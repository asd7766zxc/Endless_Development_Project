   M S B A M L   `   `   `  ���� ]  YEndless Development Project Studio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Chat_Pro_NCPChat_Pro_NCP  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem "    Chat_Pro_NCP.ChatItemControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Chat_Pro_NCP     9system&clr-namespace:System;assembly=mscorlib       � 	Resources     ContentStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �Name � ColumnDefinitions �� Padding	 �� RelativeSource
 �� CornerRadius �� ImageSource �� 	Converter*   $Chat_Pro_NCP.PathUrlToImageConverter J� Effect-  'System.Windows.Media.Effects.BlurEffect   Radius  LatoRegular �� Triggers P� Property P� Value �� 
TargetName  BackgroundTransparencyBrush  Button.Disabled.Background��%4  &	        7  7  7  7  7  7  �� " ��.���  � �� �� " ��.R��� $ 
background��$��0 1 0 0q����#42454A���	#AA292929._�� $ 	container��
������  �� $
��Auto ��� $��* �.+��� ���	#FF9CCC65$��0��$
��Left=��� $��60��$��0��$ 8q�._��� ���� *ActualHeight+	 �� *Self+
 �� *ActualHeight+	 �� *Self+._�� $��0 0 0 0q�.+��� $
��Mask�����#4FC3F7$��0q�
 �� *ActualHeight+	 �� *Self+����  �� *	AvatarUrl+      $
 0.25Q��� 
������ 
������ $��Center=�$��Center=�
�������$��20(�$��0 0 0 0q�8��  �� $��1��$ 0 0 8 0q�._��� $��Center=�.+�� .+��� $��14(����	#FF80CBC4$��CharacterEllipsis=�8�� ���� *Name+�� $��12(����	#FF80CBC4$��Right=�$��CharacterEllipsis=�8�� ���� *Date+�� $��15(�
�������$
��Wrap=�$��CharacterEllipsis=�8�� ���� *	message+ P�  � {� .  . ��� $ 
background��8   � ��P�  � {� .  . ��� $ 	container��8   � ��.���� #��[  