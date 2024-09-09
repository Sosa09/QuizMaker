using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    /// <summary>
    /// FileHandler serves as a handler for reading and writing data from or to files
    /// </summary>
    public static class FileHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">path contains the absolute path including the filename</param>
        /// <param name="content">string that contains a xml pre serialized</param>
        public static void WriteToFile(string path, string content)
        {
            if (!FileExists(path))
                CreateFile(path);
         
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(content);
            }
        }
        /// <summary>
        /// Creates the file on the desired path
        /// </summary>
        /// <param name="path">path contains the absolute path including the filename</param>
        private static void CreateFile(string path)
        {
            File.Create(path);
        }

        /// <summary>
        /// ReadFromFile will run FileExists function in order to check if the file the system wants to read from is available.
        /// if not it will return an empty string
        /// </summary>
        /// <param name="path">path contains the absolute path including the filename</param>
        /// <returns>
        ///     XML Content
        ///     <quiz>
        ///         <questions>
        ///             <question> 
        ///                 <text> What is the most popular song ? </text>
        ///             <choices>
        ///                 <choice>Merry Christmas</choice>
        ///                 <choice>Merry Christmas</choice>
        ///                 <choice>Merry Christmas</choice>
        ///             </choices>
        ///             </question>
        ///         </questions>
        ///     </quiz>
        /// </returns>
        public static string ReadFromFile(string path)
        {
            if (!FileExists(path))
                return "";
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
        /// <summary>
        /// Checks if File exists for a given path
        /// 
        /// </summary>
        /// <param name="path">path contains the absolute path including the filename</param>
        /// <returns>
        /// true or false</returns>
        private static bool FileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
