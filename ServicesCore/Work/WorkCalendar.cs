namespace ServicesCore.Work
{
    /// <summary>
    /// Рабочий календарь
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{DebugDisplay()}")]
    public abstract class WorkCalendar : CalendarServiceBase
    {
        public WorkCalendar(DB_Credentials work, DB_Credentials intern) : base(DBType.WorkCalendar, intern, work) { }

        string DebugDisplay()
        {
            return (string.IsNullOrEmpty(InternalCreds?.ConnectionString) ? "EMPTY" : InternalCreds.ConnectionString) + " | " + (string.IsNullOrEmpty(DBTypePrefix) ? "NO_PREFIX" : DBTypePrefix);
        }

         
    }
}
