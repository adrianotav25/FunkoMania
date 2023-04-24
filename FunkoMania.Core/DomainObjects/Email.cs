﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FunkoMania.Core.DomainObjects
{
    public class Email
    {
        public const int AddressMaxLenght = 254;
        public const int AddressMinLength = 5;
        public string Address { get; private set; }

        protected Email()
        {

        }
        public Email(String address)
        {
            if (!Valide(address)) throw new DomainException("E-mail inválido");
            Address = address;
        }

        public static bool Valide(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
