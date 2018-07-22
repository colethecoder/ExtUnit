namespace Xunit.Sdk
{
    /// <summary>
    /// Exception thrown when Option unexpectedly has a value.
    /// </summary>
#if XUNIT_VISIBILITY_INTERNAL
    internal
#else
    public
#endif
    class NoneException : XunitException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="NoneException"/> class.
        /// </summary>
        public NoneException()
            : base("Assert.None() Failure")
        { }
    }
}