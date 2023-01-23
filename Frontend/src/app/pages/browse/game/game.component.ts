import { Component } from '@angular/core';
import { GameService } from '../../../core/services/game.service';
import { Game } from '../../../data/game';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent {
  public games?: Array<Game>
  public columnsToDisplay : Array<string> = ["name","dev","price","button"]

  constructor(private readonly gameService: GameService) { }

  ngOnInit(): void {
    this.gameService.getAllGames().subscribe((data: Array<Game>) => this.games = data);
  }
}
