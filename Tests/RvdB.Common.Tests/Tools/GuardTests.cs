﻿using System;

using Xunit;

namespace RvdB.Common.Tests.Tools
{
    public class GuardTests
    {
        #region Fields

        private static readonly object _nullValue = null;
        private static readonly object _nonNullValue = new();

        #endregion

        [Fact]
        public void IsNotNull_WithArgumentValueNull_ShouldThrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => Guard.IsNotNull(_nullValue, nameof(_nullValue)));

            Assert.Equal(nameof(_nullValue), exception.ParamName);
        }

        [Fact]
        public void IsNotNull_WithArgumentValueNotNull_ShouldNotThrowArgumentNullException()
        {
            Guard.IsNotNull(_nonNullValue, nameof(_nonNullValue));
        }
    }
}
