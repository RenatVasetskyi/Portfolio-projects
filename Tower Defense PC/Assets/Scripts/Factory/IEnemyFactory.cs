using System.Collections;

public interface IEnemyFactory
{
    public void Initialize();
    public IEnumerator Create();
}
