   M S B A M L   `   `   `  ���� [  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  1    +Accounting_FormsFillingAssistant.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @local.clr-namespace:Accounting_FormsFillingAssistant     -     � Title$+  %Помощник бухгалтера��$	��700��$
��1000�� � WindowStartupLocation$ CenterScreen=�$	��900��$	��500�� � 	Resources    MainMenu_style �� Property �� Value �� 	Resources �� 
TargetType  MenuBorder_style  Home_btn_image  Btn_Settings_image��%�  &	        &	 "    &	 o    &	 �    �� .���  � ��
 �������  � ��
 �   ���  � ��$ 0q���  � ��$	 220�� ���� 'm�       " m�.���  � ��$ 1q���  � ��$ 36����  � ��$	 220����  � ��$ Center=���  � ��$ 3q���  � ��
 �������  � ��$ 2q��� .���  � ��
 �������  � ��
 �������  � ��$ 0q��� $$��Resources/home_icon_124950.png���� $#��Resources/Settings_icon_2.png��.���  � ColumnDefinitions �� $	��220 ��� $��* �.+��� #��[ ._��  � RowDefinitions �� $��50 ��� $��* �.+��� #��[ ._��� 	 �� Orientation$	 
Horizontal=�$	��1 0q�
������� ��%�   '��       �� " ��.���  � ��
 �������  � ��$ 25����  � ��$ 25����  � ��$	 5 2q���  � ��$ 0q�.+��� $�� ��#��[ ���� *GoToHomePage+�� $�� ��#��[ ���� *OpenSettingsWindow+�� $��1��.+��� #��[ ._�o� #��[  ���� .R��� .@�m� $��Организации��$
��Left=�$	��0,1q�.@�m� $��Добавить��
 m� Command
 �� *GoToAddOrganisationsPage+m� $#��Все организации��
 �� *GoToAllOrganisationsPage+m� $��Создать бланк��.@�m� $��Аккредитив��
 �� *GoToAccreditivePage_Create+m� $-��'Инкассовое поручение��
 �� *GoToInkassoPage_Create+m� $+��%Платежное поручение��
 �� *GoToPaymentOrderPage_Create+m� $-��'Платежное требование��
 �� *#!GoToPaymentRequirementPage_Create+m� $ ��Дополнительно��.@�m� $��
Банки��.@�m� $��Добавить��
 �� *GoToPageAddEditBank+m� $��Все банки��
 �� *GoToPageWithAllBanks+m� $��
Счета��.@�m� $��Добавить��
 �� *GoToThePageAddBankAccount+m� $��Все счета��
 �� *GoToPageWithAllBankAccounts+ � -     �Name$ mfr_WorkingPanel��$��1��  � NavigationUIVisibility$ Hidden=