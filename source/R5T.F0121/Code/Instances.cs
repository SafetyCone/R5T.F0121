using System;


namespace R5T.F0121
{
    public static class Instances
    {
        public static ICharacterOperator CharacterOperator => F0121.CharacterOperator.Instance;
        public static ICharacters Characters => F0121.Characters.Instance;
        public static F0000.IStringOperator StringOperator => F0000.StringOperator.Instance;
        public static IStrings Strings => F0121.Strings.Instance;
    }
}