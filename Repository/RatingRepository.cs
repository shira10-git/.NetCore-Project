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
        private readonly IConfiguration configuration;
        public RatingRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public RatingRepository()
        {
            
        }

        public async Task<Rating> Post(Rating r)
        {
            string query = "INSERT INTO RATING(HOST, METHOD, [PATH], REFERER, USER_AGENT, Record_Date)" +
                           "VALUES(@HOST, @METHOD, @PATH, @REFERER, @USER_AGENT, @Record_Date)";
            using (SqlConnection cn = new SqlConnection(configuration.GetConnectionString("School")))
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
            //string query = "INSERT INTO RATING(HOST,METHOD,PATH,REFERER,USER_AGENT,Record_Date)" +
            //    "VALUES(@HOST,@METHOD,@PATH,@REFERER,@USER_AGENT,@Record_Date)";

            //using (SqlConnection cn = new SqlConnection("Data Source=srv2\\\\PUPILS;Initial Catalog=Shop_db_325338135;Trusted_Connection=True;TrustServerCertificate=True"))
            //using (SqlCommand cmd = new SqlCommand(query, cn))
            //{
            //    cmd.Parameters.Add("@HOST", SqlDbType.NVarChar, 50).Value = r.Host;
            //    cmd.Parameters.Add("@METHOD", SqlDbType.NChar).Value = r.Method;
            //    cmd.Parameters.Add("@PATH", SqlDbType.NVarChar).Value = r.Path;
            //    cmd.Parameters.Add("@REFERER", SqlDbType.NVarChar, 100).Value = r.Referer;
            //    cmd.Parameters.Add("@USER_AGENT", SqlDbType.NVarChar, 100).Value = r.UserAgent;
            //    cmd.Parameters.Add("@Record_Date", SqlDbType.DateTime, 100).Value = new DateTime();

            //    cn.Open();
            //    int rowsAffected = cmd.ExecuteNonQuery();
            //    cn.Close();

            //    return r;
            //}
        }

       
    }
}
