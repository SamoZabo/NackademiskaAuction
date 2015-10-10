using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Domain.DomainClasses;

namespace NA.Domain.Repository
{
    public interface IAddressRepository
    {
        Address Get(Guid addressId);
        IList<Address> GetAll(Guid? customerId);
        void Remove(Guid id);
        void Update();
    }
}
