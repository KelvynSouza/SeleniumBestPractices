using ConnectedLessons.ElementsPath;
using ConnectedLessons.Helper;
using OpenQA.Selenium.Edge;
using System;

namespace ConnectedLessons.Pages
{
    public class Login
    {
        private EdgeDriver _driver;
        private string _UserName, _Password;

        public Login(EdgeDriver driver, string userName, string password)
        {
            _driver = driver ?? throw new ArgumentNullException(); 
            _UserName = userName ?? throw new ArgumentNullException(); 
            _Password = password ?? throw new ArgumentNullException(); 
        }

        public bool LogIn()
        {
            int test = 0;
            do
            {
                _driver.Url = "https://connected.timescontroller.com.br/login";
                ElementsHelper.IsVisible(_driver.FindElement, LoginElementsPath.UserName).SendKeys(_UserName);
                ElementsHelper.IsVisible(_driver.FindElement, LoginElementsPath.Password).SendKeys(_Password);
                ElementsHelper.IsVisible(_driver.FindElement, LoginElementsPath.LogInButton).Click();
                ++test;
            } while (!ValidateLogin() && test < 2);
            return ValidateLogin();
        }

        private bool ValidateLogin()
        {
            return ElementsHelper.IsVisible(_driver.FindElement, PlayAndPracticeElementsPath.PlayAndPracticeMenuButton) != null ? true : false;
        }
    }
}
