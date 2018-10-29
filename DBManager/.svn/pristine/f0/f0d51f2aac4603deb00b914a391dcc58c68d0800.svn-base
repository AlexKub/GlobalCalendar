using System;

namespace DBManager.Gregorian.DTO.Service
{
    /// <summary>
    /// Информация о рабочем дне
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{DebugDisplay()}")]
    public class WorkingDateInfo
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; private set; }
        /// <summary>
        /// Тип дня (Рабочий/Нет/Сокращённый/Не определено)
        /// </summary>
        public int DateType { get; private set; }
        /// <summary>
        /// День недели
        /// </summary>
        public int WeekIndex { get; private set; }
        /// <summary>
        /// День года
        /// </summary>
        public int YearIndex { get; private set; }

        public WorkingDateInfo(DateTime date, CalendarCore.Gregorian.WorkingDayType dType, int weekI, int yearI)
        {
            Date = date;
            switch (dType)
            {
                case CalendarCore.Gregorian.WorkingDayType.NotWork:
                    DateType = 0;
                    break;
                case CalendarCore.Gregorian.WorkingDayType.Work:
                    DateType = 1;
                    break;
                case CalendarCore.Gregorian.WorkingDayType.Short:
                    DateType = 2;
                    break;
                default:
                    DateType = -1;
                    break;
            }
            WeekIndex = weekI;
            YearIndex = yearI;
        }

        string DebugDisplay()
        {
            return string.Concat(Date.ToShortDateString(), " | ", DateType.ToString());
        }
    }
}
