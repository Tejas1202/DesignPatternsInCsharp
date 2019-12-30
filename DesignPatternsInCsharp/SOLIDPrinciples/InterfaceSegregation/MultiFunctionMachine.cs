using System;

namespace DesignPatternsInCsharp.SOLIDPrinciples.InterfaceSegregation
{
    /*Now if we already have the implementations of a Printer and a Scanner and we're saying that a MultiFunctionDevice is simply a
     joining of those two concrete classes that you already have, then you can do delegation instead of implementing the missing members*/
    class MultiFunctionMachine : IMultiFunctionDevice
    {
        #region as we already have implementation of printer and scanner, hence instead of doing the below code of implementing them again, we'll do delegation
        //public void Print(Document d)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Scan(Document d)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

        private IPrinter _printer;
        private IScanner _scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            _printer = printer ?? throw new ArgumentNullException(paramName: nameof(printer));
            _scanner = scanner ?? throw new ArgumentNullException(paramName: nameof(scanner));
        }

        //delegating the calls to variables _printer and _scanner
        public void Print(Document d)
        {
            _printer.Print(d);
        }

        public void Scan(Document d)
        {
            _scanner.Scan(d);
        } //decorator pattern
    }
}
