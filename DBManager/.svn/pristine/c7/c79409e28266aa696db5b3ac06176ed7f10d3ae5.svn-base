using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    /// <summary>
    /// КОллекция экземпляров StringBuilder
    /// </summary>
    internal class StringBuildersCollection
    {
        readonly SortedList<int, StringBuilder> _collection;
        readonly SortedList<int, bool> _lockList;


        public StringBuildersCollection(int count, int capacity = 100)
        {
            if (count < 0) count = 0;

            _collection = new SortedList<int, StringBuilder>();

            int index = 0;
            while(count != 0)
            {
                _collection.Add(index++, new StringBuilder(capacity));
                count--;
            }
            
        }

       
    }
}
