using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHouse
{
    public partial class Index : System.Web.UI.Page
    {
        ComponentList list;
        ControlCollection controlls = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                list = (ComponentList)Session["Key"];
                on.CheckedChanged += on_CheckedChanged;
                off.CheckedChanged += on_CheckedChanged;
                summer.CheckedChanged += season__CheckedChanged;
                winter.CheckedChanged += season__CheckedChanged;
                OpenDoor.CheckedChanged += Door_CheckedChanged;
                CloseDoor.CheckedChanged += Door_CheckedChanged;
                Regimes.SelectedIndexChanged += Regimes_SelectedIndexChanged;
                IncreaseTemperature.Click += ChangeTemperature_Click;
                DecreaseTemperature.Click += ChangeTemperature_Click;
                SetTemp.Click += SetTemp_Click;
                BurnerOn.CheckedChanged += BurnerOn_CheckedChanged;
                BurnerOf.CheckedChanged += BurnerOn_CheckedChanged;
                DropDownListOvenRegimes.SelectedIndexChanged += DropDownListOvenRegimes_SelectedIndexChanged;

            }
            else
            {
                list = new ComponentList();
                Session["Key"] = list;
                DropDownCreate();
            }
        }
       
        void BurnerOn_CheckedChanged(object sender, EventArgs e)
        {
            CookingSurfase c = (CookingSurfase)Session["d"];
            string tmp = (string)Session["burn"];
            if (BurnerOn.Checked)
            {
                switch (tmp)
                {
                    case "Burner1":
                        c.SwitchOnUpperRightBurner();
                        break;
                    case "Burner2":
                        c.SwitchOnUpperLeftBurner();
                        break;
                    case "Burner3":
                        c.SwitchOnBottomLeftBurner();
                        break;
                    case "Burner4":
                        c.SwitchOnBottomRightBurner();
                        break;
                }
            }
            else
            {
                switch (tmp)
                {
                    case "Burner1":
                        c.SwitchOffUpperRightBurner();
                        break;
                    case "Burner2":
                        c.SwitchOffUpperLeftBurner();
                        break;
                    case "Burner3":
                        c.SwitchOffBottomLeftBurner();
                        break;
                    case "Burner4":
            c.SwitchOffBottomRightBurner();
                         break;
                }
            }
            Display.Text = DisplayInfo(c);
        }

        void SetTemp_Click(object sender, EventArgs e)
        {
            Device d = (Device)Session["d"];
            if (d.DeviceState == true)
            {
                int temp;
                bool res = Int32.TryParse(Set.Text, out temp);
                if (res)
                {
                    ((ITemperature)d).Temperature = temp;
                }
                else
                {
                    Set.Text = "Укажите цифру";

                }
                Display.Text = DisplayInfo(d);
            }
            else
            {
                DisplayError.Text = "Включите устройство";
            }
        }

        void Door_CheckedChanged(object sender, EventArgs e)
        {
            Device d = (Device)Session["d"];
            if (OpenDoor.Checked)
            {
                ((IOpenClose)d).Opened();
            }
            else
            {
                ((IOpenClose)d).Closed();
            }
            Session["d"] = d;
            Display.Text = DisplayInfo(d);

        }
        public void AddControlMenu(ControlCollection c)
        {

            for (int i = 0; i < c.Count; i++)
            {
                PanelSwitch.Controls.Add(c[i]);
            }
        }
        private ControlCollection MenuCol(Device d)
        {
            Session["d"] = d;
            ControlCollection controlls = new ControlCollection(PlaceHolder1);
            if (d is ISwitcher)
            {
                PanelSwitch.Visible = true;
            }

            if (d is IModeSeason)
            {
                PanelSeason.Visible = true;
            }
            if (d is IOpenClose)
            {
                PanelForDoor.Visible = true;
            }
            if (d is IRegime)
            {
                Regimes.Visible = true;
            }
            if (d is IRegulator)
            {
                PanelChangeTemperatute.Visible = true;

            }
            if (d is ITemperature)
            {
                SetTemperature.Visible = true;
            }
            if (d is Oven)
            {
                DropDownListOvenRegimes.Visible = true;
               
            }

            Session["d"] = d;
            return controlls;
        }

        void DropDownListOvenRegimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device d = (Device)Session["d"];
            if (d.DeviceState == true)
            {
                switch (DropDownListOvenRegimes.SelectedValue)
                {
                    case "VG":
                        ((Oven)d).setFanGrillBottomHeat();
                        break;
                    case "V":
                        ((Oven)d).SetRingHeatingElementFan();
                        break;
                    case "Gril":
                        ((Oven)d).SetGrill();
                        break;
                    case "Up":
                        ((Oven)d).SetTopHeating();
                        break;
                    case "BU":
                        ((Oven)d).SetTopHeatingBottomHeat();
                        break;
                    case "bottom":
                        ((Oven)d).SetBottomHeat();
                        break;
                    case "TurboGril":
                        ((Oven)d).SetGrill();
                        break;
                }
                Display.Text = DisplayInfo(d);
            }
            else
            {
               
                DisplayError.Text = "Включите устройство";
            }
        }
        void ChangeTemperature_Click(object sender, EventArgs e)
        {
            Device d = (Device)Session["d"];
            if (d.DeviceState == true)
            {
                if (((Button)sender).ID == "IncreaseTemperature")
                {
                    ((IRegulator)d).Increasing();
                }
                else
                {
                    ((IRegulator)d).Decreasing();
                }
                Display.Text = DisplayInfo(d);
            }
            else
            {
                DisplayError.Text = "Включите устройство";
            }
        }

        void Regimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device d = (Device)Session["d"];
            if (d.DeviceState == true)
            {
                string tmp = (string)Session["burn"];
                if (Regimes.SelectedValue == "Min")
                {
                    if (d is CookingSurfase)
                    {

                        switch (tmp)
                        {
                            case "Burner1":
                                ((CookingSurfase)d).SetMinimumModeURB();
                                break;
                            case "Burner2":
                                ((CookingSurfase)d).SetMinimumModeULB();
                                break;
                            case "Burner3":
                                ((CookingSurfase)d).SetMinimumModeBLB();
                                break;
                            case "Burner4":
                                ((CookingSurfase)d).SetMinimumModeBRB();
                                break;
                        }

                    }
                    else
                    {
                        ((IRegime)d).SetMinimumMode();
                    }
                }
                else if (Regimes.SelectedValue == "Max")
                {
                    if (d is CookingSurfase)
                    {

                        switch (tmp)
                        {
                            case "Burner1":
                                ((CookingSurfase)d).SetMaximumModeURB();
                                break;
                            case "Burner2":
                                ((CookingSurfase)d).SetMaximumModeULB();
                                break;
                            case "Burner3":
                                ((CookingSurfase)d).SetMaximumModeBLB();
                                break;
                            case "Burner4":
                                ((CookingSurfase)d).SetMaximumModeBRB();
                                break;
                        }

                    }
                    else
                    {
                        ((IRegime)d).SetMaximumMode();
                    }
                }
                else
                {
                    if (d is CookingSurfase)
                    {

                        switch (tmp)
                        {
                            case "Burner1":
                                ((CookingSurfase)d).SetNormalModeURB();
                                break;
                            case "Burner2":
                                ((CookingSurfase)d).SetNormalModeULB();
                                break;
                            case "Burner3":
                                ((CookingSurfase)d).SetNormalModeBLB();
                                break;
                            case "Burner4":
                                ((CookingSurfase)d).SetNormalModeBRB();
                                break;
                        }

                    }
                    else
                    {
                        ((IRegime)d).SetNormalMode();
                    }
                }
                Display.Text = DisplayInfo(d);
            }
            else
            {
                DisplayError.Text = "Включите устройство";
            }
        }

        void season__CheckedChanged(object sender, EventArgs e)
        {
            Device d = (Device)Session["d"];
            if (d.DeviceState == true)
            {
                if (winter.Checked)
                {
                    ((IModeSeason)d).SetWinterMode();
                }
                else
                {
                    ((IModeSeason)d).SetSummerMode();
                }
                Display.Text = DisplayInfo(d);
            }
            else
            {
                DisplayError.Text = "Включите устройство";
            }

        }

        void on_CheckedChanged(object sender, EventArgs e)
        {
            Device d = (Device)Session["d"];

            if (on.Checked)
            {
                DisplayError.Text = "";
                ((ISwitcher)d).SwitchOn();
                if (d is CookingSurfase)
                {
                    PanelCookingSurfase.Visible = true;
                }
                Session["d"] = d;

            }

            else
            {
                ((ISwitcher)d).SwitchOff();
                if (d is CookingSurfase)
                {
                    PanelCookingSurfase.Visible = false;
                    PanelSwitchBurner.Visible = false;
                    Regimes.Visible = false;
                }
                Session["d"] = d;
            }

            Display.Text = DisplayInfo(d);

        }
        public void ButtonClickAdd(object sender, System.EventArgs e)
        {
            OffAllPanels();
            Device d = null;
            Session["Key"] = list;
            d = list.AddComponent(DropDownList1.SelectedItem.Value);
            if (d is Lamp)
            {
                Display.Text = "Устройство добавлено" + "<br />" + d.ToString();
            }
            if (d is Conditioner)
            {
                Display.Text = "Устройство добавлено" + "<br />" + d.ToString();
            }
            if (d is HeatingBoiler)
            {
                Display.Text = "Устройство добавлено" + "<br />" + d.ToString();
            }
            if (d is Oven)
            {
                Display.Text = "Устройство добавлено" + "<br />" + d.ToString();
            }
            if (d is CookingSurfase)
            {
                Display.Text = "Устройство добавлено" + "<br />" + d.ToString();
            }
            if (d is KitchenVentilation)
            {
                Display.Text = "Устройство добавлено" + "<br />" + d.ToString();
            }
            DropDownCreate();
        }

        protected void Image_Command(object sender, CommandEventArgs e)
        {
            DropDownListConditioners.Items.Clear();
            DropDownListHeatingBoilers.Items.Clear();
            DropDownListCookingSurface.Items.Clear();
            DropDownListKitchenVentilation.Items.Clear();
            DropDownListLamps.Items.Clear();
            DropDownListOven.Items.Clear();
            list = (ComponentList)Session["Key"];
            DropDownListLamps.Items.Add("Выберите устройство");
            DropDownListConditioners.Items.Add("Выберите устройство ");
            DropDownListOven.Items.Add("Выберите устройство ");
            DropDownListKitchenVentilation.Items.Add("Выберите устройство ");
            DropDownListCookingSurface.Items.Add("Выберите устройство ");
            DropDownListHeatingBoilers.Items.Add("Выберите устройство");
            Display.Text = "";

            if (e.CommandName == "Lamp")
            {
                foreach (KeyValuePair<int, Device> keyValue in list.AllComponents)
                {
                    if (keyValue.Value.DeviceName == "Лампа")
                    {
                        DropDownListLamps.Items.Add("ID: " + keyValue.Key.ToString() + " " + keyValue.Value.DeviceName);
                    }
                }
                DropDownListLamps.Visible = true;

            }
            if (e.CommandName == "Conditioner")
            {
                foreach (KeyValuePair<int, Device> keyValue in list.AllComponents)
                {
                    if (keyValue.Value.DeviceName == "Кондиционер")
                    {
                        DropDownListConditioners.Items.Add("ID: " + keyValue.Key.ToString() + " " + keyValue.Value.DeviceName);
                    }
                }

                DropDownListConditioners.Visible = true;

            }
            if (e.CommandName == "HeatingBoiler")
            {
                foreach (KeyValuePair<int, Device> keyValue in list.AllComponents)
                {
                    if (keyValue.Value.DeviceName == "Котел")
                    {
                        DropDownListHeatingBoilers.Items.Add("ID: " + keyValue.Key.ToString() + " " + keyValue.Value.DeviceName);
                    }
                }

                DropDownListHeatingBoilers.Visible = true;
                DropDownListHeatingBoilers.SelectedIndexChanged += DropDownListAll_SelectedIndexChanged;

            }
            if (e.CommandName == "KitchenVentilation")
            {
                foreach (KeyValuePair<int, Device> keyValue in list.AllComponents)
                {
                    if (keyValue.Value.DeviceName == "Кухонная вытяжка")
                    {

                        DropDownListKitchenVentilation.Items.Add("ID: " + keyValue.Key.ToString() + " " + keyValue.Value.DeviceName);
                    }
                }
               
                DropDownListKitchenVentilation.Visible = true;
                DropDownListKitchenVentilation.SelectedIndexChanged += DropDownListAll_SelectedIndexChanged;
            }
            if (e.CommandName == "CookingSurface")
            {

                foreach (KeyValuePair<int, Device> keyValue in list.AllComponents)
                {
                    if (keyValue.Value.DeviceName == "Варочная поверхность")
                    {
                        DropDownListCookingSurface.Items.Add("ID: " + keyValue.Key.ToString() + " " + keyValue.Value.DeviceName);
                    }
                }

                DropDownListCookingSurface.Visible = true;
                DropDownListCookingSurface.SelectedIndexChanged += DropDownListAll_SelectedIndexChanged;
            }
            if (e.CommandName == "Oven")
            {
                foreach (KeyValuePair<int, Device> keyValue in list.AllComponents)
                {
                    if (keyValue.Value.DeviceName == "Духовка")
                    {
                        DropDownListOven.Items.Add("ID: " + keyValue.Key.ToString() + " " + keyValue.Value.DeviceName);
                    }
                }

                DropDownListOven.Visible = true;
                DropDownListOven.SelectedIndexChanged += DropDownListAll_SelectedIndexChanged;
            }

            OffAllPanels();
       

        }
        protected void OffAllPanels()
        {
            PanelSwitch.Visible = false;
            PanelSeason.Visible = false;
            PanelForDoor.Visible = false;
            PanelChangeTemperatute.Visible = false;
            Regimes.Visible = false;
            SetTemperature.Visible = false;
            PanelCookingSurfase.Visible = false;
        }
        protected string DisplayInfo(Device d)
        {
            string info = null;
            if (d is Lamp)
            {
                info = ((Lamp)d).ToString();
            }
            if (d is Conditioner)
            {
                info = ((Conditioner)d).ToString();
            } if (d is HeatingBoiler)
            {
                info = ((HeatingBoiler)d).ToString();
            }
            if (d is CookingSurfase)
            {
                info = ((CookingSurfase)d).ToString();
            }
            if (d is Oven)
            {
                info = ((Oven)d).ToString();
            }
            if (d is KitchenVentilation)
            {
                info = ((KitchenVentilation)d).ToString();
            }

            return info;
        }
        public void CheckState(Device d)
        {
            if(d.DeviceState==false)
            {
                off.Checked = true;
            }
            else
            {
                on.Checked = true;
            }
        }
        protected void DropDownListAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            list = (ComponentList)Session["Key"];

            switch (((DropDownList)sender).ClientID)
            {
                case "DropDownListLamps":
                    for (int i = 0; i < DropDownListLamps.Items.Count; i++)
                    {
                        if (DropDownListLamps.Items[i].Selected)
                        {
                            string d = DropDownListLamps.Items[i].Value;
                            string[] s = d.Split(new char[] { ' ' });
                            int a = Int32.Parse(s[1]);

                            ControlCollection col = MenuCol(list.AllComponents[a]);
                            CheckState(list.AllComponents[a]);
                            AddControlMenu(col);
                           
                            Display.Text = list.AllComponents[a].ToString();
                        }
                    }
                    DropDownListLamps.Visible = false;
                    break;
                case "DropDownListConditioners":
                    for (int i = 0; i < DropDownListConditioners.Items.Count; i++)
                    {
                        if (DropDownListConditioners.Items[i].Selected)
                        {
                            string d = DropDownListConditioners.Items[i].Value;
                            string[] s = d.Split(new char[] { ' ' });
                            int a = Int32.Parse(s[1]);

                            ControlCollection col = MenuCol(list.AllComponents[a]);
                            CheckState(list.AllComponents[a]);
                            AddControlMenu(col);
                          
                            Display.Text = list.AllComponents[a].ToString();
                        }
                    }
                    DropDownListConditioners.Visible = false;
                    break;
                case "DropDownListHeatingBoilers":
                    for (int i = 0; i < DropDownListHeatingBoilers.Items.Count; i++)
                    {
                        if (DropDownListHeatingBoilers.Items[i].Selected)
                        {
                            string d = DropDownListHeatingBoilers.Items[i].Value;
                            string[] s = d.Split(new char[] { ' ' });
                            int a = Int32.Parse(s[1]);
                            ControlCollection col = MenuCol(list.AllComponents[a]);
                            CheckState(list.AllComponents[a]);
                                     AddControlMenu(col);
                                     
                            Display.Text = list.AllComponents[a].ToString();
                        }
                    }
                    DropDownListHeatingBoilers.Visible = false;
                    break;
                case "DropDownListKitchenVentilation":
                    for (int i = 0; i < DropDownListKitchenVentilation.Items.Count; i++)
                    {
                        if (DropDownListKitchenVentilation.Items[i].Selected)
                        {
                            string d = DropDownListKitchenVentilation.Items[i].Value;
                            string[] s = d.Split(new char[] { ' ' });
                            int a = Int32.Parse(s[1]);

                            ControlCollection col = MenuCol(list.AllComponents[a]);
                            CheckState(list.AllComponents[a]);
                            AddControlMenu(col);
                            
                            Display.Text = list.AllComponents[a].ToString();
                        }
                    }
                    DropDownListKitchenVentilation.Visible = false;
                    break;
                case "DropDownListCookingSurface":
                    for (int i = 0; i < DropDownListCookingSurface.Items.Count; i++)
                    {
                        if (DropDownListCookingSurface.Items[i].Selected)
                        {
                            string d = DropDownListCookingSurface.Items[i].Value;
                            string[] s = d.Split(new char[] { ' ' });
                            int a = Int32.Parse(s[1]);
                            ControlCollection col = MenuCol(list.AllComponents[a]);
                            Session["CS"] = list.AllComponents[a];
                            CheckState(list.AllComponents[a]);
                            AddControlMenu(col);
                          
                            Display.Text = list.AllComponents[a].ToString();
                        }
                    }
                    DropDownListCookingSurface.Visible = false;
                    break;
                case "DropDownListOven":
                    for (int i = 0; i < DropDownListOven.Items.Count; i++)
                    {
                        if (DropDownListOven.Items[i].Selected)
                        {
                            string d = DropDownListOven.Items[i].Value;
                            string[] s = d.Split(new char[] { ' ' });
                            int a = Int32.Parse(s[1]);
                            ControlCollection col = MenuCol(list.AllComponents[a]);
                            CheckState(list.AllComponents[a]);
                            AddControlMenu(col);
                            Display.Text = list.AllComponents[a].ToString();
                        }
                    }
                    DropDownListOven.Visible = false;
                    break;
            }
        }
        protected void DropDownCreate()
        {
            DropDownListDelete.Items.Clear();
            DropDownListDisplay.Items.Clear();
            list = (ComponentList)Session["Key"];
            DropDownListDelete.Items.Add("Выбор устройства");
            DropDownListDisplay.Items.Add("Выбор устройства");
            foreach (KeyValuePair<int, Device> k in list.AllComponents)
            {
                DropDownListDelete.Items.Add("ID " + k.Key.ToString() + " " + k.Value.DeviceName.ToString());
                DropDownListDisplay.Items.Add("ID " + k.Key.ToString() + " " + k.Value.DeviceName.ToString());
            }
            Session["Key"] = list;

        }

        protected void DropDownListDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            OffAllPanels();
            list = (ComponentList)Session["Key"];
            for (int i = 0; i < DropDownListDelete.Items.Count; i++)
            {
                if (DropDownListDelete.Items[i].Selected)
                {
                    string d = DropDownListDelete.Items[i].Value;
                    string[] s = d.Split(new char[] { ' ' });
                    int a = Int32.Parse(s[1]);
                    list.DeleteComponent(list.AllComponents, a);
                    Session["Key"] = list;
                    DropDownListDelete.Items.Remove(DropDownListDelete.SelectedItem);
                    Display.Text = "Компонент удален";
                }

            }
            DropDownCreate();
        }
        protected void Burners_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Burners.Items.Count; i++)
            {
                if (Burners.Items[i].Selected)
                {

                    PanelSwitchBurner.Visible = true;
                    Regimes.Visible = true;
                    Session["burn"] = Burners.Items[i].Value.ToString();
                }

            }
        }
        protected void DropDownListDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            OffAllPanels();
            string d = DropDownListDisplay.SelectedItem.Value;
            string[] s = d.Split(new char[] { ' ' });
            int a = Int32.Parse(s[1]);
            Display.Text = list.AllComponents[a].ToString();
        }

    }
}