import { Component, OnInit } from '@angular/core';
import { Score } from '../models/score';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { ScoreServiceService } from '../score-service.service';

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

  constructor(public http : HttpClient, public service : ScoreServiceService) { }

  async ngOnInit() {

    this.userIsConnected = localStorage.getItem("token") != null;

    this.publicScores = await this.service.getScore();

    if (this.userIsConnected) {
      this.myScores = await this.service.getMyScore();
    }
  }

  async changeScoreVisibility(score : Score){
    let token = localStorage.getItem("token");

    if (this.userIsConnected) {
      this.service.changeVisibility(score);
      window.location.reload();
    }
  }
}
