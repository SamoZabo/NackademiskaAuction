using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NA.Domain.Identity
{
    public class PasswordHandler : IPasswordHandler
    {
        #region Constants and Fields

        /// <summary>
        /// Hash size value
        /// </summary>
        private const int HashSize = 32;

        /// <summary>
        /// The number of iterations used when salting and hashing
        /// </summary>
        private const int Iterations = 1000;

        /// <summary>
        /// Salt size value
        /// </summary>
        private const int SaltSize = 32;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Validates the specified password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="storedSalt">The stored salt.</param>
        /// <param name="storedHash">The stored hash.</param>
        /// <param name="butWhy">if set to <c>true</c> [but why].</param>
        /// <returns></returns>
        public bool Validate(string password, byte[] storedSalt, byte[] storedHash)
        {
            var rdb = new Rfc2898DeriveBytes(password, storedSalt, Iterations);

            byte[] hash = rdb.GetBytes(HashSize);
            return IsSameByteArray(storedHash, hash);
        }

        /// <summary>
        /// Creates the salt and hashvalue to store instead of the password
        /// </summary>
        /// <param name="password">
        /// The password
        /// </param>
        /// <param name="salt">
        /// The salt value
        /// </param>
        /// <param name="hash">
        /// The hash value
        /// </param>
        public void SaltAndHash(string password, out byte[] salt, out byte[] hash)
        {
            var rdb = new Rfc2898DeriveBytes(password, SaltSize, Iterations);

            salt = rdb.Salt;
            hash = rdb.GetBytes(HashSize);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Verifies that two byte arrays are the same
        /// </summary>
        /// <param name="a">
        /// The first byte array
        /// </param>
        /// <param name="b">
        /// The second byte array
        /// </param>
        /// <returns>
        /// The is same byte array.
        /// </returns>
        private static bool IsSameByteArray(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}
