using DBManager.Gregorian.DTO;
using DBManager.TableColumns;

namespace DBManager.Gregorian.Tables
{
    /// <summary>
    /// Таблица Типов Рабочих дней
    /// </summary>
    public class WorkingDayTypesTable : TableTypes.SingleEtityTable_WithID<WorkingDayTypesTable, DBE_WorkingDayType, int>
    {
        public const string tableName = "WorkingDayTypes";

        internal WorkingDayTypesTable(DBContext context) : base(context) { }

        protected override DBTableScheme<WorkingDayTypesTable, TableColumn<WorkingDayTypesTable, DBE_WorkingDayType>, DBE_WorkingDayType> CreateScheme()
        {
            var s = new DBTableScheme<WorkingDayTypesTable, TableColumn<WorkingDayTypesTable, DBE_WorkingDayType>, DBE_WorkingDayType>(tableName, "work");
            s.AddColumn(new TC_IDInt32<WorkingDayTypesTable, DBE_WorkingDayType>(this), 0);
            s.AddColumn(new TC_Bit<WorkingDayTypesTable, DBE_WorkingDayType>(this, "IsWorking"), 1);
            s.AddColumn(new TC_Bit<WorkingDayTypesTable, DBE_WorkingDayType>(this, "IsShort"), 2);
            s.AddColumn(new TC_NVChar<WorkingDayTypesTable, DBE_WorkingDayType>(this, "RussianDescription"), 3);

            return s;
        }
    }
}
