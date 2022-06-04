using Juce.Core.Direction;
using Template.Contents.Stage.Platform.Views;
using Template.Contents.Stage.Player.Views;
using UnityEngine;

namespace Template.Contents.Shared.Configuration
{
    [CreateAssetMenu(fileName = nameof(GameConfiguration), 
        menuName = "Template/Shared/Configuration/GameConfiguration", order = 1)]
    public class GameConfiguration : ScriptableObject
    {
        [Header("Physics")]
        [SerializeField] private float physicsGravity = -10f;

        [Header("Player")]
        [SerializeField] private PlayerView playerViewPrefab = default;
        [SerializeField] private HorizontalDirection initialPlayerDirection = default;

        [Header("Platform")]
        [SerializeField] private PlatformView platformViewPrefab = default;
        [SerializeField] private HorizontalDirection startingPlatformSide = default;
        [SerializeField, Min(0)] private float minPlatformSpawnHeight = default;
        [SerializeField, Min(0)] private float maxPlatformSpawnHeight = default;

        public float PhysicsGravity => physicsGravity;

        public PlayerView PlayerViewPrefab => playerViewPrefab;
        public HorizontalDirection InitialPlayerDirection => initialPlayerDirection;

        public PlatformView PlatformViewPrefab => platformViewPrefab;
        public HorizontalDirection StartingPlatformSide => startingPlatformSide;
        public float MinPlatformSpawnHeight => minPlatformSpawnHeight;
        public float MaxPlatformSpawnHeight => maxPlatformSpawnHeight;

    }
}