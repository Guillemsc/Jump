using Juce.Core.Visibility;
using Juce.CoreUnity.Ui.ViewStack.Entries;
using System;
using UnityEngine;

namespace Template.Contents.Stage.StageUi.ViewStack
{
    public sealed class StageUiViewStackEntry : ViewStackEntry
    {
        public StageUiViewStackEntry(
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
