using MyDemoApp.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyDemoApp.Test
{
    public class TestData
    {
        public static IQueryable<employee> GetEmployees()
        {
            var employees = new List<employee>();

            for (int x = 0; x < 10000; x++)
            {
                employees.Add(new employee { id = x + 1, name = "Name " + (x + 1) });
            }

            return employees.AsQueryable();
        }
    }
}