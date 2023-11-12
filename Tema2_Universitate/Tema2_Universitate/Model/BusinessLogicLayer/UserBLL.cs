using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tema2_Universitate.Model.BusinessLogicLayer
{
    internal class UserBLL : BaseBLL
    {
        //autentificare
        public Users Login(string username, string password)
        {
            Users user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user;
        }
    }
}