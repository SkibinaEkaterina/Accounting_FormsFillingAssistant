   M S B A M L   `   `   `  ���� [  WAccounting_FormsFillingAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Accounting_FormsFillingAssistant Accounting_FormsFillingAssistant  9    3Accounting_FormsFillingAssistant.InitialFillingPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:Accounting_FormsFillingAssistant       N� Title$  View_InitialFillingPage�� N� 
Background
 �����.���� 
�������$��10q�.+��� $��Начало работы��$��30(�$
��Bold"�$��10 10 10 20q��� $
��Left=�$
��12 4q�$
��Wrap=�$	��Top=�$����Добро пожаловать в программу помощник бухгалтера! Перед началом работы с программой необходимо осуществить несколько шагов.��$��38��$	��493���� $
��Left=�$
��12 4q�$
��Wrap=�$	��Top=�$?��9Шаг 1. Выбор рабочей директории.���� $
��Left=�$
��12 4q�$
��Wrap=�$����Рабочая директория программы - директория на компьютере пользователя, в которой будут храниться все создаваемые в программе бланки. Не рекомендуется указывать в качестве рабочей директории служебные директории, директории с ограниченным или закрытым доступом, директории с уже содержащимися данными.��$	��Top=�$��70��$	��489���� $
��Left=�$
��12 4q�$
��Wrap=�$)��#Рабочая директория��$	��Top=���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ mtbox_WorkingDirectory��$
��Left=�$��23��$
��12 4q� �� TextWrapping$
 Wrap=�$	��Top=�$	��347������ *PathToWorkingDirectory+�� -    ��Name$! mbtn_ChooseWorkingDirectory��$	��...��$
��Left=�$
��12 4q�$	��Top=�$��33��$��23������ *ChooseWorkingDirectory+ �� FallbackValue$ No Data���� $
��Left=�$
��12 4q�$
��Wrap=�$	��Top=�$J��DШаг 2. Создание базы данных программы.���� $
��Left=�$
��12 4q�$
��Wrap=�$����Для хранения данных, необходимых для заполнения бланков (организации, их счетах и  банки), требуется создать Excel-файл. Он будет служить в качестве базы данных. Чтобы создать базу, нажмите кнопку 'Создать'. Файл будет сохранен в рабочей директории.��$	��Top=�$��53��$	��489���� $ 
Horizontal=�.+��� -    ��Name$ mtb_DbStatus��$
��Left=�$
��12 4q�$
��Wrap=�$	��Top=�$��20��$	��304������ *DatabaseStatus+�� $��Создать��$
��Left=�$
��12 4q�$	��Top=�$��75������ *CreateDataBase+�� $
��Left=�$
��12 4q�$
��Wrap=�$	��Top=�$����Далее, прежде чем приступить к заполнению бланков, Вам необходимо добавить Банки, в которых ваши организации имеют счета, и сами Организации со счтеами. О порядке добавления объектов в базу ознакомьтесь с инструкцией.���� $��Продолжить��$��Center=�$��5q�$��80������ *GoToHomePage+