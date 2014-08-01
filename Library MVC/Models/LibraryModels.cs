using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library_MVC.Models
{
    // Ovo povezuje klase sa bazom
    public class ModelContext_test : DbContext
    {
        public DbSet<WarningType> WarningTypes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Member> Members { get; set; }
    }

    // Ovako ce nam izgledati tabele u bazi
    public class WarningType
    {
        [Key]
        public int WarningTypeID { get; set; }
        public string Penalty { get; set; }
        public string Description { get; set; }
    }

    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required]
        public int? FacultyID { get; set; }
        [ForeignKey("FacultyID")]
        public virtual Faculty Faculty { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Department department { get; set; }
        public string occupation { get; set; }
    }
}