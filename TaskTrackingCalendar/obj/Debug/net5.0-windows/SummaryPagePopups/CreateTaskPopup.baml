   M S B A M L   `   `   `  ����O  KTaskTrackingCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TaskTrackingCalendarTaskTrackingCalendar  5   	   *    $TaskTrackingCalendar.CreateTaskPopup   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:TaskTrackingCalendar     5   	     � Title$  CreateTaskPopup��5   	   $	��350��6!   $	��300��6.    � WindowStartupLocation$ CenterOwner=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6I   .+�5      �� $��Class for task: ��6   �� 5      -   5        $��ClassComboBox��5      5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��Center=�6I   $��1��6f   .+�5      �� $��Task name: ��6   �� 5      -   5        $��TaskNameTextBox��5   .   $	��100��6   $��20��6"   6.   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��Center=�6I   $��2��6f   .+�5      �� $��Task priority: ��6   �� 5      -   5        $��PriorityComboBox��5      .@�5      �� $��1��6    �� 
IsSelected$
 True��6+   �� 5      $��2��6   �� 5      $��3��6   �� 5       $��4��6   �� 5!      $��5��6   5"      5#      �� 5$   
   $ 
Horizontal=�6   $��Center=�6.   $��Center=�6I   $��3��6f   .+�5%      �� $��	Due date:��6    �� Padding$ 5q�6)   (  "System.Windows.Controls.DatePicker  5&      -   5        $��
DatePicker��5&      5'      �� 5(   
   $ 
Horizontal=�6   $��Right=�6.   $��Center=�6J   $��4��6e   $��10q�6r   .+�5)      �� -   5        $��ErrorTextBox��5)      $ 5q�6,   �� 5*      -   5        $��75��5*      $��30��6    .��5+      �� $��Submit��6   5,      5-      5.      5/      