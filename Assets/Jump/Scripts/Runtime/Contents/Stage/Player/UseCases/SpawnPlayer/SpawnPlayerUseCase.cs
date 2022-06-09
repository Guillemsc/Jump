using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Template.Contents.Stage.Player.Factories;
using Template.Contents.Stage.Player.UseCases.PlayerCollided;
using Template.Contents.Stage.Player.Views;
using UnityEngine;

namespace Template.Contents.Stage.Player.UseCases.SpawnPlayer
{
    public sealed class SpawnPlayerUseCase : ISpawnPlayerUseCase
    {
        private readonly IFactory<PlayerViewFactoryDefinition, IDisposable<PlayerView>> factory;
        private readonly ISingleRepository<IDisposable<PlayerView>> repository;
        private readonly Transform spawnPosition;
        private readonly IPlayerCollidedUseCase playerCollidedUseCase;

        public SpawnPlayerUseCase(
            IFactory<PlayerViewFactoryDefinition, IDisposable<PlayerView>> factory,
            ISingleRepository<IDisposable<PlayerView>> repository,
            Transform spawnPosition,
            IPlayerCollidedUseCase playerCollidedUseCase
            )
        {
            this.factory = factory;
            this.repository = repository;
            this.spawnPosition = spawnPosition;
            this.playerCollidedUseCase = playerCollidedUseCase;
        }

        public void Execute()
        {
            bool spawned = factory.TryCreate(
                new PlayerViewFactoryDefinition(),
                out IDisposable<PlayerView> instance
                );

            if(!spawned)
            {
                return;
            }

            repository.Set(instance);

            instance.Value.transform.position = spawnPosition.transform.position;

            instance.Value.PlayerViewCollisionsController.OnPlayerCollided += playerCollidedUseCase.Execute;
        }
    }
}
