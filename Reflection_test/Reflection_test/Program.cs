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

            var catType = typeof (Cat);

            Console.WriteLine("Атрибуты класса Cat:");
            foreach (var attribute in catType.GetCustomAttributes())
            {
                Console.WriteLine(attribute.ToString());
            }

            // Выводим все методы класса Cat
            ShowAllMethodByClassType(catType);

            // Заставляем Грелку гавкать
            var voice = ChangeSoundOfTheCat(grelka, catType);
            Console.WriteLine($"Грелка говорит: {voice} \n");

            var baseType = typeof(IAnimal);
            List<PropertyInfo> animalTypeDefaultProperties;

            // Устанавливаем значение по умолчанию для каждого своства, которое содержит DefaultValue и возвращаем список объектов типа IAnimal
            var animals = SetDefaulValueForAllPropertiesByTypeAndReturnInstanceList(baseType, out animalTypeDefaultProperties);

            Console.WriteLine("Свойства с установленными значениями по умолчанию:");

            foreach (var attribute in animalTypeDefaultProperties)
            {
                Console.WriteLine($"Свойство:{attribute.Name}");
            }

            Console.ReadKey();
        }

        private static void ShowAllMethodByClassType(IReflect classtype)
        {
            var methodInfos = classtype.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            Console.WriteLine("Все методы класса Cat:");
            foreach (var methodInfo in methodInfos)
            {
              Console.WriteLine(methodInfo.ToString());
            }

            Console.WriteLine();
            Console.WriteLine($"Количество методов: {methodInfos.Length} \n");
        }

        private static object ChangeSoundOfTheCat(Cat cat, Type type)
        {
            var soundProperty =
               type.GetField("_sound", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            // ReSharper disable once PossibleNullReferenceException
            soundProperty.SetValue(cat, "Gaaaaav");

            return type.InvokeMember("Voice",
                BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.InvokeMethod, null,
                cat, null);
        }

        private static IList<IAnimal> SetDefaulValueForAllPropertiesByTypeAndReturnInstanceList(Type baseType, out List<PropertyInfo> propertyList)
        {
            // Создаем экземпляры каждого класса IAnimal
            var animalTypes =
                Assembly.GetAssembly(baseType)
                    .GetTypes()
                    .Where(x => baseType.IsAssignableFrom(x) && x != baseType && !x.IsAbstract).ToList();

            var animalCollection = new List<IAnimal>();
            propertyList = new List<PropertyInfo>();

            foreach (var animalType in animalTypes)
            {
               var animal = (IAnimal)Activator.CreateInstance(animalType);
                var properties = animalType.GetProperties().Where(x => x.PropertyType == typeof(DefaultValueAttribute)).ToList();// x.GetCustomAttribute<DefaultValueAttribute>() != null).ToList();

                foreach (var property in properties)
                {
                    animalType.GetProperty(property.Name).SetValue(animal, property.GetCustomAttribute<DefaultValueAttribute>().Value.ToString());

                }

                animalCollection.Add(animal);
                propertyList.AddRange(properties);
            }

            return animalCollection;
        }
    }
}