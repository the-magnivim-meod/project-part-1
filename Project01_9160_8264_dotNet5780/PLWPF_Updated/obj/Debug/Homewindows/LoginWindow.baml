   M S B A M L   `   `   `  ����H  DPLWPF_Updated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PLWPF_UpdatedPLWPF_Updated  5   	       PLWPF_Updated.LoginWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PLWPF_Updated     5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   $��18(�5      $��Bookman Old Style)�6(     � Title$  Login��5	   	   $	��450��6   $	��600��6$   .��5
      � 
������� � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $"��/Images/ProjectLogoImage.jpg��6   $��2��66   $��1��6F   $	��375��6S   $��3q�6b   �� 5    
   $��Login or Register:��6   $��35(�6.   $��2��6<   $��2��6L   $��3q�6Y   �� 5"   
   $��2��6   $��3��6%    �� Orientation$ 
Horizontal=�62   .+�5#      �� $��	UserName:��6   $��2��6)   $��3��69   $��3q�6F   �� 5$      -   5         ��Name$ UserName��5$      $��3��6(   $��2��65   $	��150��6E   
�������6�   5&      �� 5(   
   $��2��6   $��4��6%   $ 
Horizontal=�62   .+�5)      �� $��	Password:��6   $��2��6)   $��4��69   $��3q�6F   G� 5*      -   5         G�Name$ UserPassword��5*      $	��150��60   $��7,0,0,0q�6<   
�������6�   5+      � 5-   
   $��5��6   $��2��6    5.      �� 5/      $��* �6#   �� 50      $��* �6#   .+�53      �� -   5         ��Name$ LoginButton��53      $��Login��6*   $��0��6:   $��50��6K   {�.  $	��Top=�6�   �� 54      -   5        $ RegisterButton��54      $��Register��6-   $��1��6@   
�������
���  ��$��50��6w   $��0.333,0,-0.333,0q�6�   $��Bottom=�6�   55      56      57      