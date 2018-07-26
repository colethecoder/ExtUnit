using LanguageExt;
using static LanguageExt.Prelude;
using Xunit.Sdk;

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
        /// Verifies that an Either is in the Left state
        /// </summary>
        /// <param name="value">The Either to be assessed</param>        
        /// <exception cref="LeftException">Thrown when the Either is in the Right state</exception>
        public static void Left<L,R>(Either<L,R> value) =>
            value.Match(
                Left: identity,
                Right: x => throw new LeftException());

        /// <summary>
        /// Verifies that an Either is in the Left state
        /// </summary>
        /// <param name="value">The Either to be assessed</param>        
        /// <exception cref="LeftException">Thrown when the Either is in the Right state</exception>
        /// <exception cref="EqualException">Thrown when the Left value does not match the expectation</exception>
        public static void Left<L, R>(L expected, Either<L, R> actual) =>
            actual.Match(
                Left: x => Equal(expected, x),
                Right: x => throw new LeftException());

        /// <summary>
        /// Verifies that an Either is in the Right state
        /// </summary>
        /// <param name="value">The Either to be assessed</param>        
        /// <exception cref="RightException">Thrown when the Either is in the Left state</exception>
        public static void Right<L, R>(Either<L, R> value) =>
            value.Match(
                Left: x => throw new RightException(),
                Right: identity);

        /// <summary>
        /// Verifies that an Either is in the Right state
        /// </summary>
        /// <param name="value">The Either to be assessed</param>        
        /// <exception cref="RightException">Thrown when the Either is in the Left state</exception>
        /// <exception cref="EqualException">Thrown when the Right value does not match the expectation</exception>
        public static void Right<L, R>(R expected, Either<L, R> actual) =>
            actual.Match(
                Left: x => throw new RightException(),
                Right: x => Equal(expected, x));
    }
}
