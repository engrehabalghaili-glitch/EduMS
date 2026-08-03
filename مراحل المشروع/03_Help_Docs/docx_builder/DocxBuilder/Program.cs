using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;

// ============================================================
// EduMS - Chapter 1 Word Document Generator
// ============================================================

string outputPath = @"D:\EduMS-Unified-Workspace\03_Graduation_Docs\Chapter1_المقدمة_العامة.docx";

using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(outputPath, WordprocessingDocumentType.Document))
{
    // === Setup Main Document Part ===
    MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
    mainPart.Document = new Document();
    Body body = mainPart.Document.AppendChild(new Body());

    // === Add Styles ===
    StyleDefinitionsPart stylesPart = mainPart.AddNewPart<StyleDefinitionsPart>();
    stylesPart.Styles = CreateStyles();
    stylesPart.Styles.Save();

    // ================================================================
    //  PAGE SETUP - A4, RTL, Margins
    // ================================================================
    SectionProperties sectionProps = new SectionProperties();
    PageSize pageSize = new PageSize() { Width = 11906, Height = 16838 }; // A4
    PageMargin pageMargin = new PageMargin() { Top = 1134, Bottom = 1134, Left = 1418, Right = 1418 };
    sectionProps.Append(pageSize);
    sectionProps.Append(pageMargin);

    // ================================================================
    //  COVER PAGE
    // ================================================================
    body.AppendChild(CenteredPara("جامعة صنعاء", "Traditional Arabic", 22, true));
    body.AppendChild(CenteredPara("كلية الحاسوب والمعلوماتية", "Traditional Arabic", 20, true));
    body.AppendChild(CenteredPara("قسم نظم المعلومات", "Traditional Arabic", 18, true));
    body.AppendChild(CenteredPara("", "Traditional Arabic", 14, false));
    body.AppendChild(CenteredPara("─────────────────────────────────", "Traditional Arabic", 14, false));
    body.AppendChild(CenteredPara("", "Traditional Arabic", 14, false));
    body.AppendChild(CenteredPara("مشروع التخرج", "Traditional Arabic", 16, true));
    body.AppendChild(CenteredPara("", "Traditional Arabic", 14, false));
    body.AppendChild(CenteredPara("نظام إدارة المدارس الموحد", "Traditional Arabic", 28, true));
    body.AppendChild(CenteredPara("EduMS – Educational Management System", "Traditional Arabic", 20, true));
    body.AppendChild(CenteredPara("", "Traditional Arabic", 14, false));
    body.AppendChild(CenteredPara("─────────────────────────────────", "Traditional Arabic", 14, false));
    body.AppendChild(CenteredPara("", "Traditional Arabic", 14, false));
    body.AppendChild(CenteredPara("الفصل الأول", "Traditional Arabic", 22, true));
    body.AppendChild(CenteredPara("المقدمة العامة", "Traditional Arabic", 20, true));
    body.AppendChild(CenteredPara("", "Traditional Arabic", 14, false));
    body.AppendChild(CenteredPara("مقدم استكمالاً لمتطلبات الحصول على درجة البكالوريوس في نظم المعلومات", "Traditional Arabic", 14, false));
    body.AppendChild(CenteredPara("", "Traditional Arabic", 14, false));
    body.AppendChild(CenteredPara("العام الجامعي 2025 / 2026م", "Traditional Arabic", 14, false));

    // Page Break after cover
    body.AppendChild(PageBreakPara());

    // ================================================================
    //  TABLE OF CONTENTS (Chapter 1)
    // ================================================================
    body.AppendChild(Heading("فهرس المحتويات - الفصل الأول", 1));
    body.AppendChild(RTLPara("1.1  المقدمة", "Traditional Arabic", 13, false));
    body.AppendChild(RTLPara("1.2  مشكلة الدراسة", "Traditional Arabic", 13, false));
    body.AppendChild(RTLPara("1.3  أهداف الدراسة", "Traditional Arabic", 13, false));
    body.AppendChild(RTLPara("1.4  أهمية الدراسة", "Traditional Arabic", 13, false));
    body.AppendChild(RTLPara("1.5  حدود الدراسة", "Traditional Arabic", 13, false));
    body.AppendChild(RTLPara("1.6  منهجية الدراسة", "Traditional Arabic", 13, false));
    body.AppendChild(RTLPara("1.7  أدوات التطوير والتقنيات المستخدمة", "Traditional Arabic", 13, false));
    body.AppendChild(RTLPara("1.8  الخطة الزمنية للمشروع", "Traditional Arabic", 13, false));
    body.AppendChild(RTLPara("1.9  هيكل الوثيقة وتوجيه القارئ", "Traditional Arabic", 13, false));
    body.AppendChild(PageBreakPara());

    // ================================================================
    //  1.1  المقدمة
    // ================================================================
    body.AppendChild(Heading("1.1  المقدمة", 1));
    body.AppendChild(RTLPara(
        "تُعدّ المؤسسات التعليمية من أكثر البيئات تعقيداً على صعيد الإدارة، إذ تتشابك فيها متطلبات متعددة " +
        "تمتد من التسجيل وشؤون الطلاب، مروراً بإدارة الكوادر الوظيفية والموارد المالية، ووصولاً إلى إصدار التقارير " +
        "والإحصاءات الرسمية. وفي ظل التحول الرقمي المتسارع الذي تشهده المنظومة التعليمية في العالم العربي، باتت الحاجة " +
        "ملحّة إلى منظومة برمجية متكاملة تتجاوز حدود الأنظمة الجزئية المتفرقة وتُؤمِّن لوحة تحكم موحدة تعالج جميع " +
        "العمليات تحت سقف واحد.",
        "Traditional Arabic", 14, false));
    body.AppendChild(RTLPara(
        "انطلاقاً من هذا الواقع، جاء مشروع \"نظام إدارة المدارس الموحد\" (EduMS) ليكون الحل الشامل الذي يُعالج هذه " +
        "الإشكاليات. يقوم النظام على بنية برمجية موزعة تستند إلى أحدث التقنيات على الجانبين: الخلفي (Backend) والأمامي " +
        "(Frontend)، ويُقدم ثمانية وحدات وظيفية متكاملة تُغطي جميع محاور إدارة المدرسة بدءاً من الهيكل الأكاديمي " +
        "وانتهاءً بإدارة الصلاحيات والمستخدمين.",
        "Traditional Arabic", 14, false));
    body.AppendChild(RTLPara(
        "يهدف هذا الفصل التمهيدي إلى وضع القارئ في سياق المشروع من حيث: المشكلة التي دفعت إلى تطويره، والأهداف " +
        "المنشودة منه، وأهميته على الصعيدين الأكاديمي والتطبيقي، والتقنيات المُوظَّفة في بنائه، فضلاً عن الخطة الزمنية " +
        "التي حكمت مراحل تطويره.",
        "Traditional Arabic", 14, false));

    // ================================================================
    //  1.2  مشكلة الدراسة
    // ================================================================
    body.AppendChild(Heading("1.2  مشكلة الدراسة", 1));
    body.AppendChild(RTLPara(
        "رصدنا خلال مرحلة تحليل الواقع العملي لعدد من المدارس أن المنظومة الإدارية تعاني من جملة من الإشكاليات " +
        "الهيكلية والتشغيلية، يمكن إجمالها في النقاط الآتية:",
        "Traditional Arabic", 14, false));

    body.AppendChild(BulletPara("التشتت الإداري: يعتمد معظم المدارس على أنظمة معزولة لكل وحدة إدارية (شؤون طلاب، شؤون موظفين، حسابات)، مما يُفضي إلى ازدواجية في البيانات وتعارض في السجلات."));
    body.AppendChild(BulletPara("انعدام الرقابة الآنية: لا تتوفر لوحات تحكم تتيح للإدارة متابعة الأداء المؤسسي بصورة فورية، وهو ما يُعيق صنع القرار في الوقت المناسب."));
    body.AppendChild(BulletPara("ضعف الأمن الرقمي: تفتقر الكثير من الأنظمة القائمة إلى آليات صارمة لإدارة الصلاحيات، مما يُعرّض البيانات الحساسة للاختراق أو التلاعب."));
    body.AppendChild(BulletPara("غياب التكامل بين الوحدات: لا تتواصل الأنظمة المختلفة مع بعضها بصورة آلية، إذ يضطر الموظف إلى إدخال البيانات يدوياً في أكثر من نظام، مما يزيد من احتمالية الخطأ البشري."));
    body.AppendChild(BulletPara("محدودية التقارير: تكاد التقارير الإحصائية والتحليلية تكون منعدمة أو تُعدّ يدوياً بتكلفة وقتية مرتفعة."));

    body.AppendChild(RTLPara(
        "ويمكن صياغة مشكلة الدراسة في التساؤل الرئيسي الآتي: كيف يمكن بناء نظام معلوماتي موحد يُعالج جميع " +
        "العمليات الإدارية للمدرسة ضمن منصة رقمية متكاملة، آمنة، وقابلة للتوسع؟",
        "Traditional Arabic", 14, false));

    // ================================================================
    //  1.3  أهداف الدراسة
    // ================================================================
    body.AppendChild(Heading("1.3  أهداف الدراسة", 1));
    body.AppendChild(RTLPara(
        "يسعى المشروع إلى تحقيق الأهداف التالية:",
        "Traditional Arabic", 14, false));

    body.AppendChild(BulletPara("بناء نظام إدارة مدرسي متكامل يجمع ثمانية وحدات وظيفية في منصة واحدة موحدة."));
    body.AppendChild(BulletPara("توفير واجهة مستخدم تفاعلية وسهلة الاستخدام مبنية بتقنية Angular 21 مع مكتبة PrimeNG 21."));
    body.AppendChild(BulletPara("تصميم خلفية (Backend) قوية وقابلة للتوسع باستخدام ASP.NET Core 10 وفق نمط Clean Architecture."));
    body.AppendChild(BulletPara("تطبيق نظام صلاحيات دقيق ومبني على الأدوار (Role-Based Access Control) يضمن أمن البيانات."));
    body.AppendChild(BulletPara("توفير آلية مصادقة آمنة مبنية على JWT Bearer Token مع تشفير HMAC-SHA256."));
    body.AppendChild(BulletPara("دعم سجل تدقيق شامل (Audit Log) لتتبع جميع العمليات داخل النظام."));
    body.AppendChild(BulletPara("تقديم تقارير وإحصائيات مؤسسية آنية تُعين الإدارة على اتخاذ القرارات."));
    body.AppendChild(BulletPara("تطبيق نمط الحذف المنطقي (Soft Delete) على جميع الكيانات لضمان أرشفة البيانات دون فقدانها."));

    // ================================================================
    //  1.4  أهمية الدراسة
    // ================================================================
    body.AppendChild(Heading("1.4  أهمية الدراسة", 1));
    body.AppendChild(RTLPara(
        "تكتسب هذه الدراسة أهميةً بالغة على مستويين:",
        "Traditional Arabic", 14, false));

    body.AppendChild(Heading("أ. على الصعيد الأكاديمي", 2));
    body.AppendChild(RTLPara(
        "يُوظَّف المشروع معرفة نظرية متعمقة في هندسة البرمجيات، من بينها: نمط CQRS (فصل الأوامر عن الاستعلامات) " +
        "باستخدام MediatR، ونمط Repository والوحدة المعمارية المتكاملة (Unit of Work)، إضافةً إلى تطبيق " +
        "FluentValidation للتحقق من صحة البيانات وAutoMapper لتحويلها. يُجسّد المشروع بذلك توليفاً نادراً بين " +
        "الجانبين النظري والتطبيقي يجعله نموذجاً مرجعياً لمشاريع التخرج في تخصصات نظم المعلومات وهندسة البرمجيات.",
        "Traditional Arabic", 14, false));

    body.AppendChild(Heading("ب. على الصعيد التطبيقي", 2));
    body.AppendChild(RTLPara(
        "يُقدم النظام حلاً عملياً جاهزاً للنشر في المؤسسات التعليمية، يُخفّض تكاليف الإدارة البشرية ويُقلص " +
        "الأخطاء المرتبطة بالإدخال اليدوي، كما يُتيح للإدارة العليا رؤية شاملة وفورية لأداء المدرسة عبر لوحات " +
        "معلومات متقدمة. وتبرز أهميته خصوصاً في السياق اليمني حيث تشحّ الحلول التقنية المتكاملة المصممة للبيئة المحلية.",
        "Traditional Arabic", 14, false));

    // ================================================================
    //  1.5  حدود الدراسة
    // ================================================================
    body.AppendChild(Heading("1.5  حدود الدراسة", 1));

    body.AppendChild(Heading("أ. الحدود الموضوعية", 2));
    body.AppendChild(RTLPara(
        "يتناول المشروع تطوير نظام معلوماتي يغطي الوحدات الثمانية التالية: (M1) إدارة المدرسة والمكتب، " +
        "(M2) شؤون الطلاب، (M3) إدارة الموظفين، (M4) الأصول والخدمات اللوجستية، (M5) الإدارة المالية، " +
        "(M6) الإحصاءات والتقارير، (M7) إدارة الاتصالات والطوارئ، و(M8) المصادقة وإدارة المستخدمين.",
        "Traditional Arabic", 14, false));

    body.AppendChild(Heading("ب. الحدود التقنية", 2));
    body.AppendChild(RTLPara(
        "يعمل النظام على بيئة تطوير محلية (Local Environment) مع قاعدة بيانات Oracle Database 19c. يستهدف " +
        "المتصفحات الحديثة التي تدعم معايير ES2020+. لا يشمل النطاق الحالي تطبيقات الهاتف المحمول (Mobile Apps) " +
        "أو نشر النظام في بيئة سحابية (Cloud Deployment).",
        "Traditional Arabic", 14, false));

    body.AppendChild(Heading("ج. الحدود الزمنية", 2));
    body.AppendChild(RTLPara(
        "امتدت مرحلة التطوير على مدار الفصل الدراسي الثاني من العام الجامعي 2025/2026م.",
        "Traditional Arabic", 14, false));

    // ================================================================
    //  1.6  منهجية الدراسة
    // ================================================================
    body.AppendChild(Heading("1.6  منهجية الدراسة", 1));
    body.AppendChild(RTLPara(
        "اعتمد الفريق منهجية تطوير مرنة (Agile) مُكيَّفة مع طبيعة مشاريع التخرج الجامعية، وتتضمن المراحل التالية:",
        "Traditional Arabic", 14, false));

    body.AppendChild(BulletPara("مرحلة التحليل والمتطلبات: جمع المتطلبات عبر استبيانات وجلسات نقاش مع عينة من إدارات المدارس، واستخلاص متطلبات وظيفية وغير وظيفية موثقة."));
    body.AppendChild(BulletPara("مرحلة التصميم المعماري: تصميم قاعدة البيانات (Oracle 19c) والكيانات البرمجية (Domain Entities) وتحديد الطبقات المعمارية وفق نمط Clean Architecture."));
    body.AppendChild(BulletPara("مرحلة التطوير التكراري: بناء كل وحدة وظيفية (Module) بصورة مستقلة وفق نمط CQRS، مع تكامل مستمر بين الوحدات عبر طبقة CrossModule."));
    body.AppendChild(BulletPara("مرحلة التكامل والاختبار: ربط الواجهة الأمامية (Angular) بنقاط الوصول (API Endpoints) وفحص التوافق وإجراء اختبارات وظيفية."));
    body.AppendChild(BulletPara("مرحلة التوثيق: إعداد وثيقة المشروع التحليلية والتقنية بالتوازي مع مراحل التطوير."));

    // ================================================================
    //  1.7  أدوات التطوير والتقنيات المستخدمة
    // ================================================================
    body.AppendChild(Heading("1.7  أدوات التطوير والتقنيات المستخدمة", 1));
    body.AppendChild(RTLPara(
        "اعتمد المشروع على منظومة تقنية متكاملة ومتوافقة، يمكن تصنيفها على النحو الآتي:",
        "Traditional Arabic", 14, false));

    body.AppendChild(Heading("أ. تقنيات الجانب الخلفي (Backend)", 2));
    string[][] backendTable = {
        new[]{"التقنية / الإطار", "الإصدار", "الغرض"},
        new[]{"ASP.NET Core", "10.0", "بناء الـ REST API والتحكم في طبقة الويب"},
        new[]{"Entity Framework Core", "10.x (Oracle Provider)", "التعامل مع قاعدة البيانات وإنشاء الجداول"},
        new[]{"Oracle Database", "19c", "قاعدة البيانات الرئيسية للنظام"},
        new[]{"MediatR", "آخر إصدار متوافق", "تطبيق نمط CQRS ومعالجة الأوامر والاستعلامات"},
        new[]{"FluentValidation", "آخر إصدار", "التحقق من صحة البيانات المدخلة"},
        new[]{"AutoMapper", "آخر إصدار", "تحويل الكيانات إلى نماذج نقل البيانات (DTOs)"},
        new[]{"JWT Bearer (HMAC-SHA256)", "مدمج في ASP.NET", "المصادقة والتفويض بتوكنات JWT"},
        new[]{"Hangfire (In-Memory)", "آخر إصدار", "تشغيل المهام الخلفية والمجدولة"},
        new[]{"Clean Architecture", "نمط معماري", "تنظيم الكود في أربع طبقات (Domain, Application, Infrastructure, WebApi)"},
    };
    body.AppendChild(CreateTable(backendTable));

    body.AppendChild(Heading("ب. تقنيات الجانب الأمامي (Frontend)", 2));
    string[][] frontendTable = {
        new[]{"التقنية / الإطار", "الإصدار", "الغرض"},
        new[]{"Angular", "21.2", "إطار عمل الواجهات الأمامية (SPA)"},
        new[]{"TypeScript", "5.9", "لغة البرمجة المستخدمة في Angular"},
        new[]{"PrimeNG", "21.1", "مكتبة مكونات واجهة المستخدم (UI Components)"},
        new[]{"NgRx SignalStore", "21.1", "إدارة الحالة التفاعلية بتقنية Signals"},
        new[]{"RxJS", "7.8", "البرمجة التفاعلية وإدارة طلبات HTTP"},
        new[]{"TailwindCSS", "4.x", "إطار تنسيق الواجهات (CSS Framework)"},
        new[]{"Aura Theme (PrimeUI)", "2.x", "نظام تصميم وثيمات PrimeNG"},
        new[]{"Angular HTTP Interceptors", "مدمج", "حقن JWT Token تلقائياً في كل طلب HTTP"},
        new[]{"Zone-less Change Detection", "مدمج في Angular 21", "تحسين الأداء بإلغاء Zone.js"},
    };
    body.AppendChild(CreateTable(frontendTable));

    body.AppendChild(Heading("ج. أدوات التطوير والإدارة", 2));
    string[][] toolsTable = {
        new[]{"الأداة", "الغرض"},
        new[]{"Visual Studio 2022", "بيئة التطوير الرئيسية للـ Backend (.NET)"},
        new[]{"Visual Studio Code", "بيئة التطوير للـ Frontend (Angular)"},
        new[]{"Swagger / OpenAPI", "توثيق واختبار نقاط الـ API"},
        new[]{"Git & GitHub", "إدارة الإصدارات والتعاون بين أعضاء الفريق"},
        new[]{"Oracle SQL Developer", "إدارة قاعدة البيانات Oracle 19c"},
        new[]{"Postman", "اختبار طلبات الـ API يدوياً"},
    };
    body.AppendChild(CreateTable(toolsTable));

    // ================================================================
    //  1.8  الخطة الزمنية للمشروع (مخطط جانت)
    // ================================================================
    body.AppendChild(Heading("1.8  الخطة الزمنية للمشروع", 1));
    body.AppendChild(RTLPara(
        "توزعت مراحل المشروع عبر ستة أشهر وفق الجدول الزمني التالي:",
        "Traditional Arabic", 14, false));

    string[][] ganttTable = {
        new[]{"المرحلة", "الوصف", "المدة الزمنية"},
        new[]{"المرحلة الأولى: التحليل", "جمع المتطلبات وتحليل النظام الحالي وتوثيق المتطلبات الوظيفية وغير الوظيفية", "الشهر الأول"},
        new[]{"المرحلة الثانية: التصميم", "تصميم قاعدة البيانات، والمعمارية البرمجية، ونماذج الكيانات (Domain Entities)", "الشهر الثاني"},
        new[]{"المرحلة الثالثة: تطوير الـ Backend", "بناء الطبقات الأربعة (Domain, Application, Infrastructure, WebApi) للوحدات M1-M8", "الشهران الثالث والرابع"},
        new[]{"المرحلة الرابعة: تطوير الـ Frontend", "بناء مكونات Angular، الخدمات، المصادقة، وربطها بالـ API", "الشهر الرابع والخامس"},
        new[]{"المرحلة الخامسة: التكامل والاختبار", "اختبار التكامل الكامل بين الـ Frontend والـ Backend وإصلاح الأخطاء", "الشهر الخامس"},
        new[]{"المرحلة السادسة: التوثيق والتسليم", "إعداد وثيقة المشروع (الفصول الثلاثة) وتجهيز العرض النهائي", "الشهر السادس"},
    };
    body.AppendChild(CreateTable(ganttTable));

    // ================================================================
    //  1.9  هيكل الوثيقة وتوجيه القارئ
    // ================================================================
    body.AppendChild(Heading("1.9  هيكل الوثيقة وتوجيه القارئ", 1));
    body.AppendChild(RTLPara(
        "تتألف وثيقة المشروع من ثلاثة فصول رئيسية يُكمل كل منها ما سبقه على النحو الآتي:",
        "Traditional Arabic", 14, false));

    body.AppendChild(BulletPara("الفصل الأول - المقدمة العامة (الفصل الحالي): يضع القارئ في سياق المشروع من حيث المشكلة والأهداف والأهمية والتقنيات والمنهجية."));
    body.AppendChild(BulletPara("الفصل الثاني - الإطار النظري والدراسات السابقة: يستعرض المفاهيم النظرية التي يرتكز عليها المشروع كـ Clean Architecture وCQRS والتطبيقات أحادية الصفحة (SPA)، مع مراجعة الدراسات والأنظمة المشابهة."));
    body.AppendChild(BulletPara("الفصل الثالث - تحليل النظام وتصميمه: يتناول توصيف النظام الجديد بالتفصيل، بما يشمل: نماذج حالات الاستخدام، ومخططات تدفق البيانات (DFD)، ومخططات الكيانات والعلاقات (ERD)، وتصميم الواجهات."));

    body.AppendChild(RTLPara(
        "يُنصح القارئ بالاطلاع على الفصول بالترتيب للبناء التدريجي على المعرفة المكتسبة. غير أن كل فصل صُمِّم " +
        "بما يكفي من الاكتفاء الذاتي ليكون مرجعاً مستقلاً عند الحاجة.",
        "Traditional Arabic", 14, false));

    // ================================================================
    //  FINAL SECTION PROPERTIES
    // ================================================================
    body.AppendChild(sectionProps);

    mainPart.Document.Save();
}

