using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Domain.Identity
{
    public interface IAuth
    {
        void DoAuth(string email);
        void SignOut();
    }
}
