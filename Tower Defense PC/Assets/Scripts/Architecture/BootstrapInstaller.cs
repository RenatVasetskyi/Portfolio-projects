using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public PlayerInput Input;  

    public override void InstallBindings()
    {
        BindInput();
    } 

    private void BindInput()
    {
        Input = new PlayerInput();

        Input.Enable();

        Container
            .Bind<PlayerInput>()
            .FromInstance(Input)
            .AsSingle();
    }
}
