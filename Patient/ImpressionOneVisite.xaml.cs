﻿using DevExpress.Xpf.Core;
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

namespace Medicus.Patient
{
    /// <summary>
    /// Interaction logic for ImpressionOneVisite.xaml
    /// </summary>
    public partial class ImpressionOneVisite : DXWindow
    {
        SVC.ServiceCliniqueClient proxy;

        private delegate void FaultedInvokerHistoriqueVisiteOne();
        public ImpressionOneVisite(SVC.ServiceCliniqueClient proxyrecu, SVC.Visite constanterecu)
        {
            try
            {
                InitializeComponent();
                var people = new List<SVC.Visite>();
                people.Add(constanterecu);
                proxy = proxyrecu;
                // datable = datatablerecu;


                MemoryStream MyRptStream = new MemoryStream((Medicus.Properties.Resources.ReportOneVisite), false);

                reportViewer1.LocalReport.LoadReportDefinition(MyRptStream);
                // reportViewer1.LocalReport.ReportPath = "../../Patient/ReportOnePatient.rdlc";

                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";//This refers to the dataset name in the RDLC file
                rds.Value = people;
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                var selpara = new List<SVC.Param>();
                selpara.Add((proxy.GetAllParamétre()));
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", selpara));


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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerHistoriqueVisiteOne(HandleProxy));
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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerHistoriqueVisiteOne(HandleProxy));
                return;
            }
            HandleProxy();
        }
    }
}
