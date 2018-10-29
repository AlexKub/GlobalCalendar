using System;

namespace DBManager.Gregorian.DTO
{
    /// <summary>
    /// Событие Грегорианского календаря
    /// </summary>
    public class DBE_Event : DBEntity_WithID<int>
    {
        public string RussianName { get; private set; }

        public DBE_Event() : base() { }

        protected override void AddValues()
        {
            _strValues.Add(ID.ToString());
            _strValues.Add(RussianName);
        }

        internal override dynamic GetValueByIndex(int index)
        {
            switch(index)
            {
                case 0:
                    return ID;
                case 1:
                    return RussianName;
                default:
                    throw new IndexOutOfRangeException("Индекс свойства для DBE_Event не определён для: " + index);
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
                    RussianName = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Индекс свойства для DBE_Event не определён для: " + index);
            }
        }

        protected override string DebugInfo()
        {
            return string.Concat(base.DebugInfo(), " | ", string.IsNullOrEmpty(RussianName) ? "EMPTY" : RussianName);
        }
    }
}
