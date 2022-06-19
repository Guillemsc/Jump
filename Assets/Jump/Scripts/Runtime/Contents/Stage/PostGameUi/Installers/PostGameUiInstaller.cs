using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Juce.Core.Refresh;
using Juce.CoreUnity.Loading.Services;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.Ui.Buttons;
using Juce.CoreUnity.Ui.ViewStack.Entries;
using Juce.CoreUnity.Ui.ViewStack.Enums;
using Juce.CoreUnity.ViewStack.Services;
using Juce.CoreUnity.Visibles;
using Juce.TweenComponent;
using JuceUnity.Core.Di.Extensions;
using Template.Contents.Services.Persistence.Services;
using Template.Contents.Stage.Points.Data;
using Template.Contents.Stage.PostGameUi.Interactor;
using Template.Contents.Stage.PostGameUi.UseCases.PlayAgain;
using Template.Contents.Stage.PostGameUi.UseCases.PlayPointsAnimation;
using Template.Contents.Stage.PostGameUi.UseCases.Refresh;
using Template.Contents.Stage.PostGameUi.ViewStack;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Template.Contents.Stage.PostGameUi.Installers
{
    public sealed class PostGameUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Play Again")]
        [SerializeField] private ButtonCallbacks playAgainButtonCallbacks = default;

        [Header("Points")]
        [SerializeField] private TweenPlayer setPointsTween = default;
        [SerializeField] private TweenPlayer highScoreTween = default;

        public void Install(IDiContainerBuilder container)
        {
            container.Bind<PostGameUiViewStackEntry>()
                .FromFunction(c => new PostGameUiViewStackEntry(
                    typeof(IPostGameUiInteractor),
                    gameObject.transform,
                    new TweenPlayerAnimationVisible(
                        showAnimation,
                        hideAnimation
                        ),
                    isPopup: false,
                    new ViewStackEntryRefresh(
                        RefreshType.BeforeShow,
                        new CallbackRefreshable(c.Resolve<IRefreshUseCase>().Execute)
                        )
                    ))
                .LinkToViewStackService()
                .NonLazy();

            container.Bind<IRefreshUseCase>()
                .FromFunction(c => new RefreshUseCase(
                    c.Resolve<PointsData>(),
                    c.Resolve<IPersistenceService>(),
                    c.Resolve<IPlayPointsAnimationUseCase>()
                    ));

            container.Bind<IPlayPointsAnimationUseCase>()
                .FromFunction(c => new PlayPointsAnimationUseCase(
                    setPointsTween,
                    highScoreTween
                    ));

            container.Bind<IPlayAgainUseCase>()
                .FromFunction(c => new PlayAgainUseCase(
                    c.Resolve<IUiViewStackService>(),
                    c.Resolve<ILoadingService>()
                    ))
                .WhenInit(o => () => playAgainButtonCallbacks.OnSubmited += (ButtonCallbacks pc, BaseEventData pa) => o.Execute())
                .NonLazy();

            container.Bind<IPostGameUiInteractor>()
                .FromFunction(c => new PostGameUiInteractor(
                    ))
                .NonLazy();
        }
    }
}