using Juce.CoreUnity.Physics;
using System;
using Template.Contents.Stage.Physics.Colliders;
using UnityEngine;

namespace Template.Contents.Stage.Player.Views
{
    public sealed class PlayerView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PhysicsCallbacks physicsCallbacks = default;
        [SerializeField] private PlayerViewController playerViewController = default;

        public PlayerViewController PlayerViewController => playerViewController;

        public event Action<ICollider> OnPlayerCollided;

        private void Awake()
        {
            physicsCallbacks.OnPhysicsTriggerEnter += OnPhysicsTriggerEnter;
        }

        private void OnPhysicsTriggerEnter(PhysicsCallbacks physicsCallbacks, ColliderData colliderData)
        {
            ICollider collider = colliderData.Collider.GetComponent<ICollider>();

            if(collider == null)
            {
                return;
            }

            OnPlayerCollided?.Invoke(collider);
        }
    }
}
