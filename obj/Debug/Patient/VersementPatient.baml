   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   .   B >Medicus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Medicus.PatientMedicus.Patient 5   	   &    Medicus.Patient.VersementPatient   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aJ 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   .   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Medicus.Patient     5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5	      &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  Office2010Black 5
       � Title$ Liste des versments��5   	   $	��550��6%   $	��900��62    � 
ResizeMode$ 	CanResize=�6>   #��� ��6V   "  DevExpress.Xpf.Core.DXWindow   ShowIcon .    	ShowTitle .  � WindowStyle$ ThreeDBorderWindow=�6�    � Icon$" /Medicus;component/Dent6.ico��6�    � WindowStartupLocation$ CenterScreen=�6
  $��0q�60  #��� ��6E   � ShowInTaskbar . .��5      � 	 � RowDefinitions	 5   
   �� 5      $
��50px �6   �� 5      .+�5   
   ]� $��15,6,6,4q�6   $
��Auto=�6&   $��Disabled=�6X   .+�5      �� -   5        
 ��Name$
 btnSupp��5      $��Segoe UI)�6&   $��20,0,0,0q�6<   $�� ��6d   
��� ��� � ToolTip$ 	Supprimer��6�   $��25��6�   $��25��6�   ��5      �� 5       �� 
TargetType" ��6     �� BasedOn 5      �� 5   "   " ��6(   .�5   &   �� +   %MahApps.Metro.Controls.ControlsHelper �� Property �@ ContentCharacterCasing �� Value$ Upper=�6g   �� 5   &    �@ CornerRadius$ 3��6]   �� 5   &    � ��$ 25��6B   �� 5   &    � ��$
 Bold"�6C   �� 5   &    � ��   UpperCaseContentFontSize# �   6A   �� 5    &    � ��  DefaultFont# �  6C   �� 5!   &    � ��  GrayBrush10# �  6C   �� 5"   &    � ��  TextBoxBorderBrush# �  6D   �� 5#   &    � ��  	TextBrush# �  6C   �� 5$   &    � ��$	 5,6q�6@   �� 5%   &    � ��$ 1q�6H   �� 5&   &    � �� 5'   *   �� 5(   .    �� 
