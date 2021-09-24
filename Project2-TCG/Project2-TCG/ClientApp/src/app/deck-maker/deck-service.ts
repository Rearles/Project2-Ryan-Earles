import { Injectable, Optional, SkipSelf } from '@angular/core';
import { Card } from '../card/card.component';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root',
})
export class DeckService {

  Deck: Card[];
  

  constructor(@Optional() @SkipSelf() sharedService: DeckService) {
    if (sharedService) {
      throw new Error('DeckSerice is already loaded')
    }
    console.info('Deck Service Created')
  }

  setDeck(deck: Card[]) {
    this.Deck = deck;
  }
  getDeck() {
    return this.Deck;
  }
}
