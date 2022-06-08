using Template.Contents.Stage.Physics.Colliders;

namespace Template.Contents.Stage.Player.UseCases.PlayerCollidedWithPlatform
{
    public interface IPlayerCollidedWithPlatformUseCase 
    {
        void Execute(PlatformCollider platformCollider);
    }
}
