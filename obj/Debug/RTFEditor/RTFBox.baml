   M S B A M L   `   `   `  ����B  >Medicus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Medicus.RTFEditorMedicus.RTFEditor  5          Medicus.RTFEditor.RTFBox   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aJ 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      5	RTFEditorclr-namespace:Medicus.RTFEditor     5      -   5          >�Name$  	RTFEditor��5	       � 	Resources 5         FontListKlasse S� 
ObjectType   Medicus.RTFEditor.FontList  FontHeightKlasse"  Medicus.RTFEditor.FontHeight��%D   &	        &	      S� 5   
   "  6J   S� 5   
   "  6L   5      .��5      ]� .+�5   
   c� -   5         c�Name$ ToolBarOben��5      $	��Top=�6'   .@�5      �� -   5         ��Name$ ToolStripButtonOpen��5      .��5      �� $��Images\Open.png��6   $
��None=�6%   5      �� 5      -   5        $ ToolStripButtonPrint��5      .��5      �� $��Images\Print.png��6   $
��None=�6&   5      �� 5      �� 5      -   5        $ ToolStripButtonCut��5      $��ApplicationCommands.Cut��6(    � ToolTip$	 Cut��6J   .��5      �� $��Images\Cut.png��6   $
��None=�6$   5      �� 5      -   5        $ ToolStripButtonCopy��5      $��ApplicationCommands.Copy��6)   $
 Copy��6L   .��5      �� $��Images\Copy.png��6   $
��None=�6%   5      �� 5       -   5        $ ToolStripButtonPaste��5       $��ApplicationCommands.Paste��6*   $ Paste��6N   .��5!      �� $��Images\Paste.png��6   $
��None=�6&   5"      �� 5#      -   5        $ ToolStripButtonUndo��5#      $��ApplicationCommands.Undo��6)   $
 Undo��6L   .��5$      �� $��Images\Undo.png��6   $
��None=�6%   5%      �� 5&      -	   5        $ ToolStripButtonRedo��5&      $��ApplicationCommands.Redo��6)   $
 Redo��6L   .��5'      �� $��Images\Redo.png��6   $
��None=�6%   5(      �� 5)      �� 5*      -
   5         ��Name$ Fonttype��5*      ��6    ��  �� Mode$ OneWay=� �� Source# [  6l   �� 5+      -   5        $ 
Fontheight��5+      ��6+   �� $ OneWay=�# [ 6z   5,      c� 5-   
   -   5        $ ToolBarUnten��5-      $	��Top=�6(   .@�5.      d� -   5        	 d�Name$	 ToolStripButtonBold��5.      $ ��EditingCommands.ToggleBold��65   $
 Bold��6Z   .��5/      �� $��Images\Bold.png��6   $
��None=�6+   50      d� 51      -   5        $	 ToolStripButtonItalic��51      $"��EditingCommands.ToggleItalic��67   $ Italic��6^   .��52      �� $��Images\Italic.png��6   $
��None=�6-   53      d� 54      -   5        $	 ToolStripButtonUnderline��54      $%��EditingCommands.ToggleUnderline��64   $ 	Underline��6^   .��55      �� $��Images\Underline.png��6   $
��None=�60   56      d� 57      -   5        $	 ToolStripButtonStrikeout��57      $ 	Strikeout��64   .��58      �� $��Images\Strikeout.png��6   $
��None=�60   59      �� 5:      �� 5;      -   5        $ ToolStripButtonTextcolor��5;      .��5<      �� $��Images\Textcolor.png��6   $
��None=�60   5=      �� 5>      -   5        $ ToolStripButtonBackcolor��5>      .��5?      �� $��Images\Backcolor.png��6   $
��None=�60   5@      �� 5A      d� 5B      -   5        $	 ToolStripButtonAlignLeft��5B      $��EditingCommands.AlignLeft��6:   $ 
Align Left��6^   .��5C      �� $��Images\AlignLeft.png��6   $
��None=�60   5D      d� 5E      -   5        $ 	 ToolStripButtonAlignCenter��5E      $!��EditingCommands.AlignCenter��66   $ Align Center��6\   .��5F      �� $��Images\AlignCenter.png��6   $
��None=�62   5G      d� 5H      -   5        $	 ToolStripButtonAlignRight��5H      $ ��EditingCommands.AlignRight��65   $ Align Right��6Z   .��5I      �� $��Images\AlignRight.png��6   $
��None=�61   5J      �� 5K      �� 5L      -   5        $ ToolStripButtonBulletList��5L      $#��EditingCommands.ToggleBullets��6/   $ Bullets��6W   .��5M      �� $��Images\BulletList.png��6   $
��None=�61   5N      �� 5O      -   5        $  ToolStripButtonNumbersList��5O      $%��EditingCommands.ToggleNumbering��60   $ Numbers��6Z   .��5P      �� $��Images\NumbersList.png��6   $
��None=�62   5Q      �� 5R      �� 5S      -   5        $ ToolStripButtonIndent��5S      $)��#EditingCommands.IncreaseIndentation��6+   $ Increase Indent��6Y   .��5T      �� $��Images\Indent.png��6   $
��None=�6-   5U      �� 5V      -   5        $! ToolStripButtonIndentDelete��5V      $)��#EditingCommands.DecreaseIndentation��61   $ Decrease Indent��6_   .��5W      �� $��Images\IndentRemove.png��6   $
��None=�63   5X      �� 5Y      d� 5Z      -   5        $	 ToolStripButtonSubscript��5Z      $ 	Subscript��64   .��5[      �� $��Images\Subscript.png��6   $
��None=�60   5\      d� 5]      -   5        $ 	 ToolStripButtonSuperscript��5]      $ Superscript��66   .��5^      �� $��Images\Superscript.png��6   $
��None=�62   5_      5`      �� 5a   
   -   5        
 ��Name$
 	StatusBar��5a      $y�	Collapsed=�6'   $��Bottom=�6>   .@�5b      �� .��5c      �� -   5         ��Name$ LabelZeileNr��5c      $��ZeileNr��6.   $��1q�6@   
