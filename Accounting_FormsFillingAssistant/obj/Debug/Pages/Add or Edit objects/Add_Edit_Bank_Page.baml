   M S B A M L   `   `   `  ����[  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  5      9    3Accounting_FormsFillingAssistant.Add_Edit_Bank_Page   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:Accounting_FormsFillingAssistant     5        N� Title$  Add_Edit_Bank_Page��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $
��15 5q�6   $��0��5      $��50��5   0   $��30(�5      $
��Bold"�6"   ��5      �� *
HeaderText+5   "   � 5   
   $��1��6   $��50 10q�5       � ColumnDefinitions 5      �� 5       $��* �6#   �� 5!      $��2* �6#   .+�5$      �� $!��Название банка��6   $��0��6.   �� 5%      $��1��6   ��5&      �� *
BankName+5(      � 5+   
   $��2��6   $��50 10q�5,       5-      �� 5.      $��* �6#   �� 5/      $��2* �6#   .+�52      �� $��
Город��6   $��0��6%   �� 53      $��1��6   ��54      �� *BankAddress+56      � 59   
   $��3��6   $��50 10q�5:       5;      �� 5<      $��* �6#   �� 5=      $��2* �6#   .+�5@      �� $&�� Номер счета Банка��6   $��0��61   �� 5A      $��1��6   ��5B      �� *BankAccount+ �� UpdateSourceTrigger$ PropertyChanged=�5D      � 5G   
   $��4��6   $��50 10q�5H       5I      �� 5J      $��* �6#   �� 5K      $��2* �6#   .+�5N      �� $��БИК��6   $��0��6#   �� 5O      $��1��6   ��5P      �� *	BankBIK+5Q      �� 5S   
    �� Orientation$ 
Horizontal=�6   $��Center=�5T      $��5��5U      $��10q�5V      .+�5X      �� $��5q�5Y      $	��100��5Z      $��25��5[      ��5X      �� *OkButtonContent+��5\      �� *
AddNewBank+�� 5_      $��Закрыть��6   $��5q�5`      $	��100��5a      $��25��5b      ��5c      �� *
CancelPage+5e      5h      5i      