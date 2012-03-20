using FubuMVC.Core;

namespace WebApplication6
{
    public class AppRegistry : FubuRegistry
    {
        public AppRegistry()
        {
            IncludeDiagnostics(true);

            Applies.ToAssemblyContainingType<AppRegistry>();

            Assets.CombineAllUniqueAssetRequests();

            Views.TryToAttachWithDefaultConventions();

            Actions.IncludeType<HomeAction>();

            Routes.HomeIs<HomeAction>(x => x.Home());
            Routes.IgnoreControllerNamesEntirely();
            Routes.IgnoreControllerFolderName();

        }
    }
}