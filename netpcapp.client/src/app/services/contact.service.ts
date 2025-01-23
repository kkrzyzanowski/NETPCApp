import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact';



@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private apiUrl = 'https://localhost:7222/api/contacts';

  constructor(private http: HttpClient) {}

  getContacts(): Observable<Contact[]> {
    const headers = this.createAuthHeaders();
    return this.http.get<Contact[]>(this.apiUrl, {headers});
  }

  getContactById(id: number): Observable<Contact> {
    return this.http.get<Contact>(`${this.apiUrl}/${id}`);
  }

  addContact(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(this.apiUrl, contact);
  }

  updateContact(id: number, contact: Contact): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, contact);
  }

  deleteContact(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  private createAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('authToken'); // Pobierz token z localStorage
    if (!token) {
      throw new Error('No authentication token found. Please log in.');
    }
    return new HttpHeaders({
      Authorization: `Bearer ${token}`, // Dodanie tokenu do nagłówka Authorization
    });
  }
}

