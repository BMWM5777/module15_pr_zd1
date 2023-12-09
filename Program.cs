using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace module15_pr_zd1
{
    class MyClass
    {
        private int privateField;
        public int PublicField;

        private MyClass() { }

        public MyClass(int value)
        {
            privateField = value;
            PublicField = value;
        }

        private void PrivateMethod()
        {
            Console.WriteLine("Private method called");
        }

        public void PublicMethod()
        {
            Console.WriteLine("Public method called");
        }
    }

    class Program
    {
        static void Main()
        {
            Type myClassType = typeof(MyClass);

            Console.WriteLine($"Имя класса: {myClassType.FullName}");

            Console.WriteLine("\nКонструкторы:");
            ConstructorInfo[] constructors = myClassType.GetConstructors();
            foreach (var constructor in constructors)
            {
                Console.WriteLine($"- {constructor}");
            }

            Console.WriteLine("\nПоля и свойства:");
            FieldInfo[] fields = myClassType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo[] properties = myClassType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                Console.WriteLine($"- {field.Name}: {field.FieldType}, модификатор доступа: {field.Attributes}");
            }
            foreach (var property in properties)
            {
                Console.WriteLine($"- {property.Name}: {property.PropertyType}, модификатор доступа: {property.Attributes}");
            }

            Console.WriteLine("\nМетоды:");
            MethodInfo[] methods = myClassType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in methods)
            {
                Console.WriteLine($"- {method.ReturnType.Name} {method.Name}, модификатор доступа: {method.Attributes}");
            }
        }
    }
}
