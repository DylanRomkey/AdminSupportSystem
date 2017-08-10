using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BOL;
using UDT;

namespace VAL
{
    public class Validate
    {
        /// <summary>
        /// Validates that an Item's properties have been set and are acceptable
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <returns></returns>
        public static bool cleanItem(Item tmpItem)
        {
            if (tmpItem.Name.Length != 0 && tmpItem.Description.Length != 0 && tmpItem.Price.ToString().Length != 0 && 
                IsNumeric(tmpItem.Price.ToString()) == true && tmpItem.Price > 0 && tmpItem.PurchaseLocation.Length != 0 &&
                tmpItem.Quantity > 0 && IsNumeric(tmpItem.Quantity.ToString()) == true && tmpItem.Quantity.ToString().Length > 0 &&
                tmpItem.Justification.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Validates that a PurchaseOrder's properties have been set and are acceptable
        /// </summary>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static bool cleanPurchaseOrder(PurchaseOrder tmpOrder)
        {
            if (tmpOrder.OrderDate != null && tmpOrder.Subtotal != 0 && tmpOrder.Taxes != 0 && tmpOrder.Total != 0 &&
                tmpOrder.EmployeeId > 0 && tmpOrder.PurchaseOrderItemList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether the specified string is a numeric value and returns a boolean
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        /// <summary>
        /// Validates that an Employee's properties have been set and are acceptable
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public static bool cleanEmp(Employee emp)
        {
            if (emp.LastName.Length != 0 &&
                emp.FirstName != "" &&
                (emp.MiddleName.Length != 1 || emp.MiddleName.Length != 0) &&
                emp.DOB != default(DateTime) &&
                emp.Street != "" &&
                emp.City != "" &&
                emp.PostalCode != "" &&
                emp.SIN.ToString().Length != 9 &&
                emp.SeniorityDate != default(DateTime) &&
                emp.JobStartDate != default(DateTime) &&
                emp.Job != 0 &&
                emp.Department != 0 &&
                emp.PayRate > 0 &&
                emp.PreviousPayRate > 0 &&
                emp.PayRateApplied != default(DateTime) &&
                emp.WorkPhone.ToString().Length != 10 &&
                emp.CellPhone.ToString().Length != 10 &&
                emp.Email != "" &&
                emp.PayrollNotifyEmail != "")
            {
                return true;
            }
            return false;
        }

        public static bool checkEmail(String email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                throw new ArgumentException("Email is in the wrong format");
            }
        }

        public static bool checkPhone(String phone)
        {
            Int64 intPhone;
            bool tryPhone = Int64.TryParse(phone, out intPhone);
            if (phone.Length == 10 && tryPhone)
            {
                return true;
            }
            throw new ArgumentException("Phone number is in the wrong format");
        }

        public static bool checkPostal(String pc)
        {
            if (Regex.Match(pc, "[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]").Success)
            {
                return true;
            }
            throw new ArgumentException("Postalcode is in the wrong format");
        }

        public static bool checkId(int id)
        {
            return id.ToString().Length == 8;
        }
    }
}
