﻿#pragma checksum "..\..\..\SummaryPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25CCCA614A5FF0F1562EEC9CC8E16C0A37DB5BD0"
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
using TaskTrackingCalendar;


namespace TaskTrackingCalendar {
    
    
    /// <summary>
    /// SummaryPage
    /// </summary>
    public partial class SummaryPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\SummaryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SortPriorityCheckBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\SummaryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ClassComboBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\SummaryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TaskListView;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\SummaryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ReminderListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TaskTrackingCalendar;component/summarypage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SummaryPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\SummaryPage.xaml"
            ((TaskTrackingCalendar.SummaryPage)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.OnClose);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SortPriorityCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 21 "..\..\..\SummaryPage.xaml"
            this.SortPriorityCheckBox.Checked += new System.Windows.RoutedEventHandler(this.PriorityCheckChanged);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\SummaryPage.xaml"
            this.SortPriorityCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.PriorityCheckChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ClassComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\..\SummaryPage.xaml"
            this.ClassComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ClassComboBoxSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 24 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnRefreshPage);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TaskListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.ReminderListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            
            #line 81 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnCreateClass);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 84 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnEditClass);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 87 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnDeleteClass);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 90 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnCreateTask);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 93 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnEditTask);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 96 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnDeleteTask);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 99 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnCreateReminder);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 102 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnEditReminder);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 105 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnDeleteReminder);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 109 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnSaveData);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 112 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnLoadData);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 117 "..\..\..\SummaryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnOpenCalendar);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

