   M S B A M L   `   `   `  ���� [  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  9    3Accounting_FormsFillingAssistant.Add_Edit_Bank_Page   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:Accounting_FormsFillingAssistant       N� Title$  Add_Edit_Bank_Page��.��� 
������� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $
��15 5q�$��0��$��50��$��30(�$
��Bold"����� *
HeaderText+� $��1��$��50 10q� � ColumnDefinitions �� $��* ��� $��2* �.+��� $!��Название банка��$��0���� $��1������ *
BankName+� $��2��$��50 10q� �� $��* ��� $��2* �.+��� $��
Город��$��0���� $��1������ *BankAddress+� $��3��$��50 10q� �� $��* ��� $��2* �.+��� $&�� Номер счета Банка��$��0���� $��1������ *BankAccount+ �� UpdateSourceTrigger$ PropertyChanged=�� $��4��$��50 10q� �� $��* ��� $��2* �.+��� $��БИК��$��0���� $��1������ *	BankBIK+��  �� Orientation$ 
Horizontal=�$��Center=�$��5��$��10q�.+��� $��5q�$	��100��$��25������ *OkButtonContent+���� *
AddNewBank+�� $��Закрыть��$��5q�$	��100��$��25������ *
CancelPage+