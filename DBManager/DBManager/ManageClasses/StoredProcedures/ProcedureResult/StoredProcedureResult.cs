using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{

    internal abstract class StoredProcedureResult
    {
        public Exception Exception { get; private set; }

        public bool HasException { get; private set; }

        public System.Data.SqlClient.SqlException SqlException { get { return this.Exception as System.Data.SqlClient.SqlException; } }

        public bool HasSqlException { get { return SqlException != null; } }

        internal StoredProcedureResult() { }

        internal StoredProcedureResult(Exception ex) { this.Exception = ex; }

        internal virtual void Execute()
        {

        }
    }
}
