using System;
using System.IO;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.UI;
using HtmlTags;
using Microsoft.Practices.ServiceLocation;

namespace WebApplication6
{
    public class HomeAction
    {
        private readonly IServiceLocator _serviceLocator;

        public HomeAction(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public HtmlDocument Home()
        {
            var doc = new FubuHtmlDocument(_serviceLocator);
            doc.Add("div").Add("a")
                .Attr("href", "/_content/styles/c7006a7dd72c7f9160a2e2edd8ac9265.css")
                .Attr("target", "_blank")
                .Text("site-styles");
            doc.Add("div").Add("a")
                .Attr("href", "/_content/scripts/c31341d908c2ecf36dccc1f009346361.js")
                .Attr("target", "_blank")
                .Text("site-scripts");
            return doc;
        }

        public FubuContinuation CreateCombinations()
        {
            var doc = new FubuHtmlDocument(_serviceLocator);
            doc.WriteCssTags("site-styles");
            doc.WriteScriptTags("site-scripts");
            return FubuContinuation.RedirectTo<HomeAction>(x => x.Home());
        }

        public FubuContinuation RecycleApp()
        {
            var webconfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "web.config");
            File.SetLastWriteTimeUtc(webconfig, DateTime.UtcNow);
            return FubuContinuation.RedirectTo<HomeAction>(x => x.Home());
        }

    }
}