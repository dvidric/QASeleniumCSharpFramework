using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumCSharpFramework.utilities
{
    public class jsonReader
    {
        public jsonReader()
        {
        }

        public string extractData(string token) 
        {
            string jsonString = File.ReadAllText("utilities\\testData.json");
            var jsonObject = JToken.Parse(jsonString);
            return jsonObject.SelectToken(token).Value<string>();
        }

        public string[] extractDataArray(string token)
        {
            string jsonString = File.ReadAllText("utilities\\testData.json");
            var jsonObject = JToken.Parse(jsonString);
            List<String> products = jsonObject.SelectTokens(token).Values<string>().ToList();
            return products.ToArray();
        }


    }
}
