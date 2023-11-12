using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2_Universitate.Model;

namespace Tema2_Universitate.ViewModels
{
    internal class RoomsVM : BaseVM
    {

        private string roomNumber;
        private string dormitoryNumber;
        private string cnp;

        public RoomsVM(string roomNumber, string dormitoryNumber, string cnp)
        {
            RoomNumber = roomNumber;
            DormitoryNumber = dormitoryNumber;
            CNP = cnp;
        }

        public string RoomNumber
        {
            get { return roomNumber; }
            set
            {
                roomNumber = value;
                NotifyPropertyChanged("RoomNumber");
            }
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

        public string CNP
        {
            get { return cnp; }
            set
            {
                cnp = value;
                NotifyPropertyChanged("CNP");
            }
        }

    }
}