using System.Web;

namespace RobotsHandler.Handlers
{
    public class RobotsHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            string content;
            var response = context.Response;

            try
            {
                response.ContentType = "text/plain";
                response.Clear();
                response.BufferOutput = true;
                content = "# robots.txt for http://www.example.at";
            }
            catch
            {
                content = "An error occured.";
            }

            response.Write(content);
        }
    }
}