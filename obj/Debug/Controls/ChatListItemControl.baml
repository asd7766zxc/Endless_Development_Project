   M S B A M L   `   `   `  ����]  YEndless Development Project Studio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Chat_Pro_NCPChat_Pro_NCP  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      &     Chat_Pro_NCP.ChatListItemControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Chat_Pro_NCP     5      9system&clr-namespace:System;assembly=mscorlib     5	      $��60��5        � 	Resources  5         LatoThin  LatoRegular  LatoBold  	LatoHeavy  FontAwesome �� 
TargetType  	BaseStyle �� Property �� Value  BaseTextBlockStyle �� BasedOn  FontSizeRegular  FontSizeSmall 	 FontSizeLarge 
 ChatIcon  UserIcon  PngIcon  CogIcon  ToolIcon  BackgroundLight  BackgroundLightBrush �� Color  BackgroundTransparency  BackgroundTransparencyBrush  BackgroundTransparent  BackgroundTransparentBrush  BackgroundVeryLight  BackgroundVeryLightBrush  ForegroundMain  ForegroundMainBrush  ForegroundVeryDark  ForegroundVeryDarkBrush  ForegroundLight  ForegroundLightBrush  ForegroundLogoGreen  ForegroundLogoGreenBrush  ForegroundLogoRed   ForegroundLogoRedBrush ! 
ButtonFace " ButtonFaceBrush # ButtonTrack $ ButtonTrackBrush % Button.Static.Background & Button.Static.Border ' Button.MouseOver.Background ( Button.MouseOver.Border ) Button.Pressed.Background * Button.Pressed.Border + Button.Disabled.Background , Button.Disabled.Border - Button.Disabled.Foreground . ContentStyle �� 
TargetType ��Name �Name	 � ColumnDefinitions
 �� 	Converter.   (Chat_Pro_NCP.BooleanToVisbilityConverter �� ConverterParameter �� Padding,   &Chat_Pro_NCP.StringRGBToBrushConverter �� RelativeSource �� CornerRadius �� Triggers �� Value �� Binding �� 
TargetName :� RoutedEvent	 �� To g� Duration �� 
TargetName �� TargetProperty P� Property P� Value��%�  &	        &	 >     &	      &	 �     &	 �     &	 <    7   &	 �    7   '�� �    7  '�� �    7  '��     7  '�� *    7  '�� L    7  &	 n    &	 �    &		 �    &	
 �    &	 �    &	 �    &	     &	      &	 9    &	 X    7  &	 p    &	 �    7  &	 �    &	 �    7  &	 �    &	     7  &	     &	 8    7  &	 P    &	 q    7  &	 �    &	 �    7  &	 �    &	 �    7  &	 �    &	      7  &	! 2    &	" S    7 ! &	# k    &	$ �    7 # &	% �    &	& �    &	' �    &	(     &	) $    &	* G    &	+ j    &	, �    &	- �    &	. �    7  7  7   7  7 ! 7 + *�5   
   *&pack://appliction;,,,/Fonts/#Lato Thin)�6N   *�5   
   -)pack://appliction;,,,/Fonts/#Lato Regular)�6T   *�5   
   *&pack://appliction;,,,/Fonts/#Lato Bold)�6N   *�5   
   +'pack://appliction;,,,/Fonts/#Lato Heavy)�6P   *�5   
   ,(pack://appliction;,,,/Fonts/#FontAwesome)�6S   �� 5   
   " ��6   .�5      ��  � ��8   6+   5      �� 5   
   " ��6   .�5      ��  � ��8   6+   5      �� 5   
   " ��6   8   6-   �� 5   
   " ��6   8   6,   �� 5   
   " ��6   8   6.   �� 5   
   " ��6   8   60   �� 5   
   " ��6   8   6/   X�5!   
   20Q�64   X�5"   
   14Q�62   X�5#   
   30Q�62   ��5%   
   w��6,   ��5&   
   U��6,   ��5'   
   v��6+   ��5(   
   x��6+   ��5)   
   x��6,   ��5+   
   #efefef��61   �� 5,   
   8   67   ��5.   
   	#0DB2EBF2��6:   �� 5/   
   8   6>   ��51   
   	#00B2EBF2��69   �� 52   
   8   6=   ��54   
   #fafafa��65   �� 55   
   8   6;   ��57   
   #686868��60   �� 58   
   8   66   ��5:   
   	#AA181818��66   �� 5;   
   8   6:   ��5=   
   #ffffff��61   �� 5>   
   8   67   ��5@   
   	#FF8BC34A��67   �� 5A   
   8   6;   ��5C   
   	#FFf44336��65   �� 5D   
   8   69   ��5F   
   	#AA404040��6.   �� 5G   
   8   62   ��5I   
   	#0000��6+   �� 5J   
   8   63   �� 5P   
   $ 	#FFDDDDDD��6;   �� 5Q   
   $ #0000��67   �� 5R   
   $ 	#AA404040��6>   �� 5S   
   $ #0000��6:   �� 5T   
   $ 	#ADC4E5F6��6<   �� 5U   
   $ 	#AD2C628B��68   �� 5V   
   $ #0000��6=   �� 5W   
   $ #0000��69   �� 5X   
   $ 	#FF594849��6=   �� 5]   
   " ��6%   .�5^      ��  � �� 5_      �� 5`      " ��6&   .R�5a      �� $ 
background��6!   ���	#AD292929._�5b      � $ 	container��6#   
������ 	 5c   "   �� 5e   &   $
��Auto �67   �� 5f   &   $��* �67   .+�5h   "   �� ���	#FF9CCC65$	��4.5��6@   $
��Left=�6M   y�6h   �� *NewContentAvailable+
   $
 True���� 5i   "   $��0��6)   $ 8q�69   ._�5j   &   �� ��6-   �� *ProfilePictrueRGB+
   ��5k   )   �� *ActualHeight+ �� *Self+ 5l   )   �� *ActualHeight+ �� *Self+._�5m   *   � .+�5n   .   �� $��Center=�5o   4   $��Center=�5p   4   
�������$��20(�5r   4   8��  ��5n   8   �� *
Initials+5t   /   5u   +   5v   '   5w   #   �� 5x   "   $��1��6)   $ 0 0 8 0q�69   ._�5y   &   �� $��Center=�61   .+�5z   *   �� $��15(�64   $��CharacterEllipsis=�6B   
�������8�� ��6v   �� *Name+6�   �� 5{   *   ���	#FF80CBC4$��CharacterEllipsis=�6d   8�� ��6K   �� *	Message+6�   5|   '   5}   #   5~      5       5�      �� 5�      $
 True��6I    6*   �� *
IsSelected+.a�5�   "   �� $ 
background��6?   8   � ��6W   5�      :� 5�      $ 
MouseEnter��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   �� 8  $ 0:0:0.3D�6Z   $ 	container��6m   $ Background.Color�6�   5�   '   5�   #   5�      :� 5�      $ 
MouseLeave��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   �� $ TransparentX�69   $ 0:0:0.3D�6J   $ 	container��6]   $ Background.Color�6   5�   '   5�   #   5�      P� 5�       � {� .  . �5�   "   �� $ 	container��6?   8   � ��6V   5�      5�      5�      5�      5�      .��5�      �� #��[. 5�      5�      