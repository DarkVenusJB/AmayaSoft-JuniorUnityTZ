using Assets.Scripts;
using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private SpawnerFactory spawnerFactory;
    public override void InstallBindings()
    {
       Container.Bind<SpawnerFactory>().FromInstance(spawnerFactory).AsSingle().NonLazy();
    }
}