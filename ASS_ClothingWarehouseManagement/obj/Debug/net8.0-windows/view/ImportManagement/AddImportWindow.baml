   M S B A M L   `   `   `  ����Z  VASS_ClothingWarehouseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ASS_ClothingWarehouseManagementASS_ClothingWarehouseManagement  5   	   5    /ASS_ClothingWarehouseManagement.AddImportWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:ASS_ClothingWarehouseManagement     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Title$ AddImportWindow��5
   	   $	��600��6!   $
��1200��6.   .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $��7* �6#   �� 5      $��3* �6#   .+�5      �� $��0��6   
�������$��	0,10,5,10q�68    �� CornerRadius$ 8��6K    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 1Q�6'      	Direction$	 270Q�67      Color$ Black��6G      Opacity$
 0.15Q�6U   	   
BlurRadius$	 10Q�6d   ._�5      � 
 � RowDefinitions
 5      �� 5      $��6* �6(   �� 5      $��4* �6(   .+�5      � $��0��6    5       �� 5!      $��* �6/   �� 5"      $��* �6/   .+�5&      �� $��0��6%   $��10q�65   .+�5'      �� -   5         ��Name$ tbSearch��5'   &   $�� ��68   6@   &   System.Windows.Controls.DataGrid  5(      -   5          Name$ 	dgProduct��5(   '   $��0,5,0,5q�6:   "   VerticalScrollBarVisibility$
 Auto=�6K   $	��200��6n   $	��265��6~      AutoGenerateColumns$ False��6�      Columns 5)   "   0  *System.Windows.Controls.DataGridTextColumn  5*   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Id��69      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6R   �� *	ProductId+  5+   &   $ Product Name��69   $ 2* 6O    6Z   �� *ProductName+  5,   &   $ Quantity��69   $
 0.6* 6K    6X   �� *
Quantity+  5-   &   $ 	BasePrice��69   $
 0.8* 6L    6Y   �� *	BasePrice+5/      51      �� 54      $��1��6%   $��10q�65   .+�55      �  56   "   �� 57   &   $��* �67   �� 58   &   $��* �67   .+�5:   "   �� $��0��6-   $��0,0,5,0q�6=   .+�5;   &   �� $��Product Code��6,   �� 5<   &   -   5        $ tbProductId��5<   .    �� 
IsReadOnly$
 True��6C   5=   #   �� 5>   "   $��1��6-   $��5,0,0,0q�6=   .+�5?   &   �� $��Product Name��6,   �� 5@   &   -   5        $ tbProductName��5@   .   $
 True��6E   5A   #   5B      � 5C      $��0,5,0,0q�6#    5D   "   �� 5E   &   $��* �67   �� 5F   &   $��* �67   .+�5H   "   �� $��0��6-   $��0,0,5,0q�6=   .+�5I   &   �� $��Material��6,   �� 5J   &   -   5        $ tbProductMaterial��5J   .   $
 True��6I   5K   #   �� 5L   "   $��1��6-   $��5,0,0,0q�6=   .+�5M   &   �� $��	Quantity*��6,   �� 5N   &   -   5        $ tbDetailQuantity��5N   .   5O   #   5P      � 5Q      $��0,5,0,0q�6#    5R   "   �� 5S   &   $��* �67   �� 5T   &   $��* �67   5X      � 5Y      $��0,5,0,0q�6#    5Z   "   �� 5[   &   $��* �67   �� 5\   &   $��* �67   .+�5`   "   �� $��0��6-   $��0,0,5,0q�6=   .+�5a   &   �� $��Unit Price*��6,   �� 5b   &   -   5        $ tbDetailPrice��5b   .   5c   #   �� 5d   "   $��1��6-    �� Orientation$ 
Horizontal=�6=   $��0,20,0,0q�6V   .+�5e   &   �� -	   5         ��Name$ btnAddProductToTheOrder��5e   -   $	��Add��6N   ���#07a646
�������$	��8,5q�6�   $��10, 0, 0, 0q�6�   6�   �� 5f   &   -
   5        $ btnUpdateProductInOrder��5f   -   $��Update��6N   ���	#FF074BA6
�������$	��8,5q�6�   $��15, 0, 0, 0q�6�   6�   �� 5g   &   -   5        $ btnDeleteProductInOrder��5g   -   $��Delete��6N   ���#bd0404
�������$	��8,5q�6�   $��15, 0, 0, 0q�6�   6�   5h   #   5i      5k      5l        5o      -   5        $ dgImportRecreiptDetail��5r      $��1��5o      $��
10,0,10,10q�6,      CanUserAddRows$ False��5p      $ False��5q       5t        5u      $ 
Product Id��61   $ 1* 6E    6P   �� *Product.ProductId+  5v      $ Product Name��61   $ 2* 6G    6R   �� *Product.ProductName+  5w      $ Material��61   $ 2* 6C    6N   �� *Product.Material+  5x      $ Quantity��61   $ 1* 6C    6N   �� *
Quantity+  5y      $ 
Unit Price��61   $
 1.5* 6E    6R   �� *	UnitPrice+5{      5|      5}      �� 5�      $��1��6   
�������$��
5,10,10,10q�68   $ 8��6L    5�        5�      $ 1Q�6'   $	 270Q�67   $ Black��6G   $
 0.15Q�6U   $	 10Q�6d   ._�5�      � 
 5�      �� 5�      $��* �6(   �� 5�      $
��Auto �6(   .+�5�      �� $��0��6!   $��15q�6.   .+�5�      �� $��Import receipt code��6    �� 5�      -   5        $ tbImportReceiptId��5�   "   $
 True��6=   �� 5�      $��Staff Created��6    $��0,10,0,0q�68   �� 5�      -   5        $ tbCreatedBy��5�   "   $�� ��67   $
 True��6?   �� 5�      $��Supplier��6    $��0,10,0,0q�63   �� 5�      -   5         ��Name$ 
cbSupplier��5�   #   5�      �� 5�      $��1��6!   $��15q�6.   .+�5�      �� -   5         ��Name$ tbTotalAmount��5�   $   $�� ��6;   $
��Bold"�6C   
���  ��$��16(�6f   $��Right=�6t   $��0,0,0,10q�6�   �� 5�      -   5        $ btnAddImportReceipt��5�   !   $��Create Import��6>   ���#27ae60
�������$��10q�6~   $
��Bold"�6�   $��40��6�   6�   5�      5�      5�      5�      5�      5�      