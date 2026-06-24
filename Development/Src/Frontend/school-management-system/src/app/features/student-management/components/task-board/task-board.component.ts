import { Component, inject, computed, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogService, DynamicDialogModule } from 'primeng/dynamicdialog';
import { AuthService } from '../../../../core/auth/auth';
import { TaskService } from '../../services/task';
import { Task, TaskPriority, TaskStatus } from '../../models/task.model';
import { TaskFormDialogComponent } from './task-form-dialog.component';

@Component({
  selector: 'app-task-board',
  standalone: true,
  imports: [CommonModule, DynamicDialogModule],
  providers: [DialogService],
  templateUrl: './task-board.component.html',
  styleUrls: ['./task-board.component.scss']
})
export class TaskBoardComponent {
  private authService = inject(AuthService);
  private taskService = inject(TaskService);
  private dialogService = inject(DialogService);

  isEmployeeOrAdmin = computed(() => {
    const user = this.authService.currentUser();
    if (!user) return false;
    return !user.roles.includes('parent');
  });

  tasks$ = this.taskService.getTasks();
  searchQuery = signal('');
  draggedTask: Task | null = null;
  saving = signal(false);

  onSearchInput(value: string) {
    this.searchQuery.set(value);
  }

  getTasksByStatus(tasks: Task[], status: string): Task[] {
    const q = this.searchQuery().trim().toLowerCase();
    const filtered = q
      ? tasks.filter(t => t.title.includes(q) || t.id.toLowerCase().includes(q) || (t.assignee && t.assignee.includes(q)))
      : tasks;
    return filtered.filter(t => t.status === status);
  }

  onDragStart(task: Task): void {
    this.draggedTask = task;
  }

  onDragEnd(): void {
    this.draggedTask = null;
  }

  onDrop(status: string): void {
    if (!this.draggedTask) return;
    if (this.draggedTask.status === status) return;
    const updated = { ...this.draggedTask, status: status as TaskStatus };
    this.taskService.updateTask(updated).subscribe();
    this.draggedTask = null;
  }

  onDragOver(event: DragEvent): void {
    event.preventDefault();
  }

  openAddDialog(): void {
    const ref = this.dialogService.open(TaskFormDialogComponent, {
      header: 'إضافة مهمة جديدة',
      width: '420px',
      dismissableMask: true,
    });

    ref!.onClose.subscribe((result: { title: string; priority: string; dueDate: string } | undefined) => {
      if (!result) return;
      this.saving.set(true);
      this.taskService.addTask(result).subscribe({
        next: () => this.saving.set(false),
        error: () => this.saving.set(false),
      });
    });
  }

  getPriorityLabel(p: TaskPriority): string {
    switch (p) { case 'high': return 'عالية'; case 'medium': return 'متوسطة'; case 'low': return 'منخفضة'; }
  }

  getPriorityClass(p: TaskPriority): string {
    switch (p) { case 'high': return 'p-high'; case 'medium': return 'p-medium'; case 'low': return 'p-low'; }
  }

  getColumnTitle(s: string): string {
    const map: Record<string, string> = { 'in-progress': 'قيد التنفيذ', 'on-hold': 'مُعلق', 'completed': 'مكتمل' }; return map[s] || '';
  }

  getColumnCount(tasks: Task[], s: string): number {
    return tasks.filter(t => t.status === s).length;
  }

  getColumnIcon(s: string): string {
    const map: Record<string, string> = { 'in-progress': 'pi pi-spinner', 'on-hold': 'pi pi-pause-circle', 'completed': 'pi pi-check-circle' }; return map[s] || '';
  }
}
