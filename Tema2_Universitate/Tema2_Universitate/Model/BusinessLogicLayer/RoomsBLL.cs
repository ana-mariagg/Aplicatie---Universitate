using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2_Universitate.Model.BusinessLogicLayer
{
    internal class RoomsBLL : BaseBLL
    {
        public List<Rooms> GetAllRooms()
        {
            return context.Rooms.ToList();
        }
        //gaseste mesele
        public Rooms GetRoom(int roomsID)
        {
            return context.Rooms.FirstOrDefault(r => r.RoomNumber == roomsID);
        }
        //adauga mesele
        public void AddRoom(Rooms room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void ModifyRoom()
        {
            context.SaveChanges();
        }

        /* //salveaza modificarile facute
         public void SaveChanges(DiningTable diningTableToSave)
         {
             context.DiningTable.AddOrUpdate(diningTableToSave);
         }*/

        //sterge o masa
        public void DeleteRoom(int roomId)
        {
            context.Rooms.Remove(GetRoom(roomId));
            context.SaveChanges();
        }

        /* public DiningTable GetDiningTableNumber(int tableNumber)
         {
             //am retinute userul cu id ul cautat si apoi am returnat angajatul cu id-ul respectiv
             return context.DiningTable.FirstOrDefault(dt => dt.TableNumber == tableNumber);

         }

         public DiningTable GetEmployeeFromTableId(int employeeID)
         {
             //am retinute userul cu id ul cautat si apoi am returnat angajatul cu id-ul respectiv
             return context.DiningTable.FirstOrDefault(e => e.EmployeeID == employeeID);

         }*/
    }
}