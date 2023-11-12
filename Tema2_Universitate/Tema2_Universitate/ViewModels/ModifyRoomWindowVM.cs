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
    internal class ModifyRoomWindowVM : BaseVM
    {
        private string roomNumber;
        private string dormitoryNumber;
        private string cnp;
        public ModifyRoomWindowVM()
        {
            Messenger.Default.Register<RoomsVM>(this, (ReceivedRoom) =>
            {
                RoomNumber=ReceivedRoom.RoomNumber;
                DormitoryNumber = ReceivedRoom.DormitoryNumber;
                CNP=ReceivedRoom.CNP;
            });
            // Messenger.Default.Unregister<StudentVM>(this);

        }
        public ModifyRoomWindowVM(string roomNumber ,string dormitoryNumber, string CNP)
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

        private ICommand modifyRoomCommand;
        public ICommand ModifyRoomCommand
        {
            get
            {
                if (modifyRoomCommand == null)
                {
                    modifyRoomCommand = new RelayCommand(ModifyRoom);
                }
                return modifyRoomCommand;
            }
        }
        private void ModifyRoom(object param)
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
