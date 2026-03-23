import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'https://localhost:7207/api/Auth/login';

  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(this.apiUrl, { email, password });
  }
}
