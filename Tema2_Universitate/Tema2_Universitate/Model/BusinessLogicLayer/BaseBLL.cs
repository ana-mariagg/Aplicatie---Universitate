using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2_Universitate.Model.BusinessLogicLayer
{
    internal class BaseBLL
    {
        //baza de date
        protected universitateEntities1 context;
        public BaseBLL()
        {
            context = new universitateEntities1();
        }
    }
}
