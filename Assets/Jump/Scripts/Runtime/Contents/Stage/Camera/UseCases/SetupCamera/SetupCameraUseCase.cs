using Cinemachine;
using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Template.Contents.Stage.Camera.UseCases.UpdateFollowCameraParent;
using Template.Contents.Stage.Player.Views;
using UnityEngine;

namespace Template.Contents.Stage.Camera.UseCases.SetupCamera
{
    public class SetupCameraUseCase : ISetupCameraUseCase
    {
        private readonly CinemachineVirtualCamera virtualCamera;
        private readonly ISingleRepository<IDisposable<PlayerView>> playerRepository;
        private readonly IUpdateFollowCameraParentUseCase updateFollowCameraParentUseCase;

        public SetupCameraUseCase(
            CinemachineVirtualCamera virtualCamera,
            ISingleRepository<IDisposable<PlayerView>> playerRepository,
            IUpdateFollowCameraParentUseCase updateFollowCameraParentUseCase
            )
        {
            this.virtualCamera = virtualCamera;
            this.playerRepository = playerRepository;
            this.updateFollowCameraParentUseCase = updateFollowCameraParentUseCase;
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

            virtualCamera.UpdateCameraState(Vector3.up, Time.deltaTime);

            updateFollowCameraParentUseCase.Execute();
        }
    }
}
