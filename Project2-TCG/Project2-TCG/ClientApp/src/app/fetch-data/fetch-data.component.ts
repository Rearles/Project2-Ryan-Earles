import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CardComponent } from '../card/card.component';
import { Card } from '../card/card.component';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  //public forecasts: WeatherForecast[];

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
  //    this.forecasts = result;
  //  }, error => console.error(error));

  Cards: Card[];

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    let resp = this.http.get("https://localhost:44390/api/card");
    resp.subscribe((result: Card) => {
      console.log(result)
      this.Cards = [result];
     
    }, error => console.error(error))
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

/*interface Card {
  id: number,
  cost: number,
  attack: number,
  defense: number,
  name: string,
  color: string,
  rarity: string
}*/
