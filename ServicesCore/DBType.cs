namespace ServicesCore
{
    /// <summary>
    /// Тип БД
    /// </summary>
    public enum DBType
    {
        /*
         * Значения должны соответствовать индексам в таблице InternalRelations.DBTypes
         * Индексы в колонке DBType
         */
        /// <summary>
        /// Не определён (по умолчанию)
        /// </summary>
        UnKnown = 0,
        /// <summary>
        /// Рабочий календарь
        /// </summary>
        WorkCalendar = 1
    }
}
