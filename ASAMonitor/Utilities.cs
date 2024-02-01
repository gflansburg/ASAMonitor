using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ASAMonitor
{
    public class Utilities
    {
		public static string GetEmbededWebResource(string name)
		{
			Assembly thisAssembly = Assembly.GetExecutingAssembly();
			string appName = thisAssembly.GetName().Name;
			using (Stream stream = thisAssembly.GetManifestResourceStream(appName + ".Web." + name))
			{
				using (TextReader reader = new StreamReader(stream))
				{
					return reader.ReadToEnd();
				}
			}
		}

        static public string GetEmbededResourcePath
        {
            get
            {
                Assembly thisAssembly = Assembly.GetExecutingAssembly();
                return thisAssembly.GetName().Name + ".Web";
            }
        }

        public static string GetExecutingDirectory()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return WebUtility.UrlDecode(new FileInfo(location.AbsolutePath).Directory.FullName);
        }

        public static List<CurseForge.Datum> GetMods()
        {
            ModLoadTime = DateTime.Now;
            List<CurseForge.Datum> mods = new List<CurseForge.Datum>();
            RestClient client = new RestClient("https://api.curseforge.com/v1");
            int index = 0;
            int count = 0;
            while (true)
            {
                RestRequest request = new RestRequest("mods/search", Method.Get);
                request.AddHeader("x-api-key", ConfigurationSettings.CurseForgeApiKey);
                request.AddParameter("gameId", ConfigurationSettings.CurseForgeID);
                request.AddParameter("index", index);
                Task<RestResponse> response = client.ExecuteAsync(request);
                while (!response.IsCompleted)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
                if (!response.Result.IsSuccessful)
                {
                    break;
                }
                CurseForge.Root root = JsonConvert.DeserializeObject<CurseForge.Root>(response.Result.Content);
                mods.AddRange(root.data);
                index += root.pagination.pageSize;
                count += root.data.Count;
                if (index >= root.pagination.totalCount)
                {
                    break;
                }
            }
            return mods.Where(m => m.isAvailable).ToList();
        }

        public static DateTime ModLoadTime { get; private set; } = DateTime.Now;
        
        public static List<CurseForge.Datum> Mods { get; set; }
    }
}
