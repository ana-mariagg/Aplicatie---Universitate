﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2_Universitate.Commands;
using GalaSoft;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace Tema2_Universitate.ViewModels
{
    internal class ModifyPaymentWindowVM : BaseVM
    {
        private string paymentID;
        private string cnp;
        private DateTime paymentDate;
        private string amountPaid;
        private string penalities;

        public ModifyPaymentWindowVM()
        {
            Messenger.Default.Register<PaymentsVM>(this, (ReceivedPayment) =>
            {
                PaymentID = ReceivedPayment.PaymentID;
                CNP = ReceivedPayment.CNP;
                PaymentDate = ReceivedPayment.PaymentDate;
                AmountPaid = ReceivedPayment.AmountPaid;
                Penalities = ReceivedPayment.Penalities;
            });
            // Messenger.Default.Unregister<StudentVM>(this);

        }
        public ModifyPaymentWindowVM(string paymentID, string cnp, DateTime paymentDate, string amountPaid, string penalities)
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



        private ICommand modifyPaymentCommand;
        public ICommand ModifyPaymentCommand
        {
            get
            {
                if (modifyPaymentCommand == null)
                {
                    modifyPaymentCommand = new RelayCommand(ModifyPayment);
                }
                return modifyPaymentCommand;
            }
        }
        private void ModifyPayment(object param)
        {
            PaymentsVM payment = new PaymentsVM(PaymentID ,CNP,PaymentDate ,AmountPaid ,Penalities);
            Messenger.Default.Send(payment);
            if (param is Window window)
            {
                window.Close();
            }
        }
    }
}
