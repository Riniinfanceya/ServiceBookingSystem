import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService) {}

  login() {
  this.authService.login(this.email, this.password).subscribe({
    next: (res: any) => {   // 👈 res is any, so TS won’t complain
      localStorage.setItem('token', res.token);
      localStorage.setItem('customerId', res.customerId); // safe now
      alert('Login successful!');
    },
    error: (err: HttpErrorResponse) => alert('Login failed: ' + err.message)
  });
}


}
