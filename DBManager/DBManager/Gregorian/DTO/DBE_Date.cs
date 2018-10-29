using System;

namespace DBManager.Gregorian.DTO
{
    /// <summary>
    /// Дата в БД
    /// </summary>
    public class DBE_Date : DBEntity_WithID<int>
    {
        /// <summary>
        /// Индекс дня недели
        /// </summary>
        public byte WeekIndex { get; private set; }
        /// <summary>
        /// ID Месяца (порядковый номер в году)
        /// </summary>
        public byte MonthID { get; private set; }
        /// <summary>
        /// Индекс текущего дня в Месяце
        /// </summary>
        public byte MonthIndex { get; private set; }
        /// <summary>
        /// ID Сезона (индекс сезона в Году)
        /// </summary>
        public byte SeasonID { get; private set; }
        /// <summary>
        /// Индекс текущего дня в сезоне
        /// </summary>
        public byte SeasonIndex { get; private set; }
        /// <summary>
        /// ID Года (Год)
        /// </summary>
        public int YearID { get; private set; }
        /// <summary>
        /// Индекс текущего дня в Году
        /// </summary>
        public Int16 YearIndex { get; private set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime DateValue { get; private set; }

        public DBE_Date() : base() { }

        protected override void AddValues()
        {
            _strValues.Add(ID.ToString());
            _strValues.Add(WeekIndex.ToString());
            _strValues.Add(MonthID.ToString());
            _strValues.Add(MonthIndex.ToString());
            _strValues.Add(SeasonID.ToString());
            _strValues.Add(SeasonIndex.ToString());
            _strValues.Add(YearID.ToString());
            _strValues.Add(YearIndex.ToString());
            _strValues.Add(DateValue.ToShortDateString());
        }

        internal override dynamic GetValueByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return ID;
                case 1:
                    return WeekIndex;
                case 2:
                    return MonthID;
                case 3:
                    return MonthIndex;
                case 4:
                    return SeasonID;
                case 5:
                    return SeasonIndex;
                case 6:
                    return YearID;
                case 7:
                    return YearIndex;
                case 8:
                    return DateValue;
                default:
                    throw new IndexOutOfRangeException("Индекс свойства для DBE_Date не определён для: " + index);
            }
        }

        internal override void SetValueByIndex(int index, dynamic value)
        {
            switch (index)
            {
                case 0:
                    ID = value;
                    break;
                case 1:
                    WeekIndex = value;
                    break;
                case 2:
                    MonthID = value;
                    break;
                case 3:
                    MonthIndex = value;
                    break;
                case 4:
                    SeasonID = value;
                    break;
                case 5:
                    SeasonIndex = value;
                    break;
                case 6:
                    YearID = value;
                    break;
                case 7:
                    YearIndex = value;
                    break;
                case 8:
                    DateValue = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Индекс свойства для DBE_Date не определён для: " + index);
            }
        }

        protected override string DebugInfo()
        {
            return string.Concat(base.DebugInfo(), " | ", DateValue.ToShortDateString());
        }
    }
}
