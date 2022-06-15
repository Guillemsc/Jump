using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Shared.Logging;
using Template.Contents.Stage.General.Data;
using Template.Contents.Stage.StageUi.Interactor;

namespace Template.Contents.Stage.General.UseCases.StartStage
{
    public sealed class StartStageUseCase : IStartStageUseCase
    {
        private readonly StageStateData stageStateData;
        private readonly IUiViewStackService viewStackService;

        public StartStageUseCase(
            StageStateData stageStateData,
            IUiViewStackService viewStackService
            )
        {
            this.stageStateData = stageStateData;
            this.viewStackService = viewStackService;
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

            viewStackService.New()
                .Show<IStageUiInteractor>(instantly: false)
                .Execute();
        }
    }
}
