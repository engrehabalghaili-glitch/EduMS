import { Component, OnInit, inject, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { SelectModule } from 'primeng/select';
import { DatePickerModule } from 'primeng/datepicker';
import { SelectButtonModule } from 'primeng/selectbutton';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { ClassesService } from '../../../classes/services/classes';
import { StudentsService, Student } from '../../../students/services/students';
import { AttendanceService, AttendanceRecord } from '../../services/attendance';

interface AttendanceRow {
  studentId: string;
  studentName: string;
  status: 'present' | 'absent' | 'late' | 'excused';
}

@Component({
  selector: 'app-attendance-list',
  standalone: true,
  imports: [CommonModule, FormsModule, ButtonModule, TableModule, SelectModule, DatePickerModule, SelectButtonModule, ToastModule],
  templateUrl: './attendance-list.html',
  styleUrls: ['./attendance-list.scss'],
  providers: [MessageService]
})
export class AttendanceListComponent implements OnInit {
  private classesService = inject(ClassesService);
  private studentsService = inject(StudentsService);
  private attendanceService = inject(AttendanceService);
  private messageService = inject(MessageService);

  classes = this.classesService.classes;
  students = this.studentsService.students;
  loading = signal(false);

  selectedClassId = signal<string | null>(null);
  selectedDate = signal<Date>(new Date());

  attendanceRows = signal<AttendanceRow[]>([]);

  classOptions = computed(() =>
    this.classes().map(c => ({ label: `${c.name} - ${c.gradeLevel}`, value: c.id }))
  );

  selectedClassName = computed(() => {
    const id = this.selectedClassId();
    const cls = this.classes().find(c => c.id === id);
    return cls ? `${cls.name} - ${cls.gradeLevel}` : '';
  });

  attendanceOptions = [
    { label: 'حاضر', value: 'present', icon: 'pi pi-check-circle' },
    { label: 'غائب', value: 'absent', icon: 'pi pi-times-circle' },
    { label: 'متأخر', value: 'late', icon: 'pi pi-clock' },
    { label: 'معذور', value: 'excused', icon: 'pi pi-question-circle' }
  ];

  ngOnInit(): void {
    this.classesService.getClasses().subscribe();
    this.studentsService.getStudents().subscribe();
  }

  onClassChange(): void {
    this.loadStudentsForClass();
  }

  onDateChange(): void {
    this.loadStudentsForClass();
  }

  private loadStudentsForClass(): void {
    const classId = this.selectedClassId();
    if (!classId) return;

    this.loading.set(true);
    const filtered = this.students().filter(s => s.classId === classId);
    const rows: AttendanceRow[] = filtered.map(s => ({
      studentId: s.id,
      studentName: s.name,
      status: 'present'
    }));
    this.attendanceRows.set(rows);
    this.loading.set(false);
  }

  saveAttendance(): void {
    const classId = this.selectedClassId();
    if (!classId) {
      this.messageService.add({ severity: 'warn', summary: '', detail: 'الرجاء اختيار الصف الدراسي' });
      return;
    }

    const date = this.selectedDate().toISOString().split('T')[0];
    const records = this.attendanceRows().map(r => ({
      studentId: r.studentId,
      status: r.status
    }));

    this.attendanceService.saveAttendance({ classId, date, records }).subscribe({
      next: () => {
        this.messageService.add({ severity: 'success', summary: '', detail: 'تم حفظ التحضير بنجاح' });
      },
      error: () => {
        this.messageService.add({ severity: 'error', summary: '', detail: 'حدث خطأ أثناء حفظ التحضير' });
      }
    });
  }

  getStatusSeverity(status: string): 'success' | 'danger' | 'warn' | 'info' {
    switch (status) {
      case 'present': return 'success';
      case 'absent': return 'danger';
      case 'late': return 'warn';
      case 'excused': return 'info';
      default: return 'info';
    }
  }
}
