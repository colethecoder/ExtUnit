using System;
using LanguageExt;
using static LanguageExt.Prelude;
using Xunit;
using Xunit.Sdk;

namespace ExtUnit.Tests
{
    public class OptionAsyncTests
    {
        [Fact]
        public async void NoneAsync_Pass() =>
            await Assert.NoneAsync(OptionAsync<string>.None);

        [Fact]
        public async void NoneAsync_Fail() =>
            await Assert.ThrowsAsync<NoneException>(
                async () => await Assert.NoneAsync(OptionAsync<string>.Some("1234")));

        [Fact]
        public async void SomeAsync_Pass() =>
            await Assert.SomeAsync(OptionAsync<string>.Some("1234"));

        [Fact]
        public async void SomeAsync_Fail() =>
            await Assert.ThrowsAsync<SomeException>(
                async () =>  await Assert.SomeAsync(OptionAsync<string>.None));

        [Fact]
        public async void SomeAsync_WithExpectation_Pass() =>
            await Assert.SomeAsync("1234", OptionAsync<string>.Some("1234"));

        [Fact]
        public async void SomeAsync_WithNone_Fail() =>
            await Assert.ThrowsAsync<SomeException>(
                async () => await Assert.SomeAsync("1234", OptionAsync<string>.None));

        [Fact]
        public async void Some_WithIncorrectExpectation_Fail() =>
            await Assert.ThrowsAsync<EqualException>(
                async () => await Assert.SomeAsync("1234", OptionAsync<string>.Some("5678")));

        [Fact]
        public async void SomeAsync_WithCorrectAsserts_Pass() =>
            await Assert.SomeAsync(OptionAsync<int>.Some(1234), x => Assert.InRange(x, 1, 9999));

        [Fact]
        public async void SomeAsync_WithIncorrectAsserts_Fail() =>
            await Assert.ThrowsAsync<InRangeException>(
                async () => await Assert.SomeAsync(OptionAsync<int>.Some(1234), x => Assert.InRange(x, 1, 999)));
    }
}
