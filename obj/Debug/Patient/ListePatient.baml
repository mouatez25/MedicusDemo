   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   %   B >Medicus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Medicus.PatientMedicus.Patient 5
      "   Medicus.Patient.ListePatient   5      f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   e aDevExpress.Xpf.Controls.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxwui7http://schemas.devexpress.com/winfx/2008/xaml/windowsui  6N   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^	 ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a
 ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aJ 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     	 
 5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   %   OdxwuinBhttp://schemas.devexpress.com/winfx/2008/xaml/windowsui/navigation  5      <dxc2http://schemas.devexpress.com/winfx/2008/xaml/core 
 5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 
 5      :d2http://schemas.microsoft.com/expression/blend/2008 
 5	      )localclr-namespace:Medicus.Patient 
 5
      9Custom,http://metro.mahapps.com/winfx/xaml/controls   5      #��� ��5      .��5      �   � RowDefinitions  5   
   �� 5      $
��80px �6   �� 5      �� 5      $��2* �6   .+�5   
   1  +DevExpress.Xpf.WindowsUI.PageAdornerControl  <  6DevExpress.Xpf.WindowsUI.Base.veHeaderedContentControl   Header$ Liste Des Patients��6#   $��0��6?   $��Center=�6L   $
��Left=�6g   $��Tahoma)�6�   #��� ��6�   $
��Bold"�6�      HeaderTemplate 5      �� 5      .R�5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6/   �� 5      .+�5!      �� ��6+   �� 5#      5$      5&      ]� 5'   
   $��	350,0,0,0q�6   $
��Auto=�6'   $��Disabled=�6Y   $��1��6�   $��Center=�6�   .+�5(      �� ��. $��Disabled=�6,   $
��Auto=�6`   $��Center=�6�   $��Center=�6�   $��10,0,0,0q�6�   .��5)      ��  �� Orientation$ 
Horizontal=�6   .+�5*      �� -   5         ��Name$ btnNew��5*      $,��&Segoe UI, Lucida Sans Unicode, Verdana)�6%   $�� ��6n   $��10(�6y   #��� ��6�    � ToolTip$ Nouveau��6�   $��25��6�   $��25��6�   $
��Left=�6  $��Center=�6  $��25��68  $��25��6C  ��5+      �� 5,      ��5/      �� 50       �� ImageSource$F @/Medicus;component/Administrateur/Images/1456624077_add_user.png��6!   ��52      �� 53       �� 
TargetType" ��6   	 �� BasedOn	 54      �� 55      " ��6$   .�56   "   �� +   %MahApps.Metro.Controls.ControlsHelper
 �� Property
 �@ ContentCharacterCasing �� Value$ Upper=�6a   �� 57   "   
 �@ CornerRadius$ 3��6W   �� 58   "   
 � ��$ 25��6>   �� 59   "   
 � ��$
 Bold"�6?   �� 5:   "   
 � ��   UpperCaseContentFontSize# �   6=   �� 5;   "   
 � ��  DefaultFont# �  6?   �� 5<   "   
 � ��  GrayBrush10# �  6?   �� 5=   "   
 � ��  TextBoxBorderBrush# �  6@   �� 5>   "   
 � ��  	TextBrush# �  6?   �� 5?   "   
 � ��$	 5,6q�6<   �� 5@   "   
 � ��$ 1q�6D   �� 5A   "   
 � �� 5B   &   �� 5C   *    �� 
TargetType" ��6:   .R�5D   .   � .+�5E   2   ��  ��Name$ 
Background��69   #��z��6M    �� CornerRadius 6w   �� *&$(Custom:ControlsHelper.CornerRadius)+ �� Mode$ OneWay=� �� RelativeSource �� *TemplatedParent+�� 5F   2   $ Border��69   #��z��6I   #��z��6u    J� SnapsToDevicePixels# z 6;  ��6�   Z�  6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6;  �� 5G   2   $ DisabledVisualElement��69     ControlsDisabledBrush#���  6X    J� IsHitTestVisible .   J� Opacity$ 0Q�6"  # z 6.   6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6.  -   'MahApps.Metro.Controls.ContentControlEx  5H   2     Name$ PART_ContentPresenter��6J   #��z��6�   #��z��6    �� ContentStringFormat# z 6D  #��z��6�  #��z��6�     RecognizesAccessKey . # z 6	  #��z��6E     ContentCharacterCasing 6i   �� *0.(Custom:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6E  5I   /    �� Triggers 5J   .   P� 5K   2    P� Property �@J�IsMouseOver P� Value . . �5M   6   ��  �� 
TargetName$ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5N   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5O   6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5P   3   P� 5Q   2    � �� . . �5R   6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5S   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5T   6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5U   3   P� 5V   2    �@J�IsKeyboardFocusWithin . . �5W   6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5X   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5Y   6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5Z   3   P� 5[   2    � {� .  . �5\   6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.7Q�6s   �� 5]   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   5^   3   5`   +   5b   #   5c      5e      5h      �� 5i      -   5        $ btnSupp��5i      $��Segoe UI)�6&   $��20,0,0,0q�6<   $�� ��6d   #��� ��6o   $ 	Supprimer��6�   $��25��6�   $��25��6�   $
��Left=�6�   $��Center=�6  $��25��6"  $��25��6-  ��5j      �� 5k      ��5m      �� 5n      $D >/Medicus;component/Administrateur/Images/1456624817_delete.png��6)   ��5p      �� 5q      " ��6   	 5r      �� 5s      " ��6$   .�5t   "   �� 
 �@ ContentCharacterCasing$ Upper=�6a   �� 5u   "   
 �@ CornerRadius$ 3��6W   �� 5v   "   
 � ��$ 25��6>   �� 5w   "   
 � ��$
 Bold"�6?   �� 5x   "   
 � ��# �   6=   �� 5y   "   
 � ��# �  6?   �� 5z   "   
 � ��# �  6?   �� 5{   "   
 � ��# �  6@   �� 5|   "   
 � ��# �  6?   �� 5}   "   
 � ��$	 5,6q�6<   �� 5~   "   
 � ��$ 1q�6D   �� 5   "   
 � �� 5�   &   �� 5�   *   " ��6:   .R�5�   .   � .+�5�   2   �� $ 
