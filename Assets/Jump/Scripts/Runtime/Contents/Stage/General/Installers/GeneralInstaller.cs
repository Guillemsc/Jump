﻿using Juce.Core.Di.Builder;
using Template.Contents.Stage.Camera.UseCases.SetupCamera;
using Template.Contents.Stage.General.Data;
using Template.Contents.Stage.General.UseCases.LoadStage;
using Template.Contents.Stage.General.UseCases.StartStage;
using Template.Contents.Stage.Physics.UseCases.SetupPhysicsConfiguration;
using Template.Contents.Stage.Platform.UseCases.TrySpawnNextPlatform;
using Template.Contents.Stage.Player.UseCases.SetInitialPlayerDirection;
using Template.Contents.Stage.Player.UseCases.SpawnPlayer;

namespace Template.Contents.Stage.General.Installers
{
    public static class GeneralInstaller
    {
        public static void InstallGeneral(this IDiContainerBuilder container)
        {
            container.Bind<StageStateData>().FromNew();

            container.Bind<ILoadStageUseCase>()
                .FromFunction(c => new LoadStageUseCase(
                    c.Resolve<StageStateData>(),
                    c.Resolve<ISetupPhysicsConfigurationUseCase>(),
                    c.Resolve<ISpawnPlayerUseCase>(),
                    c.Resolve<ISetInitialPlayerDirectionUseCase>(),
                    c.Resolve<ISetupCameraUseCase>(),
                    c.Resolve<ITrySpawnNextPlatformUseCase>()
                    ));

            container.Bind<IStartStageUseCase>()
                .FromFunction(c => new StartStageUseCase(
                    c.Resolve<StageStateData>()
                    ));
        }
    }
}