﻿#pragma checksum "..\..\..\Laboratoire\ListeDesVersementLabo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F5F9353224B8B1C3C8A4DA9EB8F49D7D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GestionClinique.Laboratoire;
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


namespace GestionClinique.Laboratoire {
    
    
    /// <summary>
    /// ListeDesVersementLabo
    /// </summary>
    public partial class ListeDesVersementLabo : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Laboratoire\ListeDesVersementLabo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border windowBorder;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Laboratoire\ListeDesVersementLabo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSupp;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Laboratoire\ListeDesVersementLabo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnImprimer;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\Laboratoire\ListeDesVersementLabo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock label;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\Laboratoire\ListeDesVersementLabo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRecherche;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\Laboratoire\ListeDesVersementLabo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelFournisseur;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\Laboratoire\ListeDesVersementLabo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid FournDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/GestionClinique;component/laboratoire/listedesversementlabo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Laboratoire\ListeDesVersementLabo.xaml"
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
            this.btnSupp = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Laboratoire\ListeDesVersementLabo.xaml"
            this.btnSupp.Click += new System.Windows.RoutedEventHandler(this.btnSupp_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnImprimer = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\Laboratoire\ListeDesVersementLabo.xaml"
            this.btnImprimer.Click += new System.Windows.RoutedEventHandler(this.btnImprimer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.label = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtRecherche = ((System.Windows.Controls.TextBox)(target));
            
            #line 146 "..\..\..\Laboratoire\ListeDesVersementLabo.xaml"
            this.txtRecherche.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtRecherche_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.labelFournisseur = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.FournDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