Background��69   #��z��6M    6w   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+�� 5�   2   $ Border��69   #��z��6I   #��z��6u   # z 6;  ��6�   Z�  6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6;  �� 5�   2   $ DisabledVisualElement��69   #���  6X    .  $ 0Q�6"  # z 6.   6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6.    5�   2   $ PART_ContentPresenter��6J   #��z��6�   #��z��6   # z 6D  #��z��6�  #��z��6�   . # z 6	  #��z��6E   6i   �� *0.(Custom:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6E  5�   /    5�   .   P� 5�   2    �@J�IsMouseOver . . �5�   6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5�   3   P� 5�   2    � �� . . �5�   6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5�   3   P� 5�   2    �@J�IsKeyboardFocusWithin . . �5�   6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5�   3   P� 5�   2    � {� .  . �5�   6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.7Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   5�   3   5�   +   5�   #   5�      5�      5�      �� 5�      -   5        $ btnEdit��5�      $��20,0,0,0q�6<   $�� ��6N   #��� ��6Y   $ Modifier��6�   $��25��6�   $��25��6�   $
��Left=�6�   $��Center=�6�   $��25��6  $��25��6  ��5�      �� 5�      ��5�      �� 5�      $G A/Medicus;component/Administrateur/Images/1456624391_edit_user.png��6)   ��5�      �� 5�      " ��6   	 5�      �� 5�      " ��6$   .�5�   "   �� 
 �@ ContentCharacterCasing$ Upper=�6a   �� 5�   "   
 �@ CornerRadius$ 3��6W   �� 5�   "   
 � ��$ 25��6>   �� 5�   "   
 � ��$
 Bold"�6?   �� 5�   "   
 � ��# �   6=   �� 5�   "   
 � ��# �  6?   �� 5�   "   
 � ��# �  6?   �� 5�   "   
 � ��# �  6@   �� 5�   "   
 � ��# �  6?   �� 5�   "   
 � ��$	 5,6q�6<   �� 5�   "   
 � ��$ 1q�6D   �� 5�   "   
 � �� 5�   &   �� 5�   *   " ��6:   .R�5�   .   � .+�5�   2   �� $ 
Background��69   #��z��6M    6w   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+�� 5�   2   $ Border��69   #��z��6I   #��z��6u   # z 6;  ��6�   Z�  6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6;  �� 5�   2   $ DisabledVisualElement��69   #���  6X    .  $ 0Q�6"  # z 6.   6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6.    5�   2   $ PART_ContentPresenter��6J   #��z��6�   #��z��6   # z 6D  #��z��6�  #��z��6�   . # z 6	  #��z��6E   6i   �� *0.(Custom:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6E  5�   /    5�   .   P� 5�   2    �@J�IsMouseOver . . �5�   6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5�   3   P� 5�   2    � �� . . �5�   6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5�   3   P� 5�   2    �@J�IsKeyboardFocusWithin . . �5�   6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5�   6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5�   3   P� 5�   2    � {� .  . �5�   6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.7Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   5�   3   5�   +   5�   #   5�      5�      5�      �� 5�      -   5        $ btnImprimer��5�      $��20,0,0,0q�6*   $�� ��6<   $��Center=�6G   #��� ��6d   $ Imprimer��6�   $��25��6�   $��25��6�   $��Center=�6�   $��25��6  $��25��6   ��5�      �� 5�      $E ?/Medicus;component/Administrateur/Images/1456624510_printer.png��6)   ��5�      �� 5�      ��5�      �� 5�      " ��6   	 5�      �� 5�      " ��6$   .�5�   "   �� 
 �@ ContentCharacterCasing$ Upper=�6a   �� 5�   "   
 �@ CornerRadius$ 3��6W   �� 5�   "   
 � ��$ 25��6>   �� 5�   "   
 � ��$
 Bold"�6?   �� 5�   "   
 � ��# �   6=   �� 5�   "   
 � ��# �  6?   �� 5�   "   
 � ��# �  6?   �� 5�   "   
 � ��# �  6@   �� 5�   "   
 � ��# �  6?   �� 5�   "   
 � ��$	 5,6q�6<   �� 5�   "   
 � ��$ 1q�6D   �� 5�   "   
 � �� 5�   &   �� 5�   *   " ��6:   .R�5�   .   � .+�5�   2   �� $ 
