import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Game } from '../../data/game';
import { Transaction } from '../../data/transaction';
import { ApiService } from './api.service';
import { LibraryService } from './library.service';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  private readonly route = 'transaction';
  private cart: Record<string, Game> = {}

  constructor(private readonly apiService: ApiService) {
    console.log("New instance created");
  }

  getHistory(userId: string): Observable<Array<Transaction>> {

    return this.apiService.get(`${this.route}/history/${userId}`);
  }

  getDetails(trId: string): Observable<Transaction> {

    return this.apiService.get(`${this.route}/${trId}`);
  }

  getCart(): Array<Game> {
    let test = Object.values(this.cart);
    return Object.values(this.cart);
  }

  makePurchase(userId: string): Observable<Transaction> {

    var res: any = this.apiService.post(`${this.route}/purchase/${userId}`, { games: Object.keys(this.cart) });
    this.cart = {}
    return res;
    
  }

  isInCart(gameId: string): boolean {

    return this.cart[gameId] != null;
  }

  addToCart(game: Game): void {

    this.cart[game.id] = game
  }

  removeFromCart(gameId: string): void {

    delete this.cart[gameId];

  }
}
