   M S B A M L   `   `   `  ����X  TWPF_Account_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:WPF_Account_Management_System.View"WPF_Account_Management_System.View  5   	   7    1WPF_Account_Management_System.View.WindowEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:WPF_Account_Management_System.View     5   	     � Title$  WindowEmployee��5   	   $	��550��6    $	��300��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�6.    � 	Resources 5
         	textBlock �� 
TargetType �� Property �� Value  
fieldsText  btn��%!  &	        &	 K     &	 �     �� 5   
   " ��6"   .�5      ��  � ��$ 10,10q�6'   5      �� 5   
   " ��6#   .�5      ��  � ��$ 10,10q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 30��6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   �� 5$      $
��Auto �6   �� 5%      $
��Auto �6   �� 5&      .+�5)   
   �� $��Enter FirstName��6   #��[  6+   �� 5*   
   $��1��6   $��Center=�6    �� 	MaxLength$ 20��6:   #��[ 5+      ��5,      �� *	FirstName+�� 5.   
   $��2��6   $��Enter LastName��6!   #��[  67   �� 5/   
   $��3��6   $��Center=�6   $ 20��6;   #��[ 50      ��51      �� *
LastName+�� 53   
   $��4��6   $��Enter Patronymic��6!   #��[  69   �� 54   
   $��5��6   $��Center=�6   $ 20��6:   #��[ 55      ��56      �� *
Patronymic+�� 58   
   $��6��6   $��Choose Birthday��6!   #��[  68   (  "System.Windows.Controls.DatePicker  59   
   $��7��6   $��10,10q�6"   	   SelectedDate	 5:      �� *DateBirthday+�� 5<   
   $��8��6   $��Enter about information��6!   #��[  6@   �� 5=   
   $��9��6   $��Center=�6   $	 200��6:   #��[ 5>      ��5?      �� *About+�� 5A   
   $��10��6   $��Choose department��6"   #��[  6;   �� 5B   
   $��11��6   $��Center=�6!   $��10,10q�6<   ��5C      �� *Departments+
 �� SelectedItem
 5D      �� *
Department+� 5F   
   $��13��6    � ColumnDefinitions 5G      �� 5H      �� 5I      .+�5L      �� $��OK��6   #��[ 6"   $��Center=�6?   ��5M      �� *OKWinCreateNewEmployee+�� 5N      $��1��6   $��Cancel��6%   #��[ 66   ��5O      �� *CloseWinCreateNewEmployee+5P      5Q      5R      