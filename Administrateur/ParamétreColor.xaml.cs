using DevExpress.Xpf.Core;
using MahApps.Metro.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Medicus.Administrateur
{
    /// <summary>
    /// Interaction logic for ParamétreColor.xaml
    /// </summary>
    public partial class ParamétreColor : DXWindow
    {
      
        SVC.ServiceCliniqueClient proxy;
        SVC.Membership memberuser;
        ICallback callback;
        private delegate void FaultedInvokerParamColor();
        public ParamétreColor(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership memberrecu, ICallback callbackrecu)
        {
            try
            {
                InitializeComponent();
                proxy = proxyrecu;
                memberuser = memberrecu;
                callback = callbackrecu;
                SalleAttenteGrid.DataContext = proxy.GetAllParamétre();
                proxy = proxyrecu;
                memberuser = memberrecu;
                callback = callbackrecu;
                callbackrecu.InsertParamCallbackEvent += new ICallback.CallbackEventHandler16(callbackrecu_Refresh);
            
                var converter = new System.Windows.Media.BrushConverter();
                EclipsePatientPrésent.Background = (Brush)converter.ConvertFromString((proxy.GetAllParamétre()).RdvPresent);
                EclipsePatientNomPrésent.Background = (Brush)converter.ConvertFromString((proxy.GetAllParamétre()).RdvNoPresent);
                EclipsePatientSalle.Background = (Brush)converter.ConvertFromString((proxy.GetAllParamétre()).SalleAttenteTjr);
                EclipsePatientNoSalle.Background = (Brush)converter.ConvertFromString((proxy.GetAllParamétre()).SalleAttenteQuit);

                EclipsePatientMedecinSalle.Background = (Brush)converter.ConvertFromString((proxy.GetAllParamétre()).MedecinSalleTjr);
                EclipsePatientNoSalleMedecin.Background = (Brush)converter.ConvertFromString((proxy.GetAllParamétre()).MedecinSalleNON);
                VisiteRéglé.Background = (Brush)converter.ConvertFromString((proxy.GetAllParamétre()).VisteRéglé);
                VisiteNonRéglé.Background = (Brush)converter.ConvertFromString((proxy.GetAllParamétre()).VisteNonRéglé);

               
                proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);

                proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        void callbackrecu_Refresh(object source,CallbackEventInsertParam e)
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
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        public void AddRefresh(SVC.Param listmembership)
        {
           try
            { 
            var converter = new System.Windows.Media.BrushConverter();
            SalleAttenteGrid.DataContext = listmembership;
            EclipsePatientPrésent.Background = (Brush)converter.ConvertFromString((listmembership).RdvPresent);
            EclipsePatientNomPrésent.Background = (Brush)converter.ConvertFromString((listmembership).RdvNoPresent);
            EclipsePatientSalle.Background = (Brush)converter.ConvertFromString((listmembership).SalleAttenteTjr);
            EclipsePatientNoSalle.Background = (Brush)converter.ConvertFromString((listmembership).SalleAttenteQuit);
            EclipsePatientMedecinSalle.Background = (Brush)converter.ConvertFromString((listmembership).MedecinSalleTjr);
            EclipsePatientNoSalleMedecin.Background = (Brush)converter.ConvertFromString((listmembership).MedecinSalleNON);

            VisiteRéglé.Background = (Brush)converter.ConvertFromString((listmembership).VisteRéglé);
            VisiteNonRéglé.Background = (Brush)converter.ConvertFromString((listmembership).VisteNonRéglé);
            
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        void InnerDuplexChannel_Closed(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerParamColor(HandleProxy));
                return;
            }
            HandleProxy();
        }

        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerParamColor(HandleProxy));
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

        private void EclipsePatientPrésent_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
           ColorPalete CLSession = new ColorPalete(proxy, memberuser, callback,1,EclipsePatientPrésent.Background.ToString());

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void EclipsePatientNomPrésent_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            ColorPalete CLSession = new ColorPalete(proxy, memberuser, callback, 2, EclipsePatientNomPrésent.ToString());

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void EclipsePatientSalle_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            ColorPalete CLSession = new ColorPalete(proxy, memberuser, callback,3, EclipsePatientNomPrésent.ToString());

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void EclipsePatientNoSalle_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            ColorPalete CLSession = new ColorPalete(proxy, memberuser, callback,4, EclipsePatientNomPrésent.ToString());

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void EclipsePatientMedecinSalle_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            ColorPalete CLSession = new ColorPalete(proxy, memberuser, callback, 5, EclipsePatientMedecinSalle.ToString());

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void EclipsePatientNoSalleMedecin_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            ColorPalete CLSession = new ColorPalete(proxy, memberuser, callback, 6, EclipsePatientNoSalleMedecin.ToString());

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void VisiteRéglé_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            ColorPalete CLSession = new ColorPalete(proxy, memberuser, callback, 7, VisiteRéglé.ToString());

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void VisiteNonRéglé_Click(object sender, RoutedEventArgs e)
        {
            try

            { 
            ColorPalete CLSession = new ColorPalete(proxy, memberuser, callback, 8, VisiteNonRéglé.ToString());

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        
    }
}
