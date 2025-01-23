import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'https://localhost:7222/api/auth';

  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<any> {
    return this.http.post('https://localhost:7222/api/auth/login', {email, password}).pipe(
      tap((response: any) => {
        localStorage.setItem('authToken', response.token); 
      })
    );
  }

  register(email: string, password: string, firstName: string, lastName: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, {
      email,
      password,
      firstName,
      lastName,
    });
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('token');
  }
}
