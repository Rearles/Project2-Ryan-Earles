import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { DeckService } from '../deck-maker/deck-service';
import { HttpClient } from '@angular/common/http';
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
  descriptionText: string = "Game Start"; //a description of what action the player or enemy just took
  currentPlayerCard: Card; //the card currently on the board for the player
  currentEnemyCard: Card; //the card currently on the board for the enemy
  Hand: Card[]; //the players hand html includes on click and index elemnets per card
  EnemyHand: Card[]; //the enemies hand, just card backs on html
  Win: number; //0 = loss 1 = tie 2 = win
  cardsRemaining: number = 10;
  draw: number;

  constructor(private _dataService: DeckService, private http: HttpClient) {

  }
  //function to run the cycle of a typcial game, 10 turn limit
  gameCycle() {
    //initizlize with 2 cards in each hand
    //initialize enemy health based on difficulty
    //remember to splice card out of deck when drawn
    //remember to splice card out of hand when played
    this.playerDraw();
    this.playerDraw();
    if (this.difficulty = "easy") {
      this.enemyHealth = 15;
    } else if (this.difficulty = "medium") {
      this.enemyHealth = 25;
    } else if (this.difficulty = "hard") {
      this.enemyHealth = 35;
    } else {
      //no difficulty given, return to home
    }

    //draw enemy cards
    

  }

  playCard(card: Card, index: number) {
    if (this.currentPlayerCard.id = -1) {
      if (card.cost <= this.playerMana) {
        this.currentPlayerCard = card;
        this.Hand.splice(index, 1);
        this.enemyTurn();
        this.turnNumber++;
      } else {
        this.descriptionText = "Not enough Mana!"
      }

    } else {
      this.descriptionText = "Already have a card in play!";
    }
  }
  playerDraw() {
    this.draw = Math.random() * this.cardsRemaining;
    this.cardsRemaining--;
    this.Hand.push(this.Deck[this.draw]);
    this.Hand.splice(this.draw, 1);
  }

  //a players half of the turn, can play a card, or attack enemies card/ enemy
  //draws card every turn, 1 mana added at the end of turn
  playerTurn() {
    if (this.turnNumber > 10) {
      if (this.playerHealth == this.enemyHealth) {
        this.Win = 2;
      } else if (this.attackPlayer > this.attackEnemy) {
        this.Win = 3;
      } else if (this.attackEnemy > this.attackPlayer) {
        this.Win = 1;
      }
    }
    this.playerDraw();


    this.playerMana++;
  }

  //an enemys half of the turn, can play a card, or attack players card/player
  //draw a card every turn

  enemyTurn() {
    try {
      let resp = this.http.get("/api/game/"+this.difficulty);

      resp.subscribe((result: Card) => {
        console.log(result)

        this.EnemyHand.push(result);

      }, error => console.error(error))
    } catch (err) {
      console.log(err);
    }
    if (this.currentEnemyCard.id = -1) {
      this.currentEnemyCard = this.EnemyHand[0];
      this.EnemyHand.splice(0, 1);
    } else {
      this.draw = Math.random() * 2;
      if (this.draw == 0) {
        this.CardBattle();
      } else {
        this.attackPlayer();
      }
    }

    this.playerTurn();
  }


  //enemy card attack is subtracted from player card health, and player card attack is subtracted from enemy card
  CardBattle() {
    this.currentEnemyCard.defense -= this.currentPlayerCard.attack;
    this.currentEnemyCard.attack -= this.currentPlayerCard.defense;
    if (this.currentEnemyCard.defense < 1) {
      this.emptyEnemyCard();
    }
    if (this.currentPlayerCard.defense < 1) {
      this.emptyPlayerCard();
    }
  }

  CardBattlePlayer() {
    if (this.currentPlayerCard.id != -1) {
      this.CardBattle();
      this.enemyTurn();
      this.turnNumber++;
    } else {
      this.descriptionText = "No Card in Play!";
    }

  }

  //attack a players health pool with current card, this removes the current card from play (empty instance)
  attackPlayer() {
    this.playerHealth -= this.currentEnemyCard.attack;
    this.emptyEnemyCard();
    this.descriptionText = "You were attaced by " + this.currentEnemyCard.name + ", losing" + this.currentEnemyCard.attack + " health!";
    if (this.playerHealth == 0) {
      this.Win = 1;
    }
    this.checkWin();
  }

  //attack an enemys health pool with current card, this removes the current card from play (empty instance)
  attackEnemy() {
    if (this.currentPlayerCard.id != -1) {
      this.enemyHealth -= this.currentPlayerCard.attack;
      this.emptyPlayerCard();
      this.descriptionText = "You attacked with " + this.currentPlayerCard.name + ", doing" + this.currentPlayerCard.attack + " damage!";
      if (this.enemyHealth < 0) {
        this.Win = 3;
      }
      this.checkWin();
      this.enemyTurn();
      this.turnNumber++;
    } else {
      this.descriptionText = "No Card in play!";
    }

  }

  //sets the currentplayercard slot to an empty instance of a card
  emptyPlayerCard() {
    this.currentPlayerCard = new Card();
    this.currentPlayerCard.id = -1;
    this.currentPlayerCard.name = "Empty";
    this.currentPlayerCard.color = "Empty";
    this.currentPlayerCard.rarity = "Empty";
  }

  // sets the currentenemycard slot to an empty instance of a card
  emptyEnemyCard() {
    this.currentEnemyCard = new Card();
    this.currentEnemyCard.id = -1;
    this.currentEnemyCard.name = "Empty";
    this.currentEnemyCard.color = "Empty";
    this.currentEnemyCard.rarity = "Empty";
  }

  checkWin() {
    if (this.Win != null) {
      //redirct to win page
    }
  }
  ngOnInit() {

  }
}
