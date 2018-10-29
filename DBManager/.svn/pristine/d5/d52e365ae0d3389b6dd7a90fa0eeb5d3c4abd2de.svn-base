using DBManager.Gregorian.DTO;
using DBManager.TableColumns;

namespace DBManager.Gregorian.Tables
{
    /// <summary>
    /// Таблица Рабочих Дней в БД
    /// </summary>
    public class WorkingDaysTable : TableTypes.SingleEtityTable_WithID<WorkingDaysTable, DBE_WorkingDay, int>
    {
        public const string tableName = "WorkingDays";

        internal WorkingDaysTable(DBContext context) : base(context) { }

        protected override DBTableScheme<WorkingDaysTable, TableColumn<WorkingDaysTable, DBE_WorkingDay>, DBE_WorkingDay> CreateScheme()
        {
            var s = new DBTableScheme<WorkingDaysTable, TableColumn<WorkingDaysTable, DBE_WorkingDay>, DBE_WorkingDay>(tableName, "work");
            s.AddColumn(new TC_IDInt32<WorkingDaysTable, DBE_WorkingDay>(this),                         0, true);
            s.AddColumn(new TC_Int32<WorkingDaysTable, DBE_WorkingDay>(this, "DateID"),                 1);
            s.AddColumn(new TC_Int32<WorkingDaysTable, DBE_WorkingDay>(this, "WorkingDayTypeID"),       2);
            s.AddColumn(new TC_Int32<WorkingDaysTable, DBE_WorkingDay>(this, "CountryID"),              3);
            s.AddColumn(new TC_Int32<WorkingDaysTable, DBE_WorkingDay>(this, "ProvinceID", true),       4);
            s.AddColumn(new TC_Int32<WorkingDaysTable, DBE_WorkingDay>(this, "HolyDayEventID", true),   5);

            return s;
        }
    }
}
