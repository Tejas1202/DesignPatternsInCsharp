using System.Collections.Generic;

namespace DesignPatternsInCsharp.SOLIDPrinciples.DependencyInversion
{
    interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildren(string name);
    }
}
