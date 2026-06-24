import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ParentData {
  firstName: string;
  fatherName: string;
  grandfatherName: string;
  familyName: string;
  idNumber: string;
  phone: string;
  email: string;
  relation: string;
}

export interface StudentBasicData {
  fullName: string;
  birthDate: string;
  gender: string;
  grade: string;
}

export interface StudentFullData {
  firstName: string;
  fatherName: string;
  grandfatherName: string;
  familyName: string;
  idNumber: string;
  birthDate: Date | undefined;
  gender: string;
  nationality: string;
  address: string;
  phone: string;
  email: string;
  grade: string;
  department: string;
  academicYear: string;
  bloodType: string;
  allergies: string;
  chronicDiseases: string;
}

export interface UploadedDoc {
  id: string;
  label: string;
  files: File[];
  accepted: boolean;
}

export interface RegistrationData {
  parent: ParentData;
  studentBasic: StudentBasicData;
  studentFull: StudentFullData;
  documents: UploadedDoc[];
}

@Injectable({ providedIn: 'root' })
export class RegistrationService {
  private http = inject(HttpClient);

  private data = signal<RegistrationData>({
    parent: { firstName: '', fatherName: '', grandfatherName: '', familyName: '', idNumber: '', phone: '', email: '', relation: '' },
    studentBasic: { fullName: '', birthDate: '', gender: '', grade: '' },
    studentFull: { firstName: '', fatherName: '', grandfatherName: '', familyName: '', idNumber: '', birthDate: undefined, gender: '', nationality: '', address: '', phone: '', email: '', grade: '', department: '', academicYear: '', bloodType: '', allergies: '', chronicDiseases: '' },
    documents: [],
  });

  readonly formData = this.data.asReadonly();

  saveData(): Observable<any> {
    return this.http.post('/api/v1/registration', this.data());
  }

  updateParent(value: Partial<ParentData>): void {
    this.data.update(d => ({ ...d, parent: { ...d.parent, ...value } }));
  }

  updateStudentBasic(value: Partial<StudentBasicData>): void {
    this.data.update(d => ({ ...d, studentBasic: { ...d.studentBasic, ...value } }));
  }

  updateStudentFull(value: Partial<StudentFullData>): void {
    this.data.update(d => ({ ...d, studentFull: { ...d.studentFull, ...value } }));
  }

  addDocument(doc: UploadedDoc): void {
    this.data.update(d => {
      const existing = d.documents.findIndex(x => x.id === doc.id);
      if (existing >= 0) {
        const updated = [...d.documents];
        updated[existing] = doc;
        return { ...d, documents: updated };
      }
      return { ...d, documents: [...d.documents, doc] };
    });
  }

  removeDocument(docId: string): void {
    this.data.update(d => ({ ...d, documents: d.documents.filter(x => x.id !== docId) }));
  }

  validateStep(step: number): boolean {
    const d = this.data();
    if (step === 0) {
      return !!(
        d.parent.firstName && d.parent.fatherName && d.parent.idNumber &&
        d.parent.phone && d.parent.email && d.parent.relation &&
        d.studentBasic.fullName && d.studentBasic.birthDate &&
        d.studentBasic.gender && d.studentBasic.grade
      );
    }
    if (step === 1) {
      return !!(
        d.studentFull.firstName && d.studentFull.fatherName && d.studentFull.familyName &&
        d.studentFull.idNumber && d.studentFull.gender && d.studentFull.grade
      );
    }
    return true;
  }

  resetAll(): void {
    this.data.set({
      parent: { firstName: '', fatherName: '', grandfatherName: '', familyName: '', idNumber: '', phone: '', email: '', relation: '' },
      studentBasic: { fullName: '', birthDate: '', gender: '', grade: '' },
      studentFull: { firstName: '', fatherName: '', grandfatherName: '', familyName: '', idNumber: '', birthDate: undefined, gender: '', nationality: '', address: '', phone: '', email: '', grade: '', department: '', academicYear: '', bloodType: '', allergies: '', chronicDiseases: '' },
      documents: [],
    });
  }
}
