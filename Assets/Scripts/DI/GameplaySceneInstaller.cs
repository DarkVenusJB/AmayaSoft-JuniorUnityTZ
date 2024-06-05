using Assets.Scripts;
using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private SpawnerFactory _spawnerFactory;
    [SerializeField] private WinElementFinder _winElementFinder;
    [SerializeField] private Initializator _initializator;
    
    public override void InstallBindings()
    {
        Container.Bind<SpawnerFactory>().FromInstance(_spawnerFactory).AsSingle().NonLazy();
        Container.Bind<WinElementFinder>().FromInstance(_winElementFinder).AsSingle().NonLazy();
        Container.Bind<Initializator>().FromInstance(_initializator).AsSingle().NonLazy();
        
    }
}