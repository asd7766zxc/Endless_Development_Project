   M S B A M L   `   `   `  ����]  YEndless Development Project Studio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Endless_Development_Project_Studio"Endless_Development_Project_Studio  5      3    -Endless_Development_Project_Studio.OnlinePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:Endless_Development_Project_Studio     5        N� Title$  
OnlinePage��5	      .��5      � $��5q�6   ���#252526 � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��1 �6   �� 5      $��* �6   .+�5   
   �� ���#2022255      �� 5   
   -   5         ��Name$
 Info��5      $��Right=�6"   $��10��6>   $��0 0 10 0q�6K   $��Center=�6]   $��10��6x    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$	 0.2Q�6#   ��5      �� 5      -   5        Indo�� �� Color$ #9CCC65��5   0   z�5      �� 5       �� CenterX$ 5Q�6"    �� CenterY$ 5Q�6.    �� Angle$ 45Q�6:   	 � Triggers	 5      :� 5       
 :� RoutedEvent$
 Loaded��6   .[�5!      �� .��5"      ��  g� DesiredFrameRate$ 20X�6%   .��5#      ��  �� From$ #C5E1A5X�6-   	 �� To$ 	#0D9CCC65X�6<    g� AutoReverse .  g� RepeatBehavior$ Forever��6^    g� Duration$ 0:0:2D�6w    �� TargetProperty$ Color�6�    �� 
TargetName$
 Indo��6�    �� EasingFunction 5$   "   /  )System.Windows.Media.Animation.CircleEase  5%   &   7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ 	EaseInOut=�61   5'      5(      5)      5*      5,      �� 5-   
   $��Online��6   
�������6!   �� 5.   
   -   5         ��Name$ OnlinePlayer��5.   @   
������ $��0q�6,   $��2��6V   
������ ��5/      �� 50      .R�51      � $	��0,2q�6    � ColumnDefinitions 52      �� 53      $��* �6/   .+�55      �� 
���������63   �� *Name+56      57      59      �� 5:   
   $��1��6   ���#9CCC65 5;        5<      $	 0.2Q�6#   5>      5?      5@      