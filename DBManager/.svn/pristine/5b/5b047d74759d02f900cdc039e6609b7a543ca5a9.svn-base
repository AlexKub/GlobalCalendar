using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarCore;

namespace DBManager.Gregorian
{
    /// <summary>
    /// Данные о Рабочем дне в БД
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{DebugDisplay()}")]
    public class WorkingDay
    {
        public long ID { get; internal set; }

        public int DateID { get; internal set; }

        public int CounrtryID { get; internal set; }

        public int? ProvinceID { get; internal set; }

        public int? HolyEventID { get; private set; }

        public WorkingDay() { }

        internal WorkingDay(long id, int dateID, int countryID, int? provinceID, int? holyEventID)
        {
            ID = id;
            DateID = dateID;
            CounrtryID = countryID;
            ProvinceID = provinceID;
            HolyEventID = holyEventID;
        }

        string DebugDisplay()
        {
            return string.Concat(ID, DateID, CounrtryID, 
                ProvinceID.HasValue ? ProvinceID.Value.ToString() : "NULL"
                , HolyEventID.HasValue ? HolyEventID.Value.ToString() : "NULL");
        }
    }
}
