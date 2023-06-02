using System;

using R5T.T0131;

using R5T.F0121.Extensions;


namespace R5T.F0121
{
    [ValuesMarker]
    public partial interface IKindMarkers : IValuesMarker
    {
        /// <summary>
        /// '!'
        /// </summary>
        public const char Error_Constant = '!';

        /// <inheritdoc cref="Error_Constant"/>
        public IKindMarker Error => IKindMarkers.Error_Constant.ToKindMarker();

        /// <summary>
        /// 'E'
        /// </summary>
        public const char Event_Constant = 'E';

        /// <inheritdoc cref="Event_Constant"/>
        public IKindMarker Event => Event_Constant.ToKindMarker();

        /// <summary>
        /// 'F'
        /// </summary>
        public const char Field_Constant = 'F';

        /// <inheritdoc cref="Field_Constant"/>
        public IKindMarker Field => Field_Constant.ToKindMarker();

        /// <summary>
        /// 'M'
        /// </summary>
        public const char Method_Constant = 'M';

        /// <inheritdoc cref="Method_Constant"/>
        public IKindMarker Method => Method_Constant.ToKindMarker();

        /// <summary>
        /// 'N'
        /// </summary>
        public const char Namespace_Constant = 'N';

        /// <inheritdoc cref="Namespace_Constant"/>
        public IKindMarker Namespace => Namespace_Constant.ToKindMarker();

        /// <summary>
        /// 'P'
        /// </summary>
        public const char Property_Constant = 'P';

        /// <inheritdoc cref="Property_Constant"/>
        public IKindMarker Property => Property_Constant.ToKindMarker();

        /// <summary>
        /// 'T'
        /// </summary>
        public const char Type_Constant = 'T';

        /// <inheritdoc cref="Type_Constant"/>
        public IKindMarker Type => 'T'.ToKindMarker();
    }
}
