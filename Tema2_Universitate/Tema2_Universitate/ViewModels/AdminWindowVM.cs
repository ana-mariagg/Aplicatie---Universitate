using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2_Universitate.Commands;
using Tema2_Universitate.Model;
using Tema2_Universitate.Model.BusinessLogicLayer;
using Tema2_Universitate.Views;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Tema2_Universitate.ViewModels
{
    internal class AdminWindowVM : BaseVM
    {
        private DormitoriesBLL dormitoriesBLL = new DormitoriesBLL();
        private PaymentsBLL paymentsBLL = new PaymentsBLL();
        private RoomsBLL roomsBLL = new RoomsBLL();
        private StudentBLL studentBLL = new StudentBLL();
        private UserBLL userBLL = new UserBLL();
        private object currentItem;

        public object CurrentItem
        {
            get { return currentItem; }
            set
            {
                currentItem = value;
                NotifyPropertyChanged("CurrentItem");
            }
        }

        //e o colectie de obiecte (fie angajati, fie mese, orice) care poate sa fie observata; cand se modifica cv se notifica automat in view
        public ObservableCollection<object> CurrentList { get; set; }
        public AdminWindowVM() { CurrentList = new ObservableCollection<object>(); }



        //-------------------------------------------------------------------------------------------------------
        //CAMINE

        //ca sa putem viziona caminele

        //VIEW ----------------------------------------------------

        private ICommand viewDormitoryCommand;
        public ICommand ViewDormitoryCommand
        {
            get
            {
                if (viewDormitoryCommand == null)
                {
                    viewDormitoryCommand = new RelayCommand(ViewDormitory);
                }
                return viewDormitoryCommand;
            }
        }

        private void ViewDormitory(object param)
        {
            List<Dormitories> dormitories = dormitoriesBLL.GetAllDormitories();
            List<DormitoriesVM> dormitoriesVM = new List<DormitoriesVM>();
            foreach (Dormitories dormitory in dormitories)
            {
                dormitoriesVM.Add(new DormitoriesVM(dormitory.DormitoryNumber.ToString(), dormitory.Fee.ToString()));
            }
            CurrentList = new ObservableCollection<object>(dormitoriesVM);
            NotifyPropertyChanged(nameof(CurrentList));
        }

        //ADD ----------------------------------------------------


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
            AddDormitoryWindow addDormitoryWindow = new AddDormitoryWindow();
            Messenger.Default.Register<DormitoriesVM>(this, (dormitoriesVM) =>
            {
                Dormitories dorm = new Dormitories();
                dorm.DormitoryNumber = int.Parse(dormitoriesVM.DormitoryNumber);
                dorm.Fee=decimal.Parse(dormitoriesVM.Fee.ToString());
                CurrentList.Add(dormitoriesVM);
                dormitoriesBLL.AddDormitories(dorm);
            });
            addDormitoryWindow.ShowDialog();
            //inchide "cutiuta postala"
            Messenger.Default.Unregister<DormitoriesVM>(this);
        }


        //MODIFY ----------------------------------------------------

        private void ModifyDormitory(object param)
        {
            ModifyDormitoryWindow modifyDormitoryWindow = new ModifyDormitoryWindow();
            Messenger.Default.Send<DormitoriesVM>(CurrentItem as DormitoriesVM);
            Messenger.Default.Register<DormitoriesVM>(this, (dormitoriesVM) =>
            {
                CurrentItem = dormitoriesVM;
                Dormitories oldDorm = dormitoriesBLL.GetDormitories(int.Parse(dormitoriesVM.DormitoryNumber));
                oldDorm.DormitoryNumber = int.Parse(dormitoriesVM.DormitoryNumber);
                oldDorm.Fee = decimal.Parse(dormitoriesVM.Fee);
                dormitoriesBLL.ModifyDormitories();
            });
            modifyDormitoryWindow.ShowDialog();
            //inchide "cutiuta postala"
            Messenger.Default.Unregister<DormitoriesVM>(this);

            //NotifyPropertyChanged("CurrentItem");
            ViewDormitory(null);
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



        //DELETE ----------------------------------------------------

        private void DeleteDormitory(object param)
        {
            Dormitories oldDormitory = dormitoriesBLL.GetDormitories(int.Parse((CurrentItem as DormitoriesVM).DormitoryNumber));
            dormitoriesBLL.DeleteDormitories(oldDormitory.DormitoryNumber);

            //NotifyPropertyChanged("CurrentItem");
            ViewDormitory(null);
        }


        private ICommand deleteDormitoryCommand;
        public ICommand DeleteDormitoryCommand
        {
            get
            {
                if (deleteDormitoryCommand == null)
                {
                    deleteDormitoryCommand = new RelayCommand(DeleteDormitory);
                }
                return deleteDormitoryCommand;
            }
        }


        //-------------------------------------------------------------------------------------------------------
        //PLATI

        //ca sa putem viziona platile

        //VIEW ----------------------------------------------------

        private ICommand viewPaymentCommand;
        public ICommand ViewPaymentCommand
        {
            get
            {
                if (viewPaymentCommand == null)
                {
                    viewPaymentCommand = new RelayCommand(ViewPayment);
                }
                return viewPaymentCommand;
            }
        }

        private void ViewPayment(object param)
        {
            List<Payments> payments = paymentsBLL.GetAllPayments();
            List<PaymentsVM> paymentsVM = new List<PaymentsVM>();
            foreach (Payments payment in payments)
            {
                paymentsVM.Add(new PaymentsVM(payment.PaymentID.ToString(), payment.CNP, payment.PaymentDate.Value,
                    payment.AmountPaid.ToString(), payment.Penalties.ToString()));
            }
            CurrentList = new ObservableCollection<object>(paymentsVM);
            NotifyPropertyChanged(nameof(CurrentList));
        }

        //ADD ----------------------------------------------------


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
            AddPaymentWindow addPaymentWindow = new AddPaymentWindow();
            Messenger.Default.Register<PaymentsVM>(this, (paymentsVM) =>
            {
                Payments payment = new Payments();
                payment.PaymentID=int.Parse(paymentsVM.PaymentID);
                payment.CNP=paymentsVM.CNP;
                payment.PaymentDate=paymentsVM.PaymentDate;
                payment.AmountPaid=int.Parse(paymentsVM.AmountPaid);
                payment.Penalties = decimal.Parse(paymentsVM.Penalities);
                CurrentList.Add(paymentsVM);
                paymentsBLL.AddPayment(payment);
            });
            addPaymentWindow.ShowDialog();
            //inchide "cutiuta postala"
            Messenger.Default.Unregister<PaymentsVM>(this);
        }


        //MODIFY ----------------------------------------------------

        private void ModifyPayment(object param)
        {
            ModifyPaymentWindow modifyPaymentWindow = new ModifyPaymentWindow();
            Messenger.Default.Send<PaymentsVM>(CurrentItem as PaymentsVM);
            Messenger.Default.Register<PaymentsVM>(this, (paymentsVM) =>
            {
                CurrentItem = paymentsVM;
                Payments oldPayment = paymentsBLL.GetPayment(int.Parse(paymentsVM.PaymentID));
                oldPayment.PaymentID = int.Parse(paymentsVM.PaymentID);
                oldPayment.CNP = paymentsVM.CNP;
                oldPayment.PaymentDate = paymentsVM.PaymentDate;
                oldPayment.AmountPaid = decimal.Parse(paymentsVM.AmountPaid);
                oldPayment.Penalties= decimal.Parse(paymentsVM.Penalities) ;
                paymentsBLL.ModifyPayments();
            });
            modifyPaymentWindow.ShowDialog();
            //inchide "cutiuta postala"
            Messenger.Default.Unregister<PaymentsVM>(this);

            //NotifyPropertyChanged("CurrentItem");
            ViewPayment(null);
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



        //DELETE ----------------------------------------------------

        private void DeletePayment(object param)
        {
            Payments oldPayment = paymentsBLL.GetPayment(int.Parse((CurrentItem as PaymentsVM).PaymentID));
            paymentsBLL.DeletePayments(oldPayment.PaymentID);

            //NotifyPropertyChanged("CurrentItem");
            ViewPayment(null);
        }


        private ICommand deletePaymentCommand;
        public ICommand DeletePaymentCommand
        {
            get
            {
                if (deletePaymentCommand == null)
                {
                    deletePaymentCommand = new RelayCommand(DeletePayment);
                }
                return deletePaymentCommand;
            }
        }


        //-------------------------------------------------------------------------------------------------------
        //CAMERE

        //ca sa putem viziona camerele

        //VIEW ----------------------------------------------------

        private ICommand viewRoomCommand;
        public ICommand ViewRoomCommand
        {
            get
            {
                if (viewRoomCommand == null)
                {
                    viewRoomCommand = new RelayCommand(ViewRoom);
                }
                return viewRoomCommand;
            }
        }

        private void ViewRoom(object param)
        {
            List<Rooms> rooms = roomsBLL.GetAllRooms();
            List<RoomsVM> roomsVM = new List<RoomsVM>();
            foreach (Rooms room in rooms)
            {
                roomsVM.Add(new RoomsVM(room.RoomNumber.ToString(), room.DormitoryNumber.ToString(), room.CNP));
            }
            CurrentList = new ObservableCollection<object>(roomsVM);
            NotifyPropertyChanged(nameof(CurrentList));
        }



        //ADD ----------------------------------------------------

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
            AddRoomWindow addRoomWindow = new AddRoomWindow();
            Messenger.Default.Register<RoomsVM>(this, (roomsVM) =>
            {
                Rooms room = new Rooms();
                room.RoomNumber=int.Parse(roomsVM.RoomNumber);
                room.DormitoryNumber= int.Parse(roomsVM.DormitoryNumber);
                room.CNP = roomsVM.CNP;
                CurrentList.Add(roomsVM);
                roomsBLL.AddRoom(room);
            });
            addRoomWindow.ShowDialog();
            //inchide "cutiuta postala"
            Messenger.Default.Unregister<RoomsVM>(this);
        }

        //MODIFY ----------------------------------------------------

        private void ModifyRoom(object param)
        {
            ModifyRoomWindow modifyRoomWindow = new ModifyRoomWindow();
            Messenger.Default.Send<RoomsVM>(CurrentItem as RoomsVM);
            Messenger.Default.Register<RoomsVM>(this, (roomsVM) =>
            {
                CurrentItem = roomsVM;
                Rooms oldRoom = roomsBLL.GetRoom(int.Parse(roomsVM.RoomNumber));
                oldRoom.RoomNumber = int.Parse(roomsVM.RoomNumber);
                oldRoom.DormitoryNumber = int.Parse(roomsVM.DormitoryNumber);
                oldRoom.CNP = roomsVM.CNP;
                roomsBLL.ModifyRoom();
            });
            modifyRoomWindow.ShowDialog();
            //inchide "cutiuta postala"
            Messenger.Default.Unregister<RoomsVM>(this);

            //NotifyPropertyChanged("CurrentItem");
            ViewRoom(null);
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


        //DELETE ----------------------------------------------------

        private void DeleteRoom(object param)
        {
            Rooms oldRoom = roomsBLL.GetRoom(int.Parse((CurrentItem as RoomsVM).RoomNumber));
            roomsBLL.DeleteRoom(oldRoom.RoomNumber);

            //NotifyPropertyChanged("CurrentItem");
            ViewRoom(null);
        }


        private ICommand deleteRoomCommand;
        public ICommand DeleteRoomCommand
        {
            get
            {
                if (deleteRoomCommand == null)
                {
                    deleteRoomCommand = new RelayCommand(DeleteRoom);
                }
                return deleteRoomCommand;
            }
        }


        //-------------------------------------------------------------------------------------------------------
        //STUDENTI

        //ca sa putem viziona studentii

        //VIEW ----------------------------------------------------

        private ICommand viewStudentCommand;
        public ICommand ViewStudentCommand
        {
            get
            {
                if (viewStudentCommand == null)
                {
                    viewStudentCommand = new RelayCommand(ViewStudent);
                }
                return viewStudentCommand;
            }
        }

        private void ViewStudent(object param)
        {
            List<Students> students = studentBLL.GetAllStudents();
            List<StudentVM> studentVM = new List<StudentVM>();
            foreach (Students student in students)
            {
                studentVM.Add(new StudentVM(student.CNP, student.FirstName, student.LastName, student.Faculty, student.StudentStatus,
                    student.Fee.ToString(), student.UserID.ToString()));
            }
            CurrentList = new ObservableCollection<object>(studentVM);
            NotifyPropertyChanged(nameof(CurrentList));
        }


        //ADD ----------------------------------------------------


        private ICommand addStudentCommand;
        public ICommand AddStudentCommand
        {
            get
            {
                if (addStudentCommand == null)
                {
                    addStudentCommand = new RelayCommand(AddStudent);
                }
                return addStudentCommand;
            }
        }

        private void AddStudent(object param)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            Messenger.Default.Register<StudentVM>(this, (studentVM) =>
            {
                Students student = new Students();
                student.CNP = studentVM.CNP;
                student.FirstName = studentVM.FirstName;
                student.LastName = studentVM.LastName;
                student.Faculty = studentVM.Faculty;
                student.StudentStatus = studentVM.StudentStatus;
                student.Fee = decimal.Parse(studentVM.Fee);
                student.UserID = int.Parse(studentVM.UserID);
                CurrentList.Add(studentVM);
                studentBLL.AddStudent(student);
            });
            addStudentWindow.ShowDialog();
            //inchide "cutiuta postala"
            Messenger.Default.Unregister<StudentVM>(this);
        }

        //MODIFY ----------------------------------------------------

        private void ModifyStudent(object param)
        {
            ModifyStudentWindow modifyStudentWindow = new ModifyStudentWindow();
            Messenger.Default.Send<StudentVM>(CurrentItem as StudentVM);
            Messenger.Default.Register<StudentVM>(this, (studentVM) =>
            {
                CurrentItem = studentVM;
                Students oldStudent = studentBLL.GetStudentFromUserID(int.Parse(studentVM.UserID));
                oldStudent.UserID = int.Parse(studentVM.UserID);
                oldStudent.FirstName = studentVM.FirstName;
                oldStudent.LastName = studentVM.LastName;
                oldStudent.Faculty= studentVM.Faculty;
                oldStudent.StudentStatus = studentVM.StudentStatus;
                oldStudent.Fee = decimal.Parse(studentVM.Fee);
                studentBLL.ModifyStudent();
            });
            modifyStudentWindow.ShowDialog();
            //inchide "cutiuta postala"
            Messenger.Default.Unregister<StudentVM>(this);

            //NotifyPropertyChanged("CurrentItem");
            ViewStudent(null);
        }

        private ICommand modifyStudentCommand;
        public ICommand ModifyStudentCommand
        {
            get
            {
                if (modifyStudentCommand == null)
                {
                    modifyStudentCommand = new RelayCommand(ModifyStudent);
                }
                return modifyStudentCommand;
            }
        }


        //DELETE ----------------------------------------------------

        private void DeleteStudent(object param)
        {
            Students oldStudent = studentBLL.GetStudentFromUserID(int.Parse((CurrentItem as StudentVM).UserID));
            studentBLL.DeleteStudents(oldStudent.CNP);

            //NotifyPropertyChanged("CurrentItem");
            ViewStudent(null);
        }


        private ICommand deleteStudentsCommand;
        public ICommand DeleteStudentsCommand
        {
            get
            {
                if (deleteStudentsCommand == null)
                {
                    deleteStudentsCommand = new RelayCommand(DeleteStudent);
                }
                return deleteStudentsCommand;
            }
        }


    }
}

