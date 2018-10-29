using CalendarManagment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DBManager
{
    /// <summary>
    /// Представление таблицы в БД содержащей описание одной Сущности
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class SingleEtityTable<TTable, TEntity> : DBTable<DBTableScheme<TTable, TableColumn<TTable, TEntity>, TEntity>>
        where TEntity : DBEntity, new()
        where TTable : SingleEtityTable<TTable, TEntity>
    {
        private readonly DM_SingleEntityMatrix<TEntity, TableColumn<TTable, TEntity>> _defaultMatrix;

        private readonly DM_SingleEntityMatrix<TEntity, TableColumn<TTable, TEntity>> _insertMatrix;

        /// <summary>
        /// Матрица мэпинга значений по умолчанию
        /// </summary>
        internal DM_SingleEntityMatrix<TEntity, TableColumn<TTable, TEntity>> DefaultMatrix { get { return _defaultMatrix; } }

        internal DM_SingleEntityMatrix<TEntity, TableColumn<TTable, TEntity>> InsertMatrix { get { return _insertMatrix; } }

        protected TEntity GetNewEntity() { return new TEntity(); }

        internal SingleEtityTable(DBContext context) : base(context)
        {
            _defaultMatrix = Schema.GetMatrix();

            var e = GetNewEntity();
            if (e == null)
                throw new InvalidOperationException("GetNewEntity() для таблицы '" + Name + "' вернул null. Что за бред?");

            if (e.ValuePropertiesCount() != Schema.ColumnCount)
                throw new InvalidOperationException(string.Format("Количество колонок таблицы {0} для сущности не соответствует количеству значимых свойств сущности {1}"
                    , Name
                    , typeof(TEntity).FullName));

            _insertMatrix = _defaultMatrix.TruncateMatrix(true, Schema.NotIncrementedColumns.ToArray());
        }

        /// <summary>
        /// Выборка всех значений Таблицы
        /// </summary>
        /// <returns>Возвращает ВСЕ значения таблицы</returns>
        public HashSet<TEntity> SELECT_ALL()
        {
            SqlCommand com = null;
            SqlDataReader reader = null;
            HashSet<TEntity> result = null;

            try
            {
                //берём 
                com = new SqlCommand(_Queries.SELECT_ALL_COLUMNS);//!!!
                com.Connection = Context.OpenConnection();
                reader = com.ExecuteReader();

                //заполненяет сущность значениями по матрице данных
                result = new HashSet<TEntity>(DefaultMatrix.Read(reader, GetNewEntity));
            }
            catch (Exception ex)
            {
                WriteExecuteException("Возникло исключкние при попытке выбора из БД всех записей", ex, com);
            }
            finally
            {
                DisposeResourses(com, reader);
            }

            return result;
        }

        /// <summary>
        /// Вставка значений сущностей в Таблицу
        /// </summary>
        /// <param name="entities">Значения</param>
        public virtual void INSERT(IEnumerable<TEntity> entities)
        {
            SqlCommand com = null;

            try
            {
                com = Context.GetCommandOpenedCommand(
                    SqlInsertQuery(new System.Text.StringBuilder(_Queries.INSERT), entities.ToArray()).ToString());

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteExecuteException("Возникло исключкние при попытке вставки в БД", ex, com);
            }
            finally
            {
                DisposeResourses(com);
            }
        }

        /// <summary>
        /// Удаляет значения в Таблице по указанным условиям
        /// </summary>
        /// <param name="conditions">Условия удаления из таблицы</param>
        public void DELETE_WHERE(params SqlQueryCondition[] conditions)
        {
            SqlCommand com = null;

            try
            {
                throw new NotImplementedException("Удаление не реализовано");
            }
            catch (Exception ex)
            {
                WriteExecuteException("Возникло исключение при удалении значений из Таблицы", ex, com, CommonProcs.GetConditionsInfo(conditions));
            }
            finally
            {
                DisposeResourses(com);
            }
        }

        /// <summary>
        /// Выборка всех значений по условиям
        /// </summary>
        /// <param name="conditions">Условия</param>
        /// <returns>Возвращает коллекцию результатов по условию</returns>
        public HashSet<TEntity> SELECT_WHERE(SqlQueryCondition[] conditions)
        {
            if (conditions == null || conditions.Length == 0)
                throw new ArgumentNullException("Выборка по условию вызвана по пустому набору Условий для таблицы " + Schema.StatementName);

            SqlCommand com = null;
            SqlDataReader reader = null;
            HashSet<TEntity> result = null;

            try
            {

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(" WHERE ");
                SqlQueryCondition c = null;
                for (int i = 0; i < conditions.Length; i++)
                {
                    c = conditions[i];
                    if (c == null)
                        continue;

                    if (i > 0)
                        sb.Append(" AND ");

                    sb.Append(c.ToString(sb));
                }

                com = new SqlCommand(sb.ToString());
                com.Connection = Context.OpenConnection();
                reader = com.ExecuteReader();

                //заполненяет сущность значениями по матрице данных
                result = new HashSet<TEntity>(DefaultMatrix.Read(reader, GetNewEntity));
            }
            catch (Exception ex)
            {
                WriteExecuteException("Возникло исключкние при попытке выбора из БД записей по условию", ex, com);
            }
            finally
            {
                DisposeResourses(com, reader);
            }

            return result;
        }

        /// <summary>
        /// Генерация INSERT-комманды
        /// </summary>
        /// <param name="entities">Сущности для вставки</param>
        /// <returns>ВОзвращает готовый текст SQL комманды для вставки в БД</returns>
        protected System.Text.StringBuilder SqlInsertQuery(System.Text.StringBuilder sb, params TEntity[] entities)
        {
            if (entities == null || entities.Length == 0)
                return new System.Text.StringBuilder();

            if (sb == null)
                sb = new System.Text.StringBuilder(_Queries.INSERT);

            int i = 0;
            string[] values;
            TEntity entity;
            for (int e = 0; e < entities.Length; e++)
            {
                entity = entities[e];
                sb.Append("(");

                for (i = 0; i < InsertMatrix.Width; i++)
                {
                    values = InsertMatrix.GetValues(entity);
                    sb.Append(values[i]).Append(", ");
                }

                sb.Remove(sb.Length - 2, 2);
                sb.Append("), ");

            }
            sb.Remove(sb.Length - 2, 2);

            return sb;
        }
    }
}
