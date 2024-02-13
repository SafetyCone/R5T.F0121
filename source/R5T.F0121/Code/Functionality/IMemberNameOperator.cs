using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using R5T.F0121.Extensions;
using R5T.L0089.T000;
using R5T.T0132;
using R5T.T0161;
using R5T.T0161.Extensions;


namespace R5T.F0121
{
    [FunctionalityMarker]
    public partial interface IMemberNameOperator : IFunctionalityMarker
    {
        public IFullMethodName Get_FullMethodName(IKindMarkedFullMethodName kindMarkedFullMethodName)
        {
            var tokens = this.Get_KindMarkerTokens(kindMarkedFullMethodName);

            var fullMethodNameToken = tokens.Second();

            var output = fullMethodNameToken.ToFullMethodName();
            return output;
        }

        public IFullPropertyName Get_FullPropertyName(IKindMarkedFullPropertyName kindMarkedFullPropertyName)
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

        public IKindMarker Get_KindMarker(IKindMarked kindMarked)
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
            INamespacedTypedParameterizedMethodName,
            IFullMethodName)
        Get_NamespacedTypedParameterizedMethodName(
            IKindMarkedFullMethodName kindMarkedFullMethodName)
        {
            var fullMethodName = this.Get_FullMethodName(kindMarkedFullMethodName);

            var tokens = this.Get_OutputTypeNameTokens(fullMethodName);

            var methodNameToken = tokens.First();

            var output = methodNameToken.ToNamespacedTypedParameterizedMethodName();
            return (output, fullMethodName);
        }

        public INamespacedTypedMethodName Get_NamespacedTypedMethodName(INamespacedTypedParameterizedMethodName namespacedTypedParameterizedMethodName)
        {
            var parameterListStartTokenIndex = this.Get_ParameterListStartTokenIndex(namespacedTypedParameterizedMethodName);

            var namespacedTypedMethodNameValue = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                parameterListStartTokenIndex,
                namespacedTypedParameterizedMethodName.Value);

