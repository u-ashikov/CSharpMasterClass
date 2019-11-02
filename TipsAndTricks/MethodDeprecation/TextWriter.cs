using System;
using System.IO;

namespace MethodDeprecation
{
    public class TextWriter
    {
        //[Obsolete("Please use WriteToFile instead.")]
        [Obsolete("Please use WriteToFile instead.", true)]
        public void WriteToFile(string pathToFile, string text)
        {
            if (File.Exists(pathToFile))
            {
                File.WriteAllText(pathToFile, text);
            }
        }

        public void WriteToConsole(string text)
        {
            Console.WriteLine($"Your text is: {text}");
        }
    }
}
