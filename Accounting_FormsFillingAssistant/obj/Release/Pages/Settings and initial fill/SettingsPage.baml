   M S B A M L   `   `   `  ���� [  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  3    -Accounting_FormsFillingAssistant.SettingsPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:Accounting_FormsFillingAssistant       N� Title$  SettingsPage�� N� 
Background
 �����.����  �� Orientation$ Vertical=�$��10q�.+��� $��Настройки��$��30(�$
��Bold"�$��10 10 10 20q��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $��* ��� $��3* �.+��� $
��12 4q�$
��Wrap=�$)��#Рабочая директория��$	��Top=��� $��0��$��1��$ 
Horizontal=�.+��� $��0��$��1��$��46��$	��350��$
��12 0q� �� TextWrapping$
 Wrap=�$
��Left=����� *PathToWorkingDirectory+�� -    ��Name$! mbtn_ChooseWorkingDirectory��$��33��$��23��$	��...��$
��Left=�$	��4 4q�$	��Top=����� *ChooseWorkingDirectory+ �� FallbackValue$ No Data���� $��1��$��0��$
��12 4q�$
��Wrap=�$)��#Путь к Excel файлу (БД)��$	��Top=��� $��1��$��1��$ 
Horizontal=�.+��� $
��Left=�$��1��$��1��$��46��$	��350��$
��12 4q�$
 Wrap=�$	��Top=� �� 
IsReadOnly . ���� *PathToDataBase+�� -   $ mbtn_ChooseDBPath��$	��...��$
��Left=�$	��4 4q�$	��Top=�$��33��$��23������ *ChooseDBPath+$ No Data���� $ 
Horizontal=�$��Center=�$��5q�.+��� -   $ mbtn_OkButton��$��Изменить��$
��Left=�$
��12 0q�$	��Top=�$��93��$��25������ *	OkClicked+$ No Data���� -   $ CloseButton��	 �� IsCancel	 . $��Закрыть��$
��Left=�$
��12 0q�$	��Top=�$��87��$��25������ *CancelClicked+$ No Data��