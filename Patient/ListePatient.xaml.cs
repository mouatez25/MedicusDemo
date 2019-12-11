using DevExpress.Xpf.Grid;
using Medicus.Administrateur;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Medicus.Patient
{
    /// <summary>
    /// Interaction logic for ListePatient.xaml
    /// </summary>
    public partial class ListePatient : UserControl
    {
        SVC.ServiceCliniqueClient proxy;
        ICallback callback;
        SVC.Membership memberuser;
        SVC.Medecin MedecinEnCours;
        SVC.Client localclient;
        private delegate void FaultedInvokerListePatient();
        public ListePatient(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership memberrecu, ICallback callbackrecu,SVC.Client clientrecu)
        {
            try
            {
                InitializeComponent();
                proxy = proxyrecu;

                memberuser = memberrecu;

                callback = callbackrecu;
                localclient = clientrecu;
                chargerpatient(proxyrecu, callbackrecu);

                loadmedecin(proxyrecu);

               
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        public void chargerpatient(SVC.ServiceCliniqueClient proxyrecu,ICallback callbackrecu)
        {
            Dispatcher.BeginInvoke(new Action(() => {
                PatientDataGrid.ItemsSource = proxyrecu.GetAllPatient();
                callbackrecu.InsertPatientCallbackEvent += new ICallback.CallbackEventHandler7(callbackrecu_Refresh);
                proxyrecu.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);

                proxyrecu.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);
            }), DispatcherPriority.SystemIdle);

            //   Thread.();
        }
        public void loadmedecin(SVC.ServiceCliniqueClient proxyrecu)
        {
            Dispatcher.BeginInvoke(new Action(() => {
                var disponible = (proxyrecu.GetAllMedecin()).Where(list1 => list1.UserName == memberuser.UserName).FirstOrDefault();
                if (disponible != null)
                {
                    MedecinEnCours = (proxyrecu.GetAllMedecin()).Where(list1 => list1.UserName == memberuser.UserName).FirstOrDefault();
                }

            }), DispatcherPriority.SystemIdle);

            //   Thread.();
        }
        void InnerDuplexChannel_Closed(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerListePatient(HandleProxy));
                return;
            }
            HandleProxy();
        }

        private void txtRef_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*try
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
                        SVC.Patient p = o as SVC.Patient;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.Ref.Value.ToString().ToUpper().StartsWith(filter.ToUpper()));
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }*/
            try
            {
                /* TextBox t = (TextBox)sender;
                   string filter = t.Text;
                   ICollectionView cv = CollectionViewSource.GetDefaultView(PatientDataGrid.ItemsSource);
                   if (filter == "")
                       cv.Filter = null;
                   else
                   {
                       cv.Filter = o =>
                       {
                           SVC.ClientV p = o as SVC.ClientV;
                           if (t.Name == "txtId")
                               return (p.Raison == filter);
                           return (p.Raison.ToUpper().StartsWith(filter.ToUpper()));
                       };
                   }*/

                /*  string filterValue = txtRecherche.Text;
                  if (!String.IsNullOrEmpty(filterValue))
                      PatientDataGrid.Columns[2].AutoFilterValue = filterValue;
                  else PatientDataGrid.FilterString = "([Id]  >= 0)";*/


                string filterValue = txtRef.Text;
                if (!String.IsNullOrEmpty(filterValue))
                {
                    PatientDataGrid.Columns[1].AutoFilterCondition = AutoFilterCondition.Contains;
                    PatientDataGrid.Columns[1].AutoFilterValue = filterValue;
                }

                else PatientDataGrid.FilterString = "([Id]  >= 0)";
                PatientDataGrid.SelectedItem = null;

            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        private void txtDossier_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*try
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
                        SVC.Patient p = o as SVC.Patient;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.Dossier.Value.ToString().ToUpper().StartsWith(filter.ToUpper()));
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }*/
            try
            {
                /* TextBox t = (TextBox)sender;
                   string filter = t.Text;
                   ICollectionView cv = CollectionViewSource.GetDefaultView(PatientDataGrid.ItemsSource);
                   if (filter == "")
                       cv.Filter = null;
                   else
                   {
                       cv.Filter = o =>
                       {
                           SVC.ClientV p = o as SVC.ClientV;
                           if (t.Name == "txtId")
                               return (p.Raison == filter);
                           return (p.Raison.ToUpper().StartsWith(filter.ToUpper()));
                       };
                   }*/

                /*  string filterValue = txtRecherche.Text;
                  if (!String.IsNullOrEmpty(filterValue))
                      PatientDataGrid.Columns[2].AutoFilterValue = filterValue;
                  else PatientDataGrid.FilterString = "([Id]  >= 0)";*/


                string filterValue = txtDossier.Text;
                if (!String.IsNullOrEmpty(filterValue))
                {
                    PatientDataGrid.Columns[2].AutoFilterCondition = AutoFilterCondition.Contains;
                    PatientDataGrid.Columns[2].AutoFilterValue = filterValue;
                }

                else PatientDataGrid.FilterString = "([Id]  >= 0)";
                PatientDataGrid.SelectedItem = null;

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
                        proxy = null;

                        break;
                    case CommunicationState.Closing:
                        break;
                    case CommunicationState.Created:
                        break;
                    case CommunicationState.Faulted:
                        proxy.Abort();
                        proxy = null;
                      /*  var wndlistsession = Window.GetWindow(this);

                        Grid test = (Grid)wndlistsession.FindName("gridAuthentification");
                        test.Visibility = Visibility.Visible;
                        Button confirmer = (Button)wndlistsession.FindName("Confirmer");
                        confirmer.IsEnabled = false;
                        Grid tests = (Grid)wndlistsession.FindName("gridhome");
                        tests.Visibility = Visibility.Collapsed;*/

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
        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerListePatient(HandleProxy));
                return;
            }
            HandleProxy();
        }
        void callbackrecu_Refresh(object source, CallbackEventInsertPatient e)
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
        public void AddRefresh(SVC.Patient listmembership,int oper)
        {
            try { 

            var LISTITEM1 = PatientDataGrid.ItemsSource as IEnumerable<SVC.Patient>;
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
                  //  objectmodifed = listmembership;

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

            PatientDataGrid.ItemsSource = LISTITEM;
          }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (memberuser.CréationPatient == true)
            {
                NewPatient CLMedecin = new NewPatient(proxy, memberuser, null);
                CLMedecin.Show();

            }
            else
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);


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
                if (memberuser.SuppressionPatient == true && PatientDataGrid.SelectedItem != null)
                {
                    SVC.Patient SelectMedecin = PatientDataGrid.SelectedItem as SVC.Patient;

                    int nbvisite = proxy.GetAllVisiteByVisite(SelectMedecin.Id).Count();
                    if (nbvisite==0)
                    {
                        using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                        {
                            proxy.DeletePatient(SelectMedecin);
                            ts.Complete();
                            MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        proxy.AjouterPatientRefresh();
                    }else
                    {
                        MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (memberuser.ModificationPatient == true && PatientDataGrid.SelectedItem != null)
            {
                SVC.Patient SelectMedecin = PatientDataGrid.SelectedItem as SVC.Patient;
                NewPatient CLMedecin = new NewPatient(proxy, memberuser, SelectMedecin);
                CLMedecin.Show();
            }else
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void btnImprimer_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (memberuser.ImpressionPatient == true)
            {
                if (PatientDataGrid.SelectedItem != null)
                {
                    SVC.Patient SelectMedecin = PatientDataGrid.SelectedItem as SVC.Patient;



                    FichePatient clsho = new FichePatient(proxy, SelectMedecin);
                    clsho.Show();
                }
                else
                {
                    if (txtRecherche.Text != "")
                    {
                        List<SVC.Patient> test = PatientDataGrid.ItemsSource as List<SVC.Patient>;
                        var t = (from e1 in test

                                 where e1.Nom.ToUpper().StartsWith(txtRecherche.Text.ToUpper())

                                 select e1);



                        ReportListePatient clsho = new ReportListePatient(proxy, t.ToList());
                        clsho.Show();
                    }
                    else
                    {
                        List<SVC.Patient> test = PatientDataGrid.ItemsSource as List<SVC.Patient>;


                        ReportListePatient clsho = new ReportListePatient(proxy, test.ToList());
                        clsho.Show();

                    }
                }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }


        private void txtRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*    try { 
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(PatientDataGrid.ItemsSource);
                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.Patient p = o as SVC.Patient;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.Nom.ToUpper().StartsWith(filter.ToUpper()));
                    };
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }*/
            try
            {
                /* TextBox t = (TextBox)sender;
                   string filter = t.Text;
                   ICollectionView cv = CollectionViewSource.GetDefaultView(PatientDataGrid.ItemsSource);
                   if (filter == "")
                       cv.Filter = null;
                   else
                   {
                       cv.Filter = o =>
                       {
                           SVC.ClientV p = o as SVC.ClientV;
                           if (t.Name == "txtId")
                               return (p.Raison == filter);
                           return (p.Raison.ToUpper().StartsWith(filter.ToUpper()));
                       };
                   }*/

                /*  string filterValue = txtRecherche.Text;
                  if (!String.IsNullOrEmpty(filterValue))
                      PatientDataGrid.Columns[2].AutoFilterValue = filterValue;
                  else PatientDataGrid.FilterString = "([Id]  >= 0)";*/


                string filterValue = txtRecherche.Text;
                if (!String.IsNullOrEmpty(filterValue))
                {
                    PatientDataGrid.Columns[3].AutoFilterCondition = AutoFilterCondition.Contains;
                    PatientDataGrid.Columns[3].AutoFilterValue = filterValue;
                }

                else PatientDataGrid.FilterString = "([Id]  >= 0)";
                PatientDataGrid.SelectedItem = null;

            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void ClientsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try { 
            if (memberuser.ModificationPatient == true && PatientDataGrid.SelectedItem != null)
            {
                SVC.Patient SelectMedecin = PatientDataGrid.SelectedItem as SVC.Patient;
                NewPatient CLMedecin = new NewPatient(proxy, memberuser, SelectMedecin);
                CLMedecin.Show();
            }else
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void txtRechercheMedecin_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*try { 
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(PatientDataGrid.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    SVC.Patient p = o as SVC.Patient;
                    if (t.Name == "txtId")
                        return (p.Id == Convert.ToInt32(filter));
                    return (p.SuiviParNom.ToUpper().StartsWith(filter.ToUpper()));
                };
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }*/
            try
            {
                /* TextBox t = (TextBox)sender;
                   string filter = t.Text;
                   ICollectionView cv = CollectionViewSource.GetDefaultView(PatientDataGrid.ItemsSource);
                   if (filter == "")
                       cv.Filter = null;
                   else
                   {
                       cv.Filter = o =>
                       {
                           SVC.ClientV p = o as SVC.ClientV;
                           if (t.Name == "txtId")
                               return (p.Raison == filter);
                           return (p.Raison.ToUpper().StartsWith(filter.ToUpper()));
                       };
                   }*/

                /*  string filterValue = txtRecherche.Text;
                  if (!String.IsNullOrEmpty(filterValue))
                      PatientDataGrid.Columns[2].AutoFilterValue = filterValue;
                  else PatientDataGrid.FilterString = "([Id]  >= 0)";*/


                string filterValue = txtRechercheMedecin.Text;
                if (!String.IsNullOrEmpty(filterValue))
                {
                    PatientDataGrid.Columns[16].AutoFilterCondition = AutoFilterCondition.Contains;
                    PatientDataGrid.Columns[16].AutoFilterValue = filterValue;
                }

                else PatientDataGrid.FilterString = "([Id]  >= 0)";
                PatientDataGrid.SelectedItem = null;

            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

    
        

        private void bntcreerCas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDossier_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (PatientDataGrid.SelectedItem != null && memberuser.ModuleDossierPatient==true)
            {
                SVC.Patient SelectMedecin = PatientDataGrid.SelectedItem as SVC.Patient;
                if ((MedecinEnCours!=null && SelectMedecin.SuiviParCode==MedecinEnCours.Id)|| memberuser.AccèsToutLesDossierPatient==true)
                {
                    DossierPatient dd = new DossierPatient(proxy, SelectMedecin, callback, memberuser, "Sans Rendez Vous", MedecinEnCours,localclient);
                    dd.Show();
                }else
                {
                    if (memberuser.AccèsToutLesDossierPatient==true)
                    {
                            DossierPatient dd = new DossierPatient(proxy, SelectMedecin, callback, memberuser, "Sans Rendez Vous", null,localclient);
                        dd.Show();
                    }else
                    {
                        MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }


                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                    SVC.Patient SelectMedecin = PatientDataGrid.SelectedItem as SVC.Patient;
                    NewPatient CLMedecin = new NewPatient(proxy, memberuser, SelectMedecin);
                    CLMedecin.Show();
                
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void supprimer(object sender, RoutedEventArgs e)
        {
            try
            {
                if ( PatientDataGrid.SelectedItem != null)
                {
                    SVC.Patient SelectMedecin = PatientDataGrid.SelectedItem as SVC.Patient;

                    int nbvisite = proxy.GetAllVisiteByVisite(SelectMedecin.Id).Count();
                    if (nbvisite == 0)
                    {
                        using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                        {
                            proxy.DeletePatient(SelectMedecin);
                            ts.Complete();
                            MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        proxy.AjouterPatientRefresh();
                    }
                    else
                    {
                        MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void FolderClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PatientDataGrid.SelectedItem != null)
                {
                    SVC.Patient SelectMedecin = PatientDataGrid.SelectedItem as SVC.Patient;
                    if ((MedecinEnCours != null && SelectMedecin.SuiviParCode == MedecinEnCours.Id) || memberuser.AccèsToutLesDossierPatient == true)
                    {
                        DossierPatient dd = new DossierPatient(proxy, SelectMedecin, callback, memberuser, "Sans Rendez Vous", MedecinEnCours, localclient);
                        dd.Show();
                    }
                    else
                    {
                        if (memberuser.AccèsToutLesDossierPatient == true)
                        {
                            DossierPatient dd = new DossierPatient(proxy, SelectMedecin, callback, memberuser, "Sans Rendez Vous", null, localclient);
                            dd.Show();
                        }
                        else
                        {
                            MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                        }
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
