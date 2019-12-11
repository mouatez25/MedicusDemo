using DevExpress.Xpf.Core;
using Medicus.SVC;
using MahApps.Metro.Controls;
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

namespace Medicus.Administrateur
{
    /// <summary>
    /// Interaction logic for MainAdministrateur.xaml
    /// </summary>
    public partial class MainAdministrateur : UserControl
    {



        SVC.ServiceCliniqueClient proxy = null;
        SVC.Membership MemBerShip;
        SVC.Client localClient = null;
        string username;
        public ICallback callback;
        public event EventHandler AddEvent;
        
        //List<SVC.Client> ListeClients = new List<Client>();
        string titlesucce;
        Brush colortitle;
        bool connectionok = false;
        private delegate void FaultedInvoker();
        public MainAdministrateur(SVC.ServiceCliniqueClient proxyrecu,ICallback callbackrecu,SVC.Membership membershiprecu,SVC.Client clientrecu)
        {
            try
            {
                InitializeComponent();
                proxy = proxyrecu;
                callback = callbackrecu ;
                MemBerShip = membershiprecu;
                localClient = clientrecu;
            }

            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
         
         
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           try
            { 
           FrameInterieur.NavigationService.Navigate(new RendezVous(proxy,callback, MemBerShip));
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            try
            { 
            FrameInterieur.NavigationService.Navigate(new ListeSession(proxy,callback, MemBerShip));
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

     
    
      
        public bool authentification(SVC.ServiceCliniqueClient testproxy, string usernameTextbox)
        {

            var query = from c in testproxy.GetAllMembership()
                        select c;

            var results = query.ToList();
            var disponible = results.Where(list1 => list1.MotDePasse == usernameTextbox).FirstOrDefault();
            MemBerShip = disponible;
            if (disponible != null && disponible.Actif == true && disponible.ModuleAdministrateur==true)
            {
                MemBerShip = disponible;
                username = disponible.UserName;

                return true;

            }
            else
            {
                 ;
                 this.localClient = null;
                proxy.Close();
                return false;
            }

        }
       
        
         

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            try
            {
                proxy.DisconnectAsync(this.localClient);
            }catch(Exception ex)
            {

            }
           
          
        }

      

        private void spécialitemenu_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
           ListeSpécialitéMedecin CLSession = new ListeSpécialitéMedecin(proxy, MemBerShip, callback);

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Motifemenu_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            ListeMotifVisite CLSession = new ListeMotifVisite(proxy, MemBerShip, callback);

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void TyepCasemenu_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            ListeTypeCas CLSession = new ListeTypeCas(proxy, MemBerShip, callback);

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void BtnEntête_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            FrameInterieur.NavigationService.Navigate(new Entête(proxy, callback, MemBerShip));
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void ColorSalleAttente_Click(object sender, RoutedEventArgs e)
        {
            try

            { 
           ParamétreColor CLSession = new ParamétreColor(proxy, MemBerShip, callback);

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void MotifDepensemenu_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            
            ListMotifDepense CLSession = new ListMotifDepense(proxy, MemBerShip, callback);

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

      
       

       

        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
           ListeDesCatalogue CLSession = new ListeDesCatalogue(proxy, MemBerShip, callback);

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Acte_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            ListeActe CLSession = new ListeActe(proxy, MemBerShip, callback);

            CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Questionnaire_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnuser_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var imageBrush = (ImageBrush)btnuser.Background;
            imageBrush.Stretch = Stretch.Fill;
        }

        private void btnuser_MouseMove(object sender, MouseEventArgs e)
        {
            var imageBrush = (ImageBrush)btnuser.Background;
            imageBrush.Stretch = Stretch.Fill;
        }

        private void btnuser_MouseLeave(object sender, MouseEventArgs e)
        {
            var imageBrush = (ImageBrush)btnuser.Background;
            imageBrush.Stretch = Stretch.UniformToFill;
        }

        private void btnMdecin_MouseLeave(object sender, MouseEventArgs e)
        {
            var imageBrush = (ImageBrush)btnMdecin.Background;
            imageBrush.Stretch = Stretch.UniformToFill;
        }

        private void btnMdecin_MouseMove(object sender, MouseEventArgs e)
        {
            var imageBrush = (ImageBrush)btnMdecin.Background;
            imageBrush.Stretch = Stretch.Fill;
        }

        private void btnMdecin_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            var imageBrush = (ImageBrush)btnMdecin.Background;
            imageBrush.Stretch = Stretch.Fill;
        }

        private void BtnEntête_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            var imageBrush = (ImageBrush)BtnEntête.Background;
            imageBrush.Stretch = Stretch.Fill;
        }

        private void BtnEntête_MouseLeave(object sender, MouseEventArgs e)
        {
            var imageBrush = (ImageBrush)BtnEntête.Background;
            imageBrush.Stretch = Stretch.UniformToFill;
        }

        private void BtnEntête_MouseMove(object sender, MouseEventArgs e)
        {
            var imageBrush = (ImageBrush)BtnEntête.Background;
            imageBrush.Stretch = Stretch.Uniform;
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Authentification cl = new Authentification();
                cl.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void ParamOrdo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrdoParam CLSession = new OrdoParam(proxy, callback, MemBerShip);

                CLSession.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void quses_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DictionnaireListe CL = new DictionnaireListe(proxy, MemBerShip, callback);
                CL.Show();
            }
            catch (Exception ex)
            {
                MessageBoxResult resultc10 = Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message, Medicus.Properties.Resources.SiteWeb, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
