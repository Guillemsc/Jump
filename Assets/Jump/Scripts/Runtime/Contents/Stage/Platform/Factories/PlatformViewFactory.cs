using Juce.CoreUnity.Factories;
using Template.Contents.Stage.Platform.Views;
using UnityEngine;

namespace Template.Contents.Stage.Platform.Factories
{
    public sealed class PlatformViewFactory : MonoBehaviourKnownPrefabFactory<PlatformViewFactoryDefinition, PlatformView>
    {
        public PlatformViewFactory(PlatformView prefab, Transform parent) : base(prefab, parent)
        {

        }

        protected override void Init(PlatformViewFactoryDefinition definition, PlatformView creation)
        {
            creation.Init(definition.PlatformIndex);
        }
    }
}
