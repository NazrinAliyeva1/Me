using System.Data;
using System.Data.SqlClient;

namespace ProniaTask.Helpers
{
    public class SqlHelper
    {
        const string connectionString = @"Server=LAPTOP-PVUROI38\SQLEXPRESS;Database=MSPLATFORMST;Trusted_Connection=true;";
        public static DataTable ExecuteQuery(string query)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static int Execute(string query)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlCommand cmd = new SqlCommand(query, con);
            return cmd.ExecuteNonQuery();
        }
    
    }
}
