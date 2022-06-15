using Juce.TweenComponent.BindableData;

namespace Template.Contents.Stage.StageUi.Bindings
{
    [BindableData("SetPoints", "Jump/Stage/SetPoints", "986b0583-35a9-45b2-8a0d-f694509eb155")]
    public sealed class SetPointsBinding : IBindableData
    {
        public string PointsString { get; set; }
    }
}
