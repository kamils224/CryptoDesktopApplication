   M S B A M L   `   `   `  ����S  OCryptoDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:CryptoDesktopApplication.GeneratorsFront.Shrinking2CryptoDesktopApplication.GeneratorsFront.Shrinking  5      a5clr-namespace:CryptoDesktopApplication.LoadingControl'CryptoDesktopApplication.LoadingControl  5      J    DCryptoDesktopApplication.GeneratorsFront.Shrinking.ShrinkingSettings   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Rlocal@clr-namespace:CryptoDesktopApplication.GeneratorsFront.Shrinking     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Ccontrol5clr-namespace:CryptoDesktopApplication.LoadingControl  5      $	��645��5
      $
��1280��6   
�������.��5      � -   5          �Name$  Settings��5      .+�5   
   �� $
��Bold"�6   $��35(�6"   ���	#FF224BB6$��Center=�6G   $(��"Generator obcinający - działanie��6l   $��
0,10,0,572q�6�   �� 5   
   $��20(�6   $,��&Ustaw wartości początkowe rejestrów��6   ���	#FF224BB6$
��Left=�6c   $��	30,59,0,0q�6~   $	��Top=�6�   $
��auto��6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��68,137,468,475q�6.    J� RenderTransformOrigin$ 0.5,0.5&�6F   .+�5      �� -   5         ��Name$ lfsr1��5   �    �� 	MaxLength$ 32��6p    � ToolTip$ Znak 0 lub 1��6�   $��20(�6�   $
��Left=�6�   $��33��6�   $��25��6�   $	��700��6�    �� TextAlignment$ Center=�6�   $��0,0,0,0q�6   �� TextWrapping$
 Wrap=�6  $	��Top=�61  6I  �� 5      -   5        $��20��5      $��20��6    $��1,0,0,0q�6A   
������ 
������ .��5      '  !MaterialDesignThemes.Wpf.PackIcon  $ Usunięcie tekstu��6*   $	��-16q�6E   ���	#FF224BB6�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ CloseCircle=�6i   $��20��6|   $��20��6�   $��Center=�6�   5      5      �� 5   
   $��20(�6   $��	Rejestr 1��6   ���	#FF224BB6$
��Left=�6I   $��
68,100,0,0q�6d   $	��Top=�6x   $
��auto��6�   �� 5   
   $ 
Horizontal=�6   $��68,238,468,374q�6.   $ 0.5,0.5&�6F   .+�5      �� -   5        $ lfsr2��5      $ 32��6p   $ Znak 0 lub 1��6�   $��20(�6�   $
��Left=�6�   $��33��6�   $��25��6�   $	��700��6�   $ Center=�6�   $��0,0,0,0q�6  $
 Wrap=�6  $	��Top=�60  6H  �� 5      -   5        $��20��5      $��20��6    $��1,0,0,0q�6A   
������ 
������ .��5        $ Usunięcie tekstu��6*   $	��-16q�6E   ���	#FF224BB6$ CloseCircle=�6i   $��20��6|   $��20��6�   $��Center=�6�   5      5      �� 5   
   $��20(�6   $��	Rejestr 2��6   ���	#FF224BB6$
��Left=�6I   $��
68,201,0,0q�6d   $	��Top=�6x   $
��auto��6�   �� 5   
   -   5        	 ��Name$	 seriesLengthLabel��5      $��20(�6+   $"��Długość ciągu (w bitach)��69   ���	#FF224BB6$
��Left=�6s   $��
27,376,0,0q�6�   $	��Top=�6�   $
��auto��6�   �� 5   
   $ 
Horizontal=�6   $��305,379,798,232q�6.   $ 0.5,0.5&�6G   .+�5      �� -   5        $ outputLength��5   s   $ 8��6:   $) #Liczba z zakresu od 0 do 99 999 999��6�   $��20(�6�   $
��Left=�6�   $��33��6�   $��25��6�   $	��151��6�   $ Center=�6  $��0,0,0,0q�6  $
 Wrap=�6.  $	��Top=�6B  �� 5      -   5        $��20��5      $��20��6    $��1,0,0,0q�6H   
������ 
������ .��5         $ Usunięcie tekstu��6*   $	��-16q�6E   ���	#FF224BB6$ CloseCircle=�6i   $��20��6|   $��20��6�   $��Center=�6�   5!      5"      �� 5#   
   -	   5        $	 	r1Counter��5#   '   $ Liczba bitów��6   $��20(�6:   $��0��6H   ���	#FF224BB6$
��Left=�6k   $��
30,136,0,0q�6�   $	��Top=�6�   $��38��6�   $��33��6�   ��5$      �� 5%      
 �� 
TargetType"
 ��6   .�5&      ��  �� Property � �� �� Value
 ���� 63    �� Triggers 5'      P� 5(       P� Property �@J�IsMouseOver P� Value . . �5)      ��  � ��
 �����6;   5*      5,      5.      �� 5/   
   -
   5        $	 	r2Counter��5/   '   $ Liczba bitów��6   $��20(�6:   $��0��6H   ���	#FF224BB6$
��Left=�6k   $��
30,237,0,0q�6�   $	��Top=�6�   $��38��6�   $��32��6�   ��50      �� 51      "
 ��6   .�52      ��  � ��
 ���� 63    53      P� 54       �@J�IsMouseOver . . �55      ��  � ��
 �����6;   56      58      5:      �� 5;   
   $ ��Format generowanego ciągu��6   $��20(�64   ���	#FF224BB6$
��Left=�6Y   $��
27,339,0,0q�6t   $	��Top=�6�   $
��auto��6�   �� 5<   
   -   5         ��Name$ outputFormatComboBox��5<   !   $��20(�6   $��305,341,0,0q�6?   $
��Left=�6T   $	��Top=�6o   $	��151��6�   $��37��6�   .@�5=      �� -   5         ��Name$ 	char_type��5=   K   $- 'Tekst składający się z zer i jedynek��6   $��Znaki (char)��6^    �� 
IsSelected . 6u   �� 5>      -   5        $ base64_type��5>   n   $R LRodzaj kodowania transportowego, kodowanie bajtów za pomocą ciągu znaków��6   $��Base64��6�   5?      �� 5@   
   -   5        $	 r1State��5@   D   $ Aktualny stan rejestru��6   $��01101010��61   $��20(�6U   ���	#FF224BB6$
��Left=�6{   $��
68,170,0,0q�6�   $	��Top=�6�   $	��699��6�   $��33��6�   ��5A      �� 5B      "
 ��6   .�5C      ��  � ��
 ���� 63    5D      P� 5E       �@J�IsMouseOver . . �5F      ��  � ��
 �����6;   5G      5I      5K      �� 5L   
   -   5        $	 r2State��5L   D   $ Aktualny stan rejestru��6   $��01101010��61   $��20(�6U   ���	#FF224BB6$
��Left=�6{   $��
68,271,0,0q�6�   $	��Top=�6�   $	��699��6�   $��33��6�   ��5M      �� 5N      "
 ��6   .�5O      ��  � ��
 ���� 63    5P      P� 5Q       �@J�IsMouseOver . . �5R      ��  � ��
 �����6;   5S      5U      5W      �� 5X   
   -   5        $ output��5X   2    �� 
IsReadOnly . $��20(�6$   $
��Left=�6B   $	��110��6]   $	��210��6m   $	��200��6z   $��
18,425,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��936��6�   �� 5Y   
   -   5         ��Name$ saveFileTxt��5Y      $��20(�6   $��Zapisz (.txt)��64   $
��Left=�6L   $��797,339,0,0q�6g   $	��Top=�6|   $	��157��6�   $��36��6�   6�   �� 5Z   
   -   5        $ saveFileBin��5Z      $��20(�6   $��Zapisz (.bin)��64   $
��Left=�6L   $��797,380,0,0q�6g   $	��Top=�6|   $	��157��6�   $��33��6�   6�   �� 5[   
   -   5        $ GenerateBtn��5[      $��74��6&   $��Center=�62   $��Center=�6V   $��487,339,502,232q�6q   .��5\      ��  �� TextAlignment$ Center=�6   $��30(�6/   $��Generuj ciąg��6=   $
��Wrap=�6Q   5]      >   8CryptoDesktopApplication.LoadingControl.LoadingAnimation  5^   
   -   5          Name$ LoadingCircle��5^   :   $y�	Collapsed=�6#   $��Center=�6Q   $��Center=�6n   $��84��6�   $��439,488,739,73q�6�   $	��102��6�     5_   
   -   5          Name$ 	singleBit��5_   "   $ Test pojedynczych bitów��65   $��1092,558,0,37q�6W   ���	#FF2196F3$ CloseCircle=�6�   $��54��6�   $��50��6�   $��Center=�6�     5`   
   -   5        $ 
