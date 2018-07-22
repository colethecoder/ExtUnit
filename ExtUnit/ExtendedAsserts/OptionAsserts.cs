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
        /// Verifies that an Option is in the None state
        /// </summary>
        /// <param name="value">The Option to be assessed</param>        
        /// <exception cref="NoneException">Thrown when the sub-string is not present inside the string</exception>
        public static void None<T>(Option<T> value) =>
            value.Match(
                Some: x => throw new NoneException(),
                None: () => unit);

        public static void Some<T>(Option<T> value) =>
            value.Match(
                Some: identity,
                None: () => throw new SomeException());

        public static void Some<T>(T expected, Option<T> actual) =>
            actual.Match(
                Some: x => Equal(expected, x),
                None: () => throw new SomeException());

    }
}
