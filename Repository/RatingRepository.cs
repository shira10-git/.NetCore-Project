using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly IConfiguration _configuration;
        public RatingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public RatingRepository()
        {
            
        }

        public async Task<Rating> Post(Rating r)
        {
            string query = "INSERT INTO RATING(HOST, METHOD, [PATH], REFERER, USER_AGENT, Record_Date)" +
                           "VALUES(@HOST, @METHOD, @PATH, @REFERER, @USER_AGENT, @Record_Date)";
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("School")))
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@HOST", r.Host);
                    cmd.Parameters.AddWithValue("@METHOD", r.Method);
                    cmd.Parameters.AddWithValue("@PATH", r.Path);
                    cmd.Parameters.AddWithValue("@REFERER", r.Referer);
                    cmd.Parameters.AddWithValue("@USER_AGENT", r.UserAgent);
                    cmd.Parameters.AddWithValue("@Record_Date", DateTime.Now);

                    cn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return r;
        }

    }
}
