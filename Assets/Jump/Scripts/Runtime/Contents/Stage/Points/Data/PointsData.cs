using Juce.Core.Observables.Variables;

namespace Template.Contents.Stage.Points.Data
{
    public sealed class PointsData
    {
        public IObservableVariable<int> Points { get; } = new ObservableVariable<int>();
    }
}
