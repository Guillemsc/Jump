using Juce.TweenComponent;
using Template.Contents.Stage.StageUi.Bindings;

namespace Template.Contents.Stage.StageUi.UseCases.SetPoints
{
    public sealed class SetPointsUseCase : ISetPointsUseCase
    {
        private readonly TweenPlayer setPointsTween;

        public SetPointsUseCase(
            TweenPlayer setPointsTween
            )
        {
            this.setPointsTween = setPointsTween;
        }

        public void Execute(int points)
        {
            SetPointsBinding setPointsBinding = new SetPointsBinding
            {
                PointsString = points.ToString()
            };

            setPointsTween.Play(setPointsBinding);
        }
    }
}
