using System;
using System.Reflection;
using NUnit.Framework;

namespace Reflection_test
{
    using System.Diagnostics.CodeAnalysis;

    [TestFixture]
    [SuppressMessage("ReSharper", "ArrangeThisQualifier")]
    public class CatLikeToEatMethodTests
    {
        private Cat cat;
        private Type animalType;

        [SetUp]
        public void SetUp()
        {
            cat = new Cat();
            animalType = typeof(Cat);
        }

        [Test]
        public void LikeToEatFishTest()
        {
            var fish = new Fish();
            var result = animalType.InvokeMember("LikeToEat",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, cat,
                new object[] {fish});

            Assert.IsTrue(
                (bool)result,
                $"Метод вернул неверный результат для объекта типа {animalType.Name}  с переданным значением типа {fish.GetType()}: {result} ");
        }

        [Test]
        public void LikeToEatMeatTest()
        {
            var meat = new Meat();
            var result = animalType.InvokeMember("LikeToEat",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, cat,
                new object[] {meat});

            Assert.IsFalse(
                (bool)result,
                $"Метод вернул неверный результат для объекта типа {animalType.Name}  с переданным значением типа {meat.GetType()}: {result} ");
        }

        [Test]
        public void LikeToEatUndefinedTest()
        {
            Assert.Throws<MissingMethodException>(() => animalType.InvokeMember("LikeToEat",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, cat,
                new object[] {new Dog()}), "Something is wrong. A cat doesn't eat a dog!");
        }
    }
}
