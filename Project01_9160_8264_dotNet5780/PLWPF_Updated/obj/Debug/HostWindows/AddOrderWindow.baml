   M S B A M L   `   `   `  ����H  DPLWPF_Updated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PLWPF_UpdatedPLWPF_Updated  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   
   "    PLWPF_Updated.AddOrderWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PLWPF_Updated     5   	   +BEclr-namespace:BE;assembly=BE     5   
   $��18(�5      $��Bookman Old Style)�6*     � Title$  AddOrder��5
      .��5      � -   5         �Name$ AddOrderGrid��5      
����� � � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5    
   �� $��Welcome To Add Order��6   $��1��60   $��47��6=   $��2��6I   $��2��6Y   $��Center=�6n   $
��Bold"�6�   $��36(�6�   $��	Underline{�6�   �� 5"   
   $��Choose Hosting Unit:��6   $��3q�60   $��2��6;   $��3��6K   �� 5#   
   -   5         ��Name$ HostingUnits��5#      $��3q�6)   $��3��64   $��3��6D    �� SelectedIndex$ 0��6Q   6c   &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ guestRequestDataGrid��5$      $��4��61   $��2��6>   $��2��6N   $	��240��6z   $	��500��6�   $	��240��6�   $	��500��6�      
IsReadOnly . ��6b   �� 6�   � 5&   
   $��2��6   $��5��6   $��2��6,    5'      �� 5(      $��* �6#   �� 5)      $��* �6#   �� 5*      $��* �6#   �� 5+      $��* �6#   �� 5,      $��* �6#   �� 5-      $��* �6#   .+�5/      �� -   5         ��Name$
 Back��5/      $��Return��6#   $��3q�6H   
���   �
��� � �$��4��6y   $��30��6�   �� 50      -   5        $ LogOff��50      $��Log Off��6%   $��3q�68   
���   �
��� � �$��5��6i   $��30��6�   51      52      53      