using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL;
using UDT;

namespace BOL
{
    /// <summary>
    /// Holds all the state needed for a sick day
    /// </summary>
    public class Sickday : ISickday
    {
        internal Sickday() { }
        public int Id { get; set; }
        public DateTime SickDate { get; set; }
        public bool FullDay { get; set; }
        public String Description { get; set; }
        public int EmployeeId { get; set; }
    }
    /// <summary>
    /// creates and inserts sickdays
    /// </summary>
    public class SickdayFactory
    {
        /// <summary>
        /// creates sickdays
        /// </summary>
        /// <returns>empty sickday object</returns>
        public static Sickday Create()
        {
            return new Sickday();
        }
        /// <summary>
        /// inserts a sickday into the db
        /// </summary>
        /// <param name="sick">all state needed for a sickday record</param>
        /// <returns>number of sickdays total</returns>
        public static int Insert(Sickday sick)
        {
            return HRSQL.InsertSickday(sick);
        }
    }
}
