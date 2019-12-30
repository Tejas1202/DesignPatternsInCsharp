namespace DesignPatternsInCsharp.SOLIDPrinciples.InterfaceSegregation
{
    //As MultiFunctionPrinter can actually do all the things, hence implemeting IMachine interface in this class does makes sense
    class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

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
