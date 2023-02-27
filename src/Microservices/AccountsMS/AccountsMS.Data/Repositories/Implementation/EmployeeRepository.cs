using AccountsMS.Data.Models.Employee;
using AccountsMS.Data.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccountsMS.Data.Repositories.Implementation
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            using(var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spGetAllEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                var reader = await command.ExecuteReaderAsync();

                while(await reader.ReadAsync())
                {
                    var employeeModel = new EmployeeModel()
                    {
                        Id = Convert.ToInt32(reader["Employee_ID"]),
                        OrganizationId = Convert.ToInt32(reader["Organization_ID"]),
                        FirstName = reader["First_name"].ToString(),
                        LastName = reader["Last_name"].ToString(),
                        Hometown = reader["Hometown"].ToString(),
                        Email = reader["Email"].ToString()
                    };

                    employees.Add(employeeModel);
                }

                return employees;
            }
        }

        public async Task<EmployeeModel?> GetEmployeeByIdAsync(int id)
        {
            using(var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spGetEmployeeById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Employee_ID", id);

                var reader = await command.ExecuteReaderAsync();

                if(await reader.ReadAsync())
                {
                    var employeeModel = new EmployeeModel()
                    {
                        Id = Convert.ToInt32(reader["Employee_ID"]),
                        OrganizationId = Convert.ToInt32(reader["Organization_ID"]),
                        FirstName = reader["First_name"].ToString(),
                        LastName = reader["Last_name"].ToString(),
                        Hometown = reader["Hometown"].ToString(),
                        Email = reader["Email"].ToString()
                    };

                    return employeeModel;
                }
                    
                return null;
            }
        }

        public async Task<EmployeeModel?> GetEmployeeByEmailAsync(string email)
        {
            using(var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spGetEmployeeByEmail", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Employee_ID", email);

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var employeeModel = new EmployeeModel()
                    {
                        Id = Convert.ToInt32(reader["Employee_ID"]),
                        OrganizationId = Convert.ToInt32(reader["Organization_ID"]),
                        FirstName = reader["First_name"].ToString(),
                        LastName = reader["Last_name"].ToString(),
                        Hometown = reader["Hometown"].ToString(),
                        Email = reader["Email"].ToString()
                    };

                    return employeeModel;
                }
                    
                return null;
            }
        }

        public async Task CreateEmployeeAsync(EmployeeCreateModel employeeCreateModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spCreateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Organization_ID", employeeCreateModel.OrganizationId);
                command.Parameters.AddWithValue("@First_name", employeeCreateModel.FirstName);
                command.Parameters.AddWithValue("@Last_name", employeeCreateModel.LastName);
                command.Parameters.AddWithValue("@Hometown", employeeCreateModel.Hometown);
                command.Parameters.AddWithValue("@Email", employeeCreateModel.Email);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateEmployeeAsync(EmployeeUpdateModel employeeUpdateModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spUpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Employee_ID", employeeUpdateModel.Id);
                command.Parameters.AddWithValue("@Organization_ID", employeeUpdateModel.OrganizationId);
                command.Parameters.AddWithValue("@First_name", employeeUpdateModel.FirstName);
                command.Parameters.AddWithValue("@Last_name", employeeUpdateModel.LastName);
                command.Parameters.AddWithValue("@Hometown", employeeUpdateModel.Hometown);
                command.Parameters.AddWithValue("@Email", employeeUpdateModel.Email);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spDeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Employee_ID", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
