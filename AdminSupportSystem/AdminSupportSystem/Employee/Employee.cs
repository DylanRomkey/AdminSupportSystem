using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UDT;
using SQL;

namespace BOL
{
    /// <summary>
    /// Holds state for employee info
    /// </summary>
    public class Employee :IEmployee
    {
        internal Employee() { }

        private int _id;
        private String _lastName;
        private String _firstName;
        private String _middleName;
        private String _street;
        private String _city;
        private String _status;
        private String _postalCode;
        private int _sin;
        private int _job;
        private int _department;
        private long _workPhone;
        private long _cellPhone;
        private String _email;
        private String _payrollNotifyEmail;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value.ToString().Length != 8)
                {
                    throw new ConstraintException("Id must be 8 digits");
                }
                _id = value;
            }
        }

        public String LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ConstraintException("Last name is too long for database");
                }
                _lastName = value;
            }
        }

        public String FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ConstraintException("First name is too long for database");
                }
                _firstName = value;
            }
        }

        public String MiddleName
        {
            get { return _middleName; }
            set
            {
                if (value.Length > 1)
                {
                    throw new ConstraintException("Middle initial must only be one letter");
                }
                _middleName = value;
            }
        }

        public DateTime DOB { get; set; }
        public String Street
        {
            get { return _street; }
            set
            {
                if (value.Length > 100)
                {
                    throw new ConstraintException("Street is too long for database");
                }
                _street = value;
            }
        }

        public String City
        {
            get { return _city; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ConstraintException("City is too long for database");
                }
                _city = value;
            }
        }

        public String PostalCode
        {
            get { return _postalCode; }
            set
            {
                if (value.Length != 6)
                {
                    throw new ConstraintException("Postal code must have a length of 6");
                }
                _postalCode = value;
            }
        }

        public int SIN
        {
            get { return _sin; }
            set
            {
                if (value.ToString().Length != 9)
                {
                    throw new ConstraintException("SIN must have a length of 9");
                }
                _sin = value;
            }
        }

        public DateTime SeniorityDate { get; set; }
        public DateTime JobStartDate { get; set; }
        public int Job
        {
            get { return _job; }
            set
            {
                _job = value;
            }
        }

        public int Department
        {
            get { return _department; }
            set
            {
                _department = value;
            }
        }

        public double PayRate { get; set; }

        public double PreviousPayRate { get; set; }

        public DateTime PayRateApplied { get; set; }

        public long WorkPhone
        {
            get { return _workPhone; }
            set
            {
                if (value.ToString().Length != 10)
                {
                    throw new ConstraintException("Work phone must be 10 digits");
                }
                _workPhone = value;
            }
        }

        public long CellPhone
        {
            get { return _cellPhone; }
            set
            {
                if (value.ToString().Length != 10)
                {
                    throw new ConstraintException("Cell phone must be 10 digits");
                }
                _cellPhone = value;
            }
        }

        public String Email
        {
            get { return _email; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ConstraintException("Email is too long for database");
                }
                _email = value;
            }
        }

        public String PayrollNotifyEmail
        {
            get { return _payrollNotifyEmail; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ConstraintException("Notify email is too long for database");
                }
                _payrollNotifyEmail = value;
            }
        }

        public String Status
        {
            get { return _status; }
            set
            {
                if (value.Length > 10)
                {
                    throw new ConstraintException("Status is too long for database");
                }
                _status = value;
            }
        }
        public DateTime StatusApplied { get; set; }
    }

    /// <summary>
    /// A class for creating Employees and its CUD
    /// </summary>
    public class EmployeeFactory
    {
        /// <summary>
        /// creates an empty employee
        /// </summary>
        /// <returns></returns>
        public static Employee Create()
        {
            return new Employee();
        }
        /// <summary>
        /// inserts a employee recoird to the db
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public static int Insert(Employee cus)
        {
            return EmployeeSQL.Insert(cus);
        }
        /// <summary>
        /// updates variouse information for an employee
        /// </summary>
        /// <param name="cus">employee info</param>
        /// <param name="type">type of information being updated</param>
        public static void Modify(Employee cus, updateType type)
        {
            EmployeeSQL.Update(cus, type);
        }
        /// <summary>
        /// looks up employees by either id or last name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lname"></param>
        /// <returns></returns>
        public static List<Lookup> Search(int id = 0, String lname = "")
        {
            if (id != 0)
            {
                return LookupFactory.Create(EmployeeSQL.RetrieveLookup(dbTable.employee, id));
            }
            else if (lname != "")
            {
                return LookupFactory.Create(EmployeeSQL.RetrieveLookup(dbTable.employee, id, '%' + lname + '%'));
            }
            else
            {
                throw new Exception("Must have a search peramater");
            }
        }
        /// <summary>
        /// fetches employee by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Employee Retrieve(int Id)
        {
            DataRow dt = EmployeeSQL.Retrieve(dbTable.employee, Id).Rows[0];
            return RePackager(dt);
        }
        /// <summary>
        /// fetches employee by name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static Employee RetrieveByName(string firstName, string lastName)
        {
            DataRow dt = EmployeeSQL.RetrieveByName(firstName, lastName).Rows[0];
            return RePackager(dt);
        }
        /// <summary>
        /// fetches a list of employees 
        /// </summary>
        /// <returns></returns>
        public static List<Employee> RetrieveList()
        {
            DataTable dt = EmployeeSQL.RetrieveList();
            return RepackagerList(dt);
        }
        /// <summary>
        /// fetches an employe by order number
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public static Employee RetrieveByOrderNumber(int OrderNumber)
        {
            DataRow dt = EmployeeSQL.RetrieveByOrderNumber(OrderNumber).Rows[0];
            return RePackager(dt);
        }
        /// <summary>
        /// fetches an access level by employee name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static string RetrieveAccessLevel(string firstName, string lastName)
        {
            DataTable dt = EmployeeSQL.RetrieveAccessLevel(firstName, lastName);
            string accessLevel = dt.Rows[0]["AccessLevel"].ToString();
            return accessLevel;
        }
        /// <summary>
        /// Sets up the data from the db for front end use
        /// </summary>
        /// <param name="dt">data row with all the info for an employee</param>
        /// <returns>filled employee</returns>
        private static Employee RePackager(DataRow dt)
        {
            Employee currEmp = new Employee();
            currEmp.Id = Convert.ToInt32(dt["id"]);
            currEmp.LastName = dt["lastName"].ToString();
            currEmp.FirstName = dt["firstName"].ToString();
            currEmp.MiddleName = dt["middleName"].ToString();
            currEmp.DOB = Convert.ToDateTime(dt["dob"]);
            currEmp.Street = dt["street"].ToString();
            currEmp.City = dt["city"].ToString();
            currEmp.PostalCode = dt["postalCode"].ToString();
            currEmp.SIN = Convert.ToInt32(dt["sin"]);
            currEmp.SeniorityDate = Convert.ToDateTime(dt["seniority"]);
            currEmp.JobStartDate = Convert.ToDateTime(dt["jobStart"]);
            currEmp.Job = Convert.ToInt32(dt["job"]);
            currEmp.Department = Convert.ToInt32(dt["department"]);
            currEmp.PayRate = Convert.ToDouble(dt["payrate"]);
            currEmp.PreviousPayRate = Convert.ToDouble(dt["previousPayrate"]);
            currEmp.PayRateApplied = Convert.ToDateTime(dt["payrateApplied"]);
            currEmp.WorkPhone = Convert.ToInt64(dt["workPhone"]);
            currEmp.CellPhone = Convert.ToInt64(dt["cellPhone"]);
            currEmp.Email = dt["email"].ToString();
            currEmp.PayrollNotifyEmail = dt["payrollNotifyEmail"].ToString();
            currEmp.Status = dt["status"].ToString();
            if (dt["statusApplied"] != DBNull.Value) { currEmp.StatusApplied = Convert.ToDateTime(dt["statusApplied"]); }

            return currEmp;
        }
        /// <summary>
        /// makes a list of employees readable for the front end
        /// </summary>
        /// <param name="tmpTable">list of employee names</param>
        /// <returns>employee names and ids</returns>
        private static List<Employee> RepackagerList(DataTable tmpTable)
        {
            List<Employee> tmpList = new List<Employee>();

            for (int i = 0; i < tmpTable.Rows.Count; i++)
            {
                Employee currEmp = new Employee();
                currEmp.Id = Convert.ToInt32(tmpTable.Rows[i]["id"]);
                currEmp.LastName = tmpTable.Rows[i]["lastName"].ToString();
                currEmp.FirstName = tmpTable.Rows[i]["firstName"].ToString();

                tmpList.Add(currEmp);
            }

            return tmpList;
        }
    }
}
