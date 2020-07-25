using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp11
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        
    }

    public class BaseLogic<T>
    {
        private SchoolContext _context;

        public BaseLogic()
        {
            _context = new SchoolContext();
        }
        public  void create()
        {
        }
        public  void update()
        {

        }
        public  void Delete<T>(T item)
        {
        }
        public IList<T> getAll()
        {
            return null;
        }
    }

    public class SchoolContext : DbContext
    {

        public DbSet<StudentPoco> Students { get; set; }
        public DbSet<CoursePoco> Courses { get; set; }
        public DbSet<TeacherPoco> Teachers { get; set; }
        public DbSet<GradePoco> Marks { get; set; }

        protected override void
            OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-BILBHHR0\HUMBERBRIDGING;Initial Catalog=HUMBER_MARKS_DB;Integrated Security=True;");
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GradePoco>(
                entity =>
                entity.HasKey(entity =>
                  new { entity.CourseId, entity.StudentId }));

            base.OnModelCreating(modelBuilder);
        }
    }

    public class StudentPoco
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<CoursePoco> Courses { get; set; }
    }

    public class CoursePoco
    {
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

        [ForeignKey("TeacherId")]
        public TeacherPoco Teacher { get; set; }

    }

    public class TeacherPoco
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

    public class GradePoco
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public CoursePoco Course { get; set; }
        public StudentPoco Student { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }

    }
}
