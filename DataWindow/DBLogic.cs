using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        // GET User details from database
        public static IList GetData()
        {
            IList result = new ArrayList();

            using (SqlConnection conn = new SqlConnection(sConnB.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT FirstName, LastName, ID from Users", conn);

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        // create list of the data

                        var userList = new ArrayList();

                        foreach (DataRow row in dt.Rows)
                        {
                            User user = new User(row["FirstName"].ToString(), row["LastName"].ToString(), row["ID"].ToString());

                            userList.Add(user);
                        }

                        
                        result = userList;
                    }

                    Console.WriteLine("Data returned!");

                    // return data list
                    return result;
                }
                catch (Exception ex)
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    Console.WriteLine("Failed to get data!");

                    result = null;

                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }

        // ADD new user details
        public static string AddNewUser(User user)
        {
            string result = "";

            using (SqlConnection conn = new SqlConnection(sConnB.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Users_Add", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

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

        // delete all records
        public static string DeleteAllData()
        {
            string result = "";

            using(SqlConnection conn = new SqlConnection(sConnB.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("TRUNCATE TABLE Users", conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    result = "All data deleted!";
                    return result;
                }
                catch (Exception ex)
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    result = "Failed to delete all data!";

                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }


        // TODO - remove User by ID/Selection
        public static string RemoveUser(User user)
        {
            string result = "";


            using (SqlConnection conn = new SqlConnection(sConnB.ConnectionString))
            {
                try
                {
                    string idToRemove = user.ID;
                    SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE ID = " + idToRemove, conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    result = "Data removed";
                    

                    Console.WriteLine("Data removed!");

                    // return data list
                    return result;
                }
                catch (Exception ex)
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    Console.WriteLine("Failed to remove data!");

                    result = null;

                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}
