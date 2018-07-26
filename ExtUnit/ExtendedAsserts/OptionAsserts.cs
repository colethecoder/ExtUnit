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
        /// Verifies that an Option is in the None state
        /// </summary>
        /// <param name="value">The Option to be assessed</param>        
        /// <exception cref="NoneException">Thrown when the Option is in the Some state</exception>
        public static void None<T>(Option<T> value) =>
            value.Match(
                Some: x => throw new NoneException(),
                None: () => unit);

        /// <summary>
        /// Verifies that an Option is in the Some state
        /// </summary>
        /// <param name="value">The Option to be assessed</param>        
        /// <exception cref="SomeException">Thrown when the Option is in the None state</exception>
        public static void Some<T>(Option<T> value) =>
            value.Match(
                Some: identity,
                None: () => throw new SomeException());

        /// <summary>
        /// Verifies that an Option is in the Some state and the value matches the expectation
        /// </summary>
        /// <param name="value">The Option to be assessed</param>        
        /// <exception cref="SomeException">Thrown when the Option is in the None state</exception>
        /// <exception cref="EqualException">Thrown when the Option value does not match</exception>
        public static void Some<T>(T expected, Option<T> actual) =>
            actual.Match(
                Some: x => Equal(expected, x),
                None: () => throw new SomeException());

        public static void Some<T>(Option<T> value, Action<T> asserts) =>
            value.Match(
                Some: x => asserts(x),
                None: () => throw new SomeException());

    }
}
