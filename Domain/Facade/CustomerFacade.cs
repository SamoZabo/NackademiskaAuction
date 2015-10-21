using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Domain.DomainClasses;
using NA.Domain.Exception;
using NA.Domain.Identity;
using NA.Domain.Repository;

namespace NA.Domain.Facade
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IAuth _auth;
        private readonly IPasswordHandler _passwordHandler;

        public CustomerFacade(ICustomerRepository customerRepository, IAddressRepository addressRepository, IAuth auth, IPasswordHandler passwordHandler)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _auth = auth;
            _passwordHandler = passwordHandler;
        }


        public Customer Get(Guid id)
        {
            return _customerRepository.Get(id);
        }

        public IList<DomainClasses.Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public void Update(Customer customer)
        {
            var oldAddresses = _addressRepository.GetAll(customer.Id);

            foreach (var address in oldAddresses)
                _addressRepository.Remove(address.Id);

            _customerRepository.Update();
        }


        public Customer GetByEmail(string email)
        {
            return _customerRepository.GetByEmail(email);
        }

        public void AuthenticateRequest(System.Web.HttpContextBase httpContextBase)
        {
            if (httpContextBase.Request.IsAuthenticated)
            {
                var customer = GetByEmail(httpContextBase.User.Identity.Name);
                if (customer != null)
                {
                    httpContextBase.User = customer;
                }
            }
        }

        public Customer LogIn(string email, string password)
        {
            var customer = GetByEmail(email);
            if (customer == null)
            {
                throw new CustomerNotFoundException("User Not Found");
            }

            if (!_passwordHandler.Validate(password, customer.PasswordSalt, customer.PasswordHash))
            {
                throw new InvalidPasswordException("Invalid Password");
            }

            _auth.DoAuth(email);
            return customer;
        }

        public void Logout()
        {
            _auth.SignOut();
        }

        public void ChangePassword(string email, string currentPassword, string newPassword, string confirmNewPassword)
        {
            var customer = _customerRepository.GetByEmail(email);
            if (customer == null)
            {
                throw new CustomerNotFoundException("Invalid email");
            }

            if (!_passwordHandler.Validate(currentPassword, customer.PasswordSalt, customer.PasswordHash))
            {
                throw new InvalidPasswordException("Invalid Password");
            }

            if (newPassword != confirmNewPassword || newPassword.Length < 1)
            {
                throw new InvalidPasswordException("Invalid Password");
            }

            byte[] newSalt, newHash;

            _passwordHandler.SaltAndHash(newPassword, out newSalt, out newHash);

            customer.PasswordHash = newHash;
            customer.PasswordSalt = newSalt;
            _customerRepository.Update();
        }

        public void Add(Guid id, string firstName, string lastName, IList<Address> addresses,
            string password, string confirmPassword, string email)
        {
            var customer = _customerRepository.GetByEmail(email);
            if (customer != null)
            {
                throw new EmailExistsException(String.Format("{0} is already existing", email));
            }

            if (password != confirmPassword || password.Length < 1)
            {
                throw new InvalidPasswordException("Invalid Password");
            }

            byte[] salt, hash;
            _passwordHandler.SaltAndHash(password, out salt, out hash);

            customer = new Customer
            {
                Id = id, 
                FirstName = firstName, 
                LastName = lastName, 
                Addresses = addresses,
                Email = email,
                PasswordSalt=salt,
                PasswordHash = hash,
                Role = Role.Customer
            };
            _customerRepository.Add(customer);
        }
    }
}
