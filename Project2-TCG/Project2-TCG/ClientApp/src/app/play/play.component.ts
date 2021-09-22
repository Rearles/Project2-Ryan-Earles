import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
})
export class PlayComponent /*implements OnInit*/ {

  constructor(private http: HttpClient) {

  }
  //ngOnInit{ }
}
