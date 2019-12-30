using System;

namespace DesignPatternsInCsharp.SOLIDPrinciples.InterfaceSegregation
{
    /*Now if our old fashioned printer implements the IMachine interface, then it also has to implement all the members in it
      But as it as old fashioned printer which can only do Printing, we really have to document that as it's an old fashioned printer,
      it cannot do Fax or Scan as the consumers of this class may get confused. Hence, this is where Interface Segregation Principle comes in handy
      (To make sure people don't pay for things they don't need)*/
    class OldFashionedPrinter : IMachine
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
}