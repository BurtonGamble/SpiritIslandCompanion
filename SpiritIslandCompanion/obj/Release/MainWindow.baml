   M S B A M L   `   `   `  ���� P  LSpiritIslandCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:SpiritIslandCompanion.Properties SpiritIslandCompanion.Properties  =#clr-namespace:SpiritIslandCompanionSpiritIslandCompanion  &     SpiritIslandCompanion.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     E
Properties.clr-namespace:SpiritIslandCompanion.Properties     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:SpiritIslandCompanion     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  frmMain�� � Title$ Spirit Island Companion��$	��870��$	��635��$	��435��$	��318��$��0q�$
��Left=�$	��Top=� � Icon$, &assets/board_invader_full_4AE_icon.ico�� � 
ResizeMode$ CanResizeWithGrip=� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $��20 ��� $��* ��� $��15 �.+�o� -    o�Name$ mainMenu��$��0��$��20��$��Stretch=�$	��Top=� o� 
IsMainMenu . ����  �� ElementName$ mainGrid��	 �� Path$	 ActualWidth�.@�m� $��_File��.@�m� -   
 m�Name$
 newGame��$��	_New Game���� m� $��_Exit��m� $��_Special Actions��.@�m� $��_Event Cards��.@�m� -   $
 eventMissionariesArrive��$��Missionaries Arrive��m� -   $
 eventNewSpeciesSpread��$��New Species Spread��m� $#��Rising Interest in the Island��.@�m� -   $
 eventIgnoreTheCuriosity��$��Ignore the Curiosity��m� -   $ 
 eventWeaveLiesInTheirMinds��$0��*Weave Lies in the Minds of Their Observers��m� -   $
 eventSlaveRebellion��$��Slave Rebellion (France)��m� -	   $%
 eventWarTouchesTheIslandsShores��$$��War Touches the Islands Shores��m� $��_Powers��.@�m� -
   $
 showTopFear��$>��8_Reveal Top Fear Card (Bringer of Dreams and Nightmares)��m� $��_About��.@�m� -   $
 about��$��_About��� -    �Name$ MainGrid��$��1�� J� RenderTransformOrigin$ 0.5,0.5&� � LayoutTransform �� -   ApplicationScaleTransform�� �� CenterX$ 0Q� �� CenterY$ 0Q� �� ScaleX �� $ frmMain��$	 
ScaleValue� �� ScaleY �� $ frmMain��$	 
ScaleValue�����  �� ImageSource$< 6assets/other/adversaries/adversary-brand-prussia-2.png�� �� Opacity$	 0.2Q� j� Stretch$ UniformToFill=� �� RelativeTransform V� .~��� $	 0.5Q�$	 0.5Q�$ 1Q�$ 1Q���  �� AngleX$ 0Q� �� AngleY$ 0Q� �� CenterX$	 0.5Q� �� CenterY$	 0.5Q���  �� Angle$ 0Q� �� CenterX$	 0.5Q� �� CenterY$	 0.5Q�T� .+��� -    ��Name$ 
mainCanvas��.+��� -    ��Name$ imgMyAdversaryCard�� �� Left$	 580��
  �� Top$	  382��$	��264��$	��176��$
��Left=�$	��Top=�$<��6assets/other/adversaries/adversary-brand-prussia-2.png���� $	 746��$	  226��$��98��$	��146�����	#33808080
���   �$��1q��� $	 418��$	  226��$	��296��$	��146�����	#33808080
���   �$��1q��� -   $ imgFearEarnedDeck��$	 282��$	  196��$	��126��$	��176��$.��(assets/other/board/board-fear-earned.png��$��UniformToFill=��� -   ! ��Name$! btnFear��$	 146��$  41��$	��126��$	��145��$
��Left=�$	��Top=����	#FFDDDDDD$��+1 Fear��$
��Bold"�$��0���� -   " ��Name$" lblFear��$	 146��$	  155��$	��126��$��31��$
��Left=�$	��Top=�$��Center=�$��Center=�$��18(�$
��Bold"�# J� IsHitTestVisible# .  ���� *Fear+$ �� UpdateSourceTrigger$$ PropertyChanged=��� -   $" lblFearUntilNext��$	 146��$  41��$	��126��$��31��$
��Left=�$	��Top=�$��Center=�$��Center=�$��18(�$
��Bold"�# .  ���� *FearUntilNextCard+$$ PropertyChanged=��� -   % ��Name$% tbTurnOrder��$	 554��$  10��$	��290��$	��176��& �� Padding$& 0q�$��Center=�$	��Top=�$��Medium"�$ 0.5,0.5&�$6��0Ravage > Build > Explore > Advance Invader Cards��' �� TextAlignment$' Center=����� $	 0.5Q�( �� 
StartPoint$( 0.5,0&�) �� EndPoint$) 0.5,1&� V� .~��� $	 0.5Q�$	 0.5Q��� $	 0.5Q�$	 0.5Q��� $	 0.5Q�$	 0.5Q�T� .��� * � Offset$* 0Q�+ � Color$+ 	#FF509724��� $* 1Q�$+ 	#FF509724��� $	* 0.5Q�$+ White���� -   $ imgBlightCard��$ 10��$	  196��$	��126��$	��176��$2��,assets/cards/blight/cards-blight-healthy.png��$��UniformToFill=��� -   $ imgEventDeck��$	 146��$	  196��$	��126��$	��176��$-��'assets/other/board/board-event-deck.png��$��UniformToFill=��� -   $ imgEventDiscard��$	 146��$	  382��$	��126��$	��176��$0��*assets/other/board/board-event-discard.png��$��UniformToFill=��� -   $ imgFearDeck��$	 282��$  10��$	��126��$	��176��$/��)assets/other/board/board-fear-victory.png��$��UniformToFill=��� -   $" 	lblBlight��$ 88��$	  193��$��45��$��31��$
��Left=�$	��Top=�$��Right=�$	��Top=�, K� ZIndex$, 99��$��18(�$
��Bold"�# .  ���� *Blight+$$ PropertyChanged=��� -   $" lblFearCardsEarned��$	 360��$	  193��$��45��$��31��$��0q�$
��Left=�$	��Top=�$��Right=�$	��Top=�$, 99��$��18(�$
��Bold"�# .  ���� *FearEarnedDeck.Count+$$ PropertyChanged=��� -   $ imgFearDiscard��$	 282��$	  382��$	��126��$	��176��$
��Left=�$	��Top=�- J� OpacityMask
- �   �$/��)assets/other/board/board-fear-discard.png��$��UniformToFill=��� -   $" lblFearDeckCount��$	 360��$  7��$��45��$��31��$
��Left=�$	��Top=�$��Right=�$	��Top=�$, 99��$��18(�$
��Bold"����� *FearDeck.Count+$$ PropertyChanged=��� -   $! btnRemoveOneFear��$	 146��$  10��$	��126��$��-1 Fear��$
��Bold"��� -   $ imgTerrorCard��$	 418��$  10��$	��126��$	��176��$
��Left=�$	��Top=�$0��*assets/other/board/board-terror-level1.png��$��UniformToFill=��� -   $ imgInvaderDeck��$	 620��$	  232��$��88��$	��134��$2��,assets/other/board/board-invader-explore.png��$��UniformToFill=��� -    $ imgInvaderBuildDeck��$	 522��$	  232��$��88��$	��134��$0��*assets/other/board/board-invader-build.png��$��UniformToFill=��� -!   $ imgInvaderRavageDeck��$	 424��$	  232��$��88��$	��134��$1��+assets/other/board/board-invader-ravage.png��$��UniformToFill=��� -"   $ imgInvaderDiscard��$	 751��$	  232��$��88��$	��134��$��UniformToFill=��� $	 751��$	  205��$��88��$��Center=�$��Bottom=�$��Discard��$
��Bold"�# .  �� $	 424��$	  205��$��88��$��Center=�$��Bottom=�$��Ravage��$
��Bold"�# .  �� $	 522��$	  205��$��88��$��Center=�$��Bottom=�$��Build��$
��Bold"�# .  �� $	 620��$	  205��$��88��$��Center=�$��Bottom=�$��Invader Deck��$
��Bold"�# .  �� -#   $! btnAddBlight��$ 10��$	  166��$	��126��$��Heal the Island��$
��Bold"�
��� � ��� -$   $! btnRemoveBlight��$ 10��$	  382��$	��126��$��Blight the Island��$
��Bold"����	#FF400080�� -%   $ imgHighImmigrationTile��$	 418��$	  382��$	��147��$	��176��$
��Left=�$	��Top=�$:��4assets/other/board/board-invader-highimmigration.png��$��UniformToFill=��� -&   $ imgInvaderHighImmigration��$	 466��$	  391��$��88��$	��134��$��UniformToFill=��� -'   $" lblInvaderDeck��$��45��$��31��$��668,222,0,0q�$
��Left=�$	��Top=�$��Right=�$	��Top=�$, 99��$��18(�$
��Bold"�# .  ���� *InvaderDeck.Count+$$ PropertyChanged=��� $��2��$��15��$��Stretch=����� $ mainGrid��$	 ActualWidth