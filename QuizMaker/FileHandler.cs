using System.Xml.Serialization;

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
        public static void WriteToFile<T>(string path, XmlSerializer xmlSerializer, List<T> resource)
        {
            if (!File.Exists(path))
                CreateFile(path);
           
            using (StreamWriter sw = new StreamWriter(path))
            {
                xmlSerializer.Serialize(sw, resource);
            }
        }
        /// <summary>
        /// Creates the file on the desired path
        /// </summary>
        /// <param name="path">path contains the absolute path including the filename</param>
        private static void CreateFile(string path)
        {
            var f = File.Create(path);
            f.Close();
        }
        /// <summary>
        /// GetStreamFromFile will run FileExists function in order to check if the file the system wants to read from is available.
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
        public static StreamReader GetStreamFromFile(string path)
        {            
            if (File.Exists(path))
            {
                return new StreamReader(path);       
            }
            return null;       
        }

        public static void CloseStream(StreamReader sr)
        {
            sr.Close();
        }
        /// <summary>
        /// Checks if File exists for a given path
        /// 
        /// </summary>
        /// <param name="path">path contains the absolute path including the filename</param>
        /// <returns>
        /// true or false</returns>

    }
}
