﻿using LanguageExt;
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
        public void Fail_WithNone_Fails() =>
            Assert.Throws<FailException>(
                () => Assert.Fail(SampleNone()));

        [Fact]
        public void Fail_WithSome_Fails() =>
            Assert.Throws<FailException>(
                () => Assert.Fail(SampleSome()));

    }
}