Background��69   #��z��6M    6w   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+�� 5   2   $ Border��69   #��z��6I   #��z��6u   # z 6;  ��6�   Z�  6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6;  �� 5  2   $ DisabledVisualElement��69   #���  6X    .  $ 0Q�6"  # z 6.   6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6.    5  2   $ PART_ContentPresenter��6J   #��z��6�   #��z��6   # z 6D  #��z��6�  #��z��6�   . # z 6	  #��z��6E   6i   �� *0.(Custom:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6E  5  /    5  .   P� 5  2    �@J�IsMouseOver . . �5  6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5  6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5	  6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5
  3   P� 5  2    � �� . . �5  6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5  6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5  6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5  3   P� 5  2    �@J�IsKeyboardFocusWithin . . �5  6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5  6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5  6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5  3   P� 5  2    � {� .  . �5  6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.7Q�6s   �� 5  6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   5  3   5  +   5  #   5     5     5"     �� 5#     -   5        $ 
btnDossier��5#     $��20,0,0,0q�6)   $�� ��6;   $
��Left=�6F   #��� ��6a   $ Dossier��6�   $��25��6�   $��25��6�   $��25��6�   $��25��6�   $��Center=�6  ��5$     �� 5&     $D >/Medicus;component/FileDattente/Images/renommer-un-fichier.png��6!   ��5(     �� 5)     ��5+     �� 5,     " ��6   	 5-     �� 5.     " ��6$   .�5/  "   �� 
 �@ ContentCharacterCasing$ Upper=�6a   �� 50  "   
 �@ CornerRadius$ 3��6W   �� 51  "   
 � ��$ 25��6>   �� 52  "   
 � ��$
 Bold"�6?   �� 53  "   
 � ��# �   6=   �� 54  "   
 � ��# �  6?   �� 55  "   
 � ��# �  6?   �� 56  "   
 � ��# �  6@   �� 57  "   
 � ��# �  6?   �� 58  "   
 � ��$	 5,6q�6<   �� 59  "   
 � ��$ 1q�6D   �� 5:  "   
 � �� 5;  &   �� 5<  *   " ��6:   .R�5=  .   � .+�5>  2   �� $ 
Background��69   #��z��6M    6w   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+�� 5?  2   $ Border��69   #��z��6I   #��z��6u   # z 6;  ��6�   Z�  6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6;  �� 5@  2   $ DisabledVisualElement��69   #���  6X    .  $ 0Q�6"  # z 6.   6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6.    5A  2   $ PART_ContentPresenter��6J   #��z��6�   #��z��6   # z 6D  #��z��6�  #��z��6�   . # z 6	  #��z��6E   6i   �� *0.(Custom:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6E  5B  /    5C  .   P� 5D  2    �@J�IsMouseOver . . �5F  6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5G  6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5H  6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5I  3   P� 5J  2    � �� . . �5K  6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5L  6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5M  6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5N  3   P� 5O  2    �@J�IsKeyboardFocusWithin . . �5P  6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5Q  6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   �� 5R  6   $ 
Background��6P   
 �@J�Opacity$	 0.3Q�6h   5S  3   P� 5T  2    � {� .  . �5U  6   �� $ DisabledVisualElement��6P   
 �@J�Opacity$	 0.7Q�6s   �� 5V  6   $ PART_ContentPresenter��6P   
 �@J�Opacity$	 0.3Q�6s   5W  3   5Y  +   5[  #   5\     5^     5a     �� 5c     -   5         ��Name$ txtRecherche��5c     $
��Left=�6,   $��Center=�6G   $��15,0,0,0q�6b   $	��150��6t   ���	#FFB27300#��� ��6�   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$	 Nom��6  �� 5d     -   5        $ txtRef��5d     $
��Left=�6.   $��Center=�6I   $��15,0,0,0q�6d   $	��100��6v   ���	#FFB27300#��� ��6�   $
 Réf��6  �� 5e     -   5        $ 
txtDossier��5e     $
��Left=�62   $��Center=�6M   $��15,0,0,0q�6h   $	��100��6z   ���	#FFB27300#��� ��6�   $ N° Dossier��6  �� 5f     -	   5        $ txtRechercheMedecin��5f     $
��Left=�6;   $��Center=�6V   $��15,0,0,0q�6q   $	��120��6�   ���	#FFB27300#��� ��6�   $ Medecin Traitant��6&  5h     5i     5j     %  DevExpress.Xpf.Grid.GridControl  5m  
   -
   5          Name$ PatientDataGrid��5m     $��1��6g   $��0q�6�   $��2��6�   $��2��6�   $��Tahoma)�6�      
Background# � ��6�   )  #DevExpress.Xpf.Grid.DataControlBase    SelectionMode$
  None=�6-  !   ItemsSource! 6u   �� "   BorderBrush" 6�   Z� #   View# 5n     #  DevExpress.Xpf.Grid.TableView  5o     &	   DevExpress.Xpf.Grid.DataViewBase$ 	  AllowEditing$ .  &
   DevExpress.Xpf.Grid.GridViewBase% 
  AllowGrouping% .  & 	  AllowColumnMoving& .  ' 	  AllowSorting' .  (   AllowFixedGroups] YDevExpress.Data.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5  /DevExpress.Utils.Design.DefaultBooleanConverter$( False 6z   ) 
  ShowGroupPanel) .  "*   ShowCriteriaInAutoFilterRow* .  6�   + � ContextMenu+ 5q     �� 5s     @�5t     m� 5u     -   5        $
��Edit��5u  %   64   m� 5v     -   5        $��Delete��5v  #   63   m� 5w     -   5        $��Folder Client��5w  #   6:   5y     ,   Columns, 5}     $  DevExpress.Xpf.Grid.GridColumn  5~     $  DevExpress.Xpf.Grid.BaseColumn-   Header) 
 #DevExpress.Xpf.Core.ObjectConverter$- CodeSys 6"   .   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$
. Auto 5     /   MinWidth$/ 50��6*   $  DevExpress.Xpf.Grid.ColumnBase0   Binding0 6   �� *Id+6*     5�     $
- Réf 6!   $
. Auto 5�     $/ 50��6+   0 6   �� *Ref+6+     5�     $- Dossier 6!   $
. Auto 5�  "   $/ 50��6/   0 6   �� *	Dossier+6/     5�     $	- Nom 6!   $
. Auto 5�     $/ 50��6,   0 6   �� *Nom+6,     5�     $- Prénom 6!   $
. Auto 5�  !   $/ 50��6/   0 6   �� *	Prénom+6/     5�     $- Adresse 6!   $
. Auto 5�  "   $/ 50��6/   0 6   �� *	Adresse+6/     5�     $
- Sexe 6!   $
. Auto 5�     $/ 50��6-   0 6   �� *Sexe+6-     5�     $- Téléphone 6!   $
. Auto 5�  $   $/ 50��61   0 6   �� *Téléphone+61     5�     $- Mobile 6!   $
. Auto 5�  !   $/ 50��6/   0 6   �� *Mobile+6/     5�     $- EtatCiv 6!   $
. Auto 5�  "   $/ 50��6/   0 6   �� *	EtatCiv+6/     5�     $- DateDeNaissance 6!   $
. Auto 5�  I   $/ 50��6V   0 6   �� *DateDeNaissance+1 �� StringFormat$1 {0:dd/MM/yyyy}��6V     5�     $- 	NuméroSS 6!   $
. Auto 5�  #   $/ 50��61   0 6   �� *	NuméroSS+61     5�     $- 	Assurance 6!   $
. Auto 5�  $   $/ 50��61   0 6   �� *	Assurance+61     5�     $- Fonction 6!   $
. Auto 5�  #   $/ 50��61   0 6   �� *
Fonction+61     5�     $- 	Remarques 6!   $
. Auto 5�  $   $/ 50��62   0 6   �� *	Remarques+62     5�     $- Email 6!   $
. Auto 5�      $/ 50��6-   0 6   �� *Email+6-     5�     $- SuiviParNom 6!   $
. Auto 5�  &   $/ 50��63   0 6   �� *SuiviParNom+63     5�     $- SuiviParPrénom 6!   $
. Auto 5�  )   $/ 50��66   0 6   �� *SuiviParPrénom+66     5�     $- CheminPhoto 6!   $
. Auto 5�  &   $/ 50��64   0 6   �� *CheminPhoto+64     5�     $- SuiviParCode 6!   $
. Auto 5�  '   $/ 50��64   0 6   �� *SuiviParCode+64   5�     5�     5�     