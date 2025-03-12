﻿namespace Day_05.Areas.HR.Models
{
    public class Department
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public List<Employee>? Employees { get; set; }
    }
}
