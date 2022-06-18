using Juce.TweenComponent.BindableData;

namespace Template.Contents.Stage.PostGameUi.Bindings
{
    [BindableData("SetPostGamePointsBinding", "Jump/Stage/SetPostGamePointsBinding", "986b0583-35a9-45b2-8a0d-f694509eb156")]
    public sealed class SetPostGamePointsBinding : IBindableData
    {
        public int PointsInt { get; set; }
    }
}
