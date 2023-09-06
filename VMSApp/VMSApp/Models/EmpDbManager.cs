using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace VMSApp.Models
{
    public class EmpDbManager
    {
        Employee emp;

        public static string conString = @"server=localhost; port=3306; user=root; password=root@123; database=vms";
        public static List<Employee> GetAllEmp()
        {
            List<Employee> allemp = new List<Employee>();
            MySqlConnection con = new MySqlConnection(conString);

            try
            {
                string query = "select * from emp";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                DataRowCollection rows = dt.Rows;
                foreach (DataRow row in rows)
                {
                    Employee emp = new Employee
                    {
                        Id = int.Parse(row["eid"].ToString()),
                        Empno = int.Parse(row["empno"].ToString()),
                        FirstName = row["firstname"].ToString(),
                        LastName = row["lastname"].ToString(),
                        Email = row["email"].ToString(),
                        Password = row["password"].ToString(),
                        Role = row["role"].ToString(),
                        Status = row["status"].ToString()

                    };
                    allemp.Add(emp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return allemp;
        }

        public static void SaveNewEmp(Employee emp)
        {
            MySqlConnection con = new MySqlConnection(conString);

            try
            {
                con.Open();
                string query = $"insert into emp(firstname, lastname, role, empno ,email,password,status) values('{emp.FirstName}', '{emp.LastName}', '{emp.Role}',{emp.Empno},'{emp.Email}','{emp.Password}','{emp.Status}')";
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void DeleteEmpById(int id)
        {
            MySqlConnection con = new MySqlConnection(conString);

            try
            {
                con.Open();
                string query = "delete from emp where eid =" + id;
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void UpdateUser(int id, Employee emp)
        {
            MySqlConnection con = new MySqlConnection(conString);

            try
            {
                con.Open();
                string query = $"update emp set firstName='{emp.FirstName}', lastname='{emp.LastName}', Role='{emp.Role}' where eid={id}";
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }



        //public static Employee   AuthEmp(int empno ,String pass) {
        //        Employee emp;
        //        MySqlConnection con = new MySqlConnection(conString);

        //        try
        //        {
        //            string query = $"select * from emp  where empno={empno} and password ='{pass}'";
        //            DataSet ds = new DataSet();
        //            MySqlCommand cmd = new MySqlCommand(query, con);
        //            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //            da.Fill(ds);

        //            DataTable dt = ds.Tables[0];
        //            DataRowCollection rows = dt.Rows;
        //            foreach (DataRow row in rows)
        //            {
        //              emp=new Employee
        //                {
        //                    Id = int.Parse(row["eid"].ToString()),
        //                    Empno = int.Parse(row["empno"].ToString()),
        //                    FirstName = row["firstname"].ToString(),
        //                    LastName = row["lastname"].ToString(),
        //                    Email = row["email"].ToString(),
        //                    Password = row["password"].ToString(),
        //                    Role = row["role"].ToString(),
        //                    Status = row["status"].ToString()

        //                };

        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //       return emp;
        //    }




    }

}
