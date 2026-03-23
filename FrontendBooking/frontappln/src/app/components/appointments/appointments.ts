import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-appointments',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './appointments.html',
  styleUrls: ['./appointments.css']
})
export class AppointmentsComponent {
  serviceId: number = 0;
  staffId: number = 0;
  startTime: string = '';
  endTime: string = '';

  constructor(private http: HttpClient) {}

  bookAppointment() {
  const customerId = Number(localStorage.getItem('customerId')); // 👈 from login

  const appointment = {
    customerId: customerId,
    staffId: this.staffId,
    serviceId: this.serviceId,
    startTime: this.startTime,
    endTime: this.endTime,
    status: 'Booked',
    isActive: true
  };

  this.http.post('https://localhost:7207/api/appointments', appointment)
    .subscribe({
      next: () => alert('Appointment booked!'),
      error: (err: HttpErrorResponse) => alert('Booking failed: ' + err.message)
    });
}


}
