using Newtonsoft.Json;
using System.Collections.Generic;

namespace DQuery.CustomQuery
{
    public class ExFunction
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("params")]
        public List<object> Parameters { get; set; }
    }
}
