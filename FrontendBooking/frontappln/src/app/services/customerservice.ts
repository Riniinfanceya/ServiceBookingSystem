import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// ✅ Export interface
export interface Customer {
  customerId: number;
  name: string;
  email: string;
  phone: string;
}

// ✅ Injectable service
@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = 'https://localhost:7207/api/Customers';

  constructor(private http: HttpClient) {}

  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrl);
  }

  addCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.apiUrl, customer);
  }
}
