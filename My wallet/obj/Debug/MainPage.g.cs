﻿

#pragma checksum "C:\Users\youssef  adel\Documents\Visual Studio 2013\Projects\My wallet\My wallet\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9834F8FC972A73E2A395ADA62CCAF695"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace My_wallet
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 18 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Pivot)(target)).SelectionChanged += this.Pivot_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 90 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.wallet_tap;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 91 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.his_tap;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 76 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.emptyHistory_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 77 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Undo_Click;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 41 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.addMoney;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 42 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.subMoney;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


