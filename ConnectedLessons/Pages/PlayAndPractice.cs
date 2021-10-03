using ConnectedLessons.Elements;
using ConnectedLessons.ElementsPath;
using ConnectedLessons.Helper;
using OpenQA.Selenium.Edge;
using System;

namespace ConnectedLessons.Pages
{
    public class PlayAndPractice
    {
        private EdgeDriver _driver;
        public PlayAndPractice(EdgeDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException();
        }

        public bool EnterInPraticalPhrasesLesson()
        {
            ElementsHelper.IsVisible(_driver.FindElement, PlayAndPracticeElementsPath.PlayAndPracticeMenuButton).Click();
            ElementsHelper.IsVisible(_driver.FindElement, PlayAndPracticeElementsPath.PracticalPhrasesButton).Click();

        }
    }
}
