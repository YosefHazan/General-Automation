using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadMusic
{

    class yyMyDrive
    {
        public static IWebDriver driver { get; private set; }
        public static IJavaScriptExecutor executor { get; private set; }
        public static WebDriverWait wait { get; private set; }
        public static Actions action { get; private set; }
        public IWebElement Sreach { get; private set; } //#sf_url

        //log setting
        public string LocalLogPhath = null;
        public string conteianLog { get; private set; }
        public string DefaultLogPhath { get; private set; } = @"C:\Log\log.html";

        public yyMyDrive()
        {
            yySyncrnosy();
        }

        public yyMyDrive(string LogPhath)
        {
            if (LogPhath.ToLower().Contains("create"))
            {
                LocalLogPhath = DefaultLogPhath;
            }
            else
            {
                LocalLogPhath = LogPhath;
            }
            yySyncrnosy();

        }

        //--------------------------------------------------------------------Driver area
        public void yySyncrnosy()
        {
            driver = new ChromeDriver();
            executor = (IJavaScriptExecutor)driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            action = new Actions(driver);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(50);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://en.savefrom.net/");
        }

        public void CloseWindow()
        {
            driver.Quit();
        }

        public IWebElement yyElement(String cssSelector)
        {
            IWebElement yyE = null;
            //if the first letter is '/' so find element by XPath else by Css Selectors.
            By by = ((cssSelector[0] == '/') ? By.XPath(cssSelector) : By.CssSelector(cssSelector));

            try
            {
                yyE = driver.FindElement(by);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("notFound"))
                {

                }
            }
            return yyE;
        }

        //----------------------------------------------------element area

        public string WriteTo(String cssSelector, String ToWrite)
        {
            string WT = null;
            IWebElement yyE = yyElement(cssSelector);
            if (yyE != null)
            {
                yyE.Clear();
                yyE.SendKeys(ToWrite);
                WT = yyE.Text;
            }
            return WT;
        }

        public void ClickOn(String cssSelector)
        {
            IWebElement yyE = yyElement(cssSelector);
            if (yyE != null)
            {
                yyE.Click();
            }
            
        }

        //-----------------------------------------------------log area
        public bool WriteLog(string contact)
        {

            bool WL = false;
            if (LocalLogPhath != null)
            {
                File.AppendAllText(LocalLogPhath, contact);
                WL = true;
            }
            return WL;
        }
        
    }
    
}
