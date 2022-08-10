using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public static void SortLists()
    {
        var list = new List<Employee>();
        list.Sort(new EmployeeByIdComparer());
        list.Sort((x, y) => x.Name.CompareTo(y.Name));
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString()
    {
        return $"Id = {Id}, name = {Name}";
    }
}

public class EmployeeByIdComparer : IComparer<Employee>
{
    public int Compare(Employee x, Employee y)
    {
        return x.Id.CompareTo(y.Id);
    }
}
