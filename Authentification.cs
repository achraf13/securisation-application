using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Inventway
{
    public partial class Authentification : Form
    {
        public Authentification()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MD5 md5Hash = MD5.Create();
            GetId clas = new GetId();
            string dd = clas.getcleId();
            // MessageBox.Show(dd);
            bool verifierCode = VerifyMd5Hash(md5Hash, dd.ToString(), tb_codeCry.Text.ToString());
            if (Equals(verifierCode, true))
            {
                MessageBox.Show("Authentification avec succes ");
                
                Menu menu =new Menu();
                menu.ShowDialog();
                
            }
            else
            {
                MessageBox.Show(" Code erroné");
            }
        }
        // Methode pour crypter l'identifiant du PDA 
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        // Methode pour verifier le code 
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Authentification_Load(object sender, EventArgs e)
        {

        }
    }
}