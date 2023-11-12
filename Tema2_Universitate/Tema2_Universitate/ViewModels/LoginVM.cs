using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Tema2_Universitate.Model.BusinessLogicLayer;
using Tema2_Universitate.Commands;
using Tema2_Universitate.Model;
using Tema2_Universitate.Views;
using GalaSoft.MvvmLight.Messaging;

namespace Tema2_Universitate.ViewModels
{
    internal class LoginVM : BaseVM
    {
        //nu se pot modifica pentru ca nu trebuie
        private readonly UserBLL userBLL = new UserBLL();
        private readonly StudentBLL studentBLL = new StudentBLL();

        private string username;
        private string password;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand(Login);
                }
                return loginCommand;
            }

        }

        //trimite fereastra curenta ca parametru ca sa o putem inchide
        public void Login(object param)
        {
            Users User = userBLL.Login(Username, Password);
            if (User != null)
            {
                if (User.Role == "Administrator")
                {
                    //creaza o fereastra noua
                    AdminWindow adminWindow = new AdminWindow();
                    //inchide pe cea veche
                    (param as Window).Close();
                    //deschide si afiseaza fereastra noua
                    adminWindow.ShowDialog();
                }
                else if (User.Role == "Student")
                {
                    StudentWindow studentWindow = new StudentWindow();
                    int studentId = studentBLL.GetStudentID(Username, Password);
                    //trimitem datele despre un student intre ViewModels
                    Messenger.Default.Send(studentId);
                    (param as Window).Close();
                    studentWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
            }
        }
    }
}

