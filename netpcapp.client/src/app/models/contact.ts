export interface Contact {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  category: string;
  subcategory?: string;
  phone: string;
  birthDate: Date;
  password: string;
}