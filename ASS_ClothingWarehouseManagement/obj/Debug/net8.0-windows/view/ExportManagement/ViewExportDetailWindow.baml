   M S B A M L   `   `   `  ����Z  VASS_ClothingWarehouseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Cclr-namespace:ASS_ClothingWarehouseManagement.view.ExportManagement5ASS_ClothingWarehouseManagement.view.ExportManagement  5   	   L    FASS_ClothingWarehouseManagement.view.ExportManagement.ViewExportWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   UlocalCclr-namespace:ASS_ClothingWarehouseManagement.view.ExportManagement     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ ViewExportWindow��5
   	   $	��450��6"   $	��800��6/   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   ���#2980b9 �� Padding$ 15q�67   ._�5      �� $��EXPORT RECEIPT DETAIL��6   
�������$��20(�5      $
��Bold"�5      $��Center=�5      5      � 5      $��1��6   $��10q�6     5      �� 5       $
��Auto �6$   �� 5!      $
��Auto �6$    � ColumnDefinitions 5#      �� 5$      �� 5%      .+�5'      � $��0��6    5(      �� 5)      $	��130 �6+   �� 5*      .+�5,      �� $��0��6    $��Import Receipt Id:��60   $��Center=�6J   $��5q�6e   �� 5-      -   5         ��Name$ 
tbImportId��5-      $��1��62   $��5q�6B    �� 
IsReadOnly$
 True��6M   5.      � 5/      $��1��6    50      �� 51      $	��130 �6+   �� 52      .+�54      �� $��0��6    $��Created Date:��60   $��Center=�6E   $��5q�6`   �� 55      -   5        $ tbCreatedDate��55      $��1��65   $��5q�6F   $
 True��6Q   56      � 57      $��0��6   $��1��6'    58      �� 59      $	��130 �6+   �� 5:      .+�5<      �� $��0��6    $��Staff Created:��60   $��Center=�6F   $��5q�6a   �� 5=      -   5        $ tbCreatedBy��5=      $��1��63   $��5q�6D   $
 True��6O   5>      � 5?      $��1��6   $��1��6'    5@      �� 5A      $	��130 �6+   �� 5B      .+�5D      �� $��0��6    $��	Customer:��60   $��Center=�6A   $��5q�6\   �� 5E      -   5        $ 
tbCustomer��5E      $��1��62   $��5q�6C   $
 True��6N   5F      5G      &   System.Windows.Controls.DataGrid  5J      -   5          Name$ dgExportReceptDetail��5K      $��2��5J      $��10,10,10,10q�5L         AutoGenerateColumns$ False��5M      	   
IsReadOnly$
	 True��5N      
   AlternatingRowBackground
 �#f9f9f9   CanUserAddRows$ False��5P         HeadersVisibility$ Column=�5Q      
�������$��0q�5S         Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$ 	ProductId��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Product.ProductId+6b     5V      $ Product Name��6)   $
 1.8* 6g    6?   �� *Product.ProductName+6g     5W      $ Quantity��6)   $ 1* 6X    6;   �� *
Quantity+6X     5X      $ 
Unit Price��6)   $
 1.2* 6[    6=   �� *	UnitPrice+6[   5Z      � 5_      $��3��6   $��10q�6     5`      �� 5a      �� 5b      .+�5d      �� -   5         ��Name$ 	btnCancel��5d   )   $��0��6   $
��Left=�6<   $��Cancel��6W   $��70��6h   $��30��6s   6   �� 5e      -   5         ��Name$ tbTotalAmount��5e   ,   $��1��6   $�� ��6C   $
��Bold"�6K   
���  ��$��16(�6n   $��Right=�6|   $��15,15,40,15q�6�   5f      5g      5h      5i      