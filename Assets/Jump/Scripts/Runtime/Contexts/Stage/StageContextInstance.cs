using Cinemachine;
using Template.Contents.Stage.StageUi.Installers;
using UnityEngine;

namespace Template.Contexts.Stage
{
    public sealed class StageContextInstance : MonoBehaviour
    {
        [Header("Camera")]
        [SerializeField] private CinemachineVirtualCamera virtualCamera = default;

        [Header("Player")]
        [SerializeField] private Transform playerViewParent = default;
        [SerializeField] private Transform playerViewSpawnPosition = default;

        [Header("Platform")]
        [SerializeField] private Transform platformViewsParent = default;
        [SerializeField] private Transform platformViewsLeftSpawnPosition = default;
        [SerializeField] private Transform platformViewsRightSpawnPosition = default;

        [Header("Death")]
        [SerializeField] private Transform deathCollider = default;

        [Header("StageUi")]
        [SerializeField] private StageUiInstaller stageUiInstaller = default;

        public CinemachineVirtualCamera VirtualCamera => virtualCamera;

        public Transform PlayerViewParent => playerViewParent;
        public Transform PlayerViewSpawnPosition => playerViewSpawnPosition;

        public Transform PlatformViewsParent => platformViewsParent;
        public Transform PlatformViewsLeftSpawnPosition => platformViewsLeftSpawnPosition;
        public Transform PlatformViewsRightSpawnPosition => platformViewsRightSpawnPosition;

        public Transform DeathCollider => deathCollider;

        public StageUiInstaller StageUiInstaller => stageUiInstaller;
    }
}
