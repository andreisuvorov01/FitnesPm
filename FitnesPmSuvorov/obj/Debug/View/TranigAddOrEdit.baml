   M S B A M L   `   `   `  ����J  FFitnesPmSuvorov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FitnesPmSuvorov.ViewFitnesPmSuvorov.View  5   	   *    $FitnesPmSuvorov.View.TranigAddOrEdit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:FitnesPmSuvorov.View     5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ TranigAddOrEdit��5
   	   $	��550��6!   $	��400��6.   .��5      � ���#ddd2b4 � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        ���#934515 �� CornerRadius$ 	0,0,20,20��5   '   $��0��6@   ���#934515._�5      �� $7��1Добавление/редактирование��6   $��Center=�69   $��Center=�6V   
�������$��28(�6�   5      �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   .+�5      �� $:��4Введите название тренировки��6   $	��Top=�6;   $��Center=�6S   $��28(�6p   �� 5      -   5         ��Name$
 name��5      ���#ddd2b4���#231f20$��5q�6O   $	��300��6y   $��50��6�   $��Center=�6�   $��0,20,0,0q�6�   ��6c   �� *name+6�   5      �� 5   
   $ Vertical=�6   $��2��6,   .+�5      �� $:��4Введите описание тренировки��6   $	��Top=�6;   $��Center=�6S   $��28(�6p   �� 5      -   5        $��description��5   +   ���#ddd2b4���#231f20$��5q�6T   $	��300��6�   $��50��6�   $��Center=�6�   $��0,20,0,0q�6�   ��6h   �� *description+6�   5      �� 5   
   $ Vertical=�6   $��3��6,   .+�5      �� $B��<Введите длительность тренировки��6   $	��Top=�6?   $��Center=�6W   $��28(�6t   �� 5       -   5        $��duration��5       ���#ddd2b4���#231f20$��5q�6Q   $	��300��6   $��50��6�   $��Center=�6�   $��0,20,0,0q�6�   ��6e   �� *
duration+6�   5!      �� 5"   
   $��4��6   $ 
Horizontal=�6"   .+�5#      �� -   5        $��	BtnCancel��5#   ;      ButtonStyle#��[  6   $��отменить��6L   
�������$
��Left=�6�   $��50��6�   $	��100��6�   $��Center=�6�   $��10,50,10,10q�6�   �� 5$      -   5        $��BtnSend��5$   ;   #��[  6   $#��внести изменеия��6J   
�������$��Right=�6�   $��50��6�   $	��100��6�   $��Center=�6�   $��170,50,10,10q�6�   5%      5&      5'      