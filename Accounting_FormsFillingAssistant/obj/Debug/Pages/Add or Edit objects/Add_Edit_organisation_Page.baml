   M S B A M L   `   `   `  ����[  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  5      <    6Accounting_FormsFillingAssistant.Add_organisation_Page   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:Accounting_FormsFillingAssistant     5        N� Title$  Add_organisation_Page��5	       � 	Resources 5      ��%    5      .��5      � 
�������$��5q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $
��15 5q�6   $��0��5      $��50��5   0   $��30(�5      $
��Bold"�6"   ��5      �� *
HeaderText+5   "   � 5!   
   $��1��6   $��50 10q�5"       � ColumnDefinitions 5#      �� 5$      $��* �6#   �� 5%      $��2* �6#   .+�5(      �� $-��'Название организации��6   $��0��64   �� 5)      $��1��6   ��5*      �� *OrganisationName+5,      � 5/   
   $��2��6   $��50 10q�50       51      �� 52      $��* �6#   �� 53      $��2* �6#   .+�56      �� $��
Адрес��6   $��0��6%   �� 57      $��1��6   ��58      �� *OrganisationAddress+5:      � 5=   
   $��3��6   $��50 10q�5>       5?      �� 5@      $��* �6#   �� 5A      $��2* �6#   .+�5D      �� $��ИНН��6   $��0��6#   �� 5E      $��1��6   ��5F      �� *OrganisationINN+ �� UpdateSourceTrigger$ PropertyChanged=�5G      � 5J   
   $��4��6   $��50 10q�5K       5L      �� 5M      $��* �6#   �� 5N      $��2* �6#   .+�5Q      �� $��КПП��6   $��0��6#   �� 5R      $��1��6   ��5S      �� *OrganisationKPP+$ PropertyChanged=�5T      �� 5V   
   $��30 10q�6   $��5��5W      $��
Счета��6   .��5X       � -   5          �Name$  mfr_WorkingPanelAdditional��5Y        � NavigationUIVisibility$ Hidden=�5Z      $��Stretch=�5[      $��Stretch=�6.   $��Stretch=�5\      $��Stretch=�65   5^      5_      �� 5b   
    �� Orientation$ 
Horizontal=�6   $��Center=�5c      $��6��5d      $��10q�5e      .+�5g      �� $��5q�5h      $	��100��5i      $��25��5j      ��5g      �� *OkButtonContent+��5k      �� *AddNewOrganisation+�� 5n      $��Закрыть��6   $��5q�5o      $	��100��5p      $��25��5q      ��5r      �� *
CancelPage+5t      5v      5w      