   M S B A M L   `   `   `  ����J  FYouTunelPutty20, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:YouTunelPutty20._Client.Components"YouTunelPutty20._Client.Components  5   	   W0clr-namespace:YouTunelPutty20._Client.Converters"YouTunelPutty20._Client.Converters  5   	   M+clr-namespace:YouTunelPutty20._Client.ModelYouTunelPutty20._Client.Model  5   	   U/clr-namespace:YouTunelPutty20._Client.ViewModel!YouTunelPutty20._Client.ViewModel  5   	   -    'YouTunelPutty20._Client.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   G
components0clr-namespace:YouTunelPutty20._Client.Components     5   	   G
converters0clr-namespace:YouTunelPutty20._Client.Converters     5   	   =model+clr-namespace:YouTunelPutty20._Client.Model     5   	   E	viewModel/clr-namespace:YouTunelPutty20._Client.ViewModel     5   	     � Title$  YouTunelPutty 2.0��5   	   $	��250��6#   $	��235��60    � Icon$) #..\Resources\Images\128YouTunel.ico��6<    � 
ResizeMode$ CanMinimize=�5	   	    � ShowInTaskbar .   � WindowStyle$
 None=�68    � DataContext 5      ;  5YouTunelPutty20._Client.ViewModel.MainWindowViewModel  5   
    � 	Resources 5      B  <YouTunelPutty20._Client.Converters.BoolToVisibilityConverter    BooleanToVisibilityConverterI  CYouTunelPutty20._Client.Converters.InverseBoolToVisibilityConverter ' #InverseBooleanToVisibilityConverterN  HYouTunelPutty20._Client.Converters.InverseConnectionStateToBoolConverter ) %InverseConnectionStateToBoolConverterM  GYouTunelPutty20._Client.Converters.ConnectionStateToVisibilityConverter ( $ConnectionStateToVisibilityConverter��%t   &	        &	      &	 &     &	 9       5   
   6/     5   
   66     5   
   6;     5   
   6:   5      .��5      � ��5   
   �� 5        YouTunelBackground �� ImageSource# [ 6   .+�5   
   �� $��1q�6   ���	#FF000000 �� CornerRadius$ 10��6>   �� 5   
     YouTunelBanner#��[ 6   $
��Left=�5      $��0,0,0,208.6q�6-   $	��300��6B   �� 5!   
   	 �� Orientation$	 Vertical=�6   $��
10,46,10,0q�6,   .+�5#      �� $
��Left=�6   $	��Top=�63   $	��215��6K   
 �� SelectedIndex$
 0��5'       � Cursor$
 Hand��5(       �� DisplayMemberPath$	 Key��5)       �� SelectedValuePath$ Value��5*      ��5$      �� *
HostList+7  1YouTunelPutty20._Client.Model.ConnectionSingleton   Instance �� Source# Z  �� SelectedValue 5%      �� *SelectedProxy+ �� Mode$ TwoWay=�{�5&      �� *ConnectionState+ �� 	Converter   5*      �� 5-      $	 
Horizontal=�6   $��20��62   $��	-10,8,0,0q�6>   .+�5.      �� $��Explorer��6   $��10,0,0,0q�51      $��9(�52      $��Simplified Arabic)�6(   ���	#FF283E31$
 Hand��6^    d� 	IsChecked 5/      �� *SetupExplorer+{�50      �� *ConnectionState+   52   ^   �� 54      $��Firefox��6   $��10,0,0,0q�57      $��9(�58      $��Simplified Arabic)�6(   ���	#FF283E31$
 Hand��6^    55      �� *SetupFirefox+{�56      �� *ConnectionState+   58   ^   59      �� 5=      $��95��6   $	 Vertical=�6%   y�5>      �� *ProxyNeedsAuthentication+# Z # [  .+�5@      �� .+�5A      �� $����Vaše připojení vyžaduje Autorizaci. Prosím vyplňte přihlašovací údaje do vaší sítě ve tvaru [doména\username] a heslo��6    $
��Left=�6�   $��29��5B       $	��Top=�6,   $	��225��6D   $��9(�5C       $��WrapWithOverflow=�6-   $��Simplified Arabic)�6N   ���	#FF283E316m   5D      �� 5E      $��6��6   �� 5F      $	 
Horizontal=�6   $
��Left=�66   .+�5G      �� $
��Name��6   $
��Left=�6+   $	��Top=�6F   $��24��6^   $��66��6j   $��Arial Narrow)�6u   �� 5H      $
��Left=�6   $��23��69    �� TextWrapping$
 Wrap=�6F   $	��Top=�5I      $	��136��66   ��5H   Z   �� *
DomainUser+{�5I   C   �� *ConnectionState+   5J      �� 5K      $	 
Horizontal=�6   $
��Left=�66   .+�5L      �� $��Password��6   $
��Left=�6/   $	��Top=�6J    J� RenderTransformOrigin$ -0.276,0.844&�6b   $��66��6�   $��Arial Narrow)�6�   $��23��6�   G� 5M      -   5        $��SdsfDfsSfgsf��5M   =   $
��Left=�6"   $��23��6Q   $	��Top=�6]   $	��136��5N   "   {�6/   �� *ConnectionState+   5O      5P      �� 5S      $��87��6   $	 Vertical=�6%   $��10,0,0,5q�6<   y�5T      �� *ProxyNeedsAuthentication+# Z # [ .+�5U      �� $
��Left=�6   $��9(�5V      $��WrapWithOverflow=�6"   $��Simplified Arabic)�6C   ���	#FF283E31�� 5W      .��6     Mercedes v anonymním surfingu6?   5X      5Y      �� 5[      $	 
Horizontal=�6   $��Right=�62   $	��Top=�6O   $��	0,11,10,0q�6g   .+�5\      �� $	 Vertical=�6   $��Center=�64   $��10,0,0,0q�6Q   .+�5]      �� $	 
Horizontal=�6!   $
��Left=�6:   $��0,0,33,0q�6U   .+�5^      �� $�� ��6#     GreenSwitchStyle#��[ 6.   $
 Hand��5a   [   ��5_   %   �� *ConnectCommand+ 5`   %   �� *ConnectionState+ G  AYouTunelPutty20._Client.Converters.ConnectionStateToBoolConverter  $ TwoWay=���5a   %   ��  �� ElementName$ SdsfDfsSfgsf��6[   5b      �� 5c      $	 
Horizontal=�6!   $��0,3,0,0q�6:   .+�5d      �� $��8(�6$    �� TextAlignment$
 Left=�61   Vyp.6L   �� 5e      $��8(�6$   $ Right=�61   $��37,0,0,0q�6G   Zap.6_   5f      5g      �� 5j      $	 Vertical=�6   $��Center=�64   y�6Q   �� *ConnectionState+   .+�5k      ;   5YouTunelPutty20._Client.Components.AnimatedGifControl  -   5          Name$ GifCtrl��5k   4   �� 5l      $��8(�6    
Navazuji67   �� 5m      $��8(�6    
spojení66   5n      �� 5p      $	 Vertical=�6   $��Center=�64   $��10,0,0,0q�6Q   .+�5q      �� -   5         ��Name$ 
HomeButton��5q      $��26��5r      $��23��6'   ���	#FFF9F7F7  TransparentButton#���  6K   $��Center=�5s      ���	#FFFAFAFB��5q   1   �� *HomeCommand+.��5t      ��   YouTunelHome#��[ 6    $
��Fill=�6G   $��21��6V   $��23��6b   5u      �� 5v      $��8(�6    Domů63   5w      �� 5y      $	 Vertical=�6   $��Center=�64   $��10,0,0,0q�6Q   .+�5z      �� -   5        $ 
HideButton��5z      $��26��5{      $��23��6(   ���	#FFF9F7F7#���  6K   $��Center=�5|      ���	#FFFAFAFB��5z   1   �� *HideWindowCommand+.��5}      ��  	 YouTunelHide#��[	 6    $
��Fill=�6G   $��21��6V   $��23��6b   5~      �� 5      $��8(�6    	Schovat66   5�      5�      5�      5�      5�      