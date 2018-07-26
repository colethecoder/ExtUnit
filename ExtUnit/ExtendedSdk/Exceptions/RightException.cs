namespace Xunit.Sdk
{
    /// <summary>
    /// Exception thrown when Either is not in the Right state.
    /// </summary>
#if XUNIT_VISIBILITY_INTERNAL
    internal
#else
    public
#endif
    class RightException : XunitException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="RightException"/> class.
        /// </summary>
        public RightException()
            : base("Assert.Right() Failure")
        { }
    }
}