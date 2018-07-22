using System;
using LanguageExt;
using static LanguageExt.Prelude;
using Xunit;
using Xunit.Sdk;

namespace ExtUnit.Tests
{
    public class OptionTests
    {
        [Fact]
        public void IsNone_Pass() =>
            Assert.IsNone(Option<string>.None);

        [Fact]
        public void IsNone_Fail() =>
            Assert.Throws<AssertActualExpectedException>(
                () => Assert.IsNone(Optional("1234")));
        
    }
}
