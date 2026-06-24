export type TaskPriority = 'high' | 'medium' | 'low';
export type TaskStatus = 'in-progress' | 'on-hold' | 'completed';

export interface Task {
  id: string;
  title: string;
  description?: string;
  priority: TaskPriority;
  dueDate: string;
  status: TaskStatus;
  assignee?: string;
}
