﻿using System.Diagnostics;
using System.Xml.Serialization;

namespace QuizMaker
{
    /// <summary>
    /// FileHandler serves as a handler for reading and writing data from or to files
    /// </summary>
    public static class FileHandler
    {
        /// <summary>
        /// WriteToFile will take 3 params to write data as xml to a file. it first checks if the file exists if not it creates it.
        /// then opens or initializes an instance of StreamWriter which is necessary to write data to a file
        /// we then serialize the data using xmlserializer framework and we pass the streamwrite and resources with T (T being the model)
        /// </summary>
        /// <param name="path">path contains the absolute path including the filename</param>
        /// <param name="content">string that contains a xml pre serialized</param>
        public static void WriteToFile<T>(string path, XmlSerializer xmlSerializer, List<T> resource)
        {
            if (!File.Exists(path))
                CreateXMLTypeFile(path);
           
            using (StreamWriter sw = new StreamWriter(path))
            {
                xmlSerializer.Serialize(sw, resource);
            }
        }
        /// <summary>
        /// Creates the file on the desired path
        /// </summary>
        /// <param name="path">path contains the absolute path including the filename</param>
        private static void CreateXMLTypeFile(string path)
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
            if (!File.Exists(path))            
                CreateXMLTypeFile(path);
            
            return new StreamReader(path);
        }

        public static void CloseStream(StreamReader sr)
        {
            sr.Close();
        }
    }
}