Console.WriteLine($"SUCCESS: Document saved to:\n{outputPath}");

// ============================================================
//  HELPER METHODS
// ============================================================

static Styles CreateStyles()
{
    var styles = new Styles();

    // Heading 1 Style
    var h1 = new Style() { Type = StyleValues.Paragraph, StyleId = "Heading1" };
    h1.Append(new StyleName() { Val = "heading 1" });
    var h1RunProps = new StyleRunProperties();
    h1RunProps.Append(new Bold());
    h1RunProps.Append(new FontSize() { Val = "32" }); // 16pt
    h1RunProps.Append(new RunFonts() { Ascii = "Traditional Arabic", HighAnsi = "Traditional Arabic", ComplexScript = "Traditional Arabic" });
    h1RunProps.Append(new Color() { Val = "1F3864" });
    h1.Append(new StyleRunProperties(h1RunProps.OuterXml));
    var h1ParaProps = new StyleParagraphProperties();
    h1ParaProps.Append(new Justification() { Val = JustificationValues.Right });
    h1ParaProps.Append(new BiDi());
    h1ParaProps.Append(new SpacingBetweenLines() { Before = "240", After = "120" });
    h1.Append(h1ParaProps);
    styles.Append(h1);

    return styles;
}

static Paragraph CenteredPara(string text, string font, int sizePt, bool bold)
{
    var para = new Paragraph();
    var pp = new ParagraphProperties();
    pp.Append(new Justification() { Val = JustificationValues.Center });
    pp.Append(new BiDi());
    pp.Append(new SpacingBetweenLines() { Line = "360", LineRule = LineSpacingRuleValues.Auto });
    para.Append(pp);

    var run = new Run();
    var rp = new RunProperties();
    rp.Append(new RunFonts() { Ascii = font, HighAnsi = font, ComplexScript = font });
    rp.Append(new FontSize() { Val = (sizePt * 2).ToString() });
    rp.Append(new FontSizeComplexScript() { Val = (sizePt * 2).ToString() });
    if (bold) rp.Append(new Bold());
    run.Append(rp);
    run.Append(new Text(text) { Space = SpaceProcessingModeValues.Preserve });
    para.Append(run);
    return para;
}

