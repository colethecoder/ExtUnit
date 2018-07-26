namespace Xunit.Sdk
{
    /// <summary>
    /// Exception thrown when Either is not in the Left state.
    /// </summary>
#if XUNIT_VISIBILITY_INTERNAL
    internal
#else
    public
#endif
    class LeftException : XunitException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="LeftException"/> class.
        /// </summary>
        public LeftException()
            : base("Assert.Left() Failure")
        { }
    }
}