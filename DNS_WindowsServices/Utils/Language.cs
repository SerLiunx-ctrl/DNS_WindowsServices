using System;
using System.Collections.Generic;
using System.Text;

namespace DNS_WindowsServices.Utils
{
    public class Language
    {
        public Dictionary<string, string> langs = new Dictionary<string, string>();
        public Dictionary<string, string> defaultins = new Dictionary<string, string>();
        private string FileLocation = @"C:\DDNS_WindowsService\lang.xml";

        public Language()
        {
            
        }

        public Dictionary<string, string> GetDefaultLanguage()
        {
            langs.Add("", "");
            langs.Add("", "");
            langs.Add("", "");

            return null;
        }
    }
}
