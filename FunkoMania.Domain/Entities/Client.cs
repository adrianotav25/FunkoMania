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

        public string Name { get; set; }
        public string Email { get; set; }  
        public string Cpf { get; set; } 
        public bool Active { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

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
