using CalendarManagment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    /// <summary>
    /// Общее представление о контексте БД
    /// </summary>
    public class DBContext
    {
        readonly string _conString;

        /// <summary>
        /// Строка подключения, используемая в экземпляре
        /// </summary>
        internal string ConnectionString { get { return _conString; } }

        public DBContext(string connectionString)
        {
            _conString = connectionString;
        }

        public bool CheckConnection()
        {
            var con = OpenConnection();

            if (con == null)
                return false;

            con.Close();
            con.Dispose();

            return true;
        }

        /// <summary>
        /// Создаёт новый экземпляр Соединения с текущей строкой подключения и открывает его
        /// </summary>
        /// <returns>Возвращает открытое соединение к текущей БД</returns>
        internal SqlConnection OpenConnection()
        {
            try
            {
                var con = new SqlConnection(_conString);

                con.Open();

                return con;
            }
            catch (Exception ex)
            {
                LogManager.WriteException("Возникло исключение при открытии соединения с БД", ex
                    , new MessageParameter("Строка подключения", _conString));
                return null;
            }
        }

        /// <summary>
        /// Получение нового экземпляра SqlCommand с указанным запросом и открытым подключением
        /// </summary>
        /// <param name="text">Текст запроса</param>
        /// <returns>Возвращает новую Комманду с открытым подключением к текущей БД</returns>
        internal SqlCommand GetCommandOpenedCommand(string text)
        {
            SqlCommand com = new SqlCommand(text);
            com.Connection = OpenConnection();

            return com;
        }

        protected SqlCommand CreateProcedureCommand(string procName, params SqlParameter[] parameters)
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.CommandText = procName;

            com.Parameters.AddRange(parameters);
            return com;
        }

        protected SqlParameter CreateParameter<TValue>(string name, System.Data.SqlDbType dbType, TValue value)
        {
            var p  = new SqlParameter(name, value);
            p.SqlDbType = System.Data.SqlDbType.Date;
            return p;
        }

        /// <summary>
        /// Вызов хранимой процедуры
        /// </summary>
        /// <param name="name">Имя процедуры</param>
        /// <param name="parameters">Параметры процедуры</param>
        public void ExecProc(string name, params SqlParameter[] parameters)
        {
            SqlConnection con = null;
            SqlCommand com = null;
            try
            {
                com = CreateProcedureCommand(name, parameters);
                con = OpenConnection();
                com.Connection = con;
                com.ExecuteNonQuery();
     
            }
            catch(Exception ex)
            {
                List<MessageParameter> mParams = new List<MessageParameter>();
                mParams.Add(new MessageParameter("Имя процедуры", name));
                mParams.Add(new MessageParameter("Строка подключения", this._conString));

                StringBuilder sb = new StringBuilder();
                foreach (var p in parameters)
                {
                    sb.Clear();
                    //запись вида <Name>(<Type>; <Direction>) : <Value>
                    mParams.Add(new MessageParameter(sb.Append(p.ParameterName)
                        .Append("(")
                        .Append(p.SqlDbType.ToString())
                        .Append("; ")
                        .Append(p.Direction.ToString())
                        .Append(")").ToString()
                        , p.Value == null ? "NULL" : p.Value.ToString()));
                }

                LogManager.WriteException("Возникло исключение при стандартном вызове хранимой процедуры", ex, mParams.ToArray());
            }
            finally
            {
                if(con != null)
                {
                    con.Close();
                    con.Dispose();
                }

                if(com != null)
                {
                    com.Dispose();
                }
            }
        }
    }
}
