using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MyDemoApp.Core
{
    public class ModelRepository : IDisposable
    {
        private readonly IRepository _db = null;

        static ModelRepository()
        {
        }

        public ModelRepository(IRepository db)
        {
            this._db = db;
        }

        private ModelRepository()
        {
        }

        public IRepository Repository { get { return this._db; } }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TDatabaseEntity Add<TModelEntity, TDatabaseEntity>(TModelEntity entity, Func<TModelEntity, TDatabaseEntity> expression)
            where TModelEntity : class
            where TDatabaseEntity : class
        {
            var toEntity = expression(entity);
            this._db.Add(toEntity);
            return toEntity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TDatabaseEntity Delete<TModelEntity, TDatabaseEntity>(TModelEntity entity, Func<TModelEntity, TDatabaseEntity> expression)
            where TModelEntity : class
            where TDatabaseEntity : class
        {
            var toEntity = expression(entity);
            this._db.Delete(toEntity);
            return toEntity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            if (this._db != null)
            {
                this._db.Dispose();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<TModelEntity> GetObjectList<TDatabaseEntity, TModelEntity>(Func<TDatabaseEntity, TModelEntity> expression, Predicate<TDatabaseEntity> databasePredicate = null, Predicate<TModelEntity> modelPredicate = null)
            where TDatabaseEntity : class
            where TModelEntity : class
        {
            databasePredicate = databasePredicate ?? delegate(TDatabaseEntity x) { return true; };
            modelPredicate = modelPredicate ?? delegate(TModelEntity x) { return true; };

            foreach (var item in this._db.Query<TDatabaseEntity>())
            {
                if (databasePredicate(item))
                {
                    var objEntity = expression(item);

                    if (modelPredicate(objEntity))
                    {
                        yield return objEntity;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int SaveChanges()
        {
            return this._db.SaveChanges();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TDatabaseEntity Update<TModelEntity, TDatabaseEntity>(TModelEntity entity, Func<TModelEntity, TDatabaseEntity> expression, IEnumerable<string> columnNames = null)
            where TModelEntity : class
            where TDatabaseEntity : class
        {
            var toEntity = expression(entity);
            this._db.Update(toEntity, columnNames);
            return toEntity;
        }
    }
}