TargetType" ��6>   .R�5)   2   � .+�5*   6   ��  ��Name$ 
Background��6=   #��z��6Q    �� CornerRadius 6{   �� *(&(Controls:ControlsHelper.CornerRadius)+ �� Mode$ OneWay=� �� RelativeSource �� *TemplatedParent+�� 5+   6   $ Border��6=   #��z��6M   #��z��6y    J� SnapsToDevicePixels# z 6A  ��6�   Z�  6�   �� *(&(Controls:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6A  �� 5,   6   $ DisabledVisualElement��6=     ControlsDisabledBrush#���  6\    J� IsHitTestVisible .   J� Opacity$ 0Q�6(  # z 64   6�   �� *(&(Controls:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+64  -   'MahApps.Metro.Controls.ContentControlEx  5-   6     Name$ PART_ContentPresenter��6P   #��z��6�   #��z��6(   �� ContentStringFormat# z 6L  #��z��6�  #��z��6�     RecognizesAccessKey . # z 6  #��z��6M     ContentCharacterCasing 6o   �� *20(Controls:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6M  5.   3    �� Triggers 5/   2   P� 50   6    P� Property �@J�IsMouseOver P� Value . . �52   :   ��  �� 
TargetName$ DisabledVisualElement��6T    �@J�Opacity$	 0.3Q�6w   �� 53   :   $ PART_ContentPresenter��6T    �@J�Opacity$	 0.3Q�6w   �� 54   :   $ 
Background��6T    �@J�Opacity$	 0.3Q�6l   55   7   P� 56   6    � �� . . �57   :   �� $ DisabledVisualElement��6T    �@J�Opacity$	 0.3Q�6w   �� 58   :   $ PART_ContentPresenter��6T    �@J�Opacity$	 0.3Q�6w   �� 59   :   $ 
Background��6T    �@J�Opacity$	 0.3Q�6l   5:   7   P� 5;   6    �@J�IsKeyboardFocusWithin . . �5<   :   �� $ DisabledVisualElement��6T    �@J�Opacity$	 0.3Q�6w   �� 5=   :   $ PART_ContentPresenter��6T    �@J�Opacity$	 0.3Q�6w   �� 5>   :   $ 
Background��6T    �@J�Opacity$	 0.3Q�6l   5?   7   P� 5@   6    � {� .  . �5A   :   �� $ DisabledVisualElement��6T    �@J�Opacity$	 0.7Q�6w   �� 5B   :   $ PART_ContentPresenter��6T    �@J�Opacity$	 0.3Q�6w   5C   7   5E   /   5G   '   5H   #   5J      ��5L      �� 5M      ��5O      �� 5P        �� ImageSource$C  =/Medicus;component/Images/supprimer-dossier-icone-4934-64.png��6%   ! j� Stretch$! UniformToFill=�6q   5R      �� 5T      -   5        $
 btnImprimer��5T      $��20,0,0,0q�6*   $�� ��6<   $
��Left=�6G   
��� ���$ Imprimer��6�   $��25��6�   $��25��6�   ��5U      �� 5V      " ��6     5W      �� 5X   "   " ��6(   .�5Y   &   ��  �@ ContentCharacterCasing$ Upper=�6g   �� 5Z   &    �@ CornerRadius$ 3��6]   �� 5[   &    � ��$ 25��6B   �� 5\   &    � ��$
 Bold"�6C   �� 5]   &    � ��# �   6A   �� 5^   &    � ��# �  6C   �� 5_   &    � ��# �  6C   �� 5`   &    � ��# �  6D   �� 5a   &    � ��# �  6C   �� 5b   &    � ��$	 5,6q�6@   �� 5c   &    � ��$ 1q�6H   �� 5d   &    � �� 5e   *   �� 5f   .   " ��6>   .R�5g   2   � .+�5h   6   �� $ 
Background��6=   #��z��6Q    6{   �� *(&(Controls:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+�� 5i   6   $ Border��6=   #��z��6M   #��z��6y   # z 6A  ��6�   Z�  6�   �� *(&(Controls:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+6A  �� 5j   6   $ DisabledVisualElement��6=   #���  6\    .  $ 0Q�6(  # z 64   6�   �� *(&(Controls:ControlsHelper.CornerRadius)+$ OneWay=� �� *TemplatedParent+64    5k   6   $ PART_ContentPresenter��6P   #��z��6�   #��z��6(  # z 6L  #��z��6�  #��z��6�   . # z 6  #��z��6M   6o   �� *20(Controls:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+6M  5l   3    5m   2   P� 5n   6    �@J�IsMouseOver . . �5p   :   �� $ DisabledVisualElement��6T    �@J�Opacity$	 0.3Q�6w   �� 5q   :   $ PART_ContentPresenter��6T    �@J�Opacity$	 0.3Q�6w   �� 5r   :   $ 
Background��6T    �@J�Opacity$	 0.3Q�6l   5s   7   P� 5t   6    � �� . . �5u   :   �� $ DisabledVisualElement��6T    �@J�Opacity$	 0.3Q�6w   �� 5v   :   $ PART_ContentPresenter��6T    �@J�Opacity$	 0.3Q�6w   �� 5w   :   $ 
Background��6T    �@J�Opacity$	 0.3Q�6l   5x   7   P� 5y   6    �@J�IsKeyboardFocusWithin . . �5z   :   �� $ DisabledVisualElement��6T    �@J�Opacity$	 0.3Q�6w   �� 5{   :   $ PART_ContentPresenter��6T    �@J�Opacity$	 0.3Q�6w   �� 5|   :   $ 
Background��6T    �@J�Opacity$	 0.3Q�6l   5}   7   P� 5~   6    � {� .  . �5   :   �� $ DisabledVisualElement��6T    �@J�Opacity$	 0.7Q�6w   �� 5�   :   $ PART_ContentPresenter��6T    �@J�Opacity$	 0.3Q�6w   5�   7   5�   /   5�   '   5�   #   5�      ��5�      �� 5�      $;  5/Medicus;component/Images/imprimer-icone-5268-128.png��6%   ��5�      �� 5�      5�      �� 5�      -   5        " ��Name$" label��5�      $��	Trouver :��6'   $
��Left=�68   $��Center=�6S   $
��Bold"�6n   $��16(�6�   $��20,0,0,0q�6�   $��Tahoma)�6�   #��� ��6�   �� 5�      -   5        # ��Name$# txtRecherche��5�      $
��Left=�6,   $��Center=�6G   $��15,0,0,0q�6b   $	��200��6t   $ �� SelectionBrush$ �	#FFB273006�   �� 5�      -   5        % ��Name$% labelFournisseur��5�      
��� ���$��Center=�6F   $��Center=�6a   $��22(�6~   $
��Bold"�6�   5�      &   System.Windows.Controls.DataGrid  5�   
   -   5        &  Name$& FournDataGrid��5�      $��1��6*   '   AutoGenerateColumns' .  $��
15,1,25,19q�6k   (   
IsReadOnly( .  ) �� IsTextSearchCaseSensitive) . #��� ��6�   ��6S   �� *   ColumnHeaderStyle* 5�      �� 5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5�      ��  �@ ContentCharacterCasing$ Normal=�6[   �� 5�       � ��$ SemiBold"�67   �� 5�       �@J�SnapsToDevicePixels . 6@   �� 5�       � ��$ 0��65   �� 5�       � ��$ 25��66   �� 5�       � ��  
BlackBrush# �  67   �� 5�       �@�Cursor$
 Hand��63   �� 5�       � ��$
 Left=�6G   �� 5�       � ��$ Center=�6E   �� 5�       � ��$ 10,4,4,7q�64   �� 5�       � ��$ 0q�63   �� 5�       � ��$ 0,0,0,3q�6<   �� 5�       � ��  
GrayBrush5# �  68   �� 5�       � ��  
GrayBrush8# �  67   �� 5�       � �� 5�      �� 5�   "   "  62   .R�5�   &   � + � ColumnDefinitions+ 5�   *   �� 5�   .   $��* �6?   �� 5�   .   $
��Auto �6?   .+�5�   *   �� $ BackgroundBorder��61   #��z��6K   #��z��6w   #��z��6�   $��2��6�     5�   *   $ HeaderContent��6D   #��z��6�   #��z��6  # z 68  #��z��6t  #��z��6�   . # z 6�  #��z��69   6[   �� *20(Controls:ControlsHelper.ContentCharacterCasing)+ �� *TemplatedParent+69  F� 5�   *   , F�Name$, 	SortArrow��6/   $��1��6B    	 
GrayBrush2#��� 	 6R   $��10��6v   $��0,0,8,2q�6�   - J� RenderTransformOrigin$- 0.5,0.5&�6�   . �� Stretch$
. Fill=�6�   $y�	Collapsed=�6�   $��Center=�6�   $��8��6�   n� 5�   *   / n�Name$/ PART_LeftHeaderGripper��60   
������ $
��Left=�6i   $
��Left=�6�   ��5�   .   �� 5�   2   " n�68   .�5�   6   ��  � ��$ 8��6N   �� 5�   6    � ��# �  6S   �� 5�   6    �@�Cursor$ SizeWE��6O   �� 5�   6    � �� 5�   :   �� 5�   >   " n�6N   .R�5�   B   �� 
������ 0 �� Padding#0 z��6b   ._�5�   F   �� #��z��6P   #��z��6t   $��1��6�   5�   C   5�   ?   5�   7   5�   3   5�   +   n� 5�   *   $/ PART_RightHeaderGripper��60   $��1��6Q   $��Right=�6a   $��Right=�6}   ��5�   .   �� 5�   2   " n�68   .�5�   6   ��  � ��$ 8��6N   �� 5�   6    � ��# �  6S   �� 5�   6    �@�Cursor$ SizeWE��6O   �� 5�   6    � �� 5�   :   �� 5�   >   " n�6N   .R�5�   B   �� 
������ #0 z��6b   ._�5�   F   �� #��z��6P   #��z��6t   $��1��6�   5�   C   5�   ?   5�   7   5�   3   5�   +   5�   '    5�   &   P� 5�   *    6K   Z�  �@ SortDirection. �5�   .   �� $ BackgroundBorder��6K    
 
WhiteBrush# � 
 6i    � ��5�   +   ]� 5�   *   1 ]� 
Conditions1 5�   .   �� 5�   2   2 �� Property2 �@J�IsMouseOver3 �� Value3 . 6S   �� 5�   2   3 6U   Z� 2 �@ SortDirection./�5�   .   �� $ BackgroundBorder��6K   # �  6i    � ��5�   +   P� 5�   *    �@ SortDirection$ 	AscendingX�6K   . �5�   .   �� $ 	SortArrow��6K    � y�$ Visible=�6b   �� 5�   .   $ 	SortArrow��6E    � ��a ����@�eрހ@�eрހ��� u��� upw�р�C��� 6npw�� 6n��р���р�@�e6\   5�   +   P� 5�   *    �@ SortDirection$ 
DescendingX�6K   . �5�   .   �� $ 	SortArrow��6K    � y�$ Visible=�6b   �� 5�   .   $ 	SortArrow��6E    � ��a ���ހ��!р���!р�8��� 6n��� 6nX4�р�C��x� uX4�� u��рހ8��рހ��!6\   �� 5�   .   $ 	SortArrow��6G    � ��$ 0,0,8,0q�6^   5�   +   P� 5�   *    �@ DisplayIndex$ 0��6J   . �5�   .   �� $ PART_LeftHeaderGripper��6K    � y�$ 	Collapsed=�6o   5�   +   P� 5�   *    � {� .  . �5�   .   �� # � ��6K    � ��5�   +   5�   #   5�      5�      4   Columns4 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn5 	  Header$
5 Code��6%   6 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
6 Auto
 5�   %   7 	  CanUserSort7 . 8   
FontFamily$8 Tahoma)�6E   9 	  
IsReadOnly9 . : 	  MinWidth$: 50Q�6k   ;   FontSize$; 12Q�6y   1  +System.Windows.Controls.DataGridBoundColumn<   Binding< 6   �� *Id+6y     5�      $
5 date��6%   $
6 Auto
 5�   '   7 . $8 Tahoma)�6G   9 . $: 50Q�6m   $; 12Q�6{   < 6   �� *date+6{     5�      $5 	Versement��6%   $
6 Auto
 5�   *   7 . $8 Tahoma)�6J   9 . $: 50Q�6p   $; 12Q�6~   < 6   �� *	montant+6~     5      $5 Paiement��6%   $
