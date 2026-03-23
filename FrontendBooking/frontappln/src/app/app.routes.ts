import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login';
import { RegisterComponent } from './components/register/register';
import { AppointmentsComponent } from './components/appointments/appointments';
import { DashboardComponent } from './components/dashboard/dashboard';
import { AuthGuard } from './guards/auth-guard';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'appointments', component: AppointmentsComponent },
  { path: 'dashboard', component: DashboardComponent},
  { path: '', redirectTo: 'login', pathMatch: 'full' }
];
