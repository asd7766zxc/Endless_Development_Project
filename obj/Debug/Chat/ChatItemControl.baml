   M S B A M L   `   `   `  ����]  YEndless Development Project Studio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Chat_Pro_NCPChat_Pro_NCP  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      "    Chat_Pro_NCP.ChatItemControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Chat_Pro_NCP     5      9system&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5
         ContentStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �Name � ColumnDefinitions �� Padding	 �� RelativeSource
 �� CornerRadius �� ImageSource �� 	Converter*   $Chat_Pro_NCP.PathUrlToImageConverter J� Effect-  'System.Windows.Media.Effects.BlurEffect   Radius  LatoRegular �� Triggers P� Property P� Value �� 
TargetName  BackgroundTransparencyBrush  Button.Disabled.Background��%�  &	        7  7  7  7  7  7  �� 5   
   " ��6%   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 
background��6!   $��0 1 0 0q�65   ���#42454A���	#73292929._�5      � $ 	container��6#   
������  5   "   �� 5   &   $
��Auto �67   �� 5   &   $��* �67   .+�5   "   �� ���	#FF9CCC65$��0��6@   $
��Left=�6K   �� 5   "   $��60��6)   $��0��65   $ 8q�6E   ._�5   &   �� ��5   )   �� *ActualHeight+	 �� *Self+
 5   )   �� *ActualHeight+	 �� *Self+._�5   *   � $��0 0 0 0q�60   .+�5   .   �� $
��Mask��65   ���#4FC3F7$��0q�5   5   
 5    5   �� *ActualHeight+	 �� *Self+��5!   2   �� 5"   6    6A   �� *	AvatarUrl+    5$   2     5%   6   $
 0.25Q�6A   5'   /   �� 5(   .   
������ 
������ $��Center=�5+   4   $��Center=�5,   4   
�������$��20(�5.   4   $��0 0 0 0q�5/   1   8��  51   /   53   +   54   '   55   #   �� 56   "   $��1��6)   $ 0 0 8 0q�69   ._�57   &   �� $��Center=�61   .+�58   *   � .+�59   .   �� $��14(�68   ���	#FF80CBC4$��CharacterEllipsis=�6]   8�� ��6   �� *Name+6�   �� 5:   .   $��12(�68   ���	#FF80CBC4$��Right=�6]   $��CharacterEllipsis=�6y   8�� ��6�   �� *Date+6�   5;   +   �� 5<   *   $��15(�64   
�������$
��Wrap=�6n   $��CharacterEllipsis=�6�   8�� ��6U   �� *	message+6�   5=   '   5>   #   5?      5@       5A      P� 5C       � {� .  . �5D   "   �� $ 
background��6?   8   � ��6W   5E      P� 5G       � {� .  . �5H   "   �� $ 	container��6?   8   � ��6V   5I      5M      5O      5P      5R      .��5S      �� #��[  5T      5U      