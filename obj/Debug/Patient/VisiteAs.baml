   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5      T PMahApps.Metro, Version=1.2.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5	      B >Medicus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Medicus.PatientMedicus.Patient 5   	      Medicus.Patient.VisiteAs   5      e aDevExpress.Xpf.Controls.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxco6http://schemas.devexpress.com/winfx/2008/xaml/controls  U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a	 ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aJ 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      	 5   	   R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml    
 5   	   @d2http://schemas.microsoft.com/expression/blend/2008    
 5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core 	 5      Iwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms 	 5      JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro 	 5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5
   	   )localclr-namespace:Medicus.Patient 	 5   	   -   5        & 	  DevExpress.Xpf.Core.ThemeManager    	ThemeName0 	 *DevExpress.Xpf.Core.ThemeNameTypeConverter$  Office2010Black 5       � Title$ Consultation assistée��5   	   $	��700��6'   $	��500��64    � 
ResizeMode$ 	CanResize=�6A    � Icon$" /Medicus;component/Dent6.ico��6X    � WindowStartupLocation$ CenterScreen=�6|   $��2q�6�    � WindowStyle$ SingleBorderWindow=�6�   $��0,0,0,0q�6�   #��� ��6�   #��� ��66  .��5      � -   5         �Name$ gridgeneral��5      #��� ��6    .+�5   
   $  DevExpress.Xpf.Controls.Wizard  -   5          Name$ VisteAssisteeWizard��5      #��� ��63   ���	#FFB27300.@�5      /  )DevExpress.Xpf.Controls.WelcomeWizardPage  (  "DevExpress.Xpf.Controls.WizardPage   Title$ Consultation Clinique��6%   � 	 �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Controls.Wizard, DevExpress.Xpf.Controls.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Controls.WizardPage, DevExpress.Xpf.Controls.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]	   Header$:	 4une évaluation de la charge ou surcharge pondérale��6C   .��5      �� -   5        
 ��Name$
 windowBorderExamenIMC��5      $��3q�6:    �� CornerRadius$ 20��6N   #��� ��6`   #��� ��6�   $��10q�6�   ._�5      � -   5        $ txtIMDC��5      $��0q�6,    � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5       $��1* �6/   .+�5%      �� -   5         ��Name$ txtIMCLabel��5%   $   $��Center=�69   $"��Indice de Masse Corporelle :��6V   $��Center=�6z   $��5,5,0,0q�6�   $��Tahoma)�6�   $��	Underline{�6�   ���	#FFB27300$��14(�6�   $
��Bold"�6�   �� 5'      -   5         ��Name$ 
TAILELABEL��5'       $��Tahoma)�64   $��14(�6H   $��Taille (cm) :��6V   $��10,0,0,0q�6n   $
��Left=�6�   $��Center=�6�   $��1��6�   $
��Bold"�6�   #��� ��6�   �� 5(      -   5         ��Name$ txtTaile��5(   "   $��Center=�6�   $	��100��6�   $��Tahoma)�6�   $��80,0,5,0q�6�   $��1��6�   ���	#FFB27300*  $MahApps.Metro.Controls.TextBoxHelper   UseFloatingWatermark . $��Center=�6:  ��64   �� *Taille+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6z  �� 5)      -	   5        $ 	poidLABEL��5)       $��Tahoma)�63   $��14(�6G   $��Poids (kg):��6U   $��10,0,0,0q�6k   $
��Left=�6}   $��Center=�6�   $��2��6�   $
��Bold"�6�   #��� ��6�   �� 5*      -
   5        $ txtPois��5*   "   $��Center=�6�   $	��100��6�   $��Tahoma)�6�   $��80,0,5,0q�6�   $��2��6�   ���	#FFB27300 . $��Center=�68   �� SelectionBrush �	#FFB27300��63   �� *Poids+$ TwoWay=� .  . 6�  �� 5+      -   5        $ IMCLABEL��5+       $��Tahoma)�62   $��14(�6F   $��IMC :��6T   $��10,0,0,0q�6d   $
��Left=�6v   $��Center=�6�   $��3��6�   $
��Bold"�6�   #��� ��6�   �� 5,      -   5        $ 	ValeurImc��5,       $��Tahoma)�6�   $��24(�6�   $��50,0,0,0q�6�   $��Center=�6�   $��Center=�6�   $	��100��6�   $��3��6  #��� ��6  $
��Bold"�6c  ��63   �� *IMC+$ TwoWay=� .  . 6c  �� 5-      -   5        $ graisse��5-       $��Tahoma)�61   $��14(�6E   $!��Répartition des graisses :��6S   $��10,0,0,0q�6x   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��4��6�   $
��Bold"�6�   #��� ��6   �� 5.      -   5        $ 
txtGraisse��5.   "   $ �� HorizontalScrollBarVisibility$
 Auto=�66   " �� VerticalScrollBarVisibility$
 Auto=�6[    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   $	��190��6  $��Tahoma)�6      	Watermark$ Champ max MAX caractére��64  $��5,30,5,5q�6o  $��72��6�  $��4��6�  $��2��6�  $��4��6�  ���	#FFB27300 . $
