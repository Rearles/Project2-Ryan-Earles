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
  difficulty: string = localStorage.getItem("difficulty");
  playerHealth: number = 20;
  playerMana: number = 1;
  enemyHealth: number;
  turnNumber: number = 0;
  constructor(private _dataService: DeckService) {

  }
  pickCard() {

  }
  ngOnInit() {

  }
}
