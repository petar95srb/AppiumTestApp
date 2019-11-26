using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class ErrorHandler
    {
        public static void UiElementMissingError(string value)
        {
            TestAppMain.Instance.TestResault.ScreenShot(value + ".png");
        }
    }
}