�������6T   5d      �� 5e      .��5f      �� -   5        $ LabelSpalteNr��5f      $��SpalteNr��6/   $��1q�6B   
�������6V   5g      �� 5h      .��5i      �� -   5        $ 
LabelEinfg��5i      $��Einfg��6,   $��1q�6<   
�������6P   5j      �� 5k      $��Right=�6   $	��100��63   .��5l      �� -    5         ��Name$ 
SliderZoom��5l      $��1��6-   $	��100��6=    �� Ticks$# 1, 2, 3, 4, 5, 6, 7, 8, 9, 10R�6I    � Value$ 1Q�6o    �� Delay$	 100��6y    �� Interval$ 5��6�    �� TickPlacement$ BottomRight=�6�    � Minimum$ 1Q�6�    � Maximum$ 10Q�6�   $
��Left=�6�   5m      5n      �� 5o   
   -!   5         ��Name$ RichTextControl��5o       �� 	IsEnabled . " �� VerticalScrollBarVisibility$
 Auto=�6K    �� AcceptsReturn .  �� 
AcceptsTab . $��Stretch=�63  $��Stretch=�6X  . �5p      /�  � 	Resources 5q       �� 
TargetType �� Property �� Value��%X   'J�       �� 5s      " J�6   .�5t      ��  �@��Margin$ 0q�63   5u      5v      .T�5w      J� .*�6   .*�5x      6�  6� Width$ 504�6    6� Height$ 04�6*    6� HorizontalAnchor$ 
ColumnLeft=�65     6� VerticalAnchor$  PageTop=�6S   ��5y      �� 5z      -"   5        	imagelogo��! �� ImageSource$D! >/Medicus;component/Images/021_medical-symbol-free-vector-l.png��5z   <   $��RightToLeft=�6�   5}       �� 5      -#   5        $ txtTitre��5      $)��#CABINET MEDICAL DE LA PETITE FORET ��6/   $��Century Schoolbook)�6]   $��20(�6}   $
��Bold"�6�   $
��Left=�6�   5�      J� 5�      " �� Margin$" 10,0,Auto,Autoq�6   .*�64   .*�5�      �� -$   5        $ 	txtTitre1��5�      $%��2,RUE DE PHALSBOURG 75017 PARIS��60   $��Century Schoolbook)�6Z   $��12(�6z   $
��Bold"�6�   $
��Left=�6�   5�      J� 5�      $" 65,0,Auto,Autoq�6   .*�64   .*�5�      �� -%   5        $ 	txtTitre2��5�      $-��'Tél : 03 02 20 54 08 R.D.V ET URGENCES��6,   $��Century Schoolbook)�6]   $��12(�6}   $
��Bold"�6�   $
��Left=�6�   5�      5�      5�      5�      5�      