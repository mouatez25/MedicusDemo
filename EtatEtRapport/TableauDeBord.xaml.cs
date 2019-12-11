using DevExpress.Xpf.Core;
using Medicus.Administrateur;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// Interaction logic for TableauDeBord.xaml
    /// </summary>
    public partial class TableauDeBord : DXWindow
    {
        SVC.Medecin medecinSelected;
        SVC.ServiceCliniqueClient proxy;
        SVC.Membership memberuser;
        ICallback callback;
        private delegate void FaultedInvokerTableaudebord();
        bool medecinsession = false;
        List<TableauDeBordClass> listtableaudebord;
        string RdvPresent, RdvNoPresent, SalleAttenteQuit, SalleAttenteTjr, MedecinSalleTjr, MedecinSalleNON, VisteNonRéglé, VisteRéglé = "";

        public TableauDeBord(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership memberrecu, ICallback callbackrecu)
        {
            try
            {
                InitializeComponent();

                proxy = proxyrecu;
                memberuser = memberrecu;
                callback = callbackrecu;
                var disponible = (proxy.GetAllMedecin()).Where(list1 => list1.UserName == memberuser.UserName).FirstOrDefault();
                if (disponible == null)
                {
                    medecinsession = false;
                    MedecinCombo.ItemsSource = proxy.GetAllMedecin().OrderBy(n => n.Nom);
                    MedecinComboDepeiement.ItemsSource = proxy.GetAllMedecin().OrderBy(n => n.Nom);
                }
                else
                {
                    medecinsession = true;
                    medecinSelected = disponible;
                    MedecinCombo.IsEnabled = false;
                    List<SVC.Medecin> testmedecin = proxy.GetAllMedecin().OrderBy(n => n.Nom).ToList();
                    MedecinCombo.ItemsSource = testmedecin;
                    List<SVC.Medecin> tte = testmedecin.Where(n => n.UserName == memberuser.UserName).ToList();
                    MedecinCombo.SelectedItem = tte.First();

                 

                    MedecinComboDepeiement.IsEnabled = false;
                    MedecinComboDepeiement.ItemsSource = testmedecin;
                    MedecinComboDepeiement.SelectedItem = tte.First();
                


                }
                var converter = new System.Windows.Media.BrushConverter();

                VisteNonRéglé = proxy.GetAllParamétre().VisteNonRéglé;
                VisteRéglé = proxy.GetAllParamétre().VisteRéglé;
                RdvPresent = proxy.GetAllParamétre().RdvPresent;
                RdvNoPresent = proxy.GetAllParamétre().RdvNoPresent;
                SalleAttenteQuit = proxy.GetAllParamétre().SalleAttenteQuit;
                SalleAttenteTjr = proxy.GetAllParamétre().SalleAttenteTjr;
                MedecinSalleTjr = proxy.GetAllParamétre().MedecinSalleTjr;
                MedecinSalleNON = proxy.GetAllParamétre().MedecinSalleNON;
                btnTjrLa.Background = (Brush)converter.ConvertFromString(SalleAttenteTjr);
                btnMedecin.Background = (Brush)converter.ConvertFromString(MedecinSalleTjr);
                btnPatientMedecin.Background = (Brush)converter.ConvertFromString(MedecinSalleNON);
                btnPayer.Background = (Brush)converter.ConvertFromString(VisteRéglé);
                btnNoPayer.Background = (Brush)converter.ConvertFromString(VisteNonRéglé);
                btnPresent.Background = (Brush)converter.ConvertFromString(RdvPresent);
                btnNoPresent.Background = (Brush)converter.ConvertFromString(RdvNoPresent);
                DateVisiteDébut.SelectedDate = DateTime.Now;
                DateVisiteFin.SelectedDate = DateTime.Now;
                proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);

                proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);

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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerTableaudebord(HandleProxy));
                return;
            }
            HandleProxy();
        }

        private void txtMedecinconsultation_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(ConsultationDatagrid.ItemsSource);
               
                    if (filter == "")
                        cv.Filter = null;
                    else
                    {
                        cv.Filter = o =>
                        {
                            SVC.SalleDattente p = o as SVC.SalleDattente;
                            if (t.Name == "txtId")
                                return (p.Id == Convert.ToInt32(filter));
                            return (p.NomMedecin.ToUpper().Contains(filter.ToUpper()));
                        };
                    }
               
            }
            catch
            {

            }
        }

        private void txtPatientconsultation_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(ConsultationDatagrid.ItemsSource);
              
                    if (filter == "")
                        cv.Filter = null;
                    else
                    {
                        cv.Filter = o =>
                        {
                            SVC.SalleDattente p = o as SVC.SalleDattente;
                            if (t.Name == "txtId")
                                return (p.Id == Convert.ToInt32(filter));
                            return (p.Nom.ToUpper().Contains(filter.ToUpper()));
                        };
                    }
                
            }
            catch
            {

            }
        }

        private void txtPatientReglement_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(ReglementDatagrid.ItemsSource);

                if (filter == "")
                {
                    cv.Filter = null;
                    txttotalreglement.Text = Convert.ToString(cv.OfType<SVC.Depeiment>().AsEnumerable().Sum(n => n.montant));
                }
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.Depeiment p = o as SVC.Depeiment;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.NomPatient.ToUpper().Contains(filter.ToUpper()));

                    };
                    txttotalreglement.Text = Convert.ToString(cv.OfType<SVC.Depeiment>().AsEnumerable().Sum(n => n.montant));

                }

            }
            catch
            {

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

        private void txtPatientvisite_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
               
                    TextBox t = (TextBox)sender;
                    string filter = t.Text;
                    ICollectionView cv = CollectionViewSource.GetDefaultView(VisiteDatagrid.ItemsSource);

                if (filter == "")
                {
                    cv.Filter = null;
                    txtLabelTotalAregler.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Montant));
                    txtLabelTotalversement.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Versement));
                    txtLabelTotalReste.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Reste));
                }
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.Visite p = o as SVC.Visite;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.NomPatient.ToUpper().Contains(filter.ToUpper()));
                    };
                    txtLabelTotalAregler.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Montant));
                    txtLabelTotalversement.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Versement));
                    txtLabelTotalReste.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Reste));
                }
               
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void txtMedecinvisite_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
               
                    TextBox t = (TextBox)sender;
                    string filter = t.Text;
                    ICollectionView cv = CollectionViewSource.GetDefaultView(VisiteDatagrid.ItemsSource);

                if (filter == "")
                {
                    cv.Filter = null;
                    txtLabelTotalAregler.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Montant));
                    txtLabelTotalversement.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Versement));
                    txtLabelTotalReste.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Reste));
                }
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.Visite p = o as SVC.Visite;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.VisiteParNom.ToUpper().Contains(filter.ToUpper()));
                    };
                    txtLabelTotalAregler.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Montant));
                    txtLabelTotalversement.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Versement));
                    txtLabelTotalReste.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Reste));
                }
             
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

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

        private void txtPatientRendezVous_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(RendezVousDatagrid.ItemsSource);

                if (filter == "")
                {
                    cv.Filter = null;
                    NBRENDEZVOUS.Text = Convert.ToString(cv.OfType<SVC.RendezVou>().AsEnumerable().Count());

                }
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.RendezVou p = o as SVC.RendezVou;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.Nom.ToUpper().Contains(filter.ToUpper()));
                    };
                    NBRENDEZVOUS.Text = Convert.ToString(cv.OfType<SVC.RendezVou>().AsEnumerable().Count());

                }

            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void txtMedecinRendezVous_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(RendezVousDatagrid.ItemsSource);

                if (filter == "")
                {
                    cv.Filter = null;
                    NBRENDEZVOUS.Text = Convert.ToString(cv.OfType<SVC.RendezVou>().AsEnumerable().Count());

                }
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.RendezVou p = o as SVC.RendezVou;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.MedecinNom.ToUpper().Contains(filter.ToUpper()));
                    };
                    NBRENDEZVOUS.Text = Convert.ToString(cv.OfType<SVC.RendezVou>().AsEnumerable().Count());

                }

            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void txtMotifRendezVous_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(RendezVousDatagrid.ItemsSource);

                if (filter == "")
                {
                    cv.Filter = null;
                    NBRENDEZVOUS.Text = Convert.ToString(cv.OfType<SVC.RendezVou>().AsEnumerable().Count());

                }
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.RendezVou p = o as SVC.RendezVou;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.Motif.ToUpper().Contains(filter.ToUpper()));
                    };
                    NBRENDEZVOUS.Text = Convert.ToString(cv.OfType<SVC.RendezVou>().AsEnumerable().Count());

                }

            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void txtMotifvisite_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(VisiteDatagrid.ItemsSource);

                if (filter == "")
                {
                    cv.Filter = null;
                    txtLabelTotalAregler.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Montant));
                    txtLabelTotalversement.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Versement));
                    txtLabelTotalReste.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Reste));
                }
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.Visite p = o as SVC.Visite;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.Motif.ToUpper().Contains(filter.ToUpper()));
                    };
                    txtLabelTotalAregler.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Montant));
                    txtLabelTotalversement.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Versement));
                    txtLabelTotalReste.Content = Convert.ToString(cv.OfType<SVC.Visite>().AsEnumerable().Sum(n => n.Reste));
                }

            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void txtMotifconsultation_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(ConsultationDatagrid.ItemsSource);

                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.SalleDattente p = o as SVC.SalleDattente;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return (p.Motif.ToUpper().Contains(filter.ToUpper()));
                    };

                }

            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void txtProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

               
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void MedecinComboDepeiement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (medecinsession != true)
                {
                    SVC.Medecin selectedmedecin;
                    if (MedecinComboDepeiement.SelectedItem != null)
                    {
                        selectedmedecin = MedecinComboDepeiement.SelectedItem as SVC.Medecin;
                    }
                    else
                    {
                        selectedmedecin = new SVC.Medecin
                        {
                            Id = 0,
                        };

                    }



                    /*TextBox t = (TextBox)sender;*/

                    int filter = selectedmedecin.Id;
                    ICollectionView cv = CollectionViewSource.GetDefaultView(ReglementDatagrid.ItemsSource);
                    if (filter == 0)
                    {
                        cv.Filter = null;
                        txttotalreglement.Text = Convert.ToString(cv.OfType<SVC.Depeiment>().AsEnumerable().Sum(n => n.montant));
                    }
                    else
                    {
                        cv.Filter = o =>
                        {
                            SVC.Depeiment p = o as SVC.Depeiment;
                            if (selectedmedecin.Id > 0)
                                return (p.CodeMedecin == Convert.ToInt32(filter));
                            //   return (p.CodeMedecin.Equals(filter));
                            return (Convert.ToString(p.CodeMedecin).ToUpper().Equals(filter));

                        };
                        txttotalreglement.Text = Convert.ToString(cv.OfType<SVC.Depeiment>().AsEnumerable().Sum(n => n.montant));


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void MedecinComboDepeiement_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (medecinsession == false)
                {
                    MedecinComboDepeiement.ItemsSource = proxy.GetAllMedecin().OrderBy(n => n.Nom);

                }

            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

       
        private void txtOperStock_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                

            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void chMontantVisite_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

                CheckBox t = (CheckBox)sender;
                decimal filter = 0;
                ICollectionView cv = CollectionViewSource.GetDefaultView(VisiteDatagrid.ItemsSource);

                if (chMontantVisite.IsChecked == true)

                {
                    cv.Filter = o =>
                    {
                        SVC.Visite p = o as SVC.Visite;
                        if (t.Name == "txtId")
                            return (p.Id == Convert.ToInt32(filter));
                        return !(p.MontantActe.Equals(p.Montant));
                    };



                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void chMontantVisite_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {

                CheckBox t = (CheckBox)sender;
                decimal filter = 0;
                ICollectionView cv = CollectionViewSource.GetDefaultView(VisiteDatagrid.ItemsSource);

                if (chMontantVisite.IsChecked == false)
                {

                    cv.Filter = null;


                }
                }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerTableaudebord(HandleProxy));
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

        private void btnImprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            if(MedecinCombo.SelectedItem!=null && RecapGrid.Items.Count!=0)
            {
                SVC.Medecin selectedmededcin = MedecinCombo.SelectedItem as SVC.Medecin;
               //var selectedtableau = RecapGrid.SelectedItems as IEnumerable<TableauDeBordClass>;
                var selectedtableau = RecapGrid.ItemsSource as IEnumerable<TableauDeBordClass>; 

                List<SVC.Medecin> listmededcin = new List<SVC.Medecin>();
                listmededcin.Add(selectedmededcin);
                ImpressionTableauDeBord cl = new ImpressionTableauDeBord(proxy,listmededcin,selectedtableau.ToList());
                cl.Show();


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
                if (DateVisiteDébut.SelectedDate != null && DateVisiteFin.SelectedDate != null)
                {

                    if (medecinsession == true)
                    {
                        SVC.Medecin selectedmededcin = MedecinCombo.SelectedItem as SVC.Medecin;
                        List<SVC.SalleDattente> SelectedSalleAttente = (proxy.GetAllSalleDattente(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).Where(n => n.CodeMedecin == selectedmededcin.Id).ToList();
                        List<SVC.Visite> SelectedVisite = (proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).Where(n =>  n.CodeMedecin == selectedmededcin.Id).ToList();
                        List<SVC.Depeiment> SelectedDepeiment = (proxy.GetAllDepeiment()).Where(n => n.date >= DateVisiteDébut.SelectedDate && n.date <= DateVisiteFin.SelectedDate && n.CodeMedecin == selectedmededcin.Id).ToList();
                        List<SVC.RendezVou> Selectedrendezvous = (proxy.GetAllRendezVous(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).Where(n => n.CodeMedecin==selectedmededcin.Id).ToList();
                        List<SVC.DepeiementMultiple> SelectedDepeimentMultiple = (proxy.GetAllDepeiementMultiple()).Where(n => n.date >= DateVisiteDébut.SelectedDate && n.date <= DateVisiteFin.SelectedDate && n.CodeMedecin == selectedmededcin.Id).ToList();

                        if(SelectedDepeimentMultiple.Count>0)
                        {

                            foreach(SVC.DepeiementMultiple item in SelectedDepeimentMultiple)
                            {
                                SVC.Depeiment depeiteim = new SVC.Depeiment
                                {
                                    CodeMedecin=item.CodeMedecin,
                                    NomMedecin=item.NomMedecin,
                                    PrénomMedecin=item.PrénomMedecin,
                                    CodePatient=item.CodePatient,
                                    NomPatient=item.NomPatient,
                                    PrénomPatient=item.PrénomPatient,
                                    banque=item.banque,
                                    amontant=item.amontant,
                                    CleMultiple=item.cleMultiple,
                                    cle=item.cleVisite,
                                    date=item.date,
                                    cp=item.cp,
                                    dates=item.dates,
                                    enreg=item.enreg,
                                    montant=item.montant,
                                    Multiple=true,
                                    nfact=item.nfact,
                                    oper=item.oper,
                                    paiem=item.paiem,
                                };
                                SelectedDepeiment.Add(depeiteim);
                            }
                        }
                      

                        ConsultationDatagrid.ItemsSource = SelectedSalleAttente;
                        VisiteDatagrid.ItemsSource = SelectedVisite;
                        txtLabelTotalAregler.Content= Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Montant));
                        txtLabelTotalversement.Content = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Versement));
                        txtLabelTotalReste.Content = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Reste));


                        ReglementDatagrid.ItemsSource = SelectedDepeiment;
                        txttotalreglement.Text = Convert.ToString(SelectedDepeiment.AsEnumerable().Sum(n => n.montant));
                      
                        RendezVousDatagrid.ItemsSource = Selectedrendezvous;
                        NBRENDEZVOUS.Text = Convert.ToString(Selectedrendezvous.AsEnumerable().Count());




                        listtableaudebord = new List<TableauDeBordClass>();

                        /*************************Nombre De Consultations Patients***************************/
                        TableauDeBordClass Nb  = new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Nombre De Consultations Patients",
                            Valeur =Convert.ToString(SelectedSalleAttente.Where(n=>n.FinDeConsultation==true).AsEnumerable().Count()),
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };

                        listtableaudebord.Add(Nb);
                        /**********************************Total montant des visites faites*****************************************************/
                        TableauDeBordClass Nb1  = new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Montant des consultations faites ",
                            Valeur = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n=>n.Montant)),
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };

                        listtableaudebord.Add(Nb1);

                        TableauDeBordClass Nb4 = new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Total des versements reçu sur les consulations de cette Période ",
                            Valeur = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Versement)),
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };
                        listtableaudebord.Add(Nb4);
                        TableauDeBordClass Nb6 = new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Total des restes sur les consultations de cette Période",
                            Valeur = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Reste)),
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };
                        listtableaudebord.Add(Nb6);
                        /**********************************Total montant des visites faites*****************************************************/
                        TableauDeBordClass Nb2 = new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Nombre total des minutes de consultation ",
                            Valeur = Convert.ToString(SelectedSalleAttente.Where(n=> n.FinDeConsultation == true).AsEnumerable().Sum(n => n.TempsQuitMedecinSalle.Value.TotalMinutes - n.TempsChezMedecinSalle.Value.TotalMinutes)),
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };

                        listtableaudebord.Add(Nb2);

                        TableauDeBordClass Nb3= new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Moyenne Minutes par consultation ",
                            Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.FinDeConsultation == true).AsEnumerable().Sum(n => n.TempsQuitMedecinSalle.Value.TotalMinutes - n.TempsChezMedecinSalle.Value.TotalMinutes)/ SelectedSalleAttente.AsEnumerable().Count()),
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };
                        listtableaudebord.Add(Nb3);


                        TableauDeBordClass Nb5 = new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Total des versements reçu dans cette période ",
                            Valeur = Convert.ToString(SelectedDepeiment.AsEnumerable().Sum(n => n.montant)),
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };
                        listtableaudebord.Add(Nb5);
                        /*****Stock*****Selectedam*/
                        TableauDeBordClass Nb7 = new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Total quantité des produits consommés dans cette période ",
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };
                        listtableaudebord.Add(Nb7);
                        TableauDeBordClass Nb8 = new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Total valeur des produits consommés dans cette période ",
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };
                        listtableaudebord.Add(Nb8);
                        /******************Selectedrendezvous************************/
                        TableauDeBordClass Nb9 = new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Total des rendez vous pris dans cette période ",
                            Valeur = Convert.ToString(Selectedrendezvous.AsEnumerable().Count()),
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };
                        listtableaudebord.Add(Nb9);

                        TableauDeBordClass Nb10= new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Total des consultations avec rendez vous dans cette période ",
                            Valeur = Convert.ToString(SelectedSalleAttente.Where(n=>n.NuméroRendezVous!="Sans Rendez Vous" && n.FinDeConsultation==true).AsEnumerable().Count()),
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };
                        listtableaudebord.Add(Nb10);

                        TableauDeBordClass Nb11 = new TableauDeBordClass
                        {
                            Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                            Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                            Rubrique = "Total des consultations sans rendez vous dans cette période ",
                            Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.NuméroRendezVous == "Sans Rendez Vous" && n.FinDeConsultation == true).AsEnumerable().Count()),
                            Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                        };
                        listtableaudebord.Add(Nb11);

                        RecapGrid.ItemsSource = listtableaudebord;



                    }
                    else
                    {
                        if (medecinsession == false && MedecinCombo.SelectedItem!=null)
                        {
                            SVC.Medecin selectedmededcin = MedecinCombo.SelectedItem as SVC.Medecin;
                            List<SVC.SalleDattente> SelectedSalleAttente = (proxy.GetAllSalleDattente(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).Where(n => n.CodeMedecin == selectedmededcin.Id).ToList();
                            List<SVC.Visite> SelectedVisite = (proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).Where(n => n.CodeMedecin == selectedmededcin.Id).ToList();
                            List<SVC.Depeiment> SelectedDepeiment = (proxy.GetAllDepeiment()).Where(n => n.date >= DateVisiteDébut.SelectedDate && n.date <= DateVisiteFin.SelectedDate && n.CodeMedecin == selectedmededcin.Id).ToList();
                            List<SVC.RendezVou> Selectedrendezvous = (proxy.GetAllRendezVous(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).Where(n =>  n.CodeMedecin == selectedmededcin.Id).ToList();

                            List<SVC.DepeiementMultiple> SelectedDepeimentMultiple = (proxy.GetAllDepeiementMultiple()).Where(n => n.date >= DateVisiteDébut.SelectedDate && n.date <= DateVisiteFin.SelectedDate && n.CodeMedecin == selectedmededcin.Id).ToList();

                            if (SelectedDepeimentMultiple.Count > 0)
                            {

                                foreach (SVC.DepeiementMultiple item in SelectedDepeimentMultiple)
                                {
                                    SVC.Depeiment depeiteim = new SVC.Depeiment
                                    {
                                        CodeMedecin = item.CodeMedecin,
                                        NomMedecin = item.NomMedecin,
                                        PrénomMedecin = item.PrénomMedecin,
                                        CodePatient = item.CodePatient,
                                        NomPatient = item.NomPatient,
                                        PrénomPatient = item.PrénomPatient,
                                        banque = item.banque,
                                        amontant = item.amontant,
                                        CleMultiple = item.cleMultiple,
                                        cle = item.cleVisite,
                                        date = item.date,
                                        cp = item.cp,
                                        dates = item.dates,
                                        enreg = item.enreg,
                                        montant = item.montant,
                                        Multiple = true,
                                        nfact = item.nfact,
                                        oper = item.oper,
                                        paiem = item.paiem,
                                    };
                                    SelectedDepeiment.Add(depeiteim);
                                }
                            }



                            ConsultationDatagrid.ItemsSource = SelectedSalleAttente;
                            VisiteDatagrid.ItemsSource = SelectedVisite;
                            ReglementDatagrid.ItemsSource = SelectedDepeiment;
                            RendezVousDatagrid.ItemsSource = Selectedrendezvous;





                            listtableaudebord = new List<TableauDeBordClass>();

                            /*************************Nombre De Consultations Patients***************************/
                            TableauDeBordClass Nb = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Nombre De Consultations Patients",
                                Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.FinDeConsultation == true).AsEnumerable().Count()),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };

                            listtableaudebord.Add(Nb);
                            /**********************************Total montant des visites faites*****************************************************/
                            TableauDeBordClass Nb1 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Montant des consulations faites ",
                                Valeur = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Montant)),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };

                            listtableaudebord.Add(Nb1);

                            TableauDeBordClass Nb4 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des versements reçu sur les consultations de cette Période ",
                                Valeur = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Versement)),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb4);
                            TableauDeBordClass Nb6 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des restes sur les consultations de cette Période",
                                Valeur = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Reste)),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb6);
                            /**********************************Total montant des visites faites*****************************************************/
                            TableauDeBordClass Nb2 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Nombre total des minutes de consultation ",
                                Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.FinDeConsultation == true).AsEnumerable().Sum(n => n.TempsQuitMedecinSalle.Value.TotalMinutes - n.TempsChezMedecinSalle.Value.TotalMinutes)),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };

                            listtableaudebord.Add(Nb2);

                            TableauDeBordClass Nb3 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Moyenne Minutes par consultation ",
                                Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.FinDeConsultation == true).AsEnumerable().Sum(n => n.TempsQuitMedecinSalle.Value.TotalMinutes - n.TempsChezMedecinSalle.Value.TotalMinutes) / SelectedSalleAttente.AsEnumerable().Count()),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb3);


                            TableauDeBordClass Nb5 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des versements reçu dans cette période ",
                                Valeur = Convert.ToString(SelectedDepeiment.AsEnumerable().Sum(n => n.montant)),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb5);
                            /*****Stock*****Selectedam*/
                            TableauDeBordClass Nb7 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total quantité des produits consommés dans cette période ",
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb7);
                            TableauDeBordClass Nb8 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total valeur des produits consommés dans cette période ",
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb8);
                            /******************Selectedrendezvous************************/
                            TableauDeBordClass Nb9 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des rendez vous pris dans cette période ",
                                Valeur = Convert.ToString(Selectedrendezvous.AsEnumerable().Count()),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb9);

                            TableauDeBordClass Nb10 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des consultations avec rendez vous dans cette période ",
                                Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.NuméroRendezVous != "Sans Rendez Vous" && n.FinDeConsultation == true).AsEnumerable().Count()),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb10);

                            TableauDeBordClass Nb11 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des consultations sans rendez vous dans cette période ",
                                Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.NuméroRendezVous == "Sans Rendez Vous" && n.FinDeConsultation == true).AsEnumerable().Count()),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb11);

                            RecapGrid.ItemsSource = listtableaudebord;



                        }else
                        {
                            List<SVC.SalleDattente> SelectedSalleAttente = (proxy.GetAllSalleDattente(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).ToList();
                            List<SVC.Visite> SelectedVisite = (proxy.GetAllVisite(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).ToList();
                            List<SVC.Depeiment> SelectedDepeiment = (proxy.GetAllDepeiment()).Where(n => n.date >= DateVisiteDébut.SelectedDate && n.date <= DateVisiteFin.SelectedDate  && n.CodeMedecin!=0).ToList();
                            List<SVC.RendezVou> Selectedrendezvous = (proxy.GetAllRendezVous(DateVisiteDébut.SelectedDate.Value, DateVisiteFin.SelectedDate.Value)).ToList();
                        

                            /**************/
                            List<SVC.DepeiementMultiple> SelectedDepeimentMultiple = (proxy.GetAllDepeiementMultiple()).Where(n => n.date >= DateVisiteDébut.SelectedDate && n.date <= DateVisiteFin.SelectedDate ).ToList();

                            if (SelectedDepeimentMultiple.Count > 0)
                            {

                                foreach (SVC.DepeiementMultiple item in SelectedDepeimentMultiple)
                                {
                                    SVC.Depeiment depeiteim = new SVC.Depeiment
                                    {
                                        CodeMedecin = item.CodeMedecin,
                                        NomMedecin = item.NomMedecin,
                                        PrénomMedecin = item.PrénomMedecin,
                                        CodePatient = item.CodePatient,
                                        NomPatient = item.NomPatient,
                                        PrénomPatient = item.PrénomPatient,
                                        banque = item.banque,
                                        amontant = item.amontant,
                                        CleMultiple = item.cleMultiple,
                                        cle = item.cleVisite,
                                        date = item.date,
                                        cp = item.cp,
                                        dates = item.dates,
                                        enreg = item.enreg,
                                        montant = item.montant,
                                        Multiple = true,
                                        nfact = item.nfact,
                                        oper = item.oper,
                                        paiem = item.paiem,
                                    };
                                    SelectedDepeiment.Add(depeiteim);
                                }
                            }
                            /**************/
                            ConsultationDatagrid.ItemsSource = SelectedSalleAttente;
                            VisiteDatagrid.ItemsSource = SelectedVisite;
                            txtLabelTotalAregler.Content = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Montant));
                            txtLabelTotalversement.Content = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Versement));
                            txtLabelTotalReste.Content = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Reste));


                            ReglementDatagrid.ItemsSource = SelectedDepeiment;
                            txttotalreglement.Text = Convert.ToString(SelectedDepeiment.AsEnumerable().Sum(n => n.montant));
                          
                            RendezVousDatagrid.ItemsSource = Selectedrendezvous;
                            NBRENDEZVOUS.Text = Convert.ToString(Selectedrendezvous.AsEnumerable().Count());




                            listtableaudebord = new List<TableauDeBordClass>();

                            /*************************Nombre De Consultations Patients***************************/
                            TableauDeBordClass Nb = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Nombre De Consultations Patients",
                                Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.FinDeConsultation == true).AsEnumerable().Count()),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };

                            listtableaudebord.Add(Nb);
                            /**********************************Total montant des visites faites*****************************************************/
                            TableauDeBordClass Nb1 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Montant des consultations faites ",
                                Valeur = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Montant)),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };

                            listtableaudebord.Add(Nb1);

                            TableauDeBordClass Nb4 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des versements reçu sur les consultations de cette Période ",
                                Valeur = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Versement)),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb4);
                            TableauDeBordClass Nb6 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des restes sur les consultations de cette Période",
                                Valeur = Convert.ToString(SelectedVisite.AsEnumerable().Sum(n => n.Reste)),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb6);
                            /**********************************Total montant des visites faites*****************************************************/
                            TableauDeBordClass Nb2 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Nombre total des minutes de consultation ",
                                Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.FinDeConsultation == true).AsEnumerable().Sum(n => n.TempsQuitMedecinSalle.Value.TotalMinutes - n.TempsChezMedecinSalle.Value.TotalMinutes)),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };

                            listtableaudebord.Add(Nb2);

                            TableauDeBordClass Nb3 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Moyenne Minutes par consultation ",
                                Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.FinDeConsultation == true).AsEnumerable().Sum(n => n.TempsQuitMedecinSalle.Value.TotalMinutes - n.TempsChezMedecinSalle.Value.TotalMinutes) / SelectedSalleAttente.AsEnumerable().Count()),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb3);


                            TableauDeBordClass Nb5 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des versements reçu dans cette période ",
                                Valeur = Convert.ToString(SelectedDepeiment.AsEnumerable().Sum(n => n.montant)),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb5);
                            /*****Stock*****Selectedam*/
                            TableauDeBordClass Nb7 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total quantité des produits consommés dans cette période ",
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb7);
                            TableauDeBordClass Nb8 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total valeur des produits consommés dans cette période ",
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb8);
                            /******************Selectedrendezvous************************/
                            TableauDeBordClass Nb9 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des rendez vous pris dans cette période ",
                                Valeur = Convert.ToString(Selectedrendezvous.AsEnumerable().Count()),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb9);

                            TableauDeBordClass Nb10 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des consultations avec rendez vous dans cette période ",
                                Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.NuméroRendezVous != "Sans Rendez Vous" && n.FinDeConsultation == true).AsEnumerable().Count()),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb10);

                            TableauDeBordClass Nb11 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total des consultations sans rendez vous dans cette période ",
                                Valeur = Convert.ToString(SelectedSalleAttente.Where(n => n.NuméroRendezVous == "Sans Rendez Vous" && n.FinDeConsultation == true).AsEnumerable().Count()),
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb11);

                            /******************SelectedAchat*///////////////////
                            TableauDeBordClass Nb12 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total en H.T des produits acheter dans cette période ",
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb12);

                            /************************/
                            TableauDeBordClass Nb13 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total en T.T.C des produits acheter dans cette période ",
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb13);
                            /**********************************************************/
                            TableauDeBordClass Nb14 = new TableauDeBordClass
                            {
                                Date1 = Convert.ToDateTime(DateVisiteDébut.SelectedDate),
                                Date2 = Convert.ToDateTime(DateVisiteFin.SelectedDate),
                                Rubrique = "Total valeur des produits disponible dans le stock ",
                                Remarque = "Vous pouvez enrichir vôtre rapport avec des remarques avant de l'imprimer",

                            };
                            listtableaudebord.Add(Nb14);
                            /**********************************************************/
                            RecapGrid.ItemsSource = listtableaudebord;

                        }
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void MedecinCombo_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (medecinsession == false)
                {
                    MedecinCombo.ItemsSource = proxy.GetAllMedecin().OrderBy(n => n.Nom);

                }

            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnLogoDent_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            Process p = new Process();
            p.StartInfo.FileName = "http://www.medicalogitech.com";
            p.Start();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

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

                    if (RowDataContaxt.Quit == true && RowDataContaxt.FinDeConsultation == false && RowDataContaxt.MedecinSalle==false)
                        e.Row.Background = (Brush)converter.ConvertFromString(SalleAttenteQuit);
                    else 
                    /*toujours dans la salle d'attente sans la quitter*/
                            if (RowDataContaxt.Quit == false && RowDataContaxt.FinDeConsultation == false && RowDataContaxt.MedecinSalle == false)
                        e.Row.Background = (Brush)converter.ConvertFromString(SalleAttenteTjr);
                    else
                    /*le patient est passé par le medecin et a fini sa consultation*/
                    if (RowDataContaxt.FinDeConsultation == true && RowDataContaxt.Quit == true && RowDataContaxt.MedecinSalle == true)
                        e.Row.Background = (Brush)converter.ConvertFromString(MedecinSalleNON);
                    else if (RowDataContaxt.FinDeConsultation == false && RowDataContaxt.Quit == true && RowDataContaxt.MedecinSalle == true)
                        e.Row.Background = (Brush)converter.ConvertFromString(MedecinSalleTjr);

                }
            }
            catch (Exception ex)
            {

                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } 
            
    }
}
