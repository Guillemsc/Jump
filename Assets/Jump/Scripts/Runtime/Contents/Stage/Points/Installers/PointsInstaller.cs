using Juce.Core.Di.Builder;
using Template.Contents.Stage.Points.Data;
using Template.Contents.Stage.StageUi.Interactor;

namespace Template.Contents.Stage.Points.Installers
{
    public static class PointsInstaller
    {
        public static void InstallPoints(this IDiContainerBuilder container)
        {
            container.Bind<PointsData>().FromNew()
                .WhenInit((c, o) => o.Points.OnChange += c.Resolve<IStageUiInteractor>().SetPoints);
        }
    }
}
