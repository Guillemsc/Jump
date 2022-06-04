using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Template.Contents.Stage.Platform.Views;

namespace Template.Contents.Stage.Platform.UseCases.DespawnPlatform
{
    public class DespawnPlatformUseCase : IDespawnPlatformUseCase
    {
        private readonly IRepository<IDisposable<PlatformView>> repository;

        public DespawnPlatformUseCase(
            IRepository<IDisposable<PlatformView>> repository
            )
        {
            this.repository = repository;
        }

        public void Execute(IDisposable<PlatformView> platform)
        {
            bool found = repository.Contains(platform);

            if(!found)
            {
                return;
            }

            repository.Remove(platform);

            platform.Dispose();
        }
    }
}
