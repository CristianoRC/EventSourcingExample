using System;
using System.Security.Cryptography;
using System.Text;

namespace FakeBank.Domain.Account.ValueObjects
{
    public class Password
    {
        public Password(string password)
        {
            if (password.Length < 6)
                throw new ArgumentException("Sua senha esta muito fraca!");

            HashedPassword = ComputeSha256Hash(password);
        }

        public string HashedPassword { get; }

        static string ComputeSha256Hash(string password)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}