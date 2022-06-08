using Template.Contents.Stage.Physics.Colliders;
using Template.Contents.Stage.Player.UseCases.PlayerCollidedWithDeath;
using Template.Contents.Stage.Player.UseCases.PlayerCollidedWithPlatform;

namespace Template.Contents.Stage.Player.UseCases.PlayerCollided
{
    public class PlayerCollidedUseCase : IPlayerCollidedUseCase, IColliderVisitor
    {
        private readonly IPlayerCollidedWithPlatformUseCase playerCollidedWithPlatformUseCase;
        private readonly IPlayerCollidedWithDeathUseCase playerCollidedWithDeathUseCase;

        public PlayerCollidedUseCase(
            IPlayerCollidedWithPlatformUseCase playerCollidedWithPlatformUseCase,
            IPlayerCollidedWithDeathUseCase playerCollidedWithDeathUseCase
            )
        {
            this.playerCollidedWithPlatformUseCase = playerCollidedWithPlatformUseCase;
            this.playerCollidedWithDeathUseCase = playerCollidedWithDeathUseCase;
        }

        public void Execute(ICollider collider)
        {
            collider.Accept(this);
        }

        public void Visit(PlatformCollider platformCollider)
        {
            playerCollidedWithPlatformUseCase.Execute(platformCollider);
        }

        public void Visit(DeathCollider deathCollider)
        {
            playerCollidedWithDeathUseCase.Execute(deathCollider);
        }
    }
}
