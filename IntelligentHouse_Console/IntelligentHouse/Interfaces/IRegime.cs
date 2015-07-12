using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentHouse
{
    interface IRegime
    {
        void SetNormalMode();
        void SetMinimumMode();
        void SetMaximumMode();
    }
}
