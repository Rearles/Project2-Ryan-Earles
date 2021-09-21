import { Component, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from './user';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {

  constructor(private http: HttpClient) {

  }

  user: User;

  onClick(username: string, password: string) {
    this.http.post<any>('https://localhost:44390/api/login/', { username, password }, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).subscribe(data => {
      this.user = {username: data.username, password: data.password, currency: data.currency}
      console.log(this.user.username)
    })
  }
}