��Bold"�6   �	#FFB27300��6�   �� *GraisseRépartiton+$ TwoWay=� .  . 6  �� 5/      -   5        $ txtNoroloLabel��5/   $   $��Center=�6<   $��Examen neurologique :��6Y   $��Center=�6v   $��5,5,0,0q�6�   $��Tahoma)�6�   $��	Underline{�6�   $��6��6�   ���	#FFB27300$��14(�6�   $
��Bold"�6  �� 50      -   5        $ Norologi��50       $��Tahoma)�62   $��14(�6F   $��pour rechercher:��6T   $��10,0,0,0q�6o   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��7��6�   #��� ��6�   $
��Bold"�6-  �� 52      -   5        $ txtNorologique��52   "   $
 Auto=�6:   $
 Auto=�6_    . $
 Wrap=�6�   $��Tahoma)�6  $M GUne polynévrite:fourmillement,démangeaisons,sensations de froid/chaud��6)  $��5,30,5,5q�6�  $��7��6�  $��2��6�  $��4��6�   . ���	#FFB27300$
��Bold"�6    �	#FFB27300��6�   �� *NorologiqueExamen+$ TwoWay=� .  . 62  54      55      57        58      $ Consultation Clinique��6   $,	 &Auscultation du cœur et des vaisseaux��6<   #��� ��6k   .��59      �� -   5        $
 windowBorderExamenCardio��59      $��3q�6=   $ 20��6Q   #��� ��6c   $��3��6�   #��� ��6�   $��10q�6  ._�5:      � -   5        $ txtCardiAdulte��5:      $��0q�63    5;      �� 5<      $
��0.5* �6,   �� 5=      �� 5>      �� 5?      �� 5@      �� 5A       5C      �� 5D      $��1* �6/   �� 5E      $��1* �6/   .+�5I      �� -   5        $ txtExamenCardio��5I   $   $��Center=�6=   $ ��Examen cardio-vasculaire :��6Z   $	��Top=�6|   $��5,5,0,0q�6�   $��Tahoma)�6�   $��	Underline{�6�   $��2��6�   $
��Bold"�6�   $��14(�6�   ���	#FFB273006	  �� 5K      -   5        $ TensionABEL��5K       $��Tahoma)�65   $��14(�6I   $��Tension artérielle :��6W   $��5,0,0,0q�6v   $
��Left=�6�   $��Center=�6�   $��1��6�   $
��Bold"�6�   #��� ��6�   �� 5L      -   5        $ txtTensionArtérielle��5L   "   $��Center=�6�   $��60��6�   $��Tahoma)�6�   $��	140,0,5,0q�6�   $��1��6�   ���	#FFB27300 . $
��Bold"�6Q  $��Center=�6c   �	#FFB27300��6@   �� *Tensionartérielle+$ TwoWay=� .  . 6�  �� 5M      -   5        $ TensionOrthoABEL��5M       $��Tahoma)�6:   $��14(�6N   $��Tension artérielle��6\   $��5,0,0,0q�6y   $
��Left=�6�   $	��Top=�6�   $��28��6�   $��2��6�   $
��Bold"�6�   #��� ��6�   �� 5N      -   5        $ TensionOrthoABELortho��5N       $��Tahoma)�6?   $��14(�6S   $�� orthostatique :��6a   $��5,15,0,0q�6|   $
��Left=�6�   $	��Top=�6�   $��28��6�   $��2��6�   $
��Bold"�6�   #��� ��6�   �� 5P      -   5        $ txtTensionArtérielleOrth��5P   "   $��Center=�6�   $��90��6�   $��Tahoma)�6�   $��	110,0,5,0q�6�   $��2��6  ���	#FFB27300 . $
��Bold"�6b  $��Center=�6t  $��80��6�   �	#FFB27300��6D   �� *!Tensionartérielleorthostatique+$ TwoWay=� .  . 6�  �� 5R      -   5        $ 
POULSLABEL��5R       $��Tahoma)�64   $��14(�6H   $��Pulsation :��6V   $��5,0,0,0q�6l   $
��Left=�6}   $��Center=�6�   $��3��6�   $
��Bold"�6�   #��� ��6�   �� 5S      -   5        $ txtPulsation��5S   "   $��90��6�   $��Tahoma)�6�   $��
110,-2,5,0q�6�   $��3��6�   $��Center=�6�   ���	#FFB27300 . $
��Bold"�6C  $��Center=�6U   �	#FFB27300��68   �� *	Pulsation+$ TwoWay=� .  . 6�  �� 5U      -   5        $ MCRLABEL��5U       $��Tahoma)�62   $��14(�6F   $��Macro-angiopathie :��6T   $��5,0,0,0q�6r   $
��Left=�6�   $	��Top=�6�   $��4��6�   $
��Bold"�6�   #��� ��6�   �� 5V      -   5        $ txtMacroangiopathie��5V   "   $
 Auto=�6?   $
 Auto=�6d    . $
 Wrap=�6�   $ Champ max MAX caractére��6  $	��190��6T  $��Tahoma)�6c  $��5,30,5,5q�6w  $��72��6�  $��4��6�  $��2��6�  ���	#FFB27300 . $
