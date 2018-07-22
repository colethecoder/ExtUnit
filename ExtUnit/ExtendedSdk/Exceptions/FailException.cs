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
    class FailException : XunitException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="FailException"/> class.
        /// </summary>
        public FailException()
            : base("Assert.Fail() Failure")
        { }
    }
}
