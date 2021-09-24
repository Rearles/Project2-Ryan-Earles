import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { DeckService } from '../deck-maker/deck-service';
import { Card } from '../card/card.component';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css'],
})

export class GameComponent implements OnInit{
  Deck: Card[] = this._dataService.getDeck();
  difficulty: string = localStorage.getItem("difficulty"); // easy, medium, hard
  playerHealth: number = 25; //players health
  playerMana: number = 1; //mana is needed for the player to play cards based on cost
  enemyHealth: number; //easy 15 medium 25 hard 35
  turnNumber: number = 0;// turn number
  descriptionText: string; //a description of what action the player or enemy just took
  currentPlayerCard: Card; //the card currently on the board for the player
  currentEnemyCard: Card; //the card currently on the board for the enemy
  Hand: Card[]; //the players hand html includes on click and index elemnets per card
  EnemyHand: Card[]; //the enemies hand, just card backs on html
  Win: number; //0 = loss 1 = tie 2 = win

  constructor(private _dataService: DeckService) {

  }
  //function to run the cycle of a typcial game, 10 turn limit
  gameCycle() {
    //initizlize with 2 cards in each hand
    //initialize enemy health based on difficulty
    //remember to splice card out of deck when drawn
    //remember to splice card out of hand when played
  }

  //a players half of the turn, can play a card, or attack enemies card/ enemy
  //draws card every turn, 1 mana added at the end of turn
  playerTurn() {

  }

  //an enemys half of the turn, can play a card, or attack players card/player
  //draw a card every turn
  enemyTurn() {

  }


  //enemy card attack is subtracted from player card health, and player card attack is subtracted from enemy card
  CardBattle() {

  }

  //attack a players health pool with current card, this removes the current card from play (empty instance)
  AttackPlayer() {

  }

  //attack an enemys health pool with current card, this removes the current card from play (empty instance)
  attackEnemy() {

  }

  //sets the currentplayercard slot to an empty instance of a card
  emptyPlayerCard() {

  }

  // sets the currentenemycard slot to an empty instance of a card
  emptyEnemyCard() {

  }

  ngOnInit() {

  }
}
