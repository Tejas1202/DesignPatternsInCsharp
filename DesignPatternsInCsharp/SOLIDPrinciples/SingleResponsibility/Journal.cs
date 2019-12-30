using System;
using System.Collections.Generic;

namespace DesignPatternsInCsharp.SOLIDPrinciples.SingleResponsibility
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count} : {text}");

            return count; //memento pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index); //Not the ideal way to remove entries, bc once you remove one of the entries, all the neighbouring indices becomes invalid
        }

        //if you want to print a string representation of your own class or struct, you should override the ToString() method (taken from SO)
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        #region Don't add the persistance logic of Journal here in this class itself according to Single Responsibility principle
        //public void Save(string filename)
        //{
        //    File.WriteAllText(filename, ToString());
        //}

        //public void Load(Uri uri)
        //{

        //}
        #endregion
    }
}
