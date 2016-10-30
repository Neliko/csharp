using System.ComponentModel;

namespace Reflection_test
{
	public class Dog : IAnimal
	{
		private static string _sound = "Gaaav!";

		public double Length { get; set; }

		public double Weight { get; set; }

		[DefaultValue("pink")]
		public string TongueColor { get; set; }

		public bool IsTrained { get; set; }

		public static string Voice()
		{
			return _sound;
		}
	}
}