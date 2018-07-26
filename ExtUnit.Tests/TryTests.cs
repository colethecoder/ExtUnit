using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace ExtUnit.Tests
{
    public class TryTests
    {
        private Try<string> SampleFail() => () =>
            throw new NotImplementedException();

        private Try<string> SampleSome() => () =>
            "1234";

        [Fact]
        public void Fail_Passes() =>
            Assert.Fail(SampleFail());

        [Fact]
        public void Fail_WithExceptionType_Passes() =>
            Assert.Fail<string, NotImplementedException>(SampleFail());

        [Fact]
        public void Fail_WithIncorrectExceptionType_Fails() =>
            Assert.Throws<FailException>(
                () => Assert.Fail<string, NullReferenceException>(SampleFail()));

        [Fact]
        public void Fail_WithValue_Fails() =>
            Assert.Throws<FailException>(
                () => Assert.Fail(SampleSome()));
    }
}
