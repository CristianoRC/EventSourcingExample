using System;
using System.Text.RegularExpressions;

namespace FakeBank.Domain.Account.ValueObjects
{
    public class Email
    {
        private string regexPattern =
            @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        
        public Email(string address)
        {
            if (!Regex.IsMatch(address, regexPattern))
            {
                throw new ArgumentException("Email inválido");
            }

            Address = address;
        }

        public string Address { get; }
    }
}