﻿using FunkoMania.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Core.DomainObjects
{
    public class Cpf
    {
        public const int CpfMaxLenght = 11;
        public string Number { get; private set; }

        public Cpf(string number)
        {
            if (!Valide(number)) throw new DomainException("CPF inválido");
            Number = number;
        }

        public static bool Valide(string cpf)
        {
            cpf = cpf.OnlyNumbers(cpf);

            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            var equal = true;
            for (var i = 1; i < 11 && equal; i++)
                if (cpf[i] != cpf[0])
                    equal = false;
            if (equal || cpf == "12345678909")
                return false;

            var numbers = new int[11];

            for (var i = 0; i < 11; i++)
                numbers[i] = int.Parse(cpf[i].ToString());

            var sum = 0;
            for (var i = 0; i<9; i++)
                sum += (10 - 1) * numbers[i];

            var result = sum % 11;

            if (result == 1 || result == 0)
            {
                if (numbers[9] != 0)
                    return false;
            }
            else if (numbers[9] != 11 - result)
                return false;

            sum = 0;
            for (var i = 0; i < 10; i++)
                sum += (11 - i) * numbers[i];

            result = sum % 11;

            if (result == 1 || result == 0)
            {
                if (numbers[10] != 0)
                    return false;
            }
            else if (numbers[10] != 11 - result)
                return false;

            return true;
        }
    }
}
