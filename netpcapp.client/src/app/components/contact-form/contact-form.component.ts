import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact';


@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css'],
  standalone: false
})
export class ContactFormComponent implements OnInit {
  contact: Contact = this.initializeContact();
  isEditMode: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.loadContact(parseInt(id, 10));
    }
  }

  initializeContact(): Contact {
    return {
      id: 0,
      firstName: '',
      lastName: '',
      email: '',
      phone: '',
      category: 'Personal',
      subcategory: '',
      phoneNumber: '',
      birthDate: new Date(),
      password: ''
      //password: '',
    };
  }

  loadContact(id: number): void {
    this.contactService.getContactById(id).subscribe({
      next: (data) => (this.contact = data),
      error: (err) => console.error('Error loading contact:', err),
    });
  }

  onCategoryChange(): void {
    if (this.contact.category !== 'Other') {
      this.contact.subcategory = '';
    }
    if (this.contact.category !== 'Business') {
      this.contact.subcategory = '';
    }
  }

  onSubmit(): void {
    if (this.isEditMode) {
      this.contactService.updateContact(this.contact.id, this.contact).subscribe({
        next: () => {
          alert('Contact updated successfully');
          this.router.navigate(['/contacts']);
        },
        error: (err) => console.error('Error updating contact:', err),
      });
    } else {
      this.contactService.addContact(this.contact).subscribe({
        next: () => {
          alert('Contact added successfully');
          this.router.navigate(['/contacts']);
        },
        error: (err) => console.error('Error adding contact:', err),
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/contacts']);
  }
}