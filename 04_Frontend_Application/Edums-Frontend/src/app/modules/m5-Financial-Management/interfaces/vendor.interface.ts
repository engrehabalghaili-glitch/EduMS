import { AuditFields } from './common.types';

export interface Vendor extends AuditFields {
  id: number;
  vendorName: string;
  taxNumber: string | null;
  contactName: string | null;
  contactEmail: string | null;
  contactPhone: string | null;
  isActive: boolean;
}

export type CreateVendorDto = Omit<Vendor, 'id' | 'createdAt'>;

export type UpdateVendorDto = Omit<Vendor, 'createdAt'>;
