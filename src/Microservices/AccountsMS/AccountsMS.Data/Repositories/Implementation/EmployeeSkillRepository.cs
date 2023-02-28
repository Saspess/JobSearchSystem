using AccountsMS.Data.Models.EmployeeSkill;
using AccountsMS.Data.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccountsMS.Data.Repositories.Implementation
{
    public class EmployeeSkillRepository : BaseRepository, IEmployeeSkillRepository
    {
        public EmployeeSkillRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<EmployeeSkillModel>> GetAllEmployeeSkillsAsync()
        {
            List<EmployeeSkillModel> employeeSkills = new List<EmployeeSkillModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spGetEmployeeSkills", connection);
                command.CommandType = CommandType.StoredProcedure;

                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var employeeSkillModel = new EmployeeSkillModel()
                    {
                        Name = reader["Name"].ToString(),
                        ConfirmationCount = Convert.ToInt32(reader["Confirmation_count"])
                    };

                    employeeSkills.Add(employeeSkillModel);
                }

                return employeeSkills;
            }
        }

        public async Task AddEmployeeSkillAsync(int employeeId, int skillId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spAddEmployeeSkill", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Employee_ID", employeeId);
                command.Parameters.AddWithValue("@Skill_ID", skillId);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task ConfirmEmployeeSkillAsync(int employeeId, int skillId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spConfirmEmployeeSkill", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Employee_ID", employeeId);
                command.Parameters.AddWithValue("@Skill_ID", skillId);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteEmployeeSkillAsync(int employeeId, int skillId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spDeleteEmployeeSkill", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Employee_ID", employeeId);
                command.Parameters.AddWithValue("@Skill_ID", skillId);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
