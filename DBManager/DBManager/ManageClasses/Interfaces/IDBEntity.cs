using System.Collections.Generic;

namespace DBManager
{
    public abstract class DBEntity
    {
        internal abstract void SetValueByIndex(int index, dynamic value);

        internal abstract dynamic GetValueByIndex(int index);

        internal abstract int ValuePropertiesCount();

        internal abstract IEnumerable<string> GetValuesToInsert();
        
    }
}
