   M S B A M L   `   `   `  ����[  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  5      0    *Accounting_FormsFillingAssistant.Page_Home   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:Accounting_FormsFillingAssistant     5        N� Title$  	Page_Home��5	       � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       '�� J     �� 5   
   " ��6   .�5      ��  � ��$
 10 6q�6/   5      �� 5   
   " ��6   .�5      ��  � ��$
 10 4q�6/   5      5      .��5      � 
�������.+�5   
   � $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $'��!Домашняя страница��6   $��30(�5      $
��Bold"�6&   $��10 10 10 20q�5       $��0��5!      �� 5$       �� Orientation$ 
Horizontal=�6   $��1��5%      .+�5&      �� $)��#Рабочая директория��6   �� 5'      ��6   �� *WorkingDirectoryPath+5(      �� 5*      $ 
Horizontal=�6   $��2��5+      .+�5,      �� $��Текущая дата��6   �� 5-      ��6   �� *CurrentDate+5.      (  "System.Windows.Controls.WebBrowser  50      -   5          Name$ UserGuidSection��51      $��3��50      $
��Auto��51   *   ;   5Accounting_FormsFillingAssistant.WebBrowserExtentions   Document 68   �� *
HtmlString+52      53      54      