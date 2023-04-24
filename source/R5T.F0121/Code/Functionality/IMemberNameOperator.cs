using System;
using System.Linq;

using R5T.F0121.Extensions;
using R5T.T0132;
using R5T.T0161;
using R5T.T0161.Extensions;


namespace R5T.F0121
{
    [FunctionalityMarker]
    public partial interface IMemberNameOperator : IFunctionalityMarker
    {
        public FullMethodName Get_FullMethodName(IKindMarkedFullMethodName kindMarkedFullMethodName)
        {
            var tokens = this.Get_KindMarkerTokens(kindMarkedFullMethodName);

            var fullMethodNameToken = tokens.Second();

            var output = fullMethodNameToken.ToFullMethodName();
            return output;
        }

        public FullPropertyName Get_FullPropertyName(IKindMarkedFullPropertyName kindMarkedFullPropertyName)
        {
            var tokens = this.Get_KindMarkerTokens(kindMarkedFullPropertyName);

            var fullPropertyNameToken = tokens.Second();

            var output = fullPropertyNameToken.ToFullPropertyName();
            return output;
        }

        public string[] Get_KindMarkerTokens(IKindMarked kindMarked)
        {
            var tokens = Instances.StringOperator.Split(
                Instances.Characters.KindMarkerTokenSeparator,
                kindMarked.Value);

            return tokens;
        }

        public KindMarker Get_KindMarker(IKindMarked kindMarked)
        {
            var tokens = this.Get_KindMarkerTokens(kindMarked);

            var kindMarkerToken = tokens.First();

            // No validation.

            var kindMarkerValue = kindMarkerToken.First();

            var output = kindMarkerValue.ToKindMarker();
            return output;
        }

        public TMemberName Get_MemberName<TMemberName>(
            IKindMarkedMemberName kindMarkedMemberName,
            Func<string, TMemberName> memberNameConstructor)
            where TMemberName : IMemberName
        {
            var tokens = this.Get_KindMarkerTokens(kindMarkedMemberName);

            var memberNameToken = tokens.Second();

            var memberName = memberNameConstructor(memberNameToken);
            return memberName;
        }

        public (
            NamespacedTypedParameterizedMethodName,
            FullMethodName)
        Get_NamespacedTypedParameterizedMethodName(
            IKindMarkedFullMethodName kindMarkedFullMethodName)
        {
            var fullMethodName = this.Get_FullMethodName(kindMarkedFullMethodName);

            var tokens = this.Get_OutputTypeNameTokens(fullMethodName);

            var methodNameToken = tokens.First();

            var output = methodNameToken.ToNamespacedTypedParameterizedMethodName();
            return (output, fullMethodName);
        }

        public NamespacedTypedMethodName Get_NamespacedTypedMethodName(INamespacedTypedParameterizedMethodName namespacedTypedParameterizedMethodName)
        {
            var parameterListStartTokenIndex = this.Get_ParameterListStartTokenIndex(namespacedTypedParameterizedMethodName);

            var namespacedTypedMethodNameValue = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                parameterListStartTokenIndex,
                namespacedTypedParameterizedMethodName.Value);

            var namespacedTypedMethodName = namespacedTypedMethodNameValue.ToNamespacedTypedMethodName();
            return namespacedTypedMethodName;
        }

        public NamespacedTypedPropertyName Get_NamespacedTypedPropertyName(IFullPropertyName fullPropertyName)
        {
            var tokens = this.Get_OutputTypeNameTokens(fullPropertyName);

            var namespacedTypedPropertyNameValue = tokens.First();

            var namespacedTypedPropertyName = namespacedTypedPropertyNameValue.ToNamespacedTypedPropertyName();
            return namespacedTypedPropertyName;
        }

        public (
            NamespacedTypeName,
            NamespacedTypedMethodName)
        Get_NamespacedTypeName(INamespacedTypedParameterizedMethodName namespacedTypedParameterizedMethodName)
        {
            var namspacedTypedMethodName = this.Get_NamespacedTypedMethodName(namespacedTypedParameterizedMethodName);

            var namespacedTypeName = this.Get_NamespacedTypeName(namspacedTypedMethodName);
            
            return (
                namespacedTypeName,
                namspacedTypedMethodName);
        }

