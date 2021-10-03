using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedLessons.ElementsPath
{
    public static class PlayAndPracticeElementsPath
    {
        public static By PlayAndPracticeMenuButton
            => By.XPath("//a[@href='/playandpractice']");

        public static By PracticalPhrasesButton
            => By.XPath("//div[contains(text(), 'Practical Phrases')]");

        public static By CycleButtons
            => By.XPath("//div[@class='panel-heading']//div[contains(@class,'no-padding')]/a");
    }
}