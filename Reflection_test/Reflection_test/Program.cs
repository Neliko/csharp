using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Reflection_test
{
    class Program
    {
        private static void Main()
        { 
            var grelka = (Cat) Activator.CreateInstance(typeof (Cat));
            var zarapka = (Cat) Activator.CreateInstance(typeof (Cat), new object[] {10});

            var murzik = new Cat();
            var catType = typeof (Cat);

            foreach (var attribute in catType.GetCustomAttributes())
            {
                Console.WriteLine(attribute.ToString());
            }

            // Выводим все методы класса Cat
            var methodInfo =
                catType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                      BindingFlags.DeclaredOnly);

            Console.WriteLine("Все методы класса Cat:");
            DisplayInfo(methodInfo.Select(x=>x.ToString()).ToList());

            Console.WriteLine("Количество методов: {0} \n", methodInfo.Count());

            // Заставляем Грелку гавкать
            var piInstance =
                catType.GetField("_sound", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            // ReSharper disable once PossibleNullReferenceException
            piInstance.SetValue(grelka, "Gaaaaav");

            var voice = catType.InvokeMember("Voice",
                BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.InvokeMethod, null,
                grelka, null);

            Console.WriteLine("Гралка говорит: {0} \n", voice);

            // Создаем экземпляры каждого класса IAnimal
            var baseType = typeof (IAnimal);
            var animalTypes =
                Assembly.GetAssembly(baseType)
                    .GetTypes()
                    .Where(x => baseType.IsAssignableFrom(x) && x != baseType).ToList();

            var animalCollection = animalTypes.Select(Activator.CreateInstance).ToArray();

            //Получаем все свойства со значениями по умолчанию        
            IList<PropertyInfo> animalTypeDefaultProperties = animalTypes.SelectMany(type => (type.GetProperties().Where(x => x.CustomAttributes.Any()).ToArray())).ToList();
           
            // Устанавливаем значение для каждого найденного свойства
            foreach (var property in animalTypeDefaultProperties)
            {
                var declaringPropertyType = property.DeclaringType;
                var animalType = animalTypes.FirstOrDefault(type => type == declaringPropertyType);
                if (animalType == null)
                {
                    throw new ArgumentNullException("Не удалось найти тип " + declaringPropertyType);
                }
                var animalInstance = animalCollection.FirstOrDefault(x => x.GetType() == declaringPropertyType);

                animalType.GetProperty(property.Name).SetValue(animalInstance, property.GetCustomAttribute<DefaultValueAttribute>().Value.ToString());
            }

            Console.WriteLine("Своства с установленными значениями по умолчанию:");
            DisplayInfo(animalTypeDefaultProperties.Select(x=>x.Name).ToList());
            Console.ReadKey();
        }

        public static void DisplayInfo(IList<string> info)
        {
            foreach (var attribute in info)
            {
                Console.WriteLine(attribute);
            }

            Console.WriteLine();
        }
    }
}