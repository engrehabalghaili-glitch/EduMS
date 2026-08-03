import { patchState, signalStore, withMethods, withState, withComputed } from '@ngrx/signals';
import { computed } from '@angular/core';

// 1. واجهة الحالة (State Interface)
interface AuthState {
  token: string | null;
}

// 2. الحالة الابتدائية (Initial State)
const initialState: AuthState = {
  token: localStorage.getItem('edums_token') // محاولة قراءة التوكن المحفوظ مسبقاً
};

// 3. إنشاء مخزن الحالة (Signal Store)
export const AuthStore = signalStore(
  { providedIn: 'root' }, // لجعله متوفراً على مستوى التطبيق بالكامل
  
  // دمج الحالة الابتدائية
  withState(initialState),
  
  // الدوال الحسابية (Computed properties)
  withComputed(({ token }) => ({
    isLoggedIn: computed(() => !!token()) // إذا كان هناك توكن، فالمستخدم مسجل الدخول
  })),
  
  // العمليات والدوال لتعديل الحالة (Methods)
  withMethods((store) => ({
    setToken(token: string) {
      localStorage.setItem('edums_token', token);
      patchState(store, { token });
    },
    clearAuth() {
      localStorage.removeItem('edums_token');
      patchState(store, { token: null });
    }
  }))
);
