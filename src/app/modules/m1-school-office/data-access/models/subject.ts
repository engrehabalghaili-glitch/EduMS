export interface Subject {
  id: number;
  schoolId: number;
  subjectCode: string;
  subjectNameAr: string;
  subjectNameEn: string;
  specialization: string | null;
  weeklyHours: number;
  gradeLevel: number;
  textbookTitle: string | null;
  totalMarks: number;
  passingMarks: number;
  creditHours: number;
  isCoreSubject: boolean;
  isActive: boolean;
}

export type CreateSubjectDto = Omit<Subject, 'id' | 'isActive'>;

export type UpdateSubjectDto = Omit<Subject, 'schoolId' | 'isActive'>;
