using UnityEngine;
using Zenject;

public class BearInstaller : MonoInstaller
{
    [SerializeField] private BearStats bearStats;
    [SerializeField] private BearBrain bearBrain;
    [SerializeField] private BearMovement bearMovement;
    [SerializeField] private BearVision bearVision;
    [SerializeField] private BearCombat bearCombat;
    [SerializeField] private BearHealth bearHealth;

    public override void InstallBindings()
    {
        Container.Bind<BearStats>().FromInstance(bearStats).AsSingle();
        Container.Bind<BearBrain>().FromInstance(bearBrain).AsSingle();
        Container.Bind<BearMovement>().FromInstance(bearMovement).AsSingle();
        Container.Bind<BearVision>().FromInstance(bearVision).AsSingle();
        Container.Bind<BearCombat>().FromInstance(bearCombat).AsSingle();
        Container.Bind<BearHealth>().FromInstance(bearHealth).AsSingle();
    }
}