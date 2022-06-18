using Juce.Core.Visibility;
using Juce.CoreUnity.Ui.ViewStack.Entries;
using System;
using UnityEngine;

namespace Template.Contents.Stage.PostGameUi.ViewStack
{
    public sealed class PostGameUiViewStackEntry : ViewStackEntry
    {
        public PostGameUiViewStackEntry(
            Type id,
            Transform transform,
            IVisible visible,
            bool isPopup,
            params ViewStackEntryRefresh[] refreshList
            ) : base(
                id,
                transform,
                visible,
                isPopup,
                refreshList
                )
        {
        }
    }
}
