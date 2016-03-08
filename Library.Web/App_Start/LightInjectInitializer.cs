[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Library.Web.App_Start.LightInjectInitializer), "Start")]

namespace Library.Web.App_Start
{
    using System.Reflection;

    using LightInject;

    using Library.Domain.Interfaces;
    using Library.Domain.Repositories;
    using Library.Web.Infrastructure;
    using Library.Web.Infrastructure.Interfaces;

    public static class LightInjectInitializer
    {
        public static void Start()
        {
            var container = new ServiceContainer();
            container.RegisterControllers();
            container.EnableMvc();
            InitializeContainer(container);
        }

        private static void InitializeContainer(ServiceContainer container)
        {
            container.Register<ISiteConfig, SiteConfig>(new PerContainerLifetime());

            // Repository registrations

            container.Register<IBookRepository, BookRepository>(new PerScopeLifetime());
            container.Register<IAuthorRepository, AuthorRepository>(new PerScopeLifetime());
            container.Register<IBookActivityRepository, BookActivityRepository>(new PerScopeLifetime());
            container.Register<IAuthorRepository, AuthorRepository>(new PerScopeLifetime());
            container.Register<IGenreRepository, GenreRepository>(new PerScopeLifetime());
        }
    }
}