using Template.Contents.Stage.GameUi.UseCases.SetPoints;

namespace Template.Contents.Stage.GameUi.UseCases.SetupInitialValues
{
    public sealed class SetupInitialValuesUseCase : ISetupInitialValuesUseCase
    {
        private readonly ISetPointsUseCase setPointsUseCase;

        public SetupInitialValuesUseCase(
            ISetPointsUseCase setPointsUseCase
            )
        {
            this.setPointsUseCase = setPointsUseCase;
        }

        public void Execute()
        {
            setPointsUseCase.Execute(0);
        }
    }
}
