   M S B A M L   `   `   `  ���� ]  YEndless Development Project Studio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullDclr-namespace:Endless_Development_Project_Studio.ServerOutputControl6Endless_Development_Project_Studio.ServerOutputControl  +clr-namespace:Chat_Pro_NCPChat_Pro_NCP  J    DEndless_Development_Project_Studio.ServerOutputControl.OutPutControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     VlocalDclr-namespace:Endless_Development_Project_Studio.ServerOutputControl     -local1clr-namespace:Chat_Pro_NCP       � 	Resources     CellStyleOutPut �� 
TargetType*  $System.Windows.Controls.DataGridCell �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� Triggers P� Property P� Value	 �� Color
 �� Opacity  CellStyleTime  RowHeaderSelector:  4System.Windows.Controls.Primitives.DataGridRowHeader �� 	Converter,   &Chat_Pro_NCP.StringRGBToBrushConverter �� CenterX �� CenterY �� Angle  DataGridStyle1&   System.Windows.Controls.DataGrid �� Padding ��Name ]� 
Conditions �� Property �� Value��%#  &	        &	     &	     &	 �    �� "  .���  � ��$ 25����  � ��$ Center=���  � �� �� "  .R��� #��z��$��0q�
������ # z ._��� # z $��Center=�#��z��#��z�� P�  �@ 
IsSelected . . ���  � ��$
 Bold"���  � �� �� $	 Transparent����  � �� �� $	 #FDCBA5��$	
 0.2Q���  � �� �#F6416CP�  �@ 
IsSelected .  . ���  � ��$
 Bold"���  � �� �� $	 Transparent����  � �� �� $	 #FDCBA5��$	
 0.2Q���  � ��
 ������� "  .���  � ��$ 25����  � ��$ Center=���  � �� �� "  .R��� #��z��$��0q�
������ # z ._��� # z $��Center=�#��z��#��z�� P�  �@ 
IsSelected . . ���  � ��$
 Bold"���  � �� �� $	 Transparent����  � �� �� $	 #FDCBA5��$	
 0.2Q���  � �� �#F6416CP�  �@ 
IsSelected .  . ���  � ��$
 Bold"���  � �� �� $	 Transparent����  � �� �� $	 	#FF80CBC4��$	
 0.2Q���  � �� �	#FF80CBC4�� "  .���  � �� �� .R��� #��z��$��0q�
������ # z ._�� .+��� $��10��$��10������ *	TypeColor+   z��� $ 5Q�$ 5Q�$ 45Q��� # z $��Center=�#��z��#��z���� "  .���  � ��
 ���� ��  � ��# � ����  � �� �	#FF688CAF��  � ��$ 1q���   �@ RowDetailsVisibilityMode$ VisibleWhenSelected=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � �� �� "  .R��� #��z��#��z��
������ # z�� . ._��� $ DG_ScrollViewer��$��Disabled=�$��Disabled=�|�.  .���� # z  ]�  ��  �@��
IsGrouping . �� " �@%�IsVirtualizingWhenGrouping .  ./���  � �� .  .��� S   MEndless_Development_Project_Studio.ServerOutputControl.LogItemListDesignModel   Instance � DataContext# Z     DateTemplate � ColumnDefinitions �� TextAlignment  LatoRegular �� TextWrapping��%�  &	       7  7  �� .R��� ._�� ���	#AA1e1e1e.+�� $��15 2.5 15 2.5q� �� $��20 ��� $��60 ��� .+��� $��10��$��10������ *	TypeColor+   z��� $ 5Q�$ 5Q�$ 45Q��� $��1��$��0q�
������ ���	#FF80CBC4$ Center=�$��Center=�8��  ���� *
TimeText+�� $��2��$��0q�
������ ���#fff$
 Left=�$��Center=�$ WrapWithOverflow=�8�� ���� *
OutputText+.+�  -     Name$ CustomerGrid��$��Stretch=�"   VerticalScrollBarVisibility$ Hidden=�   GridLinesVisibility$
 None=�   
IsReadOnly .  .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    CanUserResizeColumns .     CanUserResizeRows .    �� AlternationCount$  1��!   RowHeaderWidth$! 20Q�"   MinRowHeight$" 20Q�#   RowHeaderStyle## [ $   RowBackground
$ ���� %   AutoGenerateColumns% .  #��[ ���� & �� Path$& Items�'   Columns' 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn(   Width$( 60 )   
FontFamily#) [ *   	CellStyle#* [ 1	  +System.Windows.Controls.DataGridBoundColumn+ 	  Binding+ �� *
TimeText+  #) [ #* [  + �� *
OutputText+