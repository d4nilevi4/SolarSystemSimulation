namespace SolarSystem.Infrastructure
{
    public class BattleLocalStatesInstaller : BindingsInstaller
    {
        public override void InstallBindings(DiContainer container)
        {
            container.Bind<LocalEnterState>().To<EnterBattleState>().AsSingle();
            container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
        }
    }
}