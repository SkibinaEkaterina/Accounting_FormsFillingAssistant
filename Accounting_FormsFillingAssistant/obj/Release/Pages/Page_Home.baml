   M S B A M L   `   `   `  ���� [  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  0    *Accounting_FormsFillingAssistant.Page_Home   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:Accounting_FormsFillingAssistant       N� Title$  	Page_Home�� � 	Resources  �� 
TargetType �� Property �� Value��%^   '��       '�� %     �� " ��.���  � ��$
 10 6q��� " ��.���  � ��$
 10 4q�.��� 
�������.+�� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $'��!Домашняя страница��$��30(�$
��Bold"�$��10 10 10 20q�$��0����  �� Orientation$ 
Horizontal=�$��1��.+��� $)��#Рабочая директория���� ���� *WorkingDirectoryPath+�� $ 
Horizontal=�$��2��.+��� $��Текущая дата���� ���� *CurrentDate+(  "System.Windows.Controls.WebBrowser  -     Name$ UserGuidSection��$��3��$
��Auto��;   5Accounting_FormsFillingAssistant.WebBrowserExtentions   Document �� *
HtmlString+