using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAMonitor
{
    public class ConfigurationSettings
    {
        public static string ASAServerPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ASAServerPath"];
            }
        }

        public static string SteamCmdPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SteamCmdPath"];
            }
        }

        public static string CurseForgeApiKey
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["CurseForgeApiKey"];
            }
        }

        public static string CurseForgeID
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["CurseForgeID"];
            }
        }

        public static int ServerPort
        {
            get
            {
                return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["WebServerPort"]);
            }
        }

        public static bool ThirdPartyEdit
        {
            get
            {
                return Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["ThirdPartyEdit"]);
            }
        }

        public static bool MobileHideThirdParty
        {
            get
            {
                return Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["MobileHideThirdParty"]);
            }
        }

        public static bool AllowServerPasswordAccess
        {
            get
            {
                return Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["AllowServerPasswordAccess"]);
            }
        }

        public static ASAConfig ASAConfig
        {
            get
            {
                ASAConfig config = new ASAConfig();
                string asaconfig = string.Format("{0}\\ASAServer.config", Utilities.GetExecutingDirectory());
                if (System.IO.File.Exists(asaconfig))
                {
                    string xmldata = System.IO.File.ReadAllText(asaconfig);
                    config = (ASAConfig)SerializerHelper.FromXml(xmldata, typeof(ASAConfig));
                }
                else
                {
                    SaveConfig(config);
                }
                return config;
            }
        }

        public static void SaveConfig(ASAConfig config)
        {
            string xmldata = SerializerHelper.ToXml(config);
            string asaconfig = string.Format("{0}\\ASAServer.config", Utilities.GetExecutingDirectory());
            System.IO.File.WriteAllText(asaconfig, xmldata);
        }
    }
}
