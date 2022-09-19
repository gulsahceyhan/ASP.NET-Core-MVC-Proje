using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserCredential: IUserCredential
    {
        public string UserName { get; set; }
        public int Password { get; set; }
        public int ServerUri{ get; set; }
        

    }
     public interface IUserCredential
    {
        public string UserName { get; set; }
        public int Password { get; set; }
        public int ServerUri { get; set; }
    }
}
