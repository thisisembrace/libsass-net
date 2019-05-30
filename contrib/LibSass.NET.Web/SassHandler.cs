using System;
using System.IO;
using System.Web;
using LibSass.Compiler;
using LibSass.Compiler.Options;

namespace LibSass.Web
{
    public class SassHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string path = context.Server.MapPath(context.Request.AppRelativeCurrentExecutionFilePath);
            var file = new FileInfo(path);
            SassCompiler compiler = new SassCompiler(new SassOptions { InputPath = path });
            SassResult result = compiler.Compile();

            context.Response.ContentType = "text/css";
            context.Response.Write(result.Output);

        }

        public bool IsReusable { get { return true; } }
    }
}
