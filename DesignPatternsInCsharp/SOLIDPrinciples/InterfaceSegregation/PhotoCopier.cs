namespace DesignPatternsInCsharp.SOLIDPrinciples.InterfaceSegregation
{
    //Hence PhotoCopier doesn't need to implement IMachine interface as PhotoCopier doesn't have functionality for Fax
    //and as we did interface segregation, we implemented those smaller interfaces
    class PhotoCopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }
}
