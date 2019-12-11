using DevExpress.Xpf.Core;
using Medicus.Administrateur;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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

namespace Medicus.Caisse
{
    /// <summary>
    /// Interaction logic for AjouterTransaction.xaml
    /// </summary>
    public partial class AjouterTransaction : DXWindow
    {
        SVC.ServiceCliniqueClient proxy;
        SVC.Membership memberuser;
        ICallback callback;
        private delegate void FaultedInvokerMotifDépense();
        SVC.Depense depenseP;
        int interfaceAppel;
    
        SVC.Visite VisiteApayer;
      
        List<SVC.Visite> visiteversementmultiple;
        public bool DepaiemtMultipleSucces , DepaiemSucces , UpdateVisitesucess  , InsertDepensesucces ;
        bool manuellecreation = false;
        int MANUELL = 0;
        public AjouterTransaction(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership memberrecu, ICallback callbackrecu,SVC.Depense depenserecu ,int interfaceRecu,SVC.Visite visiterecu,List<SVC.Visite> listrecuvisitte)
        {
            try
            {
                InitializeComponent();
                proxy = proxyrecu;
                memberuser = memberrecu;
                callback = callbackrecu;
                MotifDepense.ItemsSource = proxy.GetAllMotifDepense();
                interfaceAppel = interfaceRecu;

                if (interfaceAppel == 1)
                {/* première interface écriture manuellle*/
                    /*************modification***************/
                    if (depenserecu != null)
                    {
                        manuellecreation = false;
                        MANUELL = 2;
                        depenseP = depenserecu;
                        if (depenseP.Débit == true)
                        {
                            txtRubriqueMontant.Visibility = Visibility.Visible;
                            txtRubriqueMontantD.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            if (depenseP.Crédit == true)
                            {
                                txtRubriqueMontantD.Visibility = Visibility.Visible;
                                txtRubriqueMontant.Visibility = Visibility.Collapsed;
                            }
                        }
                        ModeRéglement.SelectedIndex = 0;

                        GridTransaction.DataContext = depenseP;
                      //  MessageBoxResult resultcd1 = Xceed.Wpf.Toolkit.MessageBox.Show("Init comp i'm here", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        /*****************creation********************/
                        manuellecreation = true;
                        MANUELL = 1;
                        depenseP = new SVC.Depense
                        {
                            DateDebit=DateTime.Now,
                            DateSaisie=DateTime.Now,
                          //  CompteDébité=""
                          Crédit=false,
                          Débit=true,
                          Auto=false,
                          Username=memberuser.UserName,
                       //   ModePaiement= "Espèces",
                         
                        };
                        txtRubriqueMontant.Visibility = Visibility.Visible;
                        txtRubriqueMontantD.Visibility = Visibility.Collapsed;
                     //   ModeRéglement.SelectedIndex = 0;
                        GridTransaction.DataContext = depenseP;
                     //   MessageBoxResult resultcd1 = Xceed.Wpf.Toolkit.MessageBox.Show("Init création", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);


                    }
                }
                else
                {
                    if (interfaceAppel == 2)
                    {

                    }
                    else
                    {
                        if (interfaceAppel == 3)
                        {/*troisiéme interface réglement visite patient*/
                            if (visiterecu != null)
                            {
                                VisiteApayer = visiterecu;
                                depenseP = new SVC.Depense();
                                depenseP.DateSaisie = DateTime.Now;
                                depenseP.DateDebit = DateTime.Now;
                                depenseP.Débit = false;
                                depenseP.Crédit =true;

                                f.Content = VisiteApayer.Motif + " " + VisiteApayer.NomPatient+ " "+VisiteApayer.PrénomPatient;
                                txtNumFacture.IsEnabled = false;
                                txtRubriqueMontant.Visibility = Visibility.Collapsed;
                                txtRubriqueMontantD.Visibility = Visibility.Visible;
                                    txtDate.SelectedDate = DateTime.Now.Date;
                                    chCredit.IsEnabled = true;
                                    chDebit.IsChecked = false;
                                   chDebit.IsEnabled = false;
                                    depenseP.RubriqueComptable = "Paiement Visite :" + VisiteApayer.NomPatient +" "+VisiteApayer.PrénomPatient;
                                    depenseP.Num_Facture =Convert.ToString(VisiteApayer.Id);
                                   depenseP.MontantCrédit= VisiteApayer.Reste;
                                    txtNumFacture.IsEnabled = false;
                                    f.Foreground = Brushes.Black;
                                chImpressionRecuPatient.Visibility = Visibility.Visible;
                                    GridTransaction.DataContext = depenseP;
                                ModeRéglement.SelectedIndex = 0;
                            }
                        }else
                        {/************multiple versement visite****************/
                            if (interfaceAppel == 4)
                            {
                                if (visiterecu == null)
                                {
                                    visiteversementmultiple = listrecuvisitte;

                                    depenseP = new SVC.Depense();
                                    depenseP.DateSaisie = DateTime.Now;
                                    depenseP.DateDebit = DateTime.Now;
                                    depenseP.Débit = false;
                                    depenseP.Crédit = true;
                                    chCredit.IsEnabled = true;
                                    chDebit.IsChecked = false;
                                    chDebit.IsEnabled = false;
                                    /************************/
                                    f.Content = "Versement multiple" + " " + visiteversementmultiple.AsEnumerable().First().NomPatient + " " + visiteversementmultiple.AsEnumerable().First().PrénomPatient;
                                    /*****************************************/
                                    txtNumFacture.IsEnabled = false;
                                    txtRubriqueMontant.Visibility = Visibility.Collapsed;
                                    txtRubriqueMontantD.Visibility = Visibility.Visible;
                                    txtDate.SelectedDate = DateTime.Now.Date;
                                    /******************************************************/
                                    depenseP.RubriqueComptable = "Paiement Visite multiple :" + visiteversementmultiple.AsEnumerable().First().NomPatient + " " + visiteversementmultiple.AsEnumerable().First().PrénomPatient;
                                    depenseP.Num_Facture = "Paiement Visite multiple ";
                                    /***********************************************************/
                                    depenseP.MontantCrédit = visiteversementmultiple.AsEnumerable().Sum(o => o.Reste);

                                    txtNumFacture.IsEnabled = false;
                                    f.Foreground = Brushes.Black;
                                    chImpressionRecuPatient.Visibility = Visibility.Visible;
                                    GridTransaction.DataContext = depenseP;
                                    ModeRéglement.SelectedIndex = 0;

                                }
                            }
                        
                        }
                    }

                    callbackrecu.InsertMotifDepenseCallbackEvent += new ICallback.CallbackEventHandler19(callbackrecu_Refresh);
                 
                }
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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerMotifDépense(HandleProxy));
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
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new FaultedInvokerMotifDépense(HandleProxy));
                return;
            }
            HandleProxy();
        }
        void callbackrecu_Refresh(object source, CallbackEventInsertMotifDepense e)
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
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        public void AddRefresh(List<SVC.MotifDepense> listmembership)
        {
            try
            {

          
            MotifDepense.ItemsSource = listmembership;
            }catch (Exception ex)

            {
                this.Title = ex.Message;
            //    this.WindowTitleBrush = Brushes.Red;
            }
        }

        private void MotifDepense_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            { 
            if (MotifDepense.SelectedItem != null)
            {
                SVC.MotifDepense SelectMedecin = MotifDepense.SelectedItem as SVC.MotifDepense;
                txtRubriqueComptable.Text = SelectMedecin.MotifD.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnCreer_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            WaitIndicatorS.DeferedVisibility = true;
            BACK.Visibility = Visibility.Visible;
            bool depaiefResult = false;
            bool RecoufResult = false;
            bool depenseResult = false;
            try
            {
                if (manuellecreation=true && interfaceAppel == 1 && MANUELL==1)
                {
                    if ((txtRubriqueMontant.Text != "0" || txtRubriqueMontantD.Text != "0") && txtDate.SelectedDate != null && txtDateOper.SelectedDate != null && ModeRéglement.SelectedValue != null && txtRubriqueComptable.Text != "" && (chDebit.IsChecked == true || chCredit.IsChecked == true))
                    {
                        using (var ts = new TransactionScope())
                        {

                            depenseP.DateDebit = txtDateOper.SelectedDate;
                            depenseP.DateSaisie = txtDate.SelectedDate;

                            depenseP.ModePaiement = ModeRéglement.SelectionBoxItem.ToString();
                            //CompteDébité=
                            depenseP.RubriqueComptable = txtRubriqueComptable.Text.Trim();
                            // depenseP.Montant = 0;
                            //depenseP.MontantCrédit = 0;
                            depenseP.Commentaires = txtComentaire.Text.Trim();
                            depenseP.Num_Facture = txtNumFacture.Text.Trim();
                            depenseP.NumCheque = txtNumCheque.Text.Trim();
                            depenseP.Username = memberuser.UserName.ToString();
                            depenseP.Auto = false;


                            if (radioCompteCaisse.IsChecked == true && radioCompteBanque.IsChecked == false)
                            {
                                depenseP.CompteDébité = "Caisse";
                            }
                            else
                            {
                                if (radioCompteBanque.IsChecked == true && radioCompteCaisse.IsChecked == false)
                                {
                                    depenseP.CompteDébité = "Banque";
                                }
                            }
                            if (chDebit.IsChecked == true && txtRubriqueMontant.Text != "0")
                            {
                                depenseP.Débit = true;
                                depenseP.Crédit = false;
                                depenseP.Montant = Convert.ToDecimal(txtRubriqueMontant.Text);
                                depenseP.MontantCrédit = 0;
                                //   MessageBoxResult resultc1k = Xceed.Wpf.Toolkit.MessageBox.Show("debit", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                            else
                            {
                                if (chCredit.IsChecked == true && txtRubriqueMontantD.Text != "0")
                                {
                                    depenseP.Crédit = true;
                                    depenseP.Débit = false;
                                    depenseP.MontantCrédit = Convert.ToDecimal(txtRubriqueMontantD.Text);
                                    depenseP.Montant = 0;
                                    //      MessageBoxResult resultc1k = Xceed.Wpf.Toolkit.MessageBox.Show("credit", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                                }
                            }

                            proxy.InsertDepense(depenseP);
                            ts.Complete();

                            //    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                        //    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show("création touours", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);
                            MessageBoxResult resultcG1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                            //   this.WindowTitleBrush = Brushes.Green;


                        }
                        proxy.AjouterDepenseRefresh();
                    }

                }
                else
                {/****************modification ecriture manuelle**********/
                    if (/*manuellecreation=false*/interfaceAppel == 1 && MANUELL==2)
                    {
                        if ((txtRubriqueMontant.Text != "0" || txtRubriqueMontantD.Text != "0") && txtDate.SelectedDate != null && txtDateOper.SelectedDate != null && ModeRéglement.SelectedValue != null && txtRubriqueComptable.Text != "" )
                        {
                            using (var ts = new TransactionScope())
                            {
                                if (radioCompteCaisse.IsChecked == true)
                                {
                                    depenseP.CompteDébité = "Caisse";
                                }
                                else
                                {
                                    if (radioCompteBanque.IsChecked == true)
                                    {
                                        depenseP.CompteDébité = "Banque";
                                    }
                                }
                                if (chDebit.IsChecked == true && txtRubriqueMontant.Text != "0")
                                {
                                    depenseP.Débit = true;
                                    depenseP.Crédit = false;
                                    depenseP.Montant = Convert.ToDecimal(txtRubriqueMontant.Text);
                                    depenseP.MontantCrédit = 0;
                                }
                                else
                                {
                                    if (chCredit.IsChecked == true && txtRubriqueMontantD.Text != "0")
                                    {
                                        depenseP.Crédit = true;
                                        depenseP.Débit = false;
                                        depenseP.MontantCrédit = Convert.ToDecimal(txtRubriqueMontantD.Text);
                                        depenseP.Montant = 0;
                                    }
                                }

                                proxy.UpdateDepense(depenseP);
                                ts.Complete();
                            //    MessageBoxResult resultcd1 = Xceed.Wpf.Toolkit.MessageBox.Show("Modification manuelle", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                            proxy.AjouterDepenseRefresh();
                        }
                    }
                    else
                    {
                        /******************paiement fournisseur**********************/
                        if (depenseP != null && txtDate.SelectedDate != null && txtDateOper.SelectedDate != null && ModeRéglement.SelectedValue != null && txtRubriqueComptable.Text != "" && txtRubriqueMontant.Text != "0" /*&&  txtComentaire.Text != "" && txtNumCheque.Text != "" */&& interfaceAppel == 2)
                        {
                        }
                        else
                        {
                            if (depenseP != null && txtDate.SelectedDate != null && txtDateOper.SelectedDate != null && ModeRéglement.SelectedValue != null && txtRubriqueComptable.Text != "" && txtRubriqueMontantD.Text != "0" /*&& txtComentaire.Text != "" && txtNumCheque.Text != "" */&& interfaceAppel == 3)
                            {
                                try
                                {
                                   // bool varcastraitement = false;
                                    //var castraitement = (proxy.GetAllTraitement()).Find(n => n.Id == VisiteApayer.IdCas);
                                    SVC.Depeiment dpf;
                                    using (var ts = new TransactionScope())
                                    {

                                        depenseP.DateDebit = txtDateOper.SelectedDate;
                                        depenseP.DateSaisie = txtDate.SelectedDate;
                                        depenseP.ModePaiement = ModeRéglement.SelectionBoxItem.ToString();

                                        depenseP.RubriqueComptable = txtRubriqueComptable.Text.Trim();
                                        depenseP.Montant = 0;
                                        depenseP.MontantCrédit = Convert.ToDecimal(txtRubriqueMontantD.Text);

                                        depenseP.Commentaires = txtComentaire.Text.Trim();
                                        depenseP.Num_Facture = txtNumFacture.Text.Trim();
                                        depenseP.NumCheque = txtNumCheque.Text.Trim();
                                        depenseP.Username = memberuser.UserName.ToString();
                                        depenseP.Auto = true;
                                        depenseP.cle = VisiteApayer.cle;

                                        if (radioCompteCaisse.IsChecked == true && radioCompteBanque.IsChecked == false)
                                        {
                                            depenseP.CompteDébité = "Caisse";
                                        }
                                        else
                                        {
                                            if (radioCompteBanque.IsChecked == true && radioCompteCaisse.IsChecked == false)
                                            {
                                                depenseP.CompteDébité = "Banque";
                                            }
                                        }
                                        proxy.InsertDepense(depenseP);
                                        depenseResult = true;
                                        //    MessageBoxResult resultcx = Xceed.Wpf.Toolkit.MessageBox.Show("depenseResult = true", "Medicus", MessageBoxButton.OK, MessageBoxImage.Information);

                                        dpf = new SVC.Depeiment
                                        {
                                            date = depenseP.DateDebit,
                                            montant = Convert.ToDecimal(depenseP.MontantCrédit),
                                            paiem = depenseP.ModePaiement + " Visite :" + VisiteApayer.Motif + " " + depenseP.Num_Facture + " date :" + depenseP.DateDebit + "Libellé :" + depenseP.NumCheque,
                                            oper = depenseP.Username,
                                            dates = depenseP.DateSaisie,
                                            banque = depenseP.CompteDébité,
                                            nfact = depenseP.Num_Facture,
                                            amontant = Convert.ToDecimal(VisiteApayer.Montant),
                                            cle = depenseP.cle,
                                            cp = VisiteApayer.Id,
                                            Multiple=false,
                                            CodeMedecin=VisiteApayer.CodeMedecin,
                                            NomMedecin=VisiteApayer.VisiteParNom,
                                            PrénomMedecin=VisiteApayer.VisiteParPrénom,
                                            CodePatient=VisiteApayer.CodePatient,
                                            NomPatient=VisiteApayer.NomPatient,
                                            PrénomPatient=VisiteApayer.PrénomPatient,
                                           
                                        };

                                        proxy.InsertDepeiment(dpf);
                                        depaiefResult = true;
                                        //    MessageBoxResult resuldtcx = Xceed.Wpf.Toolkit.MessageBox.Show("depaiefResult", "Medicus", MessageBoxButton.OK, MessageBoxImage.Information);
                                        VisiteApayer.Versement = Convert.ToDecimal(VisiteApayer.Versement) + Convert.ToDecimal(depenseP.MontantCrédit);
                                        VisiteApayer.Reste = Convert.ToDecimal(VisiteApayer.Montant) - Convert.ToDecimal(VisiteApayer.Versement);
                                        if (VisiteApayer.Reste == 0)
                                        {
                                            VisiteApayer.Soldé = true;
                                        }
                                        else
                                        {
                                            VisiteApayer.Soldé = false;
                                        }



                                        proxy.UpdateVisite(VisiteApayer);
                                        RecoufResult = true;
                                        //    MessageBoxResult resuldttcx = Xceed.Wpf.Toolkit.MessageBox.Show("  RecoufResult = true;", "Medicus", MessageBoxButton.OK, MessageBoxImage.Information); 

                                        /* if (VisiteApayer.ModeFacturation == 2)
                                         {
                                             castraitement.Versement = castraitement.Versement + depenseP.MontantCrédit;
                                             castraitement.Reste = castraitement.Reste - depenseP.MontantCrédit;
                                             proxy.UpdateTypeTraitement(castraitement);
                                             varcastraitement = true;
                                          //   MessageBoxResult resuldsttcx = Xceed.Wpf.Toolkit.MessageBox.Show(" varcastraitement = true;", "Medicus", MessageBoxButton.OK, MessageBoxImage.Information);

                                         }*/

                                        if (depaiefResult && RecoufResult && depenseResult)//&& VisiteApayer.ModeFacturation!=2
                                        {
                                            ts.Complete();

                                        //    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information); btnCreer.IsEnabled = false;
                                        }
                                       else
                                        {
                                          /*  if (depaiefResult && RecoufResult && depenseResult && varcastraitement && VisiteApayer.ModeFacturation == 2)
                                            {
                                                ts.Complete();

                                                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information); btnCreer.IsEnabled = false;

                                            }*/
                                           // else
                                          //  {
                                                MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                                           // }
                                        }
                                    }
                                        if (depaiefResult && RecoufResult && depenseResult)//&& VisiteApayer.ModeFacturation!=2
                                        {
                                            proxy.AjouterTransactionPaiementRefresh();
                                            proxy.AjouterDepenseRefresh();
                                            proxy.AjouterSoldeVisiteRefresh();

                                            MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information); btnCreer.IsEnabled = false;
                                        }
                                  

                                    if (chImpressionRecuPatient.IsChecked == true)
                                    {
                                        List<SVC.Depeiment> listedepaiem = new List<SVC.Depeiment>();
                                        listedepaiem.Add(dpf);
                                        List<SVC.Visite> listevisite = new List<SVC.Visite>();
                                        listevisite.Add(VisiteApayer);
                                        ImpressionRecu cl = new ImpressionRecu(proxy, listedepaiem, listevisite);
                                        cl.Show();
                                    }



                                }
                                catch (FaultException ex)
                                {
                                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                                }
                                catch (Exception ex)
                                {
                                    MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                if (depenseP != null && txtDate.SelectedDate != null && txtDateOper.SelectedDate != null && ModeRéglement.SelectedValue != null && txtRubriqueComptable.Text != "" && txtRubriqueMontantD.Text != "0"/* && txtComentaire.Text != "" && txtNumCheque.Text != "" */&& interfaceAppel == 4)
                                {

                                    if (Convert.ToDecimal(txtRubriqueMontantD.Text)<= visiteversementmultiple.AsEnumerable().Sum(o => o.Reste))
                                    {
                                        SVC.Depeiment dpf;

                                        using (var ts = new TransactionScope())
                                        {

                                            /******************insert depense*******************/

                                            depenseP.DateDebit = txtDateOper.SelectedDate;
                                            depenseP.DateSaisie = txtDate.SelectedDate;
                                            depenseP.ModePaiement = ModeRéglement.SelectionBoxItem.ToString();

                                            depenseP.RubriqueComptable = txtRubriqueComptable.Text.Trim();
                                            depenseP.Montant = 0;
                                            depenseP.MontantCrédit = Convert.ToDecimal(txtRubriqueMontantD.Text);

                                            depenseP.Commentaires = txtComentaire.Text.Trim();
                                            depenseP.Num_Facture = txtNumFacture.Text.Trim();
                                            depenseP.NumCheque = txtNumCheque.Text.Trim();
                                            depenseP.Username = memberuser.UserName.ToString();
                                            depenseP.Auto = true;

                                            if (radioCompteCaisse.IsChecked == true && radioCompteBanque.IsChecked == false)
                                            {
                                                depenseP.CompteDébité = "Caisse";
                                            }
                                            else
                                            {
                                                if (radioCompteBanque.IsChecked == true && radioCompteCaisse.IsChecked == false)
                                                {
                                                    depenseP.CompteDébité = "Banque";
                                                }
                                            }
                                            /****************************depaiement*//////////////////////
                                            dpf = new SVC.Depeiment
                                            {
                                                date = depenseP.DateDebit,
                                                montant = Convert.ToDecimal(depenseP.MontantCrédit),
                                                paiem = depenseP.ModePaiement + "Reste Visite Multiple" + depenseP.Num_Facture + " date :" + depenseP.DateDebit + "Libellé :" + depenseP.NumCheque,
                                                oper = depenseP.Username,
                                                dates = depenseP.DateSaisie,
                                                banque = depenseP.CompteDébité,
                                                nfact = depenseP.Num_Facture,
                                                amontant = Convert.ToDecimal(visiteversementmultiple.AsEnumerable().Sum(o => o.Reste)),
                                                //      cle = depenseP.cle,
                                                cp = visiteversementmultiple.AsEnumerable().First().Id,
                                                Multiple = true,
                                                CleMultiple = visiteversementmultiple.Count() + visiteversementmultiple.AsEnumerable().Sum(o => o.Reste).ToString() + DateTime.Now,
                                                CodeMedecin = 0,
                                                NomMedecin = "Versement sur multiple visite",
                                                PrénomMedecin = "Versement sur multiple visite",
                                                CodePatient= visiteversementmultiple.First().CodePatient,
                                                NomPatient= visiteversementmultiple.First().NomPatient,
                                                PrénomPatient=visiteversementmultiple.First().PrénomPatient,
                                                //    enreg=ite
                                            };


                                            /**************************************************************/

                                           Decimal montantAinserer = Convert.ToDecimal(txtRubriqueMontantD.Text);

                                            //   foreach (SVC.Visite itemvisite in visiteversementmultiple)
                                            // {
                                            for (int i = visiteversementmultiple.Count - 1; i >= 0; i--)/*deux critére 1er connécté plus le parcour de la liste*/

                                            {
                                             //   MessageBoxResult resultcd1 = Xceed.Wpf.Toolkit.MessageBox.Show("1st boucle "+ montantAinserer, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                                                var itemvisite = visiteversementmultiple.ElementAt(i);
                                                if (montantAinserer >= itemvisite.Reste && montantAinserer != 0)
                                                {
                                                    /******************Insert MultipleDepaiement*************************/
                                                    DepaiemtMultipleSucces = false;
                                                    SVC.DepeiementMultiple DepeiementMultipleObject = new SVC.DepeiementMultiple
                                                    {
                                                        date = depenseP.DateDebit,
                                                        montant = Convert.ToDecimal(itemvisite.Reste),
                                                        paiem = depenseP.ModePaiement + " Visite :" + itemvisite.Motif + " " + depenseP.Num_Facture + " date :" + depenseP.DateDebit + "Libellé :" + depenseP.NumCheque,
                                                        oper = depenseP.Username,
                                                        dates = depenseP.DateSaisie,
                                                        banque = depenseP.CompteDébité,
                                                        nfact = "Versement multiple",
                                                        amontant = Convert.ToDecimal(itemvisite.Montant),
                                                        cleVisite = itemvisite.cle,
                                                        cp = itemvisite.Id,
                                                        cleMultiple = dpf.CleMultiple,
                                                        CodeMedecin=itemvisite.CodeMedecin,
                                                        NomMedecin=itemvisite.VisiteParNom,
                                                        PrénomMedecin=itemvisite.VisiteParPrénom,
                                                        CodePatient=itemvisite.CodePatient,
                                                        NomPatient=itemvisite.NomPatient,
                                                        PrénomPatient=itemvisite.PrénomPatient,
                                                    };
                                                    proxy.InsertDepeiementMultiple(DepeiementMultipleObject);
                                                    DepaiemtMultipleSucces = true;


                                                    /********************Update Visite***************************/
                                                    UpdateVisitesucess = false;
                                                    itemvisite.Versement = Convert.ToDecimal(itemvisite.Versement) + Convert.ToDecimal(DepeiementMultipleObject.montant);
                                                    itemvisite.Reste = Convert.ToDecimal(itemvisite.Montant) - Convert.ToDecimal(itemvisite.Versement);
                                                    if (itemvisite.Reste == 0)
                                                    {
                                                        itemvisite.Soldé = true;
                                                    }
                                                    else
                                                    {
                                                        itemvisite.Soldé = false;
                                                    }



                                                    proxy.UpdateVisite(itemvisite);
                                                    UpdateVisitesucess = true;

                                                    /*****************mettre à jours le montant*////////////////////////
                                                    montantAinserer = montantAinserer - Convert.ToDecimal(DepeiementMultipleObject.montant);
                                                    depenseP.cle = depenseP.cle + itemvisite.Id + "/";
                                                }
                                                else
                                                {
                                                    if (montantAinserer < itemvisite.Reste && montantAinserer != 0)
                                                    {
                                                        DepaiemtMultipleSucces = false;
                                                        SVC.DepeiementMultiple DepeiementMultipleObject = new SVC.DepeiementMultiple
                                                        {
                                                            date = depenseP.DateDebit,
                                                            montant = Convert.ToDecimal(montantAinserer),
                                                            paiem = depenseP.ModePaiement + " Visite :" + itemvisite.Motif + " " + depenseP.Num_Facture + " date :" + depenseP.DateDebit + "Libellé :" + depenseP.NumCheque,
                                                            oper = depenseP.Username,
                                                            dates = depenseP.DateSaisie,
                                                            banque = depenseP.CompteDébité,
                                                            nfact = "Versement multiple",
                                                            amontant = Convert.ToDecimal(itemvisite.Montant),
                                                            cleVisite = itemvisite.cle,
                                                            cp = itemvisite.Id,
                                                            cleMultiple = dpf.CleMultiple,
                                                            CodeMedecin = itemvisite.CodeMedecin,
                                                            NomMedecin = itemvisite.VisiteParNom,
                                                            PrénomMedecin = itemvisite.VisiteParPrénom,
                                                            CodePatient=itemvisite.CodePatient,
                                                            NomPatient=itemvisite.NomPatient,
                                                            PrénomPatient=itemvisite.PrénomPatient,
                                                        };
                                                        proxy.InsertDepeiementMultiple(DepeiementMultipleObject);
                                                        DepaiemtMultipleSucces = true;
                                                    //    MessageBoxResult resultcd31 = Xceed.Wpf.Toolkit.MessageBox.Show("depeiement multi^ple ok", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);



                                                        /********************Update Visite***************************/
                                                        UpdateVisitesucess = false;
                                                        itemvisite.Versement = Convert.ToDecimal(itemvisite.Versement) + Convert.ToDecimal(DepeiementMultipleObject.montant);
                                                        itemvisite.Reste = Convert.ToDecimal(itemvisite.Montant) - Convert.ToDecimal(itemvisite.Versement);
                                                        if (itemvisite.Reste == 0)
                                                        {
                                                            itemvisite.Soldé = true;
                                                        }
                                                        else
                                                        {
                                                            itemvisite.Soldé = false;
                                                        }



                                                        proxy.UpdateVisite(itemvisite);
                                                        UpdateVisitesucess = true;
                                                   //     MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show("Update visite ok", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                                                        /*****************mettre à jours le montant*////////////////////////

                                                        montantAinserer = montantAinserer - Convert.ToDecimal(DepeiementMultipleObject.montant);
                                                        depenseP.cle = depenseP.cle + itemvisite.Id + "/";

                                                    }else
                                                    {
                                                      //  MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show("NOn pour les deux conditions", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                                                    }

                                                }
                                            }
                                            /***********************insert depense*******************************/


                                            proxy.InsertDepense(depenseP);
                                            InsertDepensesucces = true;
                                         //   MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show("Depense ok", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                                            /*****************************insert depaiement global*****************************/



                                            dpf.cle = depenseP.cle;
                                            proxy.InsertDepeiment(dpf);
                                            DepaiemSucces = true;
                                         //   MessageBoxResult resultc1d = Xceed.Wpf.Toolkit.MessageBox.Show("Depaiement ok", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);


                                            if (DepaiemtMultipleSucces==true && DepaiemSucces==true && UpdateVisitesucess==true && InsertDepensesucces == true)
                                            {
                                                ts.Complete();
                                             //   MessageBoxResult resultc1s = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées , Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                                            }
                                            else
                                            {
                                                MessageBoxResult resultc14 = Xceed.Wpf.Toolkit.MessageBox.Show(InsertDepensesucces.ToString()+UpdateVisitesucess.ToString()+DepaiemSucces.ToString()+ DepaiemtMultipleSucces.ToString(), Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                                            }
                                        }
                                            if (DepaiemtMultipleSucces == true && DepaiemSucces == true && UpdateVisitesucess == true && InsertDepensesucces == true)
                                            {
                                                proxy.AjouterTransactionPaiementRefresh();
                                                proxy.AjouterDepenseRefresh();
                                                proxy.AjouterSoldeVisiteRefresh(); MessageBoxResult resultc1s = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.OperationSuccées, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Information);

                                            }
                                         
                                        if (chImpressionRecuPatient.IsChecked == true)
                                        {
                                            List<SVC.Depeiment> listedepaiem = new List<SVC.Depeiment>();
                                            listedepaiem.Add(dpf);
                                            List<SVC.Visite> listevisite = new List<SVC.Visite>();
                                            listevisite.Add(VisiteApayer);
                                            ImpressionRecu cl = new ImpressionRecu(proxy, listedepaiem, listevisite);
                                            cl.Show();
                                        }
                                    } else
                                    {
                                        MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée+"  "+"Le montant saisie doit étre inferieur ou égale au total des restes", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

                                    }
                                }
                               
                               
                                    else
                                    {
                                        MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.Opérationéchouée, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                               
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                 MessageBoxResult resultc1 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
               // var result = MessageBox.Show(ex.InnerException.Message);
            }finally
            {
                WaitIndicatorS.DeferedVisibility = false;
                BACK.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void chDebit_Checked(object sender, RoutedEventArgs e)
        {
            try
            { 
            if (chDebit.IsChecked == true)
            {
                txtRubriqueMontantD.Visibility = Visibility.Collapsed;
                txtRubriqueMontant.Visibility = Visibility.Visible;
                txtRubriqueMontant.Text = txtRubriqueMontantD.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void chCredit_Checked(object sender, RoutedEventArgs e)
        {
            try
            { 
            if (chCredit.IsChecked == true)
            {
                txtRubriqueMontantD.Visibility = Visibility.Visible;
                txtRubriqueMontant.Visibility = Visibility.Collapsed;
                txtRubriqueMontantD.Text = txtRubriqueMontant.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void txtRubriqueMontantD_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.Tab:
                case Key.Decimal:


                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        private void BTNCLOSTE_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
