﻿using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Reporting.WinForms;
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

namespace Medicus.Patient
{
    /// <summary>
    /// Interaction logic for ImpressionAutreBilan.xaml
    /// </summary>
    public partial class ImpressionAutreBilan : DXWindow
    {
        SVC.ServiceCliniqueClient proxy;

        private delegate void FaultedInvokerAutreBilan();
        public ImpressionAutreBilan(SVC.ServiceCliniqueClient proxyrecu, List<SVC.AutreBilan> constanterecu,List<SVC.Patient> listpatient)
        {
            try
            {
                InitializeComponent();
              
                proxy = proxyrecu;
                // datable = datatablerecu;


                MemoryStream MyRptStream = new MemoryStream((Medicus.Properties.Resources.AutreBilan), false);

                reportViewer1.LocalReport.LoadReportDefinition(MyRptStream);
                // reportViewer1.LocalReport.ReportPath = "../../Patient/ReportOnePatient.rdlc";

                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet2";//This refers to the dataset name in the RDLC file
                rds.Value = listpatient;
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                var selpara = new List<SVC.Param>();
                selpara.Add((proxy.GetAllParamétre()));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", selpara));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", constanterecu));

                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter paramLogo = new ReportParameter();
                paramLogo.Name = "ImagePath";
                String photolocation = System.Environment.CurrentDirectory + "/Logo.png";

                paramLogo.Values.Add(@"file:///" + photolocation);
                reportViewer1.LocalReport.SetParameters(paramLogo);
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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerAutreBilan(HandleProxy));
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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerAutreBilan(HandleProxy));
                return;
            }
            HandleProxy();
        }
    }
}