        public NamespacedTypeName Get_NamespacedTypeName(INamespacedTypeNamedMember namespacedTypeNamedMember)
        {
            var lastNameTokenSeparatorIndex = this.Get_LastNameTokenSeparatorIndex(namespacedTypeNamedMember);

            var namespacedTypeNameValue = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                lastNameTokenSeparatorIndex,
                namespacedTypeNamedMember.Value);

            var namespacedTypeName = namespacedTypeNameValue.ToNamespacedTypeName();
            return namespacedTypeName;
        }

        public int Get_LastNameTokenSeparatorIndex(string name)
        {
            var lastNameTokenSeparatorIndex = Instances.StringOperator.LastIndexOf(
                Instances.Characters.NameTokenSeparator,
                name);

            if (!lastNameTokenSeparatorIndex)
            {
                throw new Exception($"Unable to find a name token separator '{Instances.Characters.NameTokenSeparator}'.");
            }

            return lastNameTokenSeparatorIndex;
        }

        public int Get_LastNameTokenSeparatorIndex(INamespacedTypeNamedMember namespacedTypeNamedMember)
        {
            var output = this.Get_LastNameTokenSeparatorIndex(namespacedTypeNamedMember.Value);
            return output;
        }

        public string[] Get_OutputTypeNameTokens(IOutputTypeNamed outputTypeNamed)
        {
            var tokens = Instances.StringOperator.Split(
                Instances.Characters.OutputTypeTokenSeparator,
                outputTypeNamed.Value);

            return tokens;
        }

        public OutputTypeName Get_OutputTypeName(IOutputTypeNamed outputTypeNamed)
        {
            var tokens = this.Get_OutputTypeNameTokens(outputTypeNamed);

            var outputTypeToken = tokens.Second();

            var output = outputTypeToken.ToOutputTypeName();
            return output;
        }

        public TTypeName Get_OutputTypeName<TTypeName>(
            IOutputTypeNamed outputTyped,
            Func<string, TTypeName> typeNameContructor)
        {
            var tokens = Instances.StringOperator.Split(
                Instances.Characters.OutputTypeTokenSeparator,
                outputTyped.Value);

            var outputTypeToken = tokens.Second();

            var typeName = typeNameContructor(outputTypeToken);
            return typeName;
        }

        public int Get_ParameterListStartTokenIndex(IParameterListed parameterListed)
        {
            var parameterListStartTokenFound = Instances.StringOperator.IndexOf(
                Instances.Characters.ParameterListStartToken,
                parameterListed.Value);

            if (!parameterListStartTokenFound)
            {
                throw new Exception($"Parameter list start token '{Instances.Characters.ParameterListStartToken}' not found.");
            }

            return parameterListStartTokenFound.Result;
        }

        public int Get_TypeParameterListStartTokenIndex(string name)
        {
            var parameterListStartTokenFound = Instances.StringOperator.IndexOf(
                Instances.Characters.GenericTypeParametersListStartToken,
                name);

            if (!parameterListStartTokenFound)
            {
                throw new Exception($"Type parameter list start token '{Instances.Characters.GenericTypeParametersListStartToken}' not found.");
            }

            return parameterListStartTokenFound.Result;
        }

        public ParameterList Get_ParameterList(IParameterListed parameterListed)
        {
            var parameterListStartTokenIndex = this.Get_ParameterListStartTokenIndex(parameterListed);

            var parameterListEndTokenFound = Instances.StringOperator.IndexOf(
                Instances.Characters.ParameterListEndToken,
                parameterListed.Value,
                parameterListStartTokenIndex);

            if (!parameterListEndTokenFound)
            {
                throw new Exception($"Parameter list end token '{Instances.Characters.ParameterListEndToken}' not found.");
            }

            var parameterListValue = Instances.StringOperator.Get_Substring_Exclusive_Exclusive(
                parameterListStartTokenIndex,
                parameterListEndTokenFound,
                parameterListed.Value);

            var parameterList = parameterListValue.ToParameterList();
            return parameterList;
        }

        public (
            ParameterList,
            NamespacedTypedParameterizedMethodName,
            FullMethodName)
        Get_ParameterList(
            IKindMarkedFullMethodName kindMarkedFullMethodName)
        {
            (var namespacedTypedParameterizedMethodName, var fullMethodName) = this.Get_NamespacedTypedParameterizedMethodName(kindMarkedFullMethodName);

            var parameterList = this.Get_ParameterList(namespacedTypedParameterizedMethodName);

            return (
                parameterList,
                namespacedTypedParameterizedMethodName,
                fullMethodName);
        }

        public Parameter[] Get_Parameters(IParameterList parameterList)
        {
            var parameterTokens = Instances.StringOperator.Split(
                Instances.Characters.ParameterListParameterSeparator,
                parameterList.Value,
                StringSplitOptions.RemoveEmptyEntries)
                .Trim();

            var parameters = parameterTokens
                .Select(x => x.ToParameter())
                .Now();

            return parameters;
        }

        public (
            Parameter[],
            ParameterList)
        Get_Parameters(
            INamespacedTypedParameterizedMethodName namespacedTypedParameterizedMethodName)
        {
            var parameterList = this.Get_ParameterList(namespacedTypedParameterizedMethodName);

            var parameters = this.Get_Parameters(parameterList);

            return (
                parameters,
                parameterList);
        }

        public (
            Parameter[],
            ParameterList,
            NamespacedTypedParameterizedMethodName,
            FullMethodName)
        Get_Parameters(
            IKindMarkedFullMethodName kindMarkedFullMethodName)
        {
            var (parameterList, namespacedTypedParameterizedMethodName, fullMethodName) = this.Get_ParameterList(kindMarkedFullMethodName);

            var parameters = this.Get_Parameters(parameterList);

            return (
                parameters,
                parameterList,
                namespacedTypedParameterizedMethodName,
                fullMethodName);
        }

        public SimplePropertyName Get_SimplePropertyName(INamespacedTypedPropertyName namespacedTypedPropertyName)
        {
            var lastNameTokenSeparatorIndex = this.Get_LastNameTokenSeparatorIndex(namespacedTypedPropertyName);

            var simplePropertyNameValue = Instances.StringOperator.Get_Substring_Exclusive(
                lastNameTokenSeparatorIndex,
                namespacedTypedPropertyName.Value);

            var simplePropertyName = simplePropertyNameValue.ToSimplePropertyName();
            return simplePropertyName;
        }

        public SimpleMethodName Get_SimpleMethodName(INamespacedTypedMethodName namespacedTypedMethodName)
        {
            var lastNameTokenSeparatorIndex = this.Get_LastNameTokenSeparatorIndex(namespacedTypedMethodName);

            var simpleMethodNameValue = Instances.StringOperator.Get_Substring_Exclusive(
                lastNameTokenSeparatorIndex,
                namespacedTypedMethodName.Value);

            var simpleMethodName = simpleMethodNameValue.ToSimpleMethodName();
            return simpleMethodName;
        }

        public SimpleTypeName Get_SimpleTypeName(INamespacedTypeName namespacedTypeName)
        {
            var isGeneric = this.Is_Generic(namespacedTypeName);

            string simpleTypeNameValue;

            if (isGeneric)
            {
                // Need to worry about namespaced type names in the generic type parameter list.
                var typeParametersListStartTokenIndex = this.Get_TypeParameterListStartTokenIndex(namespacedTypeName.Value);

                var nonGenericPortionOfName = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                    typeParametersListStartTokenIndex,
                    namespacedTypeName.Value);

                var lastIndex_Exclusive = this.Get_LastNameTokenSeparatorIndex(nonGenericPortionOfName);

                simpleTypeNameValue = Instances.StringOperator.Get_Substring_From_Exclusive(
                    lastIndex_Exclusive,
                    nonGenericPortionOfName);
            }
            else
            {
                // Simple, just get the last name segment.
                var lastIndex_Exclusive = this.Get_LastNameTokenSeparatorIndex(namespacedTypeName.Value);

                simpleTypeNameValue = Instances.StringOperator.Get_Substring_From_Exclusive(
                    lastIndex_Exclusive,
                    namespacedTypeName.Value);
            }

            var output = simpleTypeNameValue.ToSimpleTypeName();
            return output;
        }

        public (
            SimpleTypeName,
            NamespacedTypeName)
        Get_SimpleTypeName(INamespacedTypeNamedMember namespacedTypeNamedMember)
        {
            var namespacedTypeName = this.Get_NamespacedTypeName(namespacedTypeNamedMember);

            var simpleTypeName = this.Get_SimpleTypeName(namespacedTypeName);

            return (
                simpleTypeName,
                namespacedTypeName);
        }

        public (
            SimpleTypeName,
            NamespacedTypeName,
            NamespacedTypedPropertyName,
            FullPropertyName)
        Get_SimpleTypeName(IKindMarkedFullPropertyName kindMarkedFullPropertyName)
        {
            var fullPropertyName = this.Get_FullPropertyName(kindMarkedFullPropertyName);

            var namespacedTypedPropertyName = this.Get_NamespacedTypedPropertyName(fullPropertyName);

            var (simpleTypeName, namespacedTypeName) = this.Get_SimpleTypeName(namespacedTypedPropertyName);

            return (
                simpleTypeName,
                namespacedTypeName,
                namespacedTypedPropertyName,
                fullPropertyName);
        }

        public (
            SimplestMethodName,
            SimpleMethodName,
            NamespacedTypedMethodName,
            NamespacedTypedParameterizedMethodName,
            FullMethodName)
        Get_SimplestMethodName(IKindMarkedFullMethodName kindMarkedFullMethodName)
        {
            var (namespacedTypedParameterizedMethodName, fullMethodName) = this.Get_NamespacedTypedParameterizedMethodName(kindMarkedFullMethodName);

            var namespacedTypedMethodName = this.Get_NamespacedTypedMethodName(namespacedTypedParameterizedMethodName);

            var simpleMethodName = this.Get_SimpleMethodName(namespacedTypedMethodName);

            var simplestMethodName = this.Get_SimplestMethodName(simpleMethodName);

            return (
                simplestMethodName,
                simpleMethodName,
                namespacedTypedMethodName,
                namespacedTypedParameterizedMethodName,
                fullMethodName);
        }

        public SimplestMethodName Get_SimplestMethodName(ISimpleMethodName simpleMethodName)
        {
            var isGeneric = this.Is_Generic(simpleMethodName);

            if(!isGeneric)
            {
                return simpleMethodName.Value.ToSimplestMethodName();
            }

            var typeParametersListStartIndex = Instances.StringOperator.IndexOf(
                Instances.Characters.GenericTypeParametersListStartToken,
                simpleMethodName.Value);

            var simplestMethodNameValue = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                typeParametersListStartIndex,
                simpleMethodName.Value);

            var simplestMethodName = simplestMethodNameValue.ToSimplestMethodName();
            return simplestMethodName;
        }

        public int Get_ParameterTokenSeparatorIndex(IParameter parameter)
        {
            var parameterTokenSeparatorIndex = Instances.StringOperator.IndexOf(
                Instances.Characters.ParameterTokenSeparator,
                parameter.Value);

            if(!parameterTokenSeparatorIndex)
            {
                throw new Exception($"Could not find a parameter token separator ('{Instances.Characters.ParameterTokenSeparator}').");
            }

            return parameterTokenSeparatorIndex;
        }

        public TypeName Get_TypeName(IParameter parameter)
        {
            var parameterTokenSeparatorIndex = this.Get_ParameterTokenSeparatorIndex(parameter);

            var typeNameValue = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                parameterTokenSeparatorIndex,
                parameter.Value)
                .Trim();

            var typeName = typeNameValue.ToTypeName();
            return typeName;
        }

        public bool Is_Generic(ISimpleMethodName simpleMethodName)
        {
            var output = this.Is_Generic(simpleMethodName.Value);
            return output;
        }

        public bool Is_Generic(INamespacedTypeName namespacedTypeName)
        {
            var output = this.Is_Generic(namespacedTypeName.Value);
            return output;
        }

        public bool Is_Generic(string name)
        {
            var output = Instances.StringOperator.Contains(
                Instances.Characters.GenericTypeParametersListStartToken,
                name);

            return output;
        }
    }
}
