# الدليل الشامل لمعمارية الواجهات الأمامية (Frontend Master Architecture Guide)

يُعتبر هذا الملف هو **المرجع النهائي والشامل** الذي يُلخص كل القرارات المعمارية وأفضل الممارسات التي تم الاتفاق عليها لمشروع نظام إدارة المدارس (EduMS). تم تصميم هذه الهيكلية لضمان أداء فائق، عزل كامل لبيئات العمل، وسهولة تامة في الصيانة والتوسع المستقبلي والربط مع الباك إند.

---

## 1. المعمارية المعتمدة: Enterprise DDD Monolith

الهيكلية الأساسية للمشروع تعتمد على مبادئ "التصميم الموجه بالمجال" (Domain-Driven Design). حيث نقوم بتقسيم المشروع بناءً على **الأقسام الإدارية والعمليات**، وليس بناءً على جداول قاعدة البيانات.

### 1.1 الهيكل العام للمشروع
```text
src/
├── app/
│   ├── core/                  # (البنية التحتية) Interceptors, Guards, API Interfaces, Auth
│   ├── shared/                # (المكونات المشتركة) UI Components, Pipes, Directives
│   └── modules/               # (الأقسام الرئيسية - Bounded Contexts)
│       │
│       ├── school-office/     
│       │   ├── schools/       # (عملية/شاشة محددة)
│       │   │   ├── feature/   # المكونات الذكية المتصلة بالبيانات
│       │   │   ├── ui/        # المكونات المرئية البسيطة (البطاقات، النوافذ)
│       │   │   └── data-access/ # إدارة الحالة، الخدمات، نماذج الواجهة (ViewModels)
│       │   │
│       │   └── classes/       
│       │
│       └── student-affairs/   
│           ├── registration/  
│           └── attendance/    
```

---

## 2. استراتيجية التوجيه (Routing & Lazy Loading)

لضمان أداء صاروخي (Fast Initial Load)، نعتمد استراتيجية **"التحميل المتأخر العميق" (Deep Lazy Loading)** على مستويين:

**المستوى الأول: على مستوى التطبيق (App Level)**
في ملف `app.routes.ts`، نقوم بتوجيه المستخدم إلى الأقسام الرئيسية فقط عند طلبها:
```typescript
export const appRoutes: Routes = [
  {
    path: 'student-affairs',
    loadChildren: () => import('./modules/student-affairs/student-affairs.routes').then(m => m.routes)
  }
];
```

**المستوى الثاني: على مستوى القسم (Module Level)**
داخل ملف `student-affairs.routes.ts`، نقوم بتوجيه المستخدم للعملية المحددة:
```typescript
export const routes: Routes = [
  {
    path: 'registration',
    loadComponent: () => import('./registration/feature/registration-page.component').then(c => c.RegistrationPageComponent)
  }
];
```
*(هذا يضمن أن كود "التسجيل" لن يتم تحميله إلا إذا ضغط المستخدم على زر "تسجيل طالب").*

---

## 3. استراتيجية المكونات (Smart vs Dumb Components)

كل عملية (مثل `registration`) تحتوي على مجلدين للمكونات: `feature` و `ui`. وهذا هو الفرق بينهما:

### 3.1 المكونات الذكية (Smart Components - in `feature/`)
*   **وظيفتها:** هي الصفحة (Page) التي تدير الشاشة.
*   **ما تفعله:** تتحدث مع الـ `data-access` لجلب البيانات، وتمرر البيانات إلى الـ `ui`.
*   **ما لا تفعله:** لا تحتوي على أكواد HTML وتنسيقات CSS معقدة.
```typescript
// registration/feature/registration-page.component.ts
@Component({
  selector: 'app-registration-page',
  template: `
    <!-- استدعاء المكون الغبي وتمرير البيانات إليه -->
    <app-student-form 
       [isLoading]="store.isLoading()" 
       (save)="handleSave($event)">
    </app-student-form>
  `
})
export class RegistrationPageComponent {
  store = inject(RegistrationStore); // جلب البيانات من الـ Store
  handleSave(data: any) { this.store.saveStudent(data); }
}
```

### 3.2 المكونات الغبية (Dumb/UI Components - in `ui/`)
*   **وظيفتها:** العرض والتنسيق المرئي فقط.
*   **ما تفعله:** تتلقى البيانات عبر `Input()` وتصدر الأحداث عبر `Output()`.
*   **ما لا تفعله:** **يُمنع تماماً** أن تقوم هذه المكونات بحقن أي `Service` أو التحدث مع الـ API مباشرة.
```typescript
// registration/ui/student-form.component.ts
@Component({
  selector: 'app-student-form',
  template: `<button (click)="save.emit(formData)">حفظ</button>`
})
export class StudentFormComponent {
  @Input() isLoading = false;
  @Output() save = new EventEmitter<any>();
}
```

---

## 4. الخدمات وإدارة الحالة (Services & State Management)

كيف نتصل بالباك إند ونحفظ البيانات في الشاشة؟ يتم ذلك كلياً داخل مجلد `data-access/`.

### 4.1 الخدمة (HTTP Service)
تقوم فقط بالاتصال بالـ API وجلب الـ DTOs:
```typescript
// registration/data-access/registration.service.ts
@Injectable({ providedIn: 'root' })
export class RegistrationService {
  private http = inject(HttpClient);
  
  createStudent(data: StudentDto): Observable<StudentDto> {
    return this.http.post<StudentDto>('/api/students', data);
  }
}
```

### 4.2 إدارة الحالة (Angular Signals Store)
نستخدم `SignalStore` (الحديث من NgRx) لإدارة حالة الشاشة (التحميل، الأخطاء، البيانات). الـ Store هو من يستدعي الـ Service:
```typescript
// registration/data-access/registration.store.ts
export const RegistrationStore = signalStore(
  withState({ isLoading: false, student: null }),
  withMethods((store, service = inject(RegistrationService)) => ({
    async saveStudent(data: StudentDto) {
      patchState(store, { isLoading: true });
      // استدعاء الباك إند
      service.createStudent(data).subscribe({
        next: (res) => patchState(store, { isLoading: false, student: res }),
        error: () => patchState(store, { isLoading: false })
      });
    }
  }))
);
```

