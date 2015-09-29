using MyDemoApp.Logic.Models;
using MyDemoApp.Core;
using MyDemoApp.Entities;

namespace MyDemoApp.Logic.Services
{
    public class DepartmentService : ModelService<department, DepartmentModel, long>
    {
        public DepartmentService(ModelRepository db)
            : base(new ModelServiceBase<department, DepartmentModel, long>(db, x =>
                  new DepartmentModel
                  {
                      Id = x.id,
                      Name = x.name,
                  }, x =>
                  new department
                  {
                      id = x.Id,
                      name = x.Name,
                  }, x => x.id))
        {
        }
    }
}