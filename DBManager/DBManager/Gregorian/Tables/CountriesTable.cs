using System;
using DBManager.Gregorian.DTO;
using DBManager.TableColumns;

namespace DBManager.Gregorian.Tables
{
    /// <summary>
    /// Представление Таблицы стран в БД
    /// </summary>
    public sealed class CountriesTable : TableTypes.SingleEtityTable_WithID<CountriesTable, DBE_Country, int>
    {
        internal const string tableName = "Countries";

        internal CountriesTable(DBContext context) : base(context) { }

        protected override DBTableScheme<CountriesTable, TableColumn<CountriesTable, DBE_Country>, DBE_Country> CreateScheme()
        {
            var scheme = new DBTableScheme<CountriesTable, TableColumn<CountriesTable, DBE_Country>, DBE_Country>(tableName);
            scheme.AddColumn(new TC_IDInt32<CountriesTable, DBE_Country>(this), 0, true);
            scheme.AddColumn(new TC_NVChar<CountriesTable, DBE_Country>(this, "ISO_2", 2), 1);
            scheme.AddColumn(new TC_NVChar<CountriesTable, DBE_Country>(this, "ISO_3", 3), 2);
            scheme.AddColumn(new TC_SmallInt<CountriesTable, DBE_Country>(this, "ISO_Num"), 3);
            scheme.AddColumn(new TC_NVChar<CountriesTable, DBE_Country>(this, "Name", 255), 4);
            scheme.AddColumn(new TC_NVChar<CountriesTable, DBE_Country>(this, "CommonName", 255), 5);
            scheme.AddColumn(new TC_NVChar<CountriesTable, DBE_Country>(this, "OfficialName", 255), 6);

            return scheme;
        }
    }
}
