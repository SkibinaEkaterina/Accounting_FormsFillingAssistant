   M S B A M L   `   `   `  ����[  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  5      3    -Accounting_FormsFillingAssistant.SettingsPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:Accounting_FormsFillingAssistant     5        N� Title$  SettingsPage��5	       N� 
Background
 �����.��5      ��  �� Orientation$ Vertical=�6   $��10q�5      .+�5   
   �� $��Настройки��6   $��30(�5      $
��Bold"�6&   $��10 10 10 20q�5      � 5   
    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��3* �6#   .+�5!      �� $
��12 4q�5"      $
��Wrap=�5#      $)��#Рабочая директория��6(   $	��Top=�5$      �� 5&      $��0��6   $��1��6&   $ 
Horizontal=�5'      .+�5(      �� $��0��6   $��1��6'   $��46��5)      $	��350��6&   $
��12 0q�62    �� TextWrapping$
 Wrap=�5*      $
��Left=�6.   ��5+      �� *PathToWorkingDirectory+�� 5.      -   5         ��Name$! mbtn_ChooseWorkingDirectory��5.      $��33��5/      $��23��6$   $	��...��50      $
��Left=�6'   $	��4 4q�51      $	��Top=�6&   ��52      �� *ChooseWorkingDirectory+ �� FallbackValue$ No Data��56      �� 5;      $��1��6   $��0��6%   $
��12 4q�5<      $
��Wrap=�5=      $)��#Путь к Excel файлу (БД)��6!   $	��Top=�5>      �� 5@      $��1��6   $��1��6&   $ 
Horizontal=�5A      .+�5B      �� $
��Left=�6   $��1��5C      $��1��6"   $��46��5D      $	��350��6!   $
��12 4q�6-   $
 Wrap=�5E      $	��Top=�5F       �� 
IsReadOnly . ��5H      �� *PathToDataBase+�� 5J      -   5        $ mbtn_ChooseDBPath��5J      $	��...��5K      $
��Left=�6#   $	��4 4q�5L      $	��Top=�6"   $��33��5M      $��23��6    ��5N      �� *ChooseDBPath+$ No Data��5P      5Q      �� 5T   
   $ 
Horizontal=�6   $��Center=�6.   $��5q�5U      .+�5V      �� -   5        $ mbtn_OkButton��5V      $��Изменить��5W      $
��Left=�6    $
��12 0q�5X      $	��Top=�6   $��93��5Y      $��25��6   ��5Z      �� *	OkClicked+$ No Data���� 5[      -   5        $ CloseButton��5[      	 �� IsCancel	 . $��Закрыть��5\      $
��Left=�6   $
��12 0q�5]      $	��Top=�6   $��87��5^      $��25��6   ��5_      �� *CancelClicked+$ No Data��5a      5f      5g      