using System;
using System.Collections.Generic;
using System.Text;

namespace core.Response
{
    public interface IgeneralResponse
    {
        generalModel response(dynamic data, bool isSuccessful, string message, int statusCode);
    }
    public class generalResponse : IgeneralResponse
    {
        public generalModel response(dynamic data, bool isSuccessful, string message, int statusCode)
        {
            var dataResponse = new generalModel()
            {
                data = data,
                isSuccessful = isSuccessful,
                message = message,
                statusCode = statusCode
            };
            return dataResponse;
        }
    }
}
