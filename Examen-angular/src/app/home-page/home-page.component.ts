import { Component, OnInit } from '@angular/core';
import { TransactionService } from '../core/transaction.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  incomes: number = 1000000000000000;
  expenses: number= -69999999999999;
  total: number = this.incomes + this.expenses;
  constructor(private transactionService: TransactionService) { }

  ngOnInit(): void {
    //Incomes
    this.transactionService.getIncomes()
      .subscribe((data: number) => {
        this.incomes = data;
      }, error => {
        console.log(`${error.message}`)
      }
      );
    //Expenses
    this.transactionService.getExpenses()
      .subscribe((data: number) => {
        this.expenses = data;
      }, error => {
        console.log(`${error.message}`)
      }
      );
    //Total
    this.transactionService.getTotal()
      .subscribe((data: number) => {
        this.total = data;
      }, error => {
        console.log(`${error.message}`)
      }
      );
  }

}
