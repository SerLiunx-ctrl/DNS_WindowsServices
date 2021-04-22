using System;
using System.Collections.Generic;
using System.Xml;

namespace DNS_WindowsServices.Files
{
    public class EXml
    {
        public string path { get; set; }

        public string name { get; set; }

        XmlDocument xmldoc;
        XmlElement xmlelem;
        public EXml(string path,string name)
        {
            this.path = path;
            this.name = name;

            xmldoc = new XmlDocument();
        }

        //创建xml文档
        public void CreateXml(string root,string version,string ecoding)
        {
            if (xmldoc.Equals(null))
                return;

            XmlDeclaration xmldecl;

            xmldecl = xmldoc.CreateXmlDeclaration(version, ecoding, null);
            xmldoc.AppendChild(xmldecl);
            xmlelem = xmldoc.CreateElement("", root, "");
            xmldoc.AppendChild(xmlelem);

        }

        public void AddNode(string nodePath,string newNode)
        {
            
        }

        public List<string> SplitNodePath(string nodePath)
        {
            List<string> pathConverted = new List<string>();
            string[] nodePathOr = nodePath.Split('.');

            for (int i = 0;i < nodePathOr.Length;i++)
            {
                pathConverted.Add(nodePathOr[i]);
            }

            return pathConverted;
        }

        public void Save()
        {
            this.xmldoc.Save(this.path + @"\" + this.name);
        }
    }
}
