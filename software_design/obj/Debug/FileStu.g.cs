﻿#pragma checksum "..\..\FileStu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "806CF77FFBE27658CF7EEB698BAF850E2427216D"
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
    /// FileStu
    /// </summary>
    public partial class FileStu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\FileStu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Refresh;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\FileStu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Upload;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\FileStu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button download;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\FileStu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DG_FilStu;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\FileStu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchFile;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\FileStu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FileBox;
        
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
            System.Uri resourceLocater = new System.Uri("/software_design;component/filestu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FileStu.xaml"
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
            this.Refresh = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Upload = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\FileStu.xaml"
            this.Upload.Click += new System.Windows.RoutedEventHandler(this.Upload_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.download = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\FileStu.xaml"
            this.download.Click += new System.Windows.RoutedEventHandler(this.download_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DG_FilStu = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.SearchFile = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\FileStu.xaml"
            this.SearchFile.Click += new System.Windows.RoutedEventHandler(this.SearchFile_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.FileBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 24 "..\..\FileStu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

