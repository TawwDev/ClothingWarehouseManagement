   M S B A M L   `   `   `  ����Z  VASS_ClothingWarehouseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ASS_ClothingWarehouseManagement.view$ASS_ClothingWarehouseManagement.view  5      :    4ASS_ClothingWarehouseManagement.view.ProductListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:ASS_ClothingWarehouseManagement.view     5      -   5          N� Title$  ProductListPage��5
      .��5      � $��15q�6   $��1��6   .+�5   
   �� 
������� �� CornerRadius$ 8��6$    �� Padding$ 15q�65   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      � $��0��6   $��0,0,0,15q�6$    � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5      �� $��0��6!    �� Orientation$ 
Horizontal=�61   .+�5      �� -   5         ��Name$ btnAddProduct��5   !   $	��Add��68   $��10, 0, 10, 0q�6F   6]   �� 5      -   5        $ btnEditProduct��5   !   $
��Edit��69   $��10, 0, 10, 0q�6H   $��10, 0, 0, 0q�6_   6t   �� 5       -   5        $ btnDeleteProduct��5    !   $��Delete��6;   $��10, 0, 10, 0q�6L   $��10, 0, 0, 0q�6c   6x   �� 5!      -   5        $ 
btnRefresh��5!   !   $��Refresh��65   $��10, 0, 10, 0q�6G   $��10, 0, 0, 0q�6^   6s   5"      �� 5%      $��2��6!   $ 
Horizontal=�61   $��Center=�6J   .+�5&      �� -   5         ��Name$ 
cbCategory��5&   #   $	��170��67   $��5q�6F   5'      �� 5(      -   5         ��Name$ tbSearchKeyWord��5)   "   $�� ��5(   "   
�������$	��250��5+   "   $
��10,0q�5,   "   $��5q�5-   "   $��Center=�5.   "   6D   5/      50      &   System.Windows.Controls.DataGrid  53      -   5        	  Name$	 	dgProduct��54      $��1��53      $
��Auto=�55      
   AutoGenerateColumns$
 False��56         
IsReadOnly$
 True��57         AlternatingRowBackground �#f9f9f9   CanUserAddRows$ False��59         HeadersVisibility$ Column=�5:         GridLinesVisibility$ 
Horizontal=�5;         HorizontalGridLinesBrush �#e0e0e0$��0q�5=         Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$
 Code��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *	ProductId+6Y     5A      $
 Name��6-   $
 1.5* 6[    6;   �� *ProductName+6[     5B      $ 
Unit Price��6-   $ * 6[    6A   �� *Price+6[     5C      $ 
Base Price��6-   $ * 6_    6A   �� *	BasePrice+6_     5D      $ Quantity��6-   $ 60 6\    6?   �� *
Quantity+6\     5E      $ Brand��6-   $
 1.3* 6V    6<   �� *Brand+6V     5F      $ Material��6-   $ * 6\    6?   �� *
Material+6\     5G      $ Category��6-   $
 1.5* 6i    6?   �� *Category.CategoryName+6i     5H      $ Status��6-   $ 45 6X    6=   �� *Status+6X   5K      5L      5M      5N      5O      