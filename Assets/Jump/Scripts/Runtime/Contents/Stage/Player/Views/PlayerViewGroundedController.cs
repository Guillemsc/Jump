using Juce.CoreUnity.Physics.Callbacks;
using System;
using Template.Contents.Stage.Physics.Colliders;
using UnityEngine;

namespace Template.Contents.Stage.Player.Views
{
    public sealed class PlayerViewGroundedController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PhysicsCallbacks physicsCallbacks = default;

        public event Action<bool> OnIsGroundedChanged;
        public bool IsGrounded { get; private set; }

        private void Awake()
        {
            physicsCallbacks.OnPhysicsTriggerEnter += OnPhysicsCollisionEnter;
            physicsCallbacks.OnPhysicsTriggerExit += OnPhysicsCollisionExit;
        }

        private void OnDestroy()
        {
            physicsCallbacks.OnPhysicsTriggerEnter -= OnPhysicsCollisionEnter;
            physicsCallbacks.OnPhysicsTriggerExit -= OnPhysicsCollisionExit;
        }

        private void OnPhysicsCollisionEnter(PhysicsCallbacks physicsCallbacks, Collider collider)
        {
            ICollider colliderComponent = collider.GetComponent<ICollider>();

            if (collider == null)
            {
                return;
            }

            bool isPlatformCollider = colliderComponent is PlatformCollider;

            if (!isPlatformCollider)
            {
                return;
            }

            if(IsGrounded)
            {
                return;
            }

            IsGrounded = true;
            OnIsGroundedChanged?.Invoke(IsGrounded);
        }

        private void OnPhysicsCollisionExit(PhysicsCallbacks physicsCallbacks, Collider collider)
        {
            ICollider colliderComponent = collider.gameObject.GetComponent<ICollider>();

            if (colliderComponent == null)
            {
                return;
            }

            bool isPlatformCollider = colliderComponent is PlatformCollider;

            if (!isPlatformCollider)
            {
                return;
            }

            if(!IsGrounded)
            {
                return;
            }

            IsGrounded = false;
            OnIsGroundedChanged?.Invoke(IsGrounded);
        }
    }
}
