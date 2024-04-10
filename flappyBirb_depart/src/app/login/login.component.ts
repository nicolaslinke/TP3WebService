import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { LoginDTO } from '../models/LoginDTO';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  domain : string = "https://localhost:7153/"

  hide = true;

  registerUsername : string = "";
  registerEmail : string = "";
  registerPassword : string = "";
  registerPasswordConfirm : string = "";

  loginUsername : string = "";
  loginPassword : string = "";

  constructor(public route : Router, public http : HttpClient) { }

  ngOnInit() {
  }

  async login() : Promise<void>{
    let loginDTO = new LoginDTO(this.loginUsername, this.loginPassword);
    let x = await lastValueFrom(this.http.post<any>(this.domain + "api/Users/Login", loginDTO))
    console.log(x);
    localStorage.setItem("token", x.token);


    // Redirection si la connexion a réussi :
    this.route.navigate(["/play"]);
  }

  register(){

  }

}
