using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
    /*
    public partial class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }

   
    public partial class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        
        public virtual ICollection<Student> Students { get; set; }
    }

    /*
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Enrolment> enrolments { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Enrolment> enrolments { get; set; }
    }

    public class Enrolment
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }

        public string Grade { get; set; }
    }
    /*
    public class Company
  {
    [Key]
    public string symbol { get; set; }
    public string name { get; set; }
    public string date { get; set; }
    public bool isEnabled { get; set; }
    public string type { get; set; }
    public string iexId { get; set; }
    public List<Quote> Quotes { get; set; }
  }

  public class Quote
  {
    public int QuoteId { get; set; }
    public string date { get; set; }
    public float open { get; set; }
    public float high { get; set; }
    public float low { get; set; }
    public float close { get; set; }
    public int volume { get; set; }
    public int unadjustedVolume { get; set; }
    public float change { get; set; }
    public float changePercent { get; set; }
    public float vwap { get; set; }
    public string label { get; set; }
    public float changeOverTime { get; set; }
    public string symbol { get; set; }
  }

  public class ChartRoot
  {
    public Quote[] chart { get; set; }
  }

*/



}