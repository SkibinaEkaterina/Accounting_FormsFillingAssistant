   M S B A M L   `   `   `  ����[  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  5      >    8Accounting_FormsFillingAssistant.AddEditBankAccount_Page   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:Accounting_FormsFillingAssistant     5        N� Title$  AddEditBankAccount_Page��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $
��15 5q�6   $��0��5      $��50��5   0   $��30(�5      $
��Bold"�6"   ��5      �� *
HeaderText+5   "   � 5   
   $��1��6   $��50 10q�5       � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��2* �6#   .+�5"      �� $��Номер счета��6   $��0��6+   �� 5#      $��1��6   ��5$      �� *BankAccountNumber+ �� UpdateSourceTrigger$ PropertyChanged=�5&      � 5)   
   $��2��6   $��50 10q�5*       5+      �� 5,      $��* �6#   �� 5-      $��2* �6#   .+�50      �� $��Организация��6   $��0��6+   �� 51      $��1��6    �� DisplayMemberPath$ Org_Name��56      {�52      �� *IsOrganisationsEnabled+��54      �� *CollectonOfAllOrganisations+ �� SelectedItem 55      �� *SelectedOrganisation+56      5:      � 5=   
   $��3��6   $��50 10q�5>       5?      �� 5@      $��* �6#   �� 5A      $��2* �6#   .+�5D      �� $��Банк��6   $��0��6$   �� 5E      $��1��6   $ 	Bank_Name��5H      ��5F      �� *CollectionOfAllBanks+ 5G      �� *SelectedBank+5H      5J      �� 5N   
    �� Orientation$ 
Horizontal=�6   $��Center=�5O      $��4��5P      $��10q�5Q      .+�5S      �� $��5q�5T      $	��100��5U      $��25��5V      ��5S      �� *OkButtonContent+��5W      �� *AddNewBankAccount+�� 5Z      $��Закрыть��6   $��5q�5[      $	��100��5\      $��25��5]      ��5^      �� *
CancelPage+5`      5a      5b      