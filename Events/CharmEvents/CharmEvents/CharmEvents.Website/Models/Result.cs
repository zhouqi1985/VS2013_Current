using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharmEvents.Website.Enums;
using ObjectUtil.Common;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CharmEvents.Website.Models
{
    public class Result : PageControllerBase.BaseController
    {

        public Result()
        { }

        public Result(int code, string message, object data)
        {
            this.code = code;
            this.message = message;

        }

        public Result(ErrorCode errorcode, object data)
            : this((int)errorcode, errorcode.ToDescription(), data)
        { }

        public int code { get; set; }
        public string message { get; set; }

        public string jsonp
        {
            get
            {
                return Request.QueryString["jsonpcallback"];
            }
            set { jsonp = value; }
        }

        public object data { get; set; }

        public ContentResult Jsonp(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            string result = jsonp + "(" + json + ")";
            return Content(result, "Jsonp", Encoding.UTF8);
        }

        public ContentResult Jsonp(int code, string message, object data)
        {
            var obj = new { Code = code, Message = message, Data = data };
            return Jsonp(obj);
        }

        public ContentResult Jsonp(ErrorCode errorcode, object data)
        {
            var obj = new { Code = (int)errorcode, Message = errorcode.ToDescription(), Data = data };
            return Jsonp(obj);
        }

    }
}