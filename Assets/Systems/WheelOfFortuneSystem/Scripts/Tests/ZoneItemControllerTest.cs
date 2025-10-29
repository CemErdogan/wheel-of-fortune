using NUnit.Framework;
using Zenject;
using NSubstitute;

namespace WheelOfFortuneSystem.Tests
{
    [TestFixture]
    public class ZoneItemControllerTest : ZenjectUnitTestFixture
    {
        private IZoneItemController _controller;
        private IZoneItemModel _model;
        private IZoneItemView _view;

        [SetUp]
        public void SetUp()
        {
            _model = Substitute.For<IZoneItemModel>();
            _view = Substitute.For<IZoneItemView>();

            Container.Bind<IZoneItemModel>().FromInstance(_model).AsSingle();
            Container.Bind<IZoneItemView>().FromInstance(_view).AsSingle();
            Container.Bind<IZoneItemController>().To<FakeZoneItemController>().AsSingle();

            Container.Inject(this);
            _controller = Container.Resolve<IZoneItemController>();

            Assert.That(_controller.Model, Is.EqualTo(_model), "Model should be same instance");
            Assert.That(_controller.View, Is.EqualTo(_view), "View should be same instance");
        }

        [Test]
        public void Prepare_Should_Update_Model_And_Call_View()
        {
            _controller.Prepare(7);

            _model.Received(1).Index = 7;
            _view.Received(1).SetIndex(7);
        }

        private class FakeZoneItemController : IZoneItemController
        {
            public IZoneItemModel Model { get; }
            public IZoneItemView View { get; }

            public FakeZoneItemController(IZoneItemModel model, IZoneItemView view)
            {
                Model = model;
                View = view;
            }

            public void Prepare(int index)
            {
                Model.Index = index;
                View.SetIndex(index);
            }
        }
    }
}