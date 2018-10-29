using CalendarManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    /// <summary>
    /// Матрица для единичной выборки
    /// </summary>
    internal class DM_SingleEntityMatrix<TEntity, TColumn> : DataMatrix<TColumn>
        where TEntity : DBEntity
        where TColumn : DBColumn
    {
        readonly string[] _insertEmptyArray;

        /// <summary>
        /// СОздание Матрицы для единичной выборки Сущности
        /// </summary>
        /// <param name="columns">Колонки, ожидаемые в выборке (в той же последоватиельности, что и Индексы свойств)</param>
        /// <param name="propertyMaping">И ндексы свойств Сущности (в том же порядке, что и Колонки в Запросе)</param>
        /// <param name="length">Предполагаемое количество строк в выборке</param>
        public DM_SingleEntityMatrix(TColumn[] columns
            , int[] propertyMaping) : base(columns, propertyMaping)
        {
            _insertEmptyArray = new string[_matrixWidth];
            int i = 0;
            do { _insertEmptyArray[i++] = "null"; } while (i < _insertEmptyArray.Length);
        }

        /// <summary>
        /// Усечение матрица
        /// </summary>
        /// <param name="include">Флаг включения/исключения указанных колонок. По умолчанию - true (в усечённой матрице будут все указанные колонки)</param>
        /// <param name="length">Предполагаемая длина выборки для указанной матрицы (по умолчанию - 1000)</param>
        /// <param name="columns">Усекаемые|Выбираемые столбцы</param>
        /// <returns>Возвращает матрицу с тем же мапингом, но без/с указанными колонками</returns>
        public DM_SingleEntityMatrix<TEntity, TColumn> TruncateMatrix(bool include, params TColumn[] columns)
        {
            if (columns == null || columns.Length == 0)
                return this;

            try
            {
                int[] mxIdexes = new int[columns.Length];
                TColumn[] mxColumns = new TColumn[columns.Length];

                TColumn curentBaseColumn;
                int k = 0;
                int mxIndex = 0;
                bool add;

                for (int i = 0; i < _matrixWidth; i++)
                {
                    curentBaseColumn = this.Columns[i];
                    for (k = 0; k < columns.Length; k++)
                    {
                        add = (columns[k] == curentBaseColumn && include)
                            || (columns[k] != curentBaseColumn && !include);

                        if (add)
                        {
                            mxColumns[mxIndex] = curentBaseColumn;
                            mxIdexes[mxIndex] = PropertiesIndexes[i];
                            mxIndex++;
                        }
                        else
                            continue;
                    }
                }

                return new DM_SingleEntityMatrix<TEntity, TColumn>(mxColumns, mxIdexes);
            }
            catch (Exception ex)
            {
                LogManager.WriteException("Возникло исклчечние при усечении Матрицы", ex
                    , new MessageParameter("Колонки матрицы", new StringBuilder().AppendColumnNames(Columns).ToString())
                    , new MessageParameter("Действие", "Возвращена текущая матрица без усечения"));

                return this;
            }
        }

        /// <summary>
        /// Заполнение сущностей по указанной выборке
        /// </summary>
        /// <param name="reader">"Экземпляр Reder'а запроса</param>
        /// <param name="entities">Сущности для заполнения данным из запроса</param>
        public void Fill(System.Data.SqlClient.SqlDataReader reader, params DBEntity[] entities)
        {
            if (entities == null || entities.Length == 0)
            {
                LogManager.WriteMessage("Не передано сущностей в Матрицу для заполнения");
                return;
            }

            if (reader == null || !reader.HasRows || reader.IsClosed)
            {
                LogManager.WriteMessage("Состояние Reder'а невалидно для заполнения значений в Матрице");
                return;
            }

            int cellIndex = 0;
            DBEntity entity;

            for (int i = 0; i < entities.Length; i++)
            {
                if (!reader.Read())
                    break;

                entity = entities[i];
                if (entity == null)
                    continue;

                for (cellIndex = 0; cellIndex < entity.ValuePropertiesCount(); cellIndex++)
                    entity.SetValueByIndex(PropertiesIndexes[cellIndex], Columns[cellIndex].GetReaderValue(reader, ref cellIndex));
            }
        }

        /// <summary>
        /// Заполнение сущностей по указанной выборке
        /// </summary>
        /// <param name="reader">"Экземпляр Reder'а запроса</param>
        /// <param name="createEntity">Ссылка метод создания сущности</param>
        public IEnumerable<T> Read<T>(System.Data.SqlClient.SqlDataReader reader, Func<T> createEntity) where T : DBEntity
        {
            if (createEntity == null)
            {
                LogManager.WriteMessage("Не передана ссылка на меод для генерации Сущностей");
                return Enumerable.Empty<T>();
            }

            if (reader == null || !reader.HasRows || reader.IsClosed)
            {
                LogManager.WriteMessage("Состояние Reder'а невалидно для заполнения значений в Матрице");
                return Enumerable.Empty<T>();
            }

            T entity;
            int cellIndex = 0;
            var result = new List<T>();

            try
            {
                while (reader.Read())
                {
                    entity = createEntity();
                    if (entity == null)
                        continue;

                    result.Add(entity);
                    for (cellIndex = 0; cellIndex < entity.ValuePropertiesCount(); cellIndex++)
                        entity.SetValueByIndex(PropertiesIndexes[cellIndex], Columns[cellIndex].GetReaderValue(reader, ref cellIndex));
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteException("Возникло исключение при считывании выборки Сущностей", ex,
                    new MessageParameter("Тип сущности", typeof(T).FullName));

                return result;
            }

            return result;
        }

        /// <summary>
        /// Получение значений Сущности для вставки
        /// </summary>
        /// <param name="entity">Сущность для получения значений</param>
        /// <returns>Возвращает значени в строковом формате. Пустые заполняются строкой "null"</returns>
        public string[] GetValues(TEntity entity)
        {
            try
            {
                string[] result = new string[_matrixWidth];
                _insertEmptyArray.CopyTo(result, 0);

                if (entity == null)
                    return result;

                dynamic value;
                for (int i = 0; i < _matrixWidth; i++)
                {
                    value = entity.GetValueByIndex(i);

                    if (value == null)
                        continue;

                    result[i] = value.ToString();

                }
                return result;
            }
            catch(Exception ex)
            {
                LogManager.WriteException("Возникло исключение при получении значений Сущности для вставки", ex);

                return _insertEmptyArray;
            }

            
        }

    }
}
