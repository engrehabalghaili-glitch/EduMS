import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CreatePersonComponent } from './features/M2_StudentAffairs/components/create-person/create-person.component';
import { AcademicLockComponent } from './features/M1_SchoolAdmin/components/academic-lock/academic-lock.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CreatePersonComponent, AcademicLockComponent],
  template: `
    <header style="background: #1e293b; color: #fff; padding: 1rem; text-align: center;">
      <h1>EduMS - نظام إدارة الموارد التعليمية الموحد</h1>
    </header>
    <main style="padding: 2rem;">
      <app-create-person></app-create-person>
      <app-academic-lock></app-academic-lock>
      <router-outlet></router-outlet>
    </main>
  `
})
export class AppComponent {}
