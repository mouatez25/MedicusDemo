   M S B A M L   `   `   `  ����B  >Medicus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Medicus.CaisseMedicus.Caisse  5      T PMahApps.Metro, Version=1.2.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5          Medicus.Caisse.Caisse   5      f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6N   e aDevExpress.Xpf.Controls.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxwui7http://schemas.devexpress.com/winfx/2008/xaml/windowsui  5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R	 NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^
 ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    	 
  5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml   	  5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006   	  5      @d2http://schemas.microsoft.com/expression/blend/2008   	  5      .localclr-namespace:Medicus.Caisse   	  5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro   	  5      9Custom,http://metro.mahapps.com/winfx/xaml/controls  5
      #��� ��5      .��5      �   � RowDefinitions  5   
   �� 5      $
��80px �6   �� 5      $��3* �6   �� 5      $��0.25* �6   .+�5   
   1  +DevExpress.Xpf.WindowsUI.PageAdornerControl  <  6DevExpress.Xpf.WindowsUI.Base.veHeaderedContentControl   Header$ Caisse��6#   $��0��63   $��Center=�6@   $
��Left=�6[   $��Tahoma)�6v   #��� ��6�   #��� ��6�      HeaderTemplate 5      �� 5      .R�5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6/   �� 5      .+�5       �� ��6+   �� 5"      5#      5%      ]� 5&   
   $��	200,0,0,0q�6   $
��Auto=�6'   $��Disabled=�6Y   $��Center=�6�   $��Center=�6�   .+�5'      �� ��. $��Disabled=�6,   $
��Auto=�6`   $��Center=�6�   $��Center=�6�   .��5(      ��  �� Orientation$ 
Horizontal=�6   .+�5)      ]� $��15,6,6,4q�6!   $
��Auto=�63   $��Disabled=�6e   $
��Left=�6�   $��2��6�   $��1��6�   .+�5*      �� -   5         ��Name$ 	btnFilter��5*      $��Right=�6D   $��Right=�6`   $�� ��6x   $��Times New Roman)�6�   $��12(�6�    � ToolTip$ Filtrer��6�   $��25��6�   $��5,0,0,0q�6�   $��25��6�   ��6�   Z� ��5+      �� 5,       �� 
TargetType" ��6     �� BasedOn 5-      �� 5.   "   " ��6(   .�5/   &   �� +  %MahApps.Metro.Controls.ControlsHelper	 �� Property	 �@ ContentCharacterCasing
 �� Value$
 Upper=�6g   �� 50   &   	 �@ CornerRadius$
 3��6]   �� 51   &   	 � ��$
 25��6B   �� 52   &   	 � ��$

 Bold"�6C   �� 53   &   	 � ��   UpperCaseContentFontSize#
 �   6A   �� 54   &   	 � ��  DefaultFont#
 �  6C   �� 55   &   	 � ��  GrayBrush10#
 �  6C   �� 56   &   	 � ��  TextBoxBorderBrush#
 �  6D   �� 57   &   	 � ��  	TextBrush#
 �  6C   �� 58   &   	 � ��$	
 5,6q�6@   �� 59   &   	 � ��$
 1q�6H   �� 5:   &   	 � ��
 5;   *   �� 5<   .    �� 
TargetType" ��6>   .R�5=   2   � .+�5>   6   ��  ��Name$ 
Background��6=   #��z��6Q    �� CornerRadius 6{   �� *(&(Controls:ControlsHelper.CornerRadius)+ �� Mode$ OneWay=� �� RelativeSource �� *TemplatedParent+�� 5?   6   $ Border��6=   #��z��6M   #��z��6y    J� SnapsToDevicePixels# z 6A  ��6�   Z�  6�   �� *(&(Controls:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6A  �� 5@   6   $ DisabledVisualElement��6=     ControlsDisabledBrush#���  6\    J� IsHitTestVisible .   J� Opacity$ 0Q�6(  # z 64   6�   �� *(&(Controls:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+64  -  'MahApps.Metro.Controls.ContentControlEx  5A   6     Name$ PART_ContentPresenter��6P   #��z��6�   #��z��6(   �� ContentStringFormat# z 6L  #��z��6�  #��z��6�     RecognizesAccessKey . # z 6  #��z��6M     ContentCharacterCasing 6o   �� *20(Controls:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6M  5B   3    �� Triggers 5C   2   P� 5D   6    P� Property �@J�IsMouseOver P� Value . . �5F   :   ��  �� 
TargetName$ DisabledVisualElement��6T   	 �@J�Opacity$	
 0.3Q�6w   �� 5G   :   $ PART_ContentPresenter��6T   	 �@J�Opacity$	
 0.3Q�6w   �� 5H   :   $ 
Background��6T   	 �@J�Opacity$	
 0.3Q�6l   5I   7   P� 5J   6    � �� . . �5K   :   �� $ DisabledVisualElement��6T   	 �@J�Opacity$	
 0.3Q�6w   �� 5L   :   $ PART_ContentPresenter��6T   	 �@J�Opacity$	
 0.3Q�6w   �� 5M   :   $ 
Background��6T   	 �@J�Opacity$	
 0.3Q�6l   5N   7   P� 5O   6    �@J�IsKeyboardFocusWithin . . �5P   :   �� $ DisabledVisualElement��6T   	 �@J�Opacity$	
 0.3Q�6w   �� 5Q   :   $ PART_ContentPresenter��6T   	 �@J�Opacity$	
 0.3Q�6w   �� 5R   :   $ 
Background��6T   	 �@J�Opacity$	
 0.3Q�6l   5S   7   P� 5T   6    � {� .  . �5U   :   �� $ DisabledVisualElement��6T   	 �@J�Opacity$	
 0.7Q�6w   �� 5V   :   $ PART_ContentPresenter��6T   	 �@J�Opacity$	
 0.3Q�6w   5W   7   5Y   /   5[   '   5\   #   5^      ��5`      �� 5a       �� ImageSource$V P/Medicus;component/Images/acept-verifier-corriger-vert-ok-oui-icone-9668-128.png��6%   5c      �� 5d      -   5         ��Name$ CompteComboBox��5d       �� SelectedValuePath$ Content��63   $
