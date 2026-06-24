import { Component, signal, computed, inject } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { TooltipModule } from 'primeng/tooltip';
import { AuthService } from '../../../core/auth/auth';

interface MenuItem {
  label: string;
  icon: string;
  route: string;
}

@Component({
  selector: 'app-student-layout',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive, ButtonModule, TooltipModule],
  templateUrl: './student-layout.html',
  styleUrls: ['./student-layout.scss']
})
export class StudentLayoutComponent {
  private router = inject(Router);
  private authService = inject(AuthService);

  currentUser = this.authService.currentUser;
  isCollapsed = signal(false);
  sidebarWidth = computed(() => this.isCollapsed() ? '80px' : '250px');

  menuItems = signal<MenuItem[]>([
    { label: 'الرئيسية', icon: 'pi pi-home', route: '/student/dashboard' },
    { label: 'التسجيل', icon: 'pi pi-pencil', route: '/student/registration' },
    { label: 'إدارة الطلبات', icon: 'pi pi-clipboard', route: '/student/applications' },
    { label: 'الأقساط', icon: 'pi pi-credit-card', route: '/student/installments' },
    { label: 'المهام', icon: 'pi pi-check-square', route: '/student/tasks' }
  ]);

  toggleSidebar(): void {
    this.isCollapsed.update(state => !state);
  }

  logout(): void {
    this.router.navigate(['/auth/login']);
  }
}
