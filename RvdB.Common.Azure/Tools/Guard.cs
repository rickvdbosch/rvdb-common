using System;

namespace RvdB.Common
{
    /// <summary>
    /// Static helper class with helper for Guard Clause constructs.
    /// </summary>
    public static class Guard
    {
        #region Methods (Public)

        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> when the given <paramref name="argumentValue" /> is null.
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws an <see cref="ArgumentNullException" /> when the specified <paramref name="argumentValue" /> is null.
        /// </exception>
        public static void IsNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        #endregion
    }
}
