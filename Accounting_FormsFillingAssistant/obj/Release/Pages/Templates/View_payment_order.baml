   M S B A M L   `   `   `  ���� [  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  9    3Accounting_FormsFillingAssistant.View_payment_order   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:Accounting_FormsFillingAssistant       N� Title$  View_payment_order�� � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker   
GridStyle1 � ColumnDefinitions � RowDefinitions��%U  '��       '�� %     '�� J     '  o     &	  �     �� " ��.���  � ��$
 10 6q��� " ��.���  � ��$
 10 4q��� " ��.���  � ��$
 10 4q��� "  .���  � ��$
 10 4q��� " ��.���  � �� �� .R��  �� $	��120 ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.��� 
�������.+���  �� Orientation$ Vertical=�$��10q�.+��� $+��%Платежное поручение��$��30(�$
��Bold"�$��10 10 10 20q��� $ 
Horizontal=�.+��� $��
Номер���� $��50������ *TemplateNumber+�� $
��от��  $	��150��   SelectedDate �� *TemplateDate+�  �� $��* ��� $��* �.+��� $��0��#��[  .@��� $��0��$��0��$��Плательщик���� $��0��$��1��$%��Счёт плательщика���� $��0��$��2��$��ИНН���� $��1��$��0��	 �� DisplayMemberPath$	 Org_Name��
 �� SelectedItem
 �� *OrganisationPayer+���� *CollectonOfAllOrganisations+�� $��1��$��1��$	 BankAc_Number��
 �� *OrganisationPayer_BankAccount+���� *-+CollectonOfBankAccountsForPayerOrganisation+�� $��1��$��2������ *OrganisationPayer_INN+�� $��0��$��3��$)��#Статус плательщика��$��10,6.2,-15,5.8q��� $��1��$��3������ *PayerStatus+�� $��1��#��[  .@��� $��0��$��0��$��Получатель���� $��0��$��1��$#��Счёт получателя���� $��0��$��2��$��ИНН���� $��1��$��0��$	 Org_Name��
 �� *MainOrganisation+���� *CollectonOfAllOrganisations+�� $��1��$��1��$	 BankAc_Number��
 �� *MainOrganisation_BankAccount+���� *,*CollectonOfBankAccountsForMainOrganisation+�� $��1��$��2������ *MainOrganisation_INN+�  �� $��* ��� $��* �.+��� $��0��#��[  .@��� $��0��$��0��$��Сумма платежа���� $��1��$��0������ *
PaymentSum+�� $��0��$��1��$#��Очередь платежа���� $��1��$��1������ *
Priority+�� $��1��#��[  .@��� $��0��$��0��$��Вид платежа���� $��1��$��0��
 �� *PaymentType+���� *CollectonOfPaymentTypes+�� #��[  .@��� $��0��$��0��$)��#Назначение платежа��$
��Wrap=��� $��1��$��0��$��60�� �� TextWrapping$
 Wrap=����� *PaymentAppointment+�  �� $��* ��� $��* �.+��� $��0��#��[  .@��� $��0��$��1��$��Код УИН���� $��1��$��1������ *
Code_UIN+�� $��5��.���� .+��� $����Дополнительные поля (необходлимо заполнить, только если платеж предназначается для налоговой или таможни)���  �� $��* ��� $��* �.+��� $��0��#��[  .@��� $��0��$��0��$��Код КБК���� $��1��$��0������ *
Code_KBK+�� $��0��$��1��$��Код ОКТМО���� $��1��$��1������ *
Code_oktmo+�� $��0��$��2��$"��Основание плат.���� $��1��$��2������ *BasisOfPayment+�� $��0��$��3��$5��/Показатель налог. периода��$
��Wrap=��� $��1��$��3������ *TaxPeriodIndicator+�� $��1��#��[  .@��� $��0��$��0��$-��'Номер основания плат.��$
��Wrap=��� $��1��$��0������ *PaymentBasisNumber+�� $��0��$��1��$>��8Дата документа-основания плат.��$
��Wrap=��� $��1��$��1������ *PaymentBasisDate+�� $��0��$��2��$��Тип платежа���� $��1��$��2������ *
PayType2+�� $ 
Horizontal=�$��Center=�$��6��$��10q�.+��� $��Сохранить��$��5q�$	��100��$��25������ *	SaveBlank+ � ToolTip _� $J��DСохранить бланк в рабочую директорию���� $��Закрыть��$��5q�$	��100��$��25������ *
CancelPage+ _� $%��Закрыть страницу��