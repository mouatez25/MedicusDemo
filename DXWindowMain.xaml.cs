using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using Medicus.Administrateur;
using Medicus.Stock;
using System.ServiceModel;
using System.Windows.Threading;
using Medicus.RendezVous;
using Medicus.SVC;
using Medicus.FileDattente;
using Medicus.EtatEtRapport;
using Medicus.Patient;
 

namespace Medicus
{
    /// <summary>
    /// Interaction logic for DXWindowMain.xaml
    /// </summary>
    public partial class DXWindowMain : DXWindow
    {
        SVC.ServiceCliniqueClient proxy;
        SVC.Membership MemBerShip;
        ICallback callback;
        private delegate void FaultedInvokerMain();
        SVC.Client localClient;
        public event EventHandler AddEvent;
       public Chat CL;
      public  bool ChatOpened = false;
        Dictionary<ListBoxItem, SVC.Client> OnlineClients = new Dictionary<ListBoxItem, Client>();
        public event EventHandler EventRaised;

        public DXWindowMain(SVC.ServiceCliniqueClient PROXYRECU, SVC.Membership memberrecu,ICallback callbackrecu,SVC.Client localclientrecu)
        {
            try
            {
                InitializeComponent();
                MemBerShip = memberrecu;
                proxy = PROXYRECU;
                callback = callbackrecu;
                localClient = localclientrecu;
                SESSSIONNAME.Content = localClient.UserName.ToString();
                //  VisiteAs ll = new VisiteAs();
                //ll.Show();
                
                FrameInterieur.Navigate(new Aceuill(proxy, MemBerShip, callback, this, localClient));

                autorisation(PROXYRECU, memberrecu, callbackrecu, localclientrecu);



                callbackrecu.callback += new ICallback.CallbackEventHandler(callbackrecu_callback);
               
                proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);

                proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);


            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        public void autorisation(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership memberrecu, ICallback callbackrecu, SVC.Client localclientrecu)
        {
            Dispatcher.BeginInvoke(new Action(() => {

                if (memberrecu.ModuleChat == true && localclientrecu.Chat == true)
                {
                    //   CL = new Chat(localclientrecu, callbackrecu, PROXYRECU, this, memberrecu);
                    CL = new Chat(localclientrecu, callbackrecu, proxyrecu, this, memberrecu);

                    ChatOpened = true;
                    CL.Show();
                    CL.WindowState = WindowState.Minimized;
                }

                if (localclientrecu.Stock == true && localclientrecu.Chat == true)
                {
                    this.Title = this.Title + " " + "(Medicus)";
                }
                else
                {
                    if (localclientrecu.Stock == true && localclientrecu.Chat == false)
                    {
                        this.Title = this.Title + " " + "(Medicus)";
                    }
                    else
                    {
                        if (localclientrecu.Stock == false && localclientrecu.Chat == true)
                        {
                            this.Title = this.Title + " " + "(Medicus)";
                        }
                        else
                        {
                            if (localclientrecu.Stock == false && localclientrecu.Chat == false)
                            {
                                this.Title = this.Title + " " + "(Medicus)";
                            }
                        }
                    }
                }


            }), DispatcherPriority.SystemIdle);

            //   Thread.();
        }
        void callbackrecu_callback(object source, CallbackEvent e)
        {
            try
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                {
                    AddMessage(e.clients);
                }));
            }
            catch (Exception ex)
            {
                HandleProxy();
            }
        }
        public void AddMessage(List<Client> clients)
        {
            try
            {
                chatListBoxNames.Items.Clear();
                OnlineClients.Clear();
                foreach (SVC.Client c in clients)
                {
                    ListBoxItem item = MakeItem(c.UserName);
                    chatListBoxNames.Items.Add(item);
                    OnlineClients.Add(item, c);
                   
                }
            }
            catch (Exception ex)
            {
                HandleProxy();
            }
        }
        private ListBoxItem MakeItem(string text)
        {
            ListBoxItem item = new ListBoxItem();


            TextBlock txtblock = new TextBlock();
            txtblock.Text = text;
            txtblock.VerticalAlignment = VerticalAlignment.Center;

            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Children.Add(item);
            panel.Children.Add(txtblock);

            ListBoxItem bigItem = new ListBoxItem();
            bigItem.Content = panel;

            return bigItem;
        }
        void InnerDuplexChannel_Closed(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerMain(HandleProxy));
                return;
            }
            HandleProxy();
        }

        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerMain(HandleProxy));
                return;
            }
            HandleProxy();
        }
        private void HandleProxy()
        {
            try
            {
                if (proxy != null)
                {
                    switch (this.proxy.State)
                    {
                        case CommunicationState.Closed:
                            proxy = null;
                          
                            break;
                        case CommunicationState.Closing:
                            this.Close();
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
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            try
            { 
            if (proxy != null)
            {
                if (proxy.State == CommunicationState.Faulted)
                {

                }
                else
                {
                  
                            proxy.DisconnectAsync(this.localClient);
                        
                }
                }
            }
            catch (Exception ex)
            {
                HandleProxy();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MemBerShip.CréationRendezVous == true)
                {
                    SVC.RendezVou SelectRendezVous = new RendezVou
                    {
                        PrisPar = MemBerShip.UserName,

                    };


                    PrendreRendezVous CLMedecin = new PrendreRendezVous(SelectRendezVous, proxy, MemBerShip, callback, 3, null);
                    CLMedecin.Show();



                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
                WaitIndicatorS.DeferedVisibility = true;
                //    BACK.Visibility = Visibility.Visible;
                if (MemBerShip.ModuleRendezVous == true)
                {
                    FrameInterieur.Navigate(new ListeRendezVous(proxy, MemBerShip, callback));
                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
            finally
            {
                WaitIndicatorS.DeferedVisibility = false;
                // BACK.Visibility = Visibility.Collapsed;
            }
        }
        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MemBerShip.CréationPatient == true)
                {

                    NewPatient cl = new NewPatient(proxy, MemBerShip, null);
                    cl.Show();

                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {

            try
            {

                WaitIndicatorS.DeferedVisibility = true;

                if (MemBerShip.ModulePatient == true)
                {

                    FrameInterieur.Navigate(new ListePatient(proxy, MemBerShip, callback,localClient));

                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
            finally
            {
                WaitIndicatorS.DeferedVisibility = false;
                //  windowmain.BACK.Visibility = Visibility.Collapsed;
            }
        }
         
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MemBerShip.CréationAchat == true)
                {

                    ListeDesDci CLMedecin = new ListeDesDci(proxy, MemBerShip, callback);

                    CLMedecin.Show();

                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MemBerShip.CréationAchat == true)
                {



                    ListeDeProduitPourOronnance CLMedecin = new ListeDeProduitPourOronnance(proxy, MemBerShip, callback);

                    CLMedecin.Show();



                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }

            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
 
        
       
        
        
       
      
        private void RéglementPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool sessionmedecin = false;
                var disponible = (proxy.GetAllMedecin()).Where(list1 => list1.UserName == MemBerShip.UserName).FirstOrDefault();
                if (disponible == null)
                {
                    sessionmedecin = false;
                }
                else
                {
                    sessionmedecin = true;
                }

                if (MemBerShip.ModuleAdministrateur == true || sessionmedecin == true)
                {

                    ReglementPatient cl = new ReglementPatient(proxy, MemBerShip, callback);
                    cl.Show();

                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
       
        private void Rapport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CertificatRapport cl = new CertificatRapport(proxy, MemBerShip,callback);
                cl.Show();


            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        private void Rapport3_Click(object sender, RoutedEventArgs e)
        {
            WaitIndicatorS.DeferedVisibility = true;
            //  BACK.Visibility = Visibility.Visible;
            try
            {

                Editeur cl = new Editeur(proxy);
                cl.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
            finally
            {
                WaitIndicatorS.DeferedVisibility = false;
                // BACK.Visibility = Visibility.Collapsed;
            }
        }
        private void Rapport4_Click(object sender, RoutedEventArgs e)
        {
            WaitIndicatorS.DeferedVisibility = true;
            //    BACK.Visibility = Visibility.Visible;
            try
            {

                FeuilleCalcule cl = new FeuilleCalcule(proxy);
                cl.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
            finally
            {
                WaitIndicatorS.DeferedVisibility = false;
                //  BACK.Visibility = Visibility.Collapsed;
            }
        }
        private void Tableaudebord_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool sessionmedecin = false;
                var disponible = (proxy.GetAllMedecin()).Where(list1 => list1.UserName == MemBerShip.UserName).FirstOrDefault();
                if (disponible == null)
                {
                    sessionmedecin = false;
                }
                else
                {
                    sessionmedecin = true;
                }
                if (MemBerShip.ModuleAdministrateur == true || sessionmedecin == true)
                {

                    TableauDeBord cl = new TableauDeBord(proxy, MemBerShip, callback);
                    cl.Show();

                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        

































        private void chatListBoxNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


       
        

       
        
        private void Ecrans_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dictionnaire_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EtatEtRapport.Dictionnaire cl = new EtatEtRapport.Dictionnaire(proxy, MemBerShip, callback);
                cl.Show();

            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void DXWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Attention ! Vous allez fermer le logiciel", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.No)

                {
                  //  MessageBoxResult resuDlt = Xceed.Wpf.Toolkit.MessageBox.Show("1", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                    EventRaised += new EventHandler(MetroWindow_Closed);
                 

                    e.Cancel = true;
                    return;

                }
                else
                {
               //     MessageBoxResult resuDlt = Xceed.Wpf.Toolkit.MessageBox.Show("2", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                    proxy.DisconnectAsync(this.localClient);

                    e.Cancel = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
    }
}
