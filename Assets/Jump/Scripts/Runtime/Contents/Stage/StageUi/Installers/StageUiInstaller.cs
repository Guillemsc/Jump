using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.Visibles;
using Juce.TweenComponent;
using JuceUnity.Core.Di.Extensions;
using Template.Contents.Stage.StageUi.Interactor;
using Template.Contents.Stage.StageUi.UseCases.SetPoints;
using Template.Contents.Stage.StageUi.UseCases.SetupInitialValues;
using Template.Contents.Stage.StageUi.ViewStack;
using UnityEngine;

namespace Template.Contents.Stage.StageUi.Installers
{
    public class StageUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Points")]
        [SerializeField] private TweenPlayer setPointsTween = default;

        public void Install(IDiContainerBuilder container)
        {
            container.Bind<StageUiViewStackEntry>()
                .FromFunction(c => new StageUiViewStackEntry(
                    typeof(IStageUiInteractor),
                    gameObject.transform,
                    new TweenPlayerAnimationVisible(
                        showAnimation,
                        hideAnimation
                        ),
                    isPopup: false
                    ))
                .LinkToViewStackService()
                .NonLazy();

            container.Bind<ISetPointsUseCase>()
                .FromFunction(c => new SetPointsUseCase(
                    setPointsTween
                    ));

            container.Bind<ISetupInitialValuesUseCase>()
                .FromFunction(c => new SetupInitialValuesUseCase(
                    c.Resolve<ISetPointsUseCase>()
                    ))
                .WhenInit(o => o.Execute)
                .NonLazy();

            container.Bind<IStageUiInteractor>()
                .FromFunction(c => new StageUiInteractor(
                    c.Resolve<ISetPointsUseCase>()
                    ))
                .NonLazy();
        }
    }
}