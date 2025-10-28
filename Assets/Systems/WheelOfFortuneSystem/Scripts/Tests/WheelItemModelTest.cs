using NUnit.Framework;
using Zenject;
using NSubstitute;
using UnityEngine;

namespace WheelOfFortuneSystem.Tests
{
    public class WheelItemModelTest : ZenjectUnitTestFixture
    {
        private IWheelItemModel _model;
        private IWheelItemView _view;
        private IWheelItemController _controller;
        private WheelItemData _data;

        [SetUp]
        public void SetUp()
        {
            _model = Substitute.For<IWheelItemModel>();
            _view = Substitute.For<IWheelItemView>();
            _data = WheelItemDataFactory.Create(id: "gold_coin", amount: 100, weight: 80);
            
            Assert.That(_model, Is.Not.Null, "Model should be created");
            Assert.That(_view, Is.Not.Null, "View should be created");
            
            Container.Bind<IWheelItemModel>().FromInstance(_model).AsSingle();
            Container.Bind<IWheelItemView>().FromInstance(_view).AsSingle();
            Container.Bind<IWheelItemController>().To<FakeWheelItemController>().AsSingle();
            Container.Inject(this);
            _controller = Container.Resolve<IWheelItemController>();
            
            Assert.That(_controller, Is.Not.Null, "Controller should be resolved");
            Assert.That(_controller.Model, Is.EqualTo(_model), "Model should be the same instance");
            Assert.That(_controller.View, Is.EqualTo(_view), "View should be the same instance");
        }
        
        [Test]
        public void Prepare_Should_Update_Model_And_Call_View()
        {
            _controller.Prepare(_data, 4);

            _model.Received(1).Amount = 400;              
            _view.Received(1).Prepare(400, _data.Icon);   
        }

        [Test]
        public void Prepare_Should_Handle_Zero_And_Negative_Multipliers()
        {
            _controller.Prepare(_data, 0);
            _model.Received(1).Amount = 0;
            _view.Received(1).Prepare(0, _data.Icon);

            _controller.Prepare(_data, -3);
            _model.Received(1).Amount = -300;              
            _view.Received(1).Prepare(-300, _data.Icon);  
        }
        
        private class FakeWheelItemController : IWheelItemController
        {
            public IWheelItemView View { get; }
            public IWheelItemModel Model { get; }
            
            public FakeWheelItemController(IWheelItemModel model, IWheelItemView view)
            {
                Model = model;
                View = view;
            }
            
            public void Prepare(WheelItemData data, int multiplier)
            {
                var finalAmount = data.Amount * multiplier;
                Model.Amount = finalAmount;
                View.Prepare(finalAmount, data.Icon);
            }
        }
        
        private class WheelItemDataFactory
        {
            public static WheelItemData Create(
                string id = "default_id",
                int amount = 10,
                WheelOfFortuneBaseType appearType = WheelOfFortuneBaseType.Gold,
                int weight = 50,
                Sprite icon = null)
            {
                if (icon == null)
                    icon = CreateTestSprite(8, 8); 

                object boxed = default(WheelItemData);

                var t = typeof(WheelItemData);
                t.GetField("<Id>k__BackingField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!.SetValue(boxed, id);
                t.GetField("<Amount>k__BackingField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!.SetValue(boxed, amount);
                t.GetField("<AppearType>k__BackingField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!.SetValue(boxed, appearType);
                t.GetField("<Weight>k__BackingField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!.SetValue(boxed, weight);
                t.GetField("<Icon>k__BackingField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!.SetValue(boxed, icon);

                return (WheelItemData)boxed;
            }

            private static Sprite CreateTestSprite(int width, int height)
            {
                var tex = new Texture2D(width, height);
                tex.SetPixel(0, 0, Color.white);
                tex.Apply();
                return Sprite.Create(tex, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
            }
        }
    }
}