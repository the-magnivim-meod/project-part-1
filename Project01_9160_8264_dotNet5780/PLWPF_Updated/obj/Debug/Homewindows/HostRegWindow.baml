   M S B A M L   `   `   `  ����H  DPLWPF_Updated, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PLWPF_UpdatedPLWPF_Updated  5   	   !    PLWPF_Updated.HostRegWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PLWPF_Updated     5   	   $��18(�5      $��Bookman Old Style)�6(     � Title$  HostRegWindow��5   	   $	��550��6   $
��1000��6,    � 	Resources 5	       �� 
TargetType �� Property �� Value)  #PLWPF_Updated.BoolianToY_NConverter   Y_NBoolianConverter��%�   '��       &	  �     �� 5
   
   ButtonColors��" ��6&   .�5      ��  � ��
 �����6+   �� 5       � ��
 �  ��6+   5        5   
   6&   5      .��5      � -   5         �Name$ HostRegGrid��5      
������� � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � ColumnDefinitions 5!   
   �� 5"      $��20 �6   �� 5#      $��* �6   �� 5$      $
��auto �6   �� 5%      $
��auto �6   �� 5&      $��* �6   �� 5'      $��20 �6   .+�5*   
   �� $"��/Images/ProjectLogoImage.jpg��6   $��2��66   $��1��6F   $��2��6S   $	��300��6g   $��3q�6v   �� 5,   
   $
��Host��6   $��35(�6    $��2��6.   $��2��6?   $��2��6L   $��3q�6`   $
��Bold"�6k   ��5.      }� 50      �� 52   
   $3��-please fill in the feilds and press Register:��6   $��2��6I   $��2��6Y   $��3��6m   $��3q�6z   $��Center=�6�   �� 54   
   $��BankAccountNumber��6   $��2��6-   $��4��6=   $��3q�6J   �� 55   
   -   5         ��Name$ 
BankNumber��55      $��4��6�   $��3��6�   $	��150��6�   $��3q�6�   ��6&   �� *BankAccountNumber+	 �� Mode$	 OneWayToSource=�
 �� UpdateSourceTrigger$
 PropertyChanged=� �� NotifyOnValidationError .  6�   �� 57   
   $��Please select your bank��6   $��2��63   $��5��6C   $��3q�6P   �� 58   
   -   5         ��Name$ BankSelectorButton��58      $��5��6.   $��3��6;   $	��150��6K   $��3q�6W   $��SelectBanks��6b   6x   �� 5:   
   $!��Enter the your PhoneNumber:��6   $��2��67   $��6��6G   $��3q�6T   �� 5;   
   -   5        $ PhoneNumber��5;      $��6��6'   $��3��64   $	��150��6D   $��3q�6P   ��6[   �� *PhoneNumber+$	 TwoWay=�$
 PropertyChanged=�6�   �� 5=   
    �� Orientation$ 
Horizontal=�6   $��7��6.   $��2��6;   $��2��6K   .+�5>      �� $��CollectionClearance��6   $��3q�63   �� 5?      -   5         ��Name$ checkBox��5?      $��3,4,3,3q�6)    d� 	IsChecked 6:   �� *CollectionClearance+$	 TwoWay=�$
 PropertyChanged=� �� 	Converter# [  5@      �� 5C   
   -   5        $ RegisterButton��5C      $��Register��6)   $��3q�6<   $��2��6G   $��8��6W   $��2��6d   $��50��6x   ��5D      �� 5E      " ��6   ButtonAvailable�� �� Triggers 5F      �� 5G       �� Binding 6&   �� *Text.Length+ �� ElementName$ 
BankNumber��$
 PropertyChanged=� �� Value 06�   .a�5H      ��  � {� .  6:   �� 5I       � ��
 �����6;   5J      �� 5L       6&   �� *Text.Length+$ PhoneNumber��$
 PropertyChanged=� 06�   .a�5M      ��  � {� .  6:   �� 5N       � ��
 �����6;   5O      �� 5Q       6&   �� *Text.Length+$ bankWasSelected��$
 PropertyChanged=� True6�   .a�5R      ��  � {� .  6:   �� 5S       � ��
 �����6;   5T      .�5V      ��  � ��
 �  ��63   �� 5W       � ��
 �����63   �� 5X       � {� . 62   5Y      5[      � 5]   
   $��2��6   $��9��6   $��2��6,    5^      �� 5_      $��* �6#   �� 5`      $��* �6#   �� 5a      $��* �6#   �� 5b      $��* �6#   �� 5c      $��* �6#   �� 5d      $��* �6#   .+�5f      �� -   5        $
 Back��5f      $��Return��6#   $��3,0,3,3q�6H   
���   �
��� � �$��4��6   5i      5j      5k      