using HelperClasses;

namespace HelperClassesTest
{
    [TestClass]
    public class DynamicClassTest
    {
        [TestMethod]
        public void TestDynamicClassCreation()
        {
            // Create a dynamic class with properties
            Type dynamicType = HelperClasses.DynamicClass.CreateDynamicClass("DynamicPerson", "FirstName", "LastName");

            // Create an instance of the dynamic class
            object dynamicInstance = Activator.CreateInstance(dynamicType);

            // Set property values
            dynamicInstance.GetType().GetProperty("FirstName").SetValue(dynamicInstance, "John");
            dynamicInstance.GetType().GetProperty("LastName").SetValue(dynamicInstance, "Doe");

            // Get property values
            string firstName = (string)dynamicInstance.GetType().GetProperty("FirstName").GetValue(dynamicInstance);
            string lastName = (string)dynamicInstance.GetType().GetProperty("LastName").GetValue(dynamicInstance);
            
            Assert.AreEqual("John", firstName);
            Assert.AreEqual("Doe", lastName);
        }
    }
}