��Left=�6O   $��10��6e   $��Right=�6s   $��Center=�6�   $��Tahoma)�6�   $��14(�6�   #��� ��6�   $
��Bold"�6  ���	#FFB27300#��� ��6F  .@�5e      �� $��Tous Mes Comptes��6#   $��14(�6>    �� 
IsSelected . 6L   �� 5f      $��Caisse��6#   $��14(�64   �� 5g      $��Banque��6#   $��14(�64   5h      �� 5i      -   5        $ ModeRéglement��5i      $ Content��62   $��Right=�6O   $��10��6f   $��Right=�6t   $��Center=�6�   $��Tahoma)�6�   $��14(�6�   #��� ��6   #��� ��6Q  ���	#FFB27300.@�5j      �� $"��Tous les modes de règlement��6#   $��14(�6I    . 6W   �� 5k      �� 5l      $��Espèces��6$   $��14(�66   �� 5m      $��
Hors Place��6$   $��14(�69   �� 5n      $��	Sur Place��6#   $��14(�67   �� 5o      $��Carte bancaire��6#   $��14(�6<   �� 5p      $��Virement��6$   $��14(�67   �� 5q      $��Monéo��6$   $��14(�64   �� 5r      $	��Dû��6$   $��14(�61   5s      (  "System.Windows.Controls.DatePicker  5u      -   5          Name$ DateSaisieFin��5u      $��Center=�64   $��14(�6O   $��Tahoma)�6]   $
��Bold"�6q   ���	#FFB27300$��0,0,10,0q�6�   $��Right=�6�   $��Right=�6�   #��� ��6  �� 5v      $	��au:��6   $��Center=�6(   $
��Bold"�6C   $��14(�6U   $��0,0,10,0q�6c   $��Tahoma)�6u   $��Right=�6�   $��Right=�6�   #��� ��6�     5w      -   5        $ DateSaisieDébut��5w      $��Center=�66   $��14(�6Q   $��Tahoma)�6_   $
��Bold"�6s   ���	#FFB27300$��0,0,10,0q�6�   $��Right=�6�   $��Right=�6�   #��� ��6�   �� 5x      $	��Du:��6   $��Center=�6(   $
��Bold"�6C   $��14(�6U   $
��10,0q�6c   $��Tahoma)�6q   $��Right=�6�   $��Right=�6�   #��� ��6�   5z      �� 5{      -   5        $ btnNew��5{      $,��&Segoe UI, Lucida Sans Unicode, Verdana)�6%   $�� ��6n   $��10(�6y   #��� ��6�   $ Nouveau��6�   $��25��6�   $��25��6�   $��20,0,0,0q�6�   ��5|      �� 5}      ��5      �� 5�      $B </Medicus;component/Images/dossier-nouveau-icone-4594-128.png��6!   ��5�      �� 5�      " ��6    5�      �� 5�      " ��6$   .�5�   "   �� 	 �@ ContentCharacterCasing$
 Upper=�6a   �� 5�   "   	 �@ CornerRadius$
 3��6W   �� 5�   "   	 � ��$
 25��6>   �� 5�   "   	 � ��$

 Bold"�6?   �� 5�   "   	 � ��#
 �   6=   �� 5�   "   	 � ��#
 �  6?   �� 5�   "   	 � ��#
 �  6?   �� 5�   "   	 � ��#
 �  6@   �� 5�   "   	 � ��#
 �  6?   �� 5�   "   	 � ��$	
 5,6q�6<   �� 5�   "   	 � ��$
 1q�6D   �� 5�   "   	 � ��
 5�   &   �� 5�   *   " ��6:   .R�5�   .   � .+�5�   2   �� $ 
Background��69   #��z��6M    6w   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+�� 5�   2   $ Border��69   #��z��6I   #��z��6u   # z 6;  ��6�   Z�  6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6;  �� 5�   2   $ DisabledVisualElement��69   #���  6X    .  $ 0Q�6"  # z 6.   6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6.    5�   2   $ PART_ContentPresenter��6J   #��z��6�   #��z��6   # z 6D  #��z��6�  #��z��6�   . # z 6	  #��z��6E   6i   �� *0.(Custom:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6E  5�   /    5�   .   P� 5�   2    �@J�IsMouseOver . . �5�   6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5�   3   P� 5�   2    � �� . . �5�   6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5�   3   P� 5�   2    �@J�IsKeyboardFocusWithin . . �5�   6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5�   3   P� 5�   2    � {� .  . �5�   6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.7Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   5�   3   5�   +   5�   #   5�      5�      5�      �� 5�      -   5        $ btnSupp��5�      $��Segoe UI)�6&   $��20,0,0,0q�6<   $�� ��6d   #��� ��6o   $ 	Supprimer��6�   $��25��6�   $��25��6�   ��5�      �� 5�      ��5�      �� 5�      $C =/Medicus;component/Images/supprimer-dossier-icone-4934-64.png��6!   ��5�      �� 5�      " ��6    5�      �� 5�      " ��6$   .�5�   "   �� 	 �@ ContentCharacterCasing$
 Upper=�6a   �� 5�   "   	 �@ CornerRadius$
 3��6W   �� 5�   "   	 � ��$
 25��6>   �� 5�   "   	 � ��$

 Bold"�6?   �� 5�   "   	 � ��#
 �   6=   �� 5�   "   	 � ��#
 �  6?   �� 5�   "   	 � ��#
 �  6?   �� 5�   "   	 � ��#
 �  6@   �� 5�   "   	 � ��#
 �  6?   �� 5�   "   	 � ��$	
 5,6q�6<   �� 5�   "   	 � ��$
 1q�6D   �� 5�   "   	 � ��
 5�   &   �� 5�   *   " ��6:   .R�5�   .   � .+�5�   2   �� $ 
Background��69   #��z��6M    6w   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+�� 5�   2   $ Border��69   #��z��6I   #��z��6u   # z 6;  ��6�   Z�  6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6;  �� 5�   2   $ DisabledVisualElement��69   #���  6X    .  $ 0Q�6"  # z 6.   6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6.    5�   2   $ PART_ContentPresenter��6J   #��z��6�   #��z��6   # z 6D  #��z��6�  #��z��6�   . # z 6	  #��z��6E   6i   �� *0.(Custom:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6E  5�   /    5�   .   P� 5�   2    �@J�IsMouseOver . . �5�   6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5�   3   P� 5�   2    � �� . . �5�   6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5�   3   P� 5�   2    �@J�IsKeyboardFocusWithin . . �5�   6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5�   6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5�   3   P� 5�   2    � {� .  . �5�   6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.7Q�6s   �� 5�   6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   5�   3   5�   +   5�   #   5�      5�      5�      �� 5�      -   5        $ btnEdit��5�      $��20,0,0,0q�6<   $�� ��6N   #��� ��6Y   $ Modifier��6�   $��25��6�   $��25��6�   ��5�      �� 5�      ��5�      �� 5�      $G A/Medicus;component/Administrateur/Images/1456624391_edit_user.png��6!   ��5�      �� 5�      " ��6    5      �� 5     " ��6$   .�5  "   �� 	 �@ ContentCharacterCasing$
 Upper=�6a   �� 5  "   	 �@ CornerRadius$
 3��6W   �� 5  "   	 � ��$
 25��6>   �� 5  "   	 � ��$

 Bold"�6?   �� 5  "   	 � ��#
 �   6=   �� 5  "   	 � ��#
 �  6?   �� 5  "   	 � ��#
 �  6?   �� 5	  "   	 � ��#
 �  6@   �� 5
  "   	 � ��#
 �  6?   �� 5  "   	 � ��$	
 5,6q�6<   �� 5  "   	 � ��$
 1q�6D   �� 5  "   	 � ��
 5  &   �� 5  *   " ��6:   .R�5  .   � .+�5  2   �� $ 
Background��69   #��z��6M    6w   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+�� 5  2   $ Border��69   #��z��6I   #��z��6u   # z 6;  ��6�   Z�  6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6;  �� 5  2   $ DisabledVisualElement��69   #���  6X    .  $ 0Q�6"  # z 6.   6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6.    5  2   $ PART_ContentPresenter��6J   #��z��6�   #��z��6   # z 6D  #��z��6�  #��z��6�   . # z 6	  #��z��6E   6i   �� *0.(Custom:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6E  5  /    5  .   P� 5  2    �@J�IsMouseOver . . �5  6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5  6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5  6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5  3   P� 5  2    � �� . . �5  6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5  6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5   6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5!  3   P� 5"  2    �@J�IsKeyboardFocusWithin . . �5#  6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5$  6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5%  6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5&  3   P� 5'  2    � {� .  . �5(  6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.7Q�6s   �� 5)  6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   5*  3   5,  +   5.  #   5/     51     53     �� 54     -	   5        $ btnImprimer��54     $��20,0,0,0q�6*   $�� ��6<   $
��Left=�6G   #��� ��6b   $ Imprimer��6�   $��25��6�   $��25��6�   ��55     �� 56     $E ?/Medicus;component/Administrateur/Images/1456624510_printer.png��6!   ��58     �� 59     ��5;     �� 5<     " ��6    5=     �� 5>     " ��6$   .�5?  "   �� 	 �@ ContentCharacterCasing$
 Upper=�6a   �� 5@  "   	 �@ CornerRadius$
 3��6W   �� 5A  "   	 � ��$
 25��6>   �� 5B  "   	 � ��$

 Bold"�6?   �� 5C  "   	 � ��#
 �   6=   �� 5D  "   	 � ��#
 �  6?   �� 5E  "   	 � ��#
 �  6?   �� 5F  "   	 � ��#
 �  6@   �� 5G  "   	 � ��#
 �  6?   �� 5H  "   	 � ��$	
 5,6q�6<   �� 5I  "   	 � ��$
 1q�6D   �� 5J  "   	 � ��
 5K  &   �� 5L  *   " ��6:   .R�5M  .   � .+�5N  2   �� $ 
Background��69   #��z��6M    6w   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+�� 5O  2   $ Border��69   #��z��6I   #��z��6u   # z 6;  ��6�   Z�  6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6;  �� 5P  2   $ DisabledVisualElement��69   #���  6X    .  $ 0Q�6"  # z 6.   6�   �� *&$(Custom:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6.    5Q  2   $ PART_ContentPresenter��6J   #��z��6�   #��z��6   # z 6D  #��z��6�  #��z��6�   . # z 6	  #��z��6E   6i   �� *0.(Custom:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6E  5R  /    5S  .   P� 5T  2    �@J�IsMouseOver . . �5V  6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5W  6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5X  6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5Y  3   P� 5Z  2    � �� . . �5[  6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5\  6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5]  6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5^  3   P� 5_  2    �@J�IsKeyboardFocusWithin . . �5`  6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5a  6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   �� 5b  6   $ 
Background��6P   	 �@J�Opacity$	
 0.3Q�6h   5c  3   P� 5d  2    � {� .  . �5e  6   �� $ DisabledVisualElement��6P   	 �@J�Opacity$	
 0.7Q�6s   �� 5f  6   $ PART_ContentPresenter��6P   	 �@J�Opacity$	
 0.3Q�6s   5g  3   5i  +   5k  #   5l     5n     5p     5t     5u     5w     %  DevExpress.Xpf.Grid.GridControl  5x  
   -
   5           Name$  PatientDataGrid��5x     $��1��6g   $��0q�6�   $��2��6�   $��Tahoma)�6�   !   
Background#! � ��6�   )  #DevExpress.Xpf.Grid.DataControlBase"   SelectionMode$
" None=�6A  #   ItemsSource# 6t   �� $   View$ 5y     #  DevExpress.Xpf.Grid.TableView  5z     &	   DevExpress.Xpf.Grid.DataViewBase% 	  AllowEditing% .  &
   DevExpress.Xpf.Grid.GridViewBase& 
  AllowGrouping& .  ' 	  AllowColumnMoving' .  ( 	  AllowSorting( .  )   AllowFixedGroups] YDevExpress.Data.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5  /DevExpress.Utils.Design.DefaultBooleanConverter$) False 6z   * 
  ShowGroupPanel* .  "+   ShowCriteriaInAutoFilterRow+ .  6�   ,   Columns, 5|     $  DevExpress.Xpf.Grid.GridColumn  5}     $  DevExpress.Xpf.Grid.BaseColumn-   Header)  #DevExpress.Xpf.Core.ObjectConverter$- 	Compte OP 6!   .   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$
