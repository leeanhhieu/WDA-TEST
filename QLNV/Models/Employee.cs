using System;
using System.Collections.Generic;

namespace QLNV.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string EmployeeCode { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string? Rank { get; set; }

    public virtual Department Department { get; set; } = null!;
}
