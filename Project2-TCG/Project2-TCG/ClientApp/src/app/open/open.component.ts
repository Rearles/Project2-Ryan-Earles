import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Card } from '../card/card.component';

@Component({
  selector: 'app-open',
  templateUrl: './open.component.html',
})
export class OpenComponent {
  Cards: Card[];

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    let resp = this.http.get("https://localhost:44390/api/pack/1");
    resp.subscribe((result: Card[]) => {
      console.log(result)

      this.Cards = result;

    }, error => console.error(error))
  }
}
