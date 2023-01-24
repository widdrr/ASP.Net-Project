import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Transaction } from '../../data/transaction';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  private readonly route = 'transaction';

  constructor(private readonly apiService: ApiService) { }

  getHistory(userId: string): Observable<Array<Transaction>> {

    return this.apiService.get(`${this.route}/history/${userId}`);
  }

  getDetails(trId: string): Observable<Transaction> {

    return this.apiService.get(`${this.route}/${trId}`);
  }
}
