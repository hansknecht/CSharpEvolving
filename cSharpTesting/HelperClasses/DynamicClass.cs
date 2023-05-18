using System;
using System.Reflection;
using System.Reflection.Emit;

namespace HelperClasses
{
    public class DynamicClass
    {
        public static Type CreateDynamicClass(string className, params string[] propertyNames)
        {
            // Create a new assembly and module
            AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");

            // Create a new type builder
            TypeBuilder typeBuilder = moduleBuilder.DefineType(className, TypeAttributes.Public | TypeAttributes.Class);

            // Create properties for the class
            foreach (string propertyName in propertyNames)
            {
                // Define a private field for the property
                FieldBuilder fieldBuilder = typeBuilder.DefineField($"_{propertyName}", typeof(string), FieldAttributes.Private);

                // Define the property with a getter and setter
                PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, typeof(string), null);

                // Define the getter method
                MethodBuilder getterMethodBuilder = typeBuilder.DefineMethod($"get_{propertyName}", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, typeof(string), Type.EmptyTypes);
                ILGenerator getterILGenerator = getterMethodBuilder.GetILGenerator();
                getterILGenerator.Emit(OpCodes.Ldarg_0);
                getterILGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
                getterILGenerator.Emit(OpCodes.Ret);

                // Define the setter method
                MethodBuilder setterMethodBuilder = typeBuilder.DefineMethod($"set_{propertyName}", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new[] { typeof(string) });
                ILGenerator setterILGenerator = setterMethodBuilder.GetILGenerator();
                setterILGenerator.Emit(OpCodes.Ldarg_0);
                setterILGenerator.Emit(OpCodes.Ldarg_1);
                setterILGenerator.Emit(OpCodes.Stfld, fieldBuilder);
                setterILGenerator.Emit(OpCodes.Ret);

                // Assign the getter and setter to the property
                propertyBuilder.SetGetMethod(getterMethodBuilder);
                propertyBuilder.SetSetMethod(setterMethodBuilder);
            }

            // Create the type
            Type dynamicType = typeBuilder.CreateType();

            return dynamicType;
        }
    }
}
    