. Auto 5~  '   /   MinWidth$/ 50��65   $  DevExpress.Xpf.Grid.ColumnBase0   Binding0 6   �� *CompteDébité+65     5     $- Date de Saisie 6!   $
. Auto 5�  D   $/ 50��6R   0 6   �� *
DateSaisie+1 �� StringFormat$1 {0:dd/MM/yyyy}��6R     5�     $- Date Opération 6!   $
. Auto 5�  C   $/ 50��6Q   0 6   �� *	DateDebit+$1 {0:dd/MM/yyyy}��6Q     5�     $- Rubrique 6%   $
. Auto 5�  ,   $/ 50��69   0 6   �� *RubriqueComptable+69     5�     $- Paiement 6!   $
. Auto 5�  '   $/ 50��65   0 6   �� *ModePaiement+65     5�     $- Commentaire 6!   $
. Auto 5�  '   $/ 50��65   0 6   �� *Commentaires+65     5�     $- Débit 6!   $
. Auto 5�  "   $/ 50��60   0 6   �� *	Montant+60     5�     $- Crédit 6!   $
. Auto 5�  (   $/ 50��65   0 6   �� *MontantCrédit+65     5�     $- N° facture 6!   $
. Auto 5�  &   $/ 50��64   0 6   �� *Num_Facture+64     5�     $- 
N° Cheque 6!   $
. Auto 5�  $   $/ 50��62   0 6   �� *	NumCheque+62     5�     $- UserName 6!   $
. Auto 5�  #   $/ 50��62   0 6   �� *
Username+62     5�     $
- Auto 6!   $
. Auto 5�     $/ 50��6-   0 6   �� *Auto+6-   5�     ]� 5�  
   -   5        2 ]�Name$2 appBar��5�     $��2��6$   $��Stretch=�61   $��Stretch=�6M   #��� ��6k   .+�5�     � $��Center=�6   $��Stretch=�6.     5�     �� 5�     $��1* �6$    5�     �� 5�     $
