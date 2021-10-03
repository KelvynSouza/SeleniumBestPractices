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

        public bool DoPraticalPhrasesLesson()
        {
            var praticalPhrasesLesson = new PracticalPhrases(_driver);
            for (int i = 0; i < 3; i++){
                ElementsHelper.IsVisible(_driver.FindElement, PlayAndPracticeElementsPath.PlayAndPracticeMenuButton).Click();
                ElementsHelper.IsVisible(_driver.FindElements, PlayAndPracticeElementsPath.CycleButtons)[i].Click();
                EnterInPraticalPhrasesLesson();
                praticalPhrasesLesson.AnswerQuestions();
            }
            return true;
        }

        private bool EnterInPraticalPhrasesLesson()
        {
            ElementsHelper.IsVisible(_driver.FindElement, PlayAndPracticeElementsPath.PracticalPhrasesButton).Click();

            return ElementsHelper.IsVisible(_driver.FindElement, PraticalPhrasesElementsPath.PhraseInputBox) != null ? true : false;
        }
    }
}
