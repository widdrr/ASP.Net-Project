import { Component } from '@angular/core';
import { GameService } from '../../../core/services/game.service';
import { TransactionService } from '../../../core/services/transaction.service';
import { Game } from '../../../data/game';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent {
  public games?: Array<Game>
  public columnsToDisplay : Array<string> = ["name","dev","date","price","button"]

  constructor(private readonly gameService: GameService,
              private readonly transactionService: TransactionService  ) { }

  ngOnInit(): void {
    this.gameService.getAllGames().subscribe((data: Array<Game>) => this.games = data);
  }

  addToCart(game: Game, event: MouseEvent): void {

    this.transactionService.addToCart(game);
    (event.target as HTMLButtonElement).disabled = true;
    (event.target as HTMLButtonElement).innerHTML = "IN CART";
  }
}
