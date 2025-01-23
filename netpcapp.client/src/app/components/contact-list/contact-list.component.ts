import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css'],
  standalone: false
})
export class ContactListComponent implements OnInit {
  contacts: Contact[] = [];

  constructor(private contactService: ContactService, private router: Router) {}

  ngOnInit(): void {
    this.loadContacts();
  }

  loadContacts(): void {
    this.contactService.getContacts().subscribe({
      next: (data) => (this.contacts = data),
      error: (err) => console.error('Error loading contacts:', err),
    });
  }

  selectContact(contact: Contact): void {
    this.router.navigate(['/contacts', contact.id]);
  }

  addContact(): void {
    this.router.navigate(['/contacts/new']);
  }
}