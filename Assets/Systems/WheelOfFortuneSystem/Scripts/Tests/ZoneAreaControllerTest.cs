using NUnit.Framework;
using Zenject;
using NSubstitute;
using UnityEngine;

namespace WheelOfFortuneSystem.Tests
{
    [TestFixture]
    public class ZoneAreaControllerTest : ZenjectUnitTestFixture
    {
        private IZoneAreaController _controller;
        private IZoneAreaModel _model;
        private IZoneAreaView _view;

        [SetUp]
        public void SetUp()
        {
            _model = Substitute.For<IZoneAreaModel>();
            _view = Substitute.For<IZoneAreaView>();

            Container.Bind<IZoneAreaModel>().FromInstance(_model).AsSingle();
            Container.Bind<IZoneAreaView>().FromInstance(_view).AsSingle();
            Container.Bind<IZoneAreaController>().To<FakeZoneAreaController>().AsSingle();

            Container.Inject(this);
            _controller = Container.Resolve<IZoneAreaController>();

            Assert.That(_controller.Model, Is.EqualTo(_model), "Model should be same instance");
            Assert.That(_controller.View, Is.EqualTo(_view), "View should be same instance");
        }

        [Test]
        public void SetZoneIndex_Should_Update_Model_And_Snap_View()
        {
            var fakeTarget = CreateFakeRectTransform();

            _controller.SetZoneIndex(5, fakeTarget);

            _model.Received(1).CurrentZoneIndex = 5;
            _view.Received(1).SnapTo(fakeTarget);
        }

        private RectTransform CreateFakeRectTransform()
        {
            var go = new GameObject("FakeRectTransform");
            return go.AddComponent<RectTransform>();
        }
        
        private class FakeZoneAreaController : IZoneAreaController
        { 
            public IZoneAreaModel Model { get; }
            public IZoneAreaView View { get; }
            
            public FakeZoneAreaController(IZoneAreaModel model, IZoneAreaView view)
            {
                Model = model;
                View = view;
            }
            
            public void Init() { }

            public void SetZoneIndex(int currentZoneIndex, RectTransform target)
            {
                Model.CurrentZoneIndex = currentZoneIndex;
                View.SnapTo(target);
            }
        }
    }
}
