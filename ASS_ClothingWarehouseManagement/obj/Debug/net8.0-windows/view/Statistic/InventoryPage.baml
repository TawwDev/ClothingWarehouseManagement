   M S B A M L   `   `   `  ����Z  VASS_ClothingWarehouseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:ASS_ClothingWarehouseManagement.view.Statistic.ASS_ClothingWarehouseManagement.view.Statistic  5      B    <ASS_ClothingWarehouseManagement.view.Statistic.InventoryPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Nlocal<clr-namespace:ASS_ClothingWarehouseManagement.view.Statistic     5      -   5          N� Title$  InventoryPage��5
      .��5      � .+�5   
   �� $��14(�6   $��0q�6#   $��5q�67   .@�5      �� $��OverView��6    �� 
IsSelected$
 True��6(   .��5      � $��5,5,5,5q�6    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5      � $��0��6   $��	5,10,5,10q�6(    � ColumnDefinitions 5      �� 5      $��* �6/   �� 5      $��* �6/   �� 5      $��* �6/   .+�5      �� $��0��6!    �� Padding$ 15q�61   $��5,0,5,0q�6>   ���#F8F9FA �� CornerRadius$ 5��6d   ._�5      �  5    "   �� 5!   &   $
��Auto �67   �� 5"   &   $��* �67   .+�5&   "   �� $��0��6)   $��50��69   $��50��6D   $��Center=�6P   ._�5'   &   �� $��/view/Image/Product.png��6,   6O   5(   #   �� 5+   "   $��1��6-   $��Center=�6=   $��15,0,0,0q�6X   .+�5,   &   �� -   5         ��Name$ tbTotalProduct��5,   0   $�� ��6I   $��24(�6Q   $
��Bold"�6_   ���#5A6C7C6q   �� 5-   &   $��Products in Stock��60   $��12(�6I   
�������$
��Wrap=�6i   5.   #   5/      50      �� 53      $��1��6!   $ 15q�61   $��5,0,5,0q�6>   ���#F8F9FA$ 5��6d   ._�54      �  55   "   �� 56   &   $
��Auto �67   �� 57   &   $��* �67   .+�5;   "   �� $��0��6)   $��50��69   $��50��6D   $��Center=�6P   ._�5<   &   �� $��/view/Image/Customer.png��6,   6P   5=   #   �� 5@   "   $��1��6-   $��Center=�6=   $��15,0,0,0q�6X   .+�5A   &   �� -   5        $ tbTotalCustomer��5A   0   $�� ��6I   $��24(�6Q   $
��Bold"�6_   ���#5A6C7C6q   �� 5B   &   $��Total Customers��60   $��12(�6G   
�������$
��Wrap=�6g   5C   #   5D      5E      �� 5H      $��2��6!   $ 15q�61   $��5,0,5,0q�6>   ���#F8F9FA$ 5��6d   ._�5I      �  5J   "   �� 5K   &   $
��Auto �67   �� 5L   &   $��* �67   .+�5P   "   �� $��0��6)   $��50��69   $��50��6D   $��Center=�6P   ._�5Q   &   �� $��/view/Image/Supplier.png��6,   5R   #   �� 5U   "   $��1��6-   $��Center=�6=   $��15,0,0,0q�6X   .+�5V   &   �� -   5        $ tbTotalSupplier��5V   0   $�� ��6I   $��24(�6Q   $
��Bold"�6_   ���#5A6C7C6q   �� 5W   &   $��Total Supplier��60   $��12(�6F   
�������$
��Wrap=�6f   5X   #   5Y      5Z      5[      � 5]      $��1��6   $��
10,0,10,20q�6(   $��Center=�6<    5^      �� 5_      $
��Auto �6/   �� 5`      $��* �6/   �� 5a      $
��Auto �6/   �� 5b      $��* �6/   �� 5c      $
��Auto �6/   .+�5f      �� $��
From Date:��6$   $��0��66   $��Center=�6F   (  "System.Windows.Controls.DatePicker  5g      -   5          Name$ dpFromDateOverView��5g   %   $��1��6A   $��5,0,20,0q�6Q   $��Center=�6c   6~   �� 5i      $��To Date:��6$   $��2��64   $��Center=�6D     5j      -   5        $ dpToDateOverView��5j   %   $��3��6?   $��5,0,0,0q�6O   $��Center=�6`   6{   5k      &   System.Windows.Controls.DataGrid  5m      -   5          Name$ dgSalesReport��5m   ,   $��2��6   	   AutoGenerateColumns$	 False��5n      
   
IsReadOnly$

 True��6;      Columns 5p      0  *System.Windows.Controls.DataGridTextColumn  5q      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Date+6X     5r      $ Capital��61   $ * 6^    6B   �� *	Capital+6^     5s      $ Revenue��61   $ * 6^    6B   �� *	Revenue+6^     5t      $ Profit��61   $ * 6\    6A   �� *Profit+6\   5v      5x      5y      �� 5z      $��	Inventory��6   .��5{      �  5|      �� 5}      $��42.368 �6+   �� 5~      $��207.632 �6+   �� 5      $��* �6+   .+�5�      �� $��0��6   
�������$ 5��6@   $ 20q�6Q   $��2��6^   ._�5�      �� .+�5�      �� $��Search Product��6(   $��SemiBold"�6>   $��0,0,0,5q�6T   �� 5�      $��5q�6&   $��14(�62   �� 5�      $��	From Date��6(   $��SemiBold"�69   $��0,20,0,5q�6O     5�      $��5q�6)   $��14(�65   �� 5�      $��To Date��6(   $��SemiBold"�67   $��0,20,0,5q�6M     5�      $��5q�6)   $��14(�65   �� 5�      $��Refresh��6%   $��0, 50, 0, 0q�67   5�      5�        5�      $��2��6   $	 False��5�      $

 True��67      CanUserAddRows$ False��5�         RowHeaderWidth$ 0Q�5�         GridLinesVisibility$ 
Horizontal=�5�         HorizontalGridLinesBrush �#E0E0E0$��
0,10,10,10q�5�         AlternatingRowBackground �#FAFAFA
���������5�   /   �� *InventoryItems+ 5�        5�      $ Id��61   $ 40 6V    6=   �� *MaSP+6V     5�      $ Product Name��61   $ 1* 6f    6G   �� *
TenSanPham+6f     5�      $ Begin Inventory��61   $ 1* 6g    6J   �� *
TonDauKy+6g     5�      $ In��61   $
 0.6* 6]    6=   �� *NhapTrongKy+6]     5�      $	 Out��61   $
 0.6* 6^    6>   �� *XuatTrongKy+6^     5�      $ End Inventory��61   $ 1* 6f    6H   �� *	TonCuoiKy+6f   5�      5�      5�      5�      5�      5�      