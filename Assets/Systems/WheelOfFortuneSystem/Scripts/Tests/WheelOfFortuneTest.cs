using System;
using NUnit.Framework;
using Zenject;
using NSubstitute;
using StateMachineSystem;
using UnityEngine;

namespace WheelOfFortuneSystem.Tests
{
    [TestFixture]

    public class WheelOfFortuneTest : ZenjectUnitTestFixture
    {
        private IWheelOfFortuneModel _model;
        private IWheelOfFortuneView _view;
        private IWheelOfFortuneController _controller;
        private ISpinButton _spinButton;
        private StateMachine _stateMachine;

        [SetUp]
        public void SetUp()
        {
            _model = Substitute.For<IWheelOfFortuneModel>();
            _view = Substitute.For<IWheelOfFortuneView>();
            _spinButton = Substitute.For<ISpinButton>();
            _stateMachine = new StateMachine();

            Assert.That(_model, Is.Not.Null, "Model should be created");
            Assert.That(_view, Is.Not.Null, "View should be created");
            Assert.That(_spinButton, Is.Not.Null, "SpinButton should be created");
            Assert.That(_stateMachine, Is.Not.Null, "StateMachine should be created");

            Container.Bind<IWheelOfFortuneModel>().FromInstance(_model).AsSingle();
            Container.Bind<IWheelOfFortuneView>().FromInstance(_view).AsSingle();
            Container.Bind<ISpinButton>().FromInstance(_spinButton).AsSingle();
            Container.Bind<StateMachine>().FromInstance(_stateMachine).AsSingle();
            Container.Bind<IWheelOfFortuneController>().To<FakeWheelOfFortuneController>().AsSingle();
            Container.Inject(this);
            _controller = Container.Resolve<IWheelOfFortuneController>();

            Assert.That(_controller, Is.Not.Null, "Controller should be resolved");
            Assert.That(_controller.Model, Is.EqualTo(_model), "Model should be the same instance");
            Assert.That(_controller.View, Is.EqualTo(_view), "View should be the same instance");
            Assert.That(_controller.SpinButton, Is.EqualTo(_spinButton), "SpinButton should be the same instance");
            Assert.That(_controller.StateMachine, Is.EqualTo(_stateMachine), "StateMachine should be the same instance");
        }

        [Test]
        public void Initialize()
        {
            _controller.Init();
            _view.Received(1).SetHeaderText(Arg.Any<string>(), Arg.Any<Color>());
        }

        [Test]
        public void Deinitialize()
        {
            Assert.DoesNotThrow(() => _controller.Deinit());
        }

        [Test]
        public void Should_Set_Header_Text()
        {
            _view.SetHeaderText("Spin Ready", Color.white);
            _view.Received(1).SetHeaderText("Spin Ready", Color.white);
        }

        [Test]
        public void Should_Set_Info_Text()
        {
            _view.SetInfoText("Spinning...", Color.yellow);
            _view.Received(1).SetInfoText("Spinning...", Color.yellow);
        }

        [Test]
        public void Should_Set_Base_Image()
        {
            var sprite = Sprite.Create(Texture2D.blackTexture, new Rect(0, 0, 1, 1), Vector2.zero);
            _view.SetBaseImage(sprite);
            _view.Received(1).SetBaseImage(sprite);
        }

        private class FakeWheelOfFortuneController : IWheelOfFortuneController
        {
            public IWheelOfFortuneModel Model { get; }
            public IWheelOfFortuneView View { get; }
            public ISpinButton SpinButton { get; }
            public StateMachine StateMachine { get; }

            public FakeWheelOfFortuneController(IWheelOfFortuneModel model, IWheelOfFortuneView view,
                ISpinButton spinButton, StateMachine stateMachine)
            {
                Model = model;
                View = view;
                SpinButton = spinButton;
                StateMachine = stateMachine;
            }

            public void Init()
            {
                View.SetHeaderText("Initialized", Color.green);
            }

            public void Deinit() { }

            public void Tick() { }
            
            public void RePrepare(WheelOfFortuneBaseType baseType) { }

            public void DoSpin(Vector3 targetRot, Action onCompolete = null) { }
        }
    }
}
