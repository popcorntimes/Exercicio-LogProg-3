using System;
using System.Reflection;
using System.Reflection.Emit;

var myClass = new ExampleClass();
var getInstance = TypeClass.ReturnInstance(myClass);
TypeClass.DisplayInfo(getInstance);
public class ExampleClass
{
    public List<int?> IntList { get; set; }

    public void Method1()
    {
    }
    public int Method2()
    {
        return 3;
    }

}
public class TypeClass
{
    public static void DisplayMethodInfo(MethodInfo[] myArrayMethodInfo)
    {
        // Display information for all methods.
        for (int i = 0; i < myArrayMethodInfo.Length; i++)
        {
            MethodInfo myMethodInfo = (MethodInfo)myArrayMethodInfo[i];
            Console.WriteLine($"Method {i}: {myMethodInfo.Name}\r\n");
        }
    }

    public static void DisplayInfo<T>(T obj)
    {
        Type myType = obj.GetType();
        MethodInfo[] myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        DisplayMethodInfo(myArrayMethodInfo);
        PropertyInfo[] myPropertyInfo = myType.GetProperties();
        for (int i = 0; i < myPropertyInfo.Length; i++)
        {
            Console.WriteLine($"Property {i}: {myPropertyInfo[i].ToString()}\r\n");
        }
    }
    
    public static object ReturnInstance<T>(T obj)
    {
        Type myType = obj.GetType();
        var instance = Activator.CreateInstance(myType);
        return instance;
    }


}