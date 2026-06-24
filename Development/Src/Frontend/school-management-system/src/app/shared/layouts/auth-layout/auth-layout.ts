import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-auth-layout',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './auth-layout.html',
  styleUrls: ['./auth-layout.scss']
})
export class AuthLayoutComponent {
  // ميزات المنصة الاستراتيجية المعروضة في جانب التسويق البصري (Aside)
  marketingFeatures = [
    {
      icon: 'pi pi-graduation-cap',
      title: 'إدارة طلابية شاملة',
      desc: 'من التسجيل حتى التخرج، 112 سيناريو دقيق لإدارة القبول والملفات.'
    },
    {
      icon: 'pi pi-shield',
      title: 'صلاحيات متقدمة (RBAC)',
      desc: 'تحكم دقيق بالأدوار والصلاحيات لكل مستخدم لضمان أمن البيانات.'
    },
    {
      icon: 'pi pi-chart-bar',
      title: 'تقارير وإحصائيات ذكية',
      desc: 'مؤشرات أداء فورية لمراقبة طلبات التسجيل ونسب القبول لحظة بلحظة.'
    },
    {
      icon: 'pi pi-desktop',
      title: 'متعدد الأجهزة والأنظمة',
      desc: 'واجهة متجاوبة بالكامل تعمل على الويب والجوال بكفاءة استثنائية.'
    }
  ];
}
