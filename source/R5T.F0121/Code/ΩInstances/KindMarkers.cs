using System;


namespace R5T.F0121
{
    public class KindMarkers : IKindMarkers
    {
        #region Infrastructure

        public static IKindMarkers Instance { get; } = new KindMarkers();


        private KindMarkers()
        {
        }

        #endregion
    }
}
