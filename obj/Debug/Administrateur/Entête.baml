   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      B >Medicus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Medicus.AdministrateurMedicus.Administrateur 5      $   Medicus.Administrateur.Entête   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aJ 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Medicus.Administrateur     5        N� Title$  Entête��5      $	��600��6   $	��400��6"    N� 
Background# � ��6/   .��5      � -   5         �Name$ 	GridParam��5      $��10q�6    � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $
��Logo��6   $��Century Schoolbook)�6    $��36(�6@   $��Center=�6N   $��Center=�6k   $
��Bold"�6�   #��� ��6�   �� 5!   
   $��Entête1��6   $��Century Schoolbook)�6#   $��24(�6C   $��Center=�6Q   $��Center=�6n   $
��Bold"�6�   $��1��6�   �� 5"   
   $��Entête2��6   $��2��6#   $��Century Schoolbook)�60   $��Center=�6P   $��Center=�6m   $��24(�6�   $
��Bold"�6�   �� 5#   
   $��Entête3��6   $��3��6#   $��Century Schoolbook)�60   $��24(�6P   $��Center=�6^   $��Center=�6{   $
��Bold"�6�   �� 5$   
   $��
BasDePage1��6   $��4��6&   $��Century Schoolbook)�63   $��Center=�6S   $��Center=�6p   $��24(�6�   $
��Bold"�6�   �� 5%   
   $��
BasDePage2��6   $��5��6&   $��Century Schoolbook)�63   $��Center=�6S   $��Center=�6p   $
��Bold"�6�   $��24(�6�   �� 5&   
   $��
BasDePage3��6   $��6��6&   $��24(�63   $��Century Schoolbook)�6A   $
��Bold"�6a   $��Center=�6s   $��Center=�6�   �� 5)   
   -   5         ��Name$ txtEntête1��5)      $��Century Schoolbook)�6�   $��20(�6�   $��Center=�6�   $��1��6�   $��1��6�   ��6&   �� *	Entete1+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   �� 5+   
   -   5        $ txtEntête2��5+      $��2��6&   $��1��63   $��Center=�6�   $��Century Schoolbook)�6�   ��6C   �� *	Entete2+$ TwoWay=� .  . 6�   �� 5,   
   -   5        $ txtEntête3��5,      $��3��6&   $��1��63   $��Center=�6�   $��Century Schoolbook)�6�   ��6C   �� *	Entete3+$ TwoWay=� .  . 6�   �� 5-   
   -   5        $ txtEntête4��5-      $��4��6&   $��1��63   $��Center=�6�   $��Century Schoolbook)�6�   ��6C   �� *
BasDePage1+$ TwoWay=� .  . 6�   �� 5.   
   -   5        $ txtEntête5��5.      $��5��6&   $��1��63   $��Center=�6�   $��Century Schoolbook)�6�   ��6C   �� *
BasDePage2+$ TwoWay=� .  . 6�   �� 5/   
   -   5        $ txtEntête6��5/      $��6��6&   $��1��63   $��Center=�6�   $��Century Schoolbook)�6�   ��6C   �� *
BasDePage3+$ TwoWay=� .  . 6�   �� 50   
   -   5        $��windowBorderPhoto��50      $��0q�6*   $��5q�65   	 �� CornerRadius$	 20��6I   #��� ��6[   #��� ��6�   $��2��6  $��Center=�6  $	��Top=�6/  $	��127��6G  $	��127��6S  ._�51      �� -	   5        $��imgLogo��51   %   $��5,5,5,5q�6   $
