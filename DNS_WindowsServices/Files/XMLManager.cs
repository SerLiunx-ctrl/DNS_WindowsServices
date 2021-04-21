using System;
using System.Xml;

namespace DNS_WindowsServices.Files
{
    class XMLManager
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList nodeList;


        public XMLManager(string path) {
            xmlDoc.Load(path);
        }

        private XmlNodeList GetNodeList(string node)
        {
            return this.xmlDoc.SelectSingleNode(node).ChildNodes;
        }
    }
}
