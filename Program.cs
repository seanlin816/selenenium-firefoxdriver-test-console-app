using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace FirefoxDriverConsoleApp
{
    class Program
    {
        static void Main()
        {
            SPGData spg = new SPGData();
            string result = spg.GetDeactivationData(null);
            Console.WriteLine(result);
        }
    }
}
