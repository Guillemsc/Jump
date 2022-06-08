using UnityEngine;

namespace Template.Contents.Stage.Physics.Colliders
{
    public sealed class PlatformCollider : MonoBehaviour, ICollider
    {
        public void Accept(IColliderVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
