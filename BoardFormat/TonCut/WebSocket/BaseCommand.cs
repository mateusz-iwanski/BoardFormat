using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TonCut
{
    /// <summary>
    /// Every command has the following properties
    /// </summary>
    public class BaseCommand 
    {
        /// <summary>
        /// When error occurs, is null
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// On success it will be set to true.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// On failure, success will be set to false and errCode will contain an error code.
        /// As you can see you can identify the response by the id.
        /// </summary>
        public ErrorCode? _ErrorCode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public CommandName Name;
        public readonly DateTime FlashTime;
                
        public BaseCommand()
        {
            Random rnd = new Random();
            Id = rnd.Next(0, 1000000);
            FlashTime = DateTime.Now;
        }

        public DateTime GetTime()
        {
            return FlashTime;
        }        

        public void Add(JObject message)
        {
            if (message.ContainsKey("id"))
                Id = (int)message["id"];
            if (message.ContainsKey("success"))
                Success = (bool)message["success"];
            if (message.ContainsKey("errCode"))
            {
                _ErrorCode = (ErrorCode)Enum.Parse(typeof(ErrorCode), message["errCode"].ToString());
                throw new Exception($"WebSocketClient - BaseCommand return Error {_ErrorCode.ToString()}");
            }
        }

    }
}
