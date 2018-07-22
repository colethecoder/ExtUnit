namespace Xunit.Sdk
{
    /// <summary>
    /// Exception thrown when Option is unexpectedly None.
    /// </summary>
#if XUNIT_VISIBILITY_INTERNAL
    internal
#else
    public
#endif
    class SomeException : XunitException
    {
        /// <summary>
        /// Creates a new instance of the <see cref="SomeException"/> class.
        /// </summary>
        public SomeException()
            : base("Assert.Some() Failure")
        { }
    }
}