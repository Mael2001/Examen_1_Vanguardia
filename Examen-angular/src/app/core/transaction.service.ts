import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Transaction } from '../shared/models/Transaction';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  baseUrl: string = "http://localhost:44343";
  constructor(private httpClient: HttpClient) { }
  
  getTransactions() : Observable<Transaction[]>{
    return this.httpClient.get<Transaction[]>(`${this.baseUrl}/transactions`);
  }

  getIncomes(): Observable<number>{
    return this.httpClient.get<number>(`${this.baseUrl}/summary/incomes`);
  }

  getExpenses(): Observable<number>{
    return this.httpClient.get<number>(`${this.baseUrl}/summary/expenses`);
  }
  
  getTotal(): Observable<number>{
    return this.httpClient.get<number>(`${this.baseUrl}/summary/total`);
  }
  addTransaction(transaction:Transaction): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(transaction);
    console.log(body)
    return this.httpClient.post(`${this.baseUrl}/new/transaction`, body,{'headers':headers})
  }
}
