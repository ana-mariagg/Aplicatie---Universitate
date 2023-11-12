using System;
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
    internal class ModifyDormitoryWindowVM:BaseVM
    {
        private string dormitoryNumber;
        private string fee;
        public ModifyDormitoryWindowVM()
        {
            Messenger.Default.Register<DormitoriesVM>(this, (ReceivedDorm) =>
            {
                DormitoryNumber = ReceivedDorm.DormitoryNumber;
                Fee = ReceivedDorm.Fee;
            });
            // Messenger.Default.Unregister<StudentVM>(this);

        }
        public ModifyDormitoryWindowVM(string dormitoryNumber, string fee)
        {
            DormitoryNumber = dormitoryNumber;
            Fee = fee;
        }

        public string DormitoryNumber
        {
            get { return dormitoryNumber; }
            set
            {
                dormitoryNumber = value;
                NotifyPropertyChanged("DormitoryNumber");
            }
        }

        public string Fee
        {
            get { return fee; }
            set
            {
                fee = value;
                NotifyPropertyChanged("Fee");
            }
        }
        private ICommand modifyDormitoriesCommand;
        public ICommand ModifyDormitoriesCommand
        {
            get
            {
                if (modifyDormitoriesCommand == null)
                {
                    modifyDormitoriesCommand = new RelayCommand(ModifyDormitory);
                }
                return modifyDormitoriesCommand;
            }
        }
        private void ModifyDormitory(object param)
        {
            DormitoriesVM dorm = new DormitoriesVM(DormitoryNumber,Fee);
            Messenger.Default.Send(dorm);
            if (param is Window window)
            {
                window.Close();
            }
        }
    }
}
