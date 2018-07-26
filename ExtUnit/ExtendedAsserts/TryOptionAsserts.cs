using LanguageExt;
using static LanguageExt.Prelude;
using Xunit.Sdk;
using System;
using System.Reflection;

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
        /// Verifies that an TryOption is in the None state
        /// </summary>
        /// <param name="value">The TryOption to be assessed</param>        
        /// <exception cref="NoneException">Thrown when the TryOption is in the Some or Fail state</exception>
        public static void None<T>(TryOption<T> value) =>
            value.Match(
                Some: x => throw new NoneException(),
                None: () => unit,
                Fail: x => throw new NoneException());

        /// <summary>
        /// Verifies that an TryOption is in the Some state
        /// </summary>
        /// <param name="value">The TryOption to be assessed</param>        
        /// <exception cref="SomeException">Thrown when the TryOption is in the None or Fail state</exception>
        public static void Some<T>(TryOption<T> value) =>
            value.Match(
                Some: identity,
                None: () => throw new SomeException(),
                Fail: x => throw new SomeException());

        /// <summary>
        /// Verifies that an TryOption is in the Some state and the value matches the expectation
        /// </summary>
        /// <param name="value">The TryOption to be assessed</param>        
        /// <exception cref="SomeException">Thrown when the TryOption is in the None or Fail state</exception>
        /// <exception cref="EqualException">Thrown when the TryOption value does not match</exception>
        public static void Some<T>(T expected, TryOption<T> actual) =>
            actual.Match(
                Some: x => Equal(expected, x),
                None: () => throw new SomeException(),
                Fail: x => throw new SomeException());


        public static void Fail<T>(TryOption<T> value) =>
            value.Match(
                Some: x => throw new FailException(),
                None: () => throw new FailException(),
                Fail: identity);

        public static void Fail<T, U>(TryOption<T> value) where U : Exception =>
            value.Match(
                Some: x => throw new FailException(),
                None: () => throw new FailException(),
                Fail: x => exceptionIs<U>(x) 
                            ? x
                            : raise<Exception>(new FailException()));

    }
}
