﻿#pragma checksum "..\..\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2395E92E54088CDF591CB9DF09619B0D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Tfour_Main {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_playerOneLogin;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid_gameOptions;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Play;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_ForgetPassword;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Register;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textbox_Username;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_View_Profile;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox_LoginOne;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Tfour_Main;component/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Login.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Button_playerOneLogin = ((System.Windows.Controls.Button)(target));
            
            #line 6 "..\..\Login.xaml"
            this.Button_playerOneLogin.Click += new System.Windows.RoutedEventHandler(this.Button_playerOneLogin_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Grid_gameOptions = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Button_Play = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\Login.xaml"
            this.Button_Play.Click += new System.Windows.RoutedEventHandler(this.Button_Play_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Button_ForgetPassword = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\Login.xaml"
            this.Button_ForgetPassword.Click += new System.Windows.RoutedEventHandler(this.Button_ForgetPassword_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Button_Register = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Login.xaml"
            this.Button_Register.Click += new System.Windows.RoutedEventHandler(this.Button_Register_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Textbox_Username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Button_View_Profile = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Login.xaml"
            this.Button_View_Profile.Click += new System.Windows.RoutedEventHandler(this.Button_View_Profile_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PasswordBox_LoginOne = ((System.Windows.Controls.PasswordBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

