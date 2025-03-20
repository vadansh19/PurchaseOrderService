using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonOperation
{
    /// <summary>
    /// This class inherits DbContext and is called from the service to perform database operations.
    /// </summary>
    public class DBOperation
    {

        /// <summary>
        /// Declare a static variable of PerformDBOperation.
        /// </summary>
        private static PerformDbOperation objPerformOperation;

        /// <summary>
        /// Declare a global property to get or set the static variable.
        /// </summary>
        public static PerformDbOperation ObjPerformOperation
        {
            get => objPerformOperation;
            set => objPerformOperation = value;
        }

        /// <summary>
        /// Creates an instance of PerformDBOperation with a connection string.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        /// <returns>Returns the created instance.</returns>
        public static PerformDbOperation GetInstance(string connectionString)
        {
            if (objPerformOperation == null)
            {
                objPerformOperation = new PerformDbOperation(connectionString);
            }

            return objPerformOperation;
        }

        /// <summary>
        /// Returns the existing instance of PerformDBOperation.
        /// </summary>
        /// <returns>Returns the existing instance.</returns>
        public static PerformDbOperation GetInstance()
        {
            return objPerformOperation;
        }
    }
}
