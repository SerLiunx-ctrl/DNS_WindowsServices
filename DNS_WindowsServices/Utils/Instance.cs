using DNS_WindowsServices.Files;
using Newtonsoft.Json.Linq;

namespace DNS_WindowsServices.Utils
{
    class Instance
    {
        public bool stats { get; set; }
        public string type { get; set; }
        public string instanceName { get; set; }
        public string domainName { get; set; }
        public string subDomain { get; set; }
        public string token { get; set; }
        public string ipServer { get; set; }
        public string recordId { get; set; }
        public int intervalMain { get; set; }
        public string infoUrl { get; set; }
        public string modifyUrl { get; set; }

        public string ipAddress = "0.0.0.0";
        private System.Timers.Timer timer;
        private int timesCounter = 0;

        public Instance(bool stats,string infoUrl,string modifyUrl,string type,string subDomain, string domainName, string token,string ipServer, string recordId, string instanceName,int intervalMain)
        {
            this.infoUrl = infoUrl;
            this.modifyUrl = modifyUrl;
            this.stats = stats;
            this.type = type;
            this.subDomain = subDomain;
            this.domainName = domainName;
            this.instanceName = instanceName;
            this.token = token;
            this.ipServer = ipServer;
            this.recordId = recordId;
            this.intervalMain = intervalMain;
            Util();
        }

        private void Util()
        {
            if (!this.stats) return;
            timer = new System.Timers.Timer(this.intervalMain * 1000);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string response = Internet.Post(this.token + "&domain=" + this.domainName + "&record_id=" + this.recordId + "&remark=",infoUrl);
           
            if (response.Equals("error"))
            {
                Log.OutLine("["+this.instanceName + "] 实例对应信息获取失败! 无法完成本次验证.");
                return;
            }

            JObject rss = JObject.Parse(response);
            ipAddress = Internet.GetIpaddress(this.ipServer);

            if (ipAddress.Equals("error"))
            {
                Log.OutLine("[" + this.instanceName + "] 本机ip信息获取失败! 无法完成本次验证.");
                return;
            }

            if (ipAddress.Equals(rss["record"]["value"].ToString()))
            {
                Log.OutLine("[" + this.instanceName + "] 无需解析! 等待下一次.");
                return;
            }

            if (!Modfiy())
                Log.OutLine("[" + this.instanceName + "] 解析失败! 未知错误!");

        }

        private bool Modfiy()
        {
            string updateCord;
            updateCord = Internet.Post(this.token + "&domain=" + this.domainName + "&record_id=" + 
                this.recordId + "&sub_domain=" + this.subDomain + "&record_type=" + this.type + "&record_line=默认" +
                "&value=" + this.ipAddress  + "&mx=", this.modifyUrl);
            if (updateCord.Equals("error"))
                return false;
            try
            {
                JObject rss2 = JObject.Parse(updateCord);
                Log.OutLine("[" + this.instanceName + "]" + " ============================================");
                Log.OutLine("[" + this.instanceName + "]" + "请求成功！" + rss2["status"]["message"].ToString());
                Log.OutLine("[" + this.instanceName + "]" + "新的地址：" + rss2["record"]["value"].ToString());
                Log.OutLine("[" + this.instanceName + "]" + " ============================================");
                
                //计数器
                Counter(1);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void Counter(int i)
        {
            timesCounter += i;
        }

        public void Start()
        {
            if (!this.stats) return;
            this.timer.Start();
        }

        public void Stop()
        {
            if (!this.stats) return;
            this.timer.Stop();
        }

        public string GetdomainName()
        {
            return this.domainName;
        }

        public string GetToken()
        {
            return this.token;
        }

        public string GetIpServer()
        {
            return this.ipServer;
        }

        public string GetRecordId()
        {
            return this.recordId;
        }

        public string GetIpAddress()
        {
            return this.ipAddress;
        }

        public int GetInterval()
        {
            return this.intervalMain;
        }

        public int GetTimes()
        {
            return this.timesCounter;
        }
    }
}