��Bold"�6    �	#FFB27300��6�   �� *Macroangiopathie+$ TwoWay=� .  . 6  �� 5W      -   5        $ soufflelabel��5W       $��Tahoma)�66   $��14(�6J   $��Souffles vasculaires :��6X   $��10,0,0,0q�6y   $
��Left=�6�   $	��Top=�6�   $��5��6�   $��1��6�   $
��Bold"�6�   #��� ��6�   �� 5X      -   5        $ txtsoufflesvasculaire��5X   "   $
 Auto=�6A   $
 Auto=�6f    . $
 Wrap=�6�   $ Champ max MAX caractére��6  $	��205��6Y  $��Tahoma)�6h  $��	10,30,5,5q�6|  $��35��6�  $��5��6�  $��1��6�  ���	#FFB27300 . $
��Bold"�6   �	#FFB27300��6�   �� *Soufflesvasculaires+$ TwoWay=� .  . 6  �� 5[      -    5        $ InsuffisanceLABEL��5[       $��Tahoma)�6;   $��14(�6O   $��Insuffisance cardiaque  :��6]   $��10,0,0,0q�6�   $��1��6�   $��1��6�   $	��Top=�6�   $
��Bold"�6�   #��� ��6�   �� 5\      -!   5        $ txtInsuffisance��5\   "   $
 Auto=�6;   $
 Auto=�6`    . $
 Wrap=�6�   $ Champ max MAX caractére��6  $	��190��6U  $��Tahoma)�6d  $��	10,30,5,0q�6x  $��1��6�  $��72��6�  $��1��6�  $��2��6�  ���	#FFB27300 . $
��Bold"�6   �	#FFB27300��6�   �� *Insuffisancecardiaque+$ TwoWay=� .  . 6%  �� 5]      -"   5        $ Oedemeslabel��5]       $��Tahoma)�66   $��14(�6J   $(��"Oedèmes des membres inférieurs :��6X   $��0q�6�   $	��Top=�6�   $��1��6�   $��3��6�   $
��Bold"�6�   #��� ��6�   �� 5^      -#   5        $ txtDoeèmes��5^   "   $
 Auto=�66   $
 Auto=�6[    . $
 Wrap=�6�   $ Champ max MAX caractére��6  $	��190��6L  $��Tahoma)�6[  $��	10,30,5,0q�6o  $��1��6�  $��72��6�  $��3��6�  $��2��6�  ���	#FFB27300 . $
��Bold"�6
   �	#FFB27300��6�   �� *Oedèmesdesmembres+$ TwoWay=� .  . 6  5_      5`      5b        5c      $ Consultation Clinique��6   $	 Examen des yeux��6<   #��� ��6U   .��5d      �� -$   5        $
 windowBorderExamenExamen��5d      $��3q�6=   $ 20��6Q   #��� ��6c   #��� ��6�   $��5,0,0,0q�6�   ._�5e      � -%   5        $ txtYeux��5e      $��0q�6,    5f      �� 5g      $
