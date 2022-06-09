using UnityEngine;

namespace Template.Contents.Stage.Player.Views
{
    public sealed class PlayerView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerViewCollisionsController playerViewCollisionsController = default;
        [SerializeField] private PlayerViewMovementController playerViewController = default;

        public PlayerViewCollisionsController PlayerViewCollisionsController => playerViewCollisionsController;
        public PlayerViewMovementController PlayerViewController => playerViewController;
    }
}
