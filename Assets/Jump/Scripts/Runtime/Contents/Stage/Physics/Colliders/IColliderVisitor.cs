namespace Template.Contents.Stage.Physics.Colliders
{
    public interface IColliderVisitor
    {
        void Visit(PlatformCollider platformCollider);
        void Visit(DeathCollider deathCollider);
    }
}
