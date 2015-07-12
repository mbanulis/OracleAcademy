using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentHouse
{
    enum EnumOvenMode
    {
        Fan_grill_bottomHeat,//Вентилятор + гриль + нижний нагрев
        RingHeatingElement_fan, //Кольцевой нагревательный элемент + вентилятор
        grill,//Гриль
        topHeating_bottomHeat,//Верхний нагрев + нижний нагрев
        topHeating, //Верхний нагрев
        bottomHeat,//нижний нагрев
        turboGrill//   


    }
}
