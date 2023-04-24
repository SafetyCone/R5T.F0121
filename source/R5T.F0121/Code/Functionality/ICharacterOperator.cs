using System;

using R5T.T0132;


namespace R5T.F0121
{
    [FunctionalityMarker]
    public partial interface ICharacterOperator : IFunctionalityMarker
    {
        public KindMarker ToKindMarker(char value)
        {
            var output = new KindMarker(value);
            return output;
        }
    }
}
