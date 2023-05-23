using static Assets.Scripts.Architecture.Services.InputService;

namespace Assets.Scripts.Architecture.Services
{
    public interface IInputService
    {
        event StartTouch OnTouchStarted;
        event EndTouch OnTouchEnded;
        //void SetCurrentCamera(UnityEngine.Camera camera);
    }
}