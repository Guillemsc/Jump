using Template.Contents.Stage.StageUi.UseCases.SetPoints;

namespace Template.Contents.Stage.StageUi.UseCases.SetupInitialValues
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
