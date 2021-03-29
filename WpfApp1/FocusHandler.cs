using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using ScreanReader.finder;
using ScreanReader.finder.automation;
using Automation = System.Windows.Automation;

namespace ScreanReader
{
    class FocusHandler : ISubscriber
    {
        private WindowElementFinder finder;
        private Speaker speaker;
        public FocusHandler(WindowElementFinder finder, Speaker speaker)
        {
            this.finder = finder;
            this.speaker = speaker;
        }

        private AutomationFocusChangedEventHandler focusHandler = null;
        public void SubscribeToFocusChange()
        {
            focusHandler = new AutomationFocusChangedEventHandler(OnFocusChange);
            Automation.Automation.AddAutomationFocusChangedEventHandler(focusHandler);
        }

        public void OnFocusChange(object src, AutomationFocusChangedEventArgs e)
        {
            var sourceElement = src as AutomationElement;
            var allElements = finder.FindAllElements(new WindowElement(sourceElement.Current.AutomationId, sourceElement.Current.Name));

            foreach (WindowElement element in allElements)
            {
                if (element.Id == sourceElement.Current.AutomationId && element.Name == sourceElement.Current.Name && sourceElement.Current.HasKeyboardFocus)
                {
                    speaker.Speak(sourceElement.Current.Name);
                }
            }
        }

        public void UnsubscribeFocusChange()
        {
            if (focusHandler != null)
            {
                Automation.Automation.RemoveAutomationFocusChangedEventHandler(focusHandler);
            }
        }
    }
}
