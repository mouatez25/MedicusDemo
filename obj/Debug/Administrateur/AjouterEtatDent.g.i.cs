﻿#pragma checksum "..\..\..\Administrateur\AjouterEtatDent.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2F86EA3B25F23AC78FBBE2AE92F68A70"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GestionClinique.Administrateur;
using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace GestionClinique.Administrateur {
    
    
    /// <summary>
    /// AjouterEtatDent
    /// </summary>
    public partial class AjouterEtatDent : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Administrateur\AjouterEtatDent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border windowBorder;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Administrateur\AjouterEtatDent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid SpécialitéGrid;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Administrateur\AjouterEtatDent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label f;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Administrateur\AjouterEtatDent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txSpecial;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Administrateur\AjouterEtatDent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreer;
        
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
            System.Uri resourceLocater = new System.Uri("/GestionClinique;component/administrateur/ajouteretatdent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Administrateur\AjouterEtatDent.xaml"
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
            this.windowBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.SpécialitéGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.f = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txSpecial = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\..\Administrateur\AjouterEtatDent.xaml"
            this.txSpecial.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txSpecial_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCreer = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\Administrateur\AjouterEtatDent.xaml"
            this.btnCreer.Click += new System.Windows.RoutedEventHandler(this.btnCreer_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

