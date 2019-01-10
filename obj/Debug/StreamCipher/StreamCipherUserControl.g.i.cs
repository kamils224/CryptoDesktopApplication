﻿#pragma checksum "..\..\..\StreamCipher\StreamCipherUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E4D181ED72BF65A6128A472468D12707305E321B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CryptoDesktopApplication.LoadingControl;
using CryptoDesktopApplication.StreamCipher;
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


namespace CryptoDesktopApplication.StreamCipher {
    
    
    /// <summary>
    /// StreamCipherUserControl
    /// </summary>
    public partial class StreamCipherUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputEncrypt;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loadKeyBtn;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox txtFile;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox binFile;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox outputEncrypt;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loadFileEncrypt;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button encryptFileBtn;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button encryptBtn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CryptoDesktopApplication.LoadingControl.LoadingAnimation LoadingCircle;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock filenameInfo;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid inputFormat;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon seriesTest;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock keyFileInfo;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid outputFormat;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock keyFilenameInfo;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock fileLengthInfo;
        
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
            System.Uri resourceLocater = new System.Uri("/CryptoDesktopApplication;component/streamcipher/streamcipherusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.inputEncrypt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.loadKeyBtn = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
            this.loadKeyBtn.Click += new System.Windows.RoutedEventHandler(this.loadKeyBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtFile = ((System.Windows.Controls.CheckBox)(target));
            
            #line 14 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
            this.txtFile.Checked += new System.Windows.RoutedEventHandler(this.txtFile_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.binFile = ((System.Windows.Controls.CheckBox)(target));
            
            #line 15 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
            this.binFile.Checked += new System.Windows.RoutedEventHandler(this.binFile_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.outputEncrypt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.loadFileEncrypt = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
            this.loadFileEncrypt.Click += new System.Windows.RoutedEventHandler(this.loadFileEncrypt_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.encryptFileBtn = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
            this.encryptFileBtn.Click += new System.Windows.RoutedEventHandler(this.encryptFileBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.encryptBtn = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
            this.encryptBtn.Click += new System.Windows.RoutedEventHandler(this.encryptBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.LoadingCircle = ((CryptoDesktopApplication.LoadingControl.LoadingAnimation)(target));
            return;
            case 10:
            this.filenameInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.inputFormat = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            this.seriesTest = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 13:
            this.keyFileInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.outputFormat = ((System.Windows.Controls.Grid)(target));
            return;
            case 15:
            
            #line 45 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.ChangeOutputToAscii);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 48 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.ChangeOutputToHex);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 51 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.ChangeOutputToBase64);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 54 "..\..\..\StreamCipher\StreamCipherUserControl.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.ChangeOutputToUnicode);
            
            #line default
            #line hidden
            return;
            case 19:
            this.keyFilenameInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 20:
            this.fileLengthInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

