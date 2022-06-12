using Juce.CoreUnity.Physics.Callbacks;
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

        private void OnPhysicsTriggerEnter(PhysicsCallbacks physicsCallbacks, Collider collider)
        {
            ICollider colliderComponent = collider.GetComponent<ICollider>();

            if (colliderComponent == null)
            {
                return;
            }

            OnPlayerCollided?.Invoke(colliderComponent);
        }
    }
}
