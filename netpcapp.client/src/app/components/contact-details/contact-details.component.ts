import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css'],
  standalone: false
})
export class ContactDetailsComponent implements OnInit {
  contact: Contact | null = null;

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadContact(parseInt(id, 10));
    }
  }

  loadContact(id: number): void {
    this.contactService.getContactById(id).subscribe({
      next: (data) => (this.contact = data),
      error: (err) => console.error('Error loading contact:', err),
    });
  }

  editContact(): void {
    if (this.contact) {
      this.router.navigate(['/contacts', this.contact.id, 'edit']);
    }
  }

  deleteContact(): void {
    if (this.contact && confirm('Are you sure you want to delete this contact?')) {
      this.contactService.deleteContact(this.contact.id).subscribe({
        next: () => {
          alert('Contact deleted successfully');
          this.router.navigate(['/contacts']);
        },
        error: (err) => console.error('Error deleting contact:', err),
      });
    }
  }
}