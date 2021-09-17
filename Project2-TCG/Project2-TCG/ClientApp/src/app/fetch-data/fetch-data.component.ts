import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit{
  //public forecasts: WeatherForecast[];

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
  //    this.forecasts = result;
  //  }, error => console.error(error));

  public cards: any;
  
  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    let resp = this.http.get("https://localhost:44390/api/card");
    resp.subscribe(result => {
      console.log(result)
      this.cards = result;
    }, error => console.error(error))
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface Card {
  id: number,
  cost: number,
  attack: number,
  defense: number,
  name: string,
  color: string,
  rarity: string
}
