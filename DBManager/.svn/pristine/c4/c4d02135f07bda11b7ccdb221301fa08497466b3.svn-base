using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Gregorian.DTO
{
    public sealed class DBE_Country : DBEntity_WithID<int>
    {
        public string ISO_2 { get; private set; }

        public string ISO_3 { get; private set; }

        public int ISO_Num { get; private set; }

        public string Name { get; private set; }

        public string CommonName { get; private set; }

        public string OfficialName { get; private set; }

        public DBE_Country() : base() { }

        public DBE_Country(int id
            , string iso2
            , string iso3
            , int isoN
            , string name
            , string comName
            , string offName
            ) : base(id)
        {

            ISO_2 = iso2;
            ISO_3 = iso3;
            ISO_Num = isoN;
            Name = name;
            CommonName = comName;
            OfficialName = offName;
        }

        protected override void AddValues()
        {
            _strValues.Add(ID.ToString());
            _strValues.Add(ISO_2);
            _strValues.Add(ISO_3);
            _strValues.Add(ISO_Num.ToString());
            _strValues.Add(Name);
            _strValues.Add(CommonName);
            _strValues.Add(OfficialName);
        }

        internal override dynamic GetValueByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return ID;
                case 1:
                    return ISO_2;
                case 2:
                    return ISO_3;
                case 3:
                    return ISO_Num;
                case 4:
                    return Name;
                case 5:
                    return CommonName;
                case 6:
                    return OfficialName;
                default:
                    throw new IndexOutOfRangeException("При получении значения по индексу свойства в DBE_Country получен не известный индекс: " + index);
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
                    ISO_2 = value;
                    break;
                case 2:
                    ISO_3 = value;
                    break;
                case 3:
                    ISO_Num = value;
                    break;
                case 4:
                    Name = value;
                    break;
                case 5:
                    CommonName = value;
                    break;
                case 6:
                    OfficialName = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("При получении значения по индексу свойства в DBE_Country получен не известный индекс: " + index);
            }
        }

        protected override string DebugInfo()
        {
            return string.Concat(base.DebugInfo(), " | ", string.IsNullOrEmpty(Name) ? "EMPTY Name" : Name);
        }
    }
}