---

## 5. المصادقة والبنية التحتية (Auth & Interceptors)

كل ما يخص النظام ككل (تسجيل الدخول، حماية المسارات، إضافة التوكن للطلبات) يوضع في مجلد `core/`.

### 5.1 الاعتراضات (Interceptors)
في `core/interceptors/auth.interceptor.ts`، نقوم بالتقاط أي طلب HTTP خارج للباك إند، ونقوم آلياً بحقن توكن المصادقة (JWT Token) في الـ Headers. هذا يعني أن الـ Services في الـ `data-access` لا تحتاج أبداً للقلق حول كيفية إرسال التوكن.

### 5.2 حراس المسارات (Guards)
في `core/guards/auth.guard.ts`، نتأكد أن المستخدم مسجل الدخول قبل السماح له بفتح أي مسار في `app.routes.ts`. وإذا كان غير مصرح له، يتم توجيهه لصفحة الدخول.

---

## 6. إدارة البيانات والـ DTOs (النهج الهجين)

نظراً لوجود مئات الـ DTOs في الباك إند، تم اعتماد **النهج الهجين** لحماية الواجهات الأمامية من التغيرات المفاجئة.

### 6.1 المكتبة المركزية (Single Source of Truth)
جميع الـ DTOs القادمة من الباك إند تُترجم إلى واجهات (Interfaces) وتوضع في مكتبة مركزية واحدة داخل مجلد `core/api/interfaces`.

```text
core/api/interfaces/
├── school-office/             
├── student-affairs/           
├── financial-management/      
└── cross-module-integrations/ # مخصص حصرياً للجسور المشتركة بين الأقسام
```
*   **المجلد التاسع للجسور:** أي واجهة تربط بين قسمين مختلفين في الباك إند توضع حصرياً في `cross-module-integrations` لمنع التداخل بين الأقسام (Circular Dependency).
*   **ملفات `index.ts`:** يجب أن يحتوي كل مجلد على ملف `index.ts` لتسهيل الاستيراد بسطر واحد:
    `import { StudentDto } from '@core/api/interfaces/student-affairs';`

### 6.2 حماية الشاشات بنماذج الواجهة (ViewModels)
**يُمنع استخدام الـ DTO المركزي مباشرة كنوع بيانات في ملفات الـ HTML (UI).**
بدلاً من ذلك، داخل مجلد `data-access`، ننشئ (ViewModel) يرث من الـ DTO المركزي ويضيف إليه الحقول التي تحتاجها الشاشة فقط (مثل `isSelected`).

```typescript
import { StudentDto } from '@core/api/interfaces/student-affairs';
export interface StudentViewModel extends StudentDto {
  isSelected?: boolean;
}
```

---

## 7. الممنوعات والمحاذير (Anti-Patterns to Avoid)

يُحظر تماماً ممارسة التالي لضمان عدم انهيار المعمارية:

1.  ❌ **الترقيم (m1, m2):** لا تقم بإضافة أرقام لأسماء المجلدات.
2.  ❌ **مجلد لكل جدول:** لا تقم بإنشاء مجلدات لمجرد وجود جدول لها في الباك إند. المجلدات تُبنى حول (الشاشات والعمليات) فقط.
3.  ❌ **التداخل المباشر بين الأقسام (Cross-Domain Coupling):** لا يُسمح لشاشة في قسم `financial` باستيراد مكون أو خدمة مباشرة من قسم `student-affairs`. استخدم مجلدات `shared` أو الجسور.
4.  ❌ **كتابة كود الـ HTTP داخل الـ Feature:** كل استدعاءات الخادم يجب أن تكون داخل مجلد الـ `data-access` فقط عبر الخدمات.

---

## 8. الشرح المبسط للهيكلية (Analogies & Build Order)

لفهم هذه المعمارية بسهولة، تخيل أن مشروعنا مقسم إلى 3 مباني رئيسية (مجلدات):
1. **مبنى `core` (الإدارة والبنية التحتية):** هنا نضع الأشياء التي تشغل المصنع بالكامل (مثل الأمن، والـ Interceptors، والـ Interfaces التي تمثل العقود مع الباك إند).
2. **مبنى `shared` (المخزن المشترك):** هنا نضع الأدوات التي يستخدمها جميع العمال (أزرار جاهزة، جداول مصممة، حقول نصوص).
3. **مبنى `modules` (خطوط الإنتاج):** هنا يتم العمل الفعلي، وفيه نضع الأقسام الإدارية (مثل قسم شؤون الطلاب).

### كيف نبني شاشة واحدة؟ (الترتيب الإجباري للعمل)
لا نقوم بكتابة كل شيء في ملف واحد، بل نقسم الشاشة إلى 3 غرف (يتم بناؤها بالترتيب التالي):

1. **الخطوة الأولى (العقد مع الباك إند):**
   - نبني ملف الـ `DTO` (مثال: `student.dto.ts` في مجلد `core`).
   - *السبب:* يجب معرفة شكل البيانات القادمة من الباك إند أولاً.

2. **الخطوة الثانية (غرفة `data-access` - العقل المدبر):**
   - نبني (المترجم `ViewModel`، رجل البريد `Service`، مدير المخزن `Store`).
   - *السبب:* يعتمدون على ملف الـ DTO لجلب البيانات وتخزينها، ولا علاقة لهم بالألوان أو الأزرار.

3. **الخطوة الثالثة (غرفة `ui` - العضلات / Dumb Components):**
   - نبني المكونات الغبية (مثل `student-form`). وظيفتها العرض فقط (HTML/CSS) وتنتظر البيانات من الخارج ولا تتحدث مع الخادم أبداً.
   - *السبب:* نصمم الاستمارة بناءً على البيانات التي جهزناها في الخطوة السابقة.

4. **الخطوة الرابعة (غرفة `feature` - المدير / Smart Components):**
   - نبني المكون الذكي (مثل `registration-page`). وظيفته جلب البيانات من الـ Store وتمريرها للـ UI، واستقبال الأحداث من الـ UI لإرسالها للـ Store.
   - *السبب:* لا يعمل المدير إلا إذا كان "العقل" و"العضلات" جاهزين ليربط بينهما.

