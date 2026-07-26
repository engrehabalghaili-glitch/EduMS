export interface StudentExemplaryRecognition {
  id: number;
  studentId: number;
  academicYear: string;
  semesterNumber: number;
  recognitionTitleAr: string;
  category: number;
  awardDate: string;
  certificateNumber?: string;
  recognitionTitleEn?: string;
  awardGrantedBy?: string;
  meritBonusPoints: number;
  isFeaturedInSchoolBoard: boolean;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentExemplaryRecognition = Omit<StudentExemplaryRecognition, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStudentExemplaryRecognition = CreateStudentExemplaryRecognition & { id: number };
