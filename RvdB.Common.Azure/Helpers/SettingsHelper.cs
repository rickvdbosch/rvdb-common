using System;

namespace RvdB.Common.Azure.Helpers
{
    public static class SettingsHelper
    {
        /// <summary>
        /// Gets a variable from Environment Variables.
        /// </summary>
        /// <param name="variable">The name of the variable to get.</param>
        /// <returns>The value of the specified <paramref name="variable"/>.</returns>
        public static string GetEnvironmentVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
        }
    }
}