��Fill=�64   $��1��6C   $��3��6S   $1��+/Medicus;component/Images/PatientInconu.jpg��6d   $��Center=�6�   $��Center=�6�   52      �� 53   
   -
   5        $��btnOpenFile��53      $��Bottom=�6>   $��Center=�6Y   $	��150��6v   $��Times New Roman)�6�   $��2��6�   $��0q�6�   #��� ��6�   #��� ��6  $��30��6X  .��6d  télécharger Image54      �� 55   
   -   5        
 ��Name$
 	btnUpdate��55      $��7��6$   $��Center=�61   $��Center=�6N   $��Times New Roman)�6i   $��13.333(�6�   $��Normal"�6�   $�� ��6�   ���	#FFB6A60E$��35��6�   $��35��6�    � ToolTip$ Modifier��6  ��56      �� 57       �� ImageSource$V P/Medicus;component/Images/acept-verifier-corriger-vert-ok-oui-icone-9668-128.png��6   ��59      �� 5:       �� 
TargetType" ��6    �� BasedOn 5;      �� 5<      " ��6    .�5=      �� +   %MahApps.Metro.Controls.ControlsHelper �� Property �@ ContentCharacterCasing �� Value$ Upper=�6_   �� 5>       �@ CornerRadius$ 3��6U   �� 5?       � ��$ 25��6:   �� 5@       � ��$
 Bold"�6;   �� 5A       � ��   UpperCaseContentFontSize# �   69   �� 5B       � ��  DefaultFont# �  6;   �� 5C       � ��  GrayBrush10# �  6;   �� 5D       � ��  TextBoxBorderBrush# �  6<   �� 5E       � ��  	TextBrush# �  6;   �� 5F       � ��$	 5,6q�68   �� 5G       � ��$ 1q�6@   �� 5H       � �� 5I   "   �� 5J   &    �� 
TargetType" ��66   .R�5K   *   � .+�5L   .   ��  ��Name$ 
Background��65   #��z��6I   	 6s   �� *(&(Controls:ControlsHelper.CornerRadius)+$ OneWay=� �� RelativeSource �� *TemplatedParent+�� 5M   .   $ Border��65   #��z��6E   #��z��6q    J� SnapsToDevicePixels# z 69  ��6�   Z� 	 6�   �� *(&(Controls:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+69  �� 5N   .   $ DisabledVisualElement��65     ControlsDisabledBrush#���  6T    J� IsHitTestVisible .   J� Opacity$ 0Q�6   # z 6,  	 6�   �� *(&(Controls:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6,  -   'MahApps.Metro.Controls.ContentControlEx  5O   .     Name$ PART_ContentPresenter��6H   #��z��6�   #��z��6    �� ContentStringFormat# z 6D  #��z��6�  #��z��6�     RecognizesAccessKey . # z 6	  #��z��6E     ContentCharacterCasing 6g   �� *20(Controls:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6E  5P   +    �� Triggers 5Q   *   P� 5R   .    P� Property �@J�IsMouseOver P� Value . . �5T   2   ��  �� 
TargetName$ DisabledVisualElement��6L    �@J�Opacity$	 0.3Q�6o   �� 5U   2   $ PART_ContentPresenter��6L    �@J�Opacity$	 0.3Q�6o   �� 5V   2   $ 
Background��6L    �@J�Opacity$	 0.3Q�6d   5W   /   P� 5X   .    � �� . . �5Y   2   �� $ DisabledVisualElement��6L    �@J�Opacity$	 0.3Q�6o   �� 5Z   2   $ PART_ContentPresenter��6L    �@J�Opacity$	 0.3Q�6o   �� 5[   2   $ 
Background��6L    �@J�Opacity$	 0.3Q�6d   5\   /   P� 5]   .    �@J�IsKeyboardFocusWithin . . �5^   2   �� $ DisabledVisualElement��6L    �@J�Opacity$	 0.3Q�6o   �� 5_   2   $ PART_ContentPresenter��6L    �@J�Opacity$	 0.3Q�6o   �� 5`   2   $ 
Background��6L    �@J�Opacity$	 0.3Q�6d   5a   /   P� 5b   .    � {� .  . �5c   2   �� $ DisabledVisualElement��6L    �@J�Opacity$	 0.7Q�6o   �� 5d   2   $ PART_ContentPresenter��6L    �@J�Opacity$	 0.3Q�6o   5e   /   5g   '   5i      5j      5l      ��5n      �� 5o      5s      5t      5u      