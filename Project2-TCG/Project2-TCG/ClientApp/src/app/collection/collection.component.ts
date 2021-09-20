import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CardComponent } from '../card/card.component';
import { Card } from '../card/card.component';

@Component({
  selector: 'app-collection',
  templateUrl: './collection.component.html',
})
export class CollectionComponent {
  Cards: CardComponent[];
  constructor() {
    this.Cards = [
      //new CardComponent(),
      //new CardComponent()
    ];
  }
}
