   M S B A M L   `   `   `  ����S  OCryptoDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:CryptoDesktopApplication.GeneratorsFront(CryptoDesktopApplication.GeneratorsFront  5      B    <CryptoDesktopApplication.GeneratorsFront.RegisterUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:CryptoDesktopApplication.GeneratorsFront     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $��110.666��5      $	��890��60   .��5	      � -   5          �Name$  MainGrid��5	      
�������.+�5
   
   ��  �� Orientation$ 
Horizontal=�6   $��48,39,118,39q�6.    J� RenderTransformOrigin$ 0.5,0.5&�6D   .+�5      �� -   5         ��Name$ 
lfsrTxtBox��5   �    �� 	MaxLength$ 32��6p    � ToolTip$ Znak 0 lub 1��6�   $��20(�6�   $
��Left=�6�   $��33��6�   $��25��6�   $	��700��6�    �� TextAlignment$ Center=�6�   $��0,0,0,0q�6   �� TextWrapping$
 Wrap=�6"  $	��Top=�66  6N  �� 5      -   5        $��20��5      $��20��6    $��1,0,0,0q�6@   
������ 
������ .��5      '  !MaterialDesignThemes.Wpf.PackIcon  $ Usunięcie tekstu��6*   $	��-16q�6E   ���	#FF224BB6�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ CloseCircle=�6i   $��20��6|   $��20��6�   $��Center=�6�   5      5      �� 5   
   -   5        	 ��Name$	 RegisterNumberLabel��5      $��20(�6-   $��Rejestr��6;   ���	#FF224BB6$
��Left=�6d   $��48,2,0,0q�6   $	��Top=�6�   $
��auto��6�   �� 5   
   -   5        $	 rCounter��5   '   $ Liczba bitów��6   $��20(�69   $��0��6G   ���	#FF224BB6$
��Left=�6j   $��	10,39,0,0q�6�   $	��Top=�6�   $��38��6�   $��33��6�   ��5      �� 5      
 �� 
TargetType"
 ��6   .�5      ��  �� Property � �� �� Value
 ���� 63    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      ��  � ��
 �����6;   5      5      5      �� 5   
   -   5        $	 rState��5   D   $ Aktualny stan rejestru��6   $��01101010��61   $��20(�6T   ���	#FF224BB6$
��Left=�6z   $��	48,77,0,0q�6�   $	��Top=�6�   $	��699��6�   $��33��6�   ��5      �� 5      "
 ��6   .�5       ��  � ��
 ���� 63    5!      P� 5"       �@J�IsMouseOver . . �5#      ��  � ��
 �����6;   5$      5&      5(      �� 5)   
   -   5         ��Name$ setRegister��5)      $��20(�6   $
��Left=�65   $��
777,38,0,0q�6P   $	��Top=�6d   $	��106��6|   $��67��6�   .��5*      �� $
��Wrap=�6   $��Ustaw rejestr��6,   6C   5+      �� 5,   
   -   5        $	 rCurrentCounter��5,   ;   $' !Aktulna liczba bitów w rejestrze��6   $��20(�6T   $��8��6b   ���	#FF224BB6$
��Left=�6�   $��	10,77,0,0q�6�   $	��Top=�6�   $��38��6�   $��33��6�   ��5-      �� 5.      "
 ��6   .�5/      ��  � ��
 ���� 63    50      P� 51       �@J�IsMouseOver . . �52      ��  � ��
 �����6;   53      55      57      59      5:      