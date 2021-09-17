import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  ngOnInit(): void {
  }

  constructor(private http: HttpClient) {

  }

  onClick(username: string, password: string) {
    this.http.post<any>('https://localhost:44390/api/user/', { username, password }, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).subscribe(data => {
      console.log(data)
    })
  }
}
