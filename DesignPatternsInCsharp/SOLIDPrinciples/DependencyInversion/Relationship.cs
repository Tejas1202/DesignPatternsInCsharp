namespace DesignPatternsInCsharp.SOLIDPrinciples.DependencyInversion
{
    // <summary>
    /// Explaining through a genealogy example
    /// Note: Problematic code has been wrapped inside region with the necessary comment and they should not be written in the first place
    /// </summary>
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name { get; set; }
        //public DateTime DateOfBirth { get; set; } //Just keeping Name property for the sake of simplicity
    }

}
