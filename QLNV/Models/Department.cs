using System;
using System.Collections.Generic;

namespace QLNV.Models;

public partial class Department
{
    public int Id { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string DepartmentCode { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int NumberOfPersonnels { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
