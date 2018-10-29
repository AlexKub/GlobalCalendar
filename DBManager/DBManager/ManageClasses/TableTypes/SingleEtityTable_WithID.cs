using CalendarManagment;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DBManager.TableTypes
{
    /// <summary>
    /// Сущность с 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="T_ID"></typeparam>
    public abstract class SingleEtityTable_WithID<TTable, TEntity, T_ID> : SingleEtityTable<TTable, TEntity>
        where TEntity : DBEntity_WithID<T_ID>, new()
        where TTable : SingleEtityTable_WithID<TTable, TEntity, T_ID>
    {
        public SingleEtityTable_WithID(DBContext context) : base(context) { }

        /// <summary>
        /// Заполняет экземпляр соответствующими значениями по его ID в БД
        /// </summary>
        /// <param name="id">ID в БД</param>
        /// <returns>Возвращает новый экземпляр с указанным ID</returns>
        public TEntity SELECT_ByID(T_ID id)
        {
            TEntity entity = GetNewEntity();
            entity.ID = id;

            FillByID(entity);

            return entity;
        }

        /// <summary>
        /// Заполняет данные экземпляра по его ID в БД
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Возвращает ссылку на тот же экземпляр</returns>
        public void FillByID(TEntity entity)
        {
            if (entity == null)
                return;

            SqlCommand com = null;
            SqlDataReader reader = null;

            try
            {

                com = Context.GetCommandOpenedCommand(_Queries.SELECT_BY_ID + entity.ID_ToString());

                reader = com.ExecuteReader();

                //заполненяет сущность значениями по матрице
                DefaultMatrix.Fill(reader, entity);
            }
            catch (Exception ex)
            {
                WriteExecuteException("Возникло исключкние при попытке выбора из БД по ID", ex, com,
                    new MessageParameter("ID", entity.ToString()));
            }
            finally
            {
                DisposeResourses(com, reader);
            }
        }

        /// <summary>
        /// Обновляет значение в БД по ID'шнику
        /// </summary>
        /// <param name="entity">Представление сущности в БД</param>
        /// <param name="dbColumns">Обновляемы колонки</param>
        public void UpdateByID(TEntity entity, params TableColumn<TTable, TEntity>[] dbColumns)
        {
            System.Text.StringBuilder sb = null;
            if (entity == null)
            {
                sb = new System.Text.StringBuilder();
                LogManager.WriteMessage("Попытка обновления значения таблицы по пустому значению"
                    , new MessageParameter("Обновляемые колонки", sb.AppendColumnNames(dbColumns).ToString()));
                return;
            }

            SqlCommand com = null;
            sb = new System.Text.StringBuilder();
            string[] values = null; 
            try
            {
                sb.Append("UPDATE ").Append(Schema.StatementName).Append(" SET ");

                var matrix = DefaultMatrix.TruncateMatrix(true, dbColumns);

                values = matrix.GetValues(entity);

                for(int i = 0; i < values.Length; i++)
                {
                    //получаем колонку через матрицу, т.к. значения получены через неё
                    //а порядковые индексы в переданном массиве и в матрице могут расходится
                    //будем доверять Матрице за неимением лучшего
                    sb.Append(matrix.GetColumnByIndex(i).Name);
                    sb.Append(" = ").Append(values[i]);
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - 2, 2);

                sb.Append(" WHERE ").Append(Schema.KeyColumn.Name).Append(" = ").Append(entity.ID);

                com = Context.GetCommandOpenedCommand(sb.ToString());
                com.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                sb.Clear();

                if (values == null)
                    sb.Append("NULL");
                else
                {
                    for (int i = 0; i < values.Length; i++)
                        sb.Append(values[i]).Append("; ");
                    sb.Remove(sb.Length - 2, 2);
                }

                WriteExecuteException("Возникло исключение при обновлении по ID'шнику", ex, com
                    , new MessageParameter("ID", entity.ID.ToString())
                    , new MessageParameter("Вставляемые значения", sb.ToString())
                    , new MessageParameter("Обновляемые колонки", sb.Clear().AppendColumnNames(dbColumns).ToString()));
            }
            finally
            {
                DisposeResourses(com);
            }
        }

        /// <summary>
        /// Вставка в таблицу с записбю полученных ID'шников
        /// </summary>
        /// <param name="entities">Вставляемые Сущности</param>
        public override void INSERT(IEnumerable<TEntity> entities)
        {
            SqlCommand com = null;

            try
            {
                com = new SqlCommand();
                com.Connection = Context.OpenConnection();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (var entity in entities)
                {
                    sb.Clear();
                    sb = base.SqlInsertQuery(sb.Append("BEGIN ").Append(_Queries.INSERT), entity).Append("; ");
                    sb.Append("SELECT SCOPE_IDENTITY() END");

                    //делаем запрос на каждую вставку
                    com.CommandText = sb.ToString();

                    //проставляем добавленный ID'шник
                    entity.ID = (T_ID)com.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                WriteExecuteException("ВОзникло исключение при записи параметров в таблицу с идентификатором", ex, com);
            }
            finally
            {
                DisposeResourses(com);
            }
        }

    }
}
