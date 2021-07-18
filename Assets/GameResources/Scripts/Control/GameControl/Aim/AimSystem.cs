using UnityEngine;

using Leopotam.Ecs;

public class AimSystem : EcsSystemWrapper, IEcsRunSystem
{
    private EcsFilter<Aim> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref Aim aim = ref _filter.Get1(i);

            Vector3 newDirection = Vector3.RotateTowards(aim.transform.forward, aim.direction, aim.speed, 0.0f);
            aim.transform.rotation = Quaternion.LookRotation(newDirection);            
        }
    }
}