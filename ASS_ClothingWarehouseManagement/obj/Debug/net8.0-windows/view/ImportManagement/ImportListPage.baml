   M S B A M L   `   `   `  ����Z  VASS_ClothingWarehouseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ASS_ClothingWarehouseManagement.view$ASS_ClothingWarehouseManagement.view  5      9    3ASS_ClothingWarehouseManagement.view.ImportListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:ASS_ClothingWarehouseManagement.view     5      -   5          N� Title$  ImportListPage��5
      .��5      � $��1��6    � ColumnDefinitions 5   
   �� 5      $	��280 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   
������� �� CornerRadius$ 5��64    �� Padding$ 15q�6E   $��0,0,10,0q�6R   ._�5      �� .+�5      �� $��Supplier��6   $��SemiBold"�6+   �� 5      -   5         ��Name$ 
cbSupplier��5      $��0,5,0,10q�6/   5      �� 5      $��	From date��6   $��SemiBold"�6,   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpFrom��5      $��0,5,0,10q�6-   6?   �� 5      $��To date��6   $��SemiBold"�6*     5      -   5        $
 dpTo��5      $��0,5,0,10q�6+   6=   �� 5      $��From amount (VND)��6   $��SemiBold"�64   �� 5       -   5         ��Name$ tbFromAmount��5       $��0,5,0,10q�60   6B   �� 5"      $��To amount (VND)��6   $��SemiBold"�62   �� 5#      -   5        $ 
tbToAmount��5#      $��0,5,0,0q�6.   6?   5$      5%      � 5(   
   $��1��6    � RowDefinitions 5)      �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    �� 5,      $��* �6    .+�50      �� $��0��6   
�������$ 5��65   $ 10q�6F   ._�51      ��  �� Orientation$ 
Horizontal=�6   .+�53      �� -   5        	 ��Name$	 btnAddImportRecept��53      $	��Add��69   $��10, 0, 10, 0q�6G   6^   �� 54      -   5        $	 btnViewImportRecept��54      $
��View��6:   $��10, 0, 10, 0q�6I   $��10, 0, 0, 0q�6`   6u   �� 55      -	   5        $	 
btnRefresh��55      $��Refresh��61   $��10, 0, 10, 0q�6C   $��10, 0, 0, 0q�6Z   6o   56      57      �� 5:      $��1��6   
�������$ 5��65   $ 10q�6F   $��0,10,0,0q�6S   ._�5;      �  5<      �� 5=      $��* �6+   �� 5>      $
��Auto �6+   .+�5A      �� $��0��6!   $ 
Horizontal=�61   .+�5B      �� -
   5        $ tbSearch��5B   "   
�������$��Center=�6F   $	��350��6a   $
��10,0q�6p   $��5q�6~   6�   5C      5F      5G      &   System.Windows.Controls.DataGrid  5J      -   5        
  Name$
 dgImportRecept��5K      $��2��5J      $��0,10,0,0q�5L         AutoGenerateColumns$ False��5M         
IsReadOnly$
 True��5N         AlternatingRowBackground �#f9f9f9   CanUserAddRows$ False��5P         HeadersVisibility$ Column=�5Q      
�������$��0q�5S         Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$ ReceptId��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *	ReceiptId+6Y     5V      $ Supplier��6)   $
 1.5* 6e    6;   �� *Supplier.SupplierName+6e     5W      $ 
Created By��6)   $ 1* 6n    6=   �� *CreatedByNavigation.FullName+6n     5X      $ Created Date��6)   $ 1* 6]    6?   �� *	CreatedAt+6]     5Y      $ Total Amount��6)   $ 1* 6_    6?   �� *TotalAmount+   ElementStyle 5Z      �� 5[       �� 
TargetType" ��6$   .�5\   "   ��  �� Property � �� �� Value$
 Left=�6H   5]      5_      5b      5d      5e      5f      