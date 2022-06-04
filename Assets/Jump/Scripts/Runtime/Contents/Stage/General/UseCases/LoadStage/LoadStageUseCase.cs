using Template.Contents.Shared.Logging;
using Template.Contents.Stage.Camera.UseCases.SetupCamera;
using Template.Contents.Stage.General.Data;
using Template.Contents.Stage.Physics.UseCases.SetupPhysicsConfiguration;
using Template.Contents.Stage.Platform.UseCases.TrySpawnNextPlatform;
using Template.Contents.Stage.Player.UseCases.SetInitialPlayerDirection;
using Template.Contents.Stage.Player.UseCases.SpawnPlayer;

namespace Template.Contents.Stage.General.UseCases.LoadStage
{
    public sealed class LoadStageUseCase : ILoadStageUseCase
    {
        private readonly StageStateData stageStateData;
        private readonly ISetupPhysicsConfigurationUseCase setupPhysicsConfigurationUseCase;
        private readonly ISpawnPlayerUseCase spawnPlayerUseCase;
        private readonly ISetInitialPlayerDirectionUseCase setInitialPlayerDirectionUseCase;
        private readonly ISetupCameraUseCase setupCameraUseCase;
        private readonly ITrySpawnNextPlatformUseCase trySpawnNextPlatformUseCase;

        public LoadStageUseCase(
            StageStateData stageStateData,
            ISetupPhysicsConfigurationUseCase setupPhysicsConfigurationUseCase,
            ISpawnPlayerUseCase spawnPlayerUseCase,
            ISetInitialPlayerDirectionUseCase setInitialPlayerDirectionUseCase,
            ISetupCameraUseCase setupCameraUseCase,
            ITrySpawnNextPlatformUseCase trySpawnNextPlatformUseCase
            )
        {
            this.stageStateData = stageStateData;
            this.setupPhysicsConfigurationUseCase = setupPhysicsConfigurationUseCase;
            this.spawnPlayerUseCase = spawnPlayerUseCase;
            this.setInitialPlayerDirectionUseCase = setInitialPlayerDirectionUseCase;
            this.setupCameraUseCase = setupCameraUseCase;
            this.trySpawnNextPlatformUseCase = trySpawnNextPlatformUseCase;
        }

        public void Execute()
        {
            if(stageStateData.Loaded)
            {
                SharedLoggers.StageLogger.Log("Trying to load stage but stage was already loaded");
                return;
            }

            SharedLoggers.StageLogger.Log("Loading stage");

            stageStateData.Loaded = true;

            setupPhysicsConfigurationUseCase.Execute();
            spawnPlayerUseCase.Execute();
            setInitialPlayerDirectionUseCase.Execute();
            setupCameraUseCase.Execute();
            trySpawnNextPlatformUseCase.Execute();
        }
    }
}
