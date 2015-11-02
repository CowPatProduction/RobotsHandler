﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotsHandler.Handlers
{
    public class RobotsHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            var content = string.Empty;
            var response = context.Response;

            try
            {
                response.ContentType = "text/plain";
                response.Clear();
                response.BufferOutput = true;

                int mandatorNumber = 1;
                var robot = GetRobotData(mandatorNumber);

                content = robot.Aggregate(content, (current, item) => current + (item.Line + Environment.NewLine));
            }
            catch
            {
                content = "An error occured.";
            }

            response.Write(content);
        }

        internal IList<RobotData> GetRobotData(int mandatorNumber)
        {
            return new List<RobotData>
            {
                new RobotData { Line = "# robots.txt for http://cpp.cloudapp.net/" },
                new RobotData { Line = "User-agent: *" },
                new RobotData { Line = "Disallow: /*.js$" },
                new RobotData { Line = "Disallow: /*.css$" },
                new RobotData { Line = "Disallow: /private/" },
                new RobotData { Line = "Sitemap: http://cpp.cloudapp.net/sitemap.xml" }
            };
        }
    }

    public class RobotData
    {
        public string Line { get; set; }
    }
}