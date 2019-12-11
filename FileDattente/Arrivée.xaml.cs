using DevExpress.Xpf.Core;
using dragonz.actb.core;
using dragonz.actb.provider;
using Medicus.Administrateur;
using Medicus.Patient;
using MahApps.Metro.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Arrivée.xaml
    /// </summary>
    public partial class Arrivée : MetroWindow
    {
        SVC.ServiceCliniqueClient proxy;
        SVC.Membership UserMembership;
        ICallback callback;
        SVC.RendezVou rendezvous;
        SVC.Medecin MedecinForSalleAttente;
        SVC.Patient PatientSalleDattente;
        SVC.SalleDattente SalleAttenteP;
        int interf;
        DateTime DateSalleAttente;
        private delegate void FaultedInvokerArriv();
        int IndexOfPatient;
        bool auto = false;
        /*******************************************/


        public Arrivée(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership memberrecu, ICallback callbackrecu, SVC.RendezVou rendezvousrecu, SVC.Medecin medecinrecu, DateTime DateRecu, int interfacerecu, SVC.Patient patientrecu, SVC.SalleDattente salleattenterecu)
        {
            try
            {
                InitializeComponent();
                proxy = proxyrecu;
                UserMembership = memberrecu;
                callback = callbackrecu;
                rendezvous = rendezvousrecu;
                DateSalleAttente = DateRecu;
                MedecinForSalleAttente = medecinrecu;
                interf = interfacerecu;
                txtdateRendezVous.Content = DateRecu.ToLongDateString();

                /************ne pas oublié dans tout les interfaces*****************/

                callbackrecu.InsertPatientCallbackEvent += new ICallback.CallbackEventHandler7(callbackrecu_Refresh);
                proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);

                proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);
                /*dans la salle d'attente button in datagrid rendez vous        */
                if (interf == 1)
                {

                    List<SVC.Medecin> testmedecin = proxy.GetAllMedecin().OrderBy(n => n.Nom).ToList();
                    txtMedecin.ItemsSource = testmedecin;
                    List<SVC.Medecin> tte = testmedecin.Where(n => n.Id == MedecinForSalleAttente.Id).OrderBy(n => n.Nom).ToList();
                    txtMedecin.SelectedItem = tte.First();

                    List<SVC.Patient> testmedecin1 = proxy.GetAllPatientBYID(rendezvous.CodePatient.Value).OrderBy(n => n.Nom).ToList();
                    txtPatient.ItemsSource = testmedecin1;
                    List<SVC.Patient> tte1 = testmedecin1.Where(n => n.Id == rendezvous.CodePatient).OrderBy(n => n.Nom).ToList();
                    txtPatient.SelectedItem = tte1.First();
                    txtPatient.IsEnabled = false;
                        
                    txtArrivée.Text = Convert.ToString(DateTime.Now.TimeOfDay);

                    txtFonction.ItemsSource = proxy.GetAllMotifVisite().OrderBy(n => n.Motif);
                    RendezVousGrid.DataContext = rendezvousrecu;
                    //  txtFonction.SelectedValue = rendezvousrecu.Motif.ToString();

                    PatientSalleDattente = tte1.First();
                    txtPatient.IsEnabled = false;
                    //  txtMedecin.IsEnabled = false;
                    btnPatient.IsEnabled = false;
                    txtPatient.Visibility = Visibility.Visible;
                    accbStates.Visibility = Visibility.Collapsed;
                    auto = false;
                }
                else
                {/* 1-Arrivage dans liste home.xaml c-a-d patient connu  
                    2-Arrivée sans rendez vous dans la salle d'attente patient non connu
                    */
                    if (interf == 2)
                    {
                        if (patientrecu != null)
                        {
                            PatientSalleDattente = patientrecu;
                            List<SVC.Medecin> testmedecin = proxy.GetAllMedecin().OrderBy(n => n.Nom).ToList();
                            txtMedecin.ItemsSource = testmedecin;
                            List<SVC.Medecin> tte = testmedecin.Where(n => n.Nom == PatientSalleDattente.SuiviParNom && n.Prénom == PatientSalleDattente.SuiviParPrénom).OrderBy(n => n.Nom).ToList();
                            txtMedecin.SelectedItem = tte.First();

                            List<SVC.Patient> testmedecin1 = proxy.GetAllPatientBYID(PatientSalleDattente.Id).OrderBy(n => n.Nom).ToList();
                            txtPatient.ItemsSource = testmedecin1;

                            List<SVC.Patient> tte1 = testmedecin1.Where(n => n.Id == PatientSalleDattente.Id).OrderBy(n => n.Nom).ToList();
                            txtPatient.SelectedItem = tte1.First();
                            txtPatient.IsEnabled = false;
                            txtArrivée.Text = Convert.ToString(DateTime.Now.TimeOfDay);

                            txtFonction.ItemsSource = proxy.GetAllMotifVisite().OrderBy(n => n.Motif);
                            txtPatient.IsEnabled = false;
                            txtPatient.Visibility = Visibility.Visible;
                            accbStates.Visibility = Visibility.Collapsed;
                            auto = false;

                        }
                        else
                        {
                            List<SVC.Medecin> testmedecin = proxy.GetAllMedecin().OrderBy(n => n.Nom).ToList();
                            txtMedecin.ItemsSource = testmedecin;
                            txtMedecin.SelectedIndex = 0;

                            txtArrivée.Text = Convert.ToString(DateTime.Now.TimeOfDay);
                            txtFonction.ItemsSource = proxy.GetAllMotifVisite().OrderBy(n => n.Motif);
                            List<SVC.Patient> pp = new List<SVC.Patient>();
                            accbStates.ItemsSource = pp;
                            txtPatient.Visibility = Visibility.Collapsed;

                            auto = true;

                        }



                    }
                    else
                    {
                        if (interf == 3)
                        {
                            SalleAttenteP = salleattenterecu;
                            List<SVC.Medecin> testmedecin = proxy.GetAllMedecin().OrderBy(n => n.Nom).ToList();
                            txtMedecin.ItemsSource = testmedecin;
                            List<SVC.Medecin> tte = testmedecin.Where(n => n.Id == MedecinForSalleAttente.Id).OrderBy(n => n.Nom).ToList();
                            txtMedecin.SelectedItem = tte.First();

                            List<SVC.Patient> testmedecin1 = proxy.GetAllPatientBYID(patientrecu.Id).OrderBy(n => n.Nom).ToList();
                            txtPatient.ItemsSource = testmedecin1;
                            List<SVC.Patient> tte1 = testmedecin1.Where(n => n.Id == patientrecu.Id).OrderBy(n => n.Nom).ToList();
                            txtPatient.SelectedItem = tte1.First();
                            txtPatient.IsEnabled = false;
                            List<SVC.MotifVisite> testmotif = proxy.GetAllMotifVisite().OrderBy(n => n.Motif).ToList();
                            txtFonction.ItemsSource = testmotif;
                            //List<SVC.MotifVisite> ttemitif = testmotif.Where(n => n.Motif == salleattenterecu.Motif).ToList();
                            txtFonction.SelectedItem = salleattenterecu.Motif;
                            txtArrivée.Text = salleattenterecu.Arrivée.ToString();
                            RendezVousGrid.DataContext = SalleAttenteP;
                            txtPatient.Visibility = Visibility.Visible;
                            accbStates.Visibility = Visibility.Collapsed;
                            auto = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        void callbackrecu_Refresh(object source, CallbackEventInsertPatient e)
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
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        public void AddRefresh(SVC.Patient listmembership, int oper)
        {
            try
            { 
            if (auto == false)
            {
                var LISTITEM1 = txtPatient.ItemsSource as IEnumerable<SVC.Patient>;
                List<SVC.Patient> LISTITEM = LISTITEM1.ToList();

                if (oper == 1)
                {
                    LISTITEM.Add(listmembership);
                }
                else
                {
                    if (oper == 2)
                    {
                        //   var objectmodifed = LISTITEM.Find(n => n.Id == listmembership.Id);
                        // objectmodifed = listmembership;

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

                txtPatient.ItemsSource = LISTITEM;
            }
            else
            {
                if (auto == true)
                {
                    var LISTITEM11 = accbStates.ItemsSource as IEnumerable<SVC.Patient>;
                    List<SVC.Patient> LISTITEM0 = LISTITEM11.ToList();

                    if (oper == 1)
                    {
                        LISTITEM0.Add(listmembership);
                    }
                    else
                    {
                        if (oper == 2)
                        {
                            //var objectmodifed = LISTITEM0.Find(n => n.Id == listmembership.Id);
                            // var objectmodifed = listmembership;


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


                    accbStates.ItemsSource = LISTITEM0;
                    //        accbStates.AutoCompleteManager.DataProvider = new SimpleStaticDataProvider(from c in LISTITEM0
                    //                         select c.Nom + " " + c.Prénom);

                    //      accbStates.AutoCompleteManager.AutoAppend = true;
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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerArriv(HandleProxy));
                return;
            }
            HandleProxy();
        }

        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerArriv(HandleProxy));
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
                bool RendezVousResult = false;
                bool SalleAttenteResult = false;
                /*dans la salle d'attente button in datagrid rendez vous        */
                if (interf == 1 && UserMembership.CréationSalleAttente == true && txtFonction.SelectedItem!=null && txtArrivée.Text!="" && txtMedecin.SelectedItem!=null)
                {
                    using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                    {
                        rendezvous.Confirm = true;
                        SVC.Medecin SelectMedecin = txtMedecin.SelectedItem as SVC.Medecin;
                        SVC.MotifVisite SelectMotif = txtFonction.SelectedItem as SVC.MotifVisite;
                        SVC.SalleDattente sl = new SVC.SalleDattente
                        {
                            Nom = rendezvous.Nom,
                            Prénom = rendezvous.Prénom,
                            Arrivée = TimeSpan.Parse(txtArrivée.Text),
                            Rdv = rendezvous.RendezVousD,
                            DateRendez = rendezvous.Date,
                            DateArrivée = DateSalleAttente,
                            DateDeNaissance = PatientSalleDattente.DateDeNaissance,
                            Age = Convert.ToInt16(DateTime.Now.Date.Year - (PatientSalleDattente.DateDeNaissance).Value.Year),
                            Commentaire = txtCommentaire.Text,
                            NomMedecin = SelectMedecin.Nom,
                            PrénomMedecin = SelectMedecin.Prénom,
                            NuméroRendezVous = rendezvous.NuméroRendezVous,
                            CodePatient = rendezvous.CodePatient,
                            Quit = false,
                            Motif = SelectMotif.Motif,
                            MedecinSalle = false,
                            NumFilleAttente = 0,
                            FinDeConsultation = false,
                            CodeMedecin = SelectMedecin.Id,
                        };
                        proxy.UpdateRendezVous(rendezvous);
                        RendezVousResult = true;
                        proxy.InsertSalleDatente(sl);
                        SalleAttenteResult = true;
                        if (RendezVousResult && SalleAttenteResult)
                        {
                            ts.Complete();

                        }
                        else
                        {
                            MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                        if (RendezVousResult && SalleAttenteResult)
                        {
                            proxy.AjouterSalleAtentefRefresh();
                            proxy.AjouterRendezVOUSfRefresh();
                            MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                        }
        
                }
                else
                {
                    if (interf == 2 && UserMembership.CréationSalleAttente == true && txtFonction.SelectedItem != null && txtArrivée.Text != "" && txtMedecin.SelectedItem != null)
                    {
                        using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                        {

                            if (PatientSalleDattente != null)
                            {
                                SVC.Medecin SelectMedecin = txtMedecin.SelectedItem as SVC.Medecin;
                                SVC.Patient selectpatient = PatientSalleDattente;// txtPatient.SelectedItem as SVC.Patient;
                                SVC.MotifVisite SelectMotif = txtFonction.SelectedItem as SVC.MotifVisite;
                                SVC.SalleDattente sl = new SVC.SalleDattente
                                {
                                    Nom = selectpatient.Nom,
                                    Prénom = selectpatient.Prénom,
                                    Arrivée = TimeSpan.Parse(txtArrivée.Text),
                                    Rdv = TimeSpan.Parse(txtArrivée.Text),
                                    DateRendez = DateSalleAttente,
                                    DateArrivée = DateSalleAttente,
                                    DateDeNaissance = selectpatient.DateDeNaissance,
                                    Age = Convert.ToInt16(DateTime.Now.Date.Year - (selectpatient.DateDeNaissance).Value.Year),
                                    Commentaire = txtCommentaire.Text,
                                    NomMedecin = SelectMedecin.Nom,
                                    PrénomMedecin = SelectMedecin.Prénom,
                                    NuméroRendezVous = "Sans Rendez Vous",
                                    CodePatient = selectpatient.Id,
                                    Quit = false,
                                    Motif = SelectMotif.Motif,
                                    MedecinSalle = false,
                                    NumFilleAttente = 0,
                                    FinDeConsultation = false,
                                    CodeMedecin = SelectMedecin.Id,

                                };

                                proxy.InsertSalleDatente(sl);
                                SalleAttenteResult = true;
                            }
                            else
                            {
                                SVC.Medecin SelectMedecin = txtMedecin.SelectedItem as SVC.Medecin;
                                SVC.Patient selectpatient = proxy.GetAllPatientNomPrenom(accbStates.Text.Trim());
                                SVC.MotifVisite SelectMotif = txtFonction.SelectedItem as SVC.MotifVisite;
                                SVC.SalleDattente sl = new SVC.SalleDattente
                                {
                                    Nom = selectpatient.Nom,
                                    Prénom = selectpatient.Prénom,
                                    Arrivée = TimeSpan.Parse(txtArrivée.Text),
                                    Rdv = TimeSpan.Parse(txtArrivée.Text),
                                    DateRendez = DateSalleAttente,
                                    DateArrivée = DateSalleAttente,
                                    DateDeNaissance = selectpatient.DateDeNaissance,
                                    Age = Convert.ToInt16(DateTime.Now.Date.Year - (selectpatient.DateDeNaissance).Value.Year),
                                    Commentaire = txtCommentaire.Text,
                                    NomMedecin = SelectMedecin.Nom,
                                    PrénomMedecin = SelectMedecin.Prénom,
                                    NuméroRendezVous = "Sans Rendez Vous",
                                    CodePatient = selectpatient.Id,
                                    Quit = false,
                                    Motif = SelectMotif.Motif,
                                    CodeMedecin = SelectMedecin.Id,
                                    MedecinSalle = false,
                                    NumFilleAttente = 0,
                                    FinDeConsultation = false,
                                };

                                proxy.InsertSalleDatente(sl);
                                SalleAttenteResult = true;
                            }






                            if (SalleAttenteResult)
                            {
                                ts.Complete();
                              
                            }
                            else
                            {
                                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        if (SalleAttenteResult)
                        {
                            proxy.AjouterSalleAtentefRefresh();

                            MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        if (interf == 3 && UserMembership.ModificationSalleAttente == true && txtFonction.SelectedItem != null && txtArrivée.Text != "" && txtMedecin.SelectedItem != null)
                        {
                            using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                            {
                                SVC.Medecin SelectMedecin = txtMedecin.SelectedItem as SVC.Medecin;
                                SVC.Patient selectpatient = txtPatient.SelectedItem as SVC.Patient;
                                SVC.MotifVisite SelectMotif = txtFonction.SelectedItem as SVC.MotifVisite;

                                SalleAttenteP.Age = Convert.ToInt16(DateTime.Now.Date.Year - (selectpatient.DateDeNaissance).Value.Year);
                                SalleAttenteP.Arrivée = TimeSpan.Parse(txtArrivée.Text);
                                SalleAttenteP.CodePatient = selectpatient.Id;
                                SalleAttenteP.Commentaire = txtCommentaire.Text;
                                //  SalleAttenteP.DateArrivée = DateTime.Now;

                                SalleAttenteP.DateDeNaissance = selectpatient.DateDeNaissance;
                                SalleAttenteP.Motif = SelectMotif.Motif;
                                SalleAttenteP.Nom = selectpatient.Nom;
                                SalleAttenteP.Prénom = selectpatient.Prénom;

                                SalleAttenteP.NomMedecin = SelectMedecin.Nom;
                                SalleAttenteP.PrénomMedecin = SelectMedecin.Prénom;
                                SalleAttenteP.CodeMedecin = SelectMedecin.Id;
                                /*Rdv+DateRendez+NuméroRendezVous+Quit+MedecinSalle+NumFilleAttente+TempsChezMedecin
                                 * +TempsQuitMededcinSalle+FinDeConsultation */
                                proxy.UpdateSalleDattente(SalleAttenteP);
                                SalleAttenteResult = true;

                                if (SalleAttenteResult)
                                {
                                    ts.Complete();

                                }
                                else
                                {
                                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            if (SalleAttenteResult)
                                {
                                    proxy.AjouterSalleAtentefRefresh();

                                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                           
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            if (UserMembership.CréationPatient == true)
            {
                NewPatient CLNewPatient = new NewPatient(proxy, UserMembership, null);
                CLNewPatient.Show();
            }
            else
            {
                if (UserMembership.CréationPatient != true)
                {
                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            txtArrivée.Text = Convert.ToString(DateTime.Now.TimeOfDay);
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void accbStates_DropDownClosed(object sender, EventArgs e)
        {
            try
            { 
            if (accbStates.SelectedItem != null)
            {
                var t = accbStates.SelectedItem as SVC.Patient;
                accbStates.Text = t.Nom + " " + t.Prénom;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void txtFonction_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            { 
            var box = sender as ComboBox;
            box.IsDropDownOpen = true;
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void txtFonction_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            { 
            var box = sender as ComboBox;
            box.IsDropDownOpen = false;
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void accbStates_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            { 
            if (interf == 2 && auto == true)
            {
                 
                if (accbStates.Text.ToCharArray().Count() == 2)
                {
                    accbStates.ItemsSource = proxy.GetAllPatientPAR(accbStates.Text.ToUpper().Trim());
                    accbStates.AutoCompleteManager.DataProvider = new SimpleStaticDataProvider(from c in proxy.GetAllPatientPAR(accbStates.Text.ToUpper().Trim())
                                                                                               select c.Nom + " " + c.Prénom);

                    accbStates.AutoCompleteManager.AutoAppend = true;
                
                }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
    }
}
