using System;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using VueBlog.Database;

namespace VueBlog
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void ConfigureUnity(HttpConfiguration config)
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            config.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<BlogDbContext>();
        }
    }
}