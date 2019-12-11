using DevExpress.Xpf.Core;
using Medicus.Administrateur;
using Medicus.Caisse;
using Medicus.Patient;
using MahApps.Metro.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace Medicus.FileDattente
{
    /// <summary>
    /// Interaction logic for SalleDattente.xaml
    /// </summary>
    public partial class SalleDattente : DXWindow
    {
        SVC.ServiceCliniqueClient proxy;
        SVC.Membership memberuser;
        ICallback callback;
        private delegate void FaultedInvokerSalleDattente();
        SVC.Medecin medecinSelected;
        bool medecinsession = false;
        SVC.Client localclient;
        //  bool ProcessRowsbool, ProcessRowsSalleAttentebool, ProcessRowsMedecinSallebool, ProcessRowsRéglementVisitebool=false;
        string RdvPresent, RdvNoPresent, SalleAttenteQuit, SalleAttenteTjr, MedecinSalleTjr, MedecinSalleNON, VisteNonRéglé, VisteRéglé = "";
        public SalleDattente(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership memberrecu, ICallback callbackrecu, SVC.Client clientrecu)
        {
            try
            {
                InitializeComponent();
                WaitIndicatorS.DeferedVisibility = true;
                BACK.Visibility = Visibility.Visible;
                proxy = proxyrecu;
                memberuser = memberrecu;
                localclient = clientrecu;
                callback = callbackrecu;
                DateNOW.SelectedDate = DateTime.Now;
                DateNOWRendez.SelectedDate = DateTime.Now;
                DateVisite.SelectedDate = DateTime.Now;
                //btnExit.IsEnabled = false;
                btnSupp.IsEnabled = false;

                ///   chargerparam(proxyrecu);
                ///   
                var paramettre = proxyrecu.GetAllParamétre();
                VisteNonRéglé = paramettre.VisteNonRéglé;
                VisteRéglé = paramettre.VisteRéglé;
                RdvPresent = paramettre.RdvPresent;
                RdvNoPresent = paramettre.RdvNoPresent;
                SalleAttenteQuit = paramettre.SalleAttenteQuit;
                SalleAttenteTjr = paramettre.SalleAttenteTjr;
                MedecinSalleTjr = paramettre.MedecinSalleTjr;
                MedecinSalleNON = paramettre.MedecinSalleNON;
                var converter = new System.Windows.Media.BrushConverter();

                btnPresent.Background = (Brush)converter.ConvertFromString(RdvPresent);
                btnNoPresent.Background = (Brush)converter.ConvertFromString(RdvNoPresent);
                btnPayer.Background = (Brush)converter.ConvertFromString(VisteRéglé);
                btnNoPayer.Background = (Brush)converter.ConvertFromString(VisteNonRéglé);
                btnTjrLa.Background = (Brush)converter.ConvertFromString(SalleAttenteTjr);
                btnNoSalle.Background = (Brush)converter.ConvertFromString(SalleAttenteQuit);
                btnMedecin.Background = (Brush)converter.ConvertFromString(MedecinSalleTjr);
                btnPatientMedecin.Background = (Brush)converter.ConvertFromString(MedecinSalleNON);

                //////////////////////
                chargerMedecin(proxyrecu, memberrecu);




                callbackrecu.InsertRendezVousCallbackEvent += new ICallback.CallbackEventHandler8(callbackrecu_Refresh);
                callbackrecu.InsertSalleDattenteCallbackEvent += new ICallback.CallbackEventHandler17(callbackrecuSalleDattente_Refresh);
                callbackrecu.InsertVisiteCallbackEvent += new ICallback.CallbackEventHandler13(callbackrecuVisite_Refresh);



                proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);

                proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);

            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                WaitIndicatorS.DeferedVisibility = false;
                BACK.Visibility = Visibility.Collapsed;
            }
        }
        public void chargerMedecin(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership memberrecu)
        {
            Dispatcher.BeginInvoke(new Action(() => {
                var disponible = (proxyrecu.GetAllMedecin()).Where(list1 => list1.UserName == memberuser.UserName).FirstOrDefault();
                if (disponible == null)
                {

                    MedecinCombo.ItemsSource = proxyrecu.GetAllMedecin().OrderBy(n => n.Nom); ;




                    medecinsession = false;




                }
                else
                {

                    medecinSelected = disponible;

                    List<SVC.Medecin> testmedecin = proxyrecu.GetAllMedecin().OrderBy(n => n.Nom).ToList();
                    MedecinCombo.ItemsSource = testmedecin;
                    List<SVC.Medecin> tte = testmedecin.Where(n => n.UserName == memberuser.UserName).ToList();
                    MedecinCombo.SelectedItem = tte.First();


                    if (memberrecu.AccèsToutLesDossierPatient == true)
                    {
                        MedecinCombo.IsEnabled = true;
                    }
                    else
                    {
                        MedecinCombo.IsEnabled = false;
                    }

                    medecinsession = true;

                }




            }), DispatcherPriority.SystemIdle);

            //   Thread.();
        }
        public void chargerparam(SVC.ServiceCliniqueClient proxyrecu)
        {
            Dispatcher.BeginInvoke(new Action(() => {
                var paramettre = proxyrecu.GetAllParamétre();
                VisteNonRéglé = paramettre.VisteNonRéglé;
                VisteRéglé = paramettre.VisteRéglé;
                RdvPresent = paramettre.RdvPresent;
                RdvNoPresent = paramettre.RdvNoPresent;
                SalleAttenteQuit = paramettre.SalleAttenteQuit;
                SalleAttenteTjr = paramettre.SalleAttenteTjr;
                MedecinSalleTjr = paramettre.MedecinSalleTjr;
                MedecinSalleNON = paramettre.MedecinSalleNON;
                var converter = new System.Windows.Media.BrushConverter();

                btnPresent.Background = (Brush)converter.ConvertFromString(RdvPresent);
                btnNoPresent.Background = (Brush)converter.ConvertFromString(RdvNoPresent);
                btnPayer.Background = (Brush)converter.ConvertFromString(VisteRéglé);
                btnNoPayer.Background = (Brush)converter.ConvertFromString(VisteNonRéglé);
                btnTjrLa.Background = (Brush)converter.ConvertFromString(SalleAttenteTjr);
                btnNoSalle.Background = (Brush)converter.ConvertFromString(SalleAttenteQuit);
                btnMedecin.Background = (Brush)converter.ConvertFromString(MedecinSalleTjr);
                btnPatientMedecin.Background = (Brush)converter.ConvertFromString(MedecinSalleNON);

            }), DispatcherPriority.SystemIdle);

            //   Thread.();
        }
        void callbackrecu_Refresh(object source, CallbackEventInsertRendezVous e)
        {
            try
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                {
                    AddRefresh(e.clientleav, e.operleav);
                }));
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        void callbackrecuSalleDattente_Refresh(object source, CallbackEventInsertSalleDattente e)
        {
            try
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                {
                    AddRefreshSalle(e.clientleav, e.operleav);
                }));
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        void callbackrecuVisite_Refresh(object source, CallbackEventInsertVisite e)
        {
            try
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                {
                    AddRefreshVisite(e.clientleav, e.operleav);
                }));
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        public void AddRefreshVisite(SVC.Visite listmembership, int oper)
        {
            try
            {
                if (DateVisite.SelectedDate.Value != null)
                {
                    if (medecinSelected != null)
                    {
                        if (listmembership.Date == DateVisite.SelectedDate.Value && listmembership.CodeMedecin == medecinSelected.Id)
                        {
                            var LISTITEM1 = VisiteExisiteGrid.ItemsSource as IEnumerable<SVC.Visite>;
                            List<SVC.Visite> LISTITEM = LISTITEM1.ToList();

                            if (oper == 1)
                            {
                                LISTITEM.Add(listmembership);
                            }
                            else
                            {
                                if (oper == 2)
                                {



                                    var objectmodifed = LISTITEM.Find(n => n.Id == listmembership.Id);
                                    //objectmodifed = listmembership;
                                    var index = LISTITEM.IndexOf(objectmodifed);
                                    if (index != -1)
                                        LISTITEM[index] = listmembership;
                                }
                                else
                                {
                                    if (oper == 3)
                                    {
                                        //    MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show("Supp rendezvous :"+ listmembership.Id.ToString(), Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                                        var deleterendez = LISTITEM.Where(n => n.Id == listmembership.Id).First();
                                        LISTITEM.Remove(deleterendez);
                                    }
                                }
                            }

                            VisiteExisiteGrid.ItemsSource = LISTITEM;



                            //       VisiteExisiteGrid.ItemsSource = (listmembership).Where(n => n.Date == DateVisite.SelectedDate.Value && n.CodeMedecin == medecinSelected.Id);
                            txtLabelTotalAregler.Content = Convert.ToString((LISTITEM.Where(n => n.Date == DateVisite.SelectedDate.Value && n.CodeMedecin == medecinSelected.Id)).AsEnumerable().Sum(o => o.Montant));
                            txtLabelTotalversement.Content = Convert.ToString((LISTITEM.Where(n => n.Date == DateVisite.SelectedDate.Value && n.CodeMedecin == medecinSelected.Id)).AsEnumerable().Sum(o => o.Versement));
                            txtLabelTotalReste.Content = Convert.ToString((LISTITEM.Where(n => n.Date == DateVisite.SelectedDate.Value && n.CodeMedecin == medecinSelected.Id)).AsEnumerable().Sum(o => o.Reste));
                        }
                    }
                    else
                    {
                        if (listmembership.Date == DateVisite.SelectedDate.Value)
                        {
                            var LISTITEM1 = VisiteExisiteGrid.ItemsSource as IEnumerable<SVC.Visite>;
                            List<SVC.Visite> LISTITEM = LISTITEM1.ToList();

                            if (oper == 1)
                            {
                                LISTITEM.Add(listmembership);
                            }
                            else
                            {
                                if (oper == 2)
                                {



                                    var objectmodifed = LISTITEM.Find(n => n.Id == listmembership.Id);
                                    //objectmodifed = listmembership;
                                    var index = LISTITEM.IndexOf(objectmodifed);
                                    if (index != -1)
                                        LISTITEM[index] = listmembership;
                                }
                                else
                                {
                                    if (oper == 3)
                                    {
                                        //    MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show("Supp rendezvous :"+ listmembership.Id.ToString(), Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                                        var deleterendez = LISTITEM.Where(n => n.Id == listmembership.Id).First();
                                        LISTITEM.Remove(deleterendez);
                                    }
                                }
                            }

                            VisiteExisiteGrid.ItemsSource = LISTITEM;



                            //       VisiteExisiteGrid.ItemsSource = (listmembership).Where(n => n.Date == DateVisite.SelectedDate.Value && n.CodeMedecin == medecinSelected.Id);
                            txtLabelTotalAregler.Content = Convert.ToString((LISTITEM.Where(n => n.Date == DateVisite.SelectedDate.Value)).AsEnumerable().Sum(o => o.Montant));
                            txtLabelTotalversement.Content = Convert.ToString((LISTITEM.Where(n => n.Date == DateVisite.SelectedDate.Value)).AsEnumerable().Sum(o => o.Versement));
                            txtLabelTotalReste.Content = Convert.ToString((LISTITEM.Where(n => n.Date == DateVisite.SelectedDate.Value)).AsEnumerable().Sum(o => o.Reste));
                        }





                    }

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
            //     Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRowsRéglementVisite));

        }
        public void AddRefresh(SVC.RendezVou listmembership, int oper)
        {
            try
            {
                if (MedecinCombo.SelectedItem != null && DateNOWRendez.SelectedDate.Value != null)
                {
                    SVC.Medecin SelectMedecin = MedecinCombo.SelectedItem as SVC.Medecin;
                    //    List<SVC.RendezVou> LISTITEM = RendezVousExisiteGrid.ItemsSource as List<SVC.RendezVou>;
                    var LISTITEM1 = RendezVousExisiteGrid.ItemsSource as IEnumerable<SVC.RendezVou>;
                    List<SVC.RendezVou> LISTITEM = LISTITEM1.ToList();
                    if (listmembership.CodeMedecin == SelectMedecin.Id && listmembership.Date == DateNOWRendez.SelectedDate.Value)
                    {
                        if (oper == 1)
                        {
                            LISTITEM.Add(listmembership);
                        }
                        else
                        {
                            if (oper == 2)
                            {
                                var objectmodifed = LISTITEM.Find(n => n.Id == listmembership.Id);
                                //objectmodifed = listmembership;
                                var index = LISTITEM.IndexOf(objectmodifed);
                                if (index != -1)
                                    LISTITEM[index] = listmembership;
                            }
                            else
                            {
                                if (oper == 3)
                                {
                                    //    MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show("Supp rendezvous :"+ listmembership.Id.ToString(), Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                                    var deleterendez = LISTITEM.Where(n => n.Id == listmembership.Id).First();
                                    LISTITEM.Remove(deleterendez);
                                }
                            }
                        }
                    }
                    RendezVousExisiteGrid.ItemsSource = LISTITEM.OrderBy(n => n.Date);
                    //  RendezVousExisiteGrid.ItemsSource = (listmembership).Where(n => n.CodeMedecin==SelectMedecin.Id && n.Date == DateNOWRendez.SelectedDate.Value);
                    NBRENDEZVOUS.Text = ((LISTITEM).Where(n => n.CodeMedecin == SelectMedecin.Id && n.Date == DateNOWRendez.SelectedDate.Value).AsEnumerable().Count()).ToString();

                }
                else
                {
                    if (MedecinCombo.SelectedItem == null /*&& DateNOWRendez.SelectedDate.Value != null*/)
                    {
                        var LISTITEM1 = RendezVousExisiteGrid.ItemsSource as IEnumerable<SVC.RendezVou>;
                        List<SVC.RendezVou> LISTITEM = LISTITEM1.ToList();
                        if (listmembership.Date == DateNOWRendez.SelectedDate.Value)
                        {
                            if (oper == 1)
                            {
                                LISTITEM.Add(listmembership);
                            }
                            else
                            {
                                if (oper == 2)
                                {
                                    var objectmodifed = LISTITEM.Find(n => n.Id == listmembership.Id);
                                    //objectmodifed = listmembership;
                                    var index = LISTITEM.IndexOf(objectmodifed);
                                    if (index != -1)
                                        LISTITEM[index] = listmembership;
                                }
                                else
                                {
                                    if (oper == 3)
                                    {
                                        var deleterendez = LISTITEM.Where(n => n.Id == listmembership.Id).First();

                                        LISTITEM.Remove(deleterendez);
                                    }
                                }
                            }
                        }
                        //    RendezVousExisiteGrid.ItemsSource = (listmembership).Where(n => n.Date == DateNOWRendez.SelectedDate.Value);
                        RendezVousExisiteGrid.ItemsSource = LISTITEM.OrderBy(n => n.Date);
                        NBRENDEZVOUS.Text = ((LISTITEM).Where(n => n.Date == DateNOWRendez.SelectedDate.Value).AsEnumerable().Count()).ToString();

                    }
                }
                //    Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRows));
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        public void AddRefreshSalle(SVC.SalleDattente listmembership, int oper)
        {
            try
            {
                if (MedecinCombo.SelectedItem != null && DateNOW.SelectedDate.Value != null)
                {
                    SVC.Medecin SelectMedecin = MedecinCombo.SelectedItem as SVC.Medecin;

                    var LISTITEM1 = SalleDattenteGrid.ItemsSource as IEnumerable<SVC.SalleDattente>;
                    List<SVC.SalleDattente> LISTITEM = LISTITEM1.ToList();

                    if (listmembership.CodeMedecin == SelectMedecin.Id && listmembership.DateArrivée == DateNOW.SelectedDate.Value)
                    {
                        if (oper == 1)
                        {
                            LISTITEM.Add(listmembership);
                        }
                        else
                        {
                            if (oper == 2)
                            {
                                var objectmodifed = LISTITEM.Find(n => n.Id == listmembership.Id);
                                //objectmodifed = listmembership;
                                var index = LISTITEM.IndexOf(objectmodifed);
                                if (index != -1)
                                    LISTITEM[index] = listmembership;
                            }
                            else
                            {
                                if (oper == 3)
                                {
                                    var deleteSalle = LISTITEM.Where(n => n.Id == listmembership.Id).First();
                                    LISTITEM.Remove(deleteSalle);
                                }
                            }
                        }
                    }


                    SalleDattenteGrid.ItemsSource = LISTITEM;





                    MedecinRecomandationGrid.ItemsSource = LISTITEM.Where(n => n.NumFilleAttente > 0);





                    if (medecinsession == true)
                    {
                        //  NBSALLEATTENTE.Text = ((LISTITEM).Where(n => n.CodeMedecin == medecinSelected.Id && n.DateArrivée == DateTime.Now.Date && n.Quit == false).AsEnumerable().Count()).ToString();
                        NBSALLEATTENTE.Text = ((LISTITEM).Where(n => n.CodeMedecin == medecinSelected.Id && n.Quit == false).AsEnumerable().Count()).ToString();

                    }
                    else
                    {
                        //   NBSALLEATTENTE.Text = ((LISTITEM).Where(n => n.CodeMedecin == SelectMedecin.Id && n.DateArrivée == DateTime.Now.Date && n.Quit == false).AsEnumerable().Count()).ToString();
                        NBSALLEATTENTE.Text = ((LISTITEM).Where(n => n.CodeMedecin == SelectMedecin.Id && n.Quit == false).AsEnumerable().Count()).ToString();

                    }

                }
                else
                {
                    if (MedecinCombo.SelectedItem == null && DateNOW.SelectedDate.Value != null)
                    {
                        var LISTITEM1 = SalleDattenteGrid.ItemsSource as IEnumerable<SVC.SalleDattente>;
                        List<SVC.SalleDattente> LISTITEM = LISTITEM1.ToList();
                        if (listmembership.DateArrivée == DateNOW.SelectedDate.Value)
                        {
                            if (oper == 1)
                            {
                                LISTITEM.Add(listmembership);
                            }
                            else
                            {
                                if (oper == 2)
                                {
                                    var objectmodifed = LISTITEM.Find(n => n.Id == listmembership.Id);
                                    //objectmodifed = listmembership;
                                    var index = LISTITEM.IndexOf(objectmodifed);
                                    if (index != -1)
                                        LISTITEM[index] = listmembership;
                                }
                                else
                                {
                                    if (oper == 3)
                                    {
                                        var deleteSalle = LISTITEM.Where(n => n.Id == listmembership.Id).First();

                                        LISTITEM.Remove(deleteSalle);
                                    }
                                }
                            }
                        }
                        SalleDattenteGrid.ItemsSource = LISTITEM;

                        //    SalleDattenteGrid.ItemsSource = (listmembership).Where(n => n.DateArrivée == DateNOW.SelectedDate.Value);
                        MedecinRecomandationGrid.ItemsSource = LISTITEM.Where(n => n.NumFilleAttente > 0);
                        //  MedecinRecomandationGrid.ItemsSource = (listmembership).Where(n => n.DateArrivée == DateNOW.SelectedDate.Value && n.NumFilleAttente > 0);
                        //    NBSALLEATTENTE.Text = ((LISTITEM).Where(n => n.DateArrivée == DateTime.Now.Date && n.Quit == false).AsEnumerable().Count()).ToString();
                        NBSALLEATTENTE.Text = ((LISTITEM).Where(n => n.Quit == false).AsEnumerable().Count()).ToString();


                    }
                }
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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerSalleDattente(HandleProxy));
                return;
            }
            HandleProxy();
        }

        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerSalleDattente(HandleProxy));
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





        private void BtnPresentExiste_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WaitIndicatorS.DeferedVisibility = true;
                BACK.Visibility = Visibility.Visible;
                if (RendezVousExisiteGrid.SelectedItem != null/* && MedecinCombo.SelectedItem != null */&& DateNOW.SelectedDate.Value != null && memberuser.CréationSalleAttente == true)
                {
                    SVC.RendezVou selectrendezvous = RendezVousExisiteGrid.SelectedItem as SVC.RendezVou;

                    ///      SVC.Medecin  selectmedecin = MedecinCombo.SelectedItem as SVC.Medecin;
                    SVC.Medecin selectmedecin = proxy.GetAllMedecin().Find(n => n.Id == selectrendezvous.CodeMedecin);

                    if (selectrendezvous.Confirm != true)
                    {
                        Arrivée cl = new Arrivée(proxy, memberuser, callback, selectrendezvous, selectmedecin, DateNOW.SelectedDate.Value, 1, null, null);
                        cl.Show();
                    }


                    else
                    {
                        MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Patient déja dans la salle d'attente", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                        DateNOW.BorderBrush = Brushes.Red;
                    }

                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Vous devez choisir un medecin", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                    DateNOW.BorderBrush = Brushes.Red;
                }
                WaitIndicatorS.DeferedVisibility = false;
                BACK.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void DateNOWRendez_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                WaitIndicatorS.DeferedVisibility = true;
                BACK.Visibility = Visibility.Visible;

                if (MedecinCombo.SelectedItem != null)
                {

                    SVC.Medecin SelectMedecin = MedecinCombo.SelectedItem as SVC.Medecin;
                    RendezVousExisiteGrid.ItemsSource = (proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id).OrderBy(n => n.Date);
                    NBRENDEZVOUS.Text = ((proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id).AsEnumerable().Count()).ToString();

                    //      Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRows));
                }
                else
                {

                    RendezVousExisiteGrid.ItemsSource = (proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value)).OrderBy(n => n.Date);
                    MedecinCombo.BorderBrush = Brushes.Red;
                    NBRENDEZVOUS.Text = ((proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value)).AsEnumerable().Count()).ToString();

                    //   Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRows));
                }
                WaitIndicatorS.DeferedVisibility = false;
                BACK.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void DateNOW_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                WaitIndicatorS.DeferedVisibility = true;
                BACK.Visibility = Visibility.Visible;

                if (MedecinCombo.SelectedItem != null)
                {
                    SVC.Medecin SelectMedecin = MedecinCombo.SelectedItem as SVC.Medecin;
                    SalleDattenteGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id);
                    MedecinRecomandationGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id && n.NumFilleAttente > 0);
                    NBSALLEATTENTE.Text = ((proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id && n.Quit == false).AsEnumerable().Count()).ToString();

                }
                else
                {
                    SalleDattenteGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value));
                    MedecinRecomandationGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.NumFilleAttente > 0);
                    MedecinCombo.BorderBrush = Brushes.Red;
                    NBSALLEATTENTE.Text = ((proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value).Where(n => n.Quit == false)).AsEnumerable().Count()).ToString();

                }
                WaitIndicatorS.DeferedVisibility = false;
                BACK.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void PeriodeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (MedecinCombo.SelectedItem != null)
                {
                    var itemsSource = SalleDattenteGrid.ItemsSource as IEnumerable;
                }
                else
                {
                    MedecinCombo.BorderBrush = Brushes.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void MedecinCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (MedecinCombo.SelectedItem != null)
                {
                    SVC.Medecin SelectMedecin = MedecinCombo.SelectedItem as SVC.Medecin;
                    RendezVousExisiteGrid.ItemsSource = (proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id).OrderBy(n => n.Date);
                    NBRENDEZVOUS.Text = ((proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id).AsEnumerable().Count()).ToString();

                    SalleDattenteGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id);
                    MedecinRecomandationGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id && n.NumFilleAttente > 0);
                    NBSALLEATTENTE.Text = ((proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id && n.Quit == false).AsEnumerable().Count()).ToString();
                    //  if(medecinsession==true)
                    //   {
                    VisiteExisiteGrid.ItemsSource = (proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id);
                    txtLabelTotalAregler.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).Where(n => n.CodeMedecin == SelectMedecin.Id)).AsEnumerable().Sum(o => o.Montant));
                    txtLabelTotalversement.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).Where(n => n.CodeMedecin == SelectMedecin.Id)).AsEnumerable().Sum(o => o.Versement));
                    txtLabelTotalReste.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).Where(n => n.CodeMedecin == SelectMedecin.Id)).AsEnumerable().Sum(o => o.Reste));
                    // }

                }
                else
                {
                    RendezVousExisiteGrid.ItemsSource = (proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value)).OrderBy(n => n.Date);
                    NBRENDEZVOUS.Text = ((proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value)).AsEnumerable().Count()).ToString();

                    SalleDattenteGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value));
                    MedecinRecomandationGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.NumFilleAttente > 0);
                    //  NBSALLEATTENTE.Text = ((proxy.GetAllSalleDattente(DateTime.Now.Date, DateTime.Now.Date)).Where(n =>   n.Quit == false).AsEnumerable().Count()).ToString();
                    NBSALLEATTENTE.Text = ((proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.Quit == false).AsEnumerable().Count()).ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }





        private void btnNewSalleAttente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DateNOW.SelectedDate.Value != null && memberuser.CréationSalleAttente == true)
                {
                    SVC.RendezVou selectrendezvous = RendezVousExisiteGrid.SelectedItem as SVC.RendezVou;
                    SVC.Medecin selectmedecin = MedecinCombo.SelectedItem as SVC.Medecin;
                    Arrivée cl = new Arrivée(proxy, memberuser, callback, null, null, DateNOW.SelectedDate.Value, 2, null, null);
                    cl.Show();
                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Vous devez choisir la date d'arrivée ou " + Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                    DateNOW.BorderBrush = Brushes.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SalleDattenteGrid.SelectedItem != null && memberuser.ModificationSalleAttente == true)
                {
                    SVC.SalleDattente SelectSalleATTENTE = SalleDattenteGrid.SelectedItem as SVC.SalleDattente;
                    if (SelectSalleATTENTE.Quit == true)
                    {
                        SelectSalleATTENTE.Quit = false;

                        //  btnExit.ToolTip = "réintégration du patient à la salle d'attente";

                        proxy.UpdateSalleDattenteAsync(SelectSalleATTENTE);
                    }
                    else
                    {
                        SelectSalleATTENTE.Quit = true;

                        //  btnExit.ToolTip= "faire quitter le patient de la salle d'attente";
                        proxy.UpdateSalleDattenteAsync(SelectSalleATTENTE);
                    }
                    proxy.AjouterSalleAtentefRefresh();
                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SalleDattenteGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (SalleDattenteGrid.SelectedItem != null)
                {
                    //   btnExit.IsEnabled = true;
                    btnSupp.IsEnabled = true;
                    /*  SVC.SalleDattente SelectSalleATTENTE = SalleDattenteGrid.SelectedItem as SVC.SalleDattente;
                      if (SelectSalleATTENTE.Quit == true)
                      {


                          btnExit.ToolTip = "réintégration du patient à la salle d'attente";


                      }
                      else
                      {


                          btnExit.ToolTip = "Patient a quitter la salle d'attente sans consultation";
                          btnSupp.IsEnabled = false;
                      }*/

                }
                else
                {
                    //  btnExit.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnImprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (memberuser.ImpressionSalleAttente == true)
                {
                    var itemsSource0 = SalleDattenteGrid.ItemsSource as IEnumerable;// List<SVC.SalleDattente>;
                    List<SVC.SalleDattente> itemsSource1 = new List<SVC.SalleDattente>();
                    foreach (SVC.SalleDattente item in itemsSource0)
                    {
                        itemsSource1.Add(item);
                    }
                    ImpressionSalleAttente cl = new ImpressionSalleAttente(proxy, itemsSource1);
                    cl.Show();
                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
                    DateNOW.BorderBrush = Brushes.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnDossier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MedecinRecomandationGrid.SelectedItem != null && memberuser.ModuleDossierPatient == true)
                {
                    SVC.SalleDattente SelectMedecin1 = MedecinRecomandationGrid.SelectedItem as SVC.SalleDattente;
                    SVC.Patient SelectMedecin = (proxy.GetAllPatient()).Where(n => n.Id == SelectMedecin1.CodePatient).First();
                    if(SelectMedecin1.FinDeConsultation != true)
                    {
                        if (SelectMedecin1.NuméroRendezVous != "")
                        {
                            if (/*(*/medecinSelected != null /*&& SelectMedecin.SuiviParCode == medecinSelected.Id)*/|| memberuser.AccèsToutLesDossierPatient == true)
                            {
                                DossierPatient dd = new DossierPatient(proxy, SelectMedecin, callback, memberuser, SelectMedecin1.NuméroRendezVous, medecinSelected, localclient);
                                dd.Show();
                            }
                            else
                            {
                                if (memberuser.AccèsToutLesDossierPatient == true)
                                {
                                    DossierPatient dd = new DossierPatient(proxy, SelectMedecin, callback, memberuser, SelectMedecin1.NuméroRendezVous, null, localclient);
                                    dd.Show();
                                }
                                else
                                {
                                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                                }
                            }
                        }
                        else
                        {
                            if ((medecinSelected != null && SelectMedecin.SuiviParCode == medecinSelected.Id) || memberuser.AccèsToutLesDossierPatient == true)
                            {
                                DossierPatient dd = new DossierPatient(proxy, SelectMedecin, callback, memberuser, SelectMedecin1.NuméroRendezVous, medecinSelected, localclient);
                                dd.Show();
                            }
                            else
                            {
                                if (memberuser.AccèsToutLesDossierPatient == true)
                                {
                                    DossierPatient dd = new DossierPatient(proxy, SelectMedecin, callback, memberuser, SelectMedecin1.NuméroRendezVous, null, localclient);
                                    dd.Show();
                                }
                                else
                                {
                                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                                }
                            }
                        }
                    }else
                    {
                        MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Pour ouvrir le dossier patient vous devez parcourir la liste des patients", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);


                    }
                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }
            }
            catch (Exception ex)
            {

                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SalleDattenteGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (SalleDattenteGrid.SelectedItem != null && DateNOW.SelectedDate.Value != null)
                {

                    SVC.SalleDattente selectssalleattente = SalleDattenteGrid.SelectedItem as SVC.SalleDattente;
                    SVC.Medecin SelectMedecin = (proxy.GetAllMedecin()).Where(n => n.Id == selectssalleattente.CodeMedecin).First();
                    SVC.Patient SelectMedecing = (proxy.GetAllPatient()).Where(n => n.Id == selectssalleattente.CodePatient).First();
                    Arrivée cl = new Arrivée(proxy, memberuser, callback, null, SelectMedecin, DateNOW.SelectedDate.Value, 3, SelectMedecing, selectssalleattente);

                    cl.Show();

                }
            }
            catch (Exception ex)
            {

                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnSupp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SalleDattenteGrid.SelectedItem != null && memberuser.SupressionSalleAttente == true)
                {
                    bool ResultRendez = false;
                    bool ResultSalle = false;

                    SVC.SalleDattente selectssalleattente = SalleDattenteGrid.SelectedItem as SVC.SalleDattente;
                    if (selectssalleattente.NuméroRendezVous != "Sans Rendez Vous" && selectssalleattente.MedecinSalle == false && selectssalleattente.TempsQuitMedecinSalle == null && selectssalleattente.FinDeConsultation == false)
                    {
                        using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                        {

                            SVC.RendezVou SelectMedecin = (proxy.GetAllRendezVousParPatient(selectssalleattente.CodePatient.Value)).Where(n => n.NuméroRendezVous == selectssalleattente.NuméroRendezVous).First();

                            SelectMedecin.Confirm = false;
                            proxy.DeleteSalleDattente(selectssalleattente);
                            ResultSalle = true;
                            proxy.UpdateRendezVous(SelectMedecin);
                            ResultRendez = true;
                            //   this.Title = "Opération réussie ! ";
                            if (ResultSalle && ResultRendez)
                            {
                                ts.Complete();
                            }


                        }
                        proxy.AjouterSalleAtentefRefresh();
                        proxy.AjouterRendezVOUSfRefresh();
                    }

                    else
                    {
                        if (selectssalleattente.NuméroRendezVous == "Sans Rendez Vous" && selectssalleattente.MedecinSalle == false && selectssalleattente.TempsQuitMedecinSalle == null)
                        {
                            using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                            {
                                proxy.DeleteSalleDattente(selectssalleattente);
                                ts.Complete();
                                //       this.Title = "Opération réussie ! ";
                            }
                            proxy.AjouterSalleAtentefRefresh();
                        }
                        else
                        {
                            MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                    }

                }
                else
                {
                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SalleDattenteGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                e.Row.Header = (e.Row.GetIndex() + 1).ToString();

                SVC.SalleDattente RowDataContaxt = e.Row.DataContext as SVC.SalleDattente;
                if (RowDataContaxt != null)
                {
                    var converter = new System.Windows.Media.BrushConverter();

                    if (RowDataContaxt.Quit == true)
                        e.Row.Background = (Brush)converter.ConvertFromString(SalleAttenteQuit);
                    else if (RowDataContaxt.Quit == false)
                        e.Row.Background = (Brush)converter.ConvertFromString(SalleAttenteTjr);

                }
            }
            catch (Exception ex)
            {

                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnchezNonlemedecin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool ResultItem = false;
                bool ResultMedecinSalle = false;
                bool ResultFilleAttente = false;

                if (MedecinRecomandationGrid.SelectedItem != null && memberuser.ModificationSalleAttente == true && /*MedecinCombo.SelectedItem != null &&*/ DateNOW.SelectedDate.Value != null)
                {
                    SVC.SalleDattente selectssalleattente = MedecinRecomandationGrid.SelectedItem as SVC.SalleDattente;
                    if (selectssalleattente.Quit == true && selectssalleattente.MedecinSalle == true && selectssalleattente.TempsQuitMedecinSalle == null)
                    {
                        using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                        {
                            SVC.Medecin SelectMedecin = MedecinCombo.SelectedItem as SVC.Medecin;

                            var itemsSource0 = MedecinRecomandationGrid.ItemsSource as IEnumerable;


                            foreach (SVC.SalleDattente item in itemsSource0)
                            {
                                ResultItem = false;
                                if (item.NumFilleAttente > selectssalleattente.NumFilleAttente)
                                {
                                    item.NumFilleAttente = item.NumFilleAttente - 1;
                                    proxy.UpdateSalleDattente(item);
                                    ResultItem = true;

                                }

                            }

                            selectssalleattente.NumFilleAttente = 0;
                            selectssalleattente.TempsChezMedecinSalle = null;
                            selectssalleattente.TempsQuitMedecinSalle = null;
                            selectssalleattente.MedecinSalle = false;
                            selectssalleattente.Quit = false;
                            selectssalleattente.FinDeConsultation = false;
                            proxy.UpdateSalleDattente(selectssalleattente);

                            ResultMedecinSalle = true;
                            ResultFilleAttente = true;
                            if (ResultItem && ResultMedecinSalle)
                            {
                                ts.Complete();
                                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Patient " + selectssalleattente.Nom + " " + selectssalleattente.Prénom + " à réintégré la salle d'attente", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                            else
                            {
                                if (ResultMedecinSalle && ResultFilleAttente)
                                {
                                    ts.Complete();
                                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Patient " + selectssalleattente.Nom + " " + selectssalleattente.Prénom + " à réintégré la salle d'attente", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                                else
                                {
                                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                        proxy.AjouterSalleAtentefRefresh();
                    }
                    else
                    {
                        MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Patient " + selectssalleattente.Nom + " " + selectssalleattente.Prénom + " ne peut plus réintégré la salle d'attente", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
                else
                {
                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnchezlemedecin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool succesoperation = false;
                if (SalleDattenteGrid.SelectedItem != null && memberuser.ModificationSalleAttente == true/* && MedecinCombo.SelectedItem != null */&& DateNOW.SelectedDate.Value != null)
                {

                    SVC.SalleDattente selectssalleattente = SalleDattenteGrid.SelectedItem as SVC.SalleDattente;
                    if (selectssalleattente.Quit == false && selectssalleattente.MedecinSalle == false)

                    {
                        // SVC.Medecin SelectMedecin = MedecinCombo.SelectedItem as SVC.Medecin;
                        SVC.Medecin SelectMedecin = proxy.GetAllMedecin().Find(n => n.Id == selectssalleattente.CodeMedecin);
                        var num = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.CodeMedecin == SelectMedecin.Id && n.NumFilleAttente > 0).Count();
                        SVC.Patient patientdem = (proxy.GetAllPatient()).Find(n => n.Id == selectssalleattente.CodePatient);
                        using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                        {
                            selectssalleattente.NumFilleAttente = num + 1;
                            selectssalleattente.MedecinSalle = true;
                            selectssalleattente.Quit = true;
                            selectssalleattente.FinDeConsultation = false;
                            selectssalleattente.TempsChezMedecinSalle = DateTime.Now.TimeOfDay;
                            proxy.UpdateSalleDattente(selectssalleattente);
                            succesoperation = true;
                            if (succesoperation == true)
                            {
                                ts.Complete();
                            }

                        }

                        proxy.AjouterSalleAtentefRefresh();
                        proxy.SalleAttenteDemandeChezLeMedecin(patientdem, selectssalleattente);
                    }
                    else
                    {
                        MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Ce patient est déja chez le medecin où il n'est plus dans la salle d'attente", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error); DateNOW.BorderBrush = Brushes.Red;
                }
            }
            catch (Exception ex)
            {

                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RendezVousExisiteGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                SVC.RendezVou RowDataContaxt = e.Row.DataContext as SVC.RendezVou;
                if (RowDataContaxt != null)
                {
                    var converter = new System.Windows.Media.BrushConverter();

                    if (RowDataContaxt.Confirm == true)
                        e.Row.Background = (Brush)converter.ConvertFromString(RdvPresent);
                    else if (RowDataContaxt.Confirm == false)
                        e.Row.Background = (Brush)converter.ConvertFromString(RdvNoPresent);

                }
            }
            catch (Exception ex)
            {

                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MedecinRecomandationGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                SVC.SalleDattente RowDataContaxt = e.Row.DataContext as SVC.SalleDattente;
                if (RowDataContaxt != null)
                {
                    var converter = new System.Windows.Media.BrushConverter();

                    if (RowDataContaxt.FinDeConsultation == true)
                        e.Row.Background = (Brush)converter.ConvertFromString(MedecinSalleNON);
                    else if (RowDataContaxt.FinDeConsultation == false)
                        e.Row.Background = (Brush)converter.ConvertFromString(MedecinSalleTjr);

                }
            }
            catch (Exception ex)
            {

                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void VisiteExisiteGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                SVC.Visite RowDataContaxt = e.Row.DataContext as SVC.Visite;
                if (RowDataContaxt != null)
                {
                    var converter = new System.Windows.Media.BrushConverter();

                    if (RowDataContaxt.Soldé == true)
                        e.Row.Background = (Brush)converter.ConvertFromString(VisteRéglé);
                    else if (RowDataContaxt.Soldé == false)
                        e.Row.Background = (Brush)converter.ConvertFromString(VisteNonRéglé);

                }
            }
            catch (Exception ex)
            {

                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(RendezVousExisiteGrid.ItemsSource);
                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.RendezVou p = o as SVC.RendezVou;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.Nom.ToUpper().StartsWith(filter.ToUpper()));
                    };
                }
            }
            catch
            {

            }
        }

        private void btnQuitter_MouseMove(object sender, MouseEventArgs e)
        {
            var imageBrush = (ImageBrush)btnQuitter.Background;
            imageBrush.Stretch = Stretch.Fill;
            btnQuitter.Width = 50;
            btnQuitter.Height = 50;

        }

        private void btnQuitter_MouseLeave(object sender, MouseEventArgs e)
        {
            var imageBrush = (ImageBrush)btnQuitter.Background;
            imageBrush.Stretch = Stretch.Fill;
            btnQuitter.Width = 30;
            btnQuitter.Height = 30;
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MedecinRecomandationGrid.SelectedItem != null && memberuser.ModificationSalleAttente == true /*&& MedecinCombo.SelectedItem != null*/ && DateNOW.SelectedDate.Value != null)
                {

                    SVC.SalleDattente selectssalleattente = MedecinRecomandationGrid.SelectedItem as SVC.SalleDattente;
                    if (selectssalleattente.Quit == true)
                    {
                        MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Attention ! si vous confirmer la fin de consultation le patient ne pourra plus réintégrer la salle d'attente", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            selectssalleattente.MedecinSalle = true;

                            selectssalleattente.FinDeConsultation = true;
                            selectssalleattente.TempsQuitMedecinSalle = DateTime.Now.TimeOfDay;
                            using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                            {
                                proxy.UpdateSalleDattente(selectssalleattente);
                                ts.Complete();
                            }
                            proxy.AjouterSalleAtentefRefresh();
                            MessageBoxResult results = Xceed.Wpf.Toolkit.MessageBox.Show("Fin de consultation pour ce patient", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                        }


                    }
                }

                else
                {
                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

         
        private void btnFiche_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MedecinRecomandationGrid.SelectedItem != null && memberuser.ModificationPatient == true)
                {
                    SVC.SalleDattente selectedsall = MedecinRecomandationGrid.SelectedItem as SVC.SalleDattente;
                    SVC.Patient selectedpatient = proxy.GetAllPatientBYID(Convert.ToInt16(selectedsall.CodePatient)).First();

                    Patient.NewPatient cl = new NewPatient(proxy, memberuser, selectedpatient);
                    cl.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNewSalleAttente_MouseLeave(object sender, MouseEventArgs e)
        {
            var imageBrush = (ImageBrush)btnNewSalleAttente.Background;
            imageBrush.Stretch = Stretch.Fill;
        }

        private void btnNewSalleAttente_MouseMove(object sender, MouseEventArgs e)
        {
            var imageBrush = (ImageBrush)btnNewSalleAttente.Background;
            imageBrush.Stretch = Stretch.Uniform;
            btnNewSalleAttente.Width = 30;
            btnNewSalleAttente.Height = 30;
        }

        private void DateVisite_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                /****************il faudrait panser a réglement pour tous ou pour chaque medecin*****************/
                //    
                if (MedecinCombo.SelectedItem != null)
                {
                    SVC.Medecin medecinSelected1 = MedecinCombo.SelectedItem as SVC.Medecin;

                    if (DateVisite.SelectedDate != null)
                    {


                        VisiteExisiteGrid.ItemsSource = (proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value)).Where(n => n.CodeMedecin == medecinSelected1.Id);
                        txtLabelTotalAregler.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).Where(n => n.CodeMedecin == medecinSelected1.Id)).AsEnumerable().Sum(o => o.Montant));
                        txtLabelTotalversement.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).Where(n => n.CodeMedecin == medecinSelected1.Id)).AsEnumerable().Sum(o => o.Versement));
                        txtLabelTotalReste.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).Where(n => n.CodeMedecin == medecinSelected1.Id)).AsEnumerable().Sum(o => o.Reste));

                    }
                    else
                    {

                        VisiteExisiteGrid.ItemsSource = (proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value)).Where(n => n.CodeMedecin == medecinSelected1.Id);
                        MedecinCombo.BorderBrush = Brushes.Red;
                        txtLabelTotalAregler.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).Where(n => n.CodeMedecin == medecinSelected1.Id)).AsEnumerable().Sum(o => o.Montant));
                        txtLabelTotalversement.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).Where(n => n.CodeMedecin == medecinSelected1.Id)).AsEnumerable().Sum(o => o.Versement));
                        txtLabelTotalReste.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).Where(n => n.CodeMedecin == medecinSelected1.Id)).AsEnumerable().Sum(o => o.Reste));
                    }
                }
                else
                {

                    if (DateVisite.SelectedDate != null)
                    {


                        VisiteExisiteGrid.ItemsSource = (proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value));

                        txtLabelTotalAregler.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).AsEnumerable().Sum(o => o.Montant)));
                        txtLabelTotalversement.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).AsEnumerable().Sum(o => o.Versement)));
                        txtLabelTotalReste.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).AsEnumerable().Sum(o => o.Reste)));
                    }
                    else
                    {

                        VisiteExisiteGrid.ItemsSource = (proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value));
                        MedecinCombo.BorderBrush = Brushes.Red;

                        txtLabelTotalAregler.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value)).AsEnumerable().Sum(o => o.Montant));
                        txtLabelTotalversement.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value)).AsEnumerable().Sum(o => o.Versement));
                        txtLabelTotalReste.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value)).AsEnumerable().Sum(o => o.Reste));

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //    Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRowsRéglementVisite));
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = sender as TabControl;
            // ... Set Title to selected tab header.
            var selected = item.SelectedItem as TabItem;
            if (selected.Name == "RéglementTab")
            {
                //   Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRowsRéglementVisite));
            }
            else
            {/////ProcessRows()
                if (selected.Name == "RendezVousTab")
                {
                    //    Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, new Action(ProcessRows));

                }
            }
        }








        private void btnNewRéglement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (memberuser.CréationCaisse == true && VisiteExisiteGrid.SelectedItem != null)
                {

                    SVC.Visite SelectMedecin = VisiteExisiteGrid.SelectedItem as SVC.Visite;
                    if (SelectMedecin.Reste != 0)
                    {
                        AjouterTransaction bn = new AjouterTransaction(proxy, memberuser, callback, null, 3, SelectMedecin, null);
                        bn.Show();
                    }
                    else
                    {
                        MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Facture déja soldé", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
                    }

                }
                else
                {
                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnModifierRéglemtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (memberuser.ImressionCaisse == true && VisiteExisiteGrid.SelectedItem != null)
                {
                    SVC.Visite SelectMedecin = VisiteExisiteGrid.SelectedItem as SVC.Visite;
                    var patient = (proxy.GetAllPatient()).Find(n => n.Id == SelectMedecin.CodePatient);
                    VersementPatient cl = new VersementPatient(proxy, memberuser, callback, patient, SelectMedecin, false);
                    cl.Show();
                }
                else
                {
                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void MedecinCombo_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (medecinsession == false)
                {

                    RendezVousExisiteGrid.ItemsSource = (proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value).OrderBy(n => n.Date));
                    NBRENDEZVOUS.Text = ((proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value)).AsEnumerable().Count()).ToString();

                    SalleDattenteGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value));
                    MedecinRecomandationGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.NumFilleAttente > 0);
                    MedecinCombo.ItemsSource = proxy.GetAllMedecin().OrderBy(n => n.Nom);
                    NBSALLEATTENTE.Text = ((proxy.GetAllSalleDattente(DateTime.Now.Date, DateTime.Now.Date)).Where(n => n.Quit == false).AsEnumerable().Count()).ToString();
                    VisiteExisiteGrid.ItemsSource = (proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value));

                    txtLabelTotalAregler.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).AsEnumerable().Sum(o => o.Montant)));
                    txtLabelTotalversement.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).AsEnumerable().Sum(o => o.Versement)));
                    txtLabelTotalReste.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).AsEnumerable().Sum(o => o.Reste)));

                }

                else
                {
                    RendezVousExisiteGrid.ItemsSource = (proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value).OrderBy(n => n.Date));
                    NBRENDEZVOUS.Text = ((proxy.GetAllRendezVous(DateNOWRendez.SelectedDate.Value, DateNOWRendez.SelectedDate.Value)).AsEnumerable().Count()).ToString();

                    SalleDattenteGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value));
                    MedecinRecomandationGrid.ItemsSource = (proxy.GetAllSalleDattente(DateNOW.SelectedDate.Value, DateNOW.SelectedDate.Value)).Where(n => n.NumFilleAttente > 0);
                    MedecinCombo.ItemsSource = proxy.GetAllMedecin().OrderBy(n => n.Nom);
                    NBSALLEATTENTE.Text = ((proxy.GetAllSalleDattente(DateTime.Now.Date, DateTime.Now.Date)).Where(n => n.Quit == false).AsEnumerable().Count()).ToString();

                    VisiteExisiteGrid.ItemsSource = (proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value));

                    txtLabelTotalAregler.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).AsEnumerable().Sum(o => o.Montant)));
                    txtLabelTotalversement.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).AsEnumerable().Sum(o => o.Versement)));
                    txtLabelTotalReste.Content = Convert.ToString((proxy.GetAllVisite(DateVisite.SelectedDate.Value, DateVisite.SelectedDate.Value).AsEnumerable().Sum(o => o.Reste)));

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


    }
}
