   M S B A M L   `   `   `  ���� [  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  6    0Accounting_FormsFillingAssistant.View_Accreditiv   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:Accounting_FormsFillingAssistant       N� Title$  View_Accreditiv�� � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker   
GridStyle1 � ColumnDefinitions � RowDefinitions��%E  '��       '�� %     '�� J     '  o     &	  �     �� " ��.���  � ��$
 10 6q��� " ��.���  � ��$
 10 4q��� " ��.���  � ��$
 10 4q��� "  .���  � ��$
 10 4q��� " ��.���  � �� �� .R��  �� $	��120 ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto �.��� 
�������.+���  �� Orientation$ Vertical=�$��10q�.+��� $��Аккредитив��$��30(�$
��Bold"�$��10 10 10 20q��� $ 
Horizontal=�.+��� $��
Номер���� $��50������ *TemplateNumber+�� $
��от��  $	��150��   SelectedDate �� *TemplateDate+�  �� $��* ��� $��* �.+��� $��0��#��[  .@��� $��0��$��0��$��Плательщик���� $��0��$��1��$%��Счёт плательщика���� $��0��$��2��$��ИНН���� $��1��$��0��	 �� DisplayMemberPath$	 Org_Name��
 �� SelectedItem
 �� *OrganisationPayer+���� *CollectonOfAllOrganisations+�� $��1��$��1��$	 BankAc_Number��
 �� *OrganisationPayer_BankAccount+���� *-+CollectonOfBankAccountsForPayerOrganisation+�� $��1��$��2������ *OrganisationPayer_INN+�� $��1��#��[  .@��� $��0��$��0��$��Получатель���� $��0��$��1��$#��Счёт получателя���� $��0��$��2��$��ИНН���� $��1��$��0��$	 Org_Name��
 �� *MainOrganisation+���� *CollectonOfAllOrganisations+�� $��1��$��1��$	 BankAc_Number��
 �� *MainOrganisation_BankAccount+���� *,*CollectonOfBankAccountsForMainOrganisation+�� $��1��$��2������ *MainOrganisation_INN+�  �� $��* ��� $��* �.+��� $��0��#��[  .@��� $��0��$��0��$��Сумма платежа���� $��1��$��0������ *
PaymentSum+�� $��1��#��[  .@��� $��0��$��0��$��Вид платежа���� $��1��$��0��
 �� *PaymentType+���� *CollectonOfPaymentTypes+�� #��[  .@��� $��0��$��0��$#��Вид аккредитива��$
��Wrap=��� $��1��$��0������ *AkkreditiveType+�� #��[  .@��� $��0��$��0��$!��Условие оплаты��$
��Wrap=��� $��1��$��0��$��48�� �� TextWrapping$
 Wrap=����� *PaymentTerm+�� #��[  .@��� $��0��$��0��$����Подробности сделки (наименование товаров/работ/услуг, № и дата договора и т.д.)��$
��Wrap=��� $��1��$��0��$��98��$
 Wrap=����� *ConditionsDetails+�� #��[  .@��� $��0��$��0��$N��HПлатеж по представлению (вид документа)��$
��Wrap=��� $��1��$��0��$��48��$
 Wrap=����� *SubmissionPayment+�� #��[  .@��� $��0��$��0��$1��+Дополнительные условия��$
��Wrap=��� $��1��$��0��$��48��$
 Wrap=����� *AdditionalDetails+�  �� $��* ��� $��* �.+��� $��0��#��[  .@��� $��0��$��1��$6��0Срок действия аккредитива��$
��Wrap=�  $��1��$��1��$	��150��$��23��$
��Left=�$	��Top=� �� *AkkreditiveEOLDate+�� $ 
Horizontal=�$��Center=�$��6��$��10q�.+��� $��Сохранить��$��5q�$	��100��$��25������ *	SaveBlank+ � ToolTip _� $J��DСохранить бланк в рабочую директорию���� $��Закрыть��$��5q�$	��100��$��25������ *
CancelPage+ _� $%��Закрыть страницу��