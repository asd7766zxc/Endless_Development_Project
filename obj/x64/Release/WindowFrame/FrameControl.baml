   M S B A M L   `   `   `  ���� ]  YEndless Development Project Studio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Server_Restart_FinalServer_Restart_Final  A    ;Endless_Development_Project_Studio.WindowFrame.FrameControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:Server_Restart_Final       � 	Resources  )   #Server_Restart_Final.ResizablePanel �� 
TargetType �� Property �� Value �� 
TargetType � DataContext �� RelativeSource � ColumnDefinitions � RowDefinitions"   Server_Restart_Final.Resizer	 � Cursor
   ThumbDirection    Button.MouseOver.Background2 �� Color  Button.MouseOver.Border2  CloseButtonStyle  FocusVisual ��Name J� SnapsToDevicePixels ��Name �� CenterX �� CenterY �� Angle ��Name �� Triggers P� Property P� Value �� 
TargetName  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground��%�  '        &	      &	 %    &	 6    7  7   7  7  7  7  �� "  .���  � �� �� "  .R��  ��  �� *TemplatedParent+ �� $��5 ��� $��* ��� $��5 � �� $��5 ��� $��* ��� $��5 �.+�  $	 SizeNWSE��
������ $��3��$��3��$��0��$��0��$
 TopLeft=�  $	 SizeWE��
������ $��3��$��1��$��0��$

 Left=�  $	 SizeNESW��
������ $��3��$��3��$��2��$��0��$
 
BottomLeft=�  $	 SizeNS��
������ $��3��$��2��$��1��$
 Bottom=�  $	 SizeNWSE��
������ $��3��$��3��$��2��$��2��$
 BottomRight=�  $	 SizeWE��
������ $��3��$��1��$��2��$
 Right=�  $	 SizeNESW��
������ $��3��$��3��$��0��$��2��$
 TopRight=�  $	 SizeNS��
������ $��3��$��0��$��1��$	
 Top=��� $��1��$��1��#��z��#��z���� $ 	#AFf44336���� $ #0000���� " ��.���  �@�FocusVisualStyle8   ��  � ��
 ���� ��  � ��
 ���� ��  � ��
 �������  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z�� . ._�� .+��� $ 	CloseRect��$��10��$��10������ $ #202225��z��� $ 5Q�$ 5Q�$ 45Q��� $ contentPresenter��|�.  #��z��#��z����. # z #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  �@J�IsMouseOver . . ��� $ 	CloseRect��8   � ���� $ border��8   � ��P�  � �� . . ��� $ 	CloseRect�� � �� �	#FFf44336P�  � {� .  . ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8   � ��.���� -    ��Name$ 
Maincanvas��$
��Auto��$
��Auto��.+�  $��0�� �� Left$ 0��
 �� Top$ 0��$��Stretch=�$��Stretch=����� *ActualHeight+ �� ElementName$ 
Maincanvas������ *ActualWidth+$ 
Maincanvas��.��� $
��Auto��$
��Auto�� �� $��25 ��� $��* �.+��� -   $��CaptionBorder�����#2F3136._��  �� $��* ��� $��25 ��� $��25 �.+��� -    ��Name$ TitleBarText��$��Ydsads��$��10(�
��������� -   $��Close��$��3��$��25��$��25��#���   � -     �Name$ PageContent��$��1��$��0q�$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��  � NavigationUIVisibility$ Hidden=