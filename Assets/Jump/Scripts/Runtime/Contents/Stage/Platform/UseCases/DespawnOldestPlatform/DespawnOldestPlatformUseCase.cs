using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Template.Contents.Stage.Platform.UseCases.DespawnPlatform;
using Template.Contents.Stage.Platform.Views;

namespace Template.Contents.Stage.Platform.UseCases.DespawnOldestPlatform
{
    public class DespawnOldestPlatformUseCase : IDespawnOldestPlatformUseCase
    {
        private readonly IRepository<IDisposable<PlatformView>> platformsRepository;
        private readonly IDespawnPlatformUseCase despawnPlatformUseCase;

        public DespawnOldestPlatformUseCase(
            IRepository<IDisposable<PlatformView>> platformsRepository,
            IDespawnPlatformUseCase despawnPlatformUseCase
            )
        {
            this.platformsRepository = platformsRepository;
            this.despawnPlatformUseCase = despawnPlatformUseCase;
        }

        public void Execute()
        {
            if(platformsRepository.Items.Count == 0)
            {
                return;
            }

            int smallestIndex = int.MaxValue;
            IDisposable<PlatformView> smallestPlatform = platformsRepository.Items[0];

            foreach (IDisposable<PlatformView> platform in platformsRepository.Items)
            {
                if(smallestIndex <= platform.Value.PlatformIndex)
                {
                    continue;
                }

                smallestIndex = platform.Value.PlatformIndex;
                smallestPlatform = platform;
            }

            despawnPlatformUseCase.Execute(smallestPlatform);
        }
    }
}
