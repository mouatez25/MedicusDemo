using DevExpress.Xpf.Core;
using Medicus.Administrateur;
using MahApps.Metro.Controls;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for CertificatRapport.xaml
    /// </summary>
    public partial class CertificatRapport : DXWindow
    {
        SVC.ServiceCliniqueClient proxy;
        SVC.Membership Membership;
        SVC.Medecin medecin;
        SVC.ArretDetravail detailArretDetravail;
        private delegate void FaultedInvokerCertificat();

        public CertificatRapport(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership memberrecu, ICallback callbackrecu)
        {
            try
            {
                InitializeComponent();
                Membership = memberrecu;
                proxy = proxyrecu;
                var disponible = (proxy.GetAllMedecin()).Where(list1 => list1.UserName == Membership.UserName).FirstOrDefault();
                if (disponible == null)
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Vous devez avoir une session de medecin pour pouvoir faire cette opération", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }
                else
                {
                    medecin = disponible;
                    List<SVC.Medecin> listmededcin = new List<SVC.Medecin>();
                    listmededcin.Add(medecin);
                    /**********************certificat***********************/
                    List<RapportCertificat> listdetail = new List<RapportCertificat>();
                    RapportCertificat detail = new RapportCertificat
                    {
                        Asignature = "Constantine",
                        DateExam = DateTime.Now,
                        DateNaissancePatient = DateTime.Now,
                        LieudeNaissancePatient = "Constantine Algerie",
                        Faitle = DateTime.Now,
                        NomPrenomPatient = "Nom et Prénom du patient",
                        Pratique = "La pratique en compétition du Triathlon et des disciplines enchaînées"
                    };
                    listdetail.Add(detail);
                    RapportCertificat detail1 = new RapportCertificat
                    {
                        Asignature = "Constantine",
                        DateExam = DateTime.Now,
                        DateNaissancePatient = DateTime.Now,
                        LieudeNaissancePatient = "Constantine Algerie",
                        Faitle = DateTime.Now,
                        NomPrenomPatient = "Nom et Prénom du patient",
                        Pratique = "La pratique à l'entraînement uniquement du Triathlon et des disciplines enchaînées",
                    };
                    listdetail.Add(detail1);

                    GridMedecin.DataContext = detail;
                    RecapGrid.DataContext = listdetail;
                    RecapGrid.ItemsSource = listdetail;


                    MemoryStream MyRptStream = new MemoryStream((Medicus.Properties.Resources.CertificationMedical), false);
                    reportViewerCertificatMedical.LocalReport.LoadReportDefinition(MyRptStream);



                    this.reportViewerCertificatMedical.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", listmededcin));
                    this.reportViewerCertificatMedical.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", listdetail));

                    reportViewerCertificatMedical.LocalReport.EnableExternalImages = true;
                    ReportParameter paramLogo = new ReportParameter();
                    paramLogo.Name = "ImagePath";
                    String photolocation = System.Environment.CurrentDirectory + "/Logo.png";

                    paramLogo.Values.Add(@"file:///" + photolocation);
                    reportViewerCertificatMedical.LocalReport.SetParameters(paramLogo);
                    reportViewerCertificatMedical.RefreshReport();
                    /*********************************************************/
                    /***********************arret***************************************/

                    List<SVC.ArretDetravail> listdetailArretDetravail = new List<SVC.ArretDetravail>();
                    detailArretDetravail = new SVC.ArretDetravail
                    {
                        Asignature = "Constantine",
                        DateDebutArret = DateTime.Now,
                        DateNaissancePatient = DateTime.Now,
                        LieudeNaissancePatient = "Constantine Algerie",
                        Faitle = DateTime.Now,
                        NomPrenomPatient = "Nom et Prénom du patient",
                        autorisées = true,
                        nonautorisées = false,
                        compteurarret = "000001",
                        Nbjour = "7 jours",

                    };
                    listdetailArretDetravail.Add(detailArretDetravail);

                    SimpleButton.IsEnabled = true;
                    GridMedecinArret.DataContext = detailArretDetravail;



                    MemoryStream MyRptStream1 = new MemoryStream((Medicus.Properties.Resources.ArretDeTravail), false);
                    reportViewerCertificatArret.LocalReport.LoadReportDefinition(MyRptStream1);
                    DateSaisieDébut.SelectedDate = DateTime.Now;
                    DateSaisieFin.SelectedDate = DateTime.Now;


                    this.reportViewerCertificatArret.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", listmededcin));
                    this.reportViewerCertificatArret.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", listdetailArretDetravail));

                    reportViewerCertificatArret.LocalReport.EnableExternalImages = true;


                    reportViewerCertificatArret.LocalReport.SetParameters(paramLogo);
                    reportViewerCertificatArret.RefreshReport();
                    ArretDataGrid.ItemsSource = proxy.GetAllArretDetravail();//.OrderBy(n=>n.)
                    proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);

                    proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);

                    callbackrecu.InsertArretDetravailCallbackevent += new ICallback.CallbackEventHandler57(callbackrecu_Refresh);




                    /*************************************************************************/
                }

            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        void callbackrecu_Refresh(object source, CallbackEventInsertArretDetravail e)
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
        public void AddRefresh(List<SVC.ArretDetravail> listmembership)
        {
            try
            {

                ArretDataGrid.ItemsSource = listmembership.OrderBy(n => n.DateDebutArret);
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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerCertificat(HandleProxy));
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
        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerCertificat(HandleProxy));
                return;
            }
            HandleProxy();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tabBord2dd.IsSelected = true;
                compteurarret.Text = "";
                DateExamArret.SelectedDate = null;
                Nbjour.Text = "";
                NomPrenomPatientArret.Text = "";
                DateNaissancePatientArret.SelectedDate = null;
                chkboxnonautoriser.IsChecked = false;
                chkboxautoriser.IsChecked = false;
                LieudeNaissancePatientArret.Text = "";
                FaitleArret.Text = "";
                AsignatureArret.Text = "";

            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnSupp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ArretDataGrid.SelectedItem!=null)
                {
                    SVC.ArretDetravail selectedarret = ArretDataGrid.SelectedItem as SVC.ArretDetravail;
                    proxy.DeleteArretDetravail(selectedarret);
                    proxy.AjouterArrettravailRefresh();
                    MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);


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
                if(ArretDataGrid.SelectedItem!=null)
                {
                    SVC.ArretDetravail selectedarred = ArretDataGrid.SelectedItem as SVC.ArretDetravail;
                    List<SVC.ArretDetravail> ar = new List<SVC.ArretDetravail>();
                        ar.Add(selectedarred);
                    List<SVC.Medecin> med = new List<SVC.Medecin>();
                    med.Add(medecin);
                    ImpressionArret cl = new ImpressionArret(proxy, ar, med);
                    cl.Show();
                }
                
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(DateSaisieDébut.SelectedDate!=null && DateSaisieFin.SelectedDate!=null)
                {
                    ArretDataGrid.ItemsSource = proxy.GetAllArretDetravail().Where(n => n.Faitle >= DateSaisieDébut.SelectedDate && n.Faitle <= DateSaisieFin.SelectedDate);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (compteurarret.Text != "" && DateExamArret.SelectedDate != null && Nbjour.Text != "" && NomPrenomPatientArret.Text != "" && DateNaissancePatientArret.SelectedDate != null && LieudeNaissancePatientArret.Text != "" && FaitleArret.SelectedDate != null && AsignatureArret.Text != "" &&(chkboxautoriser.IsChecked==true || chkboxnonautoriser.IsChecked==true))
               {
                    proxy.InsertArretDetravail(detailArretDetravail);
                    proxy.AjouterArrettravailRefresh();
                    MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show("Vous devez remplir les champs obligatoires", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                } 
            }catch(Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void txtRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                ICollectionView cv = CollectionViewSource.GetDefaultView(ArretDataGrid.ItemsSource);
                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        SVC.ArretDetravail p = o as SVC.ArretDetravail;
                        if (t.Name == "txtId")
                            return (p.NomPrenomPatient == filter);
                        return (p.NomPrenomPatient.ToUpper().Contains(filter.ToUpper()));
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void compteurarret_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                if (compteurarret.Text.Trim() != "")
                {

                    var query = from c in proxy.GetAllArretDetravail()
                                select new { c.compteurarret };

                    var results = query.ToList();
                    var disponible = results.Where(list1 => list1.compteurarret.Trim().ToUpper() == compteurarret.Text.Trim().ToUpper()).FirstOrDefault();

                    if (disponible != null)
                    {

                        SimpleButton.IsEnabled = false;
 

                    }
                    else
                    {
                        SimpleButton.IsEnabled = true;
                    }
                }
                else
                {

                    SimpleButton.IsEnabled = false;
 
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