            var namespacedTypedMethodName = namespacedTypedMethodNameValue.ToNamespacedTypedMethodName();
            return namespacedTypedMethodName;
        }

        public INamespacedTypedPropertyName Get_NamespacedTypedPropertyName(IFullPropertyName fullPropertyName)
        {
            var tokens = this.Get_OutputTypeNameTokens(fullPropertyName);

            var namespacedTypedPropertyNameValue = tokens.First();

            var namespacedTypedPropertyName = namespacedTypedPropertyNameValue.ToNamespacedTypedPropertyName();
            return namespacedTypedPropertyName;
        }

        public (
            INamespacedTypeName,
            INamespacedTypedMethodName)
        Get_NamespacedTypeName(INamespacedTypedParameterizedMethodName namespacedTypedParameterizedMethodName)
        {
            var namspacedTypedMethodName = this.Get_NamespacedTypedMethodName(namespacedTypedParameterizedMethodName);

            var namespacedTypeName = this.Get_NamespacedTypeName(namspacedTypedMethodName);
            
            return (
                namespacedTypeName,
                namspacedTypedMethodName);
        }

        public INamespacedTypeName Get_NamespacedTypeName(INamespacedTypeNamedMember namespacedTypeNamedMember)
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

        public IOutputTypeName Get_OutputTypeName(IOutputTypeNamed outputTypeNamed)
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

        public IParameterList Get_ParameterList(IParameterListed parameterListed)
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
            IParameterList,
            INamespacedTypedParameterizedMethodName,
            IFullMethodName)
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

        public IParameter[] Get_Parameters(IParameterList parameterList)
        {
            // Note, generic type parameters with multiple type arguments use the same list separator.
            // So we will have to combine tokens if generic type arguments are detected.
            var rawParameterTokens = Instances.StringOperator.Split(
                Instances.Characters.ParameterListParameterSeparator,
                parameterList.Value,
                StringSplitOptions.RemoveEmptyEntries)
                .Trim();

            var parameterTokens = new List<string>();

            int genericTypeOpenTokensCount = 0;
            int genericTypeCloseTokensCount = 0;

            var builder = new StringBuilder();

            foreach (var rawParameterToken in rawParameterTokens)
            {
                builder.Append(rawParameterToken);

                genericTypeOpenTokensCount += Instances.StringOperator.CountOf(
                    Instances.Characters.GenericTypeParametersListStartToken,
                    rawParameterToken);

                genericTypeCloseTokensCount += Instances.StringOperator.CountOf(
                    Instances.Characters.GenericTypeParametersListEndToken,
                    rawParameterToken);

                if(genericTypeOpenTokensCount == genericTypeCloseTokensCount)
                {
                    genericTypeOpenTokensCount = 0;
                    genericTypeCloseTokensCount = 0;

                    var parameterToken = builder.ToString();
                    builder.Clear();

                    parameterTokens.Add(parameterToken);
                }
                else
                {
                    // Add back the standard separator.
                    builder.Append(Instances.Strings.ParameterListTokenSeparator);
                }
            }

            var parameters = parameterTokens
                .Select(x => x.ToParameter())
                .Now();

            return parameters;
        }

        public (
            IParameter[],
            IParameterList)
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
            IParameter[] parameters,
            IParameterList paramtersList,
            INamespacedTypedParameterizedMethodName namespacedTypedParameterizedMethodName,
            IFullMethodName fullMethodName)
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

        public ISimplePropertyName Get_SimplePropertyName(INamespacedTypedPropertyName namespacedTypedPropertyName)
        {
            var lastNameTokenSeparatorIndex = this.Get_LastNameTokenSeparatorIndex(namespacedTypedPropertyName);

            var simplePropertyNameValue = Instances.StringOperator.Get_Substring_Exclusive(
                lastNameTokenSeparatorIndex,
                namespacedTypedPropertyName.Value);

            var simplePropertyName = simplePropertyNameValue.ToSimplePropertyName();
            return simplePropertyName;
        }

        public ISimpleMethodName Get_SimpleMethodName(INamespacedTypedMethodName namespacedTypedMethodName)
        {
            var lastNameTokenSeparatorIndex = this.Get_LastNameTokenSeparatorIndex(namespacedTypedMethodName);

            var simpleMethodNameValue = Instances.StringOperator.Get_Substring_Exclusive(
                lastNameTokenSeparatorIndex,
                namespacedTypedMethodName.Value);

            var simpleMethodName = simpleMethodNameValue.ToSimpleMethodName();
            return simpleMethodName;
        }

        public ISimpleTypeName Get_SimpleTypeName(INamespacedTypeName namespacedTypeName)
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
            ISimpleTypeName,
            INamespacedTypeName)
        Get_SimpleTypeName(INamespacedTypeNamedMember namespacedTypeNamedMember)
        {
            var namespacedTypeName = this.Get_NamespacedTypeName(namespacedTypeNamedMember);

            var simpleTypeName = this.Get_SimpleTypeName(namespacedTypeName);

            return (
                simpleTypeName,
                namespacedTypeName);
        }

        public (
            ISimpleTypeName,
            INamespacedTypeName,
            INamespacedTypedPropertyName,
            IFullPropertyName)
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
            ISimplestMethodName,
            ISimpleMethodName,
            INamespacedTypedMethodName,
            INamespacedTypedParameterizedMethodName,
            IFullMethodName)
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

        public ISimplestMethodName Get_SimplestMethodName(ISimpleMethodName simpleMethodName)
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
                name,
                Instances.Characters.GenericTypeParametersListStartToken);

            return output;
        }

        public WasFound<IKindMarker> Is_KindOneOf(
            IKindMarked kindMarked,
            params IKindMarker[] kindMarkers)
        {
            var kindMarker = this.Get_KindMarker(kindMarked);

            var foundKindMarkerOrDefault = kindMarkers
                .Where(x => x.Equals(kindMarker))
                .FirstOrDefault();

            var output = WasFound.From(foundKindMarkerOrDefault);
            return output;
        }

        public void Verify_Is_KindOneOf(
            IKindMarked kindMarked,
            params IKindMarker[] kindMarkers)
        {
            var isKindOneOf = this.Is_KindOneOf(
                kindMarked,
                kindMarkers);

            isKindOneOf.Get_Result_OrExceptionIfNotFound($"Kind was not one of one of the provided kinds:\n{kindMarked}");
        }
    }
}
