   M S B A M L   `   `   `  ����H  DPLWPF_Updated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PLWPF_UpdatedPLWPF_Updated  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	   )    #PLWPF_Updated.HostingUnitDataWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PLWPF_Updated     5   	   +BEclr-namespace:BE;assembly=BE     5   	     � Title$  HostingUnitDataWindow��5	   	   $	��450��6'   $	��800��64   .��5
      � -   5         �Name$ GuestRequestGrid��5
      
����� � � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��HostingUnits:��6   $��2��6)   $��1��69   $��40(�6F   $
��Bold"�6T   $��3q�6f   ��5      }� 5      &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ GuestRequestDataGrid��5!      $��2��61   $��2��6>   $	��700��6N      
IsReadOnly . $��3q�6l      AutoGenerateColumns .  ��6w   �� *hostingUnits+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ HostingUnitKey��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6=   �� *HostingUnitKey+  5$      $ Owner��6%   	 64   �� *Owner+  5%      $ HostingUnitName��6%   	 6>   �� *HostingUnitName+  5&      $
 Type��6%   	 63   �� *Type+  5'      $
 Area��6%   	 63   �� *Area+  5(      $ HasPool��6%   	 66   �� *	HasPool+  5)      $ 	HasGarden��6%   	 68   �� *	HasGarden+  5*      $ HasNearByGroceryStore��6%   	 6D   �� *HasNearByGroceryStore+  5+      $ HasChildrensAttractions��6%   	 6F   �� *HasChildrensAttractions+5-      � 5/   
   $��2��6   $��3��6    50      �� 51      $��* �6#   �� 52      $��* �6#   �� 53      $��* �6#   �� 54      $��* �6#   .+�57      �� -   5        
 ��Name$

 Back��57      $��Return��6#   $��3q�65   
���   �
��� � �$��2��6f   $��30��6v   6�   �� 58      -   5        $
 LogOff��58      $��Log Off��6%   $��3q�68   
���   �
��� � �$��3��6i   $��30��6z   6�   59      5:      5;      