   M S B A M L   `   `   `  ����H  DPLWPF_Updated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PLWPF_UpdatedPLWPF_Updated  5   	   #    PLWPF_Updated.OrderDataWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PLWPF_Updated     5   	     � Title$  OrderDataWindow��5   	   $	��450��6!   $	��800��6.   .��5	      � -   5         �Name$ GuestRequestGrid��5	      
����� � � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��Orders:��6   $��2��6#   $��1��63   $��40(�6@   $
��Bold"�6N   $��3q�6`   ��5      }� 5      &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ GuestRequestDataGrid��5!      $��2��61   $��2��6>   $	��700��6N      
IsReadOnly . $��3q�6�   ��6Z   �� *Orders+6�   � 5#   
   $��2��6   $��3��6    5$      �� 5%      $��* �6#   �� 5&      $��* �6#   �� 5'      $��* �6#   �� 5(      $��* �6#   .+�5+      �� -   5         ��Name$
 Back��5+      $��Return��6#   $��3q�65   
���   �
��� � �$��2��6f   $��30��6v   6�   �� 5,      -   5        $ LogOff��5,      $��Log Off��6%   $��3q�68   
���   �
��� � �$��3��6i   $��30��6z   6�   5-      5.      5/      