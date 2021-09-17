import { Component, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {

  constructor(private http: HttpClient) {

  }

  onClick(username: string, password: string) {
    console.log(username + ' ' + password);
  }
}