��1.5* �6'   �� 5�     �� 5�     �� 5�     .+�5�     �� $��Total Crédits : ��6   $��Center=�63   $
��Left=�6N   $��0q�6i   $��14(�6t   $��Tahoma)�6�   $
��Bold"�6�   #��� ��6�   $��2��6�   �� 5�     $��Total Débits : ��6   $��Center=�62   $
��Left=�6M   $��0q�6h   $��Tahoma)�6s   $
��Bold"�6�   $��14(�6�   #��� ��6�   $��1��6�   �� 5�     -   5        3 ��Name$3 
TxtCreebit��5�     $��Center=�6.   4 �� 
IsReadOnly4 . {�.  $
��Left=�6v   $��Center=�6�   $��	100,0,0,0q�6�   $��Right=�6�   #��� ��6�   ���	#FFB27300$��3q�6@  $��Tahoma)�6T  $��14(�6h  $
��Bold"�6v  #��� ��6�  $��2��6�  $	��150��6�  $��25��6�  �� 5�     -   5        $3 txtDebit��5�     $��Center=�6,   4 . {�.  $
��Left=�6u   $��Center=�6�   $��Right=�6�   #��� ��6�   ���	#FFB27300$��3q�6-  $��	100,0,0,0q�6A  $��Tahoma)�6T  $��14(�6h  $
��Bold"�6v  #��� ��6�  $��1��6�  $	��150��6�  $��25��6�  �� 5�     $��Solde :��6   $
��Left=�6*   $��0q�6E   $��Tahoma)�6P   $
��Bold"�6d   $��Center=�6v   $��14(�6�   #��� ��6�   $��3��6�   �� 5�     -   5        $3 txtSolde��5�     {�.  $��Center=�6>   4 . $
��Left=�6u   $��Center=�6�   $��Right=�6�   #��� ��6�   ���	#FFB27300$��3q�6,  $��16(�6@  $��Tahoma)�6N  $
��Bold"�6b  #��� ��6t  $��3��6�  $��80,0,0,0q�6�  $	��150��6�  $��25��6�  �� 5�     -   5        5 ��Name$5 label��5�     $��	Trouver :��6+   $
��Left=�6<   $��Center=�6W   $
��Bold"�6r   $��16(�6�   $��20,0,0,0q�6�   $��Tahoma)�6�   #��� ��6�   %  DevExpress.Xpf.Editors.TextEdit  5�     -   5        6  Name$6 txtRecherche��5�     $
��Left=�65   $��Center=�6P   $��	120,0,0,0q�6k   $	��150��6~   #��� ��6�   #��� ��6�   $��Tahoma)�6$  $��14(�68  ���	#FFB273006r  5�     5�     5�     5�     