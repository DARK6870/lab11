﻿#pragma checksum "..\..\..\..\WindowsCRUD\OrdersCRUD.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8A38E77EBAC5DDCB870A4DDFF79F8DB3FD4B9955"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using lab11.WindowsCRUD;


namespace lab11.WindowsCRUD {
    
    
    /// <summary>
    /// OrdersCRUD
    /// </summary>
    public partial class OrdersCRUD : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\WindowsCRUD\OrdersCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Status_tb;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\WindowsCRUD\OrdersCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save_changes_btn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\WindowsCRUD\OrdersCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete_btn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/lab11;component/windowscrud/orderscrud.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\WindowsCRUD\OrdersCRUD.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Status_tb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.Save_changes_btn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\WindowsCRUD\OrdersCRUD.xaml"
            this.Save_changes_btn.Click += new System.Windows.RoutedEventHandler(this.Save_changes_btn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Delete_btn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\WindowsCRUD\OrdersCRUD.xaml"
            this.Delete_btn.Click += new System.Windows.RoutedEventHandler(this.Delete_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

