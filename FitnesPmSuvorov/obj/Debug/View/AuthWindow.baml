   M S B A M L   `   `   `  ����J  FFitnesPmSuvorov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FitnesPmSuvorov.ViewFitnesPmSuvorov.View  5   	   %    FitnesPmSuvorov.View.AuthWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:FitnesPmSuvorov.View     5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterOwner=�5
   	    � Title$% окно авторизации��5   	   $	��450��6"   $	��400��6/   .��5      � ���#ddd2b4 � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      �� 5      �� 5      .+�5   
   �� -   5        ���#934515 �� CornerRadius$ 	0,0,20,20��5   '   ���#934515._�5      �� $��Вход��6   $��Center=�6$   $��Center=�6A   
�������$��28(�6o   5      �� 5   
   $��1��6   .+�5      �� $��Логин:��6   $��50��6&   $��Center=�62   $��32(�6O   ���#231f206]   �� 5         TextBoxBaseControlTemplate#��[  6   $��50��6d   $��10q�6p   $��10,15,10,10q�6}   
����������#60331a��6M   �� *Login+6�   5      �� 5   
   $��2��6   .+�5      �� $��Пароль:��6   $��50��6'   $��Center=�63   $��32(�6P   ���#231f206^   G� 5      -   5        $��Password��5        PasswordBoxControlTemplate#��[ 6*   $��10,15,10,10q�6a   
�������$��50��6�   $��10q�6�   ���#60331a6�   5      �� 5   
   $��3��6    �� Orientation$ 
Horizontal=�6"   .+�5       �� -   5        $��	BtnCancel��5    ;     ButtonStyle#��[ 6   $��отменить��6L   
�������$
��Left=�6�   $��50��6�   $	��100��6�   $��Center=�6�   $��10,50,10,10q�6�   �� 5!      -   5        $��BtnVhod��5!   ;   #��[ 6   
�������$��Right=�6�   $��50��6�   $	��100��6�   $��Center=�6�   $��170,50,10,10q�6�   ��6J   �� *	BtnVhod+6�   5#      5$      5%      