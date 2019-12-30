namespace DesignPatternsInCsharp.SOLIDPrinciples.InterfaceSegregation
{
    interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    /*Segregating interfaces so that those classes who doesn't have all the capabilities that IMachine has 
    can implement these or a combination of these interfaces*/
    interface IPrinter
    {
        void Print(Document d);
    }

    interface IScanner
    {
        void Scan(Document d);
    }

    //If you want to do a higher level interface, then we can do this as interface can implement from other interfaces
    interface IMultiFunctionDevice : IScanner, IPrinter //,etc...
    {

    }
}
