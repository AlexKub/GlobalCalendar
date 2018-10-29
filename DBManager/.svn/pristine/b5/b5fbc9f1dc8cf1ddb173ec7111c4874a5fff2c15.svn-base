using System;
using System.Data.SqlClient;

namespace DBManager
{
    /// <summary>
    /// Хранимая процедура
    /// </summary>
    internal abstract class StoredProcedure<TResult> where TResult : StoredProcedureResult
    {
        protected readonly string _name;
        protected readonly DBContext _context;
        protected readonly SqlParameter[] _params;
        protected readonly SqlParameter _pOutput;

        /// <summary>
        /// Имя процедуры
        /// </summary>
        public string Name { get { return _name; } }

        protected StoredProcedure(string name, DBContext context, SqlParameter pOutput, params SqlParameter[] parameters)
        {
            _name = name;
            _context = context;
            _params = parameters;
            _pOutput = pOutput;
        }

        public TResult Result { get { return _pOutput == null ? default(TResult) : _pOutput.GetSqlValue<TResult>(); } }

        /// <summary>
        /// Стандартный вызов процедуры (ExcuteNoneQuery)
        /// </summary>
        protected virtual void Execute()
        {
            SqlCommand com = null;
            SqlConnection con = null;

            try
            {
                com = new SqlCommand(Name);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Connection = _context.OpenConnection();
                com.Parameters.AddRange(_params);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //сбор подробной информации о передаваемых параметрах
                System.Collections.Generic.List<CalendarManagment.MessageParameter> listParams = CommonProcs.GetParametersInfo(_params);
                listParams.Add(new CalendarManagment.MessageParameter("Имя процедуры", Name));

                CalendarManagment.LogManager.WriteException("Возникло исключение при стандартном вызове Хранимой процедуры", ex,
                    listParams.ToArray());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
                if (com != null)
                    com.Dispose();
            }
        }
    }
}
