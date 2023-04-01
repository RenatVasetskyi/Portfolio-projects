using UnityEngine;

namespace Environment
{
    public interface IFinishDetector
    {
        public void Detect(Collider collider);
    }
}
