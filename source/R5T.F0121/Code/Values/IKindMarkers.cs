using System;

using R5T.T0131;

using R5T.F0121.Extensions;


namespace R5T.F0121
{
    [ValuesMarker]
    public partial interface IKindMarkers : IValuesMarker
    {
        public IKindMarker Error => '!'.ToKindMarker();
        public IKindMarker Event => 'E'.ToKindMarker();
        public IKindMarker Field => 'F'.ToKindMarker();
        public IKindMarker Method => 'M'.ToKindMarker();
        public IKindMarker Namespace => 'N'.ToKindMarker();
        public IKindMarker Property => 'P'.ToKindMarker();
        public IKindMarker Type => 'T'.ToKindMarker();
    }
}
