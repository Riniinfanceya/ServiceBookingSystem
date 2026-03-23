import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerService, Customer } from '../../services/customerservice';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.css']
})
export class DashboardComponent implements OnInit {
  customers: Customer[] = [];
  appointments: any[] = [];

  constructor(private customerService: CustomerService, private http: HttpClient) {}

  ngOnInit(): void {
    this.loadCustomers();
    this.loadAppointments();
  }

  loadCustomers() {
    this.customerService.getCustomers().subscribe({
      next: (data: Customer[]) => this.customers = data,
      error: (err: HttpErrorResponse) => console.error('Error fetching customers', err)
    });
  }

  loadAppointments() {
    this.http.get<any[]>('https://localhost:7207/api/appointments').subscribe({
      next: (data: any[]) => this.appointments = data,
      error: (err: HttpErrorResponse) => console.error('Error fetching appointments', err)
    });
  }
}
