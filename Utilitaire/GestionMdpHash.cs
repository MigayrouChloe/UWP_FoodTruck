using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Utilitaire
{
    public class GestionMdpHash
    {
        private string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public string UseHash(string motDePasse)
        {
            using (SHA256 Hash = SHA256.Create())
            {
                GestionMdpHash gestionHash = new GestionMdpHash();
                string Mdp_Hash = gestionHash.GetHash(Hash, motDePasse);
                return Mdp_Hash;
            }
        }


    }
}