6 Auto
 5  (   7 . $8 Tahoma)�6H   9 . $: 50Q�6n   $; 12Q�6|   < 6   �� *paiem+6|     5     $
5 Oper��6%   $
6 Auto
 5  '   7 . $8 Tahoma)�6G   9 . $: 50Q�6m   $; 12Q�6{   < 6   �� *oper+6{     5     $5 dates��6%   $
6 Auto
 5  (   7 . $8 Tahoma)�6H   9 . $: 50Q�6n   $; 12Q�6|   < 6   �� *dates+6|     5     $5 Compte Débité��6%   $
6 Auto
 5  )   7 . $8 Tahoma)�6I   9 . $: 50Q�6o   $; 12Q�6}   < 6   �� *banque+6}     5     $5 nfact��6%   $
6 Auto
 5	  (   7 . $8 Tahoma)�6H   9 . $: 50Q�6n   $; 12Q�6|   < 6   �� *nfact+6|     5
     $5 Montant Facture��6%   $
6 Auto
 5  +   7 . $8 Tahoma)�6K   9 . $: 50Q�6q   $; 12Q�6   < 6   �� *
amontant+6     5     $	5 cle��6%   $
6 Auto
 5  &   7 . $8 Tahoma)�6F   9 . $: 50Q�6l   $; 12Q�6z   < 6   �� *cle+6z     5     $5 Multiple��6)   $
6 Auto
 5  +   7 . $8 Tahoma)�6K   9 . $: 50Q�6q   $; 12Q�6   < 6   �� *
Multiple+6   5     5     5     