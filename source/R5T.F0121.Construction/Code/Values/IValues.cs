using System;

using R5T.T0131;
using R5T.T0161;
using R5T.T0161.Extensions;


namespace R5T.F0121.Construction
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker
    {
        public IKindMarkedFullMethodName Example_Method01 =>
            "M:R5T.E0047.F001.IReflectedInstanceContextProvider.InExampleClass00Context<TOut>(System.Func<System.Reflection.TypeInfo, TOut> typeFunction);TOut"
            .ToKindMarkedFullMethodName();

        public IKindMarkedFullMethodName Example_Method02 => (
            "M:R5T.D0106.D002.I001.IServiceActionOperator.AddProcessDirectoryNameProviderAction(" +
                "R5T.T0147.IServiceAction<R5T.D0107.IProcessNameProvider> processNameProvider," +
                " R5T.T0147.IServiceAction<R5T.D0106.IDirectoryNameProvider> directoryNameProvider);" +
            "R5T.T0147.IServiceAction<R5T.D0106.D002.IProcessDirectoryNameProvider>")
            .ToKindMarkedFullMethodName();

        public IKindMarkedFullMethodName Example_Method03 =>
            "M:R5T.E0047.F001.IReflectedInstanceContextProvider.InExampleClass00Context();System.Void"
            .ToKindMarkedFullMethodName();

        /// <summary>
        /// Contains a generic type in the parameters list.
        /// </summary>
        public IKindMarkedFullMethodName Example_Method04 =>
            "M:D8S.S0001.IPortfolioExcelFileOperations.UpdatePortfolioFile(System.String portfolioExcelFilePath, System.Collections.Generic.Dictionary<System.String, D8S.S0001.Quote> quotesByTicker);System.Void"
            .ToKindMarkedFullMethodName();
    }
}
