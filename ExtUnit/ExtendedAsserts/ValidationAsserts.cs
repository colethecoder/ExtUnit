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
        public static void Success<T,U>(Validation<T,U> value) =>
            value.Match(
                Succ: x => unit,
                Fail: x => throw new SuccessException());

        public static void Success<T, U>(U expected, Validation<T, U> actual) =>
            actual.Match(
                Succ: x => Equal(expected, x),
                Fail: x => throw new SuccessException());

        public static void Fail<T, U>(Validation<T, U> value) =>
            value.Match(
                Succ: x => throw new FailureException(),
                Fail: x => unit);

        public static void Fail<T, U>(Validation<T, U> value, Action<Seq<T>> assertAction) =>
            value.Match(
                Succ: x => throw new FailureException(),
                Fail: x => assertAction(x));

        public static void FailContains<T, U>(T expected, Validation<T, U> value) =>
            Fail(value, x => Contains(expected, x));

        public static void FailContains<T, U>(Validation<T, U> value, Predicate<T> predicate) =>
            Fail(value, x => Contains(x, predicate));
    }
}
