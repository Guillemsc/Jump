using Juce.Core.Di.Builder;
using Template.Contents.Stage.Visuals.UseCases.SimulateParticles;
using Template.Contexts.Stage;

namespace Template.Contents.Stage.Visuals.Installers
{
    public static class VisualsInstaller
    {
        public static void InstallVisuals(this IDiContainerBuilder container)
        {
            container.Bind<ISimulateParticlesUseCase>()
                .FromFunction(c => new SimulateParticlesUseCase(
                     c.Resolve<StageContextInstance>().ParticlesToSimulate
                    ));
        }
    }
}
