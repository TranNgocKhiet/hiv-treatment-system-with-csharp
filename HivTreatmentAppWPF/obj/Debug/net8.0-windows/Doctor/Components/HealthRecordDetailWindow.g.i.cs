﻿#pragma checksum "..\..\..\..\..\Doctor\Components\HealthRecordDetailWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2C209EFCBA195E24D83A32BF2DFE0EEC72DEDC50"
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


namespace HivTreatmentAppWPF.Doctor {
    
    
    /// <summary>
    /// HealthRecordDetailWindow
    /// </summary>
    public partial class HealthRecordDetailWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\..\..\..\Doctor\Components\HealthRecordDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RegimenSearchBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\Doctor\Components\HealthRecordDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RegimenComboBox;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\..\Doctor\Components\HealthRecordDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TestResultDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/HivTreatmentAppWPF;V1.0.0.0;component/doctor/components/healthrecorddetailwindow" +
                    ".xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Doctor\Components\HealthRecordDetailWindow.xaml"
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
            this.RegimenSearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\..\..\..\Doctor\Components\HealthRecordDetailWindow.xaml"
            this.RegimenSearchBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.RegimenSearchBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RegimenComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.TestResultDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            
            #line 126 "..\..\..\..\..\Doctor\Components\HealthRecordDetailWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteTestResult_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 133 "..\..\..\..\..\Doctor\Components\HealthRecordDetailWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 134 "..\..\..\..\..\Doctor\Components\HealthRecordDetailWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

