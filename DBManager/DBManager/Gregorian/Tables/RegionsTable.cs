using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBManager.Gregorian.DTO;
using DBManager.TableColumns;

namespace DBManager.Gregorian.Tables
{
    /// <summary>
    /// Таблица Регионом
    /// </summary>
    public class RegionsTable : TableTypes.SingleEtityTable_WithID<RegionsTable, DBE_Region, int>
    {
        public const string tableName = "Provinces";

        internal RegionsTable(DBContext context) : base(context) { }

        protected override DBTableScheme<RegionsTable, TableColumn<RegionsTable, DBE_Region>, DBE_Region> CreateScheme()
        {
            var s = new DBTableScheme<RegionsTable, TableColumn<RegionsTable, DBE_Region>, DBE_Region>(tableName);
            s.AddColumn(new TC_IDInt32<RegionsTable, DBE_Region>(this),                     0, true);
            s.AddColumn(new TC_Int32<RegionsTable, DBE_Region>  (this, "CountryID"),        1);
            s.AddColumn(new TC_NVChar<RegionsTable, DBE_Region> (this, "SysCode", 10),      2);
            s.AddColumn(new TC_NVChar<RegionsTable, DBE_Region> (this, "ISO_Code", 7),      3);
            s.AddColumn(new TC_NVChar<RegionsTable, DBE_Region> (this, "CountryCode", 2),   4);
            s.AddColumn(new TC_NVChar<RegionsTable, DBE_Region> (this, "Code", 4),          5);
            s.AddColumn(new TC_NVChar<RegionsTable, DBE_Region> (this, "Name", 255),        6);
            s.AddColumn(new TC_NVChar<RegionsTable, DBE_Region> (this, "ProvinceType", 30), 7);
            s.AddColumn(new TC_NVChar<RegionsTable, DBE_Region> (this, "Parent", 10),       8);
            s.AddColumn(new TC_Bit<RegionsTable, DBE_Region>    (this, "IsParent"),         9);

            return s;
        }

    }
}
