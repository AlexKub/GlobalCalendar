namespace ServicesCore.Work
{
    /// <summary>
    /// Рабочий календарь
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{DebugDisplay()}")]
    public abstract class WorkCalendar : CalendarServiceBase
    {
        public WorkCalendar(string conString) : base(DBType.WorkCalendar, conString) { }

        string DebugDisplay()
        {
            return (string.IsNullOrEmpty(ConnectionString) ? "EMPTY" : ConnectionString) + " | " + (string.IsNullOrEmpty(TableNamePrefix) ? "NO_PREFIX" : TableNamePrefix);
        }

         
    }
}
