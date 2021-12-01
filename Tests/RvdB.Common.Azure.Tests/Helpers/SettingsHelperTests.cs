using System;

using RvdB.Common.Azure.Helpers;

using Xunit;

namespace RvdB.Common.Azure.Tests.Helpers
{
    public class SettingsHelperTests
    {
        #region Constants

        private const string VALID_NAME = "validName";
        private const string INVALID_NAME = "invalidName";
        private const string EXPECTED_VALUE = "testValue";

        #endregion

        [Fact]
        public void GettingEnvVariable_WithNameIsNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => SettingsHelper.GetEnvironmentVariable(null));
            Assert.Equal("variable", ex.ParamName);
        }

        [Fact]
        public void GettingEnvVariable_WithValidName_ReturnsValue()
        {
            Environment.SetEnvironmentVariable(VALID_NAME, EXPECTED_VALUE);
            var variable = SettingsHelper.GetEnvironmentVariable(VALID_NAME);
            Assert.Equal(EXPECTED_VALUE, variable);
            Environment.SetEnvironmentVariable(VALID_NAME, null);
        }

        [Fact]
        public void GettingEnvVariable_WithInvalidName_ReturnsNull()
        {
            var variable = SettingsHelper.GetEnvironmentVariable(INVALID_NAME);
            Assert.Null(variable);
        }
    }
}