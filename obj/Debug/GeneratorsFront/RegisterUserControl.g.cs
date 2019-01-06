﻿#pragma checksum "..\..\..\GeneratorsFront\RegisterUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D7ABBAAEE2B61E3ADA50A31FB20E970906F4962D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CryptoDesktopApplication.GeneratorsFront;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace CryptoDesktopApplication.GeneratorsFront {
    
    
    /// <summary>
    /// RegisterUserControl
    /// </summary>
    public partial class RegisterUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lfsrTxtBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label RegisterNumberLabel;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label rCounter;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label rState;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button setRegister;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label rCurrentCounter;
        
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
            System.Uri resourceLocater = new System.Uri("/CryptoDesktopApplication;component/generatorsfront/registerusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
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
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.lfsrTxtBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
            this.lfsrTxtBox.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.BinaryStringPasting));
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
            this.lfsrTxtBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.BinaryStringValidationTextBox);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
            this.lfsrTxtBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.lfsr_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 12 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear_lfsr);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RegisterNumberLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.rCounter = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.rState = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.setRegister = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\GeneratorsFront\RegisterUserControl.xaml"
            this.setRegister.Click += new System.Windows.RoutedEventHandler(this.setRegister_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.rCurrentCounter = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
