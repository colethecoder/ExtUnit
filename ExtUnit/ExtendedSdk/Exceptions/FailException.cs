namespace Xunit.Sdk
{
    /// <summary>
    /// Exception thrown when Try or TryOption is not in a Fail state.
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
