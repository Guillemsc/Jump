using Cinemachine;
using Juce.Extensions;
using UnityEngine;

namespace Template.Contents.Stage.Camera.UseCases.UpdateFollowCameraParent
{
    public class UpdateFollowCameraParentUseCase : IUpdateFollowCameraParentUseCase
    {
        private readonly CinemachineVirtualCamera virtualCamera;
        private readonly Transform followCameraParent;

        public UpdateFollowCameraParentUseCase(
            CinemachineVirtualCamera virtualCamera,
            Transform followCameraParent
            )
        {
            this.virtualCamera = virtualCamera;
            this.followCameraParent = followCameraParent;
        }

        public void Execute()
        {
            followCameraParent.transform.SetPositionY(virtualCamera.transform.position.y);
        }
    }
}