   M S B A M L   `   `   `  ����Z  VASS_ClothingWarehouseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ASS_ClothingWarehouseManagementASS_ClothingWarehouseManagement  5   	   0    *ASS_ClothingWarehouseManagement.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:ASS_ClothingWarehouseManagement     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5       � Title$ 
MainWindow��5	   	   $	��700��6   $
��1500��6)   .��5
      � ���#f0f2f5 � ColumnDefinitions 5   
   �� 5      $	��31* �6   �� 5      $	��79* �6   �� 5      $
��440* �6   .+�5   
   �� $��0��6   
�������$��10,10,10,10q�64    �� CornerRadius$ 8��6I   $��2��6Z    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 1Q�6#      	Direction$	 270Q�63      Color$ Black��6C      Opacity$
 0.15Q�6Q   	   
BlurRadius$	 10Q�6`   ._�5      �� .+�5      � 
 � RowDefinitions
 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       .+�5#      �� -   5         ��Name$ lbHello��5#   )   $��0��6   $�� ��6:   $��18(�6E   $
��Bold"�6S   $��	0,20,0,20q�6e   $��Center=�6x   �� 5$      -   5         ��Name$ 
btnProduct��5$   *   $��1��6   $��Product��6>   $��
10,0,10,20q�6P   $��40��6d   6p   �� 5%      -   5        $ 	btnImport��5%   *   $��2��6   $��Import��6=   $��
10,0,10,20q�6N   $��40��6b   6n   �� 5&      -   5        $ 	btnExport��5&   *   $��3��6   $��Export��6=   $��
10,0,10,20q�6N   $��40��6b   6n   �� 5'      -   5        $ btnSupplier��5'   *   $��4��6   $��Supplier��6?   $��
10,0,10,20q�6R   $��40��6f   6r   �� 5(      -   5        $ btnCustomer��5(   *   $��5��6   $��Customer��6?   $��
10,0,10,20q�6R   $��40��6f   6r   �� 5)      -   5        $ btnStatistics��5)   *   $��6��6   $��
Statistics��6A   $��
10,0,10,20q�6V   $��40��6j   6v   �� 5*      -	   5        $ 	btnLogOut��5*   *   $��7��6   $��Logout��6=   $��10,30,10,20q�6N   $��40��6c   $��Bottom=�6o   6�   5+      5,      5-       � 50   
   -
   5          �Name$ 	MainFrame��51      $��2��50        � NavigationUIVisibility$ Hidden=�52      $��
0,10,10,10q�53      �� 54   
   -   5         ��Name$ WelcomeContent��54      
�������$ 8��6<   $��2��6M    55        56      $ 1Q�6#   $	 270Q�63   $ Black��6C   $
 0.15Q�6Q   $	 10Q�6`   ._�58      �� $��Center=�6   $��Center=�64   .+�59      �� $��Welcome to CWM System!��6   $��32(�6:   $
��Bold"�6H   ���#3336Z   �� 5:      $;��5Please select a function from the left menu to begin.��6   $��16(�5;       
�������$��0,10,0,0q�5=       5>      5?      5@      5A      