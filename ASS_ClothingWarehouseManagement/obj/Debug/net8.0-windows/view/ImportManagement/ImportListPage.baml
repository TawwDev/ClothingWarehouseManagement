   M S B A M L   `   `   `  ����Z  VASS_ClothingWarehouseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ASS_ClothingWarehouseManagement.view$ASS_ClothingWarehouseManagement.view  5      9    3ASS_ClothingWarehouseManagement.view.ImportListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:ASS_ClothingWarehouseManagement.view     5        N� Title$  ImportListPage��5	      .��5      � $��1��6    � ColumnDefinitions 5   
   �� 5      $	��280 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   
������� �� CornerRadius$ 5��64    �� Padding$ 15q�6E   $��0,0,10,0q�6R   ._�5      �� .+�5      �� $��Nhà cung cấp��6   $��SemiBold"�6/   �� 5      $��0,5,0,10q�6   .@�5      ��  �� 
IsSelected$
 True��6#   .��65   
Tất cả6=   �� 5      .��6#   '%Công Ty TNHH Thế Giới Di Động6B   �� 5      .��6#   Công Ty Samsung Việt Nam6=   5      �� 5      $��Nhân viên nhập��6   $��SemiBold"�61   �� 5      $��0,5,0,10q�6   .@�5      �� $
 True��6#   .��65   
Tất cả6=   �� 5      .��6#   Trần Nhật Sinh63   5!      �� 5#      $��
Từ ngày��6   $��SemiBold"�6*   (  "System.Windows.Controls.DatePicker  5$      $��0,5,0,10q�6   �� 5&      $��Đến ngày��6   $��SemiBold"�6+     5'      $��0,5,0,10q�6   �� 5)      $��Từ số tiền (VND)��6   $��SemiBold"�63   �� 5*      $��0,5,0,10q�6   �� 5,      $��Đến số tiền (VND)��6   $��SemiBold"�64   �� 5-      $��0,5,0,0q�6   5.      5/      � 52   
   $��1��6    � RowDefinitions 53      �� 54      $
��Auto �6    �� 55      $
��Auto �6    �� 56      $��* �6    .+�5:      �� $��0��6   
�������$ 5��65   $ 10q�6F   ._�5;      ��  �� Orientation$ 
Horizontal=�6   .+�5=      �� $��THÊM��6   �� 5>      $��
CHI TIẾT��6   �� 5?      $��HUỶ PHIẾU��6   5A      5B      �� 5E      $��1��6   
�������$ 5��65   $ 10q�6F   $��0,10,0,0q�6S   ._�5F      �  5G      �� 5H      $��* �6+   �� 5I      $
��Auto �6+   .+�5L      �� $��0��6!   $ 
Horizontal=�61   .+�5M      �� $��Center=�6#   $	��120��6>   .@�5N      �� $
 True��6+   .��6=   
Tất cả6E   5O      �� 5P      $&�� Nhập nội dung tìm kiếm...��6"   
�������$��Center=�6U   $	��250��6p   $
��10,0q�6   $��5q�6�   5Q      �� 5S      $��1��6   $��
Làm mới��6-   $��Center=�6?   $
��10,5q�6Z   5T      5U      &   System.Windows.Controls.DataGrid  5X      $��2��6   $��0,10,0,0q�5Y         AutoGenerateColumns$ False��5Z         
IsReadOnly$
 True��5[      	   AlternatingRowBackground	 �#f9f9f9
   CanUserAddRows$
 False��5]         HeadersVisibility$ Column=�5^      
�������$��0q�5`         Columns 5a      0  *System.Windows.Controls.DataGridTextColumn  5b      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *STT+6N     5c      $ Mã phiếu nh...��6)   $	 120 6]    6A   �� *	MaPhieu+6]     5d      $ Nhà cung cấp��6)   $ * 6^    6?   �� *
NhaCungCap+6^     5e      $ Nhân viên nhập��6)   $ * 6b    6A   �� *NhanVienNhap+6b     5f      $ Thời gian��6)   $ * 6Y    6<   �� *
ThoiGian+6Y     5g      $ Tổng tiền��6)   $ * 6q    6<   �� *
TongTien+ �� StringFormat$ {0:N0}đ��   ElementStyle 5h      �� 5i       �� 
TargetType" ��6$   .�5j   "   ��  �� Property � �� �� Value$ Right=�6H   5k      5m      5p      5r      5s      5t      