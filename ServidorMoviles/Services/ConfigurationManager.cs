using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServidorMoviles.Services
{
    public class ConfigurationManager
    {
        public static ConfigurationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(ConfigurationManager))
                    {
                        if (_instance == null)
                        {
                            _instance = new ConfigurationManager();
                        }
                    }
                }

                return _instance;
            }
        }
        protected ConfigurationManager() { }
        private static volatile ConfigurationManager _instance = null;

        public string HostUrl { get; set; }
    }
}
