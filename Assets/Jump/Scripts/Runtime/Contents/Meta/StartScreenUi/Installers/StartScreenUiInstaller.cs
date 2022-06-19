using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.Ui.Buttons;
using Juce.CoreUnity.ViewStack.Services;
using Juce.CoreUnity.Visibles;
using JuceUnity.Core.Di.Extensions;
using Template.Contents.Meta.StartScreenUi.Interactor;
using Template.Contents.Meta.StartScreenUi.UseCases.PlayAgain;
using Template.Contents.Meta.StartScreenUi.ViewStack;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Template.Contents.Meta.StartScreenUi.Installers
{
    public class StartScreenUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Play")]
        [SerializeField] private ButtonCallbacks playButtonCallbacks = default;

        public void Install(IDiContainerBuilder container)
        {
            container.Bind<StartScreenUiViewStackEntry>()
                .FromFunction(c => new StartScreenUiViewStackEntry(
                    typeof(IStartScreenUiInteractor),
                    gameObject.transform,
                    new TweenPlayerAnimationVisible(
                        showAnimation,
                        hideAnimation
                        ),
                    isPopup: false
                    ))
                .LinkToViewStackService()
                .NonLazy();

            container.Bind<IPlayUseCase>()
               .FromFunction(c => new PlayUseCase(
                   c.Resolve<IUiViewStackService>()
                   ))
               .WhenInit(o => () => playButtonCallbacks.OnSubmited += (ButtonCallbacks pc, BaseEventData pa) => o.Execute())
               .NonLazy();

            container.Bind<IStartScreenUiInteractor>()
                .FromFunction(c => new StartScreenUiInteractor())
                .NonLazy();
        }
    }
}