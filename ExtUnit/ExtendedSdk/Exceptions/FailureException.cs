namespace Xunit.Sdk
{
    /// <summary>
    /// Exception thrown when TryOption unexpectedly has a value or is none.
    /// </summary>
#if XUNIT_VISIBILITY_INTERNAL
    internal
#else
    public
#endif
    class FailureException : XunitException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="FailureException"/> class.
        /// </summary>
        public FailureException()
            : base("Assert.Failure() Failure")
        { }
    }
}
