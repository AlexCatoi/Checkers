   M S B A M L   `   `   `  ����C  ?Checkers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CheckersCheckers  5   	   7 clr-namespace:Checkers.ViewModelCheckers.ViewModel  5   	       Checkers.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Checkers     5   	   /vm clr-namespace:Checkers.ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � DataContext 5         Checkers.ViewModel.MenuVM  5   
   6   .��5      � $��1��6    � RowDefinitions 5   
   �� 5      $
��2.5* �6   6,   �� 5      $
��2.5* �6   6,   �� 5      $
��2.5* �6   6,   �� 5      $
��2.5* �6   6,   .+�5   
   �� -   5         ��Name$ Title��5      $��Checkers��6   $��50(�62   $��Center=�6@   $��Center=�6[   $��Arial)�6x   5      �� 5   
   -   5         ��Name$ Start��5      $��Start��6    $	��150��60   $��50��6<   $��Center=�6H   $��Center=�6e   $��1��6�   $��27(�6�   ��6�   �� *Start+6�   �� 5   
   -   5        $
 Help��5      $
��Help��6   $	��150��6.   $��50��6:   $��Center=�6F   $��Center=�6c   $��2��6~   $��27(�6�   ��6�   �� *Help+6�   �� 5   
   -   5        $
 Exit��5      $
��Exit��6   $	��150��6.   $��50��6:   $��Center=�6F   $��Center=�6c   $��3��6~   $��27(�6�   ��6�   �� *Exit+6�   �� 5   
   -   5        $ Stats��5      $��30��6    $��30��6+   $��Right=�67   $	��Top=�6S   $��0��6k   $��	0,12,35,0q�6�   ��6x   �� *Stats+.��5      �� $+��%pack://application:,,,/Poze/stats.jpg��6   5      5      5      