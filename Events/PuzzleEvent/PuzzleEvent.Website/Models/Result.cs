using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PuzzleEvent.Website.Enums;
using ObjectUtil.Common;

namespace PuzzleEvent.Website.Models
{
    public class Result
    {

        public Result()
        {}

        public Result(int code, string message,object data)
        {
            this.code = code;
            this.message = message;
        
        }

        public Result(ErrorCode errorcode, object data)
            : this((int)errorcode, errorcode.ToDescription(), data)
        { }

        public int code { get; set; }
        public string message {get;set;}

        public object data { get; set; }
    }
}