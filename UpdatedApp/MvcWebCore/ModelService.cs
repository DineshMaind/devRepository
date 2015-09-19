using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MvcWebCore
{
    public class ModelService<TDatabaseEntity, TModelEntity>
        where TDatabaseEntity : class
        where TModelEntity : class
    {
        private readonly ModelServiceBase<TDatabaseEntity, TModelEntity> _service = null;

        public ModelService(ModelServiceBase<TDatabaseEntity, TModelEntity> service)
        {
            this._service = service;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void Add(TModelEntity model)
        {
            this._service.Add(model);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void Delete(TModelEntity model)
        {
            this._service.Delete(model);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual IEnumerable<TModelEntity> GetObjectList(Predicate<TModelEntity> modelPredicate = null)
        {
            return this._service.GetObjectList(null, modelPredicate);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void Update(TModelEntity model, IEnumerable<string> columnNames = null)
        {
            this._service.Update(model, columnNames);
        }
    }
}