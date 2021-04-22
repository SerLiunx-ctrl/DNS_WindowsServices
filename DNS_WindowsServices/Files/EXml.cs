using System;
using System.Xml;

namespace DNS_WindowsServices.Files
{
    class EXml
    {
        public string path { get; set; }

        public string name { get; set; }

        XmlDocument xmldoc;

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
            XmlElement xmlelem;

            xmldecl = xmldoc.CreateXmlDeclaration(version, ecoding, null);
            xmldoc.AppendChild(xmldecl);
            xmlelem = xmldoc.CreateElement("", root, "");
            xmldoc.AppendChild(xmlelem);
        }
    }
}
