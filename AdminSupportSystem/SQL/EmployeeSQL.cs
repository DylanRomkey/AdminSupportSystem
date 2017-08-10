using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DALvb;
using UDT;

namespace SQL
{
    /// <summary>
    /// does basic employee sql functions
    /// </summary>
    public class EmployeeSQL
    {
        /// <summary>
        /// fetches employee by different kinds of parameters
        /// </summary>
        /// <param name="t"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static DataTable Retrieve(dbTable t, int Id = 0)
        {
            List<parmStructure> lstParms = new List<parmStructure>();
            String sp = "";
            switch (t)
            {
                case dbTable.employee:
                    lstParms.Add(new parmStructure("@id", Id, ParameterDirection.Input, SqlDbType.Int));
                    sp = "EmployeeById";
                    break;
                case dbTable.department:
                    if (Id != 0)
                    {
                        lstParms.Add(new parmStructure("@id", Id, ParameterDirection.Input, SqlDbType.Int));
                        sp = "DepartmentRetrieve";
                    }
                    else
                    {
                        sp = "DepartmentLookup";
                    }
                    break;
                case dbTable.job:
                    sp = "JobLookup";
                    break;
                default:
                    throw new Exception("There was an error at the SQL layer");
            }

            return DataAccess.GetData(sp, lstParms);
        }
        /// <summary>
        /// fetches different kinds of lookups
        /// </summary>
        /// <param name="t"></param>
        /// <param name="Id"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static DataTable RetrieveLookup(dbTable t, int Id = 0, String search = "")
        {
            List<parmStructure> lstParms = new List<parmStructure>();
            String sp = "";
            switch (t)
            {
                case dbTable.employee:
                    if (Id != 0)
                    {
                        lstParms.Add(new parmStructure("@id", Id, ParameterDirection.Input, SqlDbType.Int));
                    }
                    else if (search != "")
                    {
                        lstParms.Add(new parmStructure("@search", search, ParameterDirection.Input, SqlDbType.VarChar, 50));
                    }
                    sp = "EmployeeLookup";
                    break;
                case dbTable.department:
                    sp = "DepartmentLookup";
                    break;
                case dbTable.job:
                    sp = "JobLookup";
                    break;
                default:
                    throw new Exception("There was an error at the SQL layer");
            }
            return DataAccess.GetData(sp, lstParms);
        }
        /// <summary>
        /// fetches orders by order numbers
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static DataTable RetrieveByOrderNumber(int orderNumber)
        {
            string sql = "EmployeeByOrderNumber";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@OrderNumber", orderNumber, ParameterDirection.Input, SqlDbType.Int));

            return DataAccess.GetData(sql, myparms);
        }
        /// <summary>
        /// gets employee records by name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static DataTable RetrieveByName(string firstName, string lastName)
        {
            string sql = "EmployeeByName";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@FirstName", firstName, ParameterDirection.Input, SqlDbType.VarChar, 50));
            myparms.Add(new parmStructure("@LastName", lastName, ParameterDirection.Input, SqlDbType.VarChar, 50));

            return DataAccess.GetData(sql, myparms);
        }
        /// <summary>
        /// fetches employee lists
        /// </summary>
        /// <returns></returns>
        public static DataTable RetrieveList()
        {
            string sql = "EmployeeList";
            List<parmStructure> myparms = new List<parmStructure>();

            return DataAccess.GetData(sql, myparms);
        }
        /// <summary>
        /// fetches employee access level by name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static DataTable RetrieveAccessLevel(string firstName, string lastName)
        {
            string sql = "EmployeeAccessLevel";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@FirstName", firstName, ParameterDirection.Input, SqlDbType.NVarChar, 50));
            myparms.Add(new parmStructure("@LastName", lastName, ParameterDirection.Input, SqlDbType.NVarChar, 50));

            return DataAccess.GetData(sql, myparms);
        }
        /// <summary>
        /// fetches department by employee id
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public static DataTable DepartmentByEmployeeId(int EmployeeId)
        {
            string sql = "DepartmentByEmployeeId";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@EmployeeId", EmployeeId, ParameterDirection.Input, SqlDbType.Int));

            return DataAccess.GetData(sql, myparms);
        }
        /// <summary>
        /// inserts an employee record
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public static int Insert(IEmployee emp)
        {
            List<parmStructure> lstParms = new List<parmStructure>();
            lstParms.Add(new parmStructure("@id", emp.Id, ParameterDirection.Output, SqlDbType.Int));
            lstParms.Add(new parmStructure("@Lname", emp.LastName, ParameterDirection.Input, SqlDbType.VarChar, 50));
            lstParms.Add(new parmStructure("@Fname", emp.FirstName, ParameterDirection.Input, SqlDbType.VarChar, 50));
            lstParms.Add(new parmStructure("@Mname", emp.MiddleName, ParameterDirection.Input, SqlDbType.VarChar, 50));
            lstParms.Add(new parmStructure("@bod", emp.DOB, ParameterDirection.Input, SqlDbType.Date));
            lstParms.Add(new parmStructure("@street", emp.Street, ParameterDirection.Input, SqlDbType.VarChar, 100));
            lstParms.Add(new parmStructure("@city", emp.City, ParameterDirection.Input, SqlDbType.VarChar, 50));
            lstParms.Add(new parmStructure("@PO", emp.PostalCode, ParameterDirection.Input, SqlDbType.VarChar, 6));
            lstParms.Add(new parmStructure("@SIN", emp.SIN, ParameterDirection.Input, SqlDbType.Int));
            lstParms.Add(new parmStructure("@seniority", emp.SeniorityDate, ParameterDirection.Input, SqlDbType.Date));
            lstParms.Add(new parmStructure("@jobStart", emp.JobStartDate, ParameterDirection.Input, SqlDbType.Date));
            lstParms.Add(new parmStructure("@payrate", emp.PayRate, ParameterDirection.Input, SqlDbType.Money));
            lstParms.Add(new parmStructure("@previousPayrate", emp.PreviousPayRate, ParameterDirection.Input, SqlDbType.Money));
            lstParms.Add(new parmStructure("@payrateApplied", emp.PayRateApplied, ParameterDirection.Input, SqlDbType.Date));
            lstParms.Add(new parmStructure("@workPhone", emp.WorkPhone, ParameterDirection.Input, SqlDbType.Char, 10));
            lstParms.Add(new parmStructure("@cellPhone", emp.CellPhone, ParameterDirection.Input, SqlDbType.Char, 10));
            lstParms.Add(new parmStructure("@email", emp.Email, ParameterDirection.Input, SqlDbType.VarChar, 50));
            lstParms.Add(new parmStructure("@payrollNotifyEmail", emp.PayrollNotifyEmail, ParameterDirection.Input, SqlDbType.VarChar, 50));
            lstParms.Add(new parmStructure("@job", emp.Job, ParameterDirection.Input, SqlDbType.Int));
            lstParms.Add(new parmStructure("@department", emp.Department, ParameterDirection.Input, SqlDbType.Int));

            DataAccess.SendData("[EmployeeInsert]", lstParms);

            return Convert.ToInt32(lstParms[0].parmValue);
        }
        /// <summary>
        /// updates an employee record by id
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="type"></param>
        public static void Update(IEmployee emp, updateType type)
        {
            List<parmStructure> lstParms = new List<parmStructure>();
            switch (type)
            {
                case updateType.webPersonal:
                    lstParms.Add(new parmStructure("@id", emp.Id, ParameterDirection.Input, SqlDbType.Int));
                    lstParms.Add(new parmStructure("@street", emp.Street, ParameterDirection.Input, SqlDbType.VarChar, 100));
                    lstParms.Add(new parmStructure("@city", emp.City, ParameterDirection.Input, SqlDbType.VarChar, 50));
                    lstParms.Add(new parmStructure("@PO", emp.PostalCode, ParameterDirection.Input, SqlDbType.VarChar, 6));
                    lstParms.Add(new parmStructure("@workPhone", emp.WorkPhone, ParameterDirection.Input, SqlDbType.Char, 10));
                    lstParms.Add(new parmStructure("@cellPhone", emp.CellPhone, ParameterDirection.Input, SqlDbType.Char, 10));

                    DataAccess.SendData("EmployeeUpdatePersonal", lstParms);
                    break;
                case updateType.winPersonal:
                    lstParms.Add(new parmStructure("@id", emp.Id, ParameterDirection.Input, SqlDbType.Int));
                    lstParms.Add(new parmStructure("@fname", emp.FirstName, ParameterDirection.Input, SqlDbType.VarChar, 50));
                    lstParms.Add(new parmStructure("@lname", emp.LastName, ParameterDirection.Input, SqlDbType.VarChar, 50));
                    if (emp.MiddleName != "") { lstParms.Add(new parmStructure("@mname", emp.MiddleName, ParameterDirection.Input, SqlDbType.Char, 1)); }
                    lstParms.Add(new parmStructure("@date", emp.DOB, ParameterDirection.Input, SqlDbType.Date));
                    lstParms.Add(new parmStructure("@street", emp.Street, ParameterDirection.Input, SqlDbType.VarChar, 100));
                    lstParms.Add(new parmStructure("@city", emp.City, ParameterDirection.Input, SqlDbType.VarChar, 50));
                    lstParms.Add(new parmStructure("@PO", emp.PostalCode, ParameterDirection.Input, SqlDbType.VarChar, 6));

                    DataAccess.SendData("EmployeeUpdatePersonal2", lstParms);
                    break;
                case updateType.status:
                    lstParms.Add(new parmStructure("@id", emp.Id, ParameterDirection.Input, SqlDbType.Int));
                    lstParms.Add(new parmStructure("@status", emp.Status, ParameterDirection.Input, SqlDbType.VarChar, 10));
                    lstParms.Add(new parmStructure("@date", emp.StatusApplied, ParameterDirection.Input, SqlDbType.Date));

                    DataAccess.SendData("[EmployeeUpdateStatus]", lstParms);
                    break;
                case updateType.job:
                    lstParms.Add(new parmStructure("@id", emp.Id, ParameterDirection.Input, SqlDbType.Int));
                    lstParms.Add(new parmStructure("@job", emp.Job, ParameterDirection.Input, SqlDbType.Int));
                    lstParms.Add(new parmStructure("@dep", emp.Department, ParameterDirection.Input, SqlDbType.Int));
                    lstParms.Add(new parmStructure("@pay", emp.PayRate, ParameterDirection.Input, SqlDbType.Money));
                    lstParms.Add(new parmStructure("@startDate", emp.JobStartDate, ParameterDirection.Input, SqlDbType.Date));

                    DataAccess.SendData("[EmployeeUpdateJob]", lstParms);
                    break;
            }
        }
    }
}
