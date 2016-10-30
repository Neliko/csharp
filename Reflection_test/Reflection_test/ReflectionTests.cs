using System;
using System.Reflection;
using NUnit.Framework;

namespace Reflection_test
{
    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public void LikeToEatFishTest()
        {
            var cat = Activator.CreateInstance(typeof (Cat));
            var animalType = typeof (Cat);

            var fish = new Fish();
            var result = animalType.InvokeMember("LikeToEat",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, cat,
                new object[] {fish});

            Assert.IsTrue((bool) result,
                "Метод вернул неверный результат для объекта типа {0}  с переданным значением типа {1}: {2} ",
                animalType.Name, fish.GetType(), result);
        }

        [Test]
        public void LikeToEatMeatTest()
        {
            var cat = Activator.CreateInstance(typeof (Cat));
            var animalType = typeof (Cat);

            var meat = new Meat();
            var result = animalType.InvokeMember("LikeToEat",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, cat,
                new object[] {meat});

            Assert.IsFalse((bool) result,
                "Метод вернул неверный результат для объекта типа {0}  с переданным значением типа {1}: {2} ",
                animalType.Name, meat.GetType(), result);
        }

        [Test]
        public void LikeToEatUndefinedTest()
        {
            var cat = Activator.CreateInstance(typeof (Cat));
            var animalType = typeof (Cat);
            Assert.Throws<MissingMethodException>(() => animalType.InvokeMember("LikeToEat",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, cat,
                new object[] {new Dog()}), "Something is wrong. A cat doesn't eat a dog!");
        }
    }
}
