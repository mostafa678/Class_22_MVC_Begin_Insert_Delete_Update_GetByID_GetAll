using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVCApp.Models.Models;
using MyMVCApp.DatabaseContext.DatabaseContext;
using System.Data.Entity;

namespace MyMVCApp.Repository.Repository
{
    public class StudentRepository
    {
        StudentDBContext db = new StudentDBContext();
        public bool Add(Student student)
        {
            int isExecuted = 0;
            db.Students.Add(student);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
                return true;
            return false;
        }
        public bool Delete(Student student)
        {
            int isExecuted = 0;
            Student aStudent = db.Students.FirstOrDefault(c => c.ID == student.ID);
            if (aStudent != null)
            {
                db.Students.Remove(aStudent);
                isExecuted = db.SaveChanges();
            }

            if (isExecuted > 0)
                return true;
            return false;
        }
        public bool Update(Student student)
        {
            int isExecuted = 0;
            db.Entry(student).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
                return true;
            return false;
        }
        public List<Student> GetAll()
        {
            
            return db.Students.ToList();
        }
        public Student GetByID(Student student)
        {
            Student aStudent = db.Students.FirstOrDefault(c => c.ID == student.ID);
            return aStudent;
        }
    }
}
