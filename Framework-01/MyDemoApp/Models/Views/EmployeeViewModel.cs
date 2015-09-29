using System;
using System.ComponentModel;

namespace MyDemoApp.Models.Views
{
    public class EmployeeViewModel
    {

        // id
        [DisplayName("Id")]
        public long Id { get; set; }

        // name
        [DisplayName("Name")]
        public string Name { get; set; }

        // department_id
        [DisplayName("Department")]
        public long? DepartmentId { get; set; }

        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
    }
}