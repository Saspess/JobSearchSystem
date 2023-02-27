using AccountsMS.Data.Models.Skill;
using AccountsMS.Data.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccountsMS.Data.Repositories.Implementation
{
    public class SkillRepository : BaseRepository, ISkillRepository
    {
        public SkillRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<SkillModel>> GetAllSkillsAsync()
        {
            List<SkillModel> skills = new List<SkillModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spGetAllSkills", connection);
                command.CommandType = CommandType.StoredProcedure;

                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var skillModel = new SkillModel()
                    {
                        Id = Convert.ToInt32(reader["Skill_ID"]),
                        Name = reader["Name"].ToString()
                    };

                    skills.Add(skillModel);
                }

                return skills;
            }
        }

        public async Task<SkillModel?> GetSkillByIdAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spGetSkillById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Skill_ID", id);

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var skillModel = new SkillModel()
                    {
                        Id = Convert.ToInt32(reader["Skill_ID"]),
                        Name = reader["Name"].ToString()
                    };

                    return skillModel;
                }

                return null;
            }
        }

        public async Task CreateSkillAsync(SkillCreateModel skillCreateModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spCreateSkill", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", skillCreateModel.Name);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateSkillAsync(SkillUpdateModel skillUpdateModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spUpdateSkill", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Skill_ID", skillUpdateModel.Id);
                command.Parameters.AddWithValue("@Name", skillUpdateModel.Name);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteSkillAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("spDeleteSkill", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Skill_ID", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
