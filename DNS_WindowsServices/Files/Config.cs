using System.IO;

namespace DNS_WindowsServices.Files
{
    public class Config
    {
        private const string versionNow = "0.0.1";

        private const string ConfigFileLocation = @"C:\DDNS_WindowsService\Config.xml";

        public Config()
        {
            if (!File.Exists(ConfigFileLocation))
                CreateConfig();
        }

        private void CreateConfig()
        {
            //
        }
    }
}
