using System;
using Assets.Scripts.Architecture.Services;

namespace Assets.Scripts.UI
{
    [Serializable]
    public class ButtonItem
    {
        public ButtonType Type;
        public WindowId WindowId;
    }
}