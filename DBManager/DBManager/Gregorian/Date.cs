using System;
using System.Collections.Generic;
using CalendarCore;

namespace DBManager.Gregorian
{
    public class Date : IDate, IYear, IRowEntity
    {
        internal const string TableName = "";

        public IEnumerable<IEvent> AllEvents
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsLeap
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public DateTime Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<IEvent> IDate.AllEvents
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IMonth IDate.Month
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IRowEntity.TableName { get { return TableName; } }

        DateTime IDate.Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        int IYear.Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IYear IDate.Year
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
