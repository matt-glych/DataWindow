using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWindow
{
    public static class DBLogic
    {
        public static SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-GVB8G38",
            InitialCatalog = "Users",
            PersistSecurityInfo = true,
            IntegratedSecurity = true
        };

        // ADD NEW USER TO DATABASE
        public static string AddNewUser(User user)
        {
            string result = "";

            using (SqlConnection conn = new SqlConnection(sConnB.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Users_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", user.ID);
                    cmd.Parameters.AddWithValue("@FName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LName", user.LastName);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    result = "New User Added!";
                    return result;
                }
                catch (Exception ex)
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    result = "Failed to Add New User!";

                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }

        // REMOVE USER FROM DATABASE BY ID
        public static string RemoveUser(User user)
        {
            string result = "";

            using (SqlConnection conn = new SqlConnection(sConnB.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Users_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", user.ID);
                    cmd.Parameters.AddWithValue("@FName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LName", user.LastName);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    result = "New User Added!";
                    return result;
                }
                catch (Exception ex)
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    result = "Failed to Add New User!";

                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}
