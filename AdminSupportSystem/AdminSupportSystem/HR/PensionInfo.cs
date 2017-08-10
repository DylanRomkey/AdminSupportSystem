using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL;

namespace BOL
{
    /// <summary>
    /// Holds state for Pension info
    /// </summary>
    public class Pension
    {
        internal Pension() { }
        public int Id { get; set; }
        public double FullPension { get; set; }
        public DateTime FullRetire { get; set; }
        public double At55 { get; set; }
        public double At56 { get; set; }
        public double At57 { get; set; }
        public double At58 { get; set; }
        public double At59 { get; set; }
        public bool IsOver55 { get; set; }
        public bool Is5YearsIn { get; set; }

        public List<int> Year { get; set; } = new List<int>();
        public List<double> Gross { get; set; } = new List<double>();
    }
    /// <summary>
    /// Used for pension retrieving
    /// </summary>
    public class PensionFactory
    {
        /// <summary>
        /// get pension by id
        /// </summary>
        /// <param name="Id">pension id</param>
        /// <returns>pension state</returns>
        public static Pension Retrieve(int Id)
        {
            DataRow drPen = HRSQL.getPensionInfo(Id).Rows[0];
            DataTable dtGross = HRSQL.getTopGross(Id);
            return RePackager(drPen, dtGross);
        }
        /// <summary>
        /// Sets up the data from the db for front end use
        /// </summary>
        /// <param name="drPen">a row of pension data</param>
        /// <param name="dtGross">a table of years-gross</param>
        /// <returns>a loaded pension object</returns>
        private static Pension RePackager(DataRow drPen, DataTable dtGross)
        {
            Pension currPen = new Pension();
            currPen.Id = Convert.ToInt32(drPen["id"]);
            currPen.FullPension = Convert.ToDouble(drPen["fullPensionPay"]);
            currPen.FullRetire = Convert.ToDateTime(drPen["fullRetireDate"]);
            currPen.At55 = Convert.ToDouble(drPen["at55"]);
            currPen.At56 = Convert.ToDouble(drPen["at56"]);
            currPen.At57 = Convert.ToDouble(drPen["at57"]);
            currPen.At58 = Convert.ToDouble(drPen["at58"]);
            currPen.At59 = Convert.ToDouble(drPen["at59"]);
            currPen.IsOver55 = Convert.ToBoolean(drPen["is55"]);
            currPen.Is5YearsIn = Convert.ToBoolean(drPen["is5YearsIn"]);

            for (int i = 0; i < 5; i++)
            {
                currPen.Year.Add(Convert.ToInt32(dtGross.Rows[i]["year"]));
                currPen.Gross.Add(Convert.ToDouble(dtGross.Rows[i]["gross"]));

            }

            return currPen;
        }
    }
}
