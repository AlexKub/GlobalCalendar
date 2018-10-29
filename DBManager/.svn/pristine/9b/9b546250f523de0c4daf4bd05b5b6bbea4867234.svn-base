using System;
using System.Text;

namespace DBManager.Gregorian.DTO
{
    /// <summary>
    /// Рабочий День из БД
    /// </summary>
    public class DBE_WorkingDay : DBEntity_WithID<int>
    {
        public int DateID { get; private set; }
        public int WorkingDayTypeID { get; private set; }
        public int CountryID { get; private set; }
        public int RegionID { get; private set; }
        public int HolyDayEventID { get; private set; }

        public DBE_WorkingDay() : base() { }

        protected override void AddValues()
        {
            _strValues.Add(ID.ToString());
            _strValues.Add(DateID.ToString());
            _strValues.Add(WorkingDayTypeID.ToString());
            _strValues.Add(CountryID.ToString());
            _strValues.Add(RegionID.ToString());
            _strValues.Add(HolyDayEventID.ToString());
        }

        internal override dynamic GetValueByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return ID;
                case 1:
                    return DateID;
                case 2:
                    return WorkingDayTypeID;
                case 3:
                    return CountryID;
                case 4:
                    return RegionID;
                case 5:
                    return HolyDayEventID;
                default:
                    throw new IndexOutOfRangeException("Индекс свойства для WorkingDay не определён для: " + index);
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
                    DateID = value;
                    break;
                case 2:
                    WorkingDayTypeID = value;
                    break;
                case 3:
                    CountryID = value;
                    break;
                case 4:
                    RegionID = value;
                    break;
                case 5:
                    HolyDayEventID = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Индекс свойства для WorkingDay не определён для: " + index);
            }
        }

        protected override string DebugInfo()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            foreach (string value in _strValues)
                sb.Append(value).Append(" | ");

            sb.Remove(sb.Length - 3, 3);
            return sb.ToString();
        }
    }
}
