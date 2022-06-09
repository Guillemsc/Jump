using Juce.Core.Direction;
using Juce.Core.Time;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Time;
using System;
using Template.Contents.Services.Configuration.Service;
using UnityEngine;

namespace Template.Contents.Stage.Player.Views
{
    public sealed class PlayerViewMovementController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody rigidBody = default;
        [SerializeField] private PlayerViewGroundedController playerViewGroundedController = default;

        private readonly ITimer chargeJumpTimer = new ScaledUnityTimer();
        private readonly ITimer canJumpAgainTimer = new ScaledUnityTimer();

        CachedService<IConfigurationService> configurationService;

        private bool chargingJump;
        private int direction = 1;

        public event Action OnChargingJumpStarted;
        public event Action OnChargingJumpFinished;
        public event Action OnChargingJumpCanceled;

        private void Update()
        {
            HandleInput();
        }

        public void SetDirection(HorizontalDirection horizontalDirection)
        {
            switch (horizontalDirection)
            {
                case HorizontalDirection.Left:
                    {
                        direction = -1;
                    }
                    break;

                case HorizontalDirection.Right:
                    {
                        direction = 1;
                    }
                    break;
            }
        }

        public void ToggleDirection()
        {
            direction *= -1;
        }

        private void HandleInput()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartChargingJump();
            }
            
            if(Input.GetKeyUp(KeyCode.Space))
            {
                ReleaseChargingJump();
            }
        }

        private void StartChargingJump()
        {
            if (chargingJump)
            {
                return;
            }

            if (!playerViewGroundedController.IsGrounded)
            {
                return;
            }

            bool canJumpAgain = !canJumpAgainTimer.Started
                || canJumpAgainTimer.HasReached(TimeSpan.FromSeconds(configurationService.Value.GameConfiguration.PlayerCanJumpAgainMinTime));

            if (!canJumpAgain)
            {
                return;
            }

            chargingJump = true;

            chargeJumpTimer.Restart();

            OnChargingJumpStarted?.Invoke();
        }

        private void ReleaseChargingJump()
        {
            if (!chargingJump)
            {
                return;
            }

            chargingJump = false;

            canJumpAgainTimer.Restart();

            bool hasNecessaryForce = chargeJumpTimer.Time.TotalSeconds > configurationService.Value.GameConfiguration.PlayerMinJumpStrenght;

            if (!hasNecessaryForce)
            {
                OnChargingJumpCanceled?.Invoke();
                return;
            }

            float timeCharging = (float)chargeJumpTimer.Time.TotalSeconds;

            float jumpStrength = Mathf.Min(timeCharging, configurationService.Value.GameConfiguration.PlayerMaxJumpStrenght);

            Vector2 force = configurationService.Value.GameConfiguration.PlayerJumpForceMultiplierByCharge * jumpStrength;

            force.x *= direction;

            rigidBody.AddForce(force, ForceMode.Force);

            OnChargingJumpFinished?.Invoke();
        }
    }
}
