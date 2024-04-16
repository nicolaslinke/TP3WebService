import { Component, OnInit } from '@angular/core';
import { Score } from '../models/score';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.css']
})
export class ScoreComponent implements OnInit {

  domain : string = "https://localhost:7153/"

  myScores : Score[] = [];
  publicScores : Score[] = [];
  userIsConnected : boolean = false;

  constructor(public http : HttpClient) { }

  async ngOnInit() {

    this.userIsConnected = localStorage.getItem("token") != null;

    let token = localStorage.getItem("token");
    let httpOptions = {
       headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
       })
    };

    let x = await lastValueFrom(this.http.get<Score[]>(this.domain + "api/Scores/GetPublicScores", httpOptions))
    console.log(x);
    this.publicScores = x;

    if (this.userIsConnected) {
      let y = await lastValueFrom(this.http.get<Score[]>(this.domain + "api/Scores/GetMyScores", httpOptions))
      console.log(y);
      this.myScores = y;
    }
  }

  async changeScoreVisibility(score : Score){
    let token = localStorage.getItem("token");

    let httpOptions = {
       headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
       })
    };

    if (this.userIsConnected) {
      let x = await lastValueFrom(this.http.put<Score[]>(this.domain + "api/Scores/ChangeScoreVisibility/" + score.id, score, httpOptions));
      console.log(x);

      window.location.reload();
    }

  }

}
