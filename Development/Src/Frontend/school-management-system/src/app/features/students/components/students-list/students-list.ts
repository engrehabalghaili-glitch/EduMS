import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { TableModule, Table } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { StudentsService, Student } from '../../services/students';
import { ClassesService } from '../../../classes/services/classes';

@Component({
  selector: 'app-students-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ButtonModule, TableModule, DialogModule, InputTextModule, SelectModule],
  templateUrl: './students-list.html',
  styleUrls: ['./students-list.scss']
})
export class StudentsListComponent implements OnInit {
  private fb = inject(FormBuilder);
  private studentsService = inject(StudentsService);
  private classesService = inject(ClassesService);

  students = this.studentsService.students;
  loading = this.studentsService.loading;
  classes = this.classesService.classes;
  dialogVisible = signal(false);
  isEdit = signal(false);
  selectedId = signal<string | null>(null);

  form = this.fb.group({
    name: ['', Validators.required],
    nationalId: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
    phone: ['', [Validators.required, Validators.pattern(/^05\d{8}$/)]],
    email: ['', [Validators.email]],
    classId: ['', Validators.required],
    address: [''],
    guardianName: ['', Validators.required],
    guardianPhone: ['', [Validators.required, Validators.pattern(/^05\d{8}$/)]]
  });

  get classOptions() {
    return this.classes().map(c => ({ label: `${c.name} - ${c.gradeLevel}`, value: c.id }));
  }

  ngOnInit(): void {
    this.studentsService.getStudents().subscribe();
    this.classesService.getClasses().subscribe();
  }

  openNew(): void {
    this.isEdit.set(false);
    this.selectedId.set(null);
    this.form.reset();
    this.dialogVisible.set(true);
  }

  openEdit(student: Student): void {
    this.isEdit.set(true);
    this.selectedId.set(student.id);
    this.form.patchValue(student);
    this.dialogVisible.set(true);
  }

  save(): void {
    if (this.form.invalid) return;
    const data = this.form.value as Partial<Student>;
    const selectedClass = this.classes().find(c => c.id === data.classId);
    data.className = selectedClass?.name || '';

    if (this.isEdit() && this.selectedId()) {
      this.studentsService.updateStudent(this.selectedId()!, data).subscribe();
    } else {
      this.studentsService.createStudent(data).subscribe();
    }
    this.dialogVisible.set(false);
  }

  delete(id: string): void {
    this.studentsService.deleteStudent(id).subscribe();
  }

  onGlobalFilter(event: Event, dt: Table): void {
    dt.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

  exportExcel(dt: Table): void {
    dt.exportCSV();
  }

  exportPdf(): void {
    console.log('PDF export triggered');
  }
}