��0.5* �6,   �� 5h      �� 5i      �� 5j      �� 5k      �� 5l      �� 5m       5o      �� 5p      $��1* �6/   .+�5u      �� -&   5        $ txtExamendeyeux��5u   $   $��Center=�6=   $��Examen rapides des yeux :��6Z   $	��Top=�6{   $��5,5,0,0q�6�   $��Tahoma)�6�   $��	Underline{�6�   $��2��6�   $��14(�6�   $
��Bold"�6�   ���	#FFB273006  �� 5v      -'   5        $ 
APPREVascu��5v       $��Tahoma)�64   $��14(�6H   $<��6* Une appréciation de l'état de la vascularisation  ��6V   $��20,0,0,0q�6�   $
��Left=�6�   $��Center=�6�   $��1��6�   $
��Bold"�6�   #��� ��6�   �� 5w      -(   5        $ APPREVascu1��5w       $��Tahoma)�65   $��14(�6I   $��de la rétine��6W   $��30,0,0,0q�6n   $
��Left=�6�   $��Bottom=�6�   $��1��6�   $
��Bold"�6�   #��� ��6�   �� 5x      -)   5        $ txtVasc��5x   "   $
 Auto=�63   $
 Auto=�6X    . $
 Wrap=�6�   $ Champ max MAX caractére��6  $	��205��6K  $��Tahoma)�6Z  $��	10,0,10,5q�6n  $��72��6�  $��2��6�  $��2��6�  ���	#FFB27300 . $
��Bold"�6�   �	#FFB27300��6�   �� *étatvascularisation+$ TwoWay=� .  . 6
  �� 5y      -*   5        $ 	APPREVISU��5y       $��Tahoma)�63   $��14(�6G   $(��"* Une étude de l'acuité visuelle��6U   $��20,0,5,0q�6�   $
��Left=�6�   $��Center=�6�   $��4��6�   $
��Bold"�6�   #��� ��6�   �� 5z      -+   5        $ txtVisu��5z   "   $
 Auto=�63   $
 Auto=�6X    . $
 Wrap=�6�   $ Champ max MAX caractére��6  $	��205��6I  $��Tahoma)�6X  $��	10,0,10,5q�6l  $��72��6  $��5��6�  $��2��6�  ���	#FFB27300 . $
��Bold"�6�   �	#FFB27300��6�   �� *Uneétudedelacuité+$ TwoWay=� .  . 6  5|      5}      5        5�      $ Consultation Clinique��6   $	 Examen de la peau,pieds��6<   #��� ��6]   .��5�      �� -,   5        $
 windowBorderExamenPeau��5�      $��3q�6;   $ 20��6O   #��� ��6a   $��3��6�   #��� ��6�   $��5,0,0,0q�6  ._�5�      � --   5        $ txtCards��5�      $��0q�6-    5�      �� 5�      $
��0.5* �6,   �� 5�      �� 5�      �� 5�      �� 5�      �� 5�       5�      �� 5�      $��1* �6/   �� 5�      $��1* �6/   .+�5�      �� -.   5        $ txtExamendelapeu��5�   $   $��Center=�6>   $��Examen de la peau,pieds :��6[   $	��Top=�6|   $��5,5,0,0q�6�   $��Tahoma)�6�   $��	Underline{�6�   $��2��6�   ���	#FFB27300$��14(�6   $
��Bold"�6  �� 5�      -/   5        $ PeauABEL��5�       $��Tahoma)�62   $��14(�6F   $��La peau pour rechercher:��6T   $��10,0,0,0q�6w   $
��Left=�6�   $	��Top=�6�   $��1��6�   #��� ��6�   $
��Bold"�6  �� 5�      -0   5        $ 	PiedsABEL��5�       $��Tahoma)�63   $��14(�6G   $ ��Les pieds pour rechercher:��6U   $��10,0,0,0q�6z   $
��Left=�6�   $��Center=�6�   $��1��6�   $��1��6�   #��� ��6�   $
��Bold"�6'  �� 5�      -1   5        $ FuronclesLabel��5�       $��Tahoma)�68   $��* Furoncles��6L   $��10,0,0,0q�6b   $
��Left=�6t   $��Center=�6�   $��1��6�   $
��Bold"�6�   #��� ��6�   �� 5�      -2   5        $ LésionLabel��5�   $   $
��Wrap=�69   $��Tahoma)�6N   $E��?* Lésions aux niveaux des narines,cuisses,conduits auditifs...��6b   $��10,0,0,0q�6�   $
��Left=�6�   $��Bottom=�6�   $��1��6�   $
��Bold"�6�   #��� ��6  �� 5�      -3   5        $ PlaiessLabel��5�       $��Tahoma)�66   $��* Plaies��6J   $��10,0,0,0q�6]   $
��Left=�6o   $	��Top=�6�   $��2��6�   $��1��6�   $
��Bold"�6�   #��� ��6�   �� 5�      -4   5        $ CallositésLabel��5�       $��Tahoma)�69   $��* Callosités��6M   $��0q�6d   $��Right=�6o   $	��Top=�6�   $��2��6�   $��1��6�   $
��Bold"�6�   #��� ��6�   �� 5�      -5   5        $ InfectionsLabel��5�       $��Tahoma)�69   $��* Infections des ongles��6M   $��10,0,0,0q�6o   $
��Left=�6�   $��Bottom=�6�   $��2��6�   $��1��6�   $
��Bold"�6�   #��� ��6�   �� 5�      -6   5        $ 	MycoLabel��5�       $��Tahoma)�63   $��	* Mycoses��6G   $��0q�6[   $��Center=�6f   $	��Top=�6�   $��2��6�   $��1��6�   $
��Bold"�6�   #��� ��6�   �� 5�      -7   5        $ 	DéfLabel��5�       $��Tahoma)�62   $��* Déformation du pied��6F   $��10,0,0,0q�6f   $
��Left=�6x   $��Center=�6�   $��2��6�   $��1��6�   $
��Bold"�6�   #��� ��6�   �� 5�      -8   5        $ txtPeau��5�   "   $
 Auto=�63   $
 Auto=�6X    . $
 Wrap=�6�   $ Champ max MAX caractére��6  $	��205��6B  $��Tahoma)�6Q  $��5,20,5,5q�6e  $��72��6w  $��2��6�  $��4��6�  ���	#FFB27300 . $
