using System;
using System.Collections.Generic;
using System.Text;

namespace core.Response
{
    public interface IgeneralModel
    {
       dynamic data { get; set; }
       bool isSuccessful { get; set; }
       string message { get; set; }
       int statusCode { get; set; }
    }
   public class generalModel: IgeneralModel
    {
        public dynamic data { get; set; }
        public bool isSuccessful { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }
}