5. **الخطوة الخامسة (باب الدخول - Routing):**
   - نبني ملف التوجيه `routes.ts`.
   - *السبب:* للسماح للمستخدم بالوصول إلى صفحة المدير عبر رابط URL (مثل `/registration`).

---

## 9. خريطة المجلدات التفصيلية (Detailed Folder Map)

لنفصل الهيكلية بالكامل وبأدق تفاصيل المجلدات الفرعية. تخيل أن المجلد الرئيسي لتطبيقنا هو `src/app`. هذا المجلد ينقسم إلى ثلاثة مجلدات أساسية: `core`, `shared`, و `modules`.

### 1. مجلد `core/` (قلب النظام والبنية التحتية)
هذا المجلد يحتوي على الإعدادات والأكواد التي تجعل التطبيق يعمل ككل، **ولا يتم استدعاؤه إلا مرة واحدة** عند تشغيل التطبيق.
- 📁 `core/api/interfaces/`: (المكتبة المركزية) هنا نكتب واجهات البيانات (DTOs) التي تطابق الباك إند بالضبط.
- 📁 `core/interceptors/`: (نقاط التفتيش) أي طلب (Request) يخرج من التطبيق للباك إند يمر من هنا أولاً (مثل إضافة التوكن).
- 📁 `core/guards/`: (حراس الأبواب) أكواد تمنع المستخدم من دخول صفحات معينة (مثل حماية لوحة التحكم).
- 📁 `core/services/`: خدمات عامة على مستوى التطبيق ككل (مثل الثيمات).

### 2. مجلد `shared/` (المكونات المشتركة)
هذا المجلد يحتوي على الأشياء التي سيتم إعادة استخدامها في **كل مكان** في التطبيق.
- 📁 `shared/components/`: مكونات الواجهة الجاهزة (مثل `custom-button`، `loading-spinner`).
- 📁 `shared/pipes/`: أدوات لتنسيق النصوص والتواريخ في الـ HTML.
- 📁 `shared/directives/`: أوامر خاصة يتم إضافتها لعناصر الـ HTML لتغيير سلوكها (مثل منع كتابة الحروف في حقل أرقام).

### 3. مجلد `modules/` (الأقسام الإدارية - خطوط الإنتاج)
هنا يتم بناء الميزات الفعلية للنظام. كل قسم إداري له مجلد خاص. مثال: **قسم شؤون الطلاب (student-affairs)**.

📁 `modules/student-affairs/` (القسم الرئيسي)
داخله يوجد ملف التوجيه `student-affairs.routes.ts`، ومجلدات فرعية لكل شاشة/عملية، مثلاً عملية **التسجيل (registration)**:

📁 `modules/student-affairs/registration/` (شاشة تسجيل طالب)
وتنقسم هذه الشاشة إجبارياً إلى 3 مجلدات فرعية:

1. **📁 `data-access/` (إدارة البيانات والاتصال بالخادم):**
   - 📄 `student.view-model.ts`: يترجم الـ DTO القادم من الـ `core` ليناسب الشاشة.
   - 📄 `registration.service.ts`: يحتوي على رابط الـ API للباك إند.
   - 📄 `registration.store.ts`: يحتفظ بالبيانات وحالة التحميل (`isLoading`) في الذاكرة.

2. **📁 `ui/` (المكونات المرئية - الغبية):**
   - هنا نضع المكونات التي تتكون من HTML و CSS فقط.
   - 📁 `student-registration-form/`: مجلد يحتوي على الاستمارة. هذه المكونات تستقبل البيانات وتخرج الأحداث، لكنها **لا تتحدث مع الخادم أبداً**.

3. **📁 `feature/` (المدير - المكون الذكي):**
   - 📁 `registration-page/`: الصفحة الرئيسية لعملية التسجيل.
   - **العملية:** يقوم هذا المكون بجلب المخزن (`store`) من `data-access`، ويمرر البيانات إلى الاستمارة المصممة في `ui` لربط الشاشة.

---

## 10. خطة التنفيذ الفعلي المفصلة (Detailed Execution Plan)

للبدء بتحويل هذه المعمارية إلى واقع، يتم تنفيذ المشروع على شكل مراحل متسلسلة. هذه الخطة تشرح **ماذا سنفعل، ولماذا نفعله، وما الفرق بين الملفات**:

### المرحلة الأولى: إرساء البنية التحتية (Core & Shared)
هذه المرحلة تنفذ مرة واحدة فقط لتهيئة المشروع وتغليف الأدوات الأساسية:

1. **إنشاء مجلد `core/api/interfaces` (المكتبة المركزية):**
   - **الهدف:** تجهيز مكان موحد لاستقبال واجهات الباك إند (DTOs).
   - **السبب:** لكي لا تتناثر الـ DTOs في المشروع. إذا تغير الباك إند، نعدل هنا فقط.
2. **تأجيل نظام الصلاحيات مؤقتاً (Mock Auth):**
   - في بداية التطوير، **لن** نقوم ببناء وتفعيل `auth.interceptor.ts` و `auth.guard.ts` الحقيقية.
   - **السبب:** بناءً على أفضل الممارسات، يتم تأجيل نظام الصلاحيات لتسهيل وتسريع بناء الشاشات دون أن يعيقنا تسجيل الدخول المتكرر أو أخطاء التوكن المنتهي (401/403) أثناء التطوير. سيتم دمج نظام الصلاحيات بالكامل في مرحلة لاحقة.
4. **تهيئة ملف التوجيه الرئيسي `app.routes.ts`:**
   - **الوظيفة:** ضبط الروابط بطريقة التحميل المتأخر (Lazy Loading) لضمان عدم تحميل أي قسم إلا عند النقر عليه (مما يسرع التطبيق جداً).

### المرحلة الثانية: بناء الموديول الأول (مثال: شؤون الطلاب - شاشة التسجيل)
هنا نطبق معمارية الغرف الثلاث بشكل عملي. هذه هي القوالب التي سننسخها لباقي الشاشات:

**الخطوة 1: العقد (DTO)**
- **الملف:** `student.dto.ts` (يُوضع في مجلد `core`).
- **الوظيفة:** يمثل البيانات الخام القادمة من الباك إند بالضبط.

