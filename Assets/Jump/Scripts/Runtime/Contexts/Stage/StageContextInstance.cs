using Cinemachine;
using Juce.Core.Di.Installers;
using System.Collections.Generic;
using Template.Contents.Stage.GameUi.Installers;
using Template.Contents.Stage.PostGameUi.Installers;
using UnityEngine;

namespace Template.Contexts.Stage
{
    public sealed class StageContextInstance : MonoBehaviour
    {
        [Header("Camera")]
        [SerializeField] private CinemachineVirtualCamera virtualCamera = default;
        [SerializeField] private Transform followCameraParent = default;

        [Header("Player")]
        [SerializeField] private Transform playerViewParent = default;
        [SerializeField] private Transform playerViewSpawnPosition = default;

        [Header("Platform")]
        [SerializeField] private Transform platformViewsParent = default;
        [SerializeField] private Transform platformViewsLeftSpawnPosition = default;
        [SerializeField] private Transform platformViewsRightSpawnPosition = default;

        [Header("Death")]
        [SerializeField] private Transform deathCollider = default;

        [Header("Particles")]
        [SerializeField] private List<ParticleSystem> particlesToSimulate = default;

        [Header("Ui")]
        [SerializeField] private GameUiInstaller gameUiInstaller = default;
        [SerializeField] private PostGameUiInstaller postGameUiInstaller = default;

        public CinemachineVirtualCamera VirtualCamera => virtualCamera;
        public Transform FollowCameraParent => followCameraParent;

        public Transform PlayerViewParent => playerViewParent;
        public Transform PlayerViewSpawnPosition => playerViewSpawnPosition;

        public Transform PlatformViewsParent => platformViewsParent;
        public Transform PlatformViewsLeftSpawnPosition => platformViewsLeftSpawnPosition;
        public Transform PlatformViewsRightSpawnPosition => platformViewsRightSpawnPosition;

        public Transform DeathCollider => deathCollider;

        public IReadOnlyList<ParticleSystem> ParticlesToSimulate => particlesToSimulate;

        public IInstaller GameUiInstaller => gameUiInstaller;
        public IInstaller PostGameUiInstaller => postGameUiInstaller;
    }
}
