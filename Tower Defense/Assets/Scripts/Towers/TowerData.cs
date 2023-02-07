using UnityEngine;

[CreateAssetMenu(menuName = "Towers / DefaultTower", fileName = "New Tower")]
public class TowerData : ScriptableObject
{
    [SerializeField] private GameObject _tower;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _damage;	
	[SerializeField] private float _hp;
	
	public GameObject Tower
    {
		get { return _tower; }
		protected set { }
	}
    public float ReloadTime
    {
        get { return _reloadTime; }
        protected set { }
    }
    public float Damage
	{
		get { return _damage; }
		protected set { }
	}
    public float Hp
    {
        get { return _hp; }
        protected set { }
    }
}
