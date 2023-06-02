using System;

using R5T.T0132;
using R5T.T0161;
using R5T.T0161.Extensions;


namespace R5T.F0121
{
    [FunctionalityMarker]
    public partial interface IParameterOperator : IFunctionalityMarker
    {
        public int Get_ParameterTokenSeparatorIndex(IParameter parameter)
        {
            var parameterTokenSeparatorIndex = Instances.StringOperator.IndexOf(
                Instances.Characters.ParameterTokenSeparator,
                parameter.Value);

            if (!parameterTokenSeparatorIndex)
            {
                throw new Exception($"Could not find a parameter token separator ('{Instances.Characters.ParameterTokenSeparator}').");
            }

            return parameterTokenSeparatorIndex;
        }

        public ITypeName Get_TypeName(IParameter parameter)
        {
            var parameterTokenSeparatorIndex = this.Get_ParameterTokenSeparatorIndex(parameter);

            var typeNameValue = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                parameterTokenSeparatorIndex,
                parameter.Value)
                .Trim();

            var typeName = typeNameValue.ToTypeName();
            return typeName;
        }
    }
}
