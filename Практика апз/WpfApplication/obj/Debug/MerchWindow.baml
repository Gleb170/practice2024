   M S B A M L   `   `   `  ����I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfApplicationWpfApplication  5   	        WpfApplication.MerchWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .localclr-namespace:WpfApplication     5   	   -   5          � Title$  Товары��5   	   $��368.95��6   $	��599��6(    � 	Resources 5      #   WpfApplication.defaultDataSet   defaultDataSet  товарViewSource �� Source �� Source��%[   &	        &	      7     5   
   6   �� 5   
    67   �� *
Товар+8   5	      .��5
      �  � DataContext# [ 6   $��0,0,0,3q�6:   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ товарDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��0,0,0,60q�6}      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   $��14(�6�   ��6e   �� 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        товарНомерColumn��,  &System.Windows.Controls.DataGridColumn
   Header$
 
Номер��5   ^      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *ТоварНомер+6m     5      -   5        товарColumn��$
 
Товар��5   T   $	 200 6d    6:   �� *
Товар+6d     5      -   5        ценаColumn��$
 Цена��5   S   $	 300 6a    69   �� *
Цена+6a   5      �� 5   
   -   5        $��Обновить��5      $
��Left=�6$   $��
12,295,0,0q�6?   $	��Top=�6S   $��84��6k   $��31��6v   $��14(�6�   6�   �� 5   
   -   5        $��Сохранить��5      $
��Left=�6%   $��101,295,0,0q�6@   $	��Top=�6U   $��84��6m   $��31��6x   $��14(�6�   6�   �� 5   
   -   5        $��Удалить��5      $
��Left=�6#   $��190,295,0,0q�6>   $	��Top=�6S   $��84��6k   $��31��6v   $��14(�6�   6�   5      5      