static Paragraph RTLPara(string text, string font, int sizePt, bool bold)
{
    var para = new Paragraph();
    var pp = new ParagraphProperties();
    pp.Append(new Justification() { Val = JustificationValues.Both });
    pp.Append(new BiDi());
    pp.Append(new SpacingBetweenLines() { Line = "480", LineRule = LineSpacingRuleValues.Auto });
    pp.Append(new Indentation() { Right = "0", Left = "0" });
    para.Append(pp);

    var run = new Run();
    var rp = new RunProperties();
    rp.Append(new RunFonts() { Ascii = font, HighAnsi = font, ComplexScript = font });
    rp.Append(new FontSize() { Val = (sizePt * 2).ToString() });
    rp.Append(new FontSizeComplexScript() { Val = (sizePt * 2).ToString() });
    if (bold) rp.Append(new Bold());
    rp.Append(new RightToLeftText());
    run.Append(rp);
    run.Append(new Text(text) { Space = SpaceProcessingModeValues.Preserve });
    para.Append(run);
    return para;
}

static Paragraph BulletPara(string text)
{
    var para = new Paragraph();
    var pp = new ParagraphProperties();
    pp.Append(new Justification() { Val = JustificationValues.Both });
    pp.Append(new BiDi());
    pp.Append(new Indentation() { Right = "720" });
    pp.Append(new SpacingBetweenLines() { Line = "420", LineRule = LineSpacingRuleValues.Auto });
    para.Append(pp);

    var run = new Run();
    var rp = new RunProperties();
    rp.Append(new RunFonts() { Ascii = "Traditional Arabic", HighAnsi = "Traditional Arabic", ComplexScript = "Traditional Arabic" });
    rp.Append(new FontSize() { Val = "28" });
    rp.Append(new FontSizeComplexScript() { Val = "28" });
    rp.Append(new RightToLeftText());
    run.Append(rp);
    run.Append(new Text("• " + text) { Space = SpaceProcessingModeValues.Preserve });
    para.Append(run);
    return para;
}

static Paragraph Heading(string text, int level)
{
    var para = new Paragraph();
    var pp = new ParagraphProperties();
    pp.Append(new Justification() { Val = JustificationValues.Right });
    pp.Append(new BiDi());
    int before = level == 1 ? 360 : 200;
    int after = level == 1 ? 180 : 100;
    pp.Append(new SpacingBetweenLines() { Before = before.ToString(), After = after.ToString(), Line = "360", LineRule = LineSpacingRuleValues.Auto });
    if (level == 1)
    {
        var borders = new ParagraphBorders();
        borders.Append(new BottomBorder() { Val = BorderValues.Single, Size = 6, Color = "1F3864" });
        pp.Append(borders);
    }
    para.Append(pp);

    var run = new Run();
    var rp = new RunProperties();
    int sz = level == 1 ? 36 : 30;
    rp.Append(new Bold());
    rp.Append(new RunFonts() { Ascii = "Traditional Arabic", HighAnsi = "Traditional Arabic", ComplexScript = "Traditional Arabic" });
    rp.Append(new FontSize() { Val = sz.ToString() });
    rp.Append(new FontSizeComplexScript() { Val = sz.ToString() });
    rp.Append(new Color() { Val = level == 1 ? "1F3864" : "2E4D8A" });
    rp.Append(new RightToLeftText());
    run.Append(rp);
    run.Append(new Text(text));
    para.Append(run);
    return para;
}

