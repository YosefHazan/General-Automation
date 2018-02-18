using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using UnitTestProject1;
using tests;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver();
        public IJavaScriptExecutor executor;

        public string foundNum(string str)
        {//found num in string
            str = Regex.Match(str, @"\d+").Value; 
            return (str);
        }

        public void WriteToFile()
        {
            StreamWriter writer = new StreamWriter(@"");
            writer.WriteLine("");
            writer.Close();
        }

        public static void CaptureXXX(IWebDriver driver, string screenShotName)
        {
        
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();//Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();"

            //Use it as you want now
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile("filename", ScreenshotImageFormat.Png); //use any of the built in image formating
            ss.ToString();//same as string screenshot = ss.AsBase64EncodedString;
 
        }

        [TestMethod]
        public void TestMethod1()
        {
            //TODO: automation that over all elements in web site and generite the base of selenium script
            //TODO: go to new window and new tab
            //TODO: before/after test
            //TODO: CI TOOLS

            #region open


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Actions action = new Actions(driver);
            executor = (IJavaScriptExecutor)driver;
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Elements.baseURL);

            IJavaScriptExecutor aa = (IJavaScriptExecutor)driver;
            //IWebElement item = driver.FindElement(By.Id("hhhh"));
            //aa.ExecuteScript("argument[0].scrollIntoView(true);", item);
            //action.DoubleClick(item).Perform();
            //IWebElement fram = driver.FindElement(By.Id("hhhh"));
            //action.DragAndDropToOffset(fram, 200, 200).Perform();

            //elementToSendTo.SendKeys(Keys.Control + "s"); // press any key of keyboards

            #endregion

            #region login
            //TODO: Function TEST negativ and possitive

            IWebElement userNme = driver.FindElement(By.Name(Elements.Txt_UserName_Name));
            IWebElement password = driver.FindElement(By.Name(Elements.Txt_Password_Name));
            IWebElement button = driver.FindElement(By.CssSelector(Elements.Btn_LogIn_CSS));

            userNme.SendKeys("123");
            password.SendKeys("123");
            string untx = userNme.Text;
            string ptx = password.Text;
                //TODO:input to FUNCTION check the value is writed
            Assert.AreEqual("123", untx);
            Assert.AreEqual("123", ptx);

            button.Click();
            
           

            Thread.Sleep(500);
            Thread.Sleep(1000);
            String currentURL = driver.Url;
            //Assert.AreEqual("http://executeautomation.com/demosite/index.html?UserName=123&Password=123&Login=Login", currentURL);

            #endregion

            #region user form

            //TODO: Function AND class
            //TODO: FUNCTION log repport
            string StringINhomePage = "This is a demo website, which act as a mock site for trying out different automation tools";
            IWebElement elementForText = driver.FindElement(By.TagName("h1"));
            string textElement = elementForText.Text;
            Assert.AreEqual(StringINhomePage, textElement);
            //TODO: Found one word in content element

            //TODO: function that try all attribiutes for found element in JS and run by selenium
            IWebElement Title = driver.FindElement(By.Id("TitleId"));
            IWebElement Initial = driver.FindElement(By.Id("Initial")); //text
            IWebElement FirstName = driver.FindElement(By.Id("FirstName")); //text*
            IWebElement MiddleName = driver.FindElement(By.Id("MiddleName")); //text
            IWebElement GenderMale = driver.FindElement(By.Name("Male")); // radio button
            IWebElement LanguagesKnownENGLISH = driver.FindElement(By.Name("english")); //check Button
            IWebElement buttonSAVE = driver.FindElement(By.Name("Save"));

            SelectElement country = new SelectElement(Title);
            country.SelectByText("Mr.");
            country.SelectByValue("2");
            country.SelectByIndex(0); // it is works?

            Initial.SendKeys("blablabal");
            FirstName.SendKeys("blablabal");
            MiddleName.SendKeys("blablabal");//TODO:function for negativ test
            GenderMale.Click(); // TODO: FUNCTION press all option and after that check if is electet 
            LanguagesKnownENGLISH.Click(); // TODO: FUNCTION press all option and after that check if is electet
            buttonSAVE.Click();
            //TODO: check if is realy save 
            //TODO: upgreat the user
            //TODO: delete the user


            #endregion
            //TODO: action for drug and drop
            // actions for MOUSEOVER
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("????")));
            action.MoveToElement(element).Perform();
            // TODO: get alert window and other pop window
            Thread.Sleep(555);
            driver.Close();

            //TODO: set id from js-> myPara.setAttribute("id", "id_you_like");
        }
    }
}
