using DNS_WindowsServices.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace DNS_WindowsServices.Files
{
    class InstanceFiles
    {
        private const string InstancesFileLocation = @"C:\DDNS_WindowsService\instances.json";
        private List<Instance> instances = new List<Instance>();

        public InstanceFiles()
        {
            if (!File.Exists(InstancesFileLocation))
                SaveToFile();
        }

        public void LoadFromFiles()
        {
            JArray config;
            try
            {
                StreamReader sw = new StreamReader(InstancesFileLocation);
                var response = sw.ReadToEnd();
                config = JArray.Parse(response);
                sw.Close(); 
            }
            catch
            {
                Log.OutLine("实例载入失败!请检查你的配置文件是否有误");
                return;
            }

            for (int i = 0;true;i++)
            {
                try
                {
                    string statsS = config[i]["stats"].ToString();
                    bool statsB = statsS == "true" ? true : false;
                    instances.Add(new Instance(statsB,config[i]["infoUrl"].ToString(), config[i]["modifyUrl"].ToString(), config[i]["type"].ToString(),config[i]["subDomain"].ToString(),config[i]["domainName"].ToString()
                        , config[i]["token"].ToString(), config[i]["ipServer"].ToString(),config[i]["recordId"].ToString(), config[i]["instanceName"].ToString(), Convert.ToInt32(config[i]["intervalMain"])));
                    Log.OutLine("成功载入实例: " + config[i]["instanceName"].ToString() + (statsB ? "(已启用)":"(未启用)"));
                }
                catch
                {
                   if(i == 0)
                        Log.OutLine("没有载入任何实例..");
                   else
                        Log.OutLine("成功载入了 " + i + " 个实例!");
                   break;
                }

            }
        }

        private void SaveToFile()
        {
            try
            {
                instances.Add(new Instance(false,"获取信息的地址","修改地址","这里是记录类型","子域名","目标域名","token填这里","获取ip的服务器地址","记录的id填这里","这是一个例子",60));
                string args = JsonConvert.SerializeObject(instances);
                JArray tar = JArray.Parse(args);

                Directory.CreateDirectory(Path.GetDirectoryName(InstancesFileLocation));
                File.AppendAllText(InstancesFileLocation,tar.ToString());
            }
            catch(Exception e)
            {
                Log.Out(e.ToString());
            }
        }

        public List<Instance> GetInstances()
        {
            return instances;
        }
    }
}
