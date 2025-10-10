using SolarSystem.Infrastructure;

namespace SolarSystem.Gameplay.HUD
{
    public class DraftIndicatorViewRegistrar : EntityComponentRegistrar
    {
        public DraftIndicatorView DraftIndicatorView;
        
        public override void RegisterComponents()
        {
            Entity.AddDraftIndicatorView(DraftIndicatorView);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasDraftIndicatorView)
                Entity.RemoveDraftIndicatorView();
        }
    }
}