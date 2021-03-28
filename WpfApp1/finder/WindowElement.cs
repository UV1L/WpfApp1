using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreanReader.finder
{
    class WindowElement
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public WindowElement(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
