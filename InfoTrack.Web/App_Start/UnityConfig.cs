using InfoTrack.Contracts;
using InfoTrack.Core;
using InfoTrack.Core.ResultsFetchers;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace InfoTrack.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IResultsFetcher, ResultsFetcher>(new InjectionConstructor(@"https://www.google.com.au/search?num=100&q="));
            //container.RegisterType<IResultsFetcher, MockResultsFetcher>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}