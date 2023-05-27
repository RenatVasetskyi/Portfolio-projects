using UnityEngine;

namespace Assets.Scripts.Data
{
    public static class Extensions
    {
        public static Vector3 ToWorldPoint(this Vector2 vector, UnityEngine.Camera camera) =>
            camera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, camera.transform.position.z));
    }
}
