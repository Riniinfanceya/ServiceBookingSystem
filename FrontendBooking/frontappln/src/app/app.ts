import { Component, signal } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  template: `
    <nav>
      <a routerLink="/login">Login</a> |
      <a routerLink="/register">Register</a> |
      <a routerLink="/appointments">Appointments</a> |
      <a routerLink="/dashboard">Dashboard</a>
    </nav>
    <router-outlet></router-outlet>
  `,
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('frontappln');
}
