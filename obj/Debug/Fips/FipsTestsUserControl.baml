   M S B A M L   `   `   `  ����S  OCryptoDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:CryptoDesktopApplication.FipsCryptoDesktopApplication.Fips  5      8    2CryptoDesktopApplication.Fips.FipsTestsUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      7local+clr-namespace:CryptoDesktopApplication.Fips  5      $	��645��5	      $
��1280��6   
�������  � 	Resources  5      '  !MaterialDesignThemes.Wpf.PackIcon   	ArrowLeft�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind��%T   &	          5   
   $ 	ArrowLeft=�64   
�������$��40��6X   $��40��6c   5      .��5      � -   5         �Name$ 	TestyFips��5      
�������$��	0,0,0,-30q�65   .+�5   
   � 
�������$��0,0,829,370q�6"   .+�5      �� $��30(�6   $��25,79,27,173q�6"   .��68   Wybór formatu wejściowego5      �� 5      $
��Bold"�6   $��Center=�6&   $��50(�6C   $��
Testy FIPS��6R   $	��294��6g   $��25,0,132,223q�6s   �� 5      -   5        $��LoadFileButton��5   B    � ToolTip$( "Wczytuje plik i przeprowadza testy��6   $��26(�6X   $
��Auto��6g   $��25,213,43,31q�6�   .��6�   Wczytaj ciąg5      �� 5      -   5        $��FormatTypeComboBox��5       �� SelectedIndex$ 0��62   $��30(�6D   $��Center=�6R   $	��383��6p   $��25,134,43,117q�6|   .@�5      �� -   5        $��	TxtFormat��5   i   $I CPlik zawierający znaki 0 lub 1 o długości minimum 20 000 znaków��6   .��6z   Plik tekstowy5      �� 5      -   5        $��	BinFormat��5   h   $H BDowolny plik o długości co najmniej 2500 bajtów (20 000 bitów)��6   .��6y   Plik binarny5       5"      5#      �� 5$   
   $
��Auto=�6   ��. $��451,169,0,206q�6R   .��5%      �� 
������� �� Orientation$ Vertical=�6+   $	��303��6B   .+�5&      �� $
��Bold"�6   $
��Wrap=�6.   $��30(�6B   $��
Test serii��6P   $��10,0,0,0q�6b   �� 5'      -   5         ��Name$ SeriesOnesText��5'      $
��Wrap=�64   $��28(�6H   $��
10,0,180,0q�6V   �� 6k   $�Seria jedynek: ��6o   �� 6�   $� ��6�   6�   �� 5(      -   5        $��SeriesZerosText��5(      $
��Wrap=�63   $��28(�6G   $��Seria zer: ��6U   $��
10,0,180,0q�6h   �� 5)      -   5        $��SeriesResultText��5)      $
��Wrap=�65   $��28(�6I   $��Wynik: ��6W   $��10,0,0,0q�6f   5*      5+      �� 5,   
   
�������$ Vertical=�6,   $	��175��6C   $��
0,469,0,31q�6P   .+�5-      �� $
��Bold"�6   $
��Wrap=�6*   $��30(�6>   $��Test pokerowy��6L   $��10,0,0,0q�6a   �� 5.      -	   5        $��PokerTestXText��5.      $
��Wrap=�6.   $��28(�6B   $��Wartość X: ��6P   $��10,0,0,0q�6c   �� 5/      -
   5        $��PokerTestResultText��5/      $
��Wrap=�63   $��28(�6G   $��Wynik: ��6U   $��10,0,0,0q�6d   51      �� 52   
   
�������$ Vertical=�6+   $��0,305,829,206q�6B   .+�53      �� $
��Bold"�6   $
��Wrap=�6*   $��30(�6>   $��Test długiej serii��6L   $��10,0,0,0q�6f   �� 54      -   5        $��LongSeriesInfoText��54      $
��Wrap=�62   $��28(�6F   $��10,0,0,0q�6T   $��Najdłuższa seria: ��6f   6�   �� 55      -   5        $��LongSeriesResultText��55      $
��Wrap=�64   $��28(�6H   $��10,0,0,0q�6V   $��Wynik: ��6h   6y   56      �� 57   
   
�������$ Vertical=�6+   $��451,0,0,506q�6B   .+�58      �� $
��Bold"�6   $
��Wrap=�6*   $��30(�6>   $��45��6L   $��10,0,0,0q�6X   Test pojedynczych bitów5:      �� 5;      -   5        $��SingletestInfo��5;   0   $��Liczba jedynek: ��6   $
��Wrap=�6F   $��28(�6Z   $��41��6h   $��10,0,0,0q�6t   5=      �� 5>      -   5        $��SingleTestResult��5>   '   $��Wynik: ��6   $
��Wrap=�6?   $��28(�6S   $��41��6a   $��10,0,0,0q�6m   5@      5A      5B      5C      