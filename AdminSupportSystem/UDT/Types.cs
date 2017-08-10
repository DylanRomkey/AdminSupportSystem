using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UDT
{
    /// <summary>
    /// A structures to help build command parameters
    /// </summary>
    public struct parmStructure
    {
        public string parmName;
        public int parmSize;
        public object parmValue;
        public ParameterDirection parmDirection;
        public SqlDbType parmType;

        public parmStructure(string name, object value, ParameterDirection direction, SqlDbType type, int size = 0)
        {
            parmName = name;
            parmSize = size;
            parmValue = value;
            parmDirection = direction;
            parmType = type;
        }
    }

    /// <summary>
    /// Interface to be used for an Item object
    /// </summary>
    public interface IItem
    {
        int ItemId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        double Price { get; set; }
        string PurchaseLocation { get; set; }
        int Quantity { get; set; }
        string Justification { get; set; }
        string ModificationReason { get; set; }
        int OrderNumber { get; set; }
        string Status { get; set; }
        double Subtotal { get; set; }
        object Timestamp { get; set; }
    }

    /// <summary>
    /// Interface to be used for a Purchase Order object
    /// </summary>
    public interface IPurchaseOrder
    {
        int OrderNumber { get; set; }
        DateTime OrderDate { get; set; }
        string Status { get; set; }
        double Subtotal { get; set; }
        double Taxes { get; set; }
        double Total { get; set; }
        int EmployeeId { get; set; }
        List<IItem> PurchaseOrderItemList { get; set; }
    }

    /// <summary>
    /// Interface to be used for the Sickday object
    /// </summary>
    public interface ISickday
    {
        int Id { get; set; }
        DateTime SickDate { get; set; }
        bool FullDay { get; set; }
        String Description { get; set; }
        int EmployeeId { get; set; }
    }

    /// <summary>
    /// A interface for sending employee state to SQL layer
    /// </summary>
    public interface IEmployee
    {
        int Id { get; set; }
        String LastName { get; set; }
        String FirstName { get; set; }
        String MiddleName { get; set; }
        DateTime DOB { get; set; }
        String Street { get; set; }
        String City { get; set; }
        String PostalCode { get; set; }
        int SIN { get; set; }
        DateTime SeniorityDate { get; set; }
        DateTime JobStartDate { get; set; }
        int Job { get; set; }
        int Department { get; set; }
        double PayRate { get; set; }
        double PreviousPayRate { get; set; }
        DateTime PayRateApplied { get; set; }
        long WorkPhone { get; set; }
        long CellPhone { get; set; }
        String Email { get; set; }
        String PayrollNotifyEmail { get; set; }
        String Status { get; set; }
        DateTime StatusApplied { get; set; }
    }

    /// <summary>
    /// Interface used for raising an Employee's pay rate
    /// </summary>
    public interface IPayRaise
    {
        int empId { get; set; }
        double payIn { get; set; }
        double oldPay { get; set; }
        double newPay { get; set; }
        DateTime oldAffDate { get; set; }
        DateTime newAffDate { get; set; }
    }

    /// <summary>
    /// Enumeration used for various types of lookup lists
    /// </summary>
    public enum dbTable
    {
        department,
        job,
        employee,
        payroll
    }

    /// <summary>
    /// Enumeration used for various types of lookup lists
    /// </summary>
    public enum updateType
    {
        winPersonal,
        webPersonal,
        job,
        status
    }
}
