import { Injectable } from '@angular/core';
import { Card } from '../card/card.component';
import { Router } from '@angular/router';
@Injectable()
export class DeckService {

  Deck: Card[];
  

  constructor(private router: Router) { }

  setDeck(deck: Card[]) {
    this.Deck = deck;
  }
  getDeck() {
    return this.Deck;
  }
}
