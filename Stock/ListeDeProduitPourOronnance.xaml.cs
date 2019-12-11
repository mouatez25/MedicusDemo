using DevExpress.Xpf.Core;
using Medicus.Administrateur;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Medicus.Stock
{
    /// <summary>
    /// Interaction logic for ListeDeProduitPourOronnance.xaml
    /// </summary>
    public partial class ListeDeProduitPourOronnance : DXWindow
    {
        SVC.Membership MemberUser;
        SVC.ServiceCliniqueClient proxy;
        ICallback callback;
        private delegate void FaultedInvokerListeProduit();
        public ListeDeProduitPourOronnance(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership membershiprecu, ICallback callbackrecu)
        {
            try
            {
                InitializeComponent();
                proxy = proxyrecu;
                callback = callbackrecu;
                MemberUser = membershiprecu;
                FournDataGrid.ItemsSource = proxy.GetAllProduitOrdonnance();
                callbackrecu.InsertProduitOrdonnanceCallbackevent += new ICallback.CallbackEventHandler36(callbackrecu_Refresh);
                proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);

                proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);

            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        void callbackrecu_Refresh(object source, CallbackEventInsertProduitOrdonnance e)
        {
            try { 
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                AddRefresh(e.clientleav,e.operleav);
            }));
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        public void AddRefresh(SVC.ProduitOrdonnance listmembership,int oper)
        {
            try
            {
                var LISTITEM11 = FournDataGrid.ItemsSource as IEnumerable<SVC.ProduitOrdonnance>;
                List<SVC.ProduitOrdonnance> LISTITEM0 = LISTITEM11.ToList();

                if (oper == 1)
                {
                    LISTITEM0.Add(listmembership);
                }
                else
                {
                    if (oper == 2)
                    {


                        var objectmodifed = LISTITEM0.Find(n => n.Id == listmembership.Id);
                        //objectmodifed = listmembership;
                        var index = LISTITEM0.IndexOf(objectmodifed);
                        if (index != -1)
                            LISTITEM0[index] = listmembership;
                    }
                    else
                    {
                        if (oper == 3)
                        {
                            //    MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show("Supp rendezvous :"+ listmembership.Id.ToString(), Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                            var deleterendez = LISTITEM0.Where(n => n.Id == listmembership.Id).First();
                            LISTITEM0.Remove(deleterendez);
                        }
                    }
                }










                FournDataGrid.ItemsSource = LISTITEM0;
                

            }catch(Exception ex)
            {

            }
        }
        void InnerDuplexChannel_Closed(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerListeProduit(HandleProxy));
                return;
            }
            HandleProxy();
        }
        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerListeProduit(HandleProxy));
                return;
            }
            HandleProxy();
        }

        private void HandleProxy()
        {
            if (proxy != null)
            {
                switch (this.proxy.State)
                {
                    case CommunicationState.Closed:
                        proxy.Abort();
                        proxy = null;
                        this.Close();
                        break;
                    case CommunicationState.Closing:
                        break;
                    case CommunicationState.Created:
                        break;
                    case CommunicationState.Faulted:
                        proxy.Abort();
                        proxy = null;
                        this.Close();
                        break;
                    case CommunicationState.Opened:


                        break;
                    case CommunicationState.Opening:
                        break;
                    default:
                        break;
                }
            }

        }

        private void txtRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            try { 
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(FournDataGrid.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    SVC.ProduitOrdonnance p = o as SVC.ProduitOrdonnance;
                    if (t.Name == "txtId")
                        return (p.Id == Convert.ToInt32(filter));
                    return (p.Design.ToUpper().StartsWith(filter.ToUpper()));
                };
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (MemberUser.CréationDossierPatient== true )
            {
                AjouterProduitOrdonnance cl = new AjouterProduitOrdonnance(proxy,null,MemberUser,callback);
                cl.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void btnSupp_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            if (MemberUser.SuppressionDossierPatient == true && FournDataGrid.SelectedItem != null)
            {
                using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    SVC.ProduitOrdonnance SelectMedecin = FournDataGrid.SelectedItem as SVC.ProduitOrdonnance;
                    proxy.DeleteProduitOrdonnance(SelectMedecin);
                    ts.Complete();
                }
                proxy.AjouterProduitOrdonnaceRefresh();

            }
            else
            {
                MessageBoxResult resul03 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (MemberUser.ModificationAchat==true && FournDataGrid.SelectedItem!=null)
            {
                SVC.ProduitOrdonnance selectproduit = FournDataGrid.SelectedItem as SVC.ProduitOrdonnance;
                AjouterProduitOrdonnance cl = new AjouterProduitOrdonnance(proxy,selectproduit,MemberUser,callback);
                cl.Show();
            }
            else
            {
                MessageBoxResult resul03 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }

        }

        private void btnImprimer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVider_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (MemberUser.SuppressionDossierPatient == true)
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Attention ! vous allez vider la table des produits pour ordonnancement", "Medicus", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        var itemsSource0 = FournDataGrid.ItemsSource as IEnumerable;
                        var itemsSource01 = proxy.GetAllDci();
                        if (itemsSource0 != null)
                        {
                            bool succées = false;
                            bool succéesFamille = false;
                            using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                            {

                                foreach (SVC.ProduitOrdonnance item in itemsSource0)
                                {
                                    succées = false;
                                    proxy.DeleteProduitOrdonnance(item);
                                    succées = true;

                                }
                                if (itemsSource01 != null)
                                {
                                    foreach (SVC.Dci item in itemsSource01)
                                    {
                                        succéesFamille = false;
                                        proxy.DeletDci(item);
                                        succéesFamille = true;
                                    }
                                }
                                if (succées == true && succéesFamille == true)
                                {
                                    ts.Complete();
                                    MessageBoxResult resul03 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                               proxy.AjouterProduitOrdonnaceRefresh();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resul03 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                if (MemberUser.CréationDossierPatient == true)
                {
                    OpenFileDialog openfile = new OpenFileDialog();
                    openfile.DefaultExt = ".txt";
                    openfile.Filter = "(.txt)|*.txt";

                    var browsefile = openfile.ShowDialog();

                    if (browsefile == true)
                    {
                        string[] lines = File.ReadAllLines(openfile.FileName);

                    

                        
                        List<SVC.ProduitOrdonnance> dt = new List<SVC.ProduitOrdonnance>();
                        for (int i = 0; i < lines.Length; i++)
                        {
                            string v1 = lines[i].Substring(0,5);
                            
                         
                                string v2 = lines[i].Substring(5,49);

                            string v3 = lines[i].Substring(55,49);

                            string v4 = lines[i].Substring(105, 30);

                            string v5 = lines[i].Substring(135,20);

                            string v6 = lines[i].Substring(155, 21);
                            SVC.ProduitOrdonnance dr = new SVC.ProduitOrdonnance
                                {
                                   CodeCnas=Convert.ToInt32(v1),
                                    Design = v2,
                                    dci = v3,
                                    Dosage = v4,
                                    UnitéDeMesure = v5,
                                    Colisage = v6,
                                    Remarques="Mise à jours automatique",
                                };
                                dt.Add(dr);
                            
                        }

                        FournDataGrid.ItemsSource = dt;
                        FournDataGrid.DataContext = dt;
                    }
                }
            }
            catch //(Exception ex)
            {
                MessageBoxResult resul03 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnVisualiser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    var itemsSourceDatagrid = FournDataGrid.ItemsSource as List<SVC.ProduitOrdonnance>;

                    bool succées = false;
                    List<SVC.Dci> famillelist = new List<SVC.Dci>();
                    foreach (SVC.ProduitOrdonnance item in itemsSourceDatagrid)
                    {
                        bool succéesFamille = false;
                        succées = false;
                        proxy.InsertProduitOrdonnance(item);
                        succées = true;
                        if (item.dci != "")
                        {

                            var found = (famillelist).Find(itemf => itemf.Dci1 == item.dci);
                            if (found == null)
                            {
                                succéesFamille = false;
                                SVC.Dci fd = new SVC.Dci
                                {
                                    Dci1 = item.dci,
                                };
                                proxy.InsertDci(fd);
                                succéesFamille = true;
                                if (succéesFamille == true)
                                {
                                    famillelist.Add(fd);
                                }
                            }
                        }
                    }
                    if (succées == true)
                    {
                        ts.Complete();

                      //  MessageBoxResult resul03 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
           
                remplirIdDci();
                proxy.AjouterProduitOrdonnaceRefresh();
            }
            catch (Exception ex)
            {

                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
        void remplirIdDci()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    var itemsSourceDatagrid = proxy.GetAllProduitOrdonnance();

                    bool succées = false;
                    var famillelist = proxy.GetAllDci();

                    foreach (SVC.ProduitOrdonnance item in itemsSourceDatagrid)
                    {


                        if (item.dci != "")
                        {

                            var found = (famillelist).Find(itemf => itemf.Dci1 == item.dci);
                            if (found != null)
                            {
                                succées = false;
                                item.IdDci = found.Id;
                                proxy.UpdateProduitOrdonnance(item);

                                succées = true;

                            }
                        }
                    }
                    if (succées == true)
                    {
                        ts.Complete();

                        MessageBoxResult resul03 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
        private void FournDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try { 
            if (MemberUser.ModificationAchat == true && FournDataGrid.SelectedItem != null)
            {
                SVC.ProduitOrdonnance selectproduit = FournDataGrid.SelectedItem as SVC.ProduitOrdonnance;
                AjouterProduitOrdonnance cl = new AjouterProduitOrdonnance(proxy, selectproduit, MemberUser,callback);
                cl.Show();
            }
            else
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Vous ne pouvez pas faire cette opération", "Medicus", MessageBoxButton.YesNo, MessageBoxImage.Question);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void BTNCLOSTE_Click(object sender, RoutedEventArgs e)
        {
            try { 
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
    }
}
