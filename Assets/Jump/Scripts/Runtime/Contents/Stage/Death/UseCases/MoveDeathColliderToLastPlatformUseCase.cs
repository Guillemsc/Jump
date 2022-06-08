using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.Extensions;
using Template.Contents.Stage.Platform.Views;
using UnityEngine;

namespace Template.Contents.Stage.Death.UseCases.UseCases
{
    public class MoveDeathColliderToLastPlatformUseCase : IMoveDeathColliderToLastPlatformUseCase
    {
        private readonly Transform deathCollider;
        private readonly float deathColliderOffset;
        private readonly IReadOnlyRepository<IDisposable<PlatformView>> platformsRepository;

        public MoveDeathColliderToLastPlatformUseCase(
            Transform deathCollider,
            float deathColliderOffset,
            IReadOnlyRepository<IDisposable<PlatformView>> platformsRepository
            )
        {
            this.deathCollider = deathCollider;
            this.deathColliderOffset = deathColliderOffset;
            this.platformsRepository = platformsRepository;
        }

        public void Execute()
        {
            if(platformsRepository.Items.Count < 2)
            {
                return;
            }

            IDisposable<PlatformView> lastPlatformView = platformsRepository.Items[platformsRepository.Items.Count - 2];

            float finalPosition = lastPlatformView.Value.transform.position.y - deathColliderOffset;

            deathCollider.transform.SetPositionY(finalPosition);
        }
    }
}
