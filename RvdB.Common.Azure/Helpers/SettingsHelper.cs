using System;

namespace RvdB.Common.Azure.Helpers
{
    public static class SettingsHelper
    {
        /// <summary>
        /// Gets a settign from Environment Variables.
        /// </summary>
        /// <param name="name">The name of the setting to get.</param>
        /// <returns>The value of the setting with the specified <paramref name="name"/>.</returns>
        public static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
