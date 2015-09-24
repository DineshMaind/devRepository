using MyDemoApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDemoApp.Test
{
    public class FakeRespository : IRepository
    {
        private readonly Dictionary<Type, List<object>> sets = new Dictionary<Type, List<object>>();

        public void AddSet<TEntity>(IQueryable<TEntity> objects)
        {
            var list = objects.ToList().ConvertAll(x=> (object)x);
            sets.Add(typeof(TEntity), list);
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            var list = sets[typeof(TEntity)] ?? new List<object>();
            list.Add(entity);
            sets[typeof(TEntity)] = list;
            return entity;
        }

        public IEnumerable<TEntity> AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            var list = sets[typeof(TEntity)] ?? new List<object>();
            list.AddRange(entities);
            sets[typeof(TEntity)] = list;
            return entities;
        }

        public TEntity Delete<TEntity>(TEntity entity) where TEntity : class
        {
            var list = sets[typeof(TEntity)] ?? new List<object>();
            list.Remove(entity);
            sets[typeof(TEntity)] = list;
            return entity;
        }

        public IEnumerable<TEntity> DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            var list = sets[typeof(TEntity)] ?? new List<object>();
            foreach (var item in entities)
            {
                list.Remove(item);
            }
            sets[typeof(TEntity)] = list;
            return entities;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            if (!sets.ContainsKey(typeof(TEntity)) || sets[typeof(TEntity)] == null)
            {
                sets[typeof(TEntity)] = new List<object>();
            }

            return sets[typeof(TEntity)].ConvertAll(x => (TEntity)x).AsQueryable<TEntity>();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public TEntity Update<TEntity>(TEntity entity, IEnumerable<string> columnNames = null) where TEntity : class
        {
            var list = sets[typeof(TEntity)] ?? new List<object>();
            var property = typeof(TEntity).GetProperty("id");
            var value = property.GetValue(entity);

            foreach (var item in list)
            {
                var localValue = property.GetValue(item);
                
                if (localValue == value)
                {
                    var properties = typeof(TEntity).GetProperties();
                    foreach (var localPropery in properties)
                    {
                        localPropery.SetValue(item, localPropery.GetValue(entity));
                    }

                    break;
                }
            }

            sets[typeof(TEntity)] = list;

            return entity;
        }

        public IEnumerable<TEntity> UpdateRange<TEntity>(IEnumerable<TEntity> entities, IEnumerable<string> columnNames = null) where TEntity : class
        {
            var list = sets[typeof(TEntity)] ?? new List<object>();
            var property = typeof(TEntity).GetProperty("id");

            foreach (var obj in entities)
            {
                var value = property.GetValue(obj);

                foreach (var item in list)
                {
                    var localValue = property.GetValue(item);

                    if (localValue == value)
                    {
                        var properties = typeof(TEntity).GetProperties();
                        foreach (var localPropery in properties)
                        {
                            localPropery.SetValue(item, localPropery.GetValue(obj));
                        }

                        break;
                    }
                }
            }

            sets[typeof(TEntity)] = list;

            return entities;
        }

        public void Dispose()
        {
            
        }
    }
}
