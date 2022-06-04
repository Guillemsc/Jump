using Juce.CoreUnity.Physics;
using System;
using Template.Contents.Stage.Platform.Views;
using UnityEngine;

namespace Template.Contents.Stage.Player.Views
{
    public sealed class PlayerView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PhysicsCallbacks physicsCallbacks = default;
        [SerializeField] private PlayerViewController playerViewController = default;

        public PlayerViewController PlayerViewController => playerViewController;

        public event Action<PlatformView> OnPlayerCollidedWithPlatform;

        private void Awake()
        {
            physicsCallbacks.OnPhysicsTriggerEnter += OnPhysicsTriggerEnter;
        }

        private void OnPhysicsTriggerEnter(PhysicsCallbacks physicsCallbacks, ColliderData colliderData)
        {
            PlatformView platformView = colliderData.Collider.GetComponentInParent<PlatformView>();

            if(platformView == null)
            {
                return;
            }

            OnPlayerCollidedWithPlatform?.Invoke(platformView);
        }
    }
}
