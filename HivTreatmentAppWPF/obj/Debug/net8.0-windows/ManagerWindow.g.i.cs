﻿#pragma checksum "..\..\..\ManagerWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EFD86C00711A73427FE3535D4215F856957EA8FC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HivTreatmentAppWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace HivTreatmentAppWPF {
    
    
    /// <summary>
    /// ManagerWindow
    /// </summary>
    public partial class ManagerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtGreeting;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToRequestListPageButton;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToMangerSchedulePageButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToUserListPageButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\ManagerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frMain;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HivTreatmentAppWPF;component/managerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ManagerWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtGreeting = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.ToRequestListPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\ManagerWindow.xaml"
            this.ToRequestListPageButton.Click += new System.Windows.RoutedEventHandler(this.ToRequestListPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ToMangerSchedulePageButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\ManagerWindow.xaml"
            this.ToMangerSchedulePageButton.Click += new System.Windows.RoutedEventHandler(this.ToMangerSchedulePageButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ToUserListPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\ManagerWindow.xaml"
            this.ToUserListPageButton.Click += new System.Windows.RoutedEventHandler(this.ToUserListPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 48 "..\..\..\ManagerWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LogoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.frMain = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

