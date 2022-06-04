﻿using Juce.TweenComponent;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Contents.LoadingScreen.LoadingScreenUi.UseCases.SetVisible
{
    public sealed class SetVisibleUseCase : ISetVisibleUseCase
    {
        private readonly TweenPlayer showTween;
        private readonly TweenPlayer hideTween;

        public SetVisibleUseCase(
            TweenPlayer showTween,
            TweenPlayer hideTween
            )
        {
            this.showTween = showTween;
            this.hideTween = hideTween;
        }

        public Task Execute(bool set, CancellationToken cancellationToken)
        {
            if (set)
            {
                hideTween.Kill();
                return showTween.Play(cancellationToken);
            }

            showTween.Kill();
            return hideTween.Play(cancellationToken);
        }
    }
}
