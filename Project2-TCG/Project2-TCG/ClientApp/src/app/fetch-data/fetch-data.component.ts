import { Component,  OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Card } from '../card/card.component';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent implements OnInit {


  card: Card;

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    try {
      let resp = this.http.get("/api/card");

      resp.subscribe((result: Card) => {
        console.log(result)

        this.card = result;

      }, error => console.error(error))
    } catch(err) {
      console.log(err);
    }
  }
}




