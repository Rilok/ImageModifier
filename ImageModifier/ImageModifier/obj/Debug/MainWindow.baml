   M S B A M L   `   `   `  ����H  DImageModifier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ImageModifierImageModifier  5   	   A%clr-namespace:ImageModifier.ViewModelImageModifier.ViewModel  5   	   J FImageProcessing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:ImageProcessing;assembly=ImageProcessingImageProcessing 5   	       ImageModifier.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ImageModifier     5   	   4mv%clr-namespace:ImageModifier.ViewModel     5   	   Ecl6clr-namespace:ImageProcessing;assembly=ImageProcessing     5   	     � Title$  
MainWindow��5
   	   $	��700��6   $	��600��6)   $	��700��65   $	��600��6E    � 	Resources 5      ,   &ImageModifier.ViewModel.ImageViewModel 	  ImgVM  ImageProcessing.Benchmark 	 Bench��%:   &	        &	        5   
   6,     5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��85* �6   5      �� 5      $	��12* �6   6+   .+�5   
   �� -   5         ��Name$ ImgBox��5      $��0��6   $��10q�6-   $��Stretch=�6:   $��Stretch=�6V   $
��Auto��6t   $
��Auto��6�    � DataContext# [  6�   ��5      �� *	Directory+ �� Mode$ TwoWay=�6<   �� 5   
   -   5         ��Name$	 Dir��5   !   $��1��6   $��10, 0, 10, 10q�6.   $��Center=�6E   $	��top=�6b   # [  6z   ��6�   �� *	Directory+6�   �� 5   
   -   5        $
 Time��5   !   $��1��6   $��20q�6/   $��Center=�6;   $	��Top=�6X   # [ 6p   ��6�   �� *
GetSeconds+6�   �� 5   
   -   5         ��Name$ LoadBtn��5      $��1��6   $��	Load File��6/   $	��100��6C   $��30��6O   $��10q�6[   $
��Left=�6g   $��Bottom=�6�   6�   �� 5   
   -   5        $ 
SaveSecBtn��5      $��1��6   $��Save (LockBits)��62   $	��100��6L   $��30��6X   $��10q�6d   $��Center=�6p   $��Bottom=�6�   6�   �� 5   
   -   5        $ SaveBtn��5      $��1��6   $��Save (GetPixel)��6/   $	��100��6I   $��30��6U   $��10q�6a   $��Right=�6m   $��Bottom=�6�   5      5      5      