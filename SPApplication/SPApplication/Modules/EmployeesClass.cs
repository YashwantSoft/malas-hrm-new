using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPApplication.Modules
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
        public int ContractorId { get; set; }
        public int CategoryId { get; set; }
        public int DesignationId { get; set; }

        public int ShiftGroupId { get; set; }
        public int OverTimeApplicable { get; set; }

        public string JobProfile { get; set; }
        public DateTime? DOJ { get; set; }
        public DateTime? DateOfExit { get; set; }
        public string CategoryFName { get; set; }
    }
}
