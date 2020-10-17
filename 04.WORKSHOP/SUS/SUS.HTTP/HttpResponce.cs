﻿using System;
using System.Collections.Generic;
using System.Text;
namespace SUS.HTTP
{
    public class HttpResponce
    {
        public HttpResponce(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            if (body == null)
            {
                throw new ArgumentException(nameof(body));
            }
            this.StatusCode = statusCode;
            this.Body = body;
            this.Headers = new List<Header>
            {
                {new Header("Content-Type", contentType) },
                {new Header("Content-Length", body.Length.ToString())},
            };
        }
        public override string ToString()
        {
            StringBuilder responceBuilder = new StringBuilder();
            responceBuilder.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}" + HttpConstants.NewLine);
            foreach (var header in Headers)
            {
                responceBuilder.Append(header.ToString() + HttpConstants.NewLine);
            }

            responceBuilder.Append(HttpConstants.NewLine);

            return responceBuilder.ToString();
        }
        public HttpStatusCode StatusCode { get; set; }
        public ICollection<Header> Headers { get; set; }
        public ICollection<Cookie> Cookies { get; set; }
        public byte[] Body { get; set; }
    }
}
