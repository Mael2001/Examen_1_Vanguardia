import { Component, OnInit } from '@angular/core';
import { AccountService } from '../core/account.service';
import { Accounts } from '../shared/models/Account';

@Component({
  selector: 'app-account-list',
  templateUrl: './account-list.component.html',
  styleUrls: ['./account-list.component.css']
})
export class AccountListComponent implements OnInit {

  accounts: Accounts[] = [{
    Amount: 10000,
    Name: "Account 1"
  }, {
    Amount: 20000,
    Name: "Account 2"
  }, {
    Amount: 30000,
    Name: "Account 3"
  }, {
    Amount: 40000,
    Name: "Account 4"
  }, {
    Amount: 50000,
    Name: "Account 5"
  }
  ];

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.accountService.getAccounts()
      .subscribe((data: Accounts[]) => {
        this.accounts = data;
      }, error => {
        console.log(`${error.message}`)
      }
      );

  }

}
