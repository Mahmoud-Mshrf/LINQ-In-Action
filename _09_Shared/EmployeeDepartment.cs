using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Shared
{
    public class EmployeeDepartment
    {
       public string FullName { get; set; }
       public string DepartmentName { get; set; }

        public override string ToString()
        {
            return $"{FullName} Works on {DepartmentName}";
        }
    }
}
