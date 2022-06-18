
using Cinemachine;

namespace Template.Contents.Stage.Camera.UseCases.StopFollowingPlayer
{
    public class StopFollowingPlayerUseCase : IStopFollowingPlayerUseCase
    {
        private readonly CinemachineVirtualCamera virtualCamera;

        public StopFollowingPlayerUseCase(
            CinemachineVirtualCamera virtualCamera
            )
        {
            this.virtualCamera = virtualCamera;
        }

        public void Execute()
        {
            virtualCamera.Follow = null;
        }
    }
}