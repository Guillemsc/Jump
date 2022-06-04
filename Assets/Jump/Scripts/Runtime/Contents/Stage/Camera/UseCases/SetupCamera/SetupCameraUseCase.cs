using Cinemachine;
using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Template.Contents.Stage.Player.Views;

namespace Template.Contents.Stage.Camera.UseCases.SetupCamera
{
    public class SetupCameraUseCase : ISetupCameraUseCase
    {
        private readonly CinemachineVirtualCamera virtualCamera;
        private readonly ISingleRepository<IDisposable<PlayerView>> playerRepository;

        public SetupCameraUseCase(
            CinemachineVirtualCamera virtualCamera,
            ISingleRepository<IDisposable<PlayerView>> playerRepository
            )
        {
            this.virtualCamera = virtualCamera;
            this.playerRepository = playerRepository;
        }

        public void Execute()
        {
            bool playerFound = playerRepository.TryGet(out IDisposable<PlayerView> playerView);

            if(!playerFound)
            {
                return;
            }

            virtualCamera.Follow = playerView.Value.transform;

            virtualCamera.PreviousStateIsValid = false;
        }
    }
}
