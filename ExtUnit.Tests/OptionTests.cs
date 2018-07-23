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
        public void None_Pass() =>
            Assert.None(Option<string>.None);

        [Fact]
        public void None_Fail() =>
            Assert.Throws<NoneException>(
                () => Assert.None(Optional("1234")));

        [Fact]
        public void Some_Pass() =>
            Assert.Some(Optional("1234"));

        [Fact]
        public void Some_Fail() =>
            Assert.Throws<SomeException>(
                () => Assert.Some(Option<string>.None));

        [Fact]
        public void Some_WithExpectation_Pass() =>
            Assert.Some("1234", Optional("1234"));

        [Fact]
        public void Some_WithNone_Fail() =>
            Assert.Throws<SomeException>(
                () => Assert.Some("1234", Option<string>.None));

        [Fact]
        public void Some_WithIncorrectExpectation_Fail() =>
            Assert.Throws<EqualException>(
                () => Assert.Some("1234", Optional("5678")));
    }
}
