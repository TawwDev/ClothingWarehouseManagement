   M S B A M L   `   `   `  ����Z  VASS_ClothingWarehouseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ASS_ClothingWarehouseManagement.view$ASS_ClothingWarehouseManagement.view  5      ;    5ASS_ClothingWarehouseManagement.view.SupplierListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:ASS_ClothingWarehouseManagement.view     5        N� Title$  SupplierListPage��5	      .��5      � $��15q�6   $��1��6   .+�5   
   �� 
������� �� CornerRadius$ 8��6$    �� Padding$ 15q�65   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      � $��0��6   $��0,0,0,15q�6$    � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5      �� $��0��6!    �� Orientation$ 
Horizontal=�61   .+�5      �� $	��Add��6!   $��10, 0, 10, 0q�6/   �� 5      $
��Edit��6!   $��10, 0, 10, 0q�60   $��10, 0, 0, 0q�6G   �� 5      $��Delete��6!   $��10, 0, 10, 0q�62   $��10, 0, 0, 0q�6I   �� 5       $
��View��6!   $��10, 0, 10, 0q�60   $��10, 0, 0, 0q�6G   5!      �� 5$      $��2��6!   $ 
Horizontal=�61   $��Center=�6J   .+�5%      �� $	��120��6#   $��5q�62   .@�5&      ��  �� 
IsSelected$
 True��6+   .��6=   
Tất cả6E   �� 5'      .��6+   Apple62   �� 5(      .��6+   	Samsung64   �� 5)      .��6+   Vivo61   5*      �� 5+      $&�� Nhập nội dung tìm kiếm...��6"   
�������$	��250��5-      $
��10,0q�5.      $��5q�5/      $��Center=�50      �� 51      $��
Làm mới��6!   $
��10,5q�63   52      53      &   System.Windows.Controls.DataGrid  56      -   5          Name$ ProductDataGrid��57      $��1��56         AutoGenerateColumns$ False��58      	   
IsReadOnly$
	 True��59      
   AlternatingRowBackground
 �#f9f9f9   CanUserAddRows$ False��5;         HeadersVisibility$ Column=�5<         GridLinesVisibility$ 
Horizontal=�5=         HorizontalGridLinesBrush �#e0e0e0$��0q�5?         Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã SP��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	ProductId+6Z     5B      $ Tên sản phẩm��6-   $ 2* 6c    6C   �� *ProductName+6c     5C      $ Số lượng tồn��6-   $ * 6e    6C   �� *StockQuantity+6e     5D      $ Thương hiệu��6-   $ * 6\    6B   �� *Brand+6\     5E      $ Hệ điều hành��6-   $ * 6g    6C   �� *OperatingSystem+6g     5F      $ Kích thước màn��6-   $ * 6d    6E   �� *
ScreenSize+6d     5G      $ Chip xử lý��6-   $
 1.5* 6_    6A   �� *	Processor+6_     5H      $ Dung lượng pin��6-   $ * 6i    6E   �� *BatteryCapacity+6i     5I      $ Xuất xứ��6-   $ * 6Y    6>   �� *Origin+6Y     5J      $ Khu vực kho��6-   $ * 6h    6B   �� *WarehouseLocation+6h   5O      5P      5Q      5R      5S      