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
    class SuccessException : XunitException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="SuccessException"/> class.
        /// </summary>
        public SuccessException()
            : base("Assert.Success() Failure")
        { }
    }
}