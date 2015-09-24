using System;
using System.ComponentModel;

namespace MyDemoApp.Models.Views
{
    public class DepartmentViewModel
    {

        // id
        [DisplayName("Id")]
        public long Id { get; set; }

        // name
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}