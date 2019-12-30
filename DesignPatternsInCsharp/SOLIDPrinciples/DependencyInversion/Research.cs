using System;
using System.Linq;

namespace DesignPatternsInCsharp.SOLIDPrinciples.DependencyInversion
{
    //Now how to perform Research on our low level API (e.g we want to find out all the children of a particular person)
    //Hence making a class Research
    class Research
    {
        #region Problematic code
        //One of the ways (not the best way) to access the low level into a high level is to simply allow the high level module to access
        //some of the internals of the low level module by giving it the list of relations
        //So we're creating ctor which takes relationships as the argument
        public Research(Relationships relationships)
        {
            var relations = relationships.Relations; //Accessing the low-level data through Property
            foreach (var r in relations.Where(
                x => x.Item1.Name == "John" &&
                x.Item2 == Relationship.Parent
                ))
            {
                Console.WriteLine($"John has a child called {r.Item3.Name}");
            }
        }
        #endregion

        #region So now instead of depending upon the low level module, we depend upon the interface
        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildren("John"))
                Console.WriteLine($"John has a child called {p.Name}");
        }
        #endregion
    }
}
