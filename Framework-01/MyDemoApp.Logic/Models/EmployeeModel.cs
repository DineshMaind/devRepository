using System;

namespace MyDemoApp.Logic.Models
{
    public class EmployeeModel
    {

        // id
        public long Id { get; set; }

        // name
        public string Name { get; set; }

        // department_id
        public long? DepartmentId { get; set; }
    }
}