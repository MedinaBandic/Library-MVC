using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

/*
 * Scaffoldanje:
    Scaffold Controller WarningType -force
    Scaffold Controller Faculty -force
    Scaffold Controller Department -force
    Scaffold Controller Member -force
    Scaffold Controller Author -force
    Scaffold Controller Publisher -force
    Scaffold Controller LiteratureType -force
    Scaffold Controller Literature -force
    Scaffold Controller Warning -force
    Scaffold Controller Lending -force
 */

namespace Library_MVC.Models
{
    // Ovako ce nam izgledati tabele u bazi
    public class WarningType
    {
        [Key]
        [Required]
        public int WarningTypeID { get; set; }

        [Required]
        public string Penalty { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public class Faculty
    {
        [Key]
        [Required]
        public int FacultyID { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class Department
    {
        [Key]
        [Required]
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
        [Required]
        public int MemberID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public int? DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        [Required]
        public string Occupation { get; set; } // Mozda i ovo da moze biti null ?
    }

    public class Author
    {
        [Key]
        [Required]
        public int AuthorID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Period { get; set; }
    }

    public class Publisher
    {
        [Key]
        [Required]
        public int PublisherID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }
    }

    public class LiteratureType
    {
        [Key]
        [Required]
        public int TypeID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Genre { get; set; } //null
    }
     
    public class Literature
    {
        [Key]
        [Required]
        public long ISBN { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public virtual Author Author { get; set; }

        [Required]
        public int? PublisherID { get; set; }
        [ForeignKey("PublisherID")]
        public virtual Publisher Publisher { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public int NumberOfCopies { get; set; }

        [Required]
        public bool Reliability { get; set; }

        [Required]
        public int? TypeID { get; set; }
        [ForeignKey("TypeID")]
        public virtual LiteratureType LiteratureType { get; set; }
    }

    public class Warning
    {
        [Key]
        [Required]
        public int WarningID { get; set; }

        [Required]
        public int? WarningTypeID { get; set; }
        [ForeignKey("WarningTypeID")]
        public virtual WarningType WarningType { get; set; }

        [Required]
        public int? MemberID { get; set; }
        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }
    }

    public class Lending
    {
        [Key]
        [Required]
        public int LendingID { get; set; }

        [Required]
        public int? MemberID { get; set; } 
        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }

        [Required]
        public long? ISBN { get; set; }
        [ForeignKey("ISBN")]
        public virtual Literature Literature { get; set; }

        [Required]
        public DateTime LendingDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        public DateTime RenewalDate { get; set; } 
    }

}