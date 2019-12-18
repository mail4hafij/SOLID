
namespace SRC.TEST.Ioc
{
    public class TestContainer : SRC.Ioc.Container
    {
        public TestContainer()
        {
            // Rebind

            // AnimalService
            _kernel.Bind<API.IAnimalService>().To<AnimalService>();

            // Static config
            _kernel.Rebind<IStaticConfig>().To<TestStaticConfig>();
        }
    }
}
