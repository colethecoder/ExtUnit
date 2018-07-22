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
        public static void Success<T,U>(Validation<T,U> value) =>
            value.Match(
                Succ: x => throw new SuccessException(),
                Fail: x => unit);

        public static void Success<T, U>(U expected, Validation<T, U> actual) =>
            actual.Match(
                Succ: x => Equal(expected, x),
                Fail: x => throw new SuccessException());
    }
}
