using MySql.Data.MySqlClient;
using System.Data;

namespace VMSApp.Models
{
    public class AdminDbManager
    {

        public static string conString = @"server=localhost;port=3306;user=root; password=root@123;database=vms";
        public static List<Visitor> GetAllDepartments()
        {
            List<Visitor> allDepartments = new List<Visitor>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                con.Open();
                //fire query to database
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                string query = "SELECT * FROM visitor";
                cmd.CommandText = query;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["firstname"].ToString();


                    Visitor dept = new Visitor
                    {
                        Id = id,
                        FirstName = name,

                    };
                    allDepartments.Add(dept);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                con.Close();
            }

            return allDepartments;
        }





    }
}