static Paragraph PageBreakPara()
{
    var para = new Paragraph();
    var run = new Run();
    run.Append(new Break() { Type = BreakValues.Page });
    para.Append(run);
    return para;
}

static Table CreateTable(string[][] rows)
{
    var table = new Table();

    var tblProps = new TableProperties();
    tblProps.Append(new TableWidth() { Width = "9638", Type = TableWidthUnitValues.Dxa });
    tblProps.Append(new TableJustification() { Val = TableRowAlignmentValues.Right });
    var tblBorders = new TableBorders();
    tblBorders.Append(new TopBorder() { Val = BorderValues.Single, Size = 6, Color = "1F3864" });
    tblBorders.Append(new BottomBorder() { Val = BorderValues.Single, Size = 6, Color = "1F3864" });
    tblBorders.Append(new LeftBorder() { Val = BorderValues.Single, Size = 6, Color = "1F3864" });
    tblBorders.Append(new RightBorder() { Val = BorderValues.Single, Size = 6, Color = "1F3864" });
    tblBorders.Append(new InsideHorizontalBorder() { Val = BorderValues.Single, Size = 4, Color = "8EA9C1" });
    tblBorders.Append(new InsideVerticalBorder() { Val = BorderValues.Single, Size = 4, Color = "8EA9C1" });
    tblProps.Append(tblBorders);
    table.Append(tblProps);

    bool isHeader = true;
    foreach (var row in rows)
    {
        var tr = new TableRow();
        var trProps = new TableRowProperties();
        if (isHeader) trProps.Append(new TableHeader());
        tr.Append(trProps);

        foreach (var cellText in row)
        {
            var tc = new TableCell();
            var tcProps = new TableCellProperties();
            if (isHeader)
                tcProps.Append(new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "1F3864" });
            else
                tcProps.Append(new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "EEF3F8" });
            tc.Append(tcProps);

            var cellPara = new Paragraph();
            var cellPP = new ParagraphProperties();
            cellPP.Append(new Justification() { Val = JustificationValues.Right });
            cellPP.Append(new BiDi());
            cellPP.Append(new SpacingBetweenLines() { Before = "60", After = "60" });
            cellPara.Append(cellPP);

            var cellRun = new Run();
            var cellRP = new RunProperties();
            cellRP.Append(new RunFonts() { Ascii = "Traditional Arabic", HighAnsi = "Traditional Arabic", ComplexScript = "Traditional Arabic" });
            cellRP.Append(new FontSize() { Val = "24" });
            cellRP.Append(new FontSizeComplexScript() { Val = "24" });
            cellRP.Append(new RightToLeftText());
            if (isHeader)
            {
                cellRP.Append(new Bold());
                cellRP.Append(new Color() { Val = "FFFFFF" });
            }
            cellRun.Append(cellRP);
            cellRun.Append(new Text(cellText) { Space = SpaceProcessingModeValues.Preserve });
            cellPara.Append(cellRun);
            tc.Append(cellPara);
            tr.Append(tc);
        }

        table.Append(tr);
        isHeader = false;
    }

    return table;
}
