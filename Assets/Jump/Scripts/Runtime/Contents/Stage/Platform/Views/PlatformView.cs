using Juce.CoreUnity.Physics;
using UnityEngine;

namespace Template.Contents.Stage.Platform.Views
{
    public sealed class PlatformView : MonoBehaviour
    {
        public int PlatformIndex { get; private set; }

        public void Init(int platformIndex)
        {
            PlatformIndex = platformIndex;
        }
    }
}
