   M S B A M L   `   `   `  ����I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfApplicationWpfApplication  5   	       WpfApplication.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .localclr-namespace:WpfApplication     5   	   -   5          � Title$  Пользователи��5   	   $��366.85��6   $��694.625��6.    � 	Resources 5      #   WpfApplication.defaultDataSet   defaultDataSet & "пользовательViewSource �� Source �� Source��%i   &	        &	      7     5   
   6   �� 5   
    6>   �� *Пользователь+8   5	      .��5
      �  � DataContext# [ 6    � ColumnDefinitions 5   
   �� 5      $
��327* �6   �� 5      $
��322* �6   �� 5      $
��144* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$&  пользовательDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��0,0,0,57q�6�   	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�6�   $��3��6�   ��6l   �� 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        ,(пользовательНомерColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��5   l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *$"ПользовательНомер+6l     5      -   5        фИОColumn��$ ФИО��5   P      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6]    68   �� *ФИО+6]     5      -   5        телефонColumn��$ Телефон��5   X   $	 100 6i    6<   �� *Телефон+6i     5      -   5        почтаColumn��$ 
Почта��5   T   $	 100 6c    6:   �� *
Почта+6c     5      -   5        логинColumn��$ 
Логин��5   T   $	 100 6c    6:   �� *
Логин+6c     5      -   5        парольColumn��$ Пароль��5   V   $	 100 6f    6;   �� *Пароль+6f     5      -	   5        праваColumn��$ 
Права��5   T   $	 100 6c    6:   �� *
Права+6c   5      �� 5   
   -
   5        $��Обновить��5      $
��Left=�6$   $��	8,296,0,0q�6?   $	��Top=�6R   $��84��6j   $��31��6u   $��14(�6�   6�   �� 5    
   -   5        $��Сохранить��5       $
��Left=�6%   $��
97,296,0,0q�6@   $	��Top=�6T   $��84��6l   $��31��6w   $��14(�6�   6�   �� 5!   
   -   5        $��Удалить��5!      $
��Left=�6#   $��186,296,0,0q�6>   $	��Top=�6S   $��84��6k   $��31��6v   $��14(�6�   6�   5#      5$      