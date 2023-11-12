using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2_Universitate.Model;

namespace Tema2_Universitate.ViewModels
{
    internal class DormitoriesVM : BaseVM
    {

        private string dormitoryNumber;
        private string fee;

        public DormitoriesVM(string dormitoryNumber, string fee)
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

    }
}