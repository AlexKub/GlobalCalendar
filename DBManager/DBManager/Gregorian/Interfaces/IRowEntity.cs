

namespace DBManager.Gregorian
{
    /// <summary>
    /// Сущность, представляющая собой строку в БД
    /// </summary>
    public interface IRowEntity 
    {
        string TableName { get; }
    }
}
