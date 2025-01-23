import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactDetailsComponent } from './components/contact-details/contact-details.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { ContactFormComponent } from './components/contact-form/contact-form.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './components/login/login.component'
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './Interceptor/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    ContactDetailsComponent,
    ContactFormComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    LoginComponent,
    CommonModule,
    FormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
