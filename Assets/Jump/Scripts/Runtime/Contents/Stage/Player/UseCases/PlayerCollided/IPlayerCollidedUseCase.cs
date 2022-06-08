using Template.Contents.Stage.Physics.Colliders;

namespace Template.Contents.Stage.Player.UseCases.PlayerCollided
{
    public interface IPlayerCollidedUseCase
    {
        void Execute(ICollider collider);
    }
}
