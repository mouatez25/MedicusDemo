using DevExpress.Xpf.Core;
using Medicus.Administrateur;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AjouterProduitOrdonnance.xaml
    /// </summary>
    public partial class AjouterProduitOrdonnance : DXWindow
    {
        SVC.ProduitOrdonnance special;
        SVC.ServiceCliniqueClient proxy;

        private delegate void FaultedInvokerNewProduitOrdonnance();
        SVC.Membership membership;
        string title;
        Brush titlebrush;
        int créationOrdonnace = 0;
        ICallback callback;
        
        public AjouterProduitOrdonnance(SVC.ServiceCliniqueClient proxyrecu, SVC.ProduitOrdonnance spécialtiérecu, SVC.Membership membershirecu,ICallback callbackrecu)
        {
            try
            {
                InitializeComponent();

                proxy = proxyrecu;
                special = spécialtiérecu;
                membership = membershirecu;
                callback = callbackrecu;
               

                if (special != null)
                {
                    FournVousGrid.DataContext = special;
                    List<SVC.Dci> testmedecin = proxy.GetAllDci();
                    ListeDciCombo.ItemsSource = testmedecin;
                    List<SVC.Dci> tte = testmedecin.Where(n => n.Id == special.IdDci).OrderBy(n=>n.Id).ToList();
                    ListeDciCombo.SelectedItem = tte.First();
                    créationOrdonnace = 0;
                    callbackrecu.InsertDciCallbackevent += new ICallback.CallbackEventHandler33(callbackDci_Refresh);
                }
                else
                {
                    special= new SVC.ProduitOrdonnance();
                    FournVousGrid.DataContext = special;
                    ListeDciCombo.ItemsSource = proxy.GetAllDci().OrderBy(n => n.Id);
                    btnCreer.IsEnabled = false;
                    créationOrdonnace = 1;
                    callbackrecu.InsertDciCallbackevent += new ICallback.CallbackEventHandler33(callbackDci_Refresh);

                }
                proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);
                proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }



        }
        void callbackDci_Refresh(object source, CallbackEventInsertDci e)
        {
            try
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                {
                    AddRefresh(e.clientleav);
                }));
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
        public void AddRefresh(List<SVC.Dci> listmembership)
        {
            try
            {
                if (proxy != null)
                {
                    if (proxy.State == CommunicationState.Faulted)
                    {
                        HandleProxy();
                    }
                    else
                    {
                        if (créationOrdonnace==1)
                        {
                        

                            ListeDciCombo.ItemsSource = listmembership;
                        }else
                        {
                            if (créationOrdonnace == 0)
                            {

                                List<SVC.Dci> testmedecin = listmembership;
                                ListeDciCombo.ItemsSource = testmedecin;
                                List<SVC.Dci> tte = testmedecin.Where(n => n.Id == special.IdDci).ToList();
                                ListeDciCombo.SelectedItem = tte.First();
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }
        void InnerDuplexChannel_Closed(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerNewProduitOrdonnance(HandleProxy));
                return;
            }
            HandleProxy();
        }
        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerNewProduitOrdonnance(HandleProxy));
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
        private void btnCreer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (membership.CréationAchat == true && créationOrdonnace==1)
                {
                    using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                    {
                      


                        if (ListeDciCombo.SelectedItem != null)
                        {
                            SVC.Dci selecdci = ListeDciCombo.SelectedItem as SVC.Dci;

                            special.IdDci = selecdci.Id;
                            special.dci = selecdci.Dci1;

                        }
                        else
                        {
                            special.IdDci = 0;
                            special.dci = "";
                        }
                        proxy.InsertProduitOrdonnance(special);
                        ts.Complete();
                        MessageBoxResult resul03 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    proxy.AjouterProduitOrdonnaceRefresh();
                    btnCreer.IsEnabled = false;
                }
                else
                {
                    if (membership.ModificationAchat == true && créationOrdonnace==0)
                    {
                        using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                        {
                            if (ListeDciCombo.SelectedItem != null)
                            {
                                SVC.Dci SelectMedecin = ListeDciCombo.SelectedItem as SVC.Dci;
                                special.dci = SelectMedecin.Dci1;
                                special.IdDci = SelectMedecin.Id;
                            }
                            else
                            {
                                special.IdDci = 0;
                                special.dci = "";
                            }

                            proxy.UpdateProduitOrdonnance(special);
                            ts.Complete();
                            MessageBoxResult resul03 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        proxy.AjouterProduitOrdonnaceRefresh();

                    }
                    else
                    {
                        MessageBoxResult resul03 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void txtCodeCnas_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* try
            {
                if (txtCodeCnas.Text.Trim() != "" && créationOrdonnace ==1)
                {

                    var query = from c in proxy.GetAllProduitOrdonnance()
                                select new { c.CodeCnas };

                    var results = query.ToList();
                    var disponible = results.Where(list1 => list1.CodeCnas==Convert.ToInt16(txtCodeCnas.Text.Trim().ToUpper())).FirstOrDefault();

                    if (disponible != null)
                    {
                       

                        btnCreer.IsEnabled = false;
                        btnCreer.Opacity = 0.2;


                    }
                    else
                    {
                        if (txtCodeCnas.Text.Trim() != "")
                        {
                         
                            btnCreer.IsEnabled = true;
                            btnCreer.Opacity = 1;

                        }
                    }
                }
                else
                {

                    btnCreer.IsEnabled = true;
                    btnCreer.Opacity = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
            }*/
        }

        private void txtDesign_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtDesign.Text.Trim() != "" && créationOrdonnace == 1)
                {

                    var query = from c in proxy.GetAllProduitOrdonnance()
                                select new { c.Design };

                    var results = query.ToList();
                    var disponible = results.Where(list1 => list1.Design.Trim().ToUpper() == txtDesign.Text.Trim().ToUpper()).FirstOrDefault();

                    if (disponible != null)
                    {


                        btnCreer.IsEnabled = false;
                        btnCreer.Opacity = 0.2;


                    }
                    else
                    {
                     //   if (txtCodeCnas.Text.Trim() != "")
                      //  {

                            btnCreer.IsEnabled = true;
                            btnCreer.Opacity = 1;

                        //}
                    }
                }
                else
                {

                    btnCreer.IsEnabled = true;
                    btnCreer.Opacity = 1;
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

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (membership.CréationAchat==true)
            {
                AjouterDci cl = new AjouterDci(proxy,null,membership);
                cl.Show();
            }
            else
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
    }
}
