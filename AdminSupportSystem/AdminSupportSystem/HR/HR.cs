using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDT;
using SQL;
using System.Data;

namespace BOL
{
    /// <summary>
    /// Holds an HR employees id and does their functions
    /// </summary>
    public class HRUser
    {
        public int Id { get; set; }

        /// <summary>
        /// Checks that it is a pay date
        /// </summary>
        /// <returns>passcode for checking</returns>
        public static String isPaydate()
        {
            return HRSQL.PayrollCheck();
        }
        /// <summary>
        /// Executes the bi-weekly pay
        /// </summary>
        /// <returns>Paystubs</returns>
        public static DataTable generatePay()
        {
            return HRSQL.PayrollExecute();
        }
        /// <summary>
        /// Sees when the next pay will be
        /// </summary>
        /// <returns>paydate</returns>
        public static DateTime nextPaydate()
        {
            return Convert.ToDateTime(HRSQL.nextPaydate().Rows[0][0]);
        }
        /// <summary>
        /// Gives an employee a raise
        /// </summary>
        /// <param name="raise">All info needed for a raise</param>
        /// <returns>Updated raise info</returns>
        public static PayRaise UpdateRaise(IPayRaise raise)
        {
            raise = HRSQL.CommitRaise(raise, false);
            PayRaise objRaise = PayFactory.Create();
            objRaise.empId = raise.empId;
            objRaise.payIn = raise.payIn;
            objRaise.oldPay = raise.oldPay;
            objRaise.oldAffDate = raise.oldAffDate;
            objRaise.newPay = raise.newPay;
            objRaise.newAffDate = raise.newAffDate;

            return objRaise;
        }
        /// <summary>
        /// Gives all employees and departments a living cost raise
        /// </summary>
        /// <param name="raise">All info for a raise</param>
        public static void UpdateAllRaises(IPayRaise raise)
        {
            raise = HRSQL.CommitRaise(raise, true);
        }
        /// <summary>
        /// Fetchs all employee emails that have requested an email when paid
        /// </summary>
        /// <returns>list of emails</returns>
        public static List<String> PayrollEmails()
        {
            List<String> emails = new List<String>();
            DataTable dt = HRSQL.getPayrollEmail();
            foreach (DataRow row in dt.Rows)
            {
                emails.Add(row[0].ToString());
            }
            return emails;
        }
    }
}