**الخطوة 2: إنشاء الهيكل الإداري للموديول**
- **الملفات:** `student-affairs.routes.ts` ومجلد `registration/`.
- **الوظيفة:** عزل قسم شؤون الطلاب تماماً عن باقي الأقسام.

**الخطوة 3: العقل المدبر (Data Access)**
في مجلد `registration/data-access/` ننشئ 3 ملفات، وهنا يكمن الفرق الجوهري:
- **`student.view-model.ts` (المترجم):**
  - **الفرق عن الـ DTO:** الـ DTO هو ما يرسله الباك إند، أما الـ ViewModel فهو الـ DTO مضافاً إليه أشياء تحتاجها الشاشة (مثل: `isLoading`, `isSelected`). نحن نحمي الشاشة من تغيرات الباك إند عبر هذا الملف.
- **`registration.service.ts` (رجل البريد):**
  - **الوظيفة:** يحتوي على كود الـ `HttpClient` (رابط الـ API).
  - **الفرق:** وظيفته الوحيدة هي "الجلب والإرسال عبر الإنترنت"، ولا يحفظ أي بيانات.
- **`registration.store.ts` (مدير المخزن بـ Signals):**
  - **الوظيفة:** يحتفظ بالبيانات في ذاكرة المتصفح. 
  - **الفرق:** الـ Store يطلب من الـ Service جلب البيانات، ثم يحتفظ بها، لكي لا نطلبها من السيرفر مرة أخرى إذا تنقل المستخدم بين الشاشات.

**الخطوة 4: العضلات (UI Component)**
- **المجلد:** `registration/ui/student-registration-form/` (ملفات HTML/TS).
- **الوظيفة:** تصميم الاستمارة (حقول الإدخال، الأزرار).
- **الفروقات والمحاذير:**
  - هذا المكون "غبي" (Dumb). لا يعرف ما هو الـ Store ولا الـ Service ولا يتصل بالإنترنت.
  - يستقبل البيانات عبر `@Input()` ويخرجها عبر `@Output()`. الهدف؟ إمكانية إعادة استخدام هذه الاستمارة في شاشة أخرى دون مشاكل.

**الخطوة 5: المدير (Feature Component)**
- **المجلد:** `registration/feature/registration-page/` (ملفات HTML/TS).
- **الوظيفة:** هو الصفحة الرئيسية التي يفتحها الرابط.
- **الفروقات والمحاذير:**
  - هذا المكون "ذكي" (Smart). هو الوحيد الذي يتحدث مع الـ Store (يجلب منه قائمة الطلاب أو يخبره بحفظ طالب جديد).
  - لا يحتوي على تصميم معقد في الـ HTML، بل يقوم فقط باستدعاء المكون الغبي (الاستمارة) ويمرر لها البيانات.

### المرحلة الثالثة: التوسع (Scaling)
بعد الانتهاء من شاشة التسجيل والتأكد من جودة الكود، يصبح هذا الموديول هو "القالب الذهبي". لتوسيع النظام:
- نبني موديول الإدارة المالية (Financial) بنسخ نفس ترتيب الغرف الثلاث.
- نبني موديول إدارة المدارس (School Office).
- بفضل هذا الفصل الصارم (DDD)، إذا تعطل قسم المالية، لن تتأثر شاشة تسجيل الطلاب إطلاقاً!


## 11. مثال تطبيقي شامل: بناء جدول بيانات (Data Table Example)

لنفترض أننا نريد بناء شاشة "قائمة الطلاب" تعرض جدولاً (Table) بأسماء الطلاب، مع إمكانية حذف طالب. كيف نطبق هذه المعمارية بدقة وبشكل عملي؟

### الخطوة 1: العقد (المكتبة المركزية)
- **مسار المجلد:** `src/app/core/api/interfaces/student-affairs/`
- **الشرح:** نبدأ دائماً بتعريف شكل البيانات القادمة من الباك إند بدقة. هذا الملف يمثل "عقد الاتصال" ولا يحتوي على أي كود برمجي معقد، بل مجرد تعريف للأنواع (Types).
```typescript
// الملف: student.dto.ts
export interface StudentDto {
  id: number;
  fullName: string;
  grade: string;
}
```

### الخطوة 2: العقل المدبر (إدارة البيانات والاتصال)
- **مسار المجلد:** `src/app/modules/student-affairs/registration/data-access/`
- **الشرح:** هنا نبني الآلية التي تجلب البيانات وتديرها. هذا المجلد ينقسم لثلاثة ملفات لكل منها دور دقيق:

**أولاً: المترجم (ViewModel)**
- **الشرح:** الجدول قد يحتاج لخصائص إضافية غير موجودة في قاعدة بيانات الباك إند. مثلاً، إذا ضغطنا "حذف"، نريد تغيير الزر إلى "جاري الحذف..."، لذا نضيف خاصية `isDeleting` هنا لحماية الشاشة دون المساس بالـ DTO الأصلي.
```typescript
// الملف: student-list.view-model.ts
import { StudentDto } from '@core/api/interfaces/student-affairs';

export interface StudentListViewModel extends StudentDto {
  isDeleting?: boolean; // هذه الخاصية مخصصة للفرونت إند فقط (UI State)
}
```

**ثانياً: رجل البريد (Service)**
- **الشرح:** هذا هو الملف **الوحيد** المصرح له بالتحدث مع الإنترنت (الخادم). لا يقوم بتخزين أي شيء، بل يجلب البيانات ويرسلها فقط.
```typescript
// الملف: student-list.service.ts
import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StudentDto } from '@core/api/interfaces/student-affairs';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class StudentListService {
  private http = inject(HttpClient);
  
  getStudents(): Observable<StudentDto[]> { 
    return this.http.get<StudentDto[]>('/api/students'); 
  }
  
  deleteStudent(id: number): Observable<void> { 
    return this.http.delete<void>(`/api/students/${id}`); 
  }
}
```

