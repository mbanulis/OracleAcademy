using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse
{
    public class ComponentList
    {
        private Dictionary<int, Device> allComponents;

        public Dictionary<int, Device> AllComponents
        {
            get { return allComponents; }
            set { allComponents = value; }
        }
        public ComponentList()
        {
            Lamp L = new Lamp();
            L.DeviceName = "Лампа";
            Conditioner C = new Conditioner();
            C.DeviceName = "Кондиционер";
            HeatingBoiler H = new HeatingBoiler();
            H.DeviceName = "Котел";
            KitchenVentilation K = new KitchenVentilation();
            K.DeviceName = "Кухонная вытяжка";
            CookingSurfase CS = new CookingSurfase("Варочная поверхность", false,new Burner(), new Burner(), new Burner(), new Burner());
            Oven O = new Oven();
            O.DeviceName = "Духовка";

            AllComponents = new Dictionary<int, Device>();
            AllComponents.Add(1, L);
            AllComponents.Add(2, C);
            AllComponents.Add(3, H);
            AllComponents.Add(4, K);
           AllComponents.Add(5, CS);
            AllComponents.Add(6, O);

        }
        
        public override string ToString()
        {
            string all = "";
            foreach(Device i in AllComponents.Values)
            {
                all+= i.ToString() + "<br />";
               
            }
            return all;
           // return AllComponents["L1"].ToString() + "</ br> " + AllComponents["C1"].ToString()+ "</ br> " + AllComponents["H1"].ToString() +"< /br>" + AllComponents["KV"].ToString();
        }
      public Device AddComponent(string typeDevice)
        {
            int temp = AllComponents.Keys.Max();
            int key=++temp;
            Device d = null;
            switch(typeDevice)
            {
                case"Lamp":
                    Lamp l = new Lamp();
                    l.DeviceName = "Лампа";
                    AllComponents.Add(key, l);
                    d = l;
                    break; 
                case "Conditioner":
                    Conditioner c = new Conditioner();
                    c.DeviceName = "Кондиционер";
                    AllComponents.Add(key,c);
                    d = c;
                    break;
                case"KitchenVentilation":
                    KitchenVentilation k = new KitchenVentilation();
                    k.DeviceName = "Кухонная вытяжка";
                    AllComponents.Add(key, k);
                    d= k;
                    break;
                case "Oven":
                    Oven o = new Oven();
                    o.DeviceName = "Духовка";
                    AllComponents.Add(key, o);
                    d= o;
                    break;
                case "CookingSurface":
                    CookingSurfase cs = new CookingSurfase("Варочная поверхность", false, new Burner(), new Burner(), new Burner(), new Burner());
                    AllComponents.Add(key,cs );
                    d= cs;
                    break;
                case "HeatingBoiler":
                    HeatingBoiler h = new HeatingBoiler();
                    h.DeviceName = "Котел";
                    AllComponents.Add(key,h );
                     d= h;
                     break;
            }
            return d;

        }
      public void DeleteComponent(Dictionary<int, Device> obj, int s)
      {
          
          if (obj.ContainsKey(s))
          {
              obj.Remove(s);
             
          }

      }

    }
}