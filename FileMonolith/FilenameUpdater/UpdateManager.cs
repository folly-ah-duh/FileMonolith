using FilenameUpdater.GzsTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilenameUpdater
{
    class UpdateManager
    {
        public void DoUpdates()
        {
            ReadDictionary();
            string exampleinput = "3cb5fc5a6e14d";
            ulong testFileHash = Convert.ToUInt64(exampleinput, 16);
            string testString = "Frick if I know!";
            Hashing.TryGetFileNameFromHash(testFileHash, out testString);
            Console.WriteLine("The testFileHash is: " + testString);
        }
        private static void ReadDictionary()
        {
            string executingAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            const string qarDictionaryName = "qar_dictionary.txt";
            try
            {
                Hashing.ReadDictionary(Path.Combine(executingAssemblyLocation, qarDictionaryName));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading {0}: {1}", qarDictionaryName, e.Message);
            }
        }
    }
}
