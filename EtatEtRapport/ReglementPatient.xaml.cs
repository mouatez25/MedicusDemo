using DevExpress.Xpf.Core;
using dragonz.actb.provider;
using Medicus.Administrateur;
using Medicus.Caisse;
using Medicus.Patient;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Medicus.EtatEtRapport
{
    /// <summary>
    /// Interaction logic for ReglementPatient.xaml
    /// </summary>
    public partial class ReglementPatient : DXWindow
    {
        SVC.ServiceCliniqueClient proxy;
        ICallback callback;
        SVC.Membership MemberUser;
        private delegate void FaultedInvokerReglementPatient();
      //  SVC.Patient selectedpatient;
       int interfaceimpression=0;
        List<SVC.Visite> visitecredit;
        SVC.Medecin SELECTEDMEDECIN;
        bool medecinsession = false;
        public ReglementPatient(SVC.ServiceCliniqueClient proxyrecu,SVC.Membership memberrecu,ICallback callbackrecu)
        {
            try
            {
                InitializeComponent();
                proxy = proxyrecu;
                callback = callbackrecu;
                MemberUser = memberrecu;
                var disponible = (proxy.GetAllMedecin()).Where(list1 => list1.UserName == MemberUser.UserName).FirstOrDefault();
                if (disponible == null)
                {
                    medecinsession = false;
                    DateVisiteDébut.SelectedDate = DateTime.Now;
                    DateVisiteFin.SelectedDate = DateTime.Now;
                    PatientDataGrid.ItemsSource = proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value);
                    MedecinCombo.ItemsSource = proxy.GetAllMedecin().OrderBy(x => x.Nom);
                   PatientCombo.ItemsSource = proxy.GetAllPatient().OrderBy(x => x.Nom);


                    txtAchat.Text = Convert.ToString((proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).AsEnumerable().Sum(o => o.Montant));
                    TxtVersement.Text = Convert.ToString((proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).AsEnumerable().Sum(o => o.Versement));
                    txtFournisseur.Text = Convert.ToString(((proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).AsEnumerable().Sum(o => o.Reste)));

                    callbackrecu.InsertVisiteCallbackEvent += new ICallback.CallbackEventHandler13(callbackrecu_Refresh);
                   callbackrecu.InsertPatientCallbackEvent += new ICallback.CallbackEventHandler7(callbackrecufourn_Refresh);
                    callbackrecu.InsertMedecinCallbackEvent += new ICallback.CallbackEventHandler6(callbackrecuMedecin_Refresh);


                    proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);

                    proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);
                }else
                {
                    SELECTEDMEDECIN = disponible;
                    medecinsession = true;
                    DateVisiteDébut.SelectedDate = DateTime.Now;
                    DateVisiteFin.SelectedDate = DateTime.Now;
                    PatientDataGrid.ItemsSource = proxy.GetAllVisiteByVisiteMedecin(SELECTEDMEDECIN.Id).Where(n => n.Date >= DateVisiteDébut.SelectedDate && n.Date <= DateVisiteFin.SelectedDate);
                    List<SVC.Medecin> testmedecin = proxy.GetAllMedecin().OrderBy(n => n.Nom).ToList();
                    MedecinCombo.ItemsSource = testmedecin;
                    List<SVC.Medecin> tte = testmedecin.Where(n => n.UserName == MemberUser.UserName).ToList();
                    MedecinCombo.SelectedItem = tte.First();
                  PatientCombo.ItemsSource = proxy.GetAllPatient().Where(n =>n.SuiviParCode==SELECTEDMEDECIN.Id).OrderBy(x => x.Nom);

                    txtAchat.Text = Convert.ToString((proxy.GetAllVisiteByVisiteMedecin(SELECTEDMEDECIN.Id).Where(n=>n.Date>=DateVisiteDébut.SelectedDate && n.Date<=DateVisiteFin.SelectedDate)).AsEnumerable().Sum(o => o.Montant));
                    TxtVersement.Text = Convert.ToString((proxy.GetAllVisiteByVisiteMedecin(SELECTEDMEDECIN.Id).Where(n => n.Date >= DateVisiteDébut.SelectedDate && n.Date <= DateVisiteFin.SelectedDate)).AsEnumerable().Sum(o => o.Versement));
                    txtFournisseur.Text = Convert.ToString(((proxy.GetAllVisiteByVisiteMedecin(SELECTEDMEDECIN.Id).Where(n => n.Date >= DateVisiteDébut.SelectedDate && n.Date <= DateVisiteFin.SelectedDate)).AsEnumerable().Sum(o => o.Reste)));

                    callbackrecu.InsertVisiteCallbackEvent += new ICallback.CallbackEventHandler13(callbackrecu_Refresh);
                   callbackrecu.InsertPatientCallbackEvent += new ICallback.CallbackEventHandler7(callbackrecufourn_Refresh);
                    callbackrecu.InsertMedecinCallbackEvent += new ICallback.CallbackEventHandler6(callbackrecuMedecin_Refresh);
                    MedecinCombo.IsEnabled = false;

                    proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);

                    proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);
                }

            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        void callbackrecu_Refresh(object source, CallbackEventInsertVisite e)
        {
            try
            { 
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
        public void AddRefresh(SVC.Visite listmembership,int oper)
        {
            try
            {
                if (medecinsession == false)
                {
                    var LISTITEM11 = PatientDataGrid.ItemsSource as IEnumerable<SVC.Visite>;
                    List<SVC.Visite> LISTITEM0 = LISTITEM11.ToList();

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


                   




                    PatientDataGrid.ItemsSource = LISTITEM0;
                    txtAchat.Text = Convert.ToString((LISTITEM0).AsEnumerable().Sum(o => o.Montant));
                    TxtVersement.Text = Convert.ToString((LISTITEM0).AsEnumerable().Sum(o => o.Versement));
                    txtFournisseur.Text = Convert.ToString((LISTITEM0).AsEnumerable().Sum(o => o.Reste));
                }
                else
                {

                    if(listmembership.CodeMedecin== SELECTEDMEDECIN.Id)
                    {

                        var LISTITEM11 = PatientDataGrid.ItemsSource as IEnumerable<SVC.Visite>;
                        List<SVC.Visite> LISTITEM0 = LISTITEM11.ToList();

                        if (oper == 1)
                        {
                            LISTITEM0.Add(listmembership);
                        }
                        else
                        {
                            if (oper == 2)
                            {
                                var objectmodifed = LISTITEM0.Find(n => n.Id == listmembership.Id);
                                objectmodifed = listmembership;
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


                        PatientDataGrid.ItemsSource = LISTITEM0;
      
                        txtAchat.Text = Convert.ToString((LISTITEM0).AsEnumerable().Sum(o => o.Montant));

                        TxtVersement.Text = Convert.ToString((LISTITEM0.Where(n => n.CodeMedecin == SELECTEDMEDECIN.Id)).AsEnumerable().Sum(o => o.Versement));
                        txtFournisseur.Text = Convert.ToString((LISTITEM0.Where(n => n.CodeMedecin == SELECTEDMEDECIN.Id)).AsEnumerable().Sum(o => o.Reste));



                    }







                  

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
        void callbackrecufourn_Refresh(object source, CallbackEventInsertPatient e)
        {
            try
            { 
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                AddRefreshfourn(e.clientleav,e.operleav);
            }));
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
      public void AddRefreshfourn(SVC.Patient listmembership,int oper)
        {
            try
            {
                if (medecinsession == false)
                {
                    var LISTITEM11 = PatientCombo.ItemsSource as IEnumerable<SVC.Patient>;
                    List<SVC.Patient> LISTITEM0 = LISTITEM11.ToList();

                    if (oper == 1)
                    {
                        LISTITEM0.Add(listmembership);
                    }
                    else
                    {
                        if (oper == 2)
                        {
                            var objectmodifed = LISTITEM0.Find(n => n.Id == listmembership.Id);
                            objectmodifed = listmembership;
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


                    PatientCombo.ItemsSource = LISTITEM0;
                   // PatientCombo.ItemsSource = listmembership.OrderBy(x => x.Nom); ;
                }else
                {
                    if(listmembership.SuiviParCode==SELECTEDMEDECIN.Id)
                    {
                        var LISTITEM11 = PatientCombo.ItemsSource as IEnumerable<SVC.Patient>;
                        List<SVC.Patient> LISTITEM0 = LISTITEM11.ToList();

                        if (oper == 1)
                        {
                            LISTITEM0.Add(listmembership);
                        }
                        else
                        {
                            if (oper == 2)
                            {
                                var objectmodifed = LISTITEM0.Find(n => n.Id == listmembership.Id);
                                objectmodifed = listmembership;
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
                        PatientCombo.ItemsSource = LISTITEM0.OrderBy(x => x.Nom);
                    }

                  

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
        void callbackrecuMedecin_Refresh(object source, CallbackEventInsertMedecin e)
        {
            try
            { 
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                AddRefreshMedecin(e.clientleav);
            }));
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        public void AddRefreshMedecin(List<SVC.Medecin> listmembership)
        {
            try
            {
                if (medecinsession == false)
                {
                    MedecinCombo.ItemsSource = listmembership;
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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerReglementPatient(HandleProxy));
                return;
            }
            HandleProxy();
        }
        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            try
            { 
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerReglementPatient(HandleProxy));
                return;
            }
            HandleProxy();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
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
                        /*   proxy.Abort();
                           proxy = null;
                           this.Close();*/
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

        private void btnSolde_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MemberUser.CréationCaisse == true && PatientDataGrid.SelectedItem != null && PatientDataGrid.SelectedItems.Count == 1)
                {

                    SVC.Visite SelectMedecin = PatientDataGrid.SelectedItem as SVC.Visite;
                    if (SelectMedecin.Reste != 0)
                    {
                        AjouterTransaction bn = new AjouterTransaction(proxy, MemberUser, callback, null, 3, SelectMedecin, null);
                        bn.Show();
                    }
                    else
                    {
                        MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Facture déja soldé", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
                    }

                }
                else
                {
                    if (MemberUser.CréationCaisse == true && PatientDataGrid.SelectedItem != null && PatientDataGrid.SelectedItems.Count > 1)
                    {
                        List<SVC.Visite> selectedreste = PatientDataGrid.SelectedItems.OfType<SVC.Visite>().ToList();
                        if (DetectPatientInLIST(selectedreste))
                        {
                            List<SVC.Visite> Realselectedvisitewithreste = new List<SVC.Visite>();
                            foreach (SVC.Visite item in selectedreste)
                            {
                                if (item.Reste != 0)
                                {
                                    Realselectedvisitewithreste.Add(item);
                                }

                            }
                            if (Realselectedvisitewithreste.Count == 1)
                            {
                                AjouterTransaction bn = new AjouterTransaction(proxy, MemberUser, callback, null, 3, Realselectedvisitewithreste.First(), null);
                                bn.Show();
                            }
                            else
                            {
                                if (Realselectedvisitewithreste.Count > 1)
                                {
                                    AjouterTransaction bn = new AjouterTransaction(proxy, MemberUser, callback, null, 4, null, Realselectedvisitewithreste);
                                    bn.Show();
                                }else
                                {
                                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                                }
                            }
                        }
                        else
                        {
                            MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show("Vous devez selectionnez les visites d'un même patient", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        public bool DetectPatientInLIST(List<SVC.Visite> myList)
        {
                   if (myList.Any()) 
                  {
                      var value = myList.First().CodePatient;
                      return myList.All(item => item.CodePatient == value);
                  }
                   else
                  {
                      return true;
                  }
        }
        private void btnListeVersement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MemberUser.ImressionCaisse == true && PatientDataGrid.SelectedItem != null)
                {
                    SVC.Visite SelectMedecin = PatientDataGrid.SelectedItem as SVC.Visite;
                    if (SelectMedecin.CodePatient==0)
                    {
                        var patient = (proxy.GetAllPatient()).Find(n => n.cle == SelectMedecin.cle);

                        VersementPatient cl = new VersementPatient(proxy, MemberUser, callback, patient, SelectMedecin, true);
                        cl.Show();
                    }else
                    {
                        var patient = (proxy.GetAllPatient()).Find(n => n.Id == SelectMedecin.CodePatient);
                        VersementPatient cl = new VersementPatient(proxy, MemberUser, callback, patient, SelectMedecin, false);
                        cl.Show();
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

        private void btnImprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            if (interfaceimpression == 2 && MemberUser.ImpressionDossierPatient==true)
            {
                var test = PatientDataGrid.ItemsSource as IEnumerable<SVC.Visite>;
           
                ImpressionVisite cl = new ImpressionVisite(proxy, test.ToList(), 2,DateTime.Now, DateTime.Now);
                cl.Show();
            }
            else
            {
                    if (interfaceimpression == 1 && MemberUser.ImpressionDossierPatient == true/* && visitecredit.Count>0*/)
                    {
                        var itemsource = PatientDataGrid.ItemsSource as List<SVC.Visite>;
                        ImpressionVisite cl = new ImpressionVisite(proxy, itemsource, 1, DateTime.Now, DateTime.Now);
                        cl.Show();
                    }
                    else
                    {
                        if (interfaceimpression == 3 && MemberUser.ImpressionDossierPatient==true && DateVisiteDébut.SelectedDate!=null && DateVisiteFin.SelectedDate!=null && MemberUser.ImpressionDossierPatient == true)
                        {
                            var test = PatientDataGrid.ItemsSource as IEnumerable<SVC.Visite>;

                            ImpressionVisite cl = new ImpressionVisite(proxy, test.ToList(), 3, DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value);
                            cl.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Boolean Value=false;
     
                if (DateVisiteDébut.SelectedDate != null && DateVisiteFin.SelectedDate != null)
                {
                    if (chVisiteRegler.IsChecked == true)
                    {
                        Value = true;

                    }
                    else
                    {
                        if (chVisitenONRegler.IsChecked == true)
                        {
                            Value = false;
                        }else
                        {
                          //  Value = null;
                        }
                    }


                  
                            if (MedecinCombo.SelectedItem == null && PatientCombo.SelectedItem == null)
                            {

                                PatientDataGrid.ItemsSource = (proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).Where(n => n.Soldé == Value);

                        interfaceimpression = 3;
                    }
                            else
                            {
                                if (MedecinCombo.SelectedItem != null && PatientCombo.SelectedItem == null)
                                {
                                    SVC.Medecin ValueFourn = MedecinCombo.SelectedItem as SVC.Medecin;
                                    PatientDataGrid.ItemsSource = (proxy.GetAllVisiteByVisiteMedecin(ValueFourn.Id)).Where(n => n.Date >= DateVisiteDébut.SelectedDate.Value && n.Date <= DateVisiteFin.SelectedDate.Value &&  n.Soldé == Value);
                            //      MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show("patient combo vide " + Value.ToString(), Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                            interfaceimpression = 3;
                        }
                               else
                                {
                                    if (MedecinCombo.SelectedItem == null && PatientCombo.SelectedItem != null)
                                    {
                                SVC.Patient PatientSelected = PatientCombo.SelectedItem as SVC.Patient;
                                PatientDataGrid.ItemsSource = (proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).Where(n =>  (n.CodePatient == PatientSelected.Id || n.cle == PatientSelected.cle) && n.Soldé == Value);
                                //     MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show("medecin combo vide " + Value.ToString(), Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                                interfaceimpression = 2;
                                     }
                                       else
                                      {
                                        if (MedecinCombo.SelectedItem != null && PatientCombo.SelectedItem != null)
                                        {
                                    SVC.Patient PatientSelected = PatientCombo.SelectedItem as SVC.Patient;
                                    SVC.Medecin ValueMedecin = MedecinCombo.SelectedItem as SVC.Medecin;

                                        PatientDataGrid.ItemsSource = (proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).Where(n => (n.CodePatient == PatientSelected.Id || n.cle == PatientSelected.cle) && n.Soldé == Value && n.CodeMedecin==ValueMedecin.Id);
                                    //      MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show("deux combo not vide " + Value.ToString(), Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                                    interfaceimpression = 2;
                                } 
                            }
                                }
                            }



                         
                      
                    

                    }
                    var test = PatientDataGrid.ItemsSource as IEnumerable<SVC.Visite>;
                    txtAchat.Text = Convert.ToString((test).AsEnumerable().Sum(o => o.Montant));
                    TxtVersement.Text = Convert.ToString((test).AsEnumerable().Sum(o => o.Versement));
                    txtFournisseur.Text = Convert.ToString(((test).AsEnumerable().Sum(o => o.Reste)));

                
            }catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btndeFilter_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (medecinsession == false)
                {
                    DateVisiteDébut.SelectedDate = DateTime.Now.Date;
                    DateVisiteFin.SelectedDate = DateTime.Now.Date;
                    PatientDataGrid.ItemsSource = proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value);
                    MedecinCombo.ItemsSource = proxy.GetAllMedecin().OrderBy(x => x.Nom);
                    PatientCombo.ItemsSource = proxy.GetAllPatient().OrderBy(x => x.Nom);
                    chVisitenONRegler.IsChecked = true;

                    txtAchat.Text = Convert.ToString((proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).AsEnumerable().Sum(o => o.Montant));
                    TxtVersement.Text = Convert.ToString((proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).AsEnumerable().Sum(o => o.Versement));
                    txtFournisseur.Text = Convert.ToString(((proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).AsEnumerable().Sum(o => o.Reste)));
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void txtRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(PatientDataGrid.ItemsSource);
                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.Visite p = o as SVC.Visite;
                        if (t.Name == "txtId")
                            return (p.Motif == filter);
                        return (p.Motif.ToUpper().Contains(filter.ToUpper()));
                    };
                }
            }catch(Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void MedecinCombo_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            { 
            MedecinCombo.ItemsSource = proxy.GetAllMedecin().OrderBy(x => x.Nom);
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        private void txtPatientconsultation_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(PatientDataGrid.ItemsSource);

                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.Visite p = o as SVC.Visite;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.NomPatient.ToUpper().Contains(filter.ToUpper()));
                    };
                }

            }
            catch
            {

            }
        }

        /*  private void PatientCombo_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
          {
              try
              { 
             PatientCombo.ItemsSource = proxy.GetAllPatient().OrderBy(x => x.Nom);
              }
              catch (Exception ex)
              {
                  MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

              }

          }*/

        private void BTNCALCUL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 visitecredit = new List<SVC.Visite>();
               var listevisitecode = (from ta in proxy.GetAllVisiteAll()
                                      where ta.CodePatient!=0
                                  select ta.CodePatient).Distinct();
               
                foreach (int itemcode in listevisitecode)
                {
                    SVC.Visite newvisite = new SVC.Visite();
                    newvisite.Montant = 0;
                    newvisite.Versement = 0;
                     newvisite.Reste = 0;
                 //   newvisite.cle = "";
                    foreach (SVC.Visite itemvisite in proxy.GetAllVisiteAll())
                    {

                        if (itemcode==itemvisite.CodePatient && itemcode!=0)
                        {

                            newvisite.CodePatient = itemcode;
                           // if(itemcode==0)
                            /*{
                                newvisite.NomPatient = " Total Ancien solde";
                                newvisite.PrénomPatient = "Du cabinet";
                            }
                            else
                            {*/
                                newvisite.NomPatient = itemvisite.NomPatient;
                                newvisite.PrénomPatient = itemvisite.PrénomPatient;
                          //  }
                            newvisite.cle = itemvisite.cle;
                            newvisite.Montant = newvisite.Montant + itemvisite.Montant;
                            newvisite.Versement = newvisite.Versement + itemvisite.Versement;
                            newvisite.Reste = newvisite.Reste + itemvisite.Reste;

                        }
                    }
                    visitecredit.Add(newvisite);
                }
                List<SVC.Visite> listcle = proxy.GetAllVisiteAll().Where(n => n.CodePatient == 0 && n.cle != "").ToList();
                            
                foreach (SVC.Visite itemcle in listcle)
                {
                    SVC.Visite newvisite = new SVC.Visite();
                    newvisite.Montant = 0;
                    newvisite.Versement = 0;
                    newvisite.Reste = 0;


                     
                                   newvisite.CodePatient = itemcle.CodePatient;


                                  newvisite.NomPatient ="Ancien Solde "+ itemcle.NomPatient;
                                  newvisite.PrénomPatient = itemcle.PrénomPatient;

                                  newvisite.Montant = newvisite.Montant + itemcle.Montant;
                                  newvisite.Versement = newvisite.Versement + itemcle.Versement;
                                  newvisite.Reste = newvisite.Reste + itemcle.Reste;
                                  visitecredit.Add(newvisite);

                       
                
                 

                } 


                PatientDataGrid.ItemsSource = visitecredit;
                var test = PatientDataGrid.ItemsSource as IEnumerable<SVC.Visite>;
                txtAchat.Text = Convert.ToString((test).AsEnumerable().Sum(o => o.Montant));
                TxtVersement.Text = Convert.ToString((test).AsEnumerable().Sum(o => o.Versement));
                txtFournisseur.Text = Convert.ToString(((test).AsEnumerable().Sum(o => o.Reste)));

                btnSolde.IsEnabled = false;
                interfaceimpression = 1;
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        public bool DetectPatientInLISTvisite(List<SVC.Visite> myList)
        {
            if (myList.Any())
            {
                var value = myList.First().CodePatient;
                return myList.All(item => item.CodePatient == value);
            }
            else
            {
                return true;
            }
        }

        private void txtRecherchenOM_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(PatientDataGrid.ItemsSource);
                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.Visite p = o as SVC.Visite;
                        if (t.Name == "txtId")
                            return (p.NomPatient == filter);
                        return (p.NomPatient.ToUpper().Contains(filter.ToUpper()));
                    };
                }
            }catch(Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
