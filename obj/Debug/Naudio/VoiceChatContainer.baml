   M S B A M L   `   `   `  ����]  YEndless Development Project Studio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Chat_Pro_NCPChat_Pro_NCP  5      b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5      3    -NAudioDemo.NetworkChatDemo.VoiceChatContainer   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Chat_Pro_NCP     5      ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5        N� Title$  	VoicePage��5
       � 	Resources 5         ComboBox.Static.Background �� EndPoint �� 
StartPoint � Color � Offset  ComboBox.Static.Border �� Color ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background * &ComboBox.Static.Editable.Button.Border  ComboBox.MouseOver.Glyph ! ComboBox.MouseOver.Background  ComboBox.MouseOver.Border *	 &ComboBox.MouseOver.Editable.Background &
 "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Glyph  ComboBox.Pressed.Background  ComboBox.Pressed.Border ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border  ComboBox.Disabled.Glyph   ComboBox.Disabled.Background  ComboBox.Disabled.Border ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBox.Static.Glyph  ComboBoxToggleButton �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name J� SnapsToDevicePixels F�Name �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� 
TargetName P� Property P� Value  ComboBoxTemplate �Name � ColumnDefinitions �Name � AllowsTransparency �� Mode5  /Microsoft.Windows.Themes.SystemDropShadowChrome  Name   Color �� MaxDropDownHeight �� ElementName  ��Name! �� ClearTypeHint" ��Name# ��Name$ ��Name-  'System.Windows.Input.KeyboardNavigation%   DirectionalNavigation& d�Name' d� 	IsChecked( ��Name) �� SelectionBoxItemTemplate* �� SelectionBoxItem#+ �� SelectionBoxItemStringFormat, �� ContentStringFormat- J� IsHitTestVisible. P� 
SourceName/ ]� 
Conditions0 �� Property  TextBox.Static.Background  ComboBoxEditableTextBox   ComboBoxEditableTemplate1 ��Name2 �� 
IsReadOnly ! ComboBoxStyle1 " FocusVisual3 �� Triggers # ListBox.Static.Background $ ListBox.Static.Border % ListBox.Disabled.Background & ListBox.Disabled.Border ' ListBoxStyle14 �� Padding5 J� Effect3  -System.Windows.Media.Effects.DropShadowEffect6   ShadowDepth7   Opacity��%2  &	        &	 �     &	 �     &	 �     &	     &	 *    &	 O    &	 r    &	     &		 1    &	
 T    &	 w    &	     &	 6    &	 Y    &	 �    &	     &	 ;    &	 ^    &	 �    &	     &	 @    &	 c    &	 �    &	 �    &	 �    &	 �    &	     &	 9    7   7  7  7  7  7  7  7  7  7  7 	 7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 \    7  &	 �    &	 �    &	      7  7  7  &	! �(    7 " 7  7  7   &	# 8+    &	$ [+    &	% ~+    &	& �+    &	' �+    7 # 7 $ 7 % 7 & �� 5   
   $	 0,1&�6A   $	 0,0&�6P   .��5      � $ 	#FFF0F0F0��6   $	 0.0Q�6-   � 5      $ 	#FFE5E5E5��6   $	 1.0Q�6-   5      �� 5   
   $ 	#FFACACAC��69   �� 5   
   $ 	#FFFFFFFF��6F   �� 5   
   $ 	#FFABADB3��6B   �� 5   
   $ Transparent��6M   �� 5   
   $ Transparent��6I   �� 5   
   $ 	#FF000000��6;   �� 5   
   $	 0,1&�6D   $	 0,0&�6S   .��5      � $ 	#FFECF4FC��6   $	 0.0Q�6-   � 5      $ 	#FFDCECFC��6   $	 1.0Q�6-   5      �� 5   
   $ 	#FF7EB4EA��6<   �� 5   
   $ 	#FFFFFFFF��6I   �� 5   
   $ 	#FF7EB4EA��6E   �� 5   
   $	 0,1&�6T   $	 0,0&�6c   .��5       � $ 	#FFEBF4FC��6   $	 0.0Q�6-   � 5!      $ 	#FFDCECFC��6   $	 1.0Q�6-   5"      �� 5#   
   $ 	#FF7EB4EA��6L   �� 5$   
   $ 	#FF000000��69   �� 5%   
   $	 0,1&�6B   $	 0,0&�6Q   .��5&      � $ 	#FFDAECFC��6   $	 0.0Q�6-   � 5'      $ 	#FFC4E0FC��6   $	 1.0Q�6-   5(      �� 5)   
   $ 	#FF569DE5��6:   �� 5*   
   $ 	#FFFFFFFF��6G   �� 5+   
   $ 	#FF569DE5��6C   �� 5,   
   $	 0,1&�6R   $	 0,0&�6a   .��5-      � $ 	#FFDAEBFC��6   $	 0.0Q�6-   � 5.      $ 	#FFC4E0FC��6   $	 1.0Q�6-   5/      �� 50   
   $ 	#FF569DE5��6J   �� 51   
   $ 	#FFBFBFBF��6:   �� 52   
   $ 	#FFF0F0F0��6?   �� 53   
   $ 	#FFD9D9D9��6;   �� 54   
   $ 	#FFFFFFFF��6H   �� 55   
   $ 	#FFBFBFBF��6D   �� 56   
   $ Transparent��6O   �� 57   
   $ Transparent��6K   �� 58   
   $ 	#FF606060��68   �� 59   
   " d�6-   .�5:      ��  �@�OverridesDefaultStyle	 . 66   �� 5;       � ��	 .  6*   �� 5<       � |�	 .  6*   �� 5=       �@��	ClickMode$	 Press=�6*   �� 5>       � ��	 5?      �� 5@      "
 d�6&   .R�5A      �� $ templateRoot��6!    . 8��  #��z��6�   8�� ._�5B      �� $ splitBorder��6%   #��� r�6:    . $��0q�6�   $��Right=�6�   $��1q�6�   
������ ._�5C   "   F� $ arrow��6'   $��Center=�66   $��0q�6Q   $��Center=�6\   8�� F����        ���( ��( јaQ     јaQ P����̰( � �    P����        6�   5D      5E       5F      ^� 5G       5H   "   �� 5I   &    60   �� *
IsEditable+ �� " �� true6�   �� 5J   &    60   �� *IsMouseOver+ �� *Self+	 false6v   �� 5K   &    60   �� *	IsPressed+ �� *Self+	 false6t   �� 5L   &    60   �� *	IsEnabled+ �� *Self+ true6t   .0�5N   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5O   "   $ templateRoot��6@   8	   � ��6Z   �� 5P   "   $ splitBorder��6?   8	   � ��6X   �� 5Q   "   $ splitBorder��6@   8	   � ��6Y   5R      P� 5S       �@J�IsMouseOver . . �5T   "   �� $ arrow��69   8	   � ��6L   5U      ^� 5V       5W   "   �� 5X   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5Y   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5[   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5\   "   $ templateRoot��6@   8	 	  � ��6Z   5]      ^� 5^       5_   "   �� 5`   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5a   &    60   �� *
IsEditable+ �� " �� true6�   .0�5c   "   �� $ templateRoot��6?   8	 
  � ��6Y   �� 5d   "   $ templateRoot��6@   8	   � ��6Z   �� 5e   "   $ splitBorder��6?   8	   � ��6X   �� 5f   "   $ splitBorder��6@   8	   � ��6Y   5g      P� 5h       � �� . . �5i   "   �� $ arrow��69   8	   � ��6L   5j      ^� 5k       5l   "   �� 5m   &    60   �� *	IsPressed+ �� *Self+ true6t   �� 5n   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5p   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5q   "   $ templateRoot��6@   8	   � ��6Z   5r      ^� 5s       5t   "   �� 5u   &    60   �� *	IsPressed+ �� *Self+ true6t   �� 5v   &    60   �� *
