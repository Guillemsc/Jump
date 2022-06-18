using Juce.TweenComponent.BindableData;

namespace Template.Contents.Stage.GameUi.Bindings
{
    [BindableData("SetGamePoints", "Jump/Stage/SetGamePoints", "986b0583-35a9-45b2-8a0d-f694509eb155")]
    public sealed class SetGamePointsBinding : IBindableData
    {
        public string PointsString { get; set; }
    }
}
