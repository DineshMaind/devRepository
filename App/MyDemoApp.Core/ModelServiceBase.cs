using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MyDemoApp.Core
{
    public class ModelServiceBase<TDatabaseEntity, TModelEntity>
        where TDatabaseEntity : class
        where TModelEntity : class
    {
        private readonly ModelRepository _db = null;
        private readonly Func<TDatabaseEntity, TModelEntity> _toBusinessModelExpression = null;
        private readonly Func<TModelEntity, TDatabaseEntity> _toDatabaseModelExpression = null;

        public ModelServiceBase(ModelRepository db, Func<TDatabaseEntity, TModelEntity> toBusinessModelExpression, Func<TModelEntity, TDatabaseEntity> toDataModelExpression)
        {
            this._db = db;
            this._toBusinessModelExpression = toBusinessModelExpression;
            this._toDatabaseModelExpression = toDataModelExpression;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual TDatabaseEntity Add(TModelEntity entity)
        {
            return this._db.Add(entity, this._toDatabaseModelExpression);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual TDatabaseEntity Delete(TModelEntity entity)
        {
            return this._db.Delete(entity, this._toDatabaseModelExpression);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual IEnumerable<TModelEntity> GetObjectList(Predicate<TDatabaseEntity> databasePredicate = null, Predicate<TModelEntity> modelPredicate = null)
        {
            return this._db.GetObjectList(this._toBusinessModelExpression, databasePredicate, modelPredicate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual TDatabaseEntity Update(TModelEntity entity, IEnumerable<string> columnNames = null)
        {
            return this._db.Update(entity, this._toDatabaseModelExpression, columnNames);
        }
    }
}