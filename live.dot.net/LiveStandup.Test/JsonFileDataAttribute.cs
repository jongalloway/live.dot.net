// https://andrewlock.net/creating-a-custom-xunit-theory-test-dataattribute-to-load-data-from-json-files/
// https://ankursheel.com/blog/2019/02/load-test-data-from-a-json-file-for-xunit-tests/

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit.Sdk;

namespace LiveStandup.Tests
{
       public class JsonFileDataAttribute : DataAttribute
    {
        private readonly string _filePath;

        private readonly string _propertyName;

        private readonly Type _dataType;

        public JsonFileDataAttribute(string filePath, Type dataType)
        {
            _filePath = filePath;
            _dataType = dataType;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            var parameters = testMethod.GetParameters();
            // Get the absolute path to the JSON file
            var path = Path.IsPathRooted(_filePath) ? _filePath : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            // Load the file
            var fileData = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(_propertyName))
            {
                //whole file is the data
                return GetData(fileData);
            }

            // Only use the specified property as the data
            var allData = JObject.Parse(fileData);
            var data = allData[_propertyName].ToString();
            return GetData(data);
        }

        private IEnumerable<object[]> GetData(string jsonData)
        {
            dynamic datalist = JsonConvert.DeserializeObject(jsonData, _dataType);
            var objectList = new List<object[]>();
            foreach (var data in datalist)
            {
                objectList.Add(new object[] { data });
            }

            return objectList;
        }
    }
}