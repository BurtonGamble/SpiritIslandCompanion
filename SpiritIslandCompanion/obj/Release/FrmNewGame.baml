   M S B A M L   `   `   `  ���� P  LSpiritIslandCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SpiritIslandCompanionSpiritIslandCompanion  &     SpiritIslandCompanion.FrmNewGame   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:SpiritIslandCompanion     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  New Game��$	��510��$	��420��$��10q� � Icon$, &assets/board_invader_full_4AE_icon.ico�� � 
ResizeMode$ NoResize=� � Topmost .  � WindowStartupLocation$ CenterScreen=�.��� .+��� $	��235��$	��290��$��	250,0,0,0q�$
��Left=�$	��Top=�$��Scenario��.��� $	��235��$	��272��$��
0,0,-12,-4q�$
��Left=�$	��Top=�.+��� $��0q�$��Center=�$��Center=�$��Soon™��$��20(�$
��Bold"��� $	��235��$	��290��$��10,0,0,0q�$
��Left=�$	��Top=�$��	Adversary��.��� $	��235��$	��272��$��
0,0,-12,-4q�$
��Left=�$	��Top=�.+��� -    ��Name$ lbAdversaries��$	��203��$��20��$��	10,10,0,0q�$
��Left=�$	��Top=�$��11(� �� 
IsReadOnly . ��. $��Disabled=�$��Disabled=�$��9�� � ToolTip$ Choose an Adversary�� �� SelectedItem �� *SelectedAdversary+	 �� Mode$	 TwoWay=��� $��
58,209,0,0q�$
��Left=�$	��Top=�$��Adversary Level:���� -   
 ��Name$
 lblAdvLevel��$��153,209,0,0q�$
��Left=�$	��Top=����� *Value+ �� ElementName$ slAdversaryLevel�� �� UpdateSourceTrigger$ PropertyChanged=��� -    ��Name$ slAdversaryLevel��$	��203��$��30��$��
10,232,0,0q�$
��Left=�$	��Top=� J� IsManipulationEnabled .  �� IsSnapToTickEnabled .  � Maximum$ 6Q� � SmallChange$ 1Q�$��0�� �� TickPlacement$ BottomRight=�$ Adversary Level���� -   $	��203��$	��174��$��	10,35,0,0q�$
��Left=�$	��Top=�$��UniformToFill=����� *SelectedAdversary.Source+�� -    ��Name$ btnOK��$��75��$��409,352,0,0q�$
��Left=�$	��Top=�$��OK�� �� 	IsDefault . �� -   $ 	btnCancel��$��75��$��307,352,0,0q�$
��Left=�$	��Top=�$��Cancel�� �� IsCancel . �� -   $ 	slPlayers��$	��256��$��30��$��167,301,0,0q�$
��Left=�$	��Top=� .  . $ 6Q� � Minimum$ 1Q�$ 1Q�$��0��$ BottomRight=�$ Number of Players���� $��
51,304,0,0q�$
��Left=�$	��Top=�$��Number of Players:���� -	   $
 	lbPlayers��$��428,304,0,0q�$
��Left=�$	��Top=����� *Value+$ 	slPlayers��$ PropertyChanged=