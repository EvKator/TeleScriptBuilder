using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Teleger
{
    
    class Script
    {
        JProperty username { get; set; }
        JProperty script { get; set; }
        JArray cmdArr { get; set;}
        public Script()
        {
            cmdArr = new JArray();
        }

        public void setUname(string uname)
        {
            username = new JProperty("username", uname);
        }

        public void addCommand(string command, string param)
        {
            JProperty prop = new JProperty(command, param);
            JObject ob = new JObject(prop);
            cmdArr.Add(ob);
        }

        public void addSendMsgBtnCommand(string param)
        {
            this.addCommand("sendmsg", param);
        }

        public void addCallbackBtnCommand(int Row, int Btn)
        {
            JProperty rowJson = new JProperty("Row", Row.ToString());
            JProperty btnJson = new JProperty("Btn", Btn.ToString());
            JObject btnPos = new JObject(rowJson, btnJson);
            JProperty prop = new JProperty("callbackbtn", btnPos);
            JObject ob = new JObject(prop);
            cmdArr.Add(ob);
        }

        public override string ToString()
        {
            string res = "";

            JObject obj = new JObject(username, new JProperty("script", cmdArr));
            res = obj.ToString();
            return res;
        }
    }
}
