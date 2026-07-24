import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core';
import { Observable } from 'rxjs';

/**
 * كلاس الخدمة الأساسي (Base API Service)
 * هذا الكلاس هو العقل المركزي (Generic Repository) الذي ستتوارث منه جميع خدمات الواجهة الأمامية.
 * يهدف هذا الكلاس إلى منع تكرار كود الاتصال بالخادم (HTTP Requests) لجميع الجداول.
 * 
 * @template T - نوع البيانات الأساسي المرجع من الباك إند (مثلاً: School)
 * @template TCreate - نوع البيانات المرسل عند الإنشاء (مثلاً: CreateSchoolPayload)
 * @template TUpdate - نوع البيانات المرسل عند التعديل (مثلاً: UpdateSchoolPayload)
 */
export abstract class BaseApiService<T, TCreate = T, TUpdate = T> {
  // استخدام دالة inject() بدلاً من Constructor Injection لتقليل الكود حسب معايير Angular الحديثة
  protected http = inject(HttpClient);
  
  /**
   * الرابط الأساسي للـ API (Base URL)
   * يجب على كل خدمة فرعية ترث من هذا الكلاس أن تقوم بإعطاء قيمة (Override) لهذه الخاصية.
   * مثال: return '/api/v1/Schools';
   */
  protected abstract get baseUrl(): string;

  /**
   * جلب جميع السجلات من الخادم
   * @returns Observable يحتوي على مصفوفة من النوع الأساسي T
   */
  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.baseUrl);
  }

  /**
   * جلب سجل واحد بناءً على المعرف (ID)
   * @param id المعرف الفريد للسجل
   * @returns Observable يحتوي على السجل المطلوب من النوع T
   */
  getById(id: number | string): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${id}`);
  }

  /**
   * إنشاء سجل جديد في الخادم
   * @param payload البيانات المرسلة للإنشاء (تطابق الـ Interface الخاص بالإنشاء)
   * @returns Observable يحتوي على السجل بعد إنشائه في الخادم
   */
  create(payload: TCreate): Observable<T> {
    return this.http.post<T>(this.baseUrl, payload);
  }

  /**
   * تعديل سجل موجود في الخادم
   * @param id المعرف الفريد للسجل المراد تعديله
   * @param payload البيانات المرسلة للتعديل
   */
  update(id: number | string, payload: TUpdate): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, payload);
  }

  /**
   * حذف سجل موجود في الخادم
   * @param id المعرف الفريد للسجل المراد حذفه
   */
  delete(id: number | string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
