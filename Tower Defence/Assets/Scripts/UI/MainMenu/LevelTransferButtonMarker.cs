using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.UI.MainMenu
{
    public class LevelTransferButtonMarker : MonoBehaviour
    {
        public LevelId Id;
        public bool IsOpened;
        public LevelTransferButton OpenedButton;
        public GameObject ClosedButton;
    }
}