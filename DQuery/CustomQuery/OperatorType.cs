namespace DQuery.CustomQuery
{
    public enum OperatorType
    {
        [Attach("")]
        None,

        [Attach("=")]
        Equal,

        [Attach("<>")]
        NotEqual,

        [Attach(">")]
        GreaterThan,

        [Attach(">=")]
        GreaterThanOrEqual,

        [Attach("<")]
        LessThan,

        [Attach("<=")]
        LessThanOrEqual,

        [Attach("like")]
        Like,

        [Attach("not like")]
        NotLike,

        [Attach("in")]
        In
    }
}
