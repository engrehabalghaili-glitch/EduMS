import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { TableModule, Table } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { SelectModule } from 'primeng/select';
import { ClassesService, Class } from '../../services/classes';
import { TeachersService, Teacher } from '../../../teachers/services/teachers';

@Component({
  selector: 'app-classes-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ButtonModule, TableModule, DialogModule, InputTextModule, InputNumberModule, SelectModule],
  templateUrl: './classes-list.html',
  styleUrls: ['./classes-list.scss']
})
export class ClassesListComponent implements OnInit {
  private fb = inject(FormBuilder);
  private classesService = inject(ClassesService);
  private teachersService = inject(TeachersService);

  classes = this.classesService.classes;
  loading = this.classesService.loading;
  teachers = this.teachersService.teachers;
  dialogVisible = signal(false);
  isEdit = signal(false);
  selectedId = signal<string | null>(null);

  gradeLevelOptions = [
    { label: 'أول ابتدائي', value: 'أول ابتدائي' },
    { label: 'ثاني ابتدائي', value: 'ثاني ابتدائي' },
    { label: 'ثالث ابتدائي', value: 'ثالث ابتدائي' },
    { label: 'رابع ابتدائي', value: 'رابع ابتدائي' },
    { label: 'خامس ابتدائي', value: 'خامس ابتدائي' },
    { label: 'سادس ابتدائي', value: 'سادس ابتدائي' },
    { label: 'أول متوسط', value: 'أول متوسط' },
    { label: 'ثاني متوسط', value: 'ثاني متوسط' },
    { label: 'ثالث متوسط', value: 'ثالث متوسط' },
    { label: 'أول ثانوي', value: 'أول ثانوي' },
    { label: 'ثاني ثانوي', value: 'ثاني ثانوي' },
    { label: 'ثالث ثانوي', value: 'ثالث ثانوي' }
  ];

  form = this.fb.group({
    name: ['', Validators.required],
    gradeLevel: ['', Validators.required],
    homeroomTeacherId: ['', Validators.required],
    capacity: [0, [Validators.required, Validators.min(1)]],
    roomNumber: ['', Validators.required]
  });

  get teacherOptions() {
    return this.teachers().map(t => ({ label: t.name, value: t.id }));
  }

  ngOnInit(): void {
    this.classesService.getClasses().subscribe();
    this.teachersService.getTeachers().subscribe();
  }

  openNew(): void {
    this.isEdit.set(false);
    this.selectedId.set(null);
    this.form.reset({ capacity: 0 });
    this.dialogVisible.set(true);
  }

  openEdit(cls: Class): void {
    this.isEdit.set(true);
    this.selectedId.set(cls.id);
    this.form.patchValue(cls);
    this.dialogVisible.set(true);
  }

  save(): void {
    if (this.form.invalid) return;
    const data = this.form.value as Partial<Class>;
    const selectedTeacher = this.teachers().find(t => t.id === data.homeroomTeacherId);
    data.homeroomTeacherName = selectedTeacher?.name || '';

    if (this.isEdit() && this.selectedId()) {
      this.classesService.updateClass(this.selectedId()!, data).subscribe();
    } else {
      this.classesService.createClass(data).subscribe();
    }
    this.dialogVisible.set(false);
  }

  delete(id: string): void {
    this.classesService.deleteClass(id).subscribe();
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
