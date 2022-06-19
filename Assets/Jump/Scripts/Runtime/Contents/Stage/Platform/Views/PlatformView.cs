using Juce.TweenComponent;
using UnityEngine;

namespace Template.Contents.Stage.Platform.Views
{
    public sealed class PlatformView : MonoBehaviour
    {
        [SerializeField] private TweenPlayer appearTween = default;
        [SerializeField] private TweenPlayer disappearTween = default;
        [SerializeField] private TweenPlayer activateTween = default;

        public TweenPlayer AppearTween => appearTween;
        public TweenPlayer DisappearTween => disappearTween;
        public TweenPlayer ActivateTween => activateTween;

        public int PlatformIndex { get; private set; }

        public void Init(int platformIndex)
        {
            PlatformIndex = platformIndex;
        }
    }
}
