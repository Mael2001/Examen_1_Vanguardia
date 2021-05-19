import { Component, OnInit } from '@angular/core';
import { TransactionService } from '../core/transaction.service';
import { Transaction } from '../shared/models/Transaction';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css']
})
export class TransactionListComponent implements OnInit {

  transactions: Transaction[] = [{
    AccountId: 1,
    Amount: 1233,
    Description: "Pago 1",
    TransactionDate: new Date()
  },
  {
    AccountId: 2,
    Amount: 699,
    Description: "Pago 2",
    TransactionDate: new Date()
  },
  {
    AccountId: 1,
    Amount: -123,
    Description: "Pago 3",
    TransactionDate: new Date()
  },
  {
    AccountId: 1,
    Amount: -500,
    Description: "Pago 4",
    TransactionDate: new Date()
  },
  {
    AccountId: 1,
    Amount:  99999,
    Description: "Pago 5",
    TransactionDate: new Date()
  }
];
  constructor(private transactionService: TransactionService) { }

  ngOnInit(): void {
    this.transactionService.getTransactions()
      .subscribe((data: Transaction[]) => {
        this.transactions = data;
      }, error => {
        console.log(`${error.message}`)
      });
  }

}
