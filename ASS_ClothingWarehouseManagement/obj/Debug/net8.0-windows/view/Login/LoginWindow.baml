   M S B A M L   `   `   `  ����Z  VASS_ClothingWarehouseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ASS_ClothingWarehouseManagementASS_ClothingWarehouseManagement  5   	   1    +ASS_ClothingWarehouseManagement.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:ASS_ClothingWarehouseManagement     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ LoginWindow��5	   	   $	��450��6   $	��800��6*   .��5
      � .+�5   
   �� $��Center=�6   .+�5      �� $��Login��6   $��40(�5      $
��Bold"�5      $��Center=�5      $��0,0,0,10q�5      ���#3333335      � 5      $��1��6   $��Center=�6    $��Center=�6=   $	��400��6X   $	��200��6d   .+�5      ��  �� CornerRadius$ 8��6   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6+      ShadowDepth$ 1Q�5         	Direction$	 315Q�5         Color$ Black��5         Opacity$	 0.7Q�5      5      �� 5!      $ 8��6   
�������$
}�True��6=   ._�5"      � 	 � RowDefinitions	 5#      �� 5$      $
��3.5* �6,   �� 5%      $
��3.5* �6,   �� 5&      $
��2.5* �6,   .+�5(      �� $��Center=�6%   .+�5)      �� $��	User Name��6$   $��20, 0, 0, 0q�68   �� 5*      -   5        
 ��Name$
 
tbUserName��5*   &   $	��350��6:   $��30��6F   5+      �� 5,      $��1��6%   .+�5-      �� $��	Pass Word��6$   $��20, 0, 0, 0q�68   G� 5.      -   5         G�Name$ 
pbPassWord��5.   *   $	��350��6>   $��30��6J   5/      � 50      $��2��6   $	��Top=�6,    � ColumnDefinitions 51      �� 52   "   �� 53   "   .+�55      �� -   5         ��Name$ btnLogin��55   %   $��Login��67   $	��100��6G   $��30��6S   $��Right=�6_   $��0, 0, 20, 0q�6{   6�   �� 56      -   5        $ btnExit��56   %   $��1��66   $	��100��6F   $��30��6R   $
��Left=�6^   $
��Exit��6y   $��20, 0, 0, 0q�6�   6�   57      58      59      5;      5<      5=      5?      