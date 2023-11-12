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
    internal class AddRoomWindowVM : BaseVM
    {
        private string roomNumber;
        private string dormitoryNumber;
        private string cnp;
        public AddRoomWindowVM()
        {

        }
        public AddRoomWindowVM(string dormitoryNumber, string fee)
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

        private ICommand addRoomCommand;
        public ICommand AddRoomCommand
        {
            get
            {
                if (addRoomCommand == null)
                {
                    addRoomCommand = new RelayCommand(AddRoom);
                }
                return addRoomCommand;
            }
        }
        private void AddRoom(object param)
        {
            RoomsVM room = new RoomsVM(RoomNumber, DormitoryNumber, CNP);
            Messenger.Default.Send(room);
            if (param is Window window)
            {
                window.Close();
            }
        }
    }
}
