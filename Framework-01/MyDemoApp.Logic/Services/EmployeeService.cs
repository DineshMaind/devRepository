using MyDemoApp.Logic.Models;
using MyDemoApp.Core;
using MyDemoApp.Entities;

namespace MyDemoApp.Logic.Services
{
    public class EmployeeService : ModelService<employee, EmployeeModel, long>
    {
        public EmployeeService(ModelRepository db)
            : base(new ModelServiceBase<employee, EmployeeModel, long>(db, x =>
                  new EmployeeModel
                  {
                      Id = x.id,
                      Name = x.name,
                      DepartmentId = x.department_id,
                  }, x =>
                  new employee
                  {
                      id = x.Id,
                      name = x.Name,
                      department_id = x.DepartmentId,
                  }, x => x.id))
        {
        }
    }
}