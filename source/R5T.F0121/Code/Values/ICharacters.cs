using System;

using R5T.T0131;


namespace R5T.F0121
{
    [ValuesMarker]
    public partial interface ICharacters : IValuesMarker
    {
        private static Z0000.ICharacters Characters => Z0000.Characters.Instance;


        public const char ErrorKindMarker_Constant = Z0000.ICharacters.ExclamationMark_Constant;
        public const char EventKindMarker_Constant = Z0000.ICharacters.E_Uppercase_Constant;
        public const char FieldKindMarker_Constant = Z0000.ICharacters.F_Uppercase_Constant;
        public const char MethodKindMarker_Constant = Z0000.ICharacters.M_Uppercase_Constant;
        public const char NamespaceKindMarker_Constant = Z0000.ICharacters.N_Uppercase_Constant;
        public const char PropertyKindMarker_Constant = Z0000.ICharacters.P_Uppercase_Constant;
        public const char TypeKindMarker_Constant = Z0000.ICharacters.T_Uppercase_Constant;

        public char ErrorKindMarker => ICharacters.ErrorKindMarker_Constant;
        public char EventKindMarker => ICharacters.EventKindMarker_Constant;
        public char FieldKindMarker => ICharacters.FieldKindMarker_Constant;
        public char MethodKindMarker => ICharacters.MethodKindMarker_Constant;
        public char NamespaceKindMarker => ICharacters.NamespaceKindMarker_Constant;
        public char PropertyKindMarker => ICharacters.PropertyKindMarker_Constant;
        public char TypeKindMarker => ICharacters.TypeKindMarker_Constant;


        public const char KindMarkerTokenSeparator_Constant = Z0000.ICharacters.Colon_Constant;
        public const char OutputTypeTokenSeparator_Constant = Z0000.ICharacters.Semicolon_Constant;

        public char KindMarkerTokenSeparator => ICharacters.KindMarkerTokenSeparator_Constant;
        public char OutputTypeTokenSeparator => ICharacters.OutputTypeTokenSeparator_Constant;


        public char GenericTypeParametersListStartToken => Characters.OpenAngleBracket;
        public char GenericTypeParametersListEndToken => Characters.CloseAngleBracket;
        public char NameTokenSeparator => Characters.Period;
        public char ParameterListEndToken => Characters.CloseParenthesis;
        public char ParameterListParameterSeparator => Characters.Comma;
        public char ParameterListStartToken => Characters.OpenParenthesis;
        public char ParameterTokenSeparator => Characters.Space;
    }
}
