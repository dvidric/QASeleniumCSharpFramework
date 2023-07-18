using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace QASeleniumCSharpFramework.Configuration
{
    internal class ConfigurationProvider
    {
        private static ConfigurationManager configuration;

        public static ConfigurationManager Configuration
        { get 
            { 
                if (configuration == null)
                {
                    configuration = new ConfigurationManager();
                    configuration.
                        AddJsonFile("appsettings.local.json", false, false);
                }
                return configuration;
            } 
        }   


    }
}
