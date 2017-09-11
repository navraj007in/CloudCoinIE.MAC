using Newtonsoft.Json;
using CloudCoinCore;

namespace CloudCoinCore
{
    public class Stack
    {
        [JsonProperty("cloudcoin")]
        public CloudCoin[] cc { get; set; }
    }
}
