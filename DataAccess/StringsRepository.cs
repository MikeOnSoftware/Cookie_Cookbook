using System.Collections.Generic;
using System.IO;

namespace Cookie_Cookbook.DataAccess
{
    public abstract class StringsRepository : IStringsRepository
    {
        //the classes of the DataAccess namespace should not know anything about the Recipes concept
        //their job is to save data to files and read it from them, and could be easily reused in any other project
        public List<string> Read(string filePath)
        {
            //in line with the TEMPLATE METHOD Design pattern
            //this method defines a template of Read/Write methods,
            //and the derives will only implement their own logic for TextToStrings/StringsToText
            if (File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                return TextToStrings(fileContents);
            }
            return new List<string>();
        }

        protected abstract List<string> TextToStrings(string fileContents);

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, StringsToText(strings));
        }

        protected abstract string StringsToText(List<string> strings);
    }
}
