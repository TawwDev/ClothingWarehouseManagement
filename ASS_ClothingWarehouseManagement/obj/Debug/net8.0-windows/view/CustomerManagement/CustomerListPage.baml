   M S B A M L   `   `   `  ����Z  VASS_ClothingWarehouseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Eclr-namespace:ASS_ClothingWarehouseManagement.view.CustomerManagement7ASS_ClothingWarehouseManagement.view.CustomerManagement  5      N    HASS_ClothingWarehouseManagement.view.CustomerManagement.CustomerListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      WlocalEclr-namespace:ASS_ClothingWarehouseManagement.view.CustomerManagement     5      -   5          N� Title$  CustomerListPage��5
      .��5      � $��15q�6   $��1��6   .+�5   
   �� 
������� �� CornerRadius$ 8��6$    �� Padding$ 15q�65   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      � $��0��6   $��0,0,0,15q�6$    � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5      �� $��0��6!    �� Orientation$ 
Horizontal=�61   .+�5      �� -   5         ��Name$ btnAddCustomer��5   !   $	��Add��69   $��10, 0, 10, 0q�6G   6^   �� 5      -   5        $ btnEditCustomer��5   !   $
��Edit��6:   $��10, 0, 10, 0q�6I   $��10, 0, 0, 0q�6`   6u   �� 5       -   5        $ btnDeleteCustomer��5    !   $��Delete��6<   $��10, 0, 10, 0q�6M   $��10, 0, 0, 0q�6d   6y   �� 5!      -   5        $ 
btnRefresh��5!   !   $��Refresh��65   $��10, 0, 10, 0q�6G   $��10, 0, 0, 0q�6^   6s   5"      �� 5%      $��2��6!   $ 
Horizontal=�61   $��Center=�6J   .+�5&      �� -   5         ��Name$ tbSearch��5&   "   $�� ��64   
�������$	��250��5(      $
��10,0q�5)      $��5q�5*      $��Center=�5+      6<   5,      5-      &   System.Windows.Controls.DataGrid  50      -   5          Name$ 
dgCustomer��51      $��1��50      	   AutoGenerateColumns$	 False��52      
   
IsReadOnly$

 True��53         AlternatingRowBackground �#f9f9f9   CanUserAddRows$ False��55         HeadersVisibility$ Column=�56         GridLinesVisibility$ 
Horizontal=�57         HorizontalGridLinesBrush �#e0e0e0$��0q�59         Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ Customer Id��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *
CustomerId+6a     5<      $ Customer Name��6-   $
 2.1* 6e    6D   �� *CustomerName+6e     5=      $ Phone��6-   $
 1.5* 6V    6<   �� *Phone+6V     5>      $ Email��6-   $
 1.5* 6V    6<   �� *Email+6V     5?      $ Address��6-   $ 3* 6Z    6>   �� *	Address+6Z     5@      $ Status��6-   $ 50 6X    6=   �� *Status+6X   5B      5C      5D      5E      5F      