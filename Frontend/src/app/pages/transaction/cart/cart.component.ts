import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TransactionService } from '../../../core/services/transaction.service';
import { Game } from '../../../data/game';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  public games: Array<Game> = new Array<Game>()
  public columnsToDisplay: Array<string> = ["name", "price", "button"]

  constructor(private readonly transactionService: TransactionService,
              private readonly router: Router  ) { }

  ngOnInit() {

    this.games = this.transactionService.getCart();
  }
  removeFromCart(gameId: string) {

    this.transactionService.removeFromCart(gameId);
    this.games = this.transactionService.getCart();
  }
  //better ways to do this, like map+reduce, I'm just lazy
  computeTotal(): number {

    var total: number = 0;

    this.games.forEach((game: Game) => {
      total += game.price;
    })

    return total;
  }
  makePurchase(): void {
    this.transactionService.makePurchase(localStorage.getItem("userId")!).subscribe(
      (data: any) => this.router.navigate(['/browse'])
      .then(() => window.location.reload()));
  }
}
