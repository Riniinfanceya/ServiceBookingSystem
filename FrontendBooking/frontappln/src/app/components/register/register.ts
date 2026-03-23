import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CustomerService, Customer } from '../../services/customerservice';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './register.html',
  styleUrls: ['./register.css']
})
export class RegisterComponent {
  customer: Customer = { customerId: 0, name: '', email: '', phone: '' };

  constructor(private customerService: CustomerService) {}

  register() {
    this.customerService.addCustomer(this.customer).subscribe({
      next: () => alert('Registration successful!'),
      error: (err: HttpErrorResponse) => alert('Registration failed: ' + err.message)
    });
  }
}
