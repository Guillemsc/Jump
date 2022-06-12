using Juce.Cheats.WidgetsInteractors;
using Juce.Core.Di.Builder;
using Juce.Core.Repositories;
using Juce.CoreUnity.Loading.Services;
using Template.Contents.Stage.Cheats.UseCases.AddCheats;
using Template.Contents.Stage.Cheats.UseCases.RemoveCheats;
using Template.Contents.Stage.Cheats.UseCases.RestartStage;

namespace Template.Contents.Stage.Cheats.Installers
{
    public static class CheatsInstaller
    {
        public static void InstallCheats(this IDiContainerBuilder container)
        {
            container.Bind<IRepository<IWidgetInteractor>>()
                .FromInstance(new SimpleRepository<IWidgetInteractor>());

            container.Bind<IAddCheatsUseCase>()
                .FromFunction(c => new AddCheatsUseCase(
                    c.Resolve<IRepository<IWidgetInteractor>>(),
                    c.Resolve<IRestartStageUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<IRemoveCheatsUseCase>()
                .FromFunction(c => new RemoveCheatsUseCase(
                    c.Resolve<IRepository<IWidgetInteractor>>()
                    ))
                .WhenDispose(o => o.Execute())
                .NonLazy();

            container.Bind<IRestartStageUseCase>()
                .FromFunction(c => new RestartStageUseCase(
                    c.Resolve<ILoadingService>()
                    ));
        }
    }
}
