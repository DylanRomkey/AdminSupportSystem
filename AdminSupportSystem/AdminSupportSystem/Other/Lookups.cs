using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using UDT;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    /// <summary>
    /// Quick class for combo or lists boxs
    /// </summary>
    public class Lookup
    {
        internal Lookup() { }

        internal string _id;
        internal string _title;

        public string Id
        {
            get
            {
                return _id;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
        }
    }

    /// <summary>
    /// Creates lookups
    /// </summary>
    public static class LookupFactory
    {
        /// <summary>
        /// creates a look up from a database table
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<Lookup> Create(dbTable t)
        {
            DataTable dt = EmployeeSQL.Retrieve(t);
            return RePackage(dt);
        }
        /// <summary>
        /// creates a look up from a data table
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<Lookup> Create(DataTable dt)
        {
            return RePackage(dt);
        }
        /// <summary>
        /// makes the look up readable for the front end
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static List<Lookup> RePackage(DataTable table)
        {
            List<Lookup> tempList = new List<Lookup>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Lookup x = new Lookup();
                x._id = table.Rows[i]["id"].ToString();
                x._title = Convert.ToString(table.Rows[i]["title"]);
                tempList.Add(x);
            }
            return tempList;
        }
    }
}
