   M S B A M L   `   `   `  ����]  YEndless Development Project Studio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Chat_Pro_NCPChat_Pro_NCP  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      "    Chat_Pro_NCP.SideMenuControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Chat_Pro_NCP     5      9system&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5
         LatoThin  LatoRegular  LatoBold  	LatoHeavy  FontAwesome �� 
TargetType  	BaseStyle �� Property �� Value  BaseTextBlockStyle �� BasedOn  FontSizeRegular  FontSizeSmall 	 FontSizeLarge 
 ChatIcon  UserIcon  PngIcon  CogIcon  ToolIcon  BackgroundLight  BackgroundLightBrush �� Color  BackgroundTransparency  BackgroundTransparencyBrush  BackgroundTransparent  BackgroundTransparentBrush  BackgroundVeryLight  BackgroundVeryLightBrush  ForegroundMain  ForegroundMainBrush  ForegroundVeryDark  ForegroundVeryDarkBrush  ForegroundLight  ForegroundLightBrush  ForegroundLogoGreen  ForegroundLogoGreenBrush  ForegroundLogoRed   ForegroundLogoRedBrush ! 
ButtonFace " ButtonFaceBrush # ButtonTrack $ ButtonTrackBrush % Button.Static.Background & Button.Static.Border ' Button.MouseOver.Background ( Button.MouseOver.Border ) Button.Pressed.Background * Button.Pressed.Border + Button.Disabled.Background , Button.Disabled.Border - Button.Disabled.Foreground . FocusVisual J� SnapsToDevicePixels �� StrokeDashArray / 	Hoverless �� 
TargetType	 �� Padding 0 
HeaderText 1 WindowControlButton'  !System.Windows.Shell.WindowChrome
 �� ScaleX �� Triggers P� Property P� Value 2 WindowCloseButton 3 SpinText �� 	Resources 4 Key �� TargetProperty W� From	 W� To g� Duration g� RepeatBehavior �� Binding �� Self �� RelativeSource �� Path �� Value N� EnterActions ��Name 5 Spin N� ExitActions �� BeginStoryboardName 6 ButtonStyle1 ��Name �� Triggers :� RoutedEvent	  �� To! �� 
TargetName" �� 
TargetName 7 ButtonStyle2��%�  &	        &	 >     &	      &	 �     &	 �     &	 <    7   &	 �    7   '�� �    7  '�� �    7  '��     7  '�� *    7  '�� L    7  &	 n    &	 �    &		 �    &	
 �    &	 �    &	 �    &	     &	      &	 9    &	 X    7  &	 p    &	 �    7  &	 �    &	 �    7  &	 �    &	     7  &	     &	 8    7  &	 P    &	 q    7  &	 �    &	 �    7  &	 �    &	 �    7  &	 �    &	      7  &	! 2    &	" S    7 ! &	# k    &	$ �    7 # &	% �    &	& �    &	' �    &	(     &	) $    &	* G    &	+ j    &	, �    &	- �    &	. �    &	/ u    &	0 �    7  7  &	1 T	    7  7  7  &	2 �    7 1 7  &	3 s    7 5 &	6 4    7 . 7  7  7 ! 7 # 7 ) 7 * 7 + 7 , 7 - &	7 c    7 . 7  7  7 ! 7 # 7 ) 7 * 7 + 7 , 7 - *�5   
   *&pack://appliction;,,,/Fonts/#Lato Thin)�6N   *�5   
   -)pack://appliction;,,,/Fonts/#Lato Regular)�6T   *�5   
   *&pack://appliction;,,,/Fonts/#Lato Bold)�6N   *�5   
   +'pack://appliction;,,,/Fonts/#Lato Heavy)�6P   *�5   
   ,(pack://appliction;,,,/Fonts/#FontAwesome)�6S   �� 5   
   " ��6   .�5      ��  � ��8   6+   5      �� 5   
   " ��6   .�5      ��  � ��8   6+   5      �� 5   
   " ��6   8   6-   �� 5   
   " ��6   8   6,   �� 5   
   " ��6   8   6.   �� 5   
   " ��6   8   60   �� 5   
   " ��6   8   6/   X�5   
   20Q�64   X�5    
   14Q�62   X�5!   
   30Q�62   ��5#   
   w��6,   ��5$   
   U��6,   ��5%   
   v��6+   ��5&   
   x��6+   ��5'   
   x��6,   ��5*   
   #efefef��61   �� 5+   
   8   67   ��5-   
   	#0DB2EBF2��6:   �� 5.   
   8   6>   ��50   
   	#00B2EBF2��69   �� 51   
   8   6=   ��53   
   #fafafa��65   �� 54   
   8   6;   ��56   
   #686868��60   �� 57   
   8   66   ��59   
   	#AA181818��66   �� 5:   
   8   6:   ��5<   
   #ffffff��61   �� 5=   
   8   67   ��5?   
   	#FF8BC34A��67   �� 5@   
   8   6;   ��5B   
   	#FFf44336��65   �� 5C   
   8   69   ��5E   
   	#AA404040��6.   �� 5F   
   8   62   ��5H   
   	#0000��6+   �� 5I   
   8   63   �� 5K   
   $ 	#FFDDDDDD��6;   �� 5L   
   $ #0000��67   �� 5M   
   $ 	#AA404040��6>   �� 5N   
   $ #0000��6:   �� 5O   
   $ 	#ADC4E5F6��6<   �� 5P   
   $ 	#AD2C628B��68   �� 5Q   
   $ #0000��6=   �� 5R   
   $ #0000��69   �� 5S   
   $ 	#FF594849��6=   �� 5U   
   .�5V      ��  � �� 5W      �� 5X      .R�5Y      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5Z      5\      5]      �� 5`   
   " ��6   .�5a      ��  � ��
 ���� 6+   �� 5b       � ��$ 0q�60   �� 5d       � �� 5e      �� 5f      " ��6&   .R�5g      �� #	 z��6!   #��z��6E   ._�5h      �� $��Center=�6/   $��Center=�6J   5i      5j      5l      5m      �� 5o   
   " ��6   8   .�5p      ��  � ��8  6+   �� 5q       � ��$ Center=�62   �� 5r       � ��$ Center=�64   �� 5s       � ��$	 0 6q�6'   5t      �� 5w   
   " ��6   8   .�5x      ��   �@ IsHitTestVisibleInChrome . 6F   �� 5y       � ��
 ���� 6+   �� 5z       � ��$ 8q�6(   �� 5{       � ��$ Stretch=�62   �� 5|       � ��8  6+   �� 5~       �@�LayoutTransform 5      �� 5�      $	
 1.5Q�6%   5�      �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� #	 z��6!   #��z��6E   ._�5�      �� $��Center=�6(   $��Center=�6C   #��z��6`   5�      5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      ��  � ��8  63   5�      5�      �� 5�   
   " ��6   8    5�      P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
 �  ��63   �� 5�       � ��8  63   5�      5�      �� 5�   
   " ��6   .�5�      ��  � ��$/ )pack://appliction;,,,/Fonts/#Lato Regular)�6+   �� 5�       � ��$ ->��6%   �� 5�       �@J�RenderTransformOrigin$ 0.5,0.5&�66   �� 5�       � z� 5�      �� 5�      5�      5�       5�      ���� 5�      Spin4 .��5�      W� $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5�      $ 0X�5�      $	 360X�5�      $ 0:0:0.1D�5�      $ Forever��5�      5�      5�       5�      �� 5�       6   �� # Z $ 	IsVisible� True6p    5�      �� 5�      $ SpinStoryboard��6*   8��  6@    5�      �� 5�      $ SpinStoryboard��6+   5�      5�      �� 5�   
   " ��6%   .�5�      ��  �@�FocusVisualStyle8   61   �� 5�       � �� �#00006+   �� 5�       � ��8  6,   �� 5�       � �� �#FAFAFA6+   �� 5�       � ��$ 20(�6)   �� 5�       � ��$ 0q�60   �� 5�       � ��$ Center=�6;   �� 5�       � ��8  6+   �� 5�       � ��$ Center=�69   �� 5�       � ��$ 10q�6(   �� 5�       � ��$ 0q�6'   �� 5�       � �� 6&   �� *ActualHeight+ �� *Self+�� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5�      � .+�5�   "   (� .��5�   &   �� #��z��60   $y�Visible=�5�   ,   |�.  #��z��5�   ,   #��z��5�   ,   #��z��5�   ,   # z 5�   ,   #��z��5�   ,   5�   '   5�   #   5�      5�       5�      :� 5�      $ 
MouseEnter��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   �� 8   $ 0:0:0.3D�6Z   $! border��6m   $ Background.Color�6�   5�   '   5�   #   5�      :� 5�      $ 
MouseLeave��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   �� 8   $ 0:0:0.3D�6[   $! border��6n   $ Background.Color�6�   5�   '   5�   #   5�      P� 5�       � �� . . �5�   "   �� $" border��6?   8   � ��6S   �� 5�   "   $" border��6@   8   � ��6T   5�      P� 5�       � {� .  . �5�   "   �� $" border��6?   8   � ��6S   �� 5�   "   $" border��6@   8   � ��6T   �� 5�   "   8 	  � ��6L   5�      5     5     5     �� 5  
   " ��6%   .�5     ��  �@�FocusVisualStyle8   61   �� 5      � �� �#00006+   �� 5	      � ��8  6,   �� 5
      � ��8  6+   �� 5      � ��$ 10(�6)   �� 5      � ��$ 0q�60   �� 5      � ��$ Center=�6;   �� 5      � ��$ Center=�69   �� 5      � �� 6&   �� *ActualHeight+ �� *Self+�� 5      � ��$ 10q�6(   �� 5      � ��$ 0q�6'   �� 5      � �� 5     �� 5     " ��6&   .R�5     �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5     � .+�5  "   (� 5  #   5     5      5     :� 5!     $ 
MouseEnter��6+   .[�5"  "   �� .��5#  &   �� .��5$  *   �� 8   $ 0:0:0.3D�6Z   $! border��6m   $ Background.Color�6�   5%  '   5&  #   5'     :� 5)     $ 
MouseLeave��6+   .[�5*  "   �� .��5+  &   �� .��5,  *   �� 8   $ 0:0:0.3D�6[   $! border��6n   $ Background.Color�6�   5-  '   5.  #   5/     P� 52      � �� . . �53  "   �� $" border��6?   8   � ��6S   �� 54  "   $" border��6@   8   � ��6T   55     P� 56      � {� .  . �57  "   �� $" border��6?   8   � ��6S   �� 58  "   $" border��6@   8   � ��6T   �� 59  "   8 	  � ��6L   5:     5<     5>     5?     5A     ��5B     �� 5C  
   " >�6   .R�5D     �� ���	#5D282828._�5E     � # � RowDefinitions# 5F     �� 5G     $
��Auto �6(   �� 5H     $��* �6(   .+�5J     � $��50��6   ���	#FF282828$ � ColumnDefinitions$ 5K     �� 5L     $
��Auto �6/   �� 5M     $��* �6/   �� 5N     $
��Auto �6/   .+�5P     �� % �� Orientation$% 
Horizontal=�6%   .+�5Q     �� #��[
 6%   #��[6 6I   �� 5R     #��[ 6%   #��[6 6I   �� 5S     #��[ 6%   #��[6 6H   �� 5T     #��[ 6%   #��[6 6I   5U     �� 5V     $��2��6!   #��[7 61   5W     �� 5X     $��1��6'   5Y     5Z     5[     5]     