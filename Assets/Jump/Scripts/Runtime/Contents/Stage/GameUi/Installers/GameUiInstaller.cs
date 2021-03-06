using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.Visibles;
using Juce.TweenComponent;
using JuceUnity.Core.Di.Extensions;
using Template.Contents.Stage.GameUi.Interactor;
using Template.Contents.Stage.GameUi.UseCases.SetPoints;
using Template.Contents.Stage.GameUi.UseCases.SetupInitialValues;
using Template.Contents.Stage.GameUi.ViewStack;
using UnityEngine;

namespace Template.Contents.Stage.GameUi.Installers
{
    public sealed class GameUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Points")]
        [SerializeField] private TweenPlayer setPointsTween = default;

        public void Install(IDiContainerBuilder container)
        {
            container.Bind<GameUiViewStackEntry>()
                .FromFunction(c => new GameUiViewStackEntry(
                    typeof(IGameUiInteractor),
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

            container.Bind<IGameUiInteractor>()
                .FromFunction(c => new GameUiInteractor(
                    c.Resolve<ISetPointsUseCase>()
                    ))
                .NonLazy();
        }
    }
}