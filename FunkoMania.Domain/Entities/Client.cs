using FunkoMania.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Domain.Entities
{
    public class Client : Entity
    {
        public Client(string name, string email, string cpf, bool active, Guid addressId, Address address)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
            Active = active;
            AddressId = addressId;
            Address = address;
        }

        protected Client()
        {

        }

        public string Name { get; private set; }
        public string Email { get; private set; }  
        public string Cpf { get; private set; } 
        public bool Active { get; private set; }
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }

        public void SetAddress(Address address)
        {
            Address = address;
            AddressId = address.Id;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }
    }
}
