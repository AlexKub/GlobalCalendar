using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    internal class SingleProcedureResult<TResult> : StoredProcedureResult
    {
        /// <summary>
        /// Результат выполнения процедуры
        /// </summary>
        public TResult Result { get; private set; }

        public SingleProcedureResult(Exception ex) : base(ex) { }

        public SingleProcedureResult(TResult result)
        {
            Result = result;
        }

    }
}
