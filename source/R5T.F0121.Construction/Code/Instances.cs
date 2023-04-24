using System;


namespace R5T.F0121.Construction
{
    public static class Instances
    {
        public static T0161.IConstructors Constructors => T0161.Constructors.Instance;
        public static IValues Values => Construction.Values.Instance;
        public static IMemberNameOperator MemberNameOperator => F0121.MemberNameOperator.Instance;
        public static F0000.ITextOperator TextOperator => F0000.TextOperator.Instance;
    }
}