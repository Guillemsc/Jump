using Juce.Core.Direction;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Template.Contents.Stage.Platform.Factories;
using Template.Contents.Stage.Platform.Views;
using UnityEngine;

namespace Template.Contents.Stage.Platform.UseCases.SpawnPlatform
{
    public sealed class SpawnPlatformUseCase : ISpawnPlatformUseCase
    {
        private readonly IFactory<PlatformViewFactoryDefinition, IDisposable<PlatformView>> factory;
        private readonly IRepository<IDisposable<PlatformView>> repository;
        private readonly Transform platformViewsLeftSpawnPosition;
        private readonly Transform platformViewsRightSpawnPosition;


        public SpawnPlatformUseCase(
            IFactory<PlatformViewFactoryDefinition, IDisposable<PlatformView>> factory,
            IRepository<IDisposable<PlatformView>> repository,
            Transform platformViewsLeftSpawnPosition,
            Transform platformViewsRightSpawnPosition
            )
        {
            this.factory = factory;
            this.repository = repository;
            this.platformViewsLeftSpawnPosition = platformViewsLeftSpawnPosition;
            this.platformViewsRightSpawnPosition = platformViewsRightSpawnPosition;
        }

        public void Execute(int platformIndex, HorizontalDirection side, float height)
        {
            bool spawned = factory.TryCreate(
                new PlatformViewFactoryDefinition(platformIndex),
                out IDisposable<PlatformView> instance
                );

            if (!spawned)
            {
                return;
            }

            repository.Add(instance);

            SetPosition(instance.Value, side, height);
        }

        private void SetPosition(PlatformView instance, HorizontalDirection side, float height)
        {
            float xPosition = 0;

            switch (side)
            {
                case HorizontalDirection.Left:
                    {
                        xPosition = platformViewsLeftSpawnPosition.position.x;
                        break;
                    }

                case HorizontalDirection.Right:
                    {
                        xPosition = platformViewsRightSpawnPosition.position.x;
                        break;
                    }
            }

            Vector3 newPosition = new Vector3(xPosition, height, instance.transform.position.z);

            instance.transform.position = newPosition;
        }
    }
}
