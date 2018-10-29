namespace DBManager.DBColumns
{
    /// <summary>
    /// Колонка с Идентификатором
    /// </summary>
    /// <typeparam name="TSqlClient">Тип SqlClient для сопоставления</typeparam>
    /// <typeparam name="TValue">Тип Значения</typeparam>
    public class DBC_ID<TSqlClient, TValue> : DBColumn<TSqlClient, TValue>
        where TSqlClient : System.Data.SqlTypes.INullable
    {
        public DBC_ID(System.Data.SqlDbType dbType, string name = "ID", int size = 0, bool autoInc = true) 
            : base(new DBColumnProperties(dbType,name, size, false, true, autoInc))
        { }
    }
}
