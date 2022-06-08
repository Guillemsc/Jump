using Juce.Core.Direction;
using Juce.Core.Time;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Time;
using Juce.TweenComponent;
using Template.Contents.Services.Configuration.Service;
using UnityEngine;

namespace Template.Contents.Stage.Player.Views
{
    public sealed class PlayerViewController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody rigidBody = default;

        [Header("Tweens")]
        [SerializeField] private TweenPlayer groundedTween = default;
        [SerializeField] private TweenPlayer squashTween = default;
        [SerializeField] private TweenPlayer jumpTween = default;

        private readonly ITimer chargeJumpTimer = new ScaledUnityTimer();

        CachedService<IConfigurationService> configurationService;

        private bool chargingJump;
        private int direction = 1;

        bool canJump;

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

        public void SetAsGrounded()
        {
            groundedTween.Play();
            squashTween.Kill();
            jumpTween.Kill();

            canJump = true;
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
            if(chargingJump)
            {
                return;
            }

            chargingJump = true;

            chargeJumpTimer.Restart();

            groundedTween.Kill();
            jumpTween.Kill();
            squashTween.Play();
        }

        private void ReleaseChargingJump()
        {
            if (!chargingJump)
            {
                return;
            }

            chargingJump = false;

            float timeCharging = (float)chargeJumpTimer.Time.TotalSeconds;

            float jumpStrength = Mathf.Min(timeCharging, configurationService.Value.GameConfiguration.PlayerMaxJumpStrenght);

            Vector2 force = configurationService.Value.GameConfiguration.PlayerJumpForceMultiplierByCharge * jumpStrength;

            force.x *= direction;

            rigidBody.AddForce(force, ForceMode.Force);

            groundedTween.Kill();
            squashTween.Kill();
            jumpTween.Play();
        }
    }
}
