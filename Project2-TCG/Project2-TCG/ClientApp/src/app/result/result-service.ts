import { Injectable, Optional, SkipSelf } from '@angular/core';
import { Card } from '../card/card.component';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root',
})
export class ResultService {

  result: number;
  difficulty: string;


  constructor(@Optional() @SkipSelf() sharedService: ResultService) {
    if (sharedService) {
      throw new Error('DeckSerice is already loaded')
    }
    console.info('Deck Service Created')
  }

  setResult(res: number, diff: string) {
    this.difficulty = diff;
    this.result = res;
  }
  getResult() {
    return this.result;
  }
  getDifficulty() {
    return this.difficulty;
  }
}
