using Juce.Cheats.Core;
using Juce.Cheats.WidgetsInteractors;
using Juce.Core.Repositories;
using Template.Contents.Stage.Cheats.UseCases.RestartStage;

namespace Template.Contents.Stage.Cheats.UseCases.AddCheats
{
    public sealed class AddCheatsUseCase : IAddCheatsUseCase
    {
        private readonly IRepository<IWidgetInteractor> cheatsRepository;
        private readonly IRestartStageUseCase restartStageUseCase;

        public AddCheatsUseCase(
            IRepository<IWidgetInteractor> cheatsRepository,
            IRestartStageUseCase restartStageUseCase
            )
        {
            this.cheatsRepository = cheatsRepository;
            this.restartStageUseCase = restartStageUseCase;
        }

        public void Execute()
        {
            IWidgetInteractor metaCheats = JuceCheats.AddAction("Stage Cheats", () => UnityEngine.Debug.Log("Stage Cheats"));
            cheatsRepository.Add(metaCheats);

            IWidgetInteractor restartStage = JuceCheats.AddAction("Restart Stage", restartStageUseCase.Execute);
            cheatsRepository.Add(restartStage);
        }
    }
}
