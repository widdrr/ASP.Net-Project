import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Game } from './data/game'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public games?: Game[];

  constructor(http: HttpClient) {
    http.get<Game[]>('/api/game').subscribe(result => {
      this.games = result;
    }, error => console.error(error));
  }

  title = 'Frontend';
}
