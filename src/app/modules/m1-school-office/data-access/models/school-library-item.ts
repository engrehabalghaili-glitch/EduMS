import type { LibraryItemStatus } from './common';

export interface SchoolLibraryItem {
  id: number;
  schoolId: number;
  itemCode: string;
  titleAr: string;
  titleEn: string | null;
  authorName: string;
  publisherName: string | null;
  isbnNumber: string | null;
  category: number;
  itemStatus: LibraryItemStatus;
  totalCopiesCount: number;
  availableCopiesCount: number;
  shelfLocationCode: string | null;
  unitPurchaseCost: number;
  acquisitionDate: string | null;
}

export type CreateSchoolLibraryItemDto = Omit<SchoolLibraryItem, 'id' | 'itemStatus'>;

export type UpdateSchoolLibraryItemDto = Omit<SchoolLibraryItem, 'schoolId' | 'itemStatus'>;
