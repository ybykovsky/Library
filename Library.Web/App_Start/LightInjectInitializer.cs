[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Library.Web.App_Start.LightInjectInitializer), "Start")]

namespace Library.Web.App_Start
{
    using System.Reflection;

    using LightInject;

    using Library.Domain.Interfaces;
    using Library.Domain.Repositories;
    using Library.Web.Infrastructure;
    using Library.Web.Infrastructure.Interfaces;
    using Library.Domain;
    using Library.Core.Interfaces;
    using Library.Core.Managers;
    using System.Web.Http;

    public static class LightInjectInitializer
    {
        public static void Start()
        {
            var container = new ServiceContainer();
            container.RegisterControllers();
            container.RegisterApiControllers();
            container.EnableMvc();
            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);
            InitializeContainer(container);
        }

        private static void InitializeContainer(ServiceContainer container)
        {
            container.Register<ISiteConfig, SiteConfig>(new PerContainerLifetime());

            // Repository registrations
            container.RegisterInstance<DataBaseContext>(new DataBaseContext());

            container.Register<IBookRepository, BookRepository>(new PerScopeLifetime());
            container.Register<IAuthorRepository, AuthorRepository>(new PerScopeLifetime());
            container.Register<IBookActivityRepository, BookActivityRepository>(new PerScopeLifetime());
            container.Register<IAuthorRepository, AuthorRepository>(new PerScopeLifetime());
            container.Register<IGenreRepository, GenreRepository>(new PerScopeLifetime());

            container.Register<IBookManager, BookManager>(new PerScopeLifetime());
        }
    }
}