   M S B A M L   `   `   `  ����[  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  5   	   1    +Accounting_FormsFillingAssistant.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Accounting_FormsFillingAssistant     5   	   -   5          � Title$+  %Помощник бухгалтера��5   	   $	��700��6%   $
��1000��62    � WindowStartupLocation$ CenterScreen=�5	   	   $	��900��6.   $	��500��6=    � 	Resources 5         MainMenu_style �� Property �� Value �� 	Resources �� 
TargetType  MenuBorder_style  Home_btn_image  Btn_Settings_image��%  &	        &	 �    &	 �    &	 �    �� 5   
   .�5      ��  � ��
 �����63   �� 5       � ��
 �   �63   �� 5       � ��$ 0q�63   �� 5       � ��$	 220��63    5      ���� 5      'm�       " m�6   .�5      ��  � ��$ 1q�6/   �� 5       � ��$ 36��6/   �� 5       � ��$	 220��6:   �� 5       � ��$ Center=�6<   �� 5       � ��$ 3q�68   �� 5       � ��
 �����6<   �� 5       � ��$ 2q�6@   5      5       5!      �� 5$   
   .�5%      ��  � ��
 �����64   �� 5&       � ��
 �����64   �� 5'       � ��$ 0q�68   5)      �� 5,   
   $$��Resources/home_icon_124950.png��6'   �� 5-   
   $#��Resources/Settings_icon_2.png��6+   50      .��53      �  � ColumnDefinitions 54   
   �� 55      $	��220 �6   �� 56      $��* �6   .+�5:   
   �� #��[ 6   ._�5;      �  � RowDefinitions 5<      �� 5=      $��50 �6$   �� 5>      $��* �6$   .+�5B      �� #��[ 6   ._�5D      �� 	 �� Orientation$	 
Horizontal=�6!   $	��1 0q�5E   !   
������� 5H      ��%�   '��       �� 5I      " ��6$   .�5J   "   ��  � ��
 �����6?   �� 5K   "    � ��$ 25��6:   �� 5L   "    � ��$ 25��6;   �� 5M   "    � ��$	 5 2q�6;   �� 5O   "    � ��$ 0q�6D   5Q      5R      .+�5T      �� $�� ��5U   !   #��[ 5V   !   ��5T   !   �� *GoToHomePage+5V   !   �� 5X      $�� ��5Y   !   #��[ 5Z   !   ��5X   !   �� *OpenSettingsWindow+5Z   !   5\      5]      �� 5`      $��1��6   .+�5a      �� #��[ 6   ._�5c      o� #��[  6   ��5e      �� 5f   "   .R�5g   &   �� 5h   #   .@�5j      m� $��Организации��6'   $
��Left=�6<   $	��0,1q�6W   .@�5k   "   m� $��Добавить��6+   
 m� Command
 6=   �� *GoToAddOrganisationsPage+m� 5l   "   $#��Все организации��6+   
 6D   �� *GoToAllOrganisationsPage+5m      m� 5n      $��Создать бланк��6'   .@�5o   "   m� $��Аккредитив��6+   
 5p   +   �� *GoToAccreditivePage_Create+5q   #   m� 5r   "   $-��'Инкассовое поручение��6+   
 5s   +   �� *GoToInkassoPage_Create+5u   #   m� 5v   "   $+��%Платежное поручение��6+   
 5w   +   �� *GoToPaymentOrderPage_Create+5y   #   m� 5z   "   $-��'Платежное требование��6+   
 5{   +   �� *#!GoToPaymentRequirementPage_Create+5}   #   5~      m� 5�      $ ��Дополнительно��6'   .@�5�   "   m� $��
Банки��6+   .@�5�   &   m� $��Добавить��6/   
 5�   0   �� *GoToPageAddEditBank+m� 5�   &   $��Все банки��6/   
 5�   /   �� *GoToPageWithAllBanks+5�   #   m� 5�   "   $��
Счета��6+   .@�5�   &   m� $��Добавить��6/   
 5�   /   �� *GoToThePageAddBankAccount+m� 5�   &   $��Все счета��6/   
 5�   /   �� *GoToPageWithAllBankAccounts+5�   #   5�      5�      5�      5�      5�      5�       � 5�   
   -   5          �Name$ mfr_WorkingPanel��5�       $��1��6     � NavigationUIVisibility$ Hidden=�6;   5�      5�      5�      