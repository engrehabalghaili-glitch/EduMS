import { Component, OnInit, inject, signal, viewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { TableModule, Table } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { TeachersService, Teacher } from '../../services/teachers';

@Component({
  selector: 'app-teachers-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ButtonModule, TableModule, DialogModule, InputTextModule, SelectModule],
  templateUrl: './teachers-list.html',
  styleUrls: ['./teachers-list.scss']
})
export class TeachersListComponent implements OnInit {
  private fb = inject(FormBuilder);
  private teachersService = inject(TeachersService);

  teachers = this.teachersService.teachers;
  loading = this.teachersService.loading;
  dialogVisible = signal(false);
  isEdit = signal(false);
  selectedId = signal<string | null>(null);

  specializationOptions = [
    { label: 'رياضيات', value: 'رياضيات' },
    { label: 'فيزياء', value: 'فيزياء' },
    { label: 'كيمياء', value: 'كيمياء' },
    { label: 'أحياء', value: 'أحياء' },
    { label: 'لغة عربية', value: 'لغة عربية' },
    { label: 'لغة إنجليزية', value: 'لغة إنجليزية' },
    { label: 'علوم حاسب', value: 'علوم حاسب' },
    { label: 'تربية اسلامية', value: 'تربية اسلامية' },
    { label: 'اجتماعيات', value: 'اجتماعيات' }
  ];

  qualificationOptions = [
    { label: 'بكالوريوس', value: 'بكالوريوس' },
    { label: 'ماجستير', value: 'ماجستير' },
    { label: 'دكتوراه', value: 'دكتوراه' },
    { label: 'دبلوم', value: 'دبلوم' }
  ];

  form = this.fb.group({
    name: ['', Validators.required],
    nationalId: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
    phone: ['', [Validators.required, Validators.pattern(/^05\d{8}$/)]],
    email: ['', [Validators.required, Validators.email]],
    specialization: ['', Validators.required],
    qualification: ['', Validators.required]
  });

  ngOnInit(): void {
    this.teachersService.getTeachers().subscribe();
  }

  openNew(): void {
    this.isEdit.set(false);
    this.selectedId.set(null);
    this.form.reset();
    this.dialogVisible.set(true);
  }

  openEdit(teacher: Teacher): void {
    this.isEdit.set(true);
    this.selectedId.set(teacher.id);
    this.form.patchValue(teacher);
    this.dialogVisible.set(true);
  }

  save(): void {
    if (this.form.invalid) return;
    const data = this.form.value as Partial<Teacher>;
    if (this.isEdit() && this.selectedId()) {
      this.teachersService.updateTeacher(this.selectedId()!, data).subscribe();
    } else {
      this.teachersService.createTeacher(data).subscribe();
    }
    this.dialogVisible.set(false);
  }

  delete(id: string): void {
    this.teachersService.deleteTeacher(id).subscribe();
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
