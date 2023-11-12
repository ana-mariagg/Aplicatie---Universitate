using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2_Universitate.Model;


namespace Tema2_Universitate.ViewModels
{
    internal class StudentVM : BaseVM
    {

        private string cnp;
        private string firstName;
        private string lastName;
        private string faculty;
        private string studentStatus;
        private string fee;
        private string userID;


        public StudentVM(string cnp, string firstName, string lastName, string faculty,
            string studentStatus, string fee, string userID)
        {
            CNP = cnp;
            FirstName = firstName;
            LastName = lastName;
            Faculty = faculty;
            StudentStatus = studentStatus;
            Fee = fee;
            UserID = userID;
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

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyPropertyChanged("LastName");
            }
        }

        public string Faculty
        {
            get { return faculty; }
            set
            {
                faculty = value;
                NotifyPropertyChanged("Faculty");
            }
        }
        public string StudentStatus
        {
            get { return studentStatus; }
            set
            {
                studentStatus = value;
                NotifyPropertyChanged("StudentStatus");
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
        public string UserID
        {
            get { return userID; }
            set
            {
                userID = value;
                NotifyPropertyChanged("UserID");
            }
        }

    }
}


