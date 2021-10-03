using OpenQA.Selenium;

namespace ConnectedLessons.ElementsPath
{
    public static class LoginElementsPath
    {
        public static By UserName       
            => By.Id("inputLogin");

        public static By Password
            => By.Id("inputPassword");

        public static By LogInButton
            => By.XPath("//button[@type='submit']");
    }
}
