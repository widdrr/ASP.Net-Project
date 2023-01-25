import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TransactionService } from '../../../core/services/transaction.service';
import { Transaction } from '../../../data/transaction';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit{

  public transactionId: string = "";
  public transaction?: Transaction;
  public columnsToDisplay = ["name","price"];

  constructor(private readonly route: ActivatedRoute,
              private readonly transactionService: TransactionService) { }

  ngOnInit() {
    this.transactionId = this.route.snapshot.params["trId"];
    this.transactionService.getDetails(this.transactionId).subscribe(
      (data: Transaction) => this.transaction = data);
  }
}
