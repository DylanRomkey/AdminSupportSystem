using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALvb;
using UDT;

namespace SQL
{
    /// <summary>
    /// does the HR sql functionality
    /// </summary>
    public class HRSQL
    {
        /// <summary>
        /// checks to see if it is time for payroll
        /// </summary>
        /// <returns></returns>
        public static String PayrollCheck()
        {
            return DataAccess.GetData("PayrollCode").Rows[0][0].ToString();
        }
        /// <summary>
        /// executes payroll and returns stub
        /// </summary>
        /// <returns></returns>
        public static DataTable PayrollExecute()
        {
            return DataAccess.GetData("PayrollExc");
        }
        /// <summary>
        /// gets all employee emails that requested an email on payroll day
        /// </summary>
        /// <returns></returns>
        public static DataTable getPayrollEmail()
        {
            return DataAccess.GetData("[PayrollNotifyEmails]");
        }
        /// <summary>
        /// fetches the next payroll date
        /// </summary>
        /// <returns></returns>
        public static DataTable nextPaydate()
        {
            return DataAccess.GetData("PayPeriodNextPay");
        }
        /// <summary>
        /// inserts a payraise for eith an employee by id or for all employees and departments
        /// </summary>
        /// <param name="pay"></param>
        /// <param name="all"></param>
        /// <returns></returns>
        public static IPayRaise CommitRaise(IPayRaise pay, bool all)
        {
            List<parmStructure> lstParms = new List<parmStructure>();
            lstParms.Add(new parmStructure("@payIn", pay.payIn, ParameterDirection.Input, SqlDbType.Decimal));
            lstParms.Add(new parmStructure("@affDate", pay.newAffDate, ParameterDirection.Input, SqlDbType.Date));

            if (all)
            {
                DataAccess.SendData("[PayraiseLiving]", lstParms);
            }
            else
            {
                lstParms.Add(new parmStructure("@empId", pay.empId, ParameterDirection.Input, SqlDbType.Int));
                lstParms.Add(new parmStructure("@payrate", pay.newPay, ParameterDirection.Output, SqlDbType.Money));
                lstParms.Add(new parmStructure("@oldRate", pay.oldPay, ParameterDirection.Output, SqlDbType.Money));
                lstParms.Add(new parmStructure("@oldAffDate", pay.oldAffDate, ParameterDirection.Output, SqlDbType.Date));

                DataAccess.SendData("[PayraisePersonal]", lstParms);

                pay.newPay = Convert.ToDouble(lstParms[3].parmValue);
                pay.oldPay = Convert.ToDouble(lstParms[4].parmValue);
                pay.oldAffDate = Convert.ToDateTime(lstParms[5].parmValue);
            }

            return pay;
        }
        /// <summary>
        /// fetches pension records by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable getPensionInfo(int id)
        {
            List<parmStructure> lstParms = new List<parmStructure>();
            lstParms.Add(new parmStructure("@id", id, ParameterDirection.Input, SqlDbType.Int));
            return DataAccess.GetData("EmployeePensionInfo", lstParms);
        }
        /// <summary>
        /// gets the top 5 gross and years they were recieved
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable getTopGross(int id)
        {
            List<parmStructure> lstParms = new List<parmStructure>();
            lstParms.Add(new parmStructure("@id", id, ParameterDirection.Input, SqlDbType.Int));
            return DataAccess.GetData("[EmployeeTop5Gross]", lstParms);
        }
        /// <summary>
        /// inserts a sickday record
        /// </summary>
        /// <param name="sick"></param>
        /// <returns></returns>
        public static int InsertSickday(ISickday sick)
        {
            List<parmStructure> lstParms = new List<parmStructure>();
            lstParms.Add(new parmStructure("@total", 0, ParameterDirection.Output, SqlDbType.Int));
            lstParms.Add(new parmStructure("@id", sick.EmployeeId, ParameterDirection.Input, SqlDbType.Int));
            lstParms.Add(new parmStructure("@date", sick.SickDate, ParameterDirection.Input, SqlDbType.Date));
            lstParms.Add(new parmStructure("@fullDay", sick.FullDay, ParameterDirection.Input, SqlDbType.Bit));
            lstParms.Add(new parmStructure("@description", sick.Description, ParameterDirection.Input, SqlDbType.VarChar, 200));

            DataAccess.SendData("SickdayInsert", lstParms);

            return Convert.ToInt32(lstParms[0].parmValue);
        }
    }
}
