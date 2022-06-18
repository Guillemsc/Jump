using Template.Contents.Stage.GameUi.UseCases.SetPoints;

namespace Template.Contents.Stage.GameUi.Interactor
{
    public sealed class GameUiInteractor : IGameUiInteractor
    {
        private readonly ISetPointsUseCase setPointsUseCase;

        public GameUiInteractor(
            ISetPointsUseCase setPointsUseCase
            )
        {
            this.setPointsUseCase = setPointsUseCase;
        }

        public void SetPoints(int points)
        {
            setPointsUseCase.Execute(points);
        }
    }
}