��Bold"�6�   �	#FFB27300��6�   �� *
ExamenPeau+$ TwoWay=� .  . 6   �� 5�      -9   5        $ txtPieds��5�   "   $
 Auto=�64   $
 Auto=�6Y    . $
 Wrap=�6�   $ Champ max MAX caractére��6	  $	��205��6D  $��Arial)�6S  $��5,0,5,5q�6f  $��72��6w  $��3��6�  $��4��6�  $��1��6�  ���	#FFB27300 . $
��Bold"�6�   �	#FFB27300��6�   �� *ExamenPieds+$ TwoWay=� .  . 6  5�      5�      5�      2  ,DevExpress.Xpf.Controls.CompletionWizardPage  5�      $ Bilan biologique��6(   #��� ��6B   .��5�      �� -:   5        $
 windowBorderparacliniques��5�      $��3q�6>   $ 20��6R   #��� ��6d   $��3��6�   #��� ��6�   $��10q�6  ._�5�      � -;   5        $! ConstaneAnamneseDétailGrid��5�      {�. $��8��6Q   $��10q�6b   #��� ��6n    5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�       5�      �� 5�      �� 5�      �� 5�      .+�5�      �� $��Nouvelle Prise:��6$   $
��Left=�6;   $��Center=�6V   ���	#FFB27300$
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   (	  "System.Windows.Controls.DatePicker	  5�      -<   5         	 Name$ DatePriseAnamnese��5�   %   $��1��6A   $��Center=�6Q   $��Tahoma)�6l   $
��Bold"�6�   $��16(�6�   $��10,0,0,0q�6�   $��28��6�   ���	#FFB273006�   �� 5�      $��Bottom=�6!   $��3��6<   #��� ��6P   $��0,0,0,2q�6�   7
  1System.Windows.Forms.Integration.WindowsFormsHost
  5�      $��1��6+   $��2��6<   $��10,0,5,0q�6L   $��Center=�6^   $��28��6y   $	��105��6�    
  Child. 5�      (   "System.Windows.Forms.MaskedTextBox  -=   5        txtTimeAnamnese��"   System.Windows.Forms.Control   SizeU QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"  System.Drawing.SizeConverter$ 15, 15 5�   H      Text$ 00:00��6V      Mask$ 00:00��6d       Dock$
  Fill=�6q   5�      �� 5�      $��Poids��6$   $
��Left=�61   $��Center=�6L   #��� ��6g   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��1��6�   �� 5�      ->   5        $ txtPoidAnamnese��5�   "   $��Center=�6�   $��1��6�   $��1��6�   $��10,0,0,0q�6�   $��Tahoma)�6�   ���	#FFB27300 . $��14(�6@  $
��Bold"�6N   �	#FFB27300��6;   �� *Poid+$ TwoWay=� .  . 6�  �� 5�      $��Kg��6$   $
��Left=�6.   $��Center=�6I   #��� ��6d   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��1��6�   $��2��6
  �� 5�      $��Taille��6$   $
��Left=�62   $��Center=�6M   #��� ��6h   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��2��6�   �� 5�      -?   5        $ txtTailleAnamnese��5�   "   $��Tahoma)�6>   $��Center=�6�   $��1��6�   $��2��6�   $��10,0,0,0q�6�   ���	#FFB27300 . $
��Bold"�6E  $��14(�6W   �	#FFB27300��6R   �� *Taille+$ TwoWay=� .  . 6�  �� 5�      $��m��6$   $
��Left=�6-   $��Center=�6H   #��� ��6c   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��2��6�   $��2��6	  �� 5�      $	��PAS��6$   $
��Left=�6/   $��Center=�6J   #��� ��6e   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��3��6�   ! � ToolTip$%! pression artérielle systolique��6  �� 5�      -@   5        $ txtPASAnamnese��5�   "   $��Center=�6�   $��1��6�   $��3��6�   $��10,0,0,0q�6�   $$! Tension artérielle systolique��6�   ���	#FFB27300 . $��14(�6R  $��Tahoma)�6`  $
��Bold"�6t   �	#FFB27300��6:   �� *PAS+$ TwoWay=� .  . 6�  �� 5�      $
��mmHg��6$   $
��Left=�60   $��Center=�6K   #��� ��6f   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��3��6�   $��2��6  �� 5�      $	��PAD��6$   $
��Left=�6/   $��Center=�6J   #��� ��6e   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��4��6�   $&!  pression artérielle diastolique��6  �� 5�      -A   5        $ txtPADAnamnese��5�   "   $��Center=�6�   $��1��6�   $��4��6�   $��10,0,0,0q�6�   $%! Tension artérielle diastolique��6�   $��Tahoma)�6	  ���	#FFB27300 . $��14(�6g  $
��Bold"�6u   �	#FFB27300��6:   �� *PAD+$ TwoWay=� .  . 6�  �� 5�      $
��mmHg��6$   $
��Left=�60   $��Center=�6K   #��� ��6f   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��4��6�   $��2��6  �� 5�      $��Pouls��6$   $
��Left=�61   $��Center=�6L   #��� ��6g   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��5��6�   �� 5�      -B   5        $ txtPoulsAnamnese��5�   "   $��Center=�6�   $��1��6�   $��5��6�   $��10,0,0,0q�6�   $! rythme cardiaque��6�   ���	#FFB27300 . $
��Bold"�6I  $��Tahoma)�6[  $��14(�6o   �	#FFB27300��6<   �� *Pouls+$ TwoWay=� .  . 6}  �� 5�      $	��bpm��6$   $
��Left=�6/   $��Center=�6J   #��� ��6e   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��5��6�   $��2��6  �� 5�      $
��Temp��6$   $
��Left=�60   $��Center=�6K   #��� ��6f   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��6��6�   �� 5�      -C   5        $ txtTempAnamnese��5�   "   $��Center=�6�   $��1��6�   $��6��6�   $��10,0,0,0q�6�   $! température��6�   $��Tahoma)�6�   ���	#FFB27300 . $��14(�6V  $
��Bold"�6d   �	#FFB27300��6;   �� *Temp+$ TwoWay=� .  . 6v  �� 5�      $	��°C��6$   $
��Left=�6.   $��Center=�6I   #��� ��6d   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��6��6�   $��2��6
  �� 5�      $��Glycémie à jeun��6$   $
��Left=�6;   $��Center=�6V   #��� ��6q   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��7��6  $! 	glycémie��6  �� 5�      -D   5        $ txtGlycémieAjeunAnamnese��5�   "   $��Tahoma)�6D   $��Center=�6�   $��1��6�   $��7��6�   $��10,0,0,0q�6�   $! glycémie à jeun��6  ���	#FFB27300 . $
��Bold"�6l  $��14(�6~   �	#FFB27300��6X   �� *GlycémieAjeun+$ TwoWay=� .  . 6�  �� 5�      $	��g/l��6$   $
��Left=�6/   $��Center=�6J   #��� ��6e   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��7��6�   $��2��6  �� 5�      $��Glycémie postprandiale.��6$   $
��Left=�6C   $��Center=�6^   #��� ��6y   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��8��6  $! choléstérol��6  �� 5�      -E   5        $" txtGlycémiePostpranAnamnese��5�   "   $	��Top=�6�   $��1��6�   $��8��6�   $��10,2,0,0q�6�   $! glycémie postprandiale��6�   $��Tahoma)�6  ���	#FFB27300 . $��14(�6|  $
��Bold"�6�   �	#FFB27300��6G   �� *GlycémiePostprandiale+$ TwoWay=� .  . 6�  �� 5�      $��L'I.M.C��6$   $��Right=�63   $��Center=�6O   ���	#FFB27300$
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��19��6�   $#! indice de la masse corporelle��6�   �� 5�      -F   5        $ txtIMCAnamnese��5�   $   $��Tahoma)�6<   $��Center=�6�   $��1��6�   $��19��6�   $��10,0,0,0q�6�   
���  ��$#! indice de la masse corporelle��6	  ��6P   �� *IMC+$ TwoWay=� .  . 6	  �� 5�      $	��g/l��6$   $
��Left=�6/   $��Center=�6J   #��� ��6e   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��8��6�   $��2��6  �� 5�      $��mmol/l ��6$   $
��Left=�63   $��Center=�6N   #��� ��6i   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��10��6  $��2��6  �� 5�      $��mmol/l ��6$   $
��Left=�63   $��Center=�6N   #��� ��6i   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��9��6  $��2��6  �� 5�      $��mmol/l ��6$   $
��Left=�63   $��Center=�6N   #��� ��6i   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��11��6  $��2��6  �� 5�      $��mmol/l ��6$   $
��Left=�63   $��Center=�6N   #��� ��6i   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��12��6  $��2��6  �� 5�      $��LDL-cholestérol��6$   $
��Left=�6;   $��Center=�6V   #��� ��6q   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��10��6  $! choléstérol��6  �� 5�      -G   5        $ txtHDLCHOLESTAnamnese��5�   "   $	��Top=�6�   $��1��6�   $��10��6�   $��10,2,0,0q�6�   $! LDL-cholestérol��6�   $��Tahoma)�6  ���	#FFB27300 . $��14(�6j  $
��Bold"�6x   �	#FFB27300��6A   �� *LDL_cholestérol+$ TwoWay=� .  . 6�  �� 5�      $��Cholestérol TOTAL��6$   $
��Left=�6=   $��Center=�6X   #��� ��6s   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��9��6  $! choléstérol��6  �� 5�      -H   5        $ txtTCCHOLESTAnamnese��5�   "   $	��Top=�6�   $��1��6�   $��9��6�   $��10,2,0,0q�6�   $! LDL-cholestérol��6�   $��Tahoma)�6  ���	#FFB27300 . $��14(�6i  $
��Bold"�6w   �	#FFB27300��6@   �� *Cholestéroltotal+$ TwoWay=� .  . 6�  �� 5�      $��HDL-cholestérol��6$   $
��Left=�6;   $��Center=�6V   #��� ��6q   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��11��6  $! choléstérol��6  �� 5�      -I   5        $  txtHDLcholestérolAnamnese��5�   "   $	��Top=�6�   $��1��6�   $��11��6�   $��10,2,0,0q�6�   $! HDL_cholestérol��6�   $��Tahoma)�6  ���	#FFB27300 . $��14(�6n  $
��Bold"�6|   �	#FFB27300��6E   �� *HDL_cholestérol+$ TwoWay=� .  . 6�  �� 5�      $��triglycérides��6$   $
��Left=�69   $��Center=�6T   #��� ��6o   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��12��6  $! choléstérol��6  �� 5�      -J   5        $ txttriglycéridesAnamnese��5�   "   $	��Top=�6�   $��1��6�   $��12��6�   $��10,2,0,0q�6�   $! triglycérides��6�   $��Tahoma)�6  ���	#FFB27300 . $��14(�6i  $
��Bold"�6w   �	#FFB27300��6D   �� *triglycérides+$ TwoWay=� .  . 6�  �� 5�      $��Hémoglobine glyquée��6$   $
��Left=�6?   $��Center=�6Z   #��� ��6u   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��13��6  $! choléstérol��6  �� 5�      $��% ��6$   $
��Left=�6.   $��Center=�6I   #��� ��6d   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��13��6�   $��2��6  �� 5�      -K   5        $ txttHBA1CAnamnese��5�   "   $	��Top=�6�   $��1��6�   $��13��6�   $��10,2,0,0q�6�   $��Tahoma)�6�   ���	#FFB27300 . $��14(�6C  $
��Bold"�6Q   �	#FFB27300��6=   �� *HbA1c+$ TwoWay=� .  . .��6~  ! 5�      _� 5   "   .��5  &   �� " �� Orientation$" Vertical=�61   .+�5  *   �� B@Quel objectif ? Idéalement il faudrait une HbA1c normale à 6%.6t   �� 5  *   ZXIl est admis qu'un diabète est très bien équilibré avec une HbA1c inférieure à 7%,6�   �� 5  *   `^bien équilibré avec une HbA1c entre 7 et 7.5 %. S'il fallait définir un objectif général,6�   �� 5  *   ��ce serait une HbA1c inférieure à 7.5 % ou 8%. Mais l'objectif doit être individualisé en fonction de l'âge (le degré d'exigence est plus élevé chez les gens jeunes),6�   �� 5  *   VTdu bilan des complications, afin d'obtenir le meilleur compromis entre, d'un côté,6�   �� 5  *   ��le risque de développer des complications dans le futur, et de l'autre coté, le risque d'hypoglycémies sévères et les contraintes du traitement pour maintenir une qualité de vie jugée acceptable pour le patient.6	  �� 5	  *   ��L'objectif le plus strict est demandé lors de la grossesse ou de l'apparition de complications de micro-angiopathie débutante. Un objectif moins strict sera demandé en cas d'hypoglycémies sévères répétées et non ressenties,6  �� 5
  *   ��en cas d'un âge avancé avec un diabète connu depuis longtemps sans complications. L'objectif peut varier en fonction des circonstances, un objectif moins strict peut être recommandable transitoirement chez un patient6  �� 5  *   ��jeune en difficulté psychologique ou professionnelle Même quand l'HbA1c reste au-dessus de ces objectifs, il ne faut pas oublier que de passer de 11 à 9 % diminue le risque de complications de 60 %, que de bien traiter la tension artérielle, arrêter de fumer, traiter le cholestérol,6Q  �� 5  *   ��faire un bilan ophtalmologique régulier, pratiquer un électrocardiogramme d'effort représentent des objectifs associés essentiels !6�   5  '   5  #   .��5  /   5     �� 5     $��Micro albuminurie��6$   $
��Left=�6=   $��Center=�6X   #��� ��6s   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��14��6  $! choléstérol��6  �� 5     -L   5        $! txtMicroalbuminurieAnamnese��5  "   $	��Top=�6�   $��1��6�   $��14��6�   $��10,2,0,0q�6�   $! triglycérides��6�   $��Tahoma)�6  ���	#FFB27300 . $��14(�6p  $
��Bold"�6~   �	#FFB27300��6G   �� *Micro_albuminurie+$ TwoWay=� .  . 6�  �� 5     $
��mg/l��6$   $
��Left=�60   $��Center=�6K   #��� ��6f   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��14��6�   $��2��6  �� 5     $��Urée sanguine��6$   $
��Left=�69   $��Center=�6T   #��� ��6o   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��15��6  $! choléstérol��6  �� 5     -M   5        $ txtUréesanguineAnamnese��5  "   $	��Top=�6�   $��1��6�   $��15��6�   $��10,2,0,0q�6�   $! triglycérides��6�   $��Tahoma)�6	  ���	#FFB27300 . $
��Bold"�6g  $��14(�6y   �	#FFB27300��6C   �� *Uréesanguine+$ TwoWay=� .  . 6�  �� 5     $��mmol/L��6$   $
��Left=�62   $��Center=�6M   #��� ��6h   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��15��6  $��2��6  �� 5     $��Urée urinaire��6$   $
��Left=�69   $��Center=�6T   #��� ��6o   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��16��6  $! choléstérol��6  �� 5     -N   5        $ txtUréeurinaireAnamnese��5  "   $	��Top=�6�   $��1��6�   $��16��6�   $��10,2,0,0q�6�   $! triglycérides��6�   $��Tahoma)�6	  ���	#FFB27300 . $��14(�6g  $
��Bold"�6u   �	#FFB27300��6C   �� *Uréeurinaire+$ TwoWay=� .  . 6�  �� 5     $��mmol/L��6$   $
��Left=�62   $��Center=�6M   #��� ��6h   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��16��6  $��2��6  �� 5     $#��Dosage sanguin de créatinine��6$   $
��Left=�6H   $��Center=�6c   #��� ��6~   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��17��6  $#! Dosage sanguin de créatinine��6  �� 5     -O   5        $# txtcréatininesanguinAnamnese��5  "   $	��Top=�6�   $��1��6�   $��17��6�   $��10,2,0,0q�6�   $! triglycérides��6�   $��Tahoma)�6  ���	#FFB27300 . $��14(�6q  $
��Bold"�6   �	#FFB27300��6H   �� *créatininesanguin+$ TwoWay=� .  . 6�  �� 5      $��mmol/L��6$   $
��Left=�62   $��Center=�6M   #��� ��6h   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��17��6  $��2��6  �� 5"     $��créatinine urinaire��6$   $
��Left=�6?   $��Center=�6Z   #��� ��6u   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��18��6  $#! Dosage sanguin de créatinine��6  �� 5#     -P   5        $% txtccréatinineurinaireAnamnese��5#  "   $	��Top=�6�   $��1��6�   $��18��6�   $��10,2,0,0q�6�   $! triglycérides��6�   $��Tahoma)�6  ���	#FFB27300 . $��14(�6t  $
��Bold"�6�   �	#FFB27300��6J   �� *créatinineurinaire+$ TwoWay=� .  . 6�  �� 5$     $��mmol/L��6$   $
��Left=�62   $��Center=�6M   #��� ��6h   $
��Bold"�6�   $��10,0,0,0q�6�   $��18.667(�6�   $��Tahoma)�6�   $��18��6  $��2��6  5&     5'     5)     5*     5+     5,     