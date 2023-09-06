namespace VMSApp.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public String Email { get; set; }
        public string AdharNo { get; set; }
        public string Reason { get; set; }



        public string Status { get; set; }
        public DateTime VDate { get; set; }
        public TimeSpan VTime { get; set; }
        public string Admin { get; set; }
        public int NoOfVisitor { get; set; }

        public Visitor(string firstName, string lastName, string email, string adharNo, string reason, string status, DateTime date, TimeSpan time)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AdharNo = adharNo;
            Reason = reason;
            Status = status;
            VDate = date;
            VTime = time;
        }

        public Visitor()
        {
        }

        public Visitor(string firstName, string lastName, string email, string adharNo, string reason, DateTime vDate, TimeSpan vTime)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AdharNo = adharNo;
            Reason = reason;
            VDate = vDate;
            VTime = vTime;
        }

        public Visitor(string firstName, string lastName, string email, string adharNo, string reason, string status, DateTime vDate, TimeSpan vTime, string admin, int noOfVisitor) : this(firstName, lastName, email, adharNo, reason, status, vDate, vTime)
        {
            Admin = admin;
            NoOfVisitor = noOfVisitor;
        }

        public Visitor(int id, string firstName, string lastName, string email, string adharNo, string reason, string status, DateTime vDate, TimeSpan vTime, string admin, int noOfVisitor)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AdharNo = adharNo;
            Reason = reason;
            Status = status;
            VDate = vDate;
            VTime = vTime;
            Admin = admin;
            NoOfVisitor = noOfVisitor;
        }
    }
}
