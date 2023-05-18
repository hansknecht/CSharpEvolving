using HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace HelperClassesTest
{
    [TestClass]
    public class DynamicObjectClassTest
    {
        [TestMethod]
        public void TestDynamicObjectClassTest()
        {
            var fields = new List<Field>() {
                new Field("EmployeeID", typeof(int)),
                new Field("EmployeeName", typeof(string)),
                new Field("Designation", typeof(string))
            };

            dynamic obj = new DynamicObjectClass(fields);

            //set
            obj.EmployeeID = 123456;
            obj.EmployeeName = "John";
            obj.Designation = "Tech Lead";

            Assert.ThrowsException<RuntimeBinderException>(() =>
            {
                obj.Age = 25;             //Exception: DynamicClass does not contain a definition for 'Age'
            });
            Assert.ThrowsException<Exception>(() =>
            {
                obj.EmployeeName = 666;   //Exception: Value 666 is not of type String
            });

            Assert.AreEqual(123456, obj.EmployeeID);
            Assert.AreEqual("John", obj.EmployeeName);
            Assert.AreEqual("Tech Lead", obj.Designation);
        }

    }

}
