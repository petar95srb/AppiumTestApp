using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class TestAppMain
    {
        private static TestAppMain _instance;
        public static TestAppMain Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TestAppMain();

                return _instance;
            }
        }

        private Connector _connector;
        public Connector Connector
        {
            get
            {
                return _connector;
            }
        }

        private PhoneConfig _phoneConfig;

        public PhoneConfig PhoneConfig
        {
            get
            {
                return _phoneConfig;
            }
        }

        private AppConfig _appConfig;

        public AppConfig AppConfig
        {
            get
            {
                return _appConfig;
            }
        }

        private Test _test;
        public Test Test
        {
            get
            {
                return _test;
            }
        }

        private TestResault _testResault;
        public TestResault TestResault
        {
            get
            {
                return _testResault;
            }
        }

        public string StartTestApp(string configDataPath)
        {
            string data = File.ReadAllText(configDataPath);

            JObject jdata = JObject.Parse(data);

            var config = jdata["config"];
            var phoneConfig = jdata["phoneConfig"];
            var appConfig = jdata["appConfig"];
            var test = jdata["testData"];
            var testResaultConfig = jdata["resaultConfig"];

            Config.Instance.SetConfig((JObject)config);
            _phoneConfig = new PhoneConfig((JObject)phoneConfig);
            _appConfig = new AppConfig((JObject)appConfig);

            _connector = new Connector(_phoneConfig, _appConfig);

            _test = new Test((JArray)test);

            _testResault = new TestResault((JObject)testResaultConfig);

            _connector.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            _test.startTest();

            return _testResault.CheckResault();
        }

        public bool InitTest(Config config, PhoneConfig phoneConfig, AppConfig appConfig,TestResault testResault)
        {
            Config.Instance.SetConfig(config);
            _phoneConfig = phoneConfig;
            _appConfig = appConfig;
            _testResault = testResault;

            try
            {
                _connector = new Connector(_phoneConfig, _appConfig);
                _test = new Test();
            }catch(Exception e)
            {
                _connector = null;
                _test = null;
                return false;
            }

            return true;
        }

        public void RunTest()
        {
            Test.startTest();
        }

        public void AddTestStep(JObject step)
        {
            Test.TestSteps.Add(ITestStep.CreateTestStep(step));
        }

        public void AddTestStep(ITestStep step)
        {
            Test.TestSteps.Add(step);
        }

        public void RemoveTestStep(int index)
        {
            Test.TestSteps.RemoveAt(index);
        }

        public void ExecuteTestStep(int index)
        {
            Test.TestSteps[index].PerformStep();
        }

        public JObject GetAsJson()
        {
            JObject data = new JObject();

            data["config"] = Config.Instance.GetAsJson();
            data["phoneConfig"] = _phoneConfig.GetAsJson();
            data["appConfig"] = _appConfig.GetAsJson();
            data["testData"] = Test.GetAsJson();
            data["resaultConfig"] = TestResault.GetAsJson();

            return data;
        }

    }
}
