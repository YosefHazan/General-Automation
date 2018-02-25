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
        #region function

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

        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            #region todo br relese
            //relese 2
            //TODO:Q&A:IWebElement aaaaa = driver.FindElementByID("");

            //relese 3
            //TODO: class for function
            //TODO: FUNCTION: log repport
            //TODO: sort TEST(calss and function) negativ and possitive, create/upgreat/delete user
            //TODO: FUNCTION: check the last activ and action is pass sucsseful
            //TODO: FUNCTION: Found one word in content element
            //TODO: FUNCTION: press all option and after that check if is electet by radio-butten/check-list/combo-box
            //TODO: go to new window and new tab
            //TODO: before/after test

            //relese 4
            //TODO: FUNCTION: that try all attribiutes for found element in JS and run by selenium 
            //TODO: FUNCTION: set id from js-> myPara.setAttribute("id", "id_you_like");
            //TODO: automation that over all elements in web site and generite the base of selenium script
            //TODO: CI TOOLS
            #endregion

            #region open

            IWebDriver driver = new ChromeDriver();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Actions action = new Actions(driver);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(50);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Elements.baseURL);

            //IWebElement item = driver.FindElement(By.Id("hhhh"));
            //action.DoubleClick(item).Perform();

            //elementToSendTo.SendKeys(Keys.Control + "s"); // its like to press "Ctrl" and "S" on keyboards

            #endregion

            #region login

            IWebElement userNme = driver.FindElement(By.Name("UserName"));
            IWebElement password = driver.FindElement(By.Name("Password"));
            IWebElement button = driver.FindElement(By.CssSelector("[value = 'Login']"));

            userNme.SendKeys("123");
            password.SendKeys("123");
            string untx = userNme.Text;
            string ptx = password.Text;
            //TODO: Assert.AreEqual("123", untx);
            //TODO: Assert.AreEqual("123", ptx);
            button.Click();
 
            Thread.Sleep(1500);
            String currentURL = driver.Url;
            Assert.AreEqual("http://executeautomation.com/demosite/index.html?UserName=123&Password=123&Login=Login", currentURL);

            #endregion

            #region user form

            string StringINhomePage = "Execute Automation Selenium Test Site";
            IWebElement elementForText = driver.FindElement(By.TagName("h1"));
            string textElement = elementForText.Text;
            Assert.AreEqual(StringINhomePage, textElement);

            IWebElement Title = driver.FindElement(By.Id("TitleId"));
            IWebElement Initial = driver.FindElement(By.Id("Initial")); //text
            IWebElement FirstName = driver.FindElement(By.Id("FirstName")); //text*
            IWebElement MiddleName = driver.FindElement(By.Id("MiddleName")); //text
            IWebElement GenderMale = driver.FindElement(By.Name("Female")); // radio button
            IWebElement LanguagesKnownENGLISH = driver.FindElement(By.Name("english")); //check Button
            IWebElement buttonSAVE = driver.FindElement(By.Name("Save"));

            SelectElement country = new SelectElement(Title);
            country.SelectByText("Mr.");
            country.SelectByValue("2");
            country.SelectByIndex(0);

            Initial.SendKeys("blablabal");
            FirstName.SendKeys("blablabal");
            MiddleName.SendKeys("blablabal");   
            GenderMale.Click();                 
            LanguagesKnownENGLISH.Click();      
            buttonSAVE.Click();

            #endregion

            #region actions

            // TODO:NOW: get alert window and other pop window

            IWebElement moveOverByScrol = driver.FindElement(By.Id("Automation Tools"));
            IWebElement OverByMeSecond = driver.FindElement(By.Id("Selenium"));
            //IWebElement clickMeOne = driver.FindElement(By.Id(""));
            action.MoveToElement(moveOverByScrol).Perform();
            Thread.Sleep(500);
            action.MoveToElement(OverByMeSecond).Perform();
            //Thread.Sleep(500);
            var clickMeOne = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Selenium IDE")));
            clickMeOne.Click();

            
            IWebElement scroll = driver.FindElement(By.ClassName("scroll"));
            IWebElement Accept = driver.FindElement(By.CssSelector("input[value='accept']"));
            
            executor.ExecuteScript("arguments[0].style='overflow: inherit;'", scroll);
            Thread.Sleep(500);
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", Accept);
            Thread.Sleep(500);
            Accept.Click();
            Thread.Sleep(500);
            Assert.IsTrue(Accept.Selected,"not selected after scrol bar");


            //drug and drop
            //< a href = "Dragging.html" >< span > Drag and Drop</ span ></ a >
            executor.ExecuteScript("scroll(0, -250);");
            IWebElement DragandDrop = driver.FindElement(By.CssSelector("a[href='Dragging.html']"));
            DragandDrop.Click();
            IWebElement item1 = driver.FindElement(By.Id("item1"));
            IWebElement item4 = driver.FindElement(By.Id("item4"));
            action.DragAndDrop(item1, item4).Perform(); 
            //action.ClickAndHold(item1).MoveToElement(item4).Release().Build().Perform();
            #endregion

            #region close

            Thread.Sleep(1500);
            driver.Close();

            #endregion
        }
    }
}
