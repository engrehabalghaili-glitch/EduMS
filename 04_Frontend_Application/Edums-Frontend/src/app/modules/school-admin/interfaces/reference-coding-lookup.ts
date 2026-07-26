export interface ReferenceCodingLookup {
  id: number;
  schoolId: number | null;
  codeType: string;
  codeKey: string;
  codeValueAr: string;
  codeValueEn: string | null;
  descriptionAr: string | null;
  descriptionEn: string | null;
  sortOrder: number;
  isSystemCode: boolean;
  isActive: boolean;
  parentCodeId: number | null;
  notes: string | null;
}

export type CreateReferenceCodingLookupDto = Omit<ReferenceCodingLookup, 'id' | 'isActive'>;

export type UpdateReferenceCodingLookupDto = Omit<ReferenceCodingLookup, 'isActive'>;
