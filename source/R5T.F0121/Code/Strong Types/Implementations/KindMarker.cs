using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.F0121
{
    /// <inheritdoc cref="IKindMarker"/>
    [StrongTypeImplementationMarker]
    public class KindMarker : TypedBase<char>, IStrongTypeImplementationMarker,
        IKindMarker
    {
        public KindMarker(char value)
            : base(value)
        {
        }
    }
}
