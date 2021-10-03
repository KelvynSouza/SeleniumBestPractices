using OpenQA.Selenium;

namespace ConnectedLessons.ElementsPath
{
    public static class PraticalPhrasesElementsPath
    {
        public static By PhraseInputBox
             => By.Id("formControlsTextarea");
        public static By ValidateButton
            => By.XPath("//button/span[text()='Validar']");
        public static By HiddenAnswer
            => By.XPath("//div[contains(@class, 'practical-phrases answer-btn text')]//strong[@class='text-danger']");
        public static By NextPhrase
            => By.XPath("//div[not(contains(@class,'hidden'))]/button/span[text()='Próximo']");
        public static By CompletionProof
            => By.XPath("//span[text()='Parabéns você concluiu os practical phrases!']");
    }
}
