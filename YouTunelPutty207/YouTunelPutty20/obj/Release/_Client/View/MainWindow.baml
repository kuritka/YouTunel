   M S B A M L   `   `   `  ���� J  FYouTunelPutty20, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:YouTunelPutty20._Client.Components"YouTunelPutty20._Client.Components  W0clr-namespace:YouTunelPutty20._Client.Converters"YouTunelPutty20._Client.Converters  M+clr-namespace:YouTunelPutty20._Client.ModelYouTunelPutty20._Client.Model  U/clr-namespace:YouTunelPutty20._Client.ViewModel!YouTunelPutty20._Client.ViewModel  -    'YouTunelPutty20._Client.View.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     G
components0clr-namespace:YouTunelPutty20._Client.Components     G
converters0clr-namespace:YouTunelPutty20._Client.Converters     =model+clr-namespace:YouTunelPutty20._Client.Model     E	viewModel/clr-namespace:YouTunelPutty20._Client.ViewModel       � Title$  YouTunelPutty 2.0��$	��250��$	��235�� � Icon$) #..\Resources\Images\128YouTunel.ico�� � 
ResizeMode$ CanMinimize=� � ShowInTaskbar .   � WindowStyle$
 None=� � DataContext ;  5YouTunelPutty20._Client.ViewModel.MainWindowViewModel   � 	Resources B  <YouTunelPutty20._Client.Converters.BoolToVisibilityConverter    BooleanToVisibilityConverterI  CYouTunelPutty20._Client.Converters.InverseBoolToVisibilityConverter ' #InverseBooleanToVisibilityConverterN  HYouTunelPutty20._Client.Converters.InverseConnectionStateToBoolConverter ) %InverseConnectionStateToBoolConverterM  GYouTunelPutty20._Client.Converters.ConnectionStateToVisibilityConverter ( $ConnectionStateToVisibilityConverter��%<   &	        &	      &	 
     &	              .��� ����   YouTunelBackground �� ImageSource# [ .+��� $��1q����	#FF000000 �� CornerRadius$ 10����   YouTunelBanner#��[ $
��Left=�$��0,0,0,208.6q�$	��300���� 	 �� Orientation$	 Vertical=�$��
10,46,10,0q�.+��� $
��Left=�$	��Top=�$	��215��
 �� SelectedIndex$
 0�� � Cursor$
 Hand�� �� DisplayMemberPath$	 Key�� �� SelectedValuePath$ Value������ *
HostList+7  1YouTunelPutty20._Client.Model.ConnectionSingleton   Instance �� Source# Z  �� SelectedValue �� *SelectedProxy+ �� Mode$ TwoWay=�{��� *ConnectionState+ �� 	Converter   �� $	 
Horizontal=�$��20��$��	-10,8,0,0q�.+��� $��Explorer��$��10,0,0,0q�$��9(�$��Simplified Arabic)����	#FF283E31$
 Hand�� d� 	IsChecked �� *SetupExplorer+{��� *ConnectionState+   �� $��Firefox��$��10,0,0,0q�$��9(�$��Simplified Arabic)����	#FF283E31$
 Hand�� �� *SetupFirefox+{��� *ConnectionState+   �� $��95��$	 Vertical=�y��� *ProxyNeedsAuthentication+# Z # [  .+��� .+��� $����Vaše připojení vyžaduje Autorizaci. Prosím vyplňte přihlašovací údaje do vaší sítě ve tvaru [doména\username] a heslo��$
��Left=�$��29��$	��Top=�$	��225��$��9(�$��WrapWithOverflow=�$��Simplified Arabic)����	#FF283E31�� $��6���� $	 
Horizontal=�$
��Left=�.+��� $
��Name��$
��Left=�$	��Top=�$��24��$��66��$��Arial Narrow)��� $
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��136������ *
DomainUser+{��� *ConnectionState+   �� $	 
Horizontal=�$
��Left=�.+��� $��Password��$
��Left=�$	��Top=� J� RenderTransformOrigin$ -0.276,0.844&�$��66��$��Arial Narrow)�$��23��G� -   $��SdsfDfsSfgsf��$
��Left=�$��23��$	��Top=�$	��136��{��� *ConnectionState+   �� $��87��$	 Vertical=�$��10,0,0,5q�y��� *ProxyNeedsAuthentication+# Z # [ .+��� $
��Left=�$��9(�$��WrapWithOverflow=�$��Simplified Arabic)����	#FF283E31�� .�� Mercedes v anonymním surfingu�� $	 
Horizontal=�$��Right=�$	��Top=�$��	0,11,10,0q�.+��� $	 Vertical=�$��Center=�$��10,0,0,0q�.+��� $	 
Horizontal=�$
��Left=�$��0,0,33,0q�.+��� $�� ��  GreenSwitchStyle#��[ $
 Hand������ *ConnectCommand+ �� *ConnectionState+ G  AYouTunelPutty20._Client.Converters.ConnectionStateToBoolConverter  $ TwoWay=�����  �� ElementName$ SdsfDfsSfgsf���� $	 
Horizontal=�$��0,3,0,0q�.+��� $��8(� �� TextAlignment$
 Left=�Vyp.�� $��8(�$ Right=�$��37,0,0,0q�Zap.�� $	 Vertical=�$��Center=�y��� *ConnectionState+   .+�;   5YouTunelPutty20._Client.Components.AnimatedGifControl  -     Name$ GifCtrl���� $��8(�
Navazuji�� $��8(�
spojení�� $	 Vertical=�$��Center=�$��10,0,0,0q�.+��� -    ��Name$ 
HomeButton��$��26��$��23�����	#FFF9F7F7  TransparentButton#���  $��Center=����	#FFFAFAFB���� *HomeCommand+.����   YouTunelHome#��[ $
��Fill=�$��21��$��23���� $��8(�Domů�� $	 Vertical=�$��Center=�$��10,0,0,0q�.+��� -   $ 
HideButton��$��26��$��23�����	#FFF9F7F7#���  $��Center=����	#FFFAFAFB���� *HideWindowCommand+.����  	 YouTunelHide#��[	 $
��Fill=�$��21��$��23���� $��8(�	Schovat