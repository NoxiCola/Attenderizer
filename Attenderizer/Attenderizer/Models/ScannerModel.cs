using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attenderizer.Models
{
    public class ScannerModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("qrCode")]
        public string QRCode { get; set; }
    }
}
