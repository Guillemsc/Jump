using Juce.Core.Di.Builder;
using Template.Contents.Services.Configuration.Service;
using Template.Contents.Stage.Physics.UseCases.SetupPhysicsConfiguration;

namespace Template.Contents.Stage.Physics.Installers
{
    public static class PhysicsInstaller
    {
        public static void InstallPhysics(this IDiContainerBuilder container)
        {
            container.Bind<ISetupPhysicsConfigurationUseCase>()
                .FromFunction(c => new SetupPhysicsConfigurationUseCase(
                    c.Resolve<IConfigurationService>().GameConfiguration.PhysicsGravity
                    ));
        }
    }
}
