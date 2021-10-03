using ConnectedLessons.ElementsPath;
using ConnectedLessons.Helper;
using OpenQA.Selenium.Edge;
using System;
using System.Linq;

namespace ConnectedLessons.Pages
{
    public class PracticalPhrases
    {
        private EdgeDriver _driver;

        public PracticalPhrases(EdgeDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException();
        }

        public bool AnswerQuestions()
        {
            while (!PhrasesEnded()) 
            {
                var answer = ElementsHelper.IsVisible(_driver.FindElement, PraticalPhrasesElementsPath.HiddenAnswer).Text;
                ElementsHelper.IsVisible(_driver.FindElement, PraticalPhrasesElementsPath.PhraseInputBox).SendKeys(answer);
                ElementsHelper.IsVisible(_driver.FindElement, PraticalPhrasesElementsPath.ValidateButton).Click();
                ElementsHelper.IsVisible(_driver.FindElement, PraticalPhrasesElementsPath.NextPhrase).Click();
            } 
            
            return ElementsHelper.IsVisible(_driver.FindElement, PraticalPhrasesElementsPath.CompletionProof) != null ? true : false;

        }

        public bool PhrasesEnded()
        {
            var phrasesCount = ElementsHelper.IsVisible(_driver.FindElement, PraticalPhrasesElementsPath.HiddenAnswer).Text;
            var counts = phrasesCount.Split("/");
            int.TryParse(counts.ElementAtOrDefault(0).Trim(), out int completed);
            int.TryParse(counts.ElementAtOrDefault(1).Trim(), out int AllToComplete);

            return completed == AllToComplete;
        }
    }
}
