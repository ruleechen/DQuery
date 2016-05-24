using Newtonsoft.Json;
using System.Collections.Generic;

namespace DQuery.CustomQuery
{
    public class FunctionEx
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parameters")]
        public List<object> Parameters { get; set; }
    }
}
