using System;
using Assets.Scripts.Data.Windows;

namespace Assets.Scripts.UI.MainMenu
{
    [Serializable]
    public class ButtonItem
    {
        public ButtonType Type;
        public WindowId WindowId;
    }
}