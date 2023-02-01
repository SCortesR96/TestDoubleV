namespace TestDoubleV.DV_DL
{
    public class ConnectionStringDL
    {
        /// <summary>
        /// I separated Connection String because if it is neccesary to change the connection we just
        /// need to change the origin and it will be modified in the whole connections
        /// </summary>
        public static readonly string DBConnectionString = "server=DESKTOP-96E9EMA\\SQLEXPRESS; database=doublev; integrated security = true";
    }
}
