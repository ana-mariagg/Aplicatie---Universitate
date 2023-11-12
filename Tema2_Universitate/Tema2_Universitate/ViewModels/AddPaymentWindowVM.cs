using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Documents;
using Tema2_Universitate.Model;
using Tema2_Universitate.Commands;
using GalaSoft;
using Tema2_Universitate.ViewModels;

namespace Tema2_Universitate.ViewModels
{
    internal class AddPaymentWindowVM : BaseVM
    {
        private string paymentID;
        private string cnp;
        private DateTime paymentDate;
        private string amountPaid;
        private string penalities;

        public AddPaymentWindowVM()
        {

        }
        public AddPaymentWindowVM(string paymentID, string cnp, DateTime paymentDate, string amountPaid, string penalities)
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

        private ICommand addPaymentCommand;
        public ICommand AddPaymentCommand
        {
            get
            {
                if (addPaymentCommand == null)
                {
                    addPaymentCommand = new RelayCommand(AddPayment);
                }
                return addPaymentCommand;
            }
        }
        private void AddPayment(object param)
        {
            PaymentsVM payment = new PaymentsVM(PaymentID, CNP,PaymentDate ,AmountPaid ,Penalities);
            Messenger.Default.Send(payment);
            if (param is Window window)
            {
                window.Close();
            }
        }
    }
}
