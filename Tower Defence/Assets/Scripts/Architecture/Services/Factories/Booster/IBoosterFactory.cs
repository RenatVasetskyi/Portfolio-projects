using Assets.Scripts.Boosters;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services.Factories.Booster
{
    public interface IBoosterFactory
    {
        Boosters.Booster CreateBooster(BoosterType boosterType, Vector3 at, Quaternion rotation, Transform parent);
    }
}