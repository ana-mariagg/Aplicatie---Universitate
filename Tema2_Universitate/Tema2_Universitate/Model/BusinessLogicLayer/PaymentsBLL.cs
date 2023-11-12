using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Tema2_Universitate.Model.BusinessLogicLayer
{
    internal class PaymentsBLL : BaseBLL
    {
        public List<Payments> GetAllPayments()
        {
            return context.Payments.ToList();
        }
        //gaseste mesele
        public Payments GetPayment(int paymentID)
        {
            return context.Payments.FirstOrDefault(p => p.PaymentID == paymentID);
        }
        //adauga mesele
        public void AddPayment(Payments payment)
        {
            context.Payments.Add(payment);
            context.SaveChanges();
        }

        public void ModifyPayments()
        {
            context.SaveChanges();
        }

        /* //salveaza modificarile facute
         public void SaveChanges(DiningTable diningTableToSave)
         {
             context.DiningTable.AddOrUpdate(diningTableToSave);
         }*/

        //sterge o masa
        public void DeletePayments(int paymentId)
        {
            context.Payments.Remove(GetPayment(paymentId));
            context.SaveChanges();
        }

        /*  public Payments GetDiningTableNumber(int tableNumber)
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