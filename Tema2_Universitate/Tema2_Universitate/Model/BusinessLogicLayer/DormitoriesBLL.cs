using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2_Universitate.Model.BusinessLogicLayer
{
    internal class DormitoriesBLL : BaseBLL
    {
        public List<Dormitories> GetAllDormitories()
        {
            return context.Dormitories.ToList();
        }
        //gaseste mesele
        public Dormitories GetDormitories(int dormitoryID)
        {
            return context.Dormitories.FirstOrDefault(d => d.DormitoryNumber == dormitoryID);
        }
        //adauga mesele
        public void AddDormitories(Dormitories dormitory)
        {
            context.Dormitories.Add(dormitory);
            context.SaveChanges();
        }

        public void ModifyDormitories()
        {
            context.SaveChanges();
        }

        /* //salveaza modificarile facute
         public void SaveChanges(DiningTable diningTableToSave)
         {
             context.DiningTable.AddOrUpdate(diningTableToSave);
         }*/

        //sterge o masa
        public void DeleteDormitories(int dormitoryId)
        {
            context.Dormitories.Remove(GetDormitories(dormitoryId));
            context.SaveChanges();
        }

        /* public Dormitories GetDormitoriesNumber(int tableNumber)
         {
             //am retinute userul cu id ul cautat si apoi am returnat angajatul cu id-ul respectiv
             return context.DiningTable.FirstOrDefault(dt => dt.TableNumber == tableNumber);

         }*/

        /* public DiningTable GetEmployeeFromTableId(int employeeID)
         {
             //am retinute userul cu id ul cautat si apoi am returnat angajatul cu id-ul respectiv
             return context.DiningTable.FirstOrDefault(e => e.EmployeeID == employeeID);

         }*/

        /* public int GetDiningTableID(string userName, string password)
         {
             //am retinute userul cu ce cautam si apoi am returnat angajatul cu id-ul respectiv
             Users user = context.Users.FirstOrDefault(u => u.Username == userName && u.Password == password);
             return context.Employee.FirstOrDefault(e => e.UserID == user.UserID).EmployeeID;
         }*/
    }
}