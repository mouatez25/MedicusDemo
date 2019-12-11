using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicus.SVC;
using System.ServiceModel;

namespace Medicus.Administrateur
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public  class ICallback : IServiceCliniqueCallback
    {
        #region Delegates

        public delegate void CallbackEventHandler(object source, CallbackEvent e);
        public delegate void CallbackEventHandler1(object source, CallbackEventJoin e);
        public delegate void CallbackEventHandler2(object source, CallbackEventUserLeave e);
        public delegate void CallbackEventHandler3(object source, CallbackEventMessageRecu e);
        public delegate void CallbackEventHandler4(object source, CallbackEventWriting e);

        public delegate void CallbackEventHandler5(object source, CallbackEventInsertMembership e);
        public delegate void CallbackEventHandler6(object source, CallbackEventInsertMedecin e);
        public delegate void CallbackEventHandler7(object source, CallbackEventInsertPatient e);
        public delegate void CallbackEventHandler8(object source, CallbackEventInsertRendezVous e);
        public delegate void CallbackEventHandler9(object source, CallbackEventInsertSpécialité e);
        public delegate void CallbackEventHandler10(object source, CallbackEventInsertMotifVisite e);
        public delegate void CallbackEventHandler11(object source, CallbackEventInsertTypeCas e);
        public delegate void CallbackEventHandler12(object source, CallbackEventInsertCasTraitement e);
        public delegate void CallbackEventHandler13(object source, CallbackEventInsertVisite e);
        public delegate void CallbackEventHandler14(object source, CallbackEventInsertConstante e);
        public delegate void CallbackEventHandler15(object source, CallbackEventInsertDicomFichier e);
        public delegate void CallbackEventHandler16(object source, CallbackEventInsertParam e);
        public delegate void CallbackEventHandler17(object source, CallbackEventInsertSalleDattente e);
        public delegate void CallbackEventHandler18(object source, CallbackEventInsertDepense e);
        public delegate void CallbackEventHandler19(object source, CallbackEventInsertMotifDepense e);
      
        public delegate void CallbackEventHandler27(object source, CallbackEventSalleAttenteDemandeChezLeMedecin e);
        public delegate void CallbackEventHandler32(object source, CallbackEventInsertDepeiment e);
        public delegate void CallbackEventHandler33(object source, CallbackEventInsertDci e);
        public delegate void CallbackEventHandler34(object source, CallbackEventInsertCatalogue e);
        public delegate void CallbackEventHandler35(object source, CallbackEventInsertActe e);
        public delegate void CallbackEventHandler36(object source, CallbackEventInsertProduitOrdonnance e);
        public delegate void CallbackEventHandler37(object source, CallbackEventInsertEnteteOrdonnace e);
        public delegate void CallbackEventHandler38(object source, CallbackEventInsertOrdonnancePatient e);
        public delegate void CallbackEventHandler42(object source, CallbackEventInsertDiagnostic e);
        public delegate void CallbackEventHandler47(object source, CallbackEventReceiveFile e);
        public delegate void CallbackEventHandler48(object source, CallbackEventReceiveWhisper e);
        public delegate void CallbackEventHandler49(object source, CallbackEventInsertDepeiementMultiple e);
      
        public delegate void CallbackEventHandler57(object source, CallbackEventInsertArretDetravail e);
        public delegate void CallbackEventHandler56(object source, CallbackEventInsertDictionnaire e);
        //   public List<SVC.Client> OnlineClients = new List<SVC.Client>();


        //   public abstract void RefreshClients(List<Client> clients);
        public void RefreshClients(List<Client> clients)
        {
            fireCallbackEvent(clients);

        }
        public void UserJoin(Client client)
        {
            UserJoined(client);
        }
        public void UserLeave(Client client)
        {
            UserLeaved(client);
        }
        public void Receive(Message msg)
        {
            ReceivedMessage(msg);
        }
        public void IsWritingCallback(Client client)
        {
            UserWrite(client);
        }
        public void RefreshMembership(List<Membership> membership)
        {
            CallbackInsertMembership(membership);
        }
        public void RefreshMedecin(List<Medecin> medecin)
        {
            CallbackInsertMedecin(medecin);
        }
        public void RefreshPatient(SVC.Patient medecin,int oper)
        {
            CallbackInsertPatient(medecin,oper);

        }
        public void RefreshRendezVous(RendezVou medecin,int oper)
        {
            CallbackInsertRendezVous(medecin,oper);
        }
        public void RefreshSpécialité(List<Spécialité> medecin)
        {
            CallbackInsertSpécialtié(medecin);
        }
        public void RefreshMotifVisite(List<MotifVisite> medecin)
        {
            CallbackInsertMotifVisite(medecin);
        }
        public void RefreshTypeCas(List<TypeCa> medecin)
        {
            CallbackInsertTypeCas(medecin);
        }
        public void RefreshCasTraitement(List<CasTraitement> medecin)
        {
            CallbackInsertCasTraitement(medecin);
        }
        public void RefreshVisite(Visite medecin,int oper)
        {
            CallbackVisite(medecin,oper);
        }
        public void RefreshConstante(List<Constante> medecin)
        {
            CallbackConstante(medecin);
        }
        public void RefreshDicom(List<DicomFichier> medecin)
        {
            CallbackDicomFichier(medecin);
            }
              public void RefreshParametre(Param medecin)
        {
            CallbackParam(medecin);
        }
        public void RefreshSalleDattente(SalleDattente medecin,int oper)
        {
            CallbackSalleDattente(medecin,oper);
        }
        public void RefreshMotifDepense(List<MotifDepense> medecin)
        {
            CallbackRefreshMotifDepense(medecin);
        }
        public void RefreshDepense(Depense medecin,int oper)
        {
            CallbackRefreshDepense(medecin,oper);
        }
       
        public void RefreshArretDetravails(List<ArretDetravail> clients)
        {
            CallbackRefreshArretDetravail(clients);
        }
       
       
      
       
        public void RefreshEcranAcceuil(SVC.Patient medecin,SVC.SalleDattente salle)
        {
            CallbackRefreshEcranAcceuil(medecin,salle);
        }
      
       
        public void RefreshDepeiment(Depeiment medecin,int oper)
        {
            CallbackRefreshDepeiment(medecin,oper);
        }
        public void RefreshDci(List<Dci> medecin)
        {
            CallbackRefreshDci(medecin);
        }

        public void RefreshActe(List<Acte> medecin)
        {
            CallbackRefreshActe(medecin);
        }
        public void RefreshCatalogue(List<Catalogue> medecin)
        {
            CallbackRefreshCatalogue(medecin);
        }
        public void RefreshProduitOrdonnance(ProduitOrdonnance medecin,int oper)
        {
            CallbackRefreshProduitOrdonnance(medecin,oper);
        }

        public void RefreshEnteteOrdonnace(List<EnteteOrdonnace> medecin)
        {
            CallbackRefreshEnteteOrdonnace(medecin);
        }



        public void RefreshOrdonnancePatient(List<OrdonnancePatient> medecin)
        {
            CallbackRefreshOrdonnancePatient(medecin);
        }
      
     
        public void RefreshDiagnostic(List<Diagnostic> medecin)
        {
            CallbackRefreshDiagnostic(medecin);
        }
    
        
        public void ReceiverFile(FileMessage fileMsg, Client receiver)
        {
            CallbackRefreshReceiveFile(fileMsg,receiver);
        }
        public void ReceiveWhisper(Message msg, Client receiver)
        {
            CallbackRefreshReceiveWhisper(msg, receiver);

        }
        public void RefreshDepeimentMultiple(List<DepeiementMultiple> medecin)
        {
            CallbackRefreshDepeiementMultiple(medecin);
        }
        
        public void RefreshDictionnaire(List<Dictionnaire> medecin)
        {
            CallbackRefreshDictionnaire(medecin);
        }

        public event CallbackEventHandler callback;
        public event CallbackEventHandler1 callbackUserjoin;
        public event CallbackEventHandler2 callbackUserLeave;
        public event CallbackEventHandler3 callbackMessageRecu;
        public event CallbackEventHandler4 IsWritingCallbackEvent;
        public event CallbackEventHandler5 InsertMmebershipCallbackEvent;
        public event CallbackEventHandler6 InsertMedecinCallbackEvent;
        public event CallbackEventHandler7 InsertPatientCallbackEvent;
        public event CallbackEventHandler8 InsertRendezVousCallbackEvent;
        public event CallbackEventHandler9 InsertSpécialitéCallbackEvent;
        public event CallbackEventHandler10 InsertMotifVisiteCallbackEvent;
        public event CallbackEventHandler11 InsertTypeCasCallbackEvent;
        public event CallbackEventHandler12 InsertCasTraitementCallbackEvent;
        public event CallbackEventHandler13 InsertVisiteCallbackEvent;
        public event CallbackEventHandler14 InsertConstanteCallbackEvent;
        public event CallbackEventHandler15 InsertDicomFichierCallbackEvent;
        public event CallbackEventHandler16 InsertParamCallbackEvent;
        public event CallbackEventHandler17 InsertSalleDattenteCallbackEvent;
        public event CallbackEventHandler18 InsertDepenseCallbackEvent;
        public event CallbackEventHandler19 InsertMotifDepenseCallbackEvent;
      
        public event CallbackEventHandler27 InsertamCallbackEcranSalleAttente;

        public event CallbackEventHandler32 InsertDepaiemCallbackevent;
        public event CallbackEventHandler33 InsertDciCallbackevent;
        public event CallbackEventHandler34 InsertCatalogueCallbackevent;
        public event CallbackEventHandler35 InsertActeCallbackevent;
        public event CallbackEventHandler36 InsertProduitOrdonnanceCallbackevent;
        public event CallbackEventHandler37 InsertEnteteOrdonnaceCallbackevent;
        public event CallbackEventHandler38 InsertOrdonnancePatientCallbackevent;
  
        public event CallbackEventHandler42 InsertDiagnosticCallbackevent;
 
        public event CallbackEventHandler47 InsertReceiveFileCallbackevent;
        public event CallbackEventHandler48 InsertReceiveWhisperCallbackevent;
        public event CallbackEventHandler49 InsertDepeiementMultipleCallbackevent;
      
   
       
        public event CallbackEventHandler57 InsertArretDetravailCallbackevent;
      
        public event CallbackEventHandler56 InsertDictionnaireCallbackevent;

        private void CallbackRefreshDictionnaire(List<Dictionnaire> medecin)
        {
            if (InsertDictionnaireCallbackevent != null)
            {
                InsertDictionnaireCallbackevent(this, new CallbackEventInsertDictionnaire(medecin));
            }
        }
        private void CallbackRefreshArretDetravail(List<ArretDetravail> medecin)
        {
            if (InsertArretDetravailCallbackevent != null)
            {
                InsertArretDetravailCallbackevent(this, new CallbackEventInsertArretDetravail(medecin));
            }
        }
       
       
        private void CallbackRefreshDepeiementMultiple(List<DepeiementMultiple> clients)
        {
            if (InsertDepeiementMultipleCallbackevent != null)
            {
                InsertDepeiementMultipleCallbackevent(this, new CallbackEventInsertDepeiementMultiple(clients));
            }
        }

        private void CallbackRefreshReceiveWhisper(SVC.Message clients, Client receiver)
        {
            if (InsertReceiveWhisperCallbackevent != null)
            {
                InsertReceiveWhisperCallbackevent(this, new CallbackEventReceiveWhisper(clients, receiver));
            }
        }
        private void CallbackRefreshReceiveFile(FileMessage clients,Client receiver)
        {
            if (InsertReceiveFileCallbackevent!=null)
            {
                InsertReceiveFileCallbackevent(this, new CallbackEventReceiveFile(clients,receiver));
            }
        }
        private void fireCallbackEvent(List<Client> clients)
        {
            if (callback != null)
            {
                callback(this, new CallbackEvent(clients));
            }
        }
        private void UserJoined(Client client)
        {
            if (callbackUserjoin != null)
            {
                callbackUserjoin(this, new CallbackEventJoin(client));
            }
        }
        private void UserLeaved(Client client)
        {
            if (callbackUserLeave != null)
            {
                callbackUserLeave(this, new CallbackEventUserLeave(client));
            }
        }
       
             private void UserWrite(Client client)
        {
            if (IsWritingCallbackEvent != null)
            {
                IsWritingCallbackEvent(this, new CallbackEventWriting(client));
            }
        }
        private void ReceivedMessage(Message msg)
        {
            if (callbackMessageRecu != null)
            {
                callbackMessageRecu(this, new CallbackEventMessageRecu(msg));
            }

        }

        private void CallbackInsertMembership(List<Membership> listMembership)
        {
            if (InsertMmebershipCallbackEvent != null)
            {
                InsertMmebershipCallbackEvent(this, new CallbackEventInsertMembership(listMembership));
            }

        }

        private void CallbackInsertMedecin(List<Medecin> listMembership)
        {
            if (InsertMedecinCallbackEvent != null)
            {
                InsertMedecinCallbackEvent(this, new CallbackEventInsertMedecin(listMembership));
            }

        }
        private void CallbackInsertPatient(SVC.Patient listMembership,int oper)
        {
            if (InsertPatientCallbackEvent != null)
            {
                InsertPatientCallbackEvent(this, new CallbackEventInsertPatient(listMembership,oper));
            }

        }
        private void CallbackInsertRendezVous(SVC.RendezVou listMembership,int oper)
        {
            if (InsertRendezVousCallbackEvent != null)
            {
                InsertRendezVousCallbackEvent(this, new CallbackEventInsertRendezVous(listMembership,oper));
            }

        }
        private void CallbackInsertSpécialtié(List<SVC.Spécialité> listMembership)
        {
            if (InsertSpécialitéCallbackEvent != null)
            {
                InsertSpécialitéCallbackEvent(this, new CallbackEventInsertSpécialité(listMembership));
            }

        }

        private void CallbackInsertMotifVisite(List<SVC.MotifVisite> listMembership)
        {
            if (InsertMotifVisiteCallbackEvent != null)
            {
                InsertMotifVisiteCallbackEvent(this, new CallbackEventInsertMotifVisite(listMembership));
            }

        }
        private void CallbackInsertTypeCas(List<SVC.TypeCa> listMembership)
        {
            if (InsertTypeCasCallbackEvent != null)
            {
                InsertTypeCasCallbackEvent(this, new CallbackEventInsertTypeCas(listMembership));
            }

        }

        private void CallbackInsertCasTraitement(List<SVC.CasTraitement> listMembership)
        {
            if (InsertCasTraitementCallbackEvent != null)
            {
                InsertCasTraitementCallbackEvent(this, new CallbackEventInsertCasTraitement(listMembership));
            }

        }

        private void CallbackVisite(SVC.Visite listMembership,int oper)
        {
            if (InsertVisiteCallbackEvent != null)
            {
                InsertVisiteCallbackEvent(this, new CallbackEventInsertVisite(listMembership,oper));
            }

        }
        private void CallbackConstante(List<SVC.Constante> listMembership)
        {
            if (InsertConstanteCallbackEvent != null)
            {
                InsertConstanteCallbackEvent(this, new CallbackEventInsertConstante(listMembership));
            }
           
        }
        private void CallbackDicomFichier(List<SVC.DicomFichier> listMembership)
        {
            if (InsertConstanteCallbackEvent != null)
            {
                InsertDicomFichierCallbackEvent(this, new CallbackEventInsertDicomFichier(listMembership));
            }
        }
        private void CallbackParam(Param listMembership)
        {

            if (InsertParamCallbackEvent != null)
            {
                InsertParamCallbackEvent(this, new CallbackEventInsertParam(listMembership));
            }
        }
        private void CallbackSalleDattente(SalleDattente listMembership,int oper)
        {

            if (InsertSalleDattenteCallbackEvent != null)
            {
                InsertSalleDattenteCallbackEvent(this, new CallbackEventInsertSalleDattente(listMembership,oper));
            }
        }
        private void CallbackRefreshDepense(Depense listMembership,int oper)
        {

            if (InsertDepenseCallbackEvent != null)
            {
                InsertDepenseCallbackEvent(this, new CallbackEventInsertDepense(listMembership,oper));
            }
        }


            private void CallbackRefreshMotifDepense(List<MotifDepense> listMembership)
        {

            if (InsertMotifDepenseCallbackEvent != null)
            {
                InsertMotifDepenseCallbackEvent(this, new CallbackEventInsertMotifDepense(listMembership));
            }
        }

    

    
      

        private void CallbackRefreshEcranAcceuil(SVC.Patient listMembership,SVC.SalleDattente sallelist)
        {

            if (InsertamCallbackEcranSalleAttente != null)
            {
                InsertamCallbackEcranSalleAttente(this, new CallbackEventSalleAttenteDemandeChezLeMedecin(listMembership,sallelist));
            }
        }
      
     

    

       
      private void CallbackRefreshDepeiment(Depeiment listMembership,int oper)
        {

            if (InsertDepaiemCallbackevent != null)
            {
                InsertDepaiemCallbackevent(this, new CallbackEventInsertDepeiment(listMembership,oper));
            }
        }

        private void CallbackRefreshDci(List<Dci> listMembership)
        {

            if (InsertDciCallbackevent != null)
            {
                InsertDciCallbackevent(this, new CallbackEventInsertDci(listMembership));
            }
        }
        private void CallbackRefreshCatalogue(List<Catalogue> listMembership)
        {

            if (InsertCatalogueCallbackevent != null)
            {
                InsertCatalogueCallbackevent(this, new CallbackEventInsertCatalogue(listMembership));
            }
        }
        private void CallbackRefreshActe(List<Acte> listMembership)
        {

            if (InsertActeCallbackevent != null)
            {
                InsertActeCallbackevent(this, new CallbackEventInsertActe(listMembership));
            }
        }//InsertProduitOrdonnanceCallbackevent

        private void CallbackRefreshProduitOrdonnance(ProduitOrdonnance listMembership,int oper)
        {

            if (InsertProduitOrdonnanceCallbackevent != null)
            {
                InsertProduitOrdonnanceCallbackevent(this, new CallbackEventInsertProduitOrdonnance(listMembership,oper));
            }
        }
        private void CallbackRefreshEnteteOrdonnace(List<EnteteOrdonnace> listMembership)
        {

            if (InsertEnteteOrdonnaceCallbackevent != null)
            {
                InsertEnteteOrdonnaceCallbackevent(this, new CallbackEventInsertEnteteOrdonnace(listMembership));
            }
        }

        private void CallbackRefreshOrdonnancePatient(List<OrdonnancePatient> listMembership)
        {

            if (InsertOrdonnancePatientCallbackevent != null)
            {
                InsertOrdonnancePatientCallbackevent(this, new CallbackEventInsertOrdonnancePatient(listMembership));
            }
        }
     
     
        private void CallbackRefreshDiagnostic(List<Diagnostic> listMembership)
        {

            if (InsertDiagnosticCallbackevent != null)
            {
                InsertDiagnosticCallbackevent(this, new CallbackEventInsertDiagnostic(listMembership));
            }
        }

      
        /**************************************************************************************************/
        public IAsyncResult BeginIsWritingCallback(Client client, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReceive(Message msg, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();

        }

        public IAsyncResult BeginReceiverFile(FileMessage fileMsg, Client receiver, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReceiveWhisper(Message msg, Client receiver, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRefreshClients(List<Client> clients, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRefreshClientsChat(List<Client> clients, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUserJoin(Client client, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUserLeave(Client client, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndIsWritingCallback(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndReceive(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndReceiverFile(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndReceiveWhisper(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshClients(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshClientsChat(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndUserJoin(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndUserLeave(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       

      

      

     

       

        public IAsyncResult BeginRefreshMembership(List<Membership> membership, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshMembership(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        

        public IAsyncResult BeginRefreshMedecin(List<Medecin> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshMedecin(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      

        public IAsyncResult BeginRefreshPatient(List<SVC.Patient> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshPatient(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       
        public IAsyncResult BeginRefreshRendezVous(List<RendezVou> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshRendezVous(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      

        public IAsyncResult BeginRefreshSpécialité(List<Spécialité> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshSpécialité(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      

        public IAsyncResult BeginRefreshMotifVisite(List<MotifVisite> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshMotifVisite(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       

        public IAsyncResult BeginRefreshTypeCas(List<TypeCa> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshTypeCas(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

   
        public IAsyncResult BeginRefreshCasTraitement(List<CasTraitement> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshCasTraitement(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        

        public IAsyncResult BeginRefreshVisite(List<Visite> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshVisite(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      

        public IAsyncResult BeginRefreshConstante(List<Constante> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshConstante(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      

        public IAsyncResult BeginRefreshDicom(List<DicomFichier> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshDicom(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      

        public IAsyncResult BeginRefreshParametre(Param medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshParametre(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      

        public IAsyncResult BeginRefreshSalleDattente(List<SalleDattente> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshSalleDattente(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

     

        public IAsyncResult BeginRefreshDepense(List<Depense> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshDepense(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       
        public IAsyncResult BeginRefreshMotifDepense(List<MotifDepense> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshMotifDepense(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       
        public void EndRefreshFourn(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      
        public void EndRefreshProduit(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        
        public void EndRefreshProdf(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        
        public void EndRefreshRecouf(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        
        public void EndRefreshRecept(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      
        public void EndRefreshdepaief(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        
        public void EndRefresham(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

    

    

        public void EndRefreshEcranAcceuil(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRefreshEcranAcceuil(SVC.Patient medecin, SalleDattente selectPatientSalle, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }
        
        public void EndRefreshFamilleAliment(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        
        public void EndRefreshAliment(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       
        public void EndRefreshBesoinCalorique(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        
        public void EndRefreshRepa(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      

        public IAsyncResult BeginRefreshDepeiment(List<Depeiment> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshDepeiment(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       

        public IAsyncResult BeginRefreshDci(List<Dci> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshDci(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      

        public IAsyncResult BeginRefreshCatalogue(List<Catalogue> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshCatalogue(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      
        public IAsyncResult BeginRefreshActe(List<Acte> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshActe(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      

        public IAsyncResult BeginRefreshProduitOrdonnance(List<ProduitOrdonnance> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshProduitOrdonnance(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      
        public IAsyncResult BeginRefreshOrdonnancePatient(List<OrdonnancePatient> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshOrdonnancePatient(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

  
        public IAsyncResult BeginRefreshEnteteOrdonnace(List<EnteteOrdonnace> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshEnteteOrdonnace(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       
      

        public void EndRefreshEtatDent(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       

       

        public void EndRefreshBouche(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       
       
        public void EndRefreshQuestionnaire(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       

        public IAsyncResult BeginRefreshDiagnostic(List<Diagnostic> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshDiagnostic(IAsyncResult result)
        {
            throw new NotImplementedException();
        }



     

        public void EndRefreshRéponseGuidé(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

    
      

        public void EndRefreshTypeDeProthése(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

     

       

        public void EndRefreshSousTypeProthèse(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

   
        

        public void EndRefreshLaboratoire(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

     

     

        public void EndRefreshLaboProthèseCommande(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       

        public IAsyncResult BeginRefreshDepeimentMultiple(List<DepeiementMultiple> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshDepeimentMultiple(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        
        public void EndRefreshautosurveillance(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

     

       
        public void EndRefreshautosurveillanceDetail(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRefreshPatient(SVC.Patient medecin, int patient, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRefreshRendezVous(RendezVou medecin, int opertype, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRefreshDepense(Depense medecin, int oper, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRefreshVisite(Visite medecin, int oper, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRefreshSalleDattente(SalleDattente medecin, int oper, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

   
       
        public void EndRefreshProdfRecept(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRefreshDepeiment(Depeiment medecin, int oper, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRefreshProduitOrdonnance(ProduitOrdonnance medecin, int oper, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

      

        public IAsyncResult BeginRefreshArretDetravails(List<ArretDetravail> clients, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshArretDetravails(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       

       
        public void EndRefreshFamilleProduit(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

       

        public IAsyncResult BeginRefreshDictionnaire(List<Dictionnaire> medecin, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndRefreshDictionnaire(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      
    }


    public class CallbackEvent : EventArgs
    {
        private readonly List<Client> clientss;
        public CallbackEvent(List<Client> clients)
        {
            this.clientss = clients;
        }
        public List<Client> clients
        {
            get { return clientss; }
        }
    }

    public class CallbackEventJoin : EventArgs
    {
        private readonly Client clientss;
        public CallbackEventJoin(Client clientsjoin)
        {
            this.clientss = clientsjoin;
        }
        public Client clientsj
        {
            get { return clientss; }
        }
    }
    public class CallbackEventUserLeave : EventArgs
    {
        private readonly Client clientsss;
        public CallbackEventUserLeave(Client clientsjoin)
        {
            this.clientsss = clientsjoin;
        }
        public Client clientleav
        {
            get { return clientsss; }
        }
    }
    public class CallbackEventMessageRecu : EventArgs
    {
        private readonly Message Messagesss;
        public CallbackEventMessageRecu(Message clientsjoin)
        {
            this.Messagesss = clientsjoin;
        }
        public Message clientleav
        {
            get { return Messagesss; }
        }
    }

    public class CallbackEventWriting : EventArgs
    {
        private readonly Client clientsssEcrit;
        public CallbackEventWriting(Client clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public Client clientleav
        {
            get { return clientsssEcrit; }
        }
    }


    public class CallbackEventInsertMembership : EventArgs
    {
        private readonly List<Membership> clientsssEcrit;
        public CallbackEventInsertMembership(List<Membership> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<Membership> clientleav
        {
            get { return clientsssEcrit; }
        }
    }

    public class CallbackEventInsertMedecin : EventArgs
    {
        private readonly List<Medecin> clientsssEcrit;
        public CallbackEventInsertMedecin(List<Medecin> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<Medecin> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
    public class CallbackEventInsertPatient : EventArgs
    {
        private readonly SVC.Patient clientsssEcrit;
        private readonly int opersssEcrit;
        public CallbackEventInsertPatient(SVC.Patient clientsjoin, int oper)
        {
            this.clientsssEcrit = clientsjoin;
            this.opersssEcrit = oper;
        }
        public SVC.Patient clientleav
        {
            get { return clientsssEcrit; }
        }
        public int operleav
        {
            get { return opersssEcrit; }
        }
    }
    public class CallbackEventInsertRendezVous : EventArgs
    {
        private readonly RendezVou clientsssEcrit;
        private readonly int opersssEcrit;
        public CallbackEventInsertRendezVous(SVC.RendezVou clientsjoin, int oper)
        {
            this.clientsssEcrit = clientsjoin;
            this.opersssEcrit = oper;
        }
        public RendezVou clientleav
        {
            get { return clientsssEcrit; }
        }
        public int operleav
        {
            get { return opersssEcrit; }
        }
    }
    public class CallbackEventInsertSpécialité : EventArgs
    {
        private readonly List<SVC.Spécialité> clientsssEcrit;
        public CallbackEventInsertSpécialité(List<SVC.Spécialité> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<SVC.Spécialité> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
    public class CallbackEventInsertMotifVisite : EventArgs
    {
        private readonly List<SVC.MotifVisite> clientsssEcrit;
        public CallbackEventInsertMotifVisite(List<SVC.MotifVisite> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<SVC.MotifVisite> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
    public class CallbackEventInsertTypeCas : EventArgs
    {
        private readonly List<SVC.TypeCa> clientsssEcrit;
        public CallbackEventInsertTypeCas(List<SVC.TypeCa> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<SVC.TypeCa> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
    public class CallbackEventInsertCasTraitement : EventArgs
    {
        private readonly List<SVC.CasTraitement> clientsssEcrit;
        public CallbackEventInsertCasTraitement(List<SVC.CasTraitement> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<SVC.CasTraitement> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
    public class CallbackEventInsertVisite : EventArgs
    {
        private readonly SVC.Visite clientsssEcrit;
        private readonly int opersssEcrit;
        public CallbackEventInsertVisite(SVC.Visite clientsjoin, int oper)
        {
            this.clientsssEcrit = clientsjoin;
            this.opersssEcrit = oper;
        }
        public SVC.Visite clientleav
        {
            get { return clientsssEcrit; }
        }
        public int operleav
        {
            get { return opersssEcrit; }
        }
    }

    public class CallbackEventInsertConstante : EventArgs
    {
        private readonly List<SVC.Constante> clientsssEcrit;
        public CallbackEventInsertConstante(List<SVC.Constante> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<SVC.Constante> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
    public class CallbackEventInsertDicomFichier : EventArgs
    {
        private readonly List<SVC.DicomFichier> clientsssEcrit;
        public CallbackEventInsertDicomFichier(List<SVC.DicomFichier> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<SVC.DicomFichier> clientleav
        {
            get { return clientsssEcrit; }
        }
    }

    /*  public class CallbackEventInsertParam : EventArgs
      {
          private readonly List<SVC.Param> clientsssEcrit;
          public CallbackEventInsertParam(List<SVC.Param> clientsjoin)
          {
              this.clientsssEcrit = clientsjoin;
          }
          public List<SVC.Param> clientleav
          {
              get { return clientsssEcrit; }
          }
      }*/

    public class CallbackEventInsertParam : EventArgs
    {
        private readonly SVC.Param clientsssEcrit;
        public CallbackEventInsertParam(Param clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public Param clientleav
        {
            get { return clientsssEcrit; }
        }
    }

    public class CallbackEventInsertSalleDattente : EventArgs
    {
        private readonly SalleDattente clientsssEcrit;
        private readonly int opersssEcrit;
        public CallbackEventInsertSalleDattente(SalleDattente clientsjoin, int oper)
        {
            this.clientsssEcrit = clientsjoin;
            this.opersssEcrit = oper;
        }
        public SalleDattente clientleav
        {
            get { return clientsssEcrit; }
        }
        public int operleav
        {
            get { return opersssEcrit; }
        }
    }
    public class CallbackEventInsertDepense : EventArgs
    {
        private readonly Depense clientsssEcrit;
        private readonly int operssEcrit;
        public CallbackEventInsertDepense(Depense clientsjoin, int oper)
        {
            this.clientsssEcrit = clientsjoin;
            this.operssEcrit = oper;
        }
        public Depense clientleav
        {
            get { return clientsssEcrit; }
        }
        public int operleav
        {
            get { return operssEcrit; }
        }
    }
    public class CallbackEventInsertMotifDepense : EventArgs
    {
        private readonly List<MotifDepense> clientsssEcrit;
        public CallbackEventInsertMotifDepense(List<MotifDepense> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<MotifDepense> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
   
    
   
 
    public class CallbackEventSalleAttenteDemandeChezLeMedecin : EventArgs
    {
        private readonly SVC.Patient clientsssEcrit;
        private readonly SVC.SalleDattente clientsssEcritattente;
        public CallbackEventSalleAttenteDemandeChezLeMedecin(SVC.Patient clientsjoin, SVC.SalleDattente salleP)
        {
            this.clientsssEcrit = clientsjoin;
            this.clientsssEcritattente = salleP;
        }
        public SVC.Patient clientleav
        {
            get { return clientsssEcrit; }
        }
        public SVC.SalleDattente clientleavSall
        {
            get { return clientsssEcritattente; }
        }
    }



    public class CallbackEventInsertDepeiment : EventArgs
    {
        private readonly Depeiment clientsssEcrit;
        private readonly int operssEcrit;
        public CallbackEventInsertDepeiment(Depeiment clientsjoin, int oper)
        {
            this.clientsssEcrit = clientsjoin;
            this.operssEcrit = oper;
        }
        public Depeiment clientleav
        {
            get { return clientsssEcrit; }
        }
        public int operleav
        {
            get { return operssEcrit; }
        }
    }
    public class CallbackEventInsertDci : EventArgs
    {
        private readonly List<Dci> clientsssEcrit;
        public CallbackEventInsertDci(List<Dci> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<Dci> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
    public class CallbackEventInsertCatalogue : EventArgs
    {
        private readonly List<Catalogue> clientsssEcrit;
        public CallbackEventInsertCatalogue(List<Catalogue> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<Catalogue> clientleav
        {
            get { return clientsssEcrit; }
        }
    }

    public class CallbackEventInsertActe : EventArgs
    {
        private readonly List<Acte> clientsssEcrit;
        public CallbackEventInsertActe(List<Acte> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<Acte> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
    
    public class CallbackEventInsertProduitOrdonnance : EventArgs
    {
        private readonly ProduitOrdonnance clientsssEcrit;
        private readonly int opersssEcrit;
        public CallbackEventInsertProduitOrdonnance(ProduitOrdonnance clientsjoin, int oper)
        {
            this.clientsssEcrit = clientsjoin;
            this.opersssEcrit = oper;
        }
        public ProduitOrdonnance clientleav
        {
            get { return clientsssEcrit; }
        }
        public int operleav
        {
            get { return opersssEcrit; }
        }
    }

    public class CallbackEventInsertEnteteOrdonnace : EventArgs
    {
        private readonly List<EnteteOrdonnace> clientsssEcrit;
        public CallbackEventInsertEnteteOrdonnace(List<EnteteOrdonnace> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<EnteteOrdonnace> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
    public class CallbackEventInsertOrdonnancePatient : EventArgs
    {
        private readonly List<OrdonnancePatient> clientsssEcrit;
        public CallbackEventInsertOrdonnancePatient(List<OrdonnancePatient> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<OrdonnancePatient> clientleav
        {
            get { return clientsssEcrit; }
        }
    }



    public class CallbackEventInsertDiagnostic : EventArgs
    {
        private readonly List<Diagnostic> clientsssEcrit;
        public CallbackEventInsertDiagnostic(List<Diagnostic> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<Diagnostic> clientleav
        {
            get { return clientsssEcrit; }
        }
    }


    public class CallbackEventReceiveFile : EventArgs
    {
        private readonly FileMessage clientsssEcrit;
        private readonly SVC.Client receiver;
        public CallbackEventReceiveFile(FileMessage clientsjoin, SVC.Client receiverClient)
        {
            this.clientsssEcrit = clientsjoin;
            this.receiver = receiverClient;
        }
        public FileMessage clientleav
        {
            get { return clientsssEcrit; }
        }
        public Client clientrec
        {
            get { return receiver; }
        }
    }
    public class CallbackEventReceiveWhisper : EventArgs
    {
        private readonly Message MSG;
        private readonly SVC.Client receiver;


        public CallbackEventReceiveWhisper(Message clientsjoin, SVC.Client receiverClient)
        {
            this.MSG = clientsjoin;
            this.receiver = receiverClient;
        }
        public Message clientleav
        {
            get { return MSG; }
        }
        public Client clientrec
        {
            get { return receiver; }
        }
    }
    public class CallbackEventInsertDepeiementMultiple : EventArgs
    {
        private readonly List<DepeiementMultiple> clientsssEcrit;
        public CallbackEventInsertDepeiementMultiple(List<DepeiementMultiple> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<DepeiementMultiple> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
  
   
    
   
   
  
  
    public class CallbackEventInsertArretDetravail : EventArgs
    {
        private readonly List<ArretDetravail> clientsssEcrit;
        public CallbackEventInsertArretDetravail(List<ArretDetravail> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<ArretDetravail> clientleav
        {
            get { return clientsssEcrit; }
        }
    }
    
    public class CallbackEventInsertDictionnaire : EventArgs
    {
        private readonly List<Dictionnaire> clientsssEcrit;
        public CallbackEventInsertDictionnaire(List<Dictionnaire> clientsjoin)
        {
            this.clientsssEcrit = clientsjoin;
        }
        public List<Dictionnaire> clientleav
        {
            get { return clientsssEcrit; }
        }
    }

    #endregion
}

