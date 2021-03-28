using System.Collections.Generic;
using System.Windows.Automation;
using ScreanReader.finder;

namespace ScreanReader
{
    interface WindowElementFinder
    {
        IEnumerable<WindowElement> FindAllElements(WindowElement src);

        IEnumerable<WindowElement> FindFloatingMenuElements(WindowElement src);

    }
}