**ثالثاً: مدير المخزن (Store)**
- **الشرح:** هذا الملف هو "عقل الشاشة". باستخدام الـ Signals، نقوم بتعريف حالة مبدئية (State) تحتوي على قائمة الطلاب وحالة التحميل. الـ Store هو من يأمر الـ Service بجلب البيانات، ثم يقوم بتحديث الحالة في الذاكرة لتتفاعل معها الواجهة مباشرة.
```typescript
// الملف: student-list.store.ts
import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { StudentListService } from './student-list.service';
import { StudentListViewModel } from './student-list.view-model';

export const StudentListStore = signalStore(
  // 1. تعريف المتغيرات التي ستتفاعل معها الشاشة
  withState({ students: [] as StudentListViewModel[], isLoading: false }),
  
  // 2. تعريف الدوال والأوامر
  withMethods((store, service = inject(StudentListService)) => ({
    loadAll() {
      patchState(store, { isLoading: true }); // إظهار علامة التحميل
      service.getStudents().subscribe(data => 
        patchState(store, { students: data, isLoading: false }) // إخفاء التحميل ووضع البيانات
      );
    },
    delete(id: number) {
      // تعديل حالة الطالب المحدد لتصبح "جاري الحذف" ليتغير شكل الزر
      patchState(store, { 
        students: store.students().map(s => s.id === id ? { ...s, isDeleting: true } : s) 
      });
      
      service.deleteStudent(id).subscribe(() => this.loadAll()); // تحديث القائمة بعد نجاح الحذف
    }
  }))
);
```

### الخطوة 3: العضلات / المكون الغبي (المكونات المرئية)
- **مسار المجلد:** `src/app/modules/student-affairs/registration/ui/student-table/`
- **الشرح:** هنا نصمم الجدول المرئي بالـ HTML. **السر في هذا المكون أنه أعمى!** لا يعرف شيئاً عن الـ Store أو الـ Service. هو يستقبل البيانات عبر `@Input()` (للداخل)، وإذا قام المستخدم بالضغط على زر الحذف، يقوم المكون فقط بالصراخ قائلاً "حدث نقر" عبر `@Output()` دون أن ينفذ الحذف بنفسه.
```typescript
// الملف: student-table.component.ts
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { StudentListViewModel } from '../../data-access/student-list.view-model';

@Component({
  selector: 'app-student-table',
  template: `
    <table>
      <tr *ngFor="let student of data">
        <td>{{ student.fullName }}</td>
        <td>
          <!-- الزر يُعطل إذا كانت حالة isDeleting مفعلة -->
          <button (click)="onDelete.emit(student.id)" [disabled]="student.isDeleting">
            {{ student.isDeleting ? 'جاري الحذف...' : 'حذف' }}
          </button>
        </td>
      </tr>
    </table>
  `
})
export class StudentTableComponent {
  @Input() data: StudentListViewModel[] = []; // استقبال البيانات من الخارج
  @Output() onDelete = new EventEmitter<number>(); // إرسال حدث الحذف للخارج
}
```

### الخطوة 4: المدير / المكون الذكي (الصفحة)
- **مسار المجلد:** `src/app/modules/student-affairs/registration/feature/student-list-page/`
- **الشرح:** هذه هي "الصفحة الرئيسية" التي يتم فتحها في المتصفح. وظيفتها الوحيدة هي تشغيل المخزن (Store) وربطه بالمكون الغبي (الجدول). هذا المكون ذكي لأنه يعلم بوجود الـ Store ويديره.
```typescript
// الملف: student-list-page.component.ts
import { Component, OnInit, inject } from '@angular/core';
import { StudentListStore } from '../../data-access/student-list.store';
import { StudentTableComponent } from '../../ui/student-table/student-table.component';

@Component({
  selector: 'app-student-list-page',
  providers: [StudentListStore], // تخصيص نسخة مستقلة من المخزن لهذه الشاشة
  template: `
    <h1>قائمة الطلاب</h1>
    <div *ngIf="store.isLoading()">جاري تحميل البيانات...</div>
    
    <!-- السحر يحدث هنا: ربط بيانات المخزن بالجدول، وربط حدث الحذف بدالة المخزن -->
    <app-student-table 
       [data]="store.students()" 
       (onDelete)="store.delete($event)">
    </app-student-table>
  `
})
export class StudentListPageComponent implements OnInit {
  store = inject(StudentListStore); // استدعاء المخزن
  
  ngOnInit() { 
    this.store.loadAll(); // فور فتح الصفحة، أمر المخزن بجلب البيانات
  }
}
```

**النتيجة النهائية للمثال:**
بسبب هذا الفصل الدقيق، أصبح لدينا:
1. جدول `app-student-table` يمكن استخدامه في أي شاشة أخرى دون تعديل حرف واحد.
2. مخزن `StudentListStore` قوي يحتفظ بالبيانات ويمكن استدعاؤه لمعرفة حالة الشاشة.
3. صفحة أنيقة `student-list-page` خالية من الأكواد المعقدة ومهمتها فقط الربط والتوجيه.

## 12. مصادر استنباط الشاشات والعمليات (Sources of Truth for Screens)

في الأنظمة المؤسسية الضخمة (Enterprise Systems)، لا يقوم مهندس الفرونت إند بابتكار الشاشات من تلقاء نفسه، بل يعتمد على مصادر محددة لمعرفة المجلدات والعمليات التي سيقوم ببنائها.

### 12.1 الباك إند (API) هو "الخريطة الحقيقية"
يعتبر توثيق الباك إند (مثل Swagger أو Postman) هو **المصدر التقني الرئيسي والعمود الفقري** لمعرفة العمليات الحقيقية.
الـ API ليس مجرد "رابط نضعه في الكود"، بل هو الخريطة التي تحدد شكل النظام وعدد شاشاته. على سبيل المثال، إذا كان الباك إند يحتوي على:
- `GET /api/students` ➔ نستنتج الحاجة لشاشة تعرض جدول الطلاب.
- `POST /api/students` ➔ نستنتج الحاجة لاستمارة (Form) لإضافة طالب جديد.
- `PUT /api/students/{id}` ➔ نستنتج الحاجة لشاشة تعديل (Popup/Form).
- `DELETE /api/students/{id}` ➔ نستنتج الحاجة لزر حذف في الجدول.

تصاميم الواجهات (مثل Figma) تفيدنا في معرفة "الشكل الجمالي وتوزيع العناصر"، ولكن **جوهر العمليات وحقيقتها يُؤخذ دائماً من الـ API**.

