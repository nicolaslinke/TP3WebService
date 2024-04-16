import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Score } from './models/score';
import { AuthInterceptor } from './auth.interceptor';

@Injectable({
  providedIn: 'root'
})
export class ScoreServiceService {

  domain : string = "https://localhost:7153/"

  constructor(public http : HttpClient, public auth: AuthInterceptor) { }

  async getMyScore() : Promise<Score[]>{
    let token = localStorage.getItem("token");
    let httpOptions = {
       headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
       })
    };

    let y = await lastValueFrom(this.http.get<Score[]>(this.domain + "api/Scores/GetMyScores", httpOptions))
    console.log(y);
    return y;
  }

  async getScore() : Promise<Score[]>{
    let token = localStorage.getItem("token");
    let httpOptions = {
       headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
       })
    };

    let x = await lastValueFrom(this.http.get<Score[]>(this.domain + "api/Scores/GetPublicScores", httpOptions))
    console.log(x);
    return x;
  }

  async changeVisibility(score : Score) : Promise<void>{
    let token = localStorage.getItem("token");
    let httpOptions = {
       headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
       })
    };

    let x = await lastValueFrom(this.http.put<Score[]>(this.domain + "api/Scores/ChangeScoreVisibility/" + score.id, score, httpOptions));
    console.log(x);
  }
}
