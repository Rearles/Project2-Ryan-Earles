import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {
  public color: string;
  public imgurl: string;
  public attack: number;
  public defense: number;
  public name: string;
  public cost: number;
  public rarity: string;
  public id: number;
  constructor(result:Card) {
    this.id = result.id;
    this.color = result.color;
    this.imgurl = result.name;
    this.attack = result.attack;
    this.defense = result.cost;
    this.cost = result.cost;
    this.name = result.name;
    this.rarity = result.rarity;
  }
  /*constructor() {
    this.id = 1;
    this.color = "shiny";
    this.imgurl = "dinotank";
    this.attack = 3;
    this.defense = 5;
    this.name = "dinotank";
    this.cost = 1;
    this.rarity = "rare";
  }*/

  ngOnInit(): void {
  }

}
export class Card {
  public id: number;
  public cost: number;
  public attack: number;
  public defense: number;
  public name: string;
  public color: string;
  public rarity: string;
}
