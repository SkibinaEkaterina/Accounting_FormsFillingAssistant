   M S B A M L   `   `   `  ���� [  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  <    6Accounting_FormsFillingAssistant.Add_organisation_Page   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:Accounting_FormsFillingAssistant       N� Title$  Add_organisation_Page�� � 	Resources ��%    .��� 
�������$��5q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $
��15 5q�$��0��$��50��$��30(�$
��Bold"����� *
HeaderText+� $��1��$��50 10q� � ColumnDefinitions �� $��* ��� $��2* �.+��� $-��'Название организации��$��0���� $��1������ *OrganisationName+� $��2��$��50 10q� �� $��* ��� $��2* �.+��� $��
Адрес��$��0���� $��1������ *OrganisationAddress+� $��3��$��50 10q� �� $��* ��� $��2* �.+��� $��ИНН��$��0���� $��1������ *OrganisationINN+ �� UpdateSourceTrigger$ PropertyChanged=�� $��4��$��50 10q� �� $��* ��� $��2* �.+��� $��КПП��$��0���� $��1������ *OrganisationKPP+$ PropertyChanged=��� $��30 10q�$��5��$��
Счета��.�� � -     �Name$  mfr_WorkingPanelAdditional��  � NavigationUIVisibility$ Hidden=�$��Stretch=�$��Stretch=�$��Stretch=�$��Stretch=���  �� Orientation$ 
Horizontal=�$��Center=�$��6��$��10q�.+��� $��5q�$	��100��$��25������ *OkButtonContent+���� *AddNewOrganisation+�� $��Закрыть��$��5q�$	��100��$��25������ *
CancelPage+