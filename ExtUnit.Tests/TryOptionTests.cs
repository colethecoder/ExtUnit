using LanguageExt;
using static LanguageExt.Prelude;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace ExtUnit.Tests
{
    public class TryOptionTests
    {
        private TryOption<string> SampleFail() => () =>
            throw new NotImplementedException();

        private TryOption<string> SampleNone() => () =>
            Option<string>.None;

        private TryOption<string> SampleSome() => () =>
            Optional("1234");

        [Fact]
        public void Failure_Passes() =>
            Assert.Failure(SampleFail());

        [Fact]
        public void Failure_WithExceptionType_Passes() =>
            Assert.Failure<string, NotImplementedException>(SampleFail());

        [Fact]
        public void Failure_WithIncorrectExceptionType_Fails() =>
            Assert.Throws<FailureException>(
                () => Assert.Failure<string, NullReferenceException>(SampleFail()));

        [Fact]
        public void Failure_WithNone_Fails() =>
            Assert.Throws<FailureException>(
                () => Assert.Failure(SampleNone()));

        [Fact]
        public void Failure_WithSome_Fails() =>
            Assert.Throws<FailureException>(
                () => Assert.Failure(SampleSome()));

    }
}
