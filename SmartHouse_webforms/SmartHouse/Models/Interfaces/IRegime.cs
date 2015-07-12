using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    interface IRegime
    {
        void SetNormalMode();
        void SetMinimumMode();
        void SetMaximumMode();
    }
}
