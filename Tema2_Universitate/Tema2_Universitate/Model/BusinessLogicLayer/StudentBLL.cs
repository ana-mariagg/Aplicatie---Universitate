using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2_Universitate.ViewModels;

namespace Tema2_Universitate.Model.BusinessLogicLayer
{
    internal class StudentBLL : BaseBLL
    {
        public List<Students> GetAllStudents()
        {
            return context.Students.ToList();
        }
        //gaseste angajatii
        public Students GetStudent(string studentID)
        {
            return context.Students.FirstOrDefault(s => s.CNP == studentID);
        }
        //adauga angajatii
        public void AddStudent(Students student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void ModifyStudent()
        {
            context.SaveChanges();
        }

        /* //salveaza modificarile facute
         public void SaveChanges(Employee employeeToSave)
         {
             context.Employee.AddOrUpdate(employeeToSave);
         }*/

        //sterge un angajat
        public void DeleteStudents(string studentId)
        {
            context.Students.Remove(GetStudent(studentId));
            context.SaveChanges();
        }

        public int GetStudentID(string userName, string password)
        {
            //am retinute userul cu ce cautam si apoi am returnat angajatul cu id-ul respectiv
            Users user = context.Users.FirstOrDefault(u => u.Username == userName && u.Password == password);
            return (int)context.Students.FirstOrDefault(s => s.UserID == user.UserID).UserID;
        }

        public string GetStudentIDSimple()
        {
            //am retinute userul cu ce cautam si apoi am returnat angajatul cu id-ul respectiv
            return context.Students.FirstOrDefault().CNP;
        }

        public Students GetStudentFromUserID(int userID)
        {
            //am retinute userul cu id ul cautat si apoi am returnat angajatul cu id-ul respectiv
            return context.Students.FirstOrDefault(s => s.UserID == userID);

        }
    }
}
