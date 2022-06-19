using Juce.Core.Di.Installers;
using Template.Contents.Meta.SplashScreenUi.Installers;
using Template.Contents.Meta.StartScreenUi.Installers;
using UnityEngine;

namespace Template.Contexts.Meta
{
    public sealed class MetaContextInstance : MonoBehaviour
    {
        [SerializeField] private SplashScreenUiInstaller splashScreenUiInstaller = default;
        [SerializeField] private StartScreenUiInstaller startScreenUiInstaller = default;

        public IInstaller SplashScreenUiInstaller => splashScreenUiInstaller;
        public IInstaller StartScreenUiInstaller => startScreenUiInstaller;
    }
}
