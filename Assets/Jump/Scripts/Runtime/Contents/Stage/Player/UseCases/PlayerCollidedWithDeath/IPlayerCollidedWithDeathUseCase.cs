using Template.Contents.Stage.Physics.Colliders;

namespace Template.Contents.Stage.Player.UseCases.PlayerCollidedWithDeath
{
    public interface IPlayerCollidedWithDeathUseCase
    {
        void Execute(DeathCollider deathCollider);
    }
}
