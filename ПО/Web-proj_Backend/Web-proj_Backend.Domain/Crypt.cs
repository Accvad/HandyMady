using System;
using System.Security.Cryptography;
using System.Text;

namespace Web_proj_Backend.Domain
{
    public class Crypt
    {
        /// <summary>
        /// Получить ХЭШ пароля для идентификации пользователя
        /// </summary>
        public static string GenerateHashPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] byteMas = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            string pass = BitConverter.ToString(byteMas).Replace("-", String.Empty);
            return pass.ToLower();
        }
        
        /// <summary>
        /// Генерирует токен авторизованного пользователя
        /// </summary>
        public static string GenerateToken(string login)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            string data = Convert.ToString(DateTime.Now);
            byte[] byteMas = md5.ComputeHash(Encoding.UTF8.GetBytes(login + data));
            string apiKey = BitConverter.ToString(byteMas).Replace("-", String.Empty);
            return apiKey;
        }
    }
}