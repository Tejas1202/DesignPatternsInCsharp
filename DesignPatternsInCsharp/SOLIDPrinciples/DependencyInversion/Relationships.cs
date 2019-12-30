using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsInCsharp.SOLIDPrinciples.DependencyInversion
{
    //low-level parts of the system (defining relationships between different people)
    //Hence this is our low level API
    class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        //Some sort of API for adding Parent and child relationship 
        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child)); //Duplicating data in the database just for speed of access (just for example)
            relations.Add((child, Relationship.Child, parent)); //Adding reverse relationship just for the fun of it
        }

        #region Problematic code
        //The problem with this code is we're accessing a very low level part(i.e. this class's datastore) in Research class
        //through a specifically designed property which exposes the private field as public
        //Which means that Relationships cannot change its mind about how to store the relationships (e.g. if they want to use dictionary instead of tuple)
        //hence Relationships cannot really change the way it stores data
        //so a better way to achieve this is a creating form of abstraction by simply defining an interface to how Relationships class can allow you to access certain high level data
        public List<(Person, Relationship, Person)> Relations => relations; //Just making a property getter for this field for accessing this private field on high level
        #endregion

        #region Correct approach. Hence we implement the interface
        //Hence now we can change the underlying logic in this case if we want to as relations is not exposed to any other class unlike previously
        public IEnumerable<Person> FindAllChildren(string name)
        {
            return relations.Where(
                x => x.Item1.Name == name &&
                x.Item2 == Relationship.Parent
                ).Select(r => r.Item3);
        }
        #endregion
    }
}