### 12.2 التطوير المتوازي (Mocking & Contract-First)
ماذا لو لم يكتمل الباك إند بعد؟ هل يتوقف الفرونت إند؟ **لا، إطلاقاً!**
1. **الاتفاق على العقد (Contract):** يتفق مهندس الفرونت إند مع الباك إند على شكل البيانات (DTO) ويكتبه في `core/api/interfaces/` مسبقاً.
2. **البيانات الوهمية (Mock Data):** يتم برمجة الـ `Service` ليرجع بيانات وهمية مؤقتة (بدلاً من الاتصال بالإنترنت).
3. **بناء الشاشات:** يتم بناء الشاشات والـ Store والـ UI بالكامل بناءً على هذا العقد المبدئي.
4. **لحظة الربط (Integration):** عندما يجهز الباك إند، يتم فقط تعديل الـ `Service` لوضع الرابط الحقيقي بدلاً من البيانات الوهمية، وتعمل الشاشة فوراً دون أي تعديل إضافي!
### 12.3 تأثير الـ DTO على التطوير (قبل وبعد جهوزية الـ API)
الـ **DTO** هو حجر الأساس (Blueprint). بمجرد الاتفاق عليه، يتضح مسار بناء الشاشة بالكامل:
- **الجداول (Tables):** نستنتج الأعمدة من خصائص الـ DTO (مثال: الاسم، العمر).
- **الاستمارات (Forms):** نستنتج حقول الإدخال (Inputs) من نوع البيانات في الـ DTO (نصوص، أرقام، تواريخ).

**ما الذي يمكننا بناؤه قبل أن يجهز الباك إند؟**
بوجود الـ DTO فقط، يمكننا بناء 99% من الشاشة:
1. المترجم (ViewModel).
2. مدير المخزن (Store) وتفاعلاته.
3. المكونات الغبية (UI) وتصميمها بالكامل.
4. المدير (Feature Component) الذي يربط الشاشة.
5. رجل البريد (Service) نجعله يُرجع **بيانات وهمية (Mock Data)** مطابقة للـ DTO.
بذلك تعمل الشاشة أمامنا بالكامل ونستطيع اختبارها بدقة.

**ما الذي يتغير بعد أن يجهز الباك إند؟**
يتغير **ملف واحد فقط**: الـ `Service`.
نقوم بحذف كود البيانات الوهمية ونضع مكانه كود الاتصال الحقيقي بالإنترنت (مثال: `this.http.get('/api/endpoint')`). 
أما (الـ Store، والـ UI، والـ ViewModel، والـ Feature Component) فلا يتم المساس بها إطلاقاً، وتستمر بالعمل بكفاءة تامة. هذه هي القوة الجبارة للعزل المطبقة في معمارية الغرف الثلاث!

## 13. خطة تنفيذ نظام تسجيل الطلاب (Registration Module)
بناءً على ملف `RegistrationDto.cs` المستخرج من الباك إند، تم اعتماد الخطة التالية لبناء القسم الفعلي (Contract-First):

### 13.1 طبقة العقود (Core Interfaces)
- **مسار الملف:** `src/app/core/api/interfaces/student-affairs/registration.dto.ts`
- **الوصف:** ستتم ترجمة كود C# الخاص بـ `RegistrationDto` والذي يحتوي على أكثر من 30 حقلاً (أسماء، تواريخ، جهات اتصال) إلى TypeScript، مع تضمين الـ Enums الضرورية (Gender, RegistrationStatus).

### 13.2 العقل المدبر (Data Access Layer)
المسار: `src/app/modules/student-affairs/registration/data-access/`
- **`registration.view-model.ts`:** سيورث الـ DTO ويضيف خصائص تفاعلية للواجهة مثل `isSaving` و `isUploading`.
- **`registration.service.ts`:** سيتم تزويده ببيانات وهمية (Mock Data) مؤقتاً لتشغيل الشاشة حتى يتم ربطه بالـ API الحقيقي.
- **`registration.store.ts`:** مخزن (Signals) يدير حالتين: قائمة المسجلين (لإدارة الجدول)، وحالة النموذج (لإدارة إدخال الاستمارة الضخمة).

### 13.3 العضلات / الواجهة (UI Layer)
نظراً لضخامة البيانات (أكثر من 30 حقل)، سيتم تصميم الشاشة بعناية فائقة وتقسيمها إلى مكونات:
المسار: `src/app/modules/student-affairs/registration/ui/`
- **`registration-table.component`:** جدول يعرض بيانات المسجلين الأساسية مع أزرار الإجراءات (عرض، تعديل، قبول).
- **`registration-form.component`:** استمارة ذكية مقسمة لأقسام (Tabs/Steps):
  1. بيانات الطالب (الأسماء، الجنسية، تاريخ الميلاد).
  2. بيانات الوالدين والأسرة.
  3. البيانات الأكاديمية والطبية وحالات الطوارئ.

### 13.4 المدير / الشاشة (Feature Layer)
المسار: `src/app/modules/student-affairs/registration/feature/`
- **`registration-page.component`:** الصفحة الرئيسية التي تستدعي الـ Store وتربطه بالـ Table والـ Form بطريقة ذكية ونظيفة.
- **`student-affairs.routes.ts`:** سيحتوي على إعدادات الـ Lazy Loading ليتم تحميل هذه الشاشة المعقدة فقط عند طلبها، مما يحافظ على سرعة التطبيق.

---

## 14. التقسيم الرأسي مقابل التقسيم الأفقي (Vertical vs Horizontal Slicing)

في المعماريات التقليدية (MVC)، يتم تجميع الملفات بناءً على "نوعها" (التقسيم الأفقي). مثلاً: مجلد واحد اسمه `data-access` يحتوي على كل خدمات الموديول، ومجلد `ui` يحتوي على كل الواجهات.
**هذا الأسلوب محظور تماماً في مشروعنا.**

نحن نعتمد **التقسيم الرأسي (Vertical Slicing)**، حيث تمتلك كل عملية/شاشة (مثل: التسجيل `registration`) غرفها الثلاث الخاصة بها `(feature, ui, data-access)` بشكل مستقل تماماً.

