using System.IO;

namespace DesignPatternsInCsharp.SOLIDPrinciples.SingleResponsibility
{
    public class Persistance
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }
}
