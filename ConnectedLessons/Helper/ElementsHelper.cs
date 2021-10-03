using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedLessons.Helper
{
    public static class ElementsHelper
    {

        private static TimeSpan _timeout = new TimeSpan(hours: 0, minutes: 0, seconds: 40);

        private static TimeSpan _slowTimeOut = new TimeSpan(hours: 0, minutes: 5, seconds: 0);

        public static IList<IWebElement> IsVisible(Func<By, IList<IWebElement>> findElements, By query, bool slowLoading = false)
        {
            var timeout = slowLoading ? _slowTimeOut : _timeout;

            using (var cancellationTokenSource = new CancellationTokenSource(timeout))
            {
                while (true)
                {

                    var elements = findElements(query);

                    if (cancellationTokenSource.IsCancellationRequested)
                        return elements;

                    if (elements.Count == 0)
                        continue;
                    else
                        foreach (var element in elements)
                        {
                            if (IsVisible(element) == null)
                                return null;
                        }

                    return elements;
                }
            }


        }

        public static IWebElement IsVisible(Func<By, IWebElement> findElement, By query, bool slowLoading = false)
        {
            var timeout = slowLoading ? _slowTimeOut : _timeout;

            using (var cancellationTokenSource = new CancellationTokenSource(timeout))
            {
                while (true)
                {
                    try
                    {
                        if (cancellationTokenSource.IsCancellationRequested)
                            return null;
                        var element = findElement(query);
                        return IsVisible(element);
                    }
                    catch (NoSuchElementException ex)
                    {
                        continue;
                    }

                }
            }
        }

        private static IWebElement IsVisible(this IWebElement element)
        {
            using (var cancellationTokenSource = new CancellationTokenSource(_timeout))
            {
                while (true)
                {
                    if (element.Displayed)
                        return element;
                    if (cancellationTokenSource.IsCancellationRequested)
                        throw new ElementNotVisibleException("didn't find element within determined time");
                }
            }
        }

        public static bool IsNotVisible(Func<By, IWebElement> findElement, By query, bool slowLoading = false)
        {
            var timeout = slowLoading ? _slowTimeOut : _timeout;

            using (var cancellationTokenSource = new CancellationTokenSource(timeout))
            {
                while (true)
                {
                    try
                    {
                        if (cancellationTokenSource.IsCancellationRequested)
                            return false;
                        var element = findElement(query);
                        return IsNotVisible(element);
                    }
                    catch (NoSuchElementException ex)
                    {
                        return true;
                    }

                }
            }
        }

        private static bool IsNotVisible(this IWebElement element)
        {
            using (var cancellationTokenSource = new CancellationTokenSource(_timeout))
            {
                while (true)
                {
                    if (!element.Displayed)
                        return true;
                    if (cancellationTokenSource.IsCancellationRequested)
                        return false;
                }
            }
        }


    }
}
