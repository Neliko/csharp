using System.ComponentModel;

namespace Reflection_test
{
	[DefaultValue(null)]
    public class Cat : IAnimal
    {
        private int _tailLength;

		// todo: сделать, чтобы кот гавкал :)
	    private static string _sound = "Myyaaauuuu";

		[DefaultValue("black")]
        public string FurColor { get; set; }

	    public bool IsPedegreeed { get; set; }

	    [DefaultValue("green")]
	    public string EyeColor { get; set; }

	    public Cat(int tailLength)
        {
            _tailLength = tailLength;
        }

        public Cat()
        {
            _tailLength = 5;
        }

		// todo: написать тест на приватный метод
        private bool LikeToEat(IFood someFood)
        {
			// Котики любят рыбку :)
	        if (someFood.GetType() == typeof (Fish))
		        return true;

			return false;
        }

        public string Eating(IFood someFood)
        {
	        return LikeToEat(someFood) ? "nyam-nyam" : "frrr";
        }

        public static string Voice()
        {
			return _sound;
        }
    }
}