using LanguageExt;
using static LanguageExt.Prelude;
using Xunit.Sdk;
using System;

namespace Xunit
{
#if XUNIT_VISIBILITY_INTERNAL 
    internal
#else
    public
#endif
    partial class Assert
    {
        /// <summary>
        /// Verifies that an Try is in the Succ state
        /// </summary>
        /// <param name="value">The Try to be assessed</param>        
        /// <exception cref="SuccessException">Thrown when the Try is in the Fail state</exception>
        public static void Succ<T>(Try<T> value) =>
            value.Match(
                Succ: identity,
                Fail: x => throw new SomeException());

        /// <summary>
        /// Verifies that an Try is in the Succ state and the value matches the expectation
        /// </summary>
        /// <param name="value">The Try to be assessed</param>        
        /// <exception cref="SuccessException">Thrown when the Try is in the Fail state</exception>
        /// <exception cref="EqualException">Thrown when the Try value does not match</exception>
        public static void Succ<T>(T expected, Try<T> actual) =>
            actual.Match(
                Succ: x => Equal(expected, x),                
                Fail: x => throw new SuccessException());


        public static void Fail<T>(Try<T> value) =>
            value.Match(
                Succ: x => throw new FailException(),                
                Fail: identity);

        public static void Fail<T, U>(Try<T> value) where U : Exception =>
            value.Match(
                Succ: x => throw new FailException(),                
                Fail: x => exceptionIs<U>(x)
                            ? x
                            : raise<Exception>(new FailException()));

    }
}
