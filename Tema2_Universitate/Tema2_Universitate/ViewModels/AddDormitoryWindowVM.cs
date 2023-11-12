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
    internal class AddDormitoryWindowVM : BaseVM
    {
        private string dormitoryNumber;
        private string fee;
        public AddDormitoryWindowVM()
        {

        }
        public AddDormitoryWindowVM(string dormitoryNumber, string fee)
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

        private ICommand addDormitoryCommand;
        public ICommand AddDormitoryCommand
        {
            get
            {
                if (addDormitoryCommand == null)
                {
                    addDormitoryCommand = new RelayCommand(AddDormitory);
                }
                return addDormitoryCommand;
            }
        }
        private void AddDormitory(object param)
        {
            DormitoriesVM camin = new DormitoriesVM(DormitoryNumber,Fee);
            Messenger.Default.Send(camin);
            if (param is Window window)
            {
                window.Close();
            }
        }
    }
}