seriesTest��5`   "   $ 
Test serii��66   $��974,558,0,37q�6K   ���	#FF2196F3$ CloseCircle=�6x   $��54��6�   $��50��6�   $��Center=�6�     5a   
   -   5        $ longSeriesTest��5a   "   $ Test długiej serii��6:   $��1033,558,0,37q�6W   ���	#FF2196F3$ CloseCircle=�6�   $��54��6�   $��50��6�   $��Center=�6�   $ 
0.722,0.54&�6�     5b   
   -   5        $ poker��5b   "   $ Test pokerowy��61   $��1151,558,0,37q�6I   ���	#FF2196F3$ CloseCircle=�6w   $��54��6�   $��50��6�   $��Center=�6�   �� 5c   
   $ ��Wyniki testów FIPS-140-2 ��6   $��20(�64   $8 2Ciągi krótsze niż 20 000 dają wynik negatywny.��6B   ���	#FF224BB6$
��Left=�6�   $��974,506,0,0q�6�   $	��Top=�6�   $
��auto��6�   $ 
0.48,0.676&�6�   ��5d      �� 5e      "
 ��6   .�5f      ��  � ��
 ���� 63    5g      P� 5h       �@J�IsMouseOver . . �5i      ��  � ��
 �����6;   5j      5l      5n      �� 5o   
   -   5        $ setRegister1��5o      $��20(�6   $��Ustaw rejestr��65   $
��Left=�6M   $��797,137,0,0q�6h   $	��Top=�6}   $	��157��6�   $��39��6�   6�   �� 5p   
   -   5        $ setRegister2��5p      $��20(�6   $��Ustaw rejestr��65   $
��Left=�6M   $��797,238,0,0q�6h   $	��Top=�6}   $	��157��6�   $��38��6�   6�   &   System.Windows.Controls.DataGrid  5q   
   -   5          Name$ PolynomialDataGrid��5q   �      CanUserAddRows .     AutoGenerateColumns .  $
��Left=�6�   $	��288��6�   $��959,137,0,0q�6�   $	��Top=�6  $	��301��6$  ��6�   ��    Columns 5r      0  *System.Windows.Controls.DataGridTextColumn  5s      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 67      Header$ 
Długość��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *Length+  5t      $ * 6%   $ 	Wielomian��6/    6B   �� *
Polynomial+5v      �� 5w   
   $� �Aby zmienić wielomian, wpisz liczby oddzielone przecinkami. Przykład: 1,3,5 oznacza bity na pozycji pierwszej, trzeciej i piątej licząc od lewej��6   $��20(�6�   $��Tabela wielomianów��6�   ���	#FF224BB6$
��Left=�6�   $��1018,95,0,0q�6  $	��Top=�6  $
��auto��65  ��5x      �� 5y      "
 ��6   .�5z      ��  � ��
 ���� 63    5{      P� 5|       �@J�IsMouseOver . . �5}      ��  � ��
 �����6;   5~      5�      5�      �� 5�   
   -   5        $ setPolynomial��5�      $��20(�6   $��Zresetuj tabelę��66   $1 +Przywraca wielomiany do początkowego stanu��6P   $
��Left=�6�   $��1082,430,0,0q�6�   $	��Top=�6�   $	��178��6�   $��35��6�   6�   �� 5�   
   -   5        $	 r1CurrentCounter��5�   ;   $' !Aktulna liczba bitów w rejestrze��6   $��20(�6U   $��8��6c   ���	#FF224BB6$
��Left=�6�   $��
30,170,0,0q�6�   $	��Top=�6�   $��38��6�   $��33��6�   ��5�      �� 5�      "
 ��6   .�5�      ��  � ��
 ���� 63    5�      P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
 �����6;   5�      5�      5�      �� 5�   
   -   5        $	 r2CurrentCounter��5�   ;   $' !Aktulna liczba bitów w rejestrze��6   $��20(�6U   $��8��6c   ���	#FF224BB6$
��Left=�6�   $��
30,271,0,0q�6�   $	��Top=�6�   $��38��6�   $��33��6�   ��5�      �� 5�      "
 ��6   .�5�      ��  � ��
 ���� 63    5�      P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
 �����6;   5�      5�      5�      5�      5�      