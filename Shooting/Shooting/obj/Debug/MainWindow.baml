   M S B A M L   `   `   `  ����C  ?Shooting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ShootingShooting  5   	       Shooting.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Shooting     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         textBoxInError �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self	 �� RelativeSource
 �� Path��%�   &	        �� 5
   
   " ��6'    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 60   �� #	 Z $)
 #(Validation.Errors)[0].ErrorContent�5      5      5      .��5      (� .��5   
   �� $��Center=�6   $��Center=�62   $
��Auto��6M   $	��800��6[   $��0,0,0,50q�6g   .+�5      �� -   5         ��Name$ lblTitle��5      $��32(�6&   $��Center=�64   $��0,0,0,0q�6Q   .��6c   
Shooting6m   �� 5      -   5         ��Name$ 
tblWelcome��5      $��Center=�6,   $��20��6I   $
��Auto��6U   0.Welcome to the best shooting game in the world6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      � .+�5      �� -   5        $ txtHint1��5       $��4,12,0,0q�62   $��Enter inner radius��6D   
�������6^   �� 5      -   5         ��Name$ tbxEnterInnerRadius��5      $��Center=�6;   $
��Auto��6X   $	��120��6f   $��0,10,0,0q�6r   
������  � ToolTip$$ Radius must be greater than 10��5      #��[  6G   .��6o   ��5      �� 5      $
 RadiusInner�6&    �� NotifyOnValidationError .  �� NotifyOnSourceUpdated .  �� ValidationRules 5   "   5  /System.Windows.Controls.ExceptionValidationRule  5   &   5       .��5!   (   5"      5#      � 5$      .+�5%      �� -   5        $ txtHint2��5%       $��	14,12,0,0q�62   $��Enter outer radius��6E   
�������6_   �� 5&      -   5        $ tbxEnterOuterRadius��5&      $��Center=�6;   $
��Auto��6X   $	��120��6f   $��	10,10,0,0q�6r   
������ $$ Radius must be greater than 10��5'      #��[  6G   .��6o   ��5(      �� 5)      $
 RadiusOuter�6&    5*   "     5+   &   5-      .��5.   (   5/      50      52      �� 53      -   5         ��Name$ btnPlay��53      $��Center=�6&   $
��Auto��6C   $
��Auto��6Q   $��0,10,0,0q�6^   .��6�   
Let's play6�   54      55      56      