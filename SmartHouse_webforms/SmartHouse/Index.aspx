<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SmartHouse.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index</title>


    <link rel="stylesheet" type="text/css" href="Content/Style.css" />
     

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <table>
                <tr>
                    <td>
                        <asp:Image ID="home" runat="server" ImageUrl="~/Content/images/house.png" CssClass="image" />
                    </td>
                    <td>
                        <h1>Умный дом</h1>
                    </td>

                    <td>
                        <input type="button" class="box" value="Добавить компонент" onclick="ShowHide('test');" />
                        <div id="test" style="display: none">
                            <asp:DropDownList ID="DropDownList1" CssClass="box" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ButtonClickAdd">
                                <asp:ListItem Value="  "> </asp:ListItem>
                                <asp:ListItem Value="Lamp">Лампа</asp:ListItem>
                                <asp:ListItem Value="Conditioner">Кондиционер</asp:ListItem>
                                <asp:ListItem Value="KitchenVentilation">Вытяжка</asp:ListItem>
                                <asp:ListItem Value="Oven">Духовка</asp:ListItem>
                                <asp:ListItem Value="CookingSurface">Варочная поверхность</asp:ListItem>
                                <asp:ListItem Value="HeatingBoiler">Отопление</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </td>

                    <td>
                        <input type="button" class="box" value="Удалить компонент" onclick="ShowHide('test2');" />
                        <div id="test2" style="display: none">
                            <asp:DropDownList ID="DropDownListDelete" CssClass="box" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DropDownListDelete_SelectedIndexChanged">
                            </asp:DropDownList>

                        </div>
                    </td>

                    <td>
                        <input type="button" class="box" value="Отобразить компонент" onclick="ShowHide('test3');" />
                        <div id="test3" style="display: none">
                            <asp:DropDownList ID="DropDownListDisplay" CssClass="box" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListDisplay_SelectedIndexChanged">
                            </asp:DropDownList>

                        </div>
                    </td>

                </tr>
            </table>
        </div>
        <div class="images">
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="Lamp" CssClass="image" runat="server" ImageUrl="~/Content/images/lamp.png" CommandName="Lamp" OnCommand="Image_Command" />
                    </td>
                    <td>
                        <asp:ImageButton ID="Conditioner" runat="server" CssClass="image" ImageUrl="~/Content/images/conditioner.png" CommandName="Conditioner" OnCommand="Image_Command" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="DropDownListLamps" CssClass="drops" AutoPostBack="true" OnSelectedIndexChanged="DropDownListAll_SelectedIndexChanged" runat="server" Visible="false"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListConditioners" CssClass="drops" OnSelectedIndexChanged="DropDownListAll_SelectedIndexChanged" AutoPostBack="true" runat="server" Visible="false"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="HeatingBoiler" runat="server" CssClass="image" ImageUrl="~/Content/images/heater.png" CommandName="HeatingBoiler" OnCommand="Image_Command" />
                    </td>

                    <td>
                        <asp:ImageButton ID="KitchenVentilation" runat="server" CssClass="image" ImageUrl="~/Content/images/ventilation.png" CommandName="KitchenVentilation" OnCommand="Image_Command" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="DropDownListHeatingBoilers" CssClass="drops" AutoPostBack="true" OnSelectedIndexChanged="DropDownListAll_SelectedIndexChanged" runat="server" Visible="false"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListKitchenVentilation" CssClass="drops" AutoPostBack="true" OnSelectedIndexChanged="DropDownListAll_SelectedIndexChanged" runat="server" Visible="false"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="CookingSurface" runat="server" CssClass="image" ImageUrl="~/Content/images/burn.png" CommandName="CookingSurface" OnCommand="Image_Command" />
                    </td>

                    <td>
                        <asp:ImageButton ID="Oven" runat="server" CssClass="image" ImageUrl="~/Content/images/stove.png" CommandName="Oven" OnCommand="Image_Command" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="DropDownListCookingSurface" CssClass="drops" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListAll_SelectedIndexChanged" Visible="false"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListOven" CssClass="drops" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListAll_SelectedIndexChanged" Visible="false"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div class="display">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="true">
                <table>
                    <tr>
                        <td class="DisplayItem">
                            <asp:Label ID="Display" runat="server" CssClass="DisplayItem"></asp:Label>

                        </td>
                        <td>
                            <asp:Panel ID="PanelSwitch" Visible="false" runat="server">
                                
                                <asp:RadioButton ID="on" runat="server" Text="Вкл" GroupName="switcher" AutoPostBack="true" />
                                <asp:RadioButton ID="off" runat="server" Text="Выкл"  GroupName="switcher" AutoPostBack="true" />
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="PanelCookingSurfase" Visible="false" runat="server">
                                <br />
                                
                                <asp:DropDownList ID="Burners" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Burners_SelectedIndexChanged">
                                     <asp:ListItem Value=" ">Выбор комфорки</asp:ListItem>
                                    <asp:ListItem Value="Burner1">Правая верхняя</asp:ListItem>
                                    <asp:ListItem Value="Burner2">Левая верхняя</asp:ListItem>
                                    <asp:ListItem Value="Burner3">Левая нижняя</asp:ListItem>
                                    <asp:ListItem Value="Burner4">Правая нижняя</asp:ListItem>
                                </asp:DropDownList>
                            </asp:Panel>
                            <asp:Panel ID="PanelSwitchBurner" Visible="false" runat="server">
                                <asp:RadioButton ID="BurnerOn" runat="server" Text="Вкл" GroupName="switche1r" AutoPostBack="true" />
                                <asp:RadioButton ID="BurnerOf" runat="server" Text="Выкл" Checked="true" GroupName="switche1r" AutoPostBack="true" />
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="PanelSeason" Visible="false" runat="server">
                                <asp:RadioButton ID="winter" runat="server" Text="Зима" GroupName="season" AutoPostBack="true" />
                                <asp:RadioButton ID="summer" runat="server" Text="Лето" Checked="true" GroupName="season" AutoPostBack="true" />
                            </asp:Panel>
                            <asp:Panel ID="PanelForDoor" Visible="false" runat="server">
                                <asp:RadioButton ID="OpenDoor" runat="server" Text="Открыть" GroupName="Door" AutoPostBack="true" />
                                <asp:RadioButton ID="CloseDoor" runat="server" Text="Закрыть" Checked="true" GroupName="Door" AutoPostBack="true" />
                            </asp:Panel>
                            <br />
                            <asp:DropDownList ID="Regimes" runat="server" Visible="false" AutoPostBack="true">
                                <asp:ListItem Value="Min">Укажите режим работы</asp:ListItem>
                                <asp:ListItem Value="Min">Режим Минимум</asp:ListItem>
                                <asp:ListItem Value="Max">Режим Максимум</asp:ListItem>
                                <asp:ListItem Value="Normal">Режим Средний</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Panel ID="PanelChangeTemperatute" runat="server" Visible="false">
                                <asp:Button ID="IncreaseTemperature" runat="server" Text="Увеличить температуру" />
                                <asp:Button ID="DecreaseTemperature" runat="server" Text="Снизить температуру" />
                            </asp:Panel>
                              <asp:DropDownList ID="DropDownListOvenRegimes" runat="server" Visible="false" AutoPostBack="true">
                                <asp:ListItem Value="VG">Вентилятор + гриль + нижний нагрев</asp:ListItem>
                                <asp:ListItem Value="V">Кольцевой нагревательный элемент + вентилятор</asp:ListItem>
                                <asp:ListItem Value="Gril">Гриль</asp:ListItem>
                                <asp:ListItem Value="BU">Верхний нагрев + нижний нагрев</asp:ListItem>
                                  <asp:ListItem Value="Up">Верхний нагрев</asp:ListItem>
                                   <asp:ListItem Value="bottom">Нижний нагрев</asp:ListItem>
                                   <asp:ListItem Value="TurboGril">Турбогриль</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Panel ID="SetTemperature" Visible="false" runat="server">
                                <asp:TextBox ID="Set" runat="server" Text=""></asp:TextBox>
                                <asp:Button ID="SetTemp" runat="server" Text="Установить температуру" />
                            </asp:Panel>
                            <asp:Label ID="DisplayError" runat ="server" ForeColor="Red"> </asp:Label>

                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
        </div>

    </form>
    <script type="text/javascript" src="Scripts/Script.js"></script>
</body>
</html>
