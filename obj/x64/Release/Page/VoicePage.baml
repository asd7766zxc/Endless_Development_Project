   M S B A M L   `   `   `  ���� ]  YEndless Development Project Studio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Chat_Pro_NCPChat_Pro_NCP  b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes     Chat_Pro_NCP.VoicePage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Chat_Pro_NCP     ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2       N� Title$  	VoicePage�� � 	Resources    ListBox.Static.Background �� Color  ListBox.Static.Border  ListBox.Disabled.Background  ListBox.Disabled.Border  ListBoxStyle1 �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Padding	 J� SnapsToDevicePixels
 J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value  ComboBox.Static.Background �� EndPoint �� 
StartPoint � Color � Offset  ComboBox.Static.Border ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border .	 *ComboBox.Static.Editable.Button.Background *
 &ComboBox.Static.Editable.Button.Border  ComboBox.MouseOver.Glyph ! ComboBox.MouseOver.Background  ComboBox.MouseOver.Border * &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Glyph  ComboBox.Pressed.Background  ComboBox.Pressed.Border ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border  ComboBox.Disabled.Glyph   ComboBox.Disabled.Background  ComboBox.Disabled.Border ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border   ComboBox.Static.Glyph ! ComboBoxToggleButton F�Name ^� 
Conditions �� Binding �� RelativeSource �� AncestorType " ComboBoxTemplate �Name � ColumnDefinitions �Name  � AllowsTransparency! �� Mode5  /Microsoft.Windows.Themes.SystemDropShadowChrome"  Name#   Color$ �� MaxDropDownHeight% �� ElementName& ��Name' �� ClearTypeHint( ��Name) ��Name* ��Name-  'System.Windows.Input.KeyboardNavigation+   DirectionalNavigation, d�Name- d� 	IsChecked. ��Name/ �� SelectionBoxItemTemplate0 �� SelectionBoxItem#1 �� SelectionBoxItemStringFormat2 �� ContentStringFormat3 J� IsHitTestVisible4 P� 
SourceName # TextBox.Static.Background $ ComboBoxEditableTextBox % ComboBoxEditableTemplate5 ��Name6 �� 
IsReadOnly & ComboBoxStyle1 ' FocusVisual7 �� Triggers��%�   &	        &	      &	 *     &	 ?     &	 T     7   7  7  7  &	 �    &	     &	     &	 +    &		 @    &	
 W    &	 n    &	 �    &	 �    &	 �    &	 �    &	     &	 Z    &	 k    &	 �    &	 �    &	 �    &	 �    &	 	    &	 [    &	 l    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	  �    &	!     7  7  7   7  7  7 	 7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	" B    7 ! &	#     &	$ $    &	% �    7 ! 7 $ &	& �    7 ' 7 " 7 % �� $ 	#ad36393F���� $ 	#FF000000���� $ 	#FFFFFFFF���� $ 	#FFD9D9D9���� " ��.���  � ��8   ��  � ��8  ��  � ��$ 1q���  � ��# � ����  � ��$ Disabled=���  � ��$ Disabled=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��$ Center=���  � �� �� " ��.R��� $ Bd��#��z��#��z��#��z��$ 1q�	 . ._��� |�.  #��z��.���� #	 z	 
   $ 5Q�$	 0.2Q� P�  � {� .  . ��� $ Bd��8   � ���� $ Bd��8   � ��]�  ��  �@��
IsGrouping . �� " �@%�IsVirtualizingWhenGrouping .  ./���  � �� .  �� $	 0,1&�$	 0,0&�.��� $ 	#AA1e1e1e��$	 0.0Q�� $ 	#AA1e1e1e��$	 1.0Q��� $ #0000���� $ 	#AA1e1e1e���� $ 	#FFABADB3���� $ Transparent���� $ Transparent���� $ 	#FF000000���� $	 0,1&�$	 0,0&�.��� $ #0000��$	 0.0Q�� $ #0000��$	 1.0Q��� $ #0000���� $ #0000���� $ #0000���� $	 0,1&�$	 0,0&�.��� $ #0000��$	 0.0Q�� $ #0000��$	 1.0Q��� $ #0000���� $ 	#FF000000���� $	 0,1&�$	 0,0&�.��� $ #0000��$	 0.0Q�� $ #0000��$	 1.0Q��� $ #0000���� $ #0000���� $ 	#FF569DE5���� $	 0,1&�$	 0,0&�.��� $ #0000��$	 0.0Q�� $ #0000��$	 1.0Q��� $ #0000���� $ 	#FFBFBFBF���� $ #0000���� $ 	#FFD9D9D9���� $ #0000���� $ 	#FFBFBFBF���� $ Transparent���� $ Transparent���� $ 	#FF606060���� " d�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  �@��	ClickMode$ Press=���  � �� �� " d�.R��� $ templateRoot��	 . 8��  #��z��8�� ._��� $ splitBorder��#��� r�	 . $��0q�$��Right=�$��1q�
������ ._�F� $ arrow��$��Center=�$��0q�$��Center=�8�� F����        ���( ��( јaQ     јaQ P����̰( � �    P����         ^�  ��  �� *
IsEditable+ �� " �� true��  �� *IsMouseOver+ �� *Self+	 false��  �� *	IsPressed+ �� *Self+	 false��  �� *	IsEnabled+ �� *Self+ true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  �@J�IsMouseOver . . ��� $ arrow��8   � ��^�  ��  �� *IsMouseOver+ �� *Self+ true��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8 	  � ��^�  ��  �� *IsMouseOver+ �� *Self+ true��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8 
  � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � �� . . ��� $ arrow��8   � ��^�  ��  �� *	IsPressed+ �� *Self+ true��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *	IsPressed+ �� *Self+ true��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � {� .  . ��� $ arrow��8   � ��^�  ��  �� *	IsEnabled+ �� *Self+	 false��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *	IsEnabled+ �� *Self+	 false��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ���� " ��.R�� $ templateRoot��	 .  �� $��* ��� #��� r�$��0 �.+�� $ 
PART_Popup��  . $��2��$��1q�#��� .�$��Bottom=����� *IsDropDownOpen+$! TwoWay=� �� *TemplatedParent+.��  $" shadow��$# Transparent��#��z$ ���� *ActualWidth+$% templateRoot��._��� $ dropDownBorder��#��� ��$��1q����#0000._��� $& DropDownScrollViewer��.��� $
 grid��$' Enabled=�.+��� $( canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $) 
opaqueRect������ *
Background+$% dropDownBorder������ *ActualHeight+$% dropDownBorder������ *ActualWidth+$% dropDownBorder���� $* ItemsPresenter��$+ 	Contained=�#	 z	 d� $, toggleButton��#��z��#��z��#��z��$��2��8��  - �� *IsDropDownOpen+$! TwoWay=� �� *TemplatedParent+�� $. contentPresenter��#��z/ #��z��#��z0 #2 z1 #��z��3 .  #��z��#	 z	 #��z�� P� $4 
PART_Popup�� �@�HasDropShadow . . ��� $ shadow�� � ��$ 0,0,5,5q��� $ shadow�� �@ Color$ 	#71000000��P�  �@��HasItems .  . ��� $ dropDownBorder�� � ��$ 95��]�  ��  �@��
IsGrouping . �� " �@%�IsVirtualizingWhenGrouping .  ./���  � �� .  P� $4 DropDownScrollViewer�� � �� .  . ��� $ 
opaqueRect�� �� *VerticalOffset+$% DropDownScrollViewer�� �@��Top�� $ 
opaqueRect�� �� *HorizontalOffset+$% DropDownScrollViewer�� �@��Left�� $ 	#AA1e1e1e���� " ��.���  �@�OverridesDefaultStyle . ��  �@J�	AllowDrop . ��  � ��$ 0����  � ��$ 0����  �@�FocusVisualStyle Z� ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R��� $& PART_ContentHost��
������ |�.  $��Hidden=�$��Hidden=��� " ��.R�� $ templateRoot��	 .  �� $��* ��� #��� r�$��0 �.+�� $ 
PART_Popup��  . $��2��#��� .�$��Bottom=����� *IsDropDownOpen+ �� *TemplatedParent+.��  $" shadow��$# Transparent��#��z$ ���� *ActualWidth+$% templateRoot��._��� $ dropDownBorder��#��� ��$��1q����#0000._��� $& DropDownScrollViewer��.��� $
 grid��$' Enabled=�.+��� $( canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $) 
opaqueRect������ *
Background+$% dropDownBorder������ *ActualHeight+$% dropDownBorder������ *ActualWidth+$% dropDownBorder���� $* ItemsPresenter��$+ 	Contained=�#	 z	 d� $, toggleButton��#��z��#��z��#��z��$��2��8��  - �� *IsDropDownOpen+$! TwoWay=� �� *TemplatedParent+�� $ border�����#0000#��z��._��� $5 PART_EditableTextBox��#��z��#��z��8�� #��z��6 �� *
IsReadOnly+ �� *TemplatedParent+ P�  � {� .  . ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsKeyboardFocusWithin . . ���  � ��
 �   �P� $4 
PART_Popup�� �@�HasDropShadow . . ��� $ shadow�� � ��$ 0,0,5,5q��� $ shadow�� �@ Color$ 	#71000000��P�  �@��HasItems .  . ��� $ dropDownBorder�� � ��$ 95��]�  ��  �@��
IsGrouping . �� " �@%�IsVirtualizingWhenGrouping .  ./���  � �� .  P� $4 DropDownScrollViewer�� � �� .  . ��� $ 
opaqueRect�� �� *VerticalOffset+$% DropDownScrollViewer�� �@��Top�� $ 
opaqueRect�� �� *HorizontalOffset+$% DropDownScrollViewer�� �@��Left�� " ��.���  �@�FocusVisualStyle8   ��  � �� �#0000��  � �� �#0000��  � ��
 �������  � ��$ 1q���  � ��$
 Auto=���  � ��$
 Auto=���  � ��$ 6,3,5,3q���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��8  7 P�  �@��
IsEditable . . ���  � �� .  ��  � ��$ 2q���  � ��8  .���� 
�������._�� 8 � RowDefinitions8 �� $��25 ��� $��1 ��� $��* �.+��� ���#202225�� -   $
) Info��$��Right=�$��10��$��0 0 10 0q�$��Center=�$��10��
   $	 0.2Q����� -   Indo��$ #f44336��z��� 9 �� CenterX$9 5Q�: �� CenterY$: 5Q�; �� Angle$; 0Q�< � Triggers< :� = :� RoutedEvent$= Loaded��.[��� .���� > g� DesiredFrameRate$> 20X�.���� ? �� From$? #f44336X�	@ �� To$@ 	#0Df44336X�A g� AutoReverseA . B g� RepeatBehavior$B Forever��C g� Duration$C 0:0:2D�D �� TargetProperty$D Color�E �� 
TargetName$
E Indo��F �� EasingFunctionF /  )System.Windows.Media.Animation.CircleEase  7  1System.Windows.Media.Animation.EasingFunctionBaseG   
EasingMode$G 	EaseInOut=��� .���� $> 20X�.��W� $9D 3(Rectangle.RenderTransform).(RotateTransform.Angle)�	H W� To$	H 360X�$C 0:0:2D�$B Forever��I W� EasingFunctionI   $G 	EaseInOut=��� $��Voice Channel��
��������� $��1�����#f44336
   $	 0.2Q�� -   $��MainGrid��$��2�����#1e1e1e8 �� $��40 ��� $	��120 ��� $
��Auto �.+��� -   J ��Name$J CommandEditList��$��2��
�������$��0��$��0��$	��Top=�$��Right=�#���  ���� .R�� $	��0,2q� �� $��* ��� $��30 �.+��� 
����������� *	command+�� 
�������$��1������ *commandindex+� $��2�� �� $
��100* ��� $��1* ��� $��1* ��� $��1* �.+��� -   $"��FlowLayoutPanelServerClients��$��0���� -   $!��FlowLayoutPanelServerListen��$��1���� -   $'��!FlowLayoutPanelServerProgressBars��$��2���� -   $ ��FlowLayoutPanelServerSpeak��$��3��� $��1�� �� .+�� $��1��8 �� �� �� �� .+�� -	   $��ProgressBarPlayingClient��$��20��$��5q����#1e1e1e$��0q�$
��Auto���� -
   $)��#ComboboxOutputSoundDeviceNameClient��$
��Auto��$
��Left=�$��1��#��[& �� -   $(��"ComboboxInputSoundDeviceNameClient��$
��Auto��$
��Left=�$��2��#��[& �� -   K ��Name$K LabelClient��
�������$��3��$��12(�$��Center=�$��Center=�$��0 0 0 1q����#03A9F4�  �� $��2* �.+��  �� �� .+��� -   $K LabelServer��
�������$��18(�$��Center=��� -   $��ButtonClientSpeak��$��0��$��0��$��1��
�������$��Center=�
������ $��CS��
������ �� -   $��ButtonClient��$
��Auto��$��40��$��Center=�
�������
������ $��Connect��
������ $
��74,0q�$	��Top=��� -   $��ButtonClientListen��$��0��$��0��$��1��$��Center=�
�������
������ $��CL��
������ 