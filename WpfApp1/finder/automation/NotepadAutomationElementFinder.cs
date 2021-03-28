using System.Collections.Generic;
using System.Windows.Automation;
using System.Linq;

namespace WpfApp1.finder.automation
{
    class NotepadAutomationElementFinder : WindowElementFinder
    {

        private Condition menuBarCondition = new PropertyCondition(AutomationElement.AutomationIdProperty, "MenuBar");
        private Condition menuItemCondition = new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "элемент меню");
        private Condition menuCondition = new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "меню");
        private Condition notePadCondition = new PropertyCondition(AutomationElement.ClassNameProperty, "Notepad");

        private AutomationElementToWindowElementMapper toWindowElementMapper = new AutomationElementToWindowElementMapper();

        private AutomationElement rootElement;

        private IEnumerable<WindowElement> menuBarElements;

        public NotepadAutomationElementFinder(AutomationElement rootElement)
        {
            this.rootElement = rootElement;

            menuBarElements = ToWindowElements(GetMenuBarElementsProperty(rootElement));
        }

        private IEnumerable<WindowElement> ToWindowElements(AutomationElementCollection collection)
        {
            List<WindowElement> mutableElements = new List<WindowElement>();

            foreach (AutomationElement element in collection)
            {
                mutableElements.Add(toWindowElementMapper.Map(element));
            }

            return mutableElements;
        }

        private AutomationElementCollection GetMenuBarElementsProperty(AutomationElement rootElement)
        {
            AutomationElement notePadElement = rootElement.FindFirst(TreeScope.Children, notePadCondition);
            AutomationElement menuBar = notePadElement.FindFirst(TreeScope.Children, menuBarCondition);
            return menuBar.FindAll(TreeScope.Children, Condition.TrueCondition);
        }

        public IEnumerable<WindowElement> FindAllElements(WindowElement src)
        {
            var floatingMenuBarElements = FindFloatingMenuElements(src);
            return floatingMenuBarElements.Concat(menuBarElements);
        }

        public IEnumerable<WindowElement> FindFloatingMenuElements(WindowElement src)
        {
            var currentNotepad = rootElement.FindFirst(TreeScope.Children, notePadCondition);
            if (currentNotepad != null)
            {
                var menuElements = currentNotepad.FindAll(TreeScope.Descendants, menuCondition);
                if (menuElements.Count > 0)
                {
                    AutomationElement menuHiddenElement = menuElements[menuElements.Count - 1];
                    return ToWindowElements(menuHiddenElement.FindAll(TreeScope.Children, menuItemCondition));
                }
            }
            return new List<WindowElement>();
        }
    }
}
