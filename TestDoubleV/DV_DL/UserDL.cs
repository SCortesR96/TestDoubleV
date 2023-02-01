using System.Data;
using System.Data.SqlClient;
using TestDoubleV.DV_EF.DTO;
using TestDoubleV.DV_EF.User;

namespace TestDoubleV.DV_DL
{
    public class UserDL
    {
        /// <summary>
        /// Connection to the database and used for sending parameters
        /// and validate if credentials are correct
        /// </summary>
        /// <param name="userEF">User Entity</param>
        /// <returns>HttpResponseData Object with 2 attributes: Status and Data</returns>
        public HttpResponseData Login(UserEF userEF)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringDL.DBConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_Login", conn);
                    cmd.Parameters.AddWithValue("@Username", userEF.Username);
                    cmd.Parameters.AddWithValue("@Password", userEF.Password);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        conn.Close();
                        return new HttpResponseData
                        {
                            Status = "Success"
                        };
                    }
                    conn.Close();

                    return new HttpResponseData
                    {
                        Status = "Error",
                        Data = "Credentials are incorrect"
                    };
                }
            }
            catch (Exception e)
            {
                return new HttpResponseData
                {
                    Status = "Exception",
                    Data = e.Message
                };
            }
        }
    }
}
