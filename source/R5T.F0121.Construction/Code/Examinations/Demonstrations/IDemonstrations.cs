using System;

using R5T.T0141;
using R5T.T0161;
using R5T.T0179.Extensions;


namespace R5T.F0121.Construction
{
    [DemonstrationsMarker]
    public partial interface IDemonstrations : IDemonstrationsMarker
    {
        public void Get_MethodParameters()
        {
            var kindMarkedFullMethodName =
                //Instances.Values.Example_Method01
                //Instances.Values.Example_Method02
                //Instances.Values.Example_Method03
                Instances.Values.Example_Method04
                ;

            var (parameters, _, _, _) = Instances.MemberNameOperator.Get_Parameters(kindMarkedFullMethodName);

            var parametersOutput = Instances.TextOperator.JoinLines(parameters.ToStrings());

            Console.WriteLine($"{kindMarkedFullMethodName}\n\n{parametersOutput}: parameters");
        }

        public void Get_MethodParameterList()
        {
            var kindMarkedFullMethodName =
                //Instances.Values.Example_Method01
                Instances.Values.Example_Method02
                ;

            var (parameterList, _, _) = Instances.MemberNameOperator.Get_ParameterList(kindMarkedFullMethodName);

            Console.WriteLine($"{kindMarkedFullMethodName}\n\n{parameterList}: parameter list");
        }

        public void Get_MethodName()
        {
            var kindMarkedFullMethodName =
                //Instances.Values.Example_Method01
                Instances.Values.Example_Method02
                ;

            var (methodName, _) = Instances.MemberNameOperator.Get_NamespacedTypedParameterizedMethodName(kindMarkedFullMethodName);

            Console.WriteLine($"{kindMarkedFullMethodName}\n\n{methodName}: method name");
        }

        public void Get_SimplestMethodName()
        {
            var kindMarkedFullMethodName =
                Instances.Values.Example_Method01
                //Instances.Values.Example_Method02
                ;

            var (simplestMethodName, _, _, _, _) = Instances.MemberNameOperator.Get_SimplestMethodName(kindMarkedFullMethodName);

            Console.WriteLine($"{kindMarkedFullMethodName}\n\n{simplestMethodName}: simplest method name");
        }

        public void Get_OutputTypeName()
        {
            var kindMarkedFullMethodName =
                //Instances.Values.Example_Method01
                Instances.Values.Example_Method02
                ;

            var outputTypeName =
                //Instances.MemberNameOperator.Get_OutputTypeName(kindMarkedMemberName)
                Instances.MemberNameOperator.Get_OutputTypeName(
                    kindMarkedFullMethodName,
                    Instances.Constructors.NamespacedTypeName)
                ;

            Console.WriteLine($"{kindMarkedFullMethodName}\n\n{outputTypeName}: output type name");
        }

        public void Get_MemberName()
        {
            var kindMarkedFullMethodName = Instances.Values.Example_Method01;

            var memberName = Instances.MemberNameOperator.Get_MemberName(
                kindMarkedFullMethodName,
                Instances.Constructors.FullMethodName);

            Console.WriteLine($"{kindMarkedFullMethodName}\n\n{memberName}: member name");
        }

        public void Get_KindMarker()
        {
            var kindMarked = Instances.Values.Example_Method01;

            var kindMarker = Instances.MemberNameOperator.Get_KindMarker(kindMarked);

            Console.WriteLine($"{kindMarked}\n\n{kindMarker}: kind marker");
        }
    }
}
