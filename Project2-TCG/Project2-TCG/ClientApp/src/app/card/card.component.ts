import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {
  @Input() card?: Card;
  constructor() {
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
export class Card implements OnInit {
  public id: number;
  public cost: number;
  public attack: number;
  public defense: number;
  public name: string;
  public color: string;
  public rarity: string;
}
