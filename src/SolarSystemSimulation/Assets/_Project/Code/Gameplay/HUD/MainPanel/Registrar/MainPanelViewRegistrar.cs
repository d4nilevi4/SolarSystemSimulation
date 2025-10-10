using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.HUD
{
    public class MainPanelViewRegistrar : EntityComponentRegistrar
    {
        public MainPanelView MainPanelView;
        
        public override void RegisterComponents()
        {
            Entity.AddMainPanelView(MainPanelView);
        }

        public override void UnregisterComponents()
        {
            if(Entity.hasMainPanelView)
                Entity.RemoveMainPanelView();
        }
    }
}