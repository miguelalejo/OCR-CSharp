   using System;
using System.Text;
using System.Security.Cryptography;


namespace OCR.Facultad.Ingenieria.Util
{
    /// <summary>
    /// Clase con metodos utilzados para encriptar y des-encriptar cadenas de carcteres.
    /// </summary>
    public class Encriptar
    {
        /// <summary>
        /// Contraseña privada cosntante para la encriptación de documentos
        /// </summary>
        public const int keyprivada = 635271;
        /// <summary>
        /// Método utilizado para encriptar un mensaje.
        /// </summary>
        /// <param name="Message">Mensaje a encriptar.</param>
        /// <param name="Passphrase">Codigo de encriptación.</param>
        /// <returns>Devuelve una cadena de carcteres con el mensaje Encriptado.</returns>
        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }
        /// <summary>
        /// Método utilizado para des-encriptar un mensaje.
        /// </summary>
        /// <param name="Message">Cadena de carcateres que contine un mensaje encriptado.</param>
        /// <param name="Passphrase">Contraseña para des-encriptar.</param>
        /// <returns>Cadena de caracteres original, no encriptada.</returns>
        public static string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }
        /// <summary>
        /// Genera llave a partir de la combinación de la clave pública y privada.
        /// </summary>
        /// <param name="una_keypublica">Valor entero utilizado genralmente como llave pública.</param>
        /// <returns>Llave resultado de la combinación de llaves pública y privada.</returns>
        public static int GeneraKeyfinal(int una_keypublica)
        {
            return keyprivada * una_keypublica;
        }
        /// <summary>
        /// Método estático, utilizado para encriptar un mensaje en base a una llave pública.
        /// </summary>
        /// <param name="unval">Mesnaje a encriptar.</param>
        /// <param name="unakeypublica">Valor entero de la llave pública.</param>
        /// <returns>Retorna una cadena de caracteres encriptada.</returns>
        public static string EncriptarMD5(string unval, int unakeypublica)
        {
            return Encriptar.EncryptString(unval, GeneraKeyfinal(unakeypublica).ToString());
        }
        /// <summary>
        /// Método estático, utilizado para des-encriptar un mensaje en base a una llave pública.
        /// </summary>
        /// <param name="unval">Mesnaje a des-encriptar.</param>
        /// <param name="unakeypublica">Valor entero de la llave pública.</param>
        /// <returns>Retorna una cadena de caracteres no-encriptada.</returns>
        public static string DesEncriptarMD5(string unval, int unakeypublica)
        {
            return Encriptar.DecryptString(unval, GeneraKeyfinal(unakeypublica).ToString());
        }


    }
}
   