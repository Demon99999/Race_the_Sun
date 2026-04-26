using Assets.RaceTheSun.Sources.Data;
using Cysharp.Threading.Tasks;
using RaseTheSun.Scripts.GameLogic.Trail;
using UnityEngine;

namespace RaseTheSun.Scripts.Infrastructure.Factories.SpaceshipModelFactory
{
    public interface ISpaceshipModelFactory
    {
        UniTask<SpaceshipModel> CreateSpaceshipModel(SpaceshipType type, Vector3 position, Transform parent = null);
        UniTask<Trail> CreateTrail(TrailType type, Vector3 position, Transform parent);
    }
}