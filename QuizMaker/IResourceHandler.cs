using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal interface IResourceHandler
    {
        List<object> Resources { get; set; }
        XmlSerializer XmlSerialzer { get; set; }
        public void UpdateResource(object resource);
        public void DeleteResource(int id);
        public List<T> GetAllResources<T>(int id);
        public void AddResource<T>(T resource);
        public T GetResource<T>(int id);
        public void AddResourceInBulk<T>(string path);
    }
}
