using Juce.Core.Visibility;
using Juce.CoreUnity.Ui.ViewStack.Entries;
using System;
using UnityEngine;

namespace Template.Contents.Meta.StartScreenUi.ViewStack
{
    public sealed class StartScreenUiViewStackEntry : ViewStackEntry
    {
        public StartScreenUiViewStackEntry(
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
