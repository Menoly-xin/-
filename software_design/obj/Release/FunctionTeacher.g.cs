﻿#pragma checksum "..\..\FunctionTeacher.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "441AA3681D3DF99925F12F4786FB5A6438D110AB4D0E8DC1E77349018EBA187C"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
using software_design;


namespace software_design {
    
    
    /// <summary>
    /// FunctionTeacher
    /// </summary>
    public partial class FunctionTeacher : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\FunctionTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InfChangeTea;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\FunctionTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RefreshTeaInf;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\FunctionTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FunctionUserNameTea;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\FunctionTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FunctionNameTea;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\FunctionTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FunctionSexTea;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\FunctionTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FunctionClassTea;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\FunctionTeacher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FunctionEmailTea;
        
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
            System.Uri resourceLocater = new System.Uri("/software_design;component/functionteacher.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FunctionTeacher.xaml"
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
            this.InfChangeTea = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\FunctionTeacher.xaml"
            this.InfChangeTea.Click += new System.Windows.RoutedEventHandler(this.InfChangeTea_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RefreshTeaInf = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\FunctionTeacher.xaml"
            this.RefreshTeaInf.Click += new System.Windows.RoutedEventHandler(this.RefreshTeaInf_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 17 "..\..\FunctionTeacher.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 18 "..\..\FunctionTeacher.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FunctionUserNameTea = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.FunctionNameTea = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.FunctionSexTea = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.FunctionClassTea = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.FunctionEmailTea = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

