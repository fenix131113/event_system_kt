using Menu;
using Menu.View;
using PlayerResources;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class MainInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UiStateMachine>(Lifetime.Singleton);
            builder.Register<UiStatesRegister>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<ResourcesBank>(Lifetime.Singleton);

            builder.RegisterComponentInHierarchy<MainMenuView>();
            builder.RegisterComponentInHierarchy<AddMenuView>();
            builder.RegisterComponentInHierarchy<RemoveMenuView>();
            builder.RegisterComponentInHierarchy<Observables>();
        }
    }
}
