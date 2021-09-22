import { Component,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CardComponent } from '../card/card.component';
import { Card } from '../card/card.component';


@Component({
  selector: 'app-collection',
  templateUrl: './collection.component.html',
})
export class CollectionComponent {
  Cards: Card[];
  username: string;
  message: string;
  constructor(private http: HttpClient) {
    this.Cards = [
      //new CardComponent(),
      //new CardComponent()
    ];
  }
  ngOnInit() {
    this.username = localStorage.getItem("user");
    if (this.username == null || this.username == "error") {
      this.message = "Not logged in!";
    } else {
      let resp = this.http.get("https://localhost:44390/api/user/" + this.username);
      resp.subscribe((result: Card[]) => {
        console.log(result)

        this.Cards = result;

      }, error => console.error(error))
    }
  }
}
