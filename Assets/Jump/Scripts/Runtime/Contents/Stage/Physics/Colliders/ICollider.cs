namespace Template.Contents.Stage.Physics.Colliders
{
    public interface ICollider 
    {
        void Accept(IColliderVisitor visitor);
    }
}
