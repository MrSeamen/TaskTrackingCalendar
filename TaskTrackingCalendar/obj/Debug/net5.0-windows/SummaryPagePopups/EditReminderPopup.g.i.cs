﻿#pragma checksum "..\..\..\..\SummaryPagePopups\EditReminderPopup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ADEC33D0D55DB040EC0CE82EA2FFD2AD398EFE04"
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
using TaskTrackingCalendar.SummaryPagePopups;


namespace TaskTrackingCalendar.SummaryPagePopups {
    
    
    /// <summary>
    /// EditReminderPopup
    /// </summary>
    public partial class EditReminderPopup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\SummaryPagePopups\EditReminderPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ClassComboBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\SummaryPagePopups\EditReminderPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TaskComboBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\SummaryPagePopups\EditReminderPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePicker;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\SummaryPagePopups\EditReminderPopup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ErrorTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TaskTrackingCalendar;component/summarypagepopups/editreminderpopup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SummaryPagePopups\EditReminderPopup.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ClassComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\..\SummaryPagePopups\EditReminderPopup.xaml"
            this.ClassComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ClassComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TaskComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.DatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.ErrorTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 31 "..\..\..\..\SummaryPagePopups\EditReminderPopup.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnSubmit);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

