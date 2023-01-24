import { Component, OnInit } from '@angular/core';
import { map, tap } from 'rxjs';
import { TransactionService } from '../../../core/services/transaction.service';
import { Transaction } from '../../../data/transaction';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  public transactions?: Array<Transaction>
  public columnsToDisplay: Array<string> = ["date", "sum"]
  
  constructor(private readonly transactionService: TransactionService) {}

  ngOnInit(): void {

    this.transactionService.getHistory(localStorage.getItem("userId")!)
      .subscribe((data: Array<Transaction>) => this.transactions = data);

  }

  computeTotal() : number {
    var total: number = 0;

    this.transactions!.forEach((transact: Transaction) => {
      if (transact.type == "Deposit")
        total += transact.sum;
      else
        total -= transact.sum;
    })

    return total;
  }
}
