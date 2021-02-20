using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string PhotoFilename { get; set; }
    }
}
