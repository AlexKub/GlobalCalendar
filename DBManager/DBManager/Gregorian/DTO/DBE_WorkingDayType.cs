using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Gregorian.DTO
{
    /// <summary>
    /// Тип рабочего дня в БД
    /// </summary>
    public class DBE_WorkingDayType : DBEntity_WithID<int>
    {
        public bool IsWorking { get; private set; }
        public bool IsShort { get; private set; }
        public string RussianDescription { get; private set; }

        public DBE_WorkingDayType() : base() { }

        protected override void AddValues()
        {
            _strValues.Add(ID.ToString());
            _strValues.Add(IsWorking ? "1" : "0");
            _strValues.Add(IsShort ? "1" : "0");
            _strValues.Add(RussianDescription);
        }

        internal override dynamic GetValueByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return ID;
                case 1:
                    return IsWorking;
                case 2:
                    return IsShort;
                case 3:
                    return RussianDescription;
                default:
                    throw new IndexOutOfRangeException("Индекс свойства для DBE_WorkingDayType не определён для: " + index);
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
                    IsWorking = value;
                    break;
                case 2:
                    IsShort = value;
                    break;
                case 3:
                    RussianDescription = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Индекс свойства для DBE_WorkingDayType не определён для: " + index);
            }
        }

        protected override string DebugInfo()
        {
            return string.Concat(base.DebugInfo(), " | ", string.IsNullOrEmpty(RussianDescription) ? "EMPTY DESCRIPTION" : RussianDescription);
        }
    }
}
