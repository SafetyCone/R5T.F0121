using System;

using R5T.T0131;


namespace R5T.F0121
{
    [ValuesMarker]
    public partial interface IStrings : IValuesMarker
    {
        public string KindMarkerTokenSeparator => ":";
    }
}