**لماذا هذا الأسلوب هو الأفضل؟ (الفوائد الذهبية):**
1. **الاستقلالية وسهولة الحذف (High Cohesion):** لو قررت الإدارة غداً إلغاء نظام "التسجيل"، كل ما عليك فعله هو حذف مجلد `registration` فقط! ولن تتأثر بقية أجزاء النظام. بينما في الطريقة الأفقية، ستضطر للبحث عن ملفات التسجيل وسط عشرات الملفات الأخرى في المجلدات العامة لتفادي انهيار النظام.
2. **عزل المشاكل (Isolation):** المبرمج الذي يعمل على شاشة (الغياب) لن يتداخل كوده أبداً مع المبرمج الذي يعمل على شاشة (التسجيل)، لأن كل مبرمج يعمل داخل "كبسولة" الغرف الثلاث الخاصة بعمله ولا يشاركها مع أحد.
3. **أداء خارق في التوجيه (Micro Lazy Loading):** هذه الهيكلية تسمح للمتصفح بتحميل كود (الـ Service والـ Store والـ UI) الخاص بالتسجيل **فقط** عندما يفتح المستخدم شاشة التسجيل، مما يمنع تحميل خدمات لا يحتاجها المستخدم ويقلل من استهلاك الذاكرة بشكل هائل.

---

## 15. مصادر الحقيقة وأنواع العمليات (Verbs & CQRS)

نظام الباك إند يعتمد على معمارية متقدمة تُسمى **CQRS (Command Query Responsibility Segregation)**، وهي تفصل أوامر القراءة عن أوامر الكتابة. فكيف نعرف في الفرونت إند نوع العملية المطلوبة (GET, POST, PUT, DELETE) حتى وإن لم يجهز الباك إند بعد؟

### 15.1 التحديد التلقائي لأنواع العمليات (RESTful Conventions)
كمهندس فرونت إند، يمكنك استنتاج نوع العملية المطلوبة للـ `Service` بديهياً بناءً على واجهة المستخدم:
- **عرض جداول/تفاصيل:** نستخدم دالة `GET` (تتطابق مع مجلد `Queries` في الباك إند).
- **إضافة سجل جديد (إرسال استمارة):** نستخدم دالة `POST` (تتطابق مع مجلد `Commands` في الباك إند).
- **تحديث بيانات سجل موجود:** نستخدم دالة `PUT` أو `PATCH` (تتطابق مع `Commands`).
- **حذف سجل:** نستخدم دالة `DELETE` (تتطابق مع `Commands`).

### 15.2 مطابقة الواجهتين (The Source of Truth)
ملف الـ `DTO` بحد ذاته لا يحتوي على أنواع العمليات (هو مجرد وعاء للبيانات). لمعرفة الرابط الدقيق (URL) ونوع العملية:
1. **الخيار الأول:** قراءة ملفات الـ Controllers مباشرة من مشروع `WebApi` في الباك إند (مثال: `CreateRegistrationController.cs` يحتوي بداخله بوضوح على `[HttpPost]` والرابط).
2. **الخيار الثاني:** استخدام واجهة التوثيق **Swagger** أو **Postman** التي يوفرها مبرمج الباك إند.

**ماذا لو لم يتم بناء الـ Controller في الباك إند بعد؟**
لا يتوقف عمل الفرونت إند إطلاقاً. نقوم بتخمين رابط منطقي (مثال: `api/v1/registrations`)، ونحدد نوع العملية بناءً على القواعد المذكورة أعلاه (POST)، ونقوم باستخدام **البيانات الوهمية (Mock Data)** داخل الـ `Service` لبناء الشاشة واختبارها بالكامل. وعند جهوزية الباك إند، نستبدل الكود الوهمي بالرابط الحقيقي فقط، وستعمل الشاشة فوراً دون أي تعديل إضافي.

---

## 16. المكدس التقني المعتمد (Approved Tech Stack)

بناءً على النقاشات والقرارات المعمارية لتطوير النظام بأعلى كفاءة باستخدام **Angular 21**، تم اعتماد الحزمة التقنية التالية:

### 16.1 الإطار الأساسي وإدارة الحالة
- **الإطار:** Angular 21 (الاعتماد على Standalone Components كمبدأ أساسي).
- **إدارة الحالة (State Management):** الاعتماد الكلي على **Angular Signals** المدمجة لضمان أداء فائق وكود نظيف، واستخدام **NgRx SignalStore** لإدارة الحالات المعقدة (بدلاً من Redux/NgRx التقليدي لتجنب الـ Boilerplate).

### 16.2 واجهة المستخدم (UI) والتصميم
- **المكتبة الأساسية:** **PrimeNG** (لبناء الجداول المعقدة، النماذج، والتقويمات، نظراً لقوتها في الأنظمة الإدارية).
- **التخطيط والتنسيق:** **Tailwind CSS** (لإدارة المسافات، الألوان، وبناء الـ Layouts المرنة بسرعة دون تعارض مع PrimeNG).
- **الأيقونات:** **PrimeIcons** (للتكامل التام مع PrimeNG وتجنب تحميل مكتبات إضافية).

### 16.3 الإضافات والأدوات الجوهرية
- **التعامل مع التواريخ:** **`date-fns`** (مكتبة خفيفة وحديثة، كبديل ضروري لـ Moment.js المحظورة بسبب حجمها).
- **دعم اللغات والاتجاهات (i18n & RTL):** استخدام `@ngx-translate/core` لضمان مرونة دعم اللغة العربية (RTL) والإنجليزية (LTR) ديناميكياً.
- **توليد الكود التلقائي (API Code Generation):** أداة **OpenAPI Generator** لقراءة ملف Swagger من الباك إند وتوليد الـ DTOs (Interfaces) والـ HTTP Services تلقائياً لمنع الأخطاء البشرية وتوفير الوقت.
### 16.4 لماذا تم استبعاد Bootstrap؟
تم اتخاذ قرار معماري حاسم باستبعاد مكتبة `Bootstrap` تماماً من المكدس التقني للأسباب التالية:
1. **تضارب المهام (Redundancy):** مكتبة `Tailwind CSS` تقوم بوظيفة النظام الشبكي (Grid) والمسافات بكفاءة ومرونة أعلى بكثير من Bootstrap. الجمع بينهما يؤدي لتعارض في أكواد الـ CSS.
2. **المكونات الجاهزة:** يُستخدم Bootstrap عادةً لأخذ المكونات الجاهزة، ولكن `PrimeNG` يوفر مكونات أضخم وأكثر احترافية ومناسبة للأنظمة الإدارية المعقدة.
3. **أداء التطبيق:** إضافة Bootstrap بجانب Tailwind و PrimeNG سيؤدي إلى تضخم حجم التطبيق (Bundle Bloat) وإبطاء التحميل دون تقديم أي قيمة تقنية إضافية.

