using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2_Universitate.Model;

namespace Tema2_Universitate.ViewModels
{
    internal class PaymentsVM : BaseVM
    {
        private string paymentID;
        private string cnp;
        private DateTime paymentDate;
        private string amountPaid;
        private string penalities;

        public PaymentsVM(string paymentID, string cnp, DateTime paymentDate, string amountPaid, string penalities)
        {
            PaymentID = paymentID;
            CNP = cnp;
            PaymentDate = paymentDate;
            AmountPaid = amountPaid;
            Penalities = penalities;
        }

        public string PaymentID
        {
            get { return paymentID; }
            set
            {
                paymentID = value;
                NotifyPropertyChanged("PaymentID");
            }
        }

        public string CNP
        {
            get { return cnp; }
            set
            {
                cnp = value;
                NotifyPropertyChanged("CNP");
            }
        }
        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set
            {
                paymentDate = value;
                NotifyPropertyChanged("PaymentDate");
            }
        }
        public string AmountPaid
        {
            get { return amountPaid; }
            set
            {
                amountPaid = value;
                NotifyPropertyChanged("AmountPaid");
            }
        }
        public string Penalities
        {
            get { return penalities; }
            set
            {
                penalities = value;
                NotifyPropertyChanged("Penalities");
            }
        }
    }
}
