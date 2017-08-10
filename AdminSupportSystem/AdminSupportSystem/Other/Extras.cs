using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDT;

namespace BOL
{
    /// <summary>
    /// holds state for all the payraise info
    /// </summary>
    public class PayRaise : IPayRaise
    {
        internal PayRaise() { }

        public int empId { get; set; }

        public double payIn { get; set; }

        public double oldPay { get; set; }

        public double newPay { get; set; }

        public DateTime oldAffDate { get; set; }

        public DateTime newAffDate { get; set; }

        public void selfCheck(int id)
        {
            if (id == empId)
            {
                throw new ConstraintException("You cannot give yourself a raise");
            }
        }
    }
    /// <summary>
    /// used to vreate new payraise objects
    /// </summary>
    public class PayFactory
    {
        /// <summary>
        /// creates and empty payraise object
        /// </summary>
        /// <returns></returns>
        public static PayRaise Create()
        {
            return new PayRaise();
        }


    }
    /// <summary>
    /// used to hold department record state
    /// </summary>
    public class Department
    {
        internal Department() { }

        public int Id { get; set; }

        public String Title { get; set; }

        public int Supervisor { get; set; }

        public string SupervisorName { get; set; }
    }
    /// <summary>
    /// used to create and fetche department info
    /// </summary>
    public class DepartmentFactory
    {
        /// <summary>
        /// vreates and empty department object
        /// </summary>
        /// <returns></returns>
        public static Department Create()
        {
            return new Department();
        }
        /// <summary>
        /// fetches a department object
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Department Retrieve(int Id)
        {
            DataRow dt = EmployeeSQL.Retrieve(dbTable.department, Id).Rows[0];
            return RePackager(dt);
        }
        /// <summary>
        /// fetches a department object by employee id
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public static Department RetrieveByEmployeeId(int EmployeeId)
        {
            DataRow dt = EmployeeSQL.DepartmentByEmployeeId(EmployeeId).Rows[0];
            return RePackager(dt);
        }
        /// <summary>
        /// makes a department recored readable for the front end
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static Department RePackager(DataRow dt)
        {
            Department currDep = new Department();
            currDep.Id = Convert.ToInt32(dt["id"]);
            currDep.Title = dt["title"].ToString();
            currDep.Supervisor = Convert.ToInt32(dt["supervisor"]);
            currDep.SupervisorName = dt["supervisorName"].ToString();

            return currDep;
        }

    }
    /// <summary>
    /// used to hold a job records state
    /// </summary>
    public class Job
    {
        internal Job() { }

        public int Id { get; set; }

        public String Title { get; set; }

        public double MaxPay { get; set; }
    }
    /// <summary>
    /// used to create and fetche job info
    /// </summary>
    public class JobFactory
    {
        /// <summary>
        /// creates and empty job object
        /// </summary>
        /// <returns></returns>
        public static Job Create()
        {
            return new Job();
        }
        /// <summary>
        /// fetches a job record from the db
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Job Retrieve(int Id)
        {
            DataRow dt = EmployeeSQL.Retrieve(dbTable.job, Id).Rows[0];
            return RePackager(dt);
        }
        /// <summary>
        /// makes a job record redable for the front end
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static Job RePackager(DataRow dt)
        {
            Job currJob = new Job();
            currJob.Id = Convert.ToInt32(dt["id"]);
            currJob.Title = dt["title"].ToString();
            currJob.MaxPay = Convert.ToInt64(dt["supervisor"]);

            return currJob;
        }

    }
}
