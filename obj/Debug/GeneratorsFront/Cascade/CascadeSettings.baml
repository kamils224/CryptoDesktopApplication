   M S B A M L   `   `   `  ����S  OCryptoDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:CryptoDesktopApplication.GeneratorsFront.Cascade0CryptoDesktopApplication.GeneratorsFront.Cascade  5      a5clr-namespace:CryptoDesktopApplication.LoadingControl'CryptoDesktopApplication.LoadingControl  5      F    @CryptoDesktopApplication.GeneratorsFront.Cascade.CascadeSettings   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Plocal>clr-namespace:CryptoDesktopApplication.GeneratorsFront.Cascade     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Ccontrol5clr-namespace:CryptoDesktopApplication.LoadingControl  5      $	��645��5
      $
��1280��6   
�������.��5      � -   5          �Name$  Settings��5      .+�5   
   �� $
��Bold"�6   $��35(�6"   ���	#FF224BB6$��Center=�6G   $$��Kaskada Gollmanna - działanie��6l   $��
0,10,0,572q�6�   �� 5   
   $��20(�6   $@��:Podaj liczbę rejestrów i ustaw ich wartości początkowe��6   ���	#FF224BB6$
��Left=�6v   $��	30,68,0,0q�6�   $	��Top=�6�   $
��auto��6�   �� 5   
   ��. $��Visible=�60   $��10,115,332,318q�6V   .��5      �� -   5         ��Name$ 	Lfsr_list��5      $��Visible=�6,   $	��150��6`   5      5      �� 5   
   -   5         ��Name$ seriesLengthLabel��5      $��20(�6+   $"��Długość ciągu (w bitach)��69   ���	#FF224BB6$
��Left=�6s   $��
30,369,0,0q�6�   $	��Top=�6�   $
��auto��6�   �� 5   
   $ ��Format generowanego ciągu��6   $��20(�64   ���	#FF224BB6$
��Left=�6Y   $��
30,332,0,0q�6t   $	��Top=�6�   $
��auto��6�   �� 5   
   -   5         ��Name$ output��5   2    �� 
IsReadOnly . $��20(�6$   $
��Left=�6B   $	��110��6]   $	��193��6m   $	��200��6z   $��
30,425,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��918��6�   �� 5   
   -   5         ��Name$ saveFileTxt��5      $��20(�6   $��Zapisz (.txt)��64   $
��Left=�6L   $��790,332,0,0q�6g   $	��Top=�6|   $	��158��6�   $��37��6�   6�   �� 5   
   -   5        $ saveFileBin��5      $��20(�6   $��Zapisz (.bin)��64   $
��Left=�6L   $��790,374,0,0q�6g   $	��Top=�6|   $	��158��6�   $��37��6�   6�   �� 5   
   -   5        $ GenerateBtn��5      $��81��6&   $��Center=�62   $��Center=�6V   $��482,332,506,232q�6q   .��5      ��  �� TextAlignment$ Center=�6   $��30(�6/   $��Generuj ciąg��6=   $
��Wrap=�6Q   5      >   8CryptoDesktopApplication.LoadingControl.LoadingAnimation  5   
   -   5          Name$ LoadingCircle��5   :   $y�	Collapsed=�6#   $��Center=�6Q   $��Center=�6n   $��84��6�   $��482,477,696,84q�6�   $	��102��6�   '  !MaterialDesignThemes.Wpf.PackIcon  5   
   -	   5        	  Name$	 	singleBit��5   "   
 � ToolTip$
 Test pojedynczych bitów��65   $��1092,558,0,37q�6W   ���	#FF2196F3�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ CloseCircle=�6�   $��54��6�   $��50��6�   $��Center=�6�     5   
   -
   5        $	 
seriesTest��5   "   $
 
Test serii��66   $��974,558,0,37q�6K   ���	#FF2196F3$ CloseCircle=�6x   $��54��6�   $��50��6�   $��Center=�6�     5   
   -   5        $	 longSeriesTest��5   "   $
 Test długiej serii��6:   $��1033,558,0,37q�6W   ���	#FF2196F3$ CloseCircle=�6�   $��54��6�   $��50��6�   $��Center=�6�    J� RenderTransformOrigin$ 
0.722,0.54&�6�     5   
   -   5        $	 poker��5   "   $
 Test pokerowy��61   $��1151,558,0,37q�6I   ���	#FF2196F3$ CloseCircle=�6w   $��54��6�   $��50��6�   $��Center=�6�   �� 5   
   $ ��Wyniki testów FIPS-140-2 ��6   $��20(�64   $8
 2Ciągi krótsze niż 20 000 dają wynik negatywny.��6B   ���	#FF224BB6$
��Left=�6�   $��974,506,0,0q�6�   $	��Top=�6�   $
��auto��6�   $ 
0.48,0.676&�6�   ��5       �� 5!       �� 
TargetType" ��6   .�5"      ��  �� Property � �� �� Value
 ���� 63    �� Triggers 5#      P� 5$       P� Property �@J�IsMouseOver P� Value . . �5%      ��  � ��
 �����6;   5&      5(      5*      &   System.Windows.Controls.DataGrid  5+   
   -   5          Name$ PolynomialDataGrid��5+   �      CanUserAddRows .     AutoGenerateColumns .  $
��Left=�6�   $	��288��6�   $��959,137,0,0q�6�   $	��Top=�6  $	��301��6$  ��6�   ��    Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 67      Header$ 
Długość��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *Length+  5.      $ * 6%   $ 	Wielomian��6/    6B   �� *
Polynomial+50      �� 51   
   $�
 �Aby zmienić wielomian, wpisz liczby oddzielone przecinkami. Przykład: 1,3,5 oznacza bity na pozycji pierwszej, trzeciej i piątej licząc od lewej��6   $��20(�6�   $��Tabela wielomianów��6�   ���	#FF224BB6$
��Left=�6�   $��1018,95,0,0q�6  $	��Top=�6  $
��auto��65  ��52      �� 53      " ��6   .�54      ��  � ��
 ���� 63    55      P� 56       �@J�IsMouseOver . . �57      ��  � ��
 �����6;   58      5:      5<      �� 5=   
   -   5        $ setPolynomial��5=      $��20(�6   $��Zresetuj tabelę��66   $1
 +Przywraca wielomiany do początkowego stanu��6P   $
��Left=�6�   $��1082,430,0,0q�6�   $	��Top=�6�   $	��178��6�   $��35��6�   6�   �� 5>   
   -   5        $ numOfLfsrTxtBox��5>   o    �� 	MaxLength$ 2��66   $
 Liczba rejestrów��6�   $��20(�6�   $
��Left=�6�   $��33��6�   $��25��6�   $	��150��6�    �� TextAlignment$ Center=�6�   $
 Wrap=�6	  $	��Top=�6  $��
542,73,0,0q�65  �� 5?   
    �� Orientation$ 
Horizontal=�6   $��299,372,804,239q�6.   $ 0.5,0.5&�6G   .+�5@      �� -   5        $ outputLength��5@   s   $ 8��6:   $)
 #Liczba z zakresu od 0 do 99 999 999��6�   $��20(�6�   $
��Left=�6�   $��33��6�   $��25��6�   $	��151��6�   $ Center=�6  $��0,0,0,0q�6  $
 Wrap=�6.  $	��Top=�6B  �� 5A      -   5        $��20��5A      $��20��6    $��1,0,0,0q�6H   
������ 
������ .��5B        $
 Usunięcie tekstu��6*   $	��-16q�6E   ���	#FF224BB6$ CloseCircle=�6i   $��20��6|   $��20��6�   $��Center=�6�   5C      5D      �� 5E   
   -   5         ��Name$ outputFormatComboBox��5E   !   $��20(�6   $��299,334,0,0q�6?   $
��Left=�6T   $	��Top=�6o   $	��151��6�   $��37��6�   .@�5F      �� -   5         ��Name$ 	char_type��5F   K   $-
 'Tekst składający się z zer i jedynek��6   $��Znaki (char)��6^     �� 
IsSelected  . 6u   �� 5G      -   5        $ base64_type��5G   n   $R
 LRodzaj kodowania transportowego, kodowanie bajtów za pomocą ciągu znaków��6   $��Base64��6�   5H      �� 5I   
   -   5        $ createRegistersBtn��5I      $��16(�6   $��Stwórz rejestry��6;   $
��Left=�6U   $��
713,73,0,0q�6p   $	��Top=�6�   $	��158��6�   $��33��6�   6�   5J      5K      