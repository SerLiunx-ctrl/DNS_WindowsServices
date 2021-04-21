using System;
using System.Xml;

namespace DNS_WindowsServices.Files
{
    class XMLManager
    {
        XmlDocument xmlDoc = new XmlDocument();


        public XMLManager(string path) {
            xmlDoc.Load(path);
        }

        public XmlNodeList GetNodeList(string node)
        {
            return this.xmlDoc.SelectSingleNode(node).ChildNodes;
        }

        public string GetValue(string nodeName,string targetNode)
        {
            XmlNodeList nodes = this.GetNodeList(nodeName);

            foreach (XmlNode xn in nodes)
            {
                XmlElement em = (XmlElement)xn;
                if(em.Name == targetNode)
                    return em.InnerText;
            }

            return "none";
        }
    }
}
