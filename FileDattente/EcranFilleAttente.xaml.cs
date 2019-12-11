using Medicus.Administrateur;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Medicus.FileDattente
{
    /// <summary>
    /// Interaction logic for EcranFilleAttente.xaml
    /// </summary>
    public partial class EcranFilleAttente : MetroWindow
    {
        SVC.ServiceCliniqueClient proxy;
     
        SVC.Membership membershipuser;
        SpeechSynthesizer reader;
        private delegate void FaultedInvokerEcran();
        ICallback callback;
        public EcranFilleAttente(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership memrecu, ICallback callbackrecu)
        {
            try
            {
                InitializeComponent();
                callbackrecu.InsertamCallbackEcranSalleAttente += new ICallback.CallbackEventHandler27(callbackrecu_Refresh);
                proxy = proxyrecu;
                membershipuser = memrecu;
                callback = callbackrecu;
               
                proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);

                proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        void callbackrecu_Refresh(object source, CallbackEventSalleAttenteDemandeChezLeMedecin e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                AddRefresh(e.clientleav,e.clientleavSall);
            }));
        }
        public void AddRefresh(SVC.Patient listmembership,SVC.SalleDattente selectSalle)
        {
            txtCode.Text = listmembership.Id.ToString();
            txtNomPrénom.Text = listmembership.Nom + " " + listmembership.Prénom;
            txtNomPrénomMedecin.Text = selectSalle.NomMedecin + " " + selectSalle.PrénomMedecin;
            reader = new SpeechSynthesizer();
          //  String voix = "Microsoft Server Speech Text to Speech Voice (fr-FR, Hortense)";
            //reader.SelectVoice(voix);
            reader.SpeakAsync(txtc.Content + txtCode.Text + txtNomPrénom.Text + txt.Content + txtNomPrénomMedecin.Text);
        }
        void InnerDuplexChannel_Closed(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerEcran(HandleProxy));
                return;
            }
            HandleProxy();
        }

        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerEcran(HandleProxy));
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




    }
}
