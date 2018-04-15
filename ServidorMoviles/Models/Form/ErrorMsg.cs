using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ServidorMoviles.Models.Form
{
    public class ErrorMsg
    {
        public string Msg { get; }

        [EnumDataType(typeof(ErrorCodesEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ErrorCodesEnum ErrorCode { get; }

        public ErrorMsg(string msg, ErrorCodesEnum code)
        {
            this.Msg = msg;
            this.ErrorCode = code;
        }
    }

    public enum ErrorCodesEnum
    {
        NotFound, BadRequest, NameConflict
    }
}
