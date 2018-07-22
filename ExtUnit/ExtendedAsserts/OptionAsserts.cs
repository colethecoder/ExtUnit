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
        /// Verifies that a string contains a given sub-string, using the current culture.
        /// </summary>
        /// <param name="expectedSubstring">The sub-string expected to be in the string</param>
        /// <param name="actualString">The string to be inspected</param>
        /// <exception cref="ContainsException">Thrown when the sub-string is not present inside the string</exception>
        public static void IsNone<T>(Option<T> value) =>
            value.Match(
                Some: x => throw new AssertActualExpectedException(Option<T>.None, value, "Expected None but the Option had a value."),
                None: () => unit);

        public static void IsSome<T>(Option<T> value) =>
            value.Match(
                Some: identity,
                None: () => throw new AssertActualExpectedException(Option<T>.Some(default(T)), value, "Expected Some but the Option was None."));

        public static void IsSome<T>(T expected, Option<T> actual) =>
            actual.Match(
                Some: x => Assert.Equal(expected, x),
                None: () => throw new AssertActualExpectedException(Option<T>.Some(default(T)), actual, "Expected Some but the Option was None.")
                );

    }
}
