﻿#pragma checksum "..\..\FrmNewGame.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EB7A4082928F07D9EB8744B449893C067308EF7F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SpiritIslandCompanion;
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


namespace SpiritIslandCompanion {
    
    
    /// <summary>
    /// FrmNewGame
    /// </summary>
    public partial class FrmNewGame : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\FrmNewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lbAdversaries;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\FrmNewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAdvLevel;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\FrmNewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slAdversaryLevel;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\FrmNewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOK;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\FrmNewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\FrmNewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slPlayers;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\FrmNewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbPlayers;
        
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
            System.Uri resourceLocater = new System.Uri("/SpiritIslandCompanion;component/frmnewgame.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FrmNewGame.xaml"
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
            
            #line 13 "..\..\FrmNewGame.xaml"
            ((SpiritIslandCompanion.FrmNewGame)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbAdversaries = ((System.Windows.Controls.ComboBox)(target));
            
            #line 67 "..\..\FrmNewGame.xaml"
            this.lbAdversaries.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbAdversaries_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblAdvLevel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.slAdversaryLevel = ((System.Windows.Controls.Slider)(target));
            return;
            case 5:
            
            #line 101 "..\..\FrmNewGame.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnOK = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\FrmNewGame.xaml"
            this.btnOK.Click += new System.Windows.RoutedEventHandler(this.btnOK_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\FrmNewGame.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.slPlayers = ((System.Windows.Controls.Slider)(target));
            return;
            case 9:
            this.lbPlayers = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

