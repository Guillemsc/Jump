using Juce.CoreUnity.Physics;
using System;
using Template.Contents.Stage.Physics.Colliders;
using UnityEngine;

namespace Template.Contents.Stage.Player.Views
{
    public class PlayerViewCollisionsController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PhysicsCallbacks physicsCallbacks = default;

        public event Action<ICollider> OnPlayerCollided;

        private void Awake()
        {
            physicsCallbacks.OnPhysicsTriggerEnter += OnPhysicsTriggerEnter;
        }

        private void OnPhysicsTriggerEnter(PhysicsCallbacks physicsCallbacks, ColliderData colliderData)
        {
            ICollider collider = colliderData.Collider.GetComponent<ICollider>();

            if (collider == null)
            {
                return;
            }

            OnPlayerCollided?.Invoke(collider);
        }
    }
}
