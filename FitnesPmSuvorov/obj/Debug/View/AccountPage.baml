   M S B A M L   `   `   `  ����J  FFitnesPmSuvorov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FitnesPmSuvorov.ViewFitnesPmSuvorov.View  5      E'clr-namespace:FitnesPmSuvorov.ViewModelFitnesPmSuvorov.ViewModel  68   &     FitnesPmSuvorov.View.AccountPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:FitnesPmSuvorov.View     5      =	viewmodel'clr-namespace:FitnesPmSuvorov.ViewModel     68     N� Title$  AccountPage��5	      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  ���#ddd2b4   
IsReadOnly .    AutoGenerateColumns .   �� SelectedItem 5      �� *SelectedAccount+��5      �� *
Accounts+ � 	Resources 5      )  #System.Windows.Controls.DataGridRow �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value��%�   '        �� 5      "  6   .�5      ��  � �� �#EBCFB263    5      P� 5      	 �@ 
IsSelected
 . . �5      ��  � �� �#ABA28A6;   5      5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ имя��5         
Foreground
 �   �1  +System.Windows.Controls.DataGridBoundColumn   Binding 5!      �� *name+  5#      $' !электронная почта��5$      
 �   � 5&      �� *email+  5'      $ пароль��5(      
 �   � 5*      �� *
password+  5+      $ 
логин��5,      
 �   � 5.      �� *login+  5/      $ роль��50      
 �   � 52      �� *role+  53      $# последний визит��54      
 �   � 56      �� *
last_visit+  57      $% дата регистрации��58      
 �   � 5:      �� *date_registration+5=      5>      5?      