using System.Data;
using System.Data.SqlClient;
using TestDoubleV.DV_EF.DTO;

namespace TestDoubleV.DV_DL
{
    public class PeopleAndUserDL
    {
        /// <summary>
        /// Connection to the database for sending parameters
        /// of user and people for creating them 
        /// </summary>
        /// <param name="peopleAndUserDTO">Entity create for make 1 call of People and User entity</param>
        /// <returns>HttpResponseData Object with 2 attributes: Status and Data</returns>
        public HttpResponseData CreatePeopleAndUsers(PeopleAndUserDTO peopleAndUserDTO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringDL.DBConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_CreatePeopleAndUser", conn);
                    cmd.Parameters.AddWithValue("@Name", peopleAndUserDTO.People.Name);
                    cmd.Parameters.AddWithValue("@Lastname", peopleAndUserDTO.People.Lastname);
                    cmd.Parameters.AddWithValue("@Email", peopleAndUserDTO.People.Email);
                    cmd.Parameters.AddWithValue("@DocumentNumber", peopleAndUserDTO.People.DocumentNumber);
                    cmd.Parameters.AddWithValue("@DocumentType", peopleAndUserDTO.People.DocumentType);
                    cmd.Parameters.AddWithValue("@Username", peopleAndUserDTO.Users.Username);
                    cmd.Parameters.AddWithValue("@Password", peopleAndUserDTO.Users.Password);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                return new HttpResponseData
                {
                    Status = "Success"
                };
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
