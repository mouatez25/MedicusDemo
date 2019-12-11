using DevExpress.Xpf.Core;
using MahApps.Metro.Controls;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ImpressionVisite.xaml
    /// </summary>
    public partial class ImpressionVisite : DXWindow
    {
        SVC.ServiceCliniqueClient proxy;
        private delegate void FaultedInvokerImpressionVisite();
        public ImpressionVisite(SVC.ServiceCliniqueClient proxyrecu, List<SVC.Visite> BoucheRecu,int iterfacerecu, DateTime datedebut, DateTime datefin)
        {
            try
            {
              


                InitializeComponent();
         
                proxy = proxyrecu;
                // datable = datatablerecu;
                if (iterfacerecu == 1)
                {
                    MemoryStream MyRptStream = new MemoryStream((Medicus.Properties.Resources.ReportCredti), false);

                    reportViewer1.LocalReport.LoadReportDefinition(MyRptStream);

                    /***********************************/
                    var selpara = new List<SVC.Param>();
                    selpara.Add((proxy.GetAllParamétre()));
                    reportViewer1.LocalReport.EnableExternalImages = true;

                    ReportParameter paramLogo = new ReportParameter();
                    paramLogo.Name = "ImagePath";
                    String photolocation = System.Environment.CurrentDirectory + "/Logo.png";

                    paramLogo.Values.Add(@"file:///" + photolocation);
                    reportViewer1.LocalReport.SetParameters(paramLogo);

                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", selpara));
                    this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", BoucheRecu));
                    reportViewer1.RefreshReport();
                }
                else
                {
                    if (iterfacerecu ==2)
                    { 
                        MemoryStream MyRptStream = new MemoryStream((Medicus.Properties.Resources.ReportVisiteDetailPatient), false);

                        reportViewer1.LocalReport.LoadReportDefinition(MyRptStream);
                        /****************************************/
                        var selpara = new List<SVC.Param>();
                        selpara.Add((proxy.GetAllParamétre()));
                        reportViewer1.LocalReport.EnableExternalImages = true;

                        ReportParameter paramLogo = new ReportParameter();
                        paramLogo.Name = "ImagePath";
                        String photolocation = System.Environment.CurrentDirectory + "/Logo.png";

                        paramLogo.Values.Add(@"file:///" + photolocation);
                        reportViewer1.LocalReport.SetParameters(paramLogo);
                      
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", selpara));
                        this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", BoucheRecu));
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        if (iterfacerecu == 3)
                        {
                            MemoryStream MyRptStream = new MemoryStream((Medicus.Properties.Resources.VisiteGeneral), false);

                            reportViewer1.LocalReport.LoadReportDefinition(MyRptStream);
                            var selpara = new List<SVC.Param>();
                            selpara.Add((proxy.GetAllParamétre()));
                            reportViewer1.LocalReport.EnableExternalImages = true;

                            /************************/
                            ReportParameter paramDateDebut = new ReportParameter();
                            paramDateDebut.Name = "DateDebut";
                            paramDateDebut.Values.Add(datedebut.Date.ToString());
                            reportViewer1.LocalReport.SetParameters(paramDateDebut);
                            /****************************/
                            /************************/
                            ReportParameter paramDateFin = new ReportParameter();
                            paramDateFin.Name = "DateFin";
                            paramDateFin.Values.Add(datefin.Date.ToString());
                            reportViewer1.LocalReport.SetParameters(paramDateFin);
                            /********************************************/

                            ReportParameter paramLogo = new ReportParameter();
                            paramLogo.Name = "ImagePath";
                            String photolocation = System.Environment.CurrentDirectory + "/Logo.png";

                            paramLogo.Values.Add(@"file:///" + photolocation);
                            reportViewer1.LocalReport.SetParameters(paramLogo);
                       


                            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", selpara));
                            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", BoucheRecu));
                            reportViewer1.RefreshReport();
                        }
                    }
               }



                reportViewer1.RefreshReport();


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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerImpressionVisite(HandleProxy));
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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerImpressionVisite(HandleProxy));
                return;
            }
            HandleProxy();
        }
    }
}
