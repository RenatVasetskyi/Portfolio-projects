using UnityEngine;

namespace Assets.Scripts.Data
{
    public static class Extentions
    {
        public static Vector3 ScreenToWorld(Vector3 position, UnityEngine.Camera camera)
        {
            position.z = camera.nearClipPlane;
            return camera.ScreenToWorldPoint(position);
        }
    }
}