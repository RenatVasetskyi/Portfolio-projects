using UnityEngine;

public class BoatSfxPlayer : MonoBehaviour
{
    private void Awake()
    {
        AudioManager.Instance.PlayBoatSfx(BoatSfxType.Engine);
    }

    private void OnDestroy()
    {
        AudioManager.Instance.StopBoatSfx(BoatSfxType.Engine);
    }
}
