using System;

namespace DBManager.Gregorian.DTO
{
    /// <summary>
    /// Регион Страны
    /// </summary>
    public class DBE_Region : DBEntity_WithID<int>
    {
        public int CountryID { get; internal set; }
        public string SysCode { get; internal set; }
        public string ISO_Code{ get; internal set; }
        public string CountryCode { get; internal set; }
        public string Code { get; internal set; }
        public string Name { get; internal set; }
        public string ProvinceType { get; internal set; }
        public string Parent { get; internal set; }
        public bool IsParent { get; internal set; }

        public DBE_Region() : base()
        {

        }
        public DBE_Region(int id) : base(id)
        {
        }

        internal override dynamic GetValueByIndex(int index)
        {
            switch(index)
            {
                case 0:
                    return ID;
                case 1:
                    return CountryID;
                case 2:
                    return SysCode;
                case 3:
                    return ISO_Code;
                case 4:
                    return CountryCode;
                case 5:
                    return Code;
                case 6:
                    return Name;
                case 7:
                    return ProvinceType;
                case 8:
                    return Parent;
                case 9:
                    return IsParent;
                default:
                    throw new IndexOutOfRangeException("Индекс свойства для DBE_Region не определён для: " + index);
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
                    CountryID = value;
                    break;
                case 2:
                    SysCode = value;
                    break;
                case 3:
                    ISO_Code = value;
                    break;
                case 4:
                    CountryCode = value;
                    break;
                case 5:
                    Code = value;
                    break;
                case 6:
                    Name = value;
                    break;
                case 7:
                    ProvinceType = value;
                    break;
                case 8:
                    Parent = value;
                    break;
                case 9:
                    IsParent = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Индекс свойства для DBE_Region не определён для: " + index);
            }
        }

        protected override void AddValues()
        {
            _strValues.Add(ID.ToString());
            _strValues.Add(CountryID.ToString());
            _strValues.Add(SysCode);
            _strValues.Add(ISO_Code);
            _strValues.Add(CountryCode);
            _strValues.Add(Code);
            _strValues.Add(Name);
            _strValues.Add(ProvinceType);
            _strValues.Add(Parent);
            _strValues.Add(IsParent ? "1" : "0");
        }

        protected override string DebugInfo()
        {
            return string.Concat(base.DebugInfo(), " | ", string.IsNullOrEmpty(Name) ? "EMPTY Name" : Name);
        }
    }
}
