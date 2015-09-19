using MvcWebCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MvcWebEntities
{
    public partial class MvcWebDBEntities : IRepository
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry(entity).State = System.Data.Entity.EntityState.Added;
            return entity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<TEntity> AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Parallel.ForEach(entities, entity =>
            {
                base.Entry(entity).State = System.Data.Entity.EntityState.Added;
            });

            return entities;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TEntity Delete<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return entity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<TEntity> DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Parallel.ForEach(entities, entity =>
            {
                base.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            });

            return entities;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>().AsNoTracking() as IQueryable<TEntity>;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TEntity Update<TEntity>(TEntity entity, IEnumerable<string> columnNames = null) where TEntity : class
        {
            if (base.Entry(entity).State == System.Data.Entity.EntityState.Detached)
            {
                base.Set<TEntity>().Attach(entity);
            }

            if (columnNames != null && columnNames.Count() > 0)
            {
                columnNames = GetMappedColumnNames(typeof(TEntity), columnNames);

                foreach (var columnName in columnNames)
                {
                    base.Entry<TEntity>(entity).Property(columnName).IsModified = true;
                }
            }
            else
            {
                base.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }

            return entity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<TEntity> UpdateRange<TEntity>(IEnumerable<TEntity> entities, IEnumerable<string> columnNames = null) where TEntity : class
        {
            Parallel.ForEach(entities, entity =>
            {
                if (base.Entry(entity).State == System.Data.Entity.EntityState.Detached)
                {
                    base.Set<TEntity>().Attach(entity);
                }

                if (columnNames != null && columnNames.Count() > 0)
                {
                    columnNames = GetMappedColumnNames(typeof(TEntity), columnNames);

                    foreach (var columnName in columnNames)
                    {
                        base.Entry<TEntity>(entity).Property(columnName).IsModified = true;
                    }
                }
                else
                {
                    base.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                }
            });

            return entities;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private IEnumerable<string> GetMappedColumnNames(Type type, IEnumerable<string> columnNames)
        {
            IList<string> mappedColumnNames = new List<string>();

            if (columnNames != null && columnNames.Count() > 0)
            {
                var typeNames = (from x in type.GetProperties() select x.Name).ToDictionary(x => x.ToLower(), x => x);

                foreach (var item in columnNames)
                {
                    if (typeNames.ContainsKey(item.ToLower()))
                    {
                        mappedColumnNames.Add(typeNames[item.ToLower()]);
                    }
                }
            }

            return mappedColumnNames;
        }
    }
}