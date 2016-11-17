using System;
using System.Collections.Generic;
using DataTransformer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstMEF.Contracts;
using MyFirstMEF.Model;

namespace MyFirstMEF.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class DataTransformTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        private IDataTransform _target;
        private DataInput _dataInput;
        private TestDataProvider _provider;
        private TestDataExporter[] _exporters;

        [TestInitialize]
        public void Initialize()
        {
            // set up the input 

            _dataInput = new DataInput
                             {
                                 ColumnNames = new[] {"Integer", "GUID"}, 
                                 Rows = new List<IList<string>>()
                             };
            
            for(var x = 0; x < 5; x++)
            {
                var row = new List<string> {x.ToString(), Guid.NewGuid().ToString()};
                _dataInput.Rows.Add(row);
            }

            _provider = new TestDataProvider(_dataInput);

            _exporters = new[] {new TestDataExporter(), new TestDataExporter()};

            _target = new DataTransform {Input = _provider, Output = _exporters};

        }

        [TestMethod]
        public void TestThatDataTransformCallsProviderAndExporters()
        {
            _target.Transform();
            Assert.IsTrue(_exporters[0].Input.IsEqualTo(_dataInput), "Test failed: first exporter did not receive the data input.");
            Assert.IsTrue(_exporters[1].Input.IsEqualTo(_dataInput), "Test failed: second data exporter did not receive the data input.");
        }
    }
}
