using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    /// <summary>
    /// Матрица данных
    /// </summary>
    public abstract class DataMatrix<TColumn> where TColumn : DBColumn
    {

        protected readonly int _matrixWidth;

        readonly int[] _propertyMaping;

        readonly TColumn[] _columns;

        /// <summary>
        /// Индексы Свойств сущности
        /// </summary>
        protected int[] PropertiesIndexes { get { return _propertyMaping; } }
        /// <summary>
        /// Колонки результата БД
        /// </summary>
        protected TColumn[] Columns { get { return _columns; } }

        /// <summary>
        /// Вовзаращает количество колонок/значений Матрицы
        /// </summary>
        public int Width { get { return _matrixWidth; } }

        public DataMatrix(TColumn[] columns, int[] propertyMaping)
        {
            if (columns == null || columns.Length == 0)
                throw new ArgumentNullException("На формирование Матрицы не передано Колонок таблицы");
            if (propertyMaping == null || propertyMaping.Length == 0)
                throw new ArgumentNullException("На формирование Матрицы не передано коллекции с Индексами свойств");
            if (columns.Length != propertyMaping.Length)
                throw new InvalidOperationException("На формирование Матрицы передано разное количество Колонок и Индексов свойств");

            _columns = columns;
            _propertyMaping = propertyMaping;
            _matrixWidth = columns.Length;
        }


        /// <summary>
        /// Получение колонки по индексу
        /// </summary>
        /// <param name="index">Индекс колонки</param>
        /// <returns>ВОзвращает колонку по указанному индексу</returns>
        public TColumn GetColumnByIndex(int index)
        {
            if (index < _matrixWidth)
                return _columns[index];
            else
                return null;
        }
        //internal void Fill(System.Data.SqlClient.SqlDataReader reader)
        //{
        //    int rowIndex = 0;
        //    int cellIndex = 0;
        //    IDBEntity[] row;
        //    while(reader.Read())
        //    {
        //        row = _data[rowIndex];
        //        for(cellIndex = 0; cellIndex < _rowLength; cellIndex++)
        //            row[cellIndex].SetValueByIndex(_propertyMaping[cellIndex], _columns[cellIndex].GetReaderValue(reader, ref cellIndex));

        //        rowIndex++;
        //    }
        //}

    }
}