IsEditable+ �� " �� true6�   .0�5x   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5y   "   $ templateRoot��6@   8	   � ��6Z   �� 5z   "   $ splitBorder��6?   8	   � ��6X   �� 5{   "   $ splitBorder��6@   8	   � ��6Y   5|      P� 5}       � {� .  . �5~   "   �� $ arrow��69   8	   � ��6L   5      ^� 5�       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5�   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5�   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5�   "   $ templateRoot��6@   8	   � ��6Z   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5�   &    60   �� *
IsEditable+ �� " �� true6�   .0�5�   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5�   "   $ templateRoot��6@   8	   � ��6Z   �� 5�   "   $ splitBorder��6?   8	   � ��6X   �� 5�   "   $ splitBorder��6@   8	   � ��6Y   5�      5�      5�      5�      �� 5�   
   "
 ��63   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5�        $ shadow��64   $ Transparent��6D   #��z 6X   ��6�   �� *ActualWidth+$ templateRoot��._�5�      �� $ dropDownBorder��6!   #��� ��69   $��1q�6�   #��� ��6�   ._�5�      �� $  DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $! Enabled=�65   .+�5�   &   �� $" canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $# 
opaqueRect��64   ��6H   �� *
Background+$ dropDownBorder����6�   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5�   '   �� 5�   &   $$ ItemsPresenter��65   $% 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $& toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  ' 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+66  �� 5�      $( contentPresenter��6#   #��z) 6=   #��z��6z   #��z* 6�   #, z+ 6�   #��z��6-  - .  #��z��6�  # z 6�  #��z��6�  5�       5�      P� 5�      $. 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/    � ��$	 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$	 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/    � ��$	 95��6K   5�      ]� 5�      / 5�      �� 5�      0 �@��
IsGrouping . 6:   �� 5�      "0 �@%�IsVirtualizingWhenGrouping .  6\   ./�5�      ��  � ��	 .  6F   5�      P� 5�      $. DropDownScrollViewer��6C    � �� .  . �5�      �� $ 
opaqueRect��63   	 6K   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��64   	 6L   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5�      5�      �� 5�   
   $ 	#FFFFFFFF��6<   �� 5�   
   " ��60   .�5�      ��  �@�OverridesDefaultStyle	 . 66   �� 5�       �@J�	AllowDrop	 . 6*   �� 5�       � ��$	 0��6)   �� 5�       � ��$	 0��6*   �� 5�       �@�FocusVisualStyle	 61   Z� �� 5�       �@��PanningMode$	 VerticalFirst=�69   �� 5�       �@��IsFlicksEnabled	 .  67   �� 5�       � ��	 5�      �� 5�      "
 ��6&   .R�5�      �� $  PART_ContentHost��6'   
������ |�.  $��Hidden=�6l   $��Hidden=�6�   5�      5�      5�      �� 5�   
   "
 ��6;   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+ �� *TemplatedParent+.��5�        $ shadow��64   $ Transparent��6D   #��z 6X   ��6�   �� *ActualWidth+$ templateRoot��._�5�      �� $ dropDownBorder��6!   #��� ��69   $��1q�6�   #��� ��6�   ._�5�      �� $  DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $! Enabled=�65   .+�5�   &   �� $" canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $# 
opaqueRect��64   ��6H   �� *
Background+$ dropDownBorder����6�   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5�   '   �� 5�   &   $$ ItemsPresenter��65   $% 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $& toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  ' 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+66  �� 5�      $ border��6   8�� #��z��6a   ._�5�      �� $1 PART_EditableTextBox��6   #��z��6<   #��z��6�   8�� #��z��6-  2 6�   �� *
IsReadOnly+ �� *TemplatedParent+6-  5�      5�       5�      P� 5�       � {� .  . �5�      �� $ border��60    �@J�Opacity$
	 0.56Q�6D   5�      P� 5�       �@J�IsKeyboardFocusWithin . . �5�      ��  � ��
	 �   �63   5�      P� 5�      $. 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/    � ��$	 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$	 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/    � ��$	 95��6K   5�      ]� 5�      / 5�      �� 5�      0 �@��
IsGrouping . 6:   �� 5�      "0 �@%�IsVirtualizingWhenGrouping .  6\   ./�5      ��  � ��	 .  6F   5     P� 5     $. DropDownScrollViewer��6C    � �� .  . �5     �� $ 
opaqueRect��63   	 6K   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5     $ 
opaqueRect��64   	 6L   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5     5     �� 5  
   " ��6'   .�5	     ��  �@�FocusVisualStyle8	   61   �� 5
      � ��	 �#1e1e1e6+   �� 5      � ��8	  6,   �� 5      � ��
	 �   �6+   �� 5      � ��$	 1q�60   �� 5      � ��$
	 Auto=�6K   �� 5      � ��$
	 Auto=�6I   �� 5      � ��$	 6,3,5,3q�6(   �� 5      � ��	 . 6>   �� 5      �@��PanningMode$
	 Both=�69   �� 5      �@��IsFlicksEnabled	 .  67   �� 5      � ��8	  6)   3 5     P� 5      �@��
IsEditable . . �5     ��  � ��	 .  62   �� 5      � ��$	 2q�60   �� 5      � ��8	  61   5     5     �� 5  
   $ 	#ad36393d��6<   �� 5  
   $ 	#FF000000��68   �� 5   
   $ 	#FFFFFFFF��6>   �� 5!  
   $ 	#FFD9D9D9��6:   �� 5"  
   " ��6&   .�5#     ��  � ��8	   6+   �� 5$      � ��8	  6,   �� 5%      � ��$	 1q�60   �� 5&      � ��#	 � ��6+   �� 5'      � ��$	 Disabled=�6K   �� 5(      � ��$	 Disabled=�6I   �� 5)      � ��	 . 6>   �� 5*      �@��PanningMode$
	 Both=�69   �� 5+      �@��IsFlicksEnabled	 .  67   �� 5,      � ��$	 Center=�69   �� 5-      � ��	 5.     �� 5/     "
 ��6&   .R�50     �� $ Bd��6!   #��z��6-   #��z��6Y   #��z��6�   $4 1q�6�    . ._�51     �� |�.  #��z��6=   .��52  "   �� # z 61   53     5 54       55  "   $6 5Q�63   $	7 0.2Q�6C   58      59     P� 5:      � {� .  . �5;  "   �� $ Bd��6?   8	   � ��6O   �� 5<  "   $ Bd��6@   8	   � ��6P   5=     ]� 5>     / 5?  "   �� 5@  &   0 �@��
IsGrouping . 6F   �� 5A  &   "0 �@%�IsVirtualizingWhenGrouping .  6h   ./�5C  "   ��  � ��	 .  6R   5D     5F     5H     5I     5J     .��5K     � -   5        $��MainGrid��5K     ���	#ad1e1e1e8 � RowDefinitions8 5L  
   �� 5M     $��60 �6   �� 5N     $��60 �6   �� 5O     $��60 �6   �� 5P     $
��Auto �6   .+�5R  
   � $��1��6   8 5S     �� 5T     $��* �6    �� 5U     $��* �6     5W     �� 5X     $��40 �6#   �� 5Y     .+�5\     �� -   5        $��comboBoxProtocol��5\  '   $��1��6   #��� ! 6?   �� 5]     -   5        $��comboBoxInputDevices��5]  '   $��1��6   #��� ! 6C   $��1��6m   5^     � 5_  
   $��2��6   8 5`     �� 5a     $��* �6    �� 5b     $��* �6     5d     �� 5e     $��40 �6#   �� 5f     .+�5i     �� -   5        $��comboBoxCodecs��5i  '   $��1��6   #��� ! 6=   5k     �� 5l  
   -   5        9 ��Name$9 CommandEditList��5l  K   $��3��6   
�������$	��260��62   $	��200��6?   $	��Top=�6e   $��Right=�6}   #��� ' 6�   ��5m     �� 5n     .R�5o     � $	��0,2q�6    5p     �� 5q     $��* �6/   �� 5r     $��30 �6/   .+�5u     �� 
���������63   �� *	command+�� 5v     
�������$��1��63   ��6C   �� *commandindex+5x     5y     5{     � 5|  
    5}     �� 5~     $��5* �6#   �� 5     $��2* �6#   �� 5�     $��2* �6#   .+�5�     � .+�5�     (� .��5�     �� -   5        : ��Name$: UserNameLabel��5�  =   
�������$��18(�6/   $��Center=�6T   5�     5�     �� 5�     -   5        $��buttonStartStreaming��5�  ]   $��1��6   
�������
������ $��M��6Q   
������ 6�   �� 5�     -   5        $��turnOnOffHeadphone��5�  ]   $��2��6   
�������
������ $��H��6Q   
������ 6w   5�     5�     5�     