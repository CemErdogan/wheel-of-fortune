using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneManager : IInitializable
    {
        [Inject] private WheelOfFortune.Factory _wheelFactory;
        
        public void Initialize()
        {
            _wheelFactory.Create();
        }
    }
}