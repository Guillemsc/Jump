using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Shared.Logging;
using Template.Contents.Stage.General.Data;
using Template.Contents.Stage.GameUi.Interactor;
using Template.Contents.Stage.Player.UseCases.SetPlayerMovementEnabled;

namespace Template.Contents.Stage.General.UseCases.StartStage
{
    public sealed class StartStageUseCase : IStartStageUseCase
    {
        private readonly StageStateData stageStateData;
        private readonly IUiViewStackService viewStackService;
        private readonly ISetPlayerMovementEnabledUseCase setPlayerMovementEnabledUseCase;

        public StartStageUseCase(
            StageStateData stageStateData,
            IUiViewStackService viewStackService,
            ISetPlayerMovementEnabledUseCase setPlayerMovementEnabledUseCase
            )
        {
            this.stageStateData = stageStateData;
            this.viewStackService = viewStackService;
            this.setPlayerMovementEnabledUseCase = setPlayerMovementEnabledUseCase;
        }

        public void Execute()
        {
            if (stageStateData.Started)
            {
                SharedLoggers.StageLogger.Log("Trying to start stage but stage was already started");
                return;
            }

            SharedLoggers.StageLogger.Log("Starting stage");

            stageStateData.Started = true;

            setPlayerMovementEnabledUseCase.Execute(true);

            viewStackService.New()
                .Show<IGameUiInteractor>(instantly: false)
                .Execute();
        }
    }
}
