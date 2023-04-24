using System;


namespace R5T.F0121
{
    public class MemberNameOperator : IMemberNameOperator
    {
        #region Infrastructure

        public static IMemberNameOperator Instance { get; } = new MemberNameOperator();


        private MemberNameOperator()
        {
        }

        #endregion
    }
}
