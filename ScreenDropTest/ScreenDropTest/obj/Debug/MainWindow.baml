   M S B A M L   `   `   `  ����E  AScreenDrop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE1clr-namespace:ScreenDrop.View;assembly=ScreenDropScreenDrop.View  5   	    ScreenDropTest   ScreenDropTest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Edropper1clr-namespace:ScreenDrop.View;assembly=ScreenDrop     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F     � Title$  
MainWindow��5   	   $	��270��6   $	��425��6)   $��18(�65    � WindowStyle$
 None=�6M    � AllowsTransparency . 
������  � 	Resources 5         commandButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� RelativeSource
 �� Triggers P� Property P� Value �� 
TargetName��%k  &	        �� 5   
   " ��6&   .�5	      ��  � �� 5
      �� 5      " ��6&   .R�5      �� $ stackP��6%   ��65   �� *
Background+	 �� *TemplatedParent+.+�5      �� 5      
 5      P� 5       �@J�IsMouseOver . . �5   "   �� $ stackP��6O    � �� �#E8E8E85      5      5      5      5      .��5      � -   5        
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Right=�6/   $��3q�6K   .+�5       �� $��3q�6:   
������ $��25��6^   $��25��6j   #��[  6u   ��6   �� *MinimizeCommand+.��5!      �� $��Resources/minimize.png��6   $��25��68   $��25��6D   5"      �� 5#      $��3q�69   
������ $��25��6]   $��25��6i   #��[  6t   ��6   �� *MaximizeCommand+.��5$      �� ��6   �� *MaximizeSource+5%      �� 5&      
������ $��3q�6P   $��25��6[   $��25��6f   #��[  6r   ��6   �� *CloseCommand+.��5'      �� $��Resources/close.png��6   5(      5)      �� 5*   
   $:��4You can use shortcut CTRL+D to toggle dropper button��6   $��1��6P   $��16(�6]   $��Center=�6k   $��Center=�6�      ScreenDrop.View.Dropper  5+   
   -   5          Name$ dropper��5+   '   $��2��6   $��10q�68   5,      5.      