using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCombat playerCombat;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerMovement>().FromInstance(playerMovement).AsSingle();
        Container.Bind<PlayerCombat>().FromInstance(playerCombat).AsSingle();
    }
}