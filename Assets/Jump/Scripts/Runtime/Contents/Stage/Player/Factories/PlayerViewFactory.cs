using Juce.CoreUnity.Factories;
using Template.Contents.Stage.Player.Views;
using UnityEngine;

namespace Template.Contents.Stage.Player.Factories
{
    public sealed class PlayerViewFactory : MonoBehaviourKnownPrefabFactory<PlayerViewFactoryDefinition, PlayerView>
    {
        public PlayerViewFactory(PlayerView prefab, Transform parent) : base(prefab, parent)
        {

        }

        protected override void Init(PlayerViewFactoryDefinition definition, PlayerView creation)
        {
    
        }
    }
}
