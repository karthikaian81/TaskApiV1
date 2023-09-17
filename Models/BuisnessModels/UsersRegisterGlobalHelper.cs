using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace TaskApiV1.Models.BuisnessModels
{
    public class UsersRegisterGlobalHelper
    {
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string VerificationToken { get; set; }

        public UsersRegisterGlobalHelper()
        {
            
        }

        public UsersRegisterGlobalHelper(byte[] salt,byte[] hash) {

            PasswordHash = hash;
            PasswordSalt = salt;

        }

        public void CreatePasswordHash(string password)
        {
          this.PasswordSalt = new byte[32];
          using(var hmac = new HMACSHA512())
          {
            this.PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
          }
            //PasswordSalt = new byte[this.PasswordSalt.Length];
            //PasswordHash = new byte[hash.Length];
            //Array.Copy(this.PasswordSalt, 0, PasswordSalt, 0, this.PasswordSalt.Length);
            //Array.Copy(hash, 0, PasswordHash, 0, hash.Length);
        }

        public bool VerifyPasswordHash(string Password)
        {
            if(string.IsNullOrEmpty(Password) || this.PasswordSalt is null) return false;
            using(var hmac = new HMACSHA512(this.PasswordSalt))
            {
              var verifyhash =  hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));
              return verifyhash.SequenceEqual(this.PasswordHash);
            }
        }

        public string CreateVerificationToken()
        {
          return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        }

        public bool VerifyToken(string tkn)
        {
            return VerificationToken == tkn;
        }
    }
}
