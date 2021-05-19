import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Accounts } from '../shared/models/Account';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl: string = "http://localhost:44343";
  constructor(private httpClient: HttpClient) { }
  
  getAccounts() : Observable<Accounts[]>{
    return this.httpClient.get<Accounts[]>(`${this.baseUrl}/accounts`);
  }
}
