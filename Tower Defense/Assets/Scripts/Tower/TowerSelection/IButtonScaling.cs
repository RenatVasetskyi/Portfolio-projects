using UnityEngine;

namespace Tower
{
    public interface IButtonScaling
    {
        public void OnSelect();
        public void OnDeselect(GameObject button);
    }
}
