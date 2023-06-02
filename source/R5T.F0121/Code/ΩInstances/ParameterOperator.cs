using System;


namespace R5T.F0121
{
    public class ParameterOperator : IParameterOperator
    {
        #region Infrastructure

        public static IParameterOperator Instance { get; } = new ParameterOperator();


        private ParameterOperator()
        {
        }

        #endregion
    }
}
