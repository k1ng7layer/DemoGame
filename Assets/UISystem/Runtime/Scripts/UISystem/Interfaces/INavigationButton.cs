
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISystem.Interfaces
{
    public interface INavigationButton:IDisplayable
    {
        string Target { get; }
    }
}
