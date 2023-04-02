using UnityEngine;

namespace Tower
{
    public interface IButtonSelection
    {
        public void OnSelect();
        public void OnDeselect(GameObject button);
    }
}
