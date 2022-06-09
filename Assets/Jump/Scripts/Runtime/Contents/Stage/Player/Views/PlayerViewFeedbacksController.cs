using Juce.CoreUnity.TweenComponent;
using System.Threading;
using UnityEngine;

namespace Template.Contents.Stage.Player.Views
{
    public sealed class PlayerViewFeedbacksController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerViewMovementController playerViewMovementController = default;
        [SerializeField] private PlayerViewGroundedController playerViewGroundedController = default;

        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation chargeAnimation = default;
        [SerializeField] private TweenPlayerAnimation jumpAnimation = default;
        [SerializeField] private TweenPlayerAnimation groundedAfterJumpAnimation = default;
        [SerializeField] private TweenPlayerAnimation jumpCanceledAnimation = default;

        private void Awake()
        {
            playerViewMovementController.OnChargingJumpStarted += OnChargingJumpStarted;
            playerViewMovementController.OnChargingJumpFinished += OnChargingJumpFinished;
            playerViewMovementController.OnChargingJumpCanceled += OnChargingJumpCanceled;

            playerViewGroundedController.OnIsGroundedChanged += OnIsGroundedChanged;
        }

        private void OnDestroy()
        {
            playerViewMovementController.OnChargingJumpStarted -= OnChargingJumpStarted;
            playerViewMovementController.OnChargingJumpFinished -= OnChargingJumpFinished;
            playerViewMovementController.OnChargingJumpCanceled -= OnChargingJumpCanceled;

            playerViewGroundedController.OnIsGroundedChanged -= OnIsGroundedChanged;
        }

        private void OnChargingJumpStarted()
        {
            chargeAnimation.Execute(instantly: false, CancellationToken.None);
        }

        private void OnChargingJumpFinished()
        {
            jumpAnimation.Execute(instantly: false, CancellationToken.None);
        }

        private void OnChargingJumpCanceled()
        {
            jumpCanceledAnimation.Execute(instantly: false, CancellationToken.None);
        }

        private void OnIsGroundedChanged(bool grounded)
        {
            if (grounded)
            {
                groundedAfterJumpAnimation.Execute(instantly: false, CancellationToken.None);
            }
        }
    }
}
