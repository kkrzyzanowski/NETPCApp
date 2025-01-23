import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { AuthGuard } from './auth.guard';
import { ContactFormComponent } from './components/contact-form/contact-form.component';
import { ContactDetailsComponent } from './components/contact-details/contact-details.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'contacts', component: ContactListComponent, canActivate: [AuthGuard] },
  { path: 'contacts/new', component: ContactFormComponent },
  { path: 'contacts/:id', component: ContactDetailsComponent },
  { path: 'contacts/:id/edit', component: ContactFormComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
