using System;
using System.Linq;
using Newtonsoft.Json;

namespace eHub.Common.Models
{
    public class Configuration
    {
        public string AppVersionName { get; set; }
        public long AppVersionCode { get; set; }
        public EnvironmentInfo Environment { get; }

        [JsonConstructor]
        public Configuration(EnvironmentInfo[] environments, string env)
        {
            var selectedEnvironment = environments.FirstOrDefault(e => e.Name == env);
            if (selectedEnvironment is null)
                throw new Exception("Environment set does not have a matching group.");

            Environment = selectedEnvironment;
        }
    }

    public class EnvironmentInfo
    {
        public string Name { get; }
        public string ApiBaseRoute { get; }
        public int Port { get; }

        [JsonConstructor]
        public EnvironmentInfo(string name, string apiBaseRoute, int port)
        {
            Name = name;
            ApiBaseRoute = apiBaseRoute;
            Port = port;
        }
    }

}