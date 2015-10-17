using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Domain.DomainClasses;

namespace NA.Domain.Facade
{
    public interface ICustomerFacade
    {
        Customer Get(Guid id);
        IList<Customer> GetAll();
        Customer GetByEmail(string email);
        void AuthenticateRequest(HttpContextBase httpContextBase);
        Customer LogIn(string email, string password);
        void Logout();
        void ChangePassword(string email, string currentPassword, string newPassword, string confirmNewPassword);
        void Add(Guid id, string firstName, string lastName, IList<Address> addresses, string password, string confirmPassword, string email);
        void Update(Customer customer);
    }
}
