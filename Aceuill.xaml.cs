using DevExpress.Xpf.WindowsUI.Navigation;
using Medicus.Administrateur;
using Medicus.Patient;
using Medicus.RendezVous;
using Medicus.Stock;
using Medicus.SVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Medicus
{
    /// <summary>
    /// Interaction logic for Aceuill.xaml
    /// </summary>
    public partial class Aceuill : UserControl
    {
        SVC.ServiceCliniqueClient proxy;
        SVC.Membership memberuser;
        ICallback callback;
        private delegate void FaultedInvokerAceuill();
        DXWindowMain windowmain;
        SVC.Client localclient;
        public Aceuill(SVC.ServiceCliniqueClient proxyrecu, SVC.Membership memberrecu, ICallback callbackrecu, DXWindowMain windowrecu,SVC.Client localclientrecu)
        {
            try
            {

                InitializeComponent();
                proxy = proxyrecu;
                memberuser = memberrecu;
                callback = callbackrecu;
                windowmain = windowrecu;
                localclient = localclientrecu;
                if (localclientrecu.Chat)
                {
                    tile6.Visibility = Visibility.Visible;
                    tile6.IsEnabled = true;
                }
                else
                {
                    tile6.Visibility = Visibility.Collapsed;
                    tile6.IsEnabled = false;
                }
                

            }
            catch(Exception ex)
            {

            }
            }

        private void tile2_Click(object sender, EventArgs e)
        {
            try
            {

                windowmain.WaitIndicatorS.DeferedVisibility = true;

                if (memberuser.ModulePatient == true)
                {

                    windowmain.FrameInterieur.Navigate(new ListePatient(proxy,memberuser,callback,localclient));

                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
            finally
            {
                windowmain.WaitIndicatorS.DeferedVisibility = false;
                //  windowmain.BACK.Visibility = Visibility.Collapsed;
            }
        }

        private void tile3_Click(object sender, EventArgs e)
        {
            try
            {

                windowmain.WaitIndicatorS.DeferedVisibility = true;
                if (memberuser.ModuleCaisse == true)
                {
                 windowmain.FrameInterieur.Navigate(new Caisse.Caisse(proxy, memberuser, callback, localclient));

                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
            finally
            {
                windowmain.WaitIndicatorS.DeferedVisibility = false;
                // windowmain.BACK.Visibility = Visibility.Collapsed;
            }
        }

        private void tile4_Click(object sender, EventArgs e)
        {
            try
            {
                windowmain.WaitIndicatorS.DeferedVisibility = true;
                //  BACK.Visibility = Visibility.Visible;
                if (memberuser.ModuleRendezVous == true)
                {
                    windowmain.FrameInterieur.Navigate(new RendezVous.RendezVous(proxy,memberuser, callback));
                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
            finally
            {
                windowmain.WaitIndicatorS.DeferedVisibility = false;
                //     BACK.Visibility = Visibility.Collapsed;
            }
        }

        private void tile1_Click(object sender, EventArgs e)
        {
            try
            {

                if (memberuser.ModuleAdministrateur == true)
                {
                    windowmain.FrameInterieur.Navigate(new MainAdministrateur(proxy,  callback, memberuser, localclient));

                }
                else
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

        private void tile5_Click(object sender, EventArgs e)
        {
            try { 
            windowmain.WaitIndicatorS.DeferedVisibility = true;
            windowmain.BACK.Visibility = Visibility.Visible;
            if (memberuser.ModuleSalleAttente == true)
            {
                FileDattente.SalleDattente CLsalee = new FileDattente.SalleDattente(proxy, memberuser, callback, localclient);

                CLsalee.Show();
            }
            else
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
            windowmain.WaitIndicatorS.DeferedVisibility = false;
            windowmain.BACK.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void tile6_Click(object sender, EventArgs e)
        {
            try
            {
                
                    if (memberuser.ModuleChat == true)
                    {
                        windowmain.CL = new Chat(localclient, callback, proxy, windowmain, memberuser);
                        windowmain.ChatOpened = true;
                        windowmain.CL.Show();
                    }
                    else
                    {
                        MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

                    }
                
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);

            }
        }

       
        private void txtNomPatient_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            try { 
            if (txtNomPatient.Text.Trim() != "")
            {
                TxtCodePatient.IsEnabled = false;
            }
            else
            {
                if (txtNomPatient.Text.Trim() == "")
                {
                    TxtCodePatient.IsEnabled = true;
                }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void txtNomPatient_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtNomPatient.Text != "")
                {
                    if (e.Key != System.Windows.Input.Key.Enter) return;

                    // your event handler here
                    e.Handled = true;
                    List<SVC.Patient> tte = (proxy.GetAllPatientPAR(txtNomPatient.Text.ToUpper().Trim())).ToList();

                    if (tte.Count() != 0)
                    {
                        if (memberuser.ModulePatient == true)
                        {
                            ListePatientHome ch = new ListePatientHome(proxy, memberuser, callback, tte,localclient);
                            ch.Show();
                        }
                        else
                        {
                            MessageBoxResult results = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
                            if (results == MessageBoxResult.OK)
                            {
                                txtNomPatient.Text = "";
                            }
                        }
                    }
                    else
                    {
                        MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Patient n'existe pas" + "\n" + "voulez vous créer un patient ? ", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            if (memberuser.CréationPatient == true)
                            {
                                NewPatient CLMedecin = new NewPatient(proxy, memberuser, null);
                                CLMedecin.Show();

                            }
                            else
                            {
                                MessageBoxResult results = Xceed.Wpf.Toolkit.MessageBox.Show(Medicus.Properties.Resources.MessageBoxPrivilége, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
                                if (results == MessageBoxResult.OK)
                                {
                                    txtNomPatient.Text = "";
                                }
                            }

                        }
                        else
                        {
                            txtNomPatient.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtCodePatient_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            try
            {
                if (TxtCodePatient.Text.Trim() != "")
                {
                    txtNomPatient.IsEnabled = false;
                }
                else
                {
                    if (TxtCodePatient.Text.Trim() == "")
                    {
                        txtNomPatient.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void TxtCodePatient_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (TxtCodePatient.Text != "")
                {
                    if (e.Key != System.Windows.Input.Key.Enter) return;

                    // your event handler here
                    e.Handled = true;
                    List<SVC.Patient> tte = (proxy.GetAllPatient()).Where(n => n.Id == Convert.ToInt16(TxtCodePatient.Text)).ToList();

                    if (tte.Count() != 0)
                    {
                        if (memberuser.ModulePatient == true)
                        {
                            ListePatientHome ch = new ListePatientHome(proxy, memberuser, callback, tte, localclient);
                            ch.Show();
                        }
                        else
                        {
                            MessageBoxResult results = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", "Medicus", MessageBoxButton.OK, MessageBoxImage.Stop);
                            if (results == MessageBoxResult.OK)
                            {
                                TxtCodePatient.Text = "";
                            }
                        }
                    }
                    else
                    {
                        MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Patient n'existe pas" + "\n" + "voulez vous créer un patient ? ", Medicus.Properties.Resources.SiteWeb, MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            if (memberuser.CréationPatient == true)
                            {
                                NewPatient CLMedecin = new NewPatient(proxy, memberuser, null);
                                CLMedecin.Show();

                            }
                            else
                            {
                                MessageBoxResult results = Xceed.Wpf.Toolkit.MessageBox.Show("vous devez avoir une autorisation pour effectuer cette action", Medicus.Properties.Resources.SiteWeb
                                    , MessageBoxButton.OK, MessageBoxImage.Stop);
                                if (results == MessageBoxResult.OK)
                                {
                                    TxtCodePatient.Text = "";
                                }
                            }

                        }
                        else
                        {
                            TxtCodePatient.Text = "";
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


        private void TxtCodePatient_KeyDown(object sender, KeyEventArgs e)
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
          


                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }
    }
}
