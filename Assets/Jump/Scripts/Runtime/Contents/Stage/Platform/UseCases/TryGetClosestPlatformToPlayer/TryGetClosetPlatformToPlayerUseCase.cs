using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Template.Contents.Stage.Platform.Views;
using Template.Contents.Stage.Player.Views;
using UnityEngine;

namespace Template.Contents.Stage.Platform.UseCases.TryGetClosetPlatformToPlayer
{
    public class TryGetClosetPlatformToPlayerUseCase : ITryGetClosetPlatformToPlayerUseCase
    {
        private readonly IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository;
        private readonly IReadOnlyRepository<IDisposable<PlatformView>> platformsRepository;

        public TryGetClosetPlatformToPlayerUseCase(
            IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository,
            IReadOnlyRepository<IDisposable<PlatformView>> platformsRepository
            )
        {
            this.playerRepository = playerRepository;
            this.platformsRepository = platformsRepository;
        }

        public bool Execute(out PlatformView platformView)
        {
            bool playerFound = playerRepository.TryGet(out IDisposable<PlayerView> playerView);

            if (!playerFound)
            {
                platformView = default;
                return false;
            }

            if (platformsRepository.Items.Count == 0)
            {
                platformView = default;
                return false;
            }

            PlatformView closestPlatform = platformsRepository.Items[0].Value;
            float closestDistance = float.MaxValue;

            foreach (IDisposable<PlatformView> platform in platformsRepository.Items)
            {
                float distanceToPlayer = Mathf.Abs(Vector3.Distance(
                    platform.Value.transform.position, 
                    playerView.Value.transform.position
                    ));

                if(distanceToPlayer > closestDistance)
                {
                    continue;
                }

                closestDistance = distanceToPlayer;
                closestPlatform = platform.Value;
            }

            platformView = closestPlatform;
            return true;
        }
    }
}
