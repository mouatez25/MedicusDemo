using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using Microsoft.Reporting.WinForms;
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
    /// Interaction logic for ImpressionArret.xaml
    /// </summary>
    public partial class ImpressionArret : DXWindow
    {
        SVC.ServiceCliniqueClient proxy;
        private delegate void FaultedInvokerImpressionArret();
        List<SVC.Depeiment> depaiemlist = new List<SVC.Depeiment>();
        List<SVC.Depeiment> depaiemlistTEST = new List<SVC.Depeiment>();
        public ImpressionArret(SVC.ServiceCliniqueClient proxyrecu, List<SVC.ArretDetravail> listdetailArretDetravail, List<SVC.Medecin> listmededcin)
        {
            try
            {
                InitializeComponent();






                MemoryStream MyRptStream1 = new MemoryStream((Medicus.Properties.Resources.ArretDeTravail), false);
                reportViewerCertificatArret.LocalReport.LoadReportDefinition(MyRptStream1);



                this.reportViewerCertificatArret.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", listmededcin));
                this.reportViewerCertificatArret.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", listdetailArretDetravail));

                reportViewerCertificatArret.LocalReport.EnableExternalImages = true;



                ReportParameter paramLogo = new ReportParameter();
                paramLogo.Name = "ImagePath";
                String photolocation = System.Environment.CurrentDirectory + "/Logo.png";

                paramLogo.Values.Add(@"file:///" + photolocation);

                reportViewerCertificatArret.LocalReport.SetParameters(paramLogo);
                reportViewerCertificatArret.RefreshReport();
            }catch(Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
        void InnerDuplexChannel_Closed(object sender, EventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerImpressionArret(HandleProxy));
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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerImpressionArret(HandleProxy));
                return;
            }
            HandleProxy();
        }
    }
}
