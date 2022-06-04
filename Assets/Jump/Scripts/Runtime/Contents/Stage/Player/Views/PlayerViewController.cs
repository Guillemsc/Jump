using Juce.Core.Direction;
using Juce.Core.Time;
using Juce.CoreUnity.Time;
using UnityEngine;

namespace Template.Contents.Stage.Player.Views
{
    public sealed class PlayerViewController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody rigidBody = default;

        [Header("Valuse")]
        [SerializeField] private Vector2 forceMultiplierByCharge = Vector2.one;

        private readonly ITimer chargeJumpTimer = new ScaledUnityTimer();

        private bool chargingJump;
        private int direction = 1;

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
            if(chargingJump)
            {
                return;
            }

            chargingJump = true;

            chargeJumpTimer.Restart();
        }

        private void ReleaseChargingJump()
        {
            if (!chargingJump)
            {
                return;
            }

            chargingJump = false;

            float timeCharging = (float)chargeJumpTimer.Time.TotalSeconds;

            Vector2 force = forceMultiplierByCharge * timeCharging;

            force.x *= direction;

            rigidBody.AddForce(force, ForceMode.Force);
        }
    }
}