---

**خاتمة:** 
بتطبيق هذه الهيكلية بحذافيرها، سيتحول مشروعكم إلى نظام مؤسسي (Enterprise System) صلب جداً. الـ Backend يوفر نقاط النهاية والجسور، والـ Frontend يتلقاها عبر المكتبة المركزية، ثم يعالجها عبر الـ Services و Signals، ويعرضها للمستخدم عبر مكونات UI غبية تديرها مكونات ذكية، وكل هذا تحت غطاء Lazy Loading فائق السرعة.



---

## 17. منهجية بناء طبقة الخدمات (Data Access & API Services)

بعد الانتهاء من تحويل وتوليد جميع واجهات البيانات (DTO Interfaces)، تم اعتماد القرار المعماري بالبدء ببرمجة **طبقة الخدمات (Services Layer)** كخطوة تالية قبل بناء الشاشات، وذلك للأسباب الهندسية التالية:

### 17.1 لماذا الخدمات قبل الشاشات؟
1. **إغلاق طبقة البيانات (Data Layer Completion):** إنهاء الخدمات يضمن استكمال البنية التحتية للـ API (`core/api`). المطور الذي يعمل على الشاشات (UI) سيجد الخدمات جاهزة للاستدعاء دون الحاجة لكتابة كود مؤقت (Mocking).
2. **التسلسل المنطقي للـ DDD:** تدفق البيانات يبدأ من الـ DTO ⬅️ ثم الـ Service ⬅️ ثم الـ Store ⬅️ وأخيراً الـ UI Component. تجاوز الخدمات يعني كسر هذا التدفق.

### 17.2 استراتيجية الـ Base Service (الخدمة الأساسية)
لتجنب تكرار الكود (DRY Principle) وتسهيل الصيانة لـ 232 جدولاً، سيتم تطبيق نمط **Generic Repository / Base Service**:
1. **`BaseApiService<T, TCreate, TUpdate>`:** خدمة عامة (Generic) مبنية بـ Angular تحتوي على العمليات الأساسية الموحدة (GET, POST, PUT, DELETE). 
2. **الخدمات المخصصة (Specific Services):** كل كيان (مثال: `SchoolService`) سيرث من الـ `BaseApiService` ويمرر له الـ URL الخاص به (مثل `api/v1/Schools`) والـ Interfaces (مثل `School`، `CreateSchoolPayload`).

### 17.3 ميزة الأتمتة السريعة
بما أن الباك إند يعتمد معمارية موحدة حيث يمتلك كل كيان Controller خاص به (مثل `SchoolsController`)، يمكن أتمتة توليد الخدمات المخصصة (Services) بنسبة 100٪ باستخدام نصوص برمجية (Scripts)، مما يسرع عملية التطوير ويقضي تماماً على الأخطاء البشرية (Human Errors) في كتابة روابط الـ HTTP.


### 17.4 المكتبات المستخدمة لطبقة الخدمات (Zero External Dependencies)
تم اتخاذ قرار معماري بعدم استخدام أي مكتبات خارجية (مثل Axios) للاتصال بالخادم. ستُبنى هذه الطبقة حصرياً باستخدام الأدوات المدمجة في إطار عمل Angular:
*   **`HttpClient`**: الأداة الرسمية والقياسية في Angular للتعامل مع بروتوكول HTTP، والتي تتميز بدعمها المباشر للـ Interceptors (مما يسهل حقن التوكن ومعالجة الأخطاء مركزياً).
*   **`RxJS (Observables)`**: المعيار الأساسي للتعامل مع البيانات غير المتزامنة (Asynchronous Data Streams).

### 17.5 مصادر بناء الخدمات (Sources of Truth)
لضمان دقة وتطابق الخدمات مع الباك إند، يتم استنباط وبناء كل خدمة من مصدرين تقنيين أساسيين:
1. **تحديد الرابط (URL Endpoint):** يُستمد مباشرة من هيكلة متحكمات الباك إند (Controllers) الموجودة في `EduMS.WebApi` (على سبيل المثال، المتحكم `SchoolsController` يوجهنا لاستخدام المسار `v1/Schools`).
2. **تحديد هيكل البيانات (Data Types):** يُستمد من واجهات TypeScript (Interfaces) الموجودة في `core/api/interfaces` والتي تم توليدها مسبقاً من طبقة الـ `EduMS.Application` (DTOs). هذا يضمن أن الخدمات تستقبل وتُرسل بيانات مكتوبة ومحددة بدقة (Strongly Typed).

### 17.6 استقلالية العمليات عن الشاشات المرئية (Operation-Driven Services)
بناءً على مبادئ (Domain-Driven Design)، يتم تصميم طبقة الخدمات ومخازن الحالة (Services & Stores) **بناءً على العمليات الإدارية (Operations)** المستنبطة من عقود الـ API، وليس بناءً على عدد الشاشات المرئية (UI Screens). 
- الـ Service والـ Store يمثلان "العقل" الذي يدير عملية محددة (مثل: إدارة إعدادات الفروع).
- الشاشات المرئية (UI) هي مجرد "مستهلك" لهذا العقل.
- **القاعدة الذهبية:** يمكن لـ Service واحد أن يغذي عدة شاشات تفاعلية، ويمكن لشاشة تفاعلية واحدة (إذا كانت معقدة) أن تستهلك بيانات من عدة Services. لذلك، فإن فصل برمجة العمليات عن رسم الشاشات يمنح النظام مرونة فائقة وقابلية عالية للتوسع.
