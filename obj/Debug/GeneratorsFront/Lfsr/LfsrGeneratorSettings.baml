   M S B A M L   `   `   `  ����S  OCryptoDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:CryptoDesktopApplication.GeneratorsFront.LfsrGen0CryptoDesktopApplication.GeneratorsFront.LfsrGen  5      a5clr-namespace:CryptoDesktopApplication.LoadingControl'CryptoDesktopApplication.LoadingControl  5      L    FCryptoDesktopApplication.GeneratorsFront.LfsrGen.LfsrGeneratorSettings   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Plocal>clr-namespace:CryptoDesktopApplication.GeneratorsFront.LfsrGen     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Ccontrol5clr-namespace:CryptoDesktopApplication.LoadingControl  5      $	��645��5
      $
��1280��6   
�������.��5      � -   5          �Name$  Settings��5      .+�5   
   �� $
��Bold"�6   $��35(�6"   ���	#FF224BB6$��Center=�6G   $��LFSR - działanie��6l   $��
0,10,0,572q�6�   �� 5   
   $��20(�6   $,��&Ustaw wartości początkowe rejestrów��6   ���	#FF224BB6$
��Left=�6c   $��	30,59,0,0q�6~   $	��Top=�6�   $
��auto��6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��68,137,488,475q�6.    J� RenderTransformOrigin$ 0.5,0.5&�6F   .+�5      �� -   5         ��Name$ lfsr1��5   �    �� 	MaxLength$ 32��6p    � ToolTip$ Znak 0 lub 1��6�   $��20(�6�   $
��Left=�6�   $��33��6�   $��25��6�   $	��700��6�    �� TextAlignment$ Center=�6�   $��0,0,0,0q�6   �� TextWrapping$
 Wrap=�6  $	��Top=�61  6I  �� 5      -   5        $��20��5      $��20��6    $��1,0,0,0q�6A   
������ 
������ .��5      '  !MaterialDesignThemes.Wpf.PackIcon  $ Usunięcie tekstu��6*   $	��-16q�6E   ���	#FF224BB6�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ CloseCircle=�6i   $��20��6|   $��20��6�   $��Center=�6�   5      5      �� 5   
   $��20(�6   $��	Rejestr 1��6   ���	#FF224BB6$
��Left=�6I   $��
68,100,0,0q�6d   $	��Top=�6x   $
��auto��6�   �� 5   
   -   5        	 ��Name$	 seriesLengthLabel��5      $��20(�6+   $"��Długość ciągu (w bitach)��69   ���	#FF224BB6$
��Left=�6s   $��
30,353,0,0q�6�   $	��Top=�6�   $
��auto��6�   �� 5   
   $ 
Horizontal=�6   $��314,353,788,258q�6.   $ 0.5,0.5&�6G   .+�5      �� -   5        $ outputLength��5   s   $ 9��6:   $) #Liczba z zakresu od 0 do 99 999 999��6�   $��20(�6�   $
��Left=�6�   $��33��6�   $��25��6�   $	��150��6�   $ Center=�6  $��0,0,0,0q�6  $
 Wrap=�6.  $	��Top=�6B  �� 5      -   5        $��20��5      $��20��6    $��1,0,0,0q�6H   
������ 
������ .��5        $ Usunięcie tekstu��6*   $	��-16q�6E   ���	#FF224BB6$ CloseCircle=�6i   $��20��6|   $��20��6�   $��Center=�6�   5      5      �� 5   
   -   5        $	 	r1Counter��5   '   $ Liczba bitów��6   $��20(�6:   $��0��6H   ���	#FF224BB6$
��Left=�6k   $��
30,136,0,0q�6�   $	��Top=�6�   $��38��6�   $��33��6�   ��5      �� 5      
 �� 
TargetType"
 ��6   .�5      ��  �� Property � �� �� Value
 ���� 63    �� Triggers 5       P� 5!       P� Property �@J�IsMouseOver P� Value . . �5"      ��  � ��
 �����6;   5#      5%      5'      �� 5(   
   $ ��Format generowanego ciągu��6   $��20(�64   ���	#FF224BB6$
��Left=�6Y   $��
30,316,0,0q�6t   $	��Top=�6�   $
��auto��6�   �� 5)   
   -   5         ��Name$ outputFormatComboBox��5)   !   $��20(�6   $��314,315,0,0q�6?   $
��Left=�6T   $	��Top=�6o   $	��150��6�   $��38��6�   .@�5*      �� -	   5         ��Name$ 	char_type��5*   K   $- 'Tekst składający się z zer i jedynek��6   $��Znaki (char)��6^    �� 
IsSelected . 6u   �� 5+      -
   5        $ base64_type��5+   n   $R LRodzaj kodowania transportowego, kodowanie bajtów za pomocą ciągu znaków��6   $��Base64��6�   5,      �� 5-   
   -   5        $	 r1State��5-   D   $ Aktualny stan rejestru��6   $��01101010��61   $��20(�6U   ���	#FF224BB6$
��Left=�6{   $��
68,170,0,0q�6�   $	��Top=�6�   $	��699��6�   $��33��6�   ��5.      �� 5/      "
 ��6   .�50      ��  � ��
 ���� 63    51      P� 52       �@J�IsMouseOver . . �53      ��  � ��
 �����6;   54      56      58      �� 59   
   -   5        $ output��59   2    �� 
IsReadOnly . $��20(�6$   $
��Left=�6B   $	��110��6]   $	��193��6m   $	��200��6z   $��
30,425,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��918��6�   �� 5:   
   -   5         ��Name$ saveFileTxt��5:      $��20(�6   $��Zapisz (.txt)��64   $
��Left=�6L   $��790,316,0,0q�6g   $	��Top=�6|   $	��158��6�   $��37��6�   6�   �� 5;   
   -   5        $ saveFileBin��5;      $��20(�6   $��Zapisz (.bin)��64   $
��Left=�6L   $��790,358,0,0q�6g   $	��Top=�6|   $	��158��6�   $��37��6�   6�   �� 5<   
   -   5        $ GenerateBtn��5<      $��74��6&   $��Center=�62   $��Center=�6V   $��497,316,506,255q�6q   .��5=      ��  �� TextAlignment$ Center=�6   $��30(�6/   $��Generuj ciąg��6=   $
��Wrap=�6Q   5>      >   8CryptoDesktopApplication.LoadingControl.LoadingAnimation  5?   
   -   5          Name$ LoadingCircle��5?   :   $y�	Collapsed=�6#   $��Center=�6Q   $��Center=�6n   $��84��6�   $��450,477,728,84q�6�   $	��102��6�     5@   
   -   5          Name$ 	singleBit��5@   "   $ Test pojedynczych bitów��65   $��1092,558,0,37q�6W   ���	#FF2196F3$ CloseCircle=�6�   $��54��6�   $��50��6�   $��Center=�6�     5A   
   -   5        $ 
seriesTest��5A   "   $ 
Test serii��66   $��974,558,0,37q�6K   ���	#FF2196F3$ CloseCircle=�6x   $��54��6�   $��50��6�   $��Center=�6�     5B   
   -   5        $ longSeriesTest��5B   "   $ Test długiej serii��6:   $��1033,558,0,37q�6W   ���	#FF2196F3$ CloseCircle=�6�   $��54��6�   $��50��6�   $��Center=�6�   $ 
0.722,0.54&�6�     5C   
   -   5        $ poker��5C   "   $ Test pokerowy��61   $��1151,558,0,37q�6I   ���	#FF2196F3$ CloseCircle=�6w   $��54��6�   $��50��6�   $��Center=�6�   �� 5D   
   $ ��Wyniki testów FIPS-140-2 ��6   $��20(�64   $8 2Ciągi krótsze niż 20 000 dają wynik negatywny.��6B   ���	#FF224BB6$
��Left=�6�   $��974,506,0,0q�6�   $	��Top=�6�   $
��auto��6�   $ 
0.48,0.676&�6�   ��5E      �� 5F      "
 ��6   .�5G      ��  � ��
 ���� 63    5H      P� 5I       �@J�IsMouseOver . . �5J      ��  � ��
 �����6;   5K      5M      5O      �� 5P   
   -   5        $ setRegister1��5P      $��20(�6   $��Ustaw rejestr��65   $
��Left=�6M   $��797,135,0,0q�6h   $	��Top=�6}   $	��157��6�   $��39��6�   6�   &   System.Windows.Controls.DataGrid  5Q   
   -   5          Name$ PolynomialDataGrid��5Q   �   
�������   CanUserAddRows .     AutoGenerateColumns .  $
��Left=�6�   $	��288��6�   $��959,137,0,0q�6
  $	��Top=�6  $	��301��67  ��6�   ��    Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 67      Header$ 
Długość��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *Length+  5T      $ * 6%   $ 	Wielomian��6/    6B   �� *
Polynomial+5V      �� 5W   
   $� �Aby zmienić wielomian, wpisz liczby oddzielone przecinkami. Przykład: 1,3,5 oznacza bity na pozycji pierwszej, trzeciej i piątej licząc od lewej��6   $��20(�6�   $��Tabela wielomianów��6�   ���	#FF224BB6$
��Left=�6�   $��1018,95,0,0q�6  $	��Top=�6  $
��auto��65  ��5X      �� 5Y      "
 ��6   .�5Z      ��  � ��
 ���� 63    5[      P� 5\       �@J�IsMouseOver . . �5]      ��  � ��
 �����6;   5^      5`      5b      �� 5c   
   -   5        $ setPolynomial��5c      $��20(�6   $��Zresetuj tabelę��66   $1 +Przywraca wielomiany do początkowego stanu��6P   $
��Left=�6�   $��1082,430,0,0q�6�   $	��Top=�6�   $	��178��6�   $��35��6�   6�   �� 5d   
   -   5        $	 r1CurrentCounter��5d   ;   $' !Aktulna liczba bitów w rejestrze��6   $��20(�6U   $��8��6c   ���	#FF224BB6$
��Left=�6�   $��
30,170,0,0q�6�   $	��Top=�6�   $��38��6�   $��33��6�   ��5e      �� 5f      "
 ��6   .�5g      ��  � ��
 ���� 63    5h      P� 5i       �@J�IsMouseOver . . �5j      ��  � ��
 �����6;   5k      5m      5o      �� 5p   
   -   5          ��Name$  calculatePeriodCheckbox��5p      $��156,234,1086,375q�64   $ 0.342,0.181&�6N   z�5q      V� 5r      .~�5s      �� �� 5t      ! �� AngleX$! -0.286Q�6$   �� 5u      T� 5v      " T� X$" -0.061Q�6)   5w      # � LayoutTransform# 5y      �� 5z      $ �� ScaleX$$ 2Q�6!   % �� ScaleY$% 2Q�6,   5|      �� 5}   
   $S MGeneruje ciąg wraz z informacją o okresie, ale spowalnia generowanie bitów��6   $��Oblicz okres��6e   $��20(�6|   ���	#FF224BB6$
��Left=�6�   $��
30,230,0,0q�6�   $	��Top=�6�   $	��126��6�   ��5~      �� 5      "
 ��6   .�5�      ��  � ��
 ���� 63    5�      P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
 �����6;   5�      5�      5�      �� 5�   
   -   5        & ��Name$& 	periodTxt��5�   (   $y�Hidden=�6   $ Center=�6;   
�������$��0��6i   $��20(�6r   ���	#FF224BB6$
��Left=�6�   $	��Top=�6�   $	��460��6�   $��314,277,0,0q�6�   �� 5�   
   -   5        $	 periodLabel��5�   $   $y�Hidden=�6   $!��Okres wygenerowanego ciągu��69   $��20(�6^   ���	#FF224BB6$
��Left=�6�   $��
30,272,0,0q�6�   $	��Top=�6�   $
��auto��6�   5�      5�      