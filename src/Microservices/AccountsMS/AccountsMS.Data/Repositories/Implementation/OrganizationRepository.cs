using AccountsMS.Data.Models.Organization;
using AccountsMS.Data.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccountsMS.Data.Repositories.Implementation
{
    public class OrganizationRepository : BaseRepository, IOrganizationRepository
    {
        public OrganizationRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<OrganizationModel>> GetAllOrganizationsAsync()
        {
            List<OrganizationModel> organizations = new List<OrganizationModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spGetAllOrganizations", connection);
                command.CommandType = CommandType.StoredProcedure;

                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var organizationModel = new OrganizationModel()
                    {
                        Id = Convert.ToInt32(reader["Organization_ID"]),
                        Name = reader["Name"].ToString(),
                        Hometown = reader["Hometown"].ToString(),
                        Email = reader["Email"].ToString()
                    };

                    organizations.Add(organizationModel);
                }

                return organizations;
            }
        }

        public async Task<OrganizationModel?> GetOrganizationByIdAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spGetOrganizationById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Organization_ID", id);

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var organizationModel = new OrganizationModel()
                    {
                        Id = Convert.ToInt32(reader["Organization_ID"]),
                        Name = reader["Name"].ToString(),
                        Hometown = reader["Hometown"].ToString(),
                        Email = reader["Email"].ToString()
                    };

                    return organizationModel;
                }

                return null;
            }
        }

        public async Task<OrganizationModel?> GetOrganizationByEmailAsync(string email)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spGetOrganizationeByEmail", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Organization_ID", email);

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var organizationModel = new OrganizationModel()
                    {
                        Id = Convert.ToInt32(reader["Organization_ID"]),
                        Name = reader["Name"].ToString(),
                        Hometown = reader["Hometown"].ToString(),
                        Email = reader["Email"].ToString()
                    };

                    return organizationModel;
                }

                return null;

            }
        }

        public async Task CreateOrganizationAsync(OrganizationCreateModel organizationCreateModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spCreateOrganization", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@First_name", organizationCreateModel.Name);
                command.Parameters.AddWithValue("@Hometown", organizationCreateModel.Hometown);
                command.Parameters.AddWithValue("@Email", organizationCreateModel.Email);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateOrganizationAsync(OrganizationUpdateModel organizationUpdateModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spUpdateOrganization", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Organization_ID", organizationUpdateModel.Id);
                command.Parameters.AddWithValue("@Name", organizationUpdateModel.Name);
                command.Parameters.AddWithValue("@Hometown", organizationUpdateModel.Hometown);
                command.Parameters.AddWithValue("@Email", organizationUpdateModel.Email);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteOrganizationAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spDeleteOrganization", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Organization_ID", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
