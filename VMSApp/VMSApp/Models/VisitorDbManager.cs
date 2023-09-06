using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MySql.Data.MySqlClient;
using System.Data;

namespace VMSApp.Models
{
    public class VisitorDbManager
    {

        public static string conString = @"server=localhost;port=3306;user=root;password=root@123;database=vms";

        public static bool Insert(Visitor visitor)
        {
            bool status = false;
            Console.WriteLine(visitor.FirstName + "  " + visitor.LastName + " " + visitor.AdharNo + "  " + visitor.VDate + " " + visitor.VTime);

            string firstname = visitor.FirstName;
            string lastname = visitor.LastName;
            string adharno = visitor.AdharNo;
            DateTime Vdate = visitor.VDate;
            TimeSpan vtime = visitor.VTime;

            string query = $"insert into visitor(firstname, lastname, adharno,vdate,reason,vtime,email,admin,noofvisitor) values('{firstname}', '{vtime}', '{lastname}','{Vdate}','{visitor.Reason}','{vtime}','{visitor.Email}','{visitor.Admin}',{visitor.NoOfVisitor});";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();  //DML
                status = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
            return status;
        }





        public static List<Visitor> GetAllVisitorIn()
        {
            List<Visitor> allVisitor = new List<Visitor>();
            MySqlConnection con = new MySqlConnection(conString);

            try
            {
                string query = "select * from Visitor";
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                DataRowCollection rows = dt.Rows;
                foreach (DataRow row in rows)
                {
                    Visitor visitor = new Visitor
                    {
                        Id = int.Parse(row["vid"].ToString()),
                        FirstName = row["firstname"].ToString(),
                        LastName = row["lastname"].ToString(),
                        AdharNo = row["adharno"].ToString(),
                        Email = row["email"].ToString(),
                        Reason = row["reason"].ToString(),

                    };
                    allVisitor.Add(visitor);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return allVisitor;
        }








    }
}
