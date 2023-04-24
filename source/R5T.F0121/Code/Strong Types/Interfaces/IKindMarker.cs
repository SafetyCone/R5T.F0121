using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.F0121
{
    /// <summary>
    /// A strongly-typed character for the identity string marker character (M for method, T for type, etc.).
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/#id-strings"/>.
    /// </summary>
    [StrongTypeMarker]
    public interface IKindMarker : ITyped<char>, IStrongTypeMarker
    {
    }
}
