const fs = require('fs');
const path = require('path');

const DB_PATH = path.join(__dirname, 'db.json');
const raw = JSON.parse(fs.readFileSync(DB_PATH, 'utf-8'));

const pick = (arr) => arr[Math.floor(Math.random() * arr.length)];
const rand = (min, max) => Math.floor(Math.random() * (max - min + 1)) + min;
const dateStr = (y, m, d) => `${y}-${String(m).padStart(2,'0')}-${String(d).padStart(2,'0')}`;
const dateStrFrom = (base, offsetDays) => {
  const d = new Date(base);
  d.setDate(d.getDate() + offsetDays);
  return d.toISOString().split('T')[0];
};
const now = () => new Date().toISOString().split('T')[0];

const idCounter = {};

function nextId(key) {
  if (!idCounter[key]) idCounter[key] = 0;
  return ++idCounter[key];
}

const schoolNamesAr = ['مدرسة النخيل الثانوية','مدرسة الفاروق الابتدائية','مدرسة الأندلس المتوسطة','مدرسة اليمامة الثانوية للبنات','مدرسة أجيال المستقبل الأهلية'];
const schoolNamesEn = ['Al Nakhil Secondary','Al Farooq Primary','Al Andalus Interm.','Al Yamamah Girls','Future Generations'];
const governorates = ['منطقة الرياض','منطقة الرياض','منطقة الرياض','منطقة الرياض','منطقة مكة المكرمة'];
const dirNames = ['مكتب تعليم شرق الرياض','مكتب تعليم غرب الرياض','مكتب تعليم العاصمة المقدسة'];

const arabicFirstNames = ['أحمد','محمد','علي','خالد','سارة','نورة','فاطمة','مريم','عبدالله','عمر','عبدالرحمن','فيصل','هند','منى','ليلى'];
const arabicLastNames = ['القحطاني','الدوسري','الزهراني','الشهراني','العتيبي','المطيري','الغامدي','العمري','الرشيد','الوذيناني','السلمي','الربيعان'];
const arabicTeachers = ['أ. محمد القحطاني','أ. عبدالله الدوسري','أ. سارة الشهراني','أ. نورة العتيبي','أ. خالد المطيري','أ. فاطمة الغامدي','أ. عمر الزهراني','أ. منى العمري','أ. عبدالرحمن السلمي','أ. ليلى الربيعان'];
const arabicSubjects = ['الرياضيات','العلوم','اللغة العربية','اللغة الإنجليزية','التربية الإسلامية','الدراسات الاجتماعية','الحاسب الآلي','التربية البدنية','التربية الفنية','الفيزياء','الكيمياء','الأحياء','التاريخ','الجغرافيا','الاقتصاد'];

let sid = 0;
let did = 0;
let eid = 0;

// ===== educationalStages =====
const stages = [
  { stageCode:'PRIM', stageNameAr:'المرحلة الابتدائية', stageNameEn:'Primary Stage', minAge:6, maxAge:12, defaultDurationYears:6, ministryCurriculumCode:'M-PRIM-01', requiresGraduationCertificate:false, displayOrder:1, isActive:true },
  { stageCode:'INTM', stageNameAr:'المرحلة المتوسطة',   stageNameEn:'Intermediate Stage', minAge:12, maxAge:15, defaultDurationYears:3, ministryCurriculumCode:'M-INTM-01', requiresGraduationCertificate:false, displayOrder:2, isActive:true },
  { stageCode:'SECN', stageNameAr:'المرحلة الثانوية',   stageNameEn:'Secondary Stage', minAge:15, maxAge:18, defaultDurationYears:3, ministryCurriculumCode:'M-SECN-01', requiresGraduationCertificate:true, displayOrder:3, isActive:true },
];
const educationalStages = stages.map(s => ({ id: nextId('educationalStages'), ...s }));

// ===== directorates (preserve existing, add if needed) =====
const existingDirs = raw.directorates || [];
const dirsToAdd = [
  { directorateCode:'DIR-RYD-001', directorateNameAr:'مكتب تعليم شرق الرياض', directorateNameEn:'Riyadh East Education Office', address:'حي النخيل، طريق أبو بكر الصديق', contactPhone:'+966112345678', contactEmail:'east.office@riyadh.gov.sa', directorName:'د. عبدالله القحطاني', governorate:'منطقة الرياض', establishmentDate:'2010-09-01', regionCode:'RYD-EAST-01', supervisoryScopeDescription:'الإشراف على 45 مدرسة في قطاع شرق الرياض', annualBudgetLimit:12500000, employeeCount:87, isActive:true },
  { directorateCode:'DIR-RYD-002', directorateNameAr:'مكتب تعليم غرب الرياض', directorateNameEn:'Riyadh West Education Office', address:'حي السويدي، طريق الأمير خالد', contactPhone:'+966112456789', contactEmail:'west.office@riyadh.gov.sa', directorName:'د. نورة الدوسري', governorate:'منطقة الرياض', establishmentDate:'2012-03-15', regionCode:'RYD-WEST-01', supervisoryScopeDescription:'الإشراف على 38 مدرسة في قطاع غرب الرياض', annualBudgetLimit:11000000, employeeCount:72, isActive:true },
  { directorateCode:'DIR-MAK-001', directorateNameAr:'مكتب تعليم العاصمة المقدسة', directorateNameEn:'Makkah Education Office', address:'حي الزاهر، طريق المنصور', contactPhone:'+966125567890', contactEmail:'info@makkah.gov.sa', directorName:'أ. خالد الزهراني', governorate:'منطقة مكة المكرمة', establishmentDate:'2008-06-20', regionCode:'MAK-01', supervisoryScopeDescription:'الإشراف على 52 مدرسة في العاصمة المقدسة', annualBudgetLimit:15000000, employeeCount:95, isActive:true },
];
const directorates = [...existingDirs];
for (const d of dirsToAdd) {
  if (!directorates.find(x => x.directorateCode === d.directorateCode)) {
    directorates.push({ id: nextId('directorates'), ...d });
  }
}

// ===== schools (preserve existing, extend to 5) =====
const existingSchools = raw.schools || [];
const schoolData = [
  { directorateId:1, educationalStageId:1, schoolNameAr:'مدرسة النخيل الثانوية', schoolNameEn:'Al Nakhil Secondary School', schoolCode:'SCH-RYD-001', directorate:'مكتب تعليم شرق الرياض', governorate:'منطقة الرياض', establishmentDate:'2015-09-01', contactPhone:'+966114567890', contactEmail:'info@nakhil.edu.sa', websiteUrl:'https://nakhil.edu.sa', postalAddress:'حي النخيل، الرياض', maxStudentCapacity:1200, isAccredited:true, isActive:true },
  { directorateId:1, educationalStageId:2, schoolNameAr:'مدرسة الفاروق الابتدائية', schoolNameEn:'Al Farooq Primary School', schoolCode:'SCH-RYD-002', directorate:'مكتب تعليم شرق الرياض', governorate:'منطقة الرياض', establishmentDate:'2010-09-01', contactPhone:'+966114567891', contactEmail:'info@farooq.edu.sa', websiteUrl:'https://farooq.edu.sa', postalAddress:'حي الرحمانية، الرياض', maxStudentCapacity:850, isAccredited:true, isActive:true },
  { directorateId:2, educationalStageId:3, schoolNameAr:'مدرسة الأندلس المتوسطة', schoolNameEn:'Al Andalus Intermediate School', schoolCode:'SCH-RYD-003', directorate:'مكتب تعليم غرب الرياض', governorate:'منطقة الرياض', establishmentDate:'2018-09-01', contactPhone:'+966114567892', contactEmail:'info@andalus.edu.sa', websiteUrl:null, postalAddress:'حي السويدي، الرياض', maxStudentCapacity:950, isAccredited:false, isActive:true },
  { directorateId:2, educationalStageId:3, schoolNameAr:'مدرسة اليمامة الثانوية للبنات', schoolNameEn:'Al Yamamah Secondary for Girls', schoolCode:'SCH-RYD-004', directorate:'مكتب تعليم غرب الرياض', governorate:'منطقة الرياض', establishmentDate:'2013-09-01', contactPhone:'+966114567893', contactEmail:'info@yamamah.edu.sa', websiteUrl:'https://yamamah.edu.sa', postalAddress:'حي طويق، الرياض', maxStudentCapacity:1100, isAccredited:true, isActive:true },
  { directorateId:3, educationalStageId:3, schoolNameAr:'مدرسة أجيال المستقبل الأهلية', schoolNameEn:'Future Generations Private School', schoolCode:'SCH-MAK-001', directorate:'مكتب تعليم العاصمة المقدسة', governorate:'منطقة مكة المكرمة', establishmentDate:'2020-09-01', contactPhone:'+966125678901', contactEmail:'info@fgen.edu.sa', websiteUrl:'https://fgen.edu.sa', postalAddress:'حي الشوقية، مكة', maxStudentCapacity:700, isAccredited:true, isActive:true },
];
const schools = [...existingSchools];
for (const s of schoolData) {
  if (!schools.find(x => x.schoolCode === s.schoolCode)) {
    schools.push({ id: nextId('schools'), ...s });
  }
}
const schoolIds = schools.map(s => s.id);
const activeSchoolIds = schools.filter(s => s.isActive).map(s => s.id);

// ===== schoolAcademicYears =====
const schoolAcademicYears = [];
for (const sid of activeSchoolIds.slice(0, 3)) {
  for (const year of ['1446-1447']) {
    schoolAcademicYears.push({
      id: nextId('schoolAcademicYears'),
      schoolId: sid,
      yearCode: year,
      yearNameAr: `العام الدراسي ${year}`,
      yearNameEn: `Academic Year ${year}`,
      startDate: '2025-08-24',
      endDate: '2026-06-18',
      registrationStartDate: '2025-07-01',
      registrationEndDate: '2025-09-01',
      addDropStartDate: '2025-09-01',
      addDropEndDate: '2025-09-15',
      examsStartDate: '2026-05-15',
      examsEndDate: '2026-06-10',
      isCurrentYear: true,
      yearStatus: 'نشط',
      isArchived: false,
      archivedDate: null,
      previousAcademicYearId: null,
      notes: null
    });
  }
}
const ayIds = schoolAcademicYears.map(a => a.id);

// ===== schoolSemesters =====
const schoolSemesters = [];
const semNames = { 1:'الفصل الدراسي الأول', 2:'الفصل الدراسي الثاني', 3:'الفصل الدراسي الثالث' };
for (const ayId of ayIds) {
  for (let sn = 1; sn <= 3; sn++) {
    schoolSemesters.push({
      id: nextId('schoolSemesters'),
      schoolAcademicYearId: ayId,
      semesterNumber: sn,
      semesterType: sn === 1 ? 'أول' : sn === 2 ? 'ثاني' : 'ثالث',
      semesterNameAr: semNames[sn],
      semesterNameEn: `Semester ${sn}`,
      startDate: sn === 1 ? '2025-08-24' : sn === 2 ? '2025-12-07' : '2026-03-08',
      endDate: sn === 1 ? '2025-12-04' : sn === 2 ? '2026-03-05' : '2026-06-18',
      teachingWeeksCount: 15,
      examWeeksCount: 2,
      registrationOpenDate: '2025-07-01',
      registrationCloseDate: '2025-09-01',
      addDropStartDate: '2025-09-01',
      addDropEndDate: '2025-09-15',
      examStartDate: sn === 1 ? '2025-11-24' : sn === 2 ? '2026-02-23' : '2026-06-08',
      examEndDate: sn === 1 ? '2025-12-04' : sn === 2 ? '2026-03-05' : '2026-06-18',
      gradingOpenDate: null, gradingCloseDate: null, closureDate: null,
      approvalStatus: 'معتمد',
      isActive: true,
      isCurrent: sn === 2,
      notes: null
    });
  }
}

// ===== schoolLevels =====
const schoolLevels = [];
for (const sid of activeSchoolIds) {
  const levels = [
    { levelNameAr:'المستوى الأول', levelNameEn:'Level 1', levelOrder:1, startGrade:'1', endGrade:'3', academicTrack:'عام', minAgeYears:6, maxAgeYears:9, defaultShiftId:1, isActive:true, notes:null },
    { levelNameAr:'المستوى الثاني', levelNameEn:'Level 2', levelOrder:2, startGrade:'4', endGrade:'6', academicTrack:'عام', minAgeYears:9, maxAgeYears:12, defaultShiftId:1, isActive:true, notes:null },
  ];
  for (const lv of levels) {
    schoolLevels.push({ id: nextId('schoolLevels'), schoolId: sid, ...lv });
  }
}
const slIds = schoolLevels.map(l => l.id);

// ===== schoolShifts =====
const schoolShifts = [];
for (const sid of activeSchoolIds) {
  schoolShifts.push(
    { id: nextId('schoolShifts'), schoolId: sid, shiftNameAr:'الفترة الصباحية', shiftNameEn:'Morning Shift', startTime:'06:30', endTime:'11:30', shiftCode: 'MORN', totalPeriodsCount:7, periodDurationMinutes:45, breakDurationMinutes:15, isActive:true },
    { id: nextId('schoolShifts'), schoolId: sid, shiftNameAr:'الفترة المسائية', shiftNameEn:'Afternoon Shift', startTime:'12:00', endTime:'16:30', shiftCode: 'AFTN', totalPeriodsCount:6, periodDurationMinutes:40, breakDurationMinutes:10, isActive:true }
  );
}

// ===== subjects =====
const subjects = [];
for (const sid of activeSchoolIds) {
  for (let i = 0; i < 6; i++) {
    const subj = pick(arabicSubjects.filter((_, idx) => !subjects.find(s => s.schoolId === sid && s.subjectNameAr === arabicSubjects[idx])));
    if (!subj) continue;
    subjects.push({
      id: nextId('subjects'),
      schoolId: sid,
      subjectCode: `SUB-${sid}-${String(i+1).padStart(2,'0')}`,
      subjectNameAr: subj,
      subjectNameEn: subj,
      specialization: pick(['علمي','أدبي','عام',null]),
      weeklyHours: rand(3,6),
      gradeLevel: rand(1,12),
      textbookTitle: `${subj} - كتاب الطالب`,
      totalMarks: 100,
      passingMarks: 50,
      creditHours: rand(2,4),
      isCoreSubject: i < 4,
      isActive: true
    });
  }
}
const subjIds = subjects.map(s => s.id);

// ===== classrooms =====
const classrooms = [];
for (const sid of activeSchoolIds) {
  for (let g = 1; g <= 3; g++) {
    for (let sec = 1; sec <= 2; sec++) {
      classrooms.push({
        id: nextId('classrooms'),
        schoolId: sid,
        classroomCode: `CLS-${sid}-${g}${String.fromCharCode(64+sec)}`,
        classroomNameAr: `الصف ${g} - شعبة ${String.fromCharCode(64+sec)}`,
        classroomNameEn: `Grade ${g} - Section ${String.fromCharCode(64+sec)}`,
        gradeLevel: g,
        capacity: rand(25,35),
        roomNumber: `R-${g}${sec}`,
        floorLevel: 1,
        buildingSection: pick(['A','B','C']),
        homeroomTeacherEmployeeId: null,
        isSmartClassroom: Math.random() > 0.5,
        isActive: true
      });
    }
  }
}
const clsIds = classrooms.map(c => c.id);

// ===== schoolFacilities =====
const facilityTypes = ['فصل_دراسي','مختبر','مكتبة','ملعب','قاعة','مقصف'];
const facilities = [];
for (const sid of activeSchoolIds) {
  const facCount = rand(3,5);
  for (let i = 0; i < facCount; i++) {
    const ft = facilityTypes[i % facilityTypes.length];
    facilities.push({
      id: nextId('facilities'),
      schoolId: sid,
      facilityCode: `FAC-${sid}-${String(i+1).padStart(2,'0')}`,
      facilityNameAr: pick(['مختبر العلوم','مكتبة المدرسة','ملعب كرة القدم','قاعة الأنشطة','مقصف الطلاب','مختبر الحاسب','فصل دراسي ذكي','قاعة الاجتماعات']),
      facilityNameEn: pick(['Science Lab','School Library','Football Field','Activity Hall','Student Cafeteria','Computer Lab','Smart Classroom','Meeting Room']),
      facilityType: ft,
      capacity: rand(30,300),
      assignedSupervisorId: null,
      isOperational: Math.random() > 0.2,
      locationFloor: pick(['أرضي','الأول','الثاني','الثالث']),
      buildingName: pick(['المبنى الرئيسي','المبنى الجنوبي','المبنى الشمالي']),
      safetyInspectionDate: dateStr(2025, rand(1,12), rand(1,28)),
      maintenanceStatus: pick(['جيد','بحاجة_صيانة','قيد_الإصلاح','متوقف'])
    });
  }
}
const facIds = facilities.map(f => f.id);

// ===== schoolContactInfos =====
const schoolContactInfos = [];
for (const sid of activeSchoolIds) {
  schoolContactInfos.push({
    id: nextId('schoolContactInfos'),
    schoolId: sid,
    officialPhone: `+9665${String(rand(10000000,99999999))}`,
    landline: `011${String(rand(1000000,9999999))}`,
    faxNumber: `011${String(rand(1000000,9999999))}`,
    officialEmail: `info@school${sid}.edu.sa`,
    alternativeEmail: `admin@school${sid}.edu.sa`,
    fullAddress: pick(['حي النخيل، الرياض','حي السويدي، الرياض','حي الشوقية، مكة']),
    streetName: pick(['شارع الملك عبدالعزيز','شارع الأمير محمد','شارع الفاروق']),
    buildingNumber: rand(100,500),
    postalCode: `12${String(rand(300,400))}`,
    districtName: pick(['النخيل','السويدي','الشوقية','الزاهر']),
    city: pick(['الرياض','الرياض','مكة المكرمة']),
    gpsLatitude: String(24 + Math.random()).slice(0,8),
    gpsLongitude: String(46 + Math.random()).slice(0,8),
    locationMapUrl: null,
    workingHoursJson: JSON.stringify({sat:'07:30-14:00',sun:'07:30-14:00',mon:'07:30-14:00',tue:'07:30-14:00',wed:'07:30-14:00'}),
    emergencyContactName: pick(arabicFirstNames) + ' ' + pick(arabicLastNames),
    emergencyContactPhone: `+9665${String(rand(10000000,99999999))}`,
    socialLinksJson: JSON.stringify({twitter:'@school'+sid,facebook:null})
  });
}

// ===== departments =====
const depTypes = ['تعليمي','إداري','مالي','فني','رقابي'];
const departments = [];
for (const sid of activeSchoolIds) {
  for (const dt of depTypes) {
    departments.push({
      id: nextId('departments'),
      schoolId: sid,
      departmentCode: `DEPT-${sid}-${dt.slice(0,4).toUpperCase()}`,
      departmentNameAr: `قسم ${dt}`,
      departmentNameEn: `${dt} Department`,
      departmentType: dt,
      responsibilities: `الإشراف على جميع المهام ${dt} في المدرسة`,
      annualBudget: rand(100000,500000),
      employeeCount: rand(3,12),
      headOfDepartmentEmployeeId: null,
      workingHoursDescription: '07:30 - 14:00',
      establishmentDate: dateStr(2015,9,1),
      isActive: true
    });
  }
}

// ===== gradeCapacities =====
const gradeCapacities = [];
const genderOptions = ['ذكر','أنثى','مختلط'];
for (const ayId of ayIds) {
  for (const slId of slIds.slice(0,2)) {
    gradeCapacities.push({
      id: nextId('gradeCapacities'),
      schoolAcademicYearId: ayId,
      schoolLevelId: slId,
      gradeLevelCode: `GL-${slId}-${ayId}`,
      gradeNameAr: `صف ${slId}`,
      gradeNameEn: `Grade ${slId}`,
      maxStudentsPerSection: rand(25,35),
      maxSectionsCount: rand(3,6),
      currentEnrolledCount: rand(80,180),
      genderAllocation: pick(genderOptions),
      isActive: true,
      notes: null
    });
  }
}

// ===== schoolCurriculumPlans =====
const schoolCurriculumPlans = [];
for (const sid of activeSchoolIds.slice(0,3)) {
  schoolCurriculumPlans.push({
    id: nextId('schoolCurriculumPlans'),
    schoolId: sid,
    planNameAr: `الخطة الدراسية - ${pick(schoolNamesAr)}`,
    planNameEn: `Curriculum Plan - ${pick(schoolNamesEn)}`,
    planCode: `PLAN-${sid}-${rand(1000,9999)}`,
    gradeCapacityId: pick(gradeCapacities.map(g => g.id)),
    schoolLevelId: pick(slIds),
    schoolAcademicYearId: pick(ayIds),
    schoolSemesterId: pick(schoolSemesters.map(s => s.id)),
    planVersion: '1.0',
    adoptionDate: dateStr(2025, rand(6,8), rand(1,28)),
    totalCreditHours: rand(25,35),
    planStatus: pick(['معتمد','قيد_التنفيذ']),
    ministerialApprovalStatus: pick(['معتمد','قيد_الاعتماد']),
    approvalDocumentUrl: null,
    isActive: true,
    effectiveDate: dateStr(2025,9,1),
    expiryDate: dateStr(2026,6,30),
    notes: null
  });
}

// ===== classSchedules =====
const daysOfWeek = ['السبت','الأحد','الإثنين','الثلاثاء','الأربعاء','الخميس'];
const classSchedules = [];
for (const sid of activeSchoolIds.slice(0,2)) {
  const thoseCls = classrooms.filter(c => c.schoolId === sid);
  const thoseSub = subjects.filter(s => s.schoolId === sid);
  for (let p = 1; p <= 4; p++) {
    for (const d of daysOfWeek.slice(0,5)) {
      const cls = pick(thoseCls);
      const sub = pick(thoseSub);
      classSchedules.push({
        id: nextId('classSchedules'),
        schoolId: sid,
        classroomId: cls.id,
        subjectId: sub.id,
        assignedEmployeeId: null,
        dayOfWeek: d,
        periodNumber: p,
        roomCode: cls.roomNumber,
        startTime: `${String(7+p).padStart(2,'0')}:00`,
        endTime: `${String(7+p).padStart(2,'0')}:45`,
        termSemesterNumber: pick(['الأول','الثاني','الثالث']),
        scheduleType: 'دراسي',
        isActive: true
      });
    }
  }
}

// ===== examDistributionTimetables =====
const examTypes = [1,2,3];
const examTimetables = [];
for (const sid of activeSchoolIds.slice(0,2)) {
  const thoseCls = classrooms.filter(c => c.schoolId === sid);
  const thoseSub = subjects.filter(s => s.schoolId === sid);
  const thoseFac = facilities.filter(f => f.schoolId === sid);
  for (let i = 0; i < 4; i++) {
    examTimetables.push({
      id: nextId('examTimetables'),
      schoolId: sid,
      subjectId: pick(thoseSub).id,
      classroomId: pick(thoseCls).id,
      facilityId: pick(thoseFac).id,
      proctorEmployeeId: null,
      examDate: dateStr(2026, rand(5,6), rand(1,15)),
      startTime: '08:00',
      endTime: '10:00',
      maxSeatCount: rand(25,30),
      status: pick(['نشط','موقوف']),
      examSessionNameAr: `اختبار ${pick(arabicSubjects)}`,
      examType: pick(examTypes),
      termSemesterNumber: pick(['الأول','الثاني','الثالث']),
      assistantProctorEmployeeId: null,
      isSeatingChartPublished: Math.random() > 0.5
    });
  }
}

// ===== classroomOperationalRules =====
const classroomOperationalRules = [];
for (const cls of classrooms.slice(0,6)) {
  classroomOperationalRules.push({
    id: nextId('classroomOperationalRules'),
    classroomId: cls.id,
    ruleCode: `RULE-${cls.classroomCode}`,
    ruleTitleAr: `قواعد الصف ${cls.classroomNameAr}`,
    ruleTitleEn: `Rules for ${cls.classroomNameEn}`,
    maxAllowedAbsencePercentage: 15,
    requiresDailyAttendanceLog: true,
    allowLateArrivalMinutes: 10,
    maxAllowedConsecutiveAbsenceDays: 5,
    penaltyTypeForExceedingLimit: pick(['إنذار','خصم_درجات','حرمان','فصل_مؤقت']),
    effectiveStartDate: dateStr(2025,9,1),
    isActive: true
  });
}

// ===== classroomResourceAllocations =====
const resourceTypes = ['أثاث','أجهزة','وسائل_تعليمية','كتب','أخرى'];
const classroomResourceAllocations = [];
for (const cls of classrooms.slice(0,6)) {
  for (let i = 0; i < 3; i++) {
    classroomResourceAllocations.push({
      id: nextId('classroomResourceAllocations'),
      classroomId: cls.id,
      resourceNameAr: pick(['سبورة ذكية','جهاز عرض','حاسب آلي','طاولة دراسية','كرسي','مكتبة صفية','خزانة']),
      resourceCode: `RES-${cls.classroomCode}-${i}`,
      resourceType: pick(resourceTypes),
      quantity: rand(1,15),
      assignedDate: dateStr(2025,9,rand(1,15)),
      conditionStatus: pick(['جديد','جيد','مقبول','بحاجة استبدال']),
      resourceNameEn: pick(['Smart Board','Projector','Computer','Desk','Chair','Bookshelf','Cabinet']),
      assetSerialNumber: `SN-${String(rand(100000,999999))}`,
      unitPurchaseCost: rand(100,5000),
      lastInspectionDate: dateStr(2025,rand(10,12),rand(1,20)),
      nextMaintenanceDate: dateStr(2026,rand(1,6),rand(1,20))
    });
  }
}

// ===== schoolAccreditationLogs =====
const accreditations = [];
for (const sid of activeSchoolIds) {
  accreditations.push({
    id: nextId('accreditations'),
    schoolId: sid,
    licenseNumber: `LIC-${sid}-${rand(10000,99999)}`,
    accreditationBody: pick(['وزارة التعليم','الهيئة الوطنية للتقويم والاعتماد','مؤسسة تطوير التعليم']),
    issueDate: dateStr(2023,rand(1,12),rand(1,28)),
    expiryDate: dateStr(2028,rand(1,12),rand(1,28)),
    status: pick(['نشط','موقوف']),
    licenseType: pick(['ترخيص_تشغيلي','اعتماد_أكاديمي','شهادة_جودة']),
    accreditationGrade: pick(['أ','ب','ج',null]),
    certificateAttachmentUrl: null,
    renewalSubmittedDate: Math.random() > 0.5 ? dateStr(2025,rand(1,6),rand(1,28)) : null
  });
}

// ===== schoolAnnouncementLogs =====
const announcements = [];
const audiences = ['جميع_الطلاب','المعلمون','الإدارة','أولياء_الأمور','الجميع'];
for (const sid of activeSchoolIds) {
  for (let i = 0; i < 3; i++) {
    announcements.push({
      id: nextId('announcements'),
      schoolId: sid,
      titleAr: pick(['جدول الاختبارات النهائية','اجتماع أولياء الأمور','إعلان بدء التسجيل','عطلة الفصل الدراسي','نتائج التفوق الدراسي']),
      titleEn: pick(['Exam Schedule','Parent Meeting','Registration Open','Semester Break','Academic Excellence']),
      announcementContent: `نشكر جميع الطلاب وأولياء الأمور على التعاون ونود إعلامكم بآخر المستجدات`,
      publishDate: dateStr(2025,rand(9,12),rand(1,28)),
      expireDate: dateStr(2026,rand(1,6),rand(1,28)),
      targetAudience: pick(audiences),
      isPinned: Math.random() > 0.7,
      announcementPriority: pick(['عادي','مهم','عاجل']),
      attachmentFileUrl: null,
      viewCount: rand(50,500),
      publishedByEmployeeId: null,
      isActive: true
    });
  }
}

// ===== schoolAuditLogs =====
const auditLogs = [];
for (const sid of activeSchoolIds.slice(0,3)) {
  for (let i = 0; i < 3; i++) {
    auditLogs.push({
      id: nextId('auditLogs'),
      schoolId: sid,
      affectedTableName: pick(['schools','classrooms','subjects','students','teachers']),
      affectedEntityId: rand(1,20),
      operationType: pick(['إنشاء','تعديل','عرض','طباعة']),
      changeTypeSummary: pick(['تم إضافة سجل جديد','تم تعديل البيانات','تم عرض التقرير']),
      oldValueJson: null,
      newValueJson: JSON.stringify({data:'mock'}),
      changeSummaryText: 'تحديث روتيني للبيانات',
      performedByUserId: 1,
      performedByUserName: 'مشرف النظام',
      performedByUserRole: 'OFFICE_SUPERVISOR',
      ipAddress: `192.168.${rand(1,255)}.${rand(1,255)}`,
      deviceInfo: 'Chrome/Windows 11',
      actionDate: dateStr(2025,rand(9,12),rand(1,28)),
      severityLevel: pick(['منخفض','متوسط','مرتفع']),
      isSuspicious: false,
      decisionDocumentUrl: null,
      notes: null
    });
  }
}

// ===== schoolCanteenItems =====
const canteenItems = [];
for (const sid of activeSchoolIds) {
  const thoseFac = facilities.filter(f => f.schoolId === sid);
  const items = [
    { itemCode:`CANT-${sid}-01`, itemNameAr:'ساندويتش دجاج', unitPrice:5, nutritionalCategory:'صحي', isApprovedByHealthOfficer:true, costPrice:3.5, dailySalesLimitPerStudent:2 },
    { itemCode:`CANT-${sid}-02`, itemNameAr:'عصير طبيعي', unitPrice:3, nutritionalCategory:'صحي', isApprovedByHealthOfficer:true, costPrice:2, dailySalesLimitPerStudent:3 },
    { itemCode:`CANT-${sid}-03`, itemNameAr:'شوكولاتة بالحليب', unitPrice:2, nutritionalCategory:'غير_صحي', isApprovedByHealthOfficer:false, costPrice:1.25, dailySalesLimitPerStudent:1 },
  ];
  for (const it of items) {
    canteenItems.push({
      id: nextId('canteenItems'),
      schoolId: sid,
      facilityId: pick(thoseFac)?.id || null,
      ...it,
      itemNameEn: null,
      stockQuantity: rand(50,200),
      reorderThresholdQuantity: rand(10,30),
      barcodeNumber: `BAR-${String(rand(100000000000,999999999999))}`,
      isAvailable: true
    });
  }
}

// ===== schoolEventCalendars =====
const events = [];
const eventTypes = ['رسمي','تربوي','رياضي','ثقافي','اجتماعي'];
for (const sid of activeSchoolIds) {
  for (let i = 0; i < 3; i++) {
    events.push({
      id: nextId('events'),
      schoolId: sid,
      eventTitleAr: pick(['اليوم الوطني','يوم التخرج','المهرجان الرياضي','الأسبوع الثقافي','اليوم المفتوح','معرض العلوم']),
      eventTitleEn: pick(['National Day','Graduation Day','Sports Festival','Culture Week','Open Day','Science Fair']),
      startDate: dateStr(2026,rand(1,6),rand(1,28)),
      endDate: dateStr(2026,rand(1,6),rand(1,28)),
      eventType: pick(eventTypes),
      isPublic: Math.random() > 0.5,
      description: 'فعالية مدرسية يشارك فيها جميع الطلاب',
      organizerEmployeeId: null,
      targetAudience: pick(audiences),
      locationDetails: pick(['ساحة المدرسة','قاعة الأنشطة','الملعب الرياضي']) ,
      requiresAttendanceTracking: Math.random() > 0.5
    });
  }
}

// ===== schoolFacilityMaintenanceLogs =====
const maintLogs = [];
const maintTypes = ['دورية','طارئة','تصحيحية','وقائية'];
for (const fac of facilities.slice(0,8)) {
  maintLogs.push({
    id: nextId('maintLogs'),
    schoolFacilityId: fac.id,
    maintenanceCode: `MNT-${fac.facilityCode}`,
    scheduledDate: dateStr(2026,rand(1,6),rand(1,28)),
    completedDate: Math.random() > 0.3 ? dateStr(2026,rand(1,6),rand(1,28)) : null,
    maintenanceType: pick(maintTypes),
    descriptionDetails: pick(['صيانة دورية للمرافق','إصلاح عطل في التكييف','دهان وصيانة عامة','استبدال الإضاءة','إصلاح السباكة']),
    totalCostAmount: rand(500,15000),
    responsibleEmployeeId: null,
    externalContractorName: Math.random() > 0.5 ? pick(['مؤسسة الصيانة الذهبية','شركة الرؤية للصيانة','مقاول الصيانة المعتمد']) : null,
    status: pick(['نشط','موقوف','مغلق']),
    inspectionRemarks: pick(['تم الانتهاء بنجاح','بحاجة متابعة','يوجد ملاحظات',null])
  });
}

// ===== schoolLibraryItems =====
const libraryItems = [];
const libStatuses = ['متاح','مُعار','مفقود','تالف','للترميم'];
for (const sid of activeSchoolIds.slice(0,3)) {
  const books = [
    { titleAr:'مبادئ الرياضيات', author:'د. أحمد القحطاني', isbn:'978-0-123456-78-9' },
    { titleAr:'اللغة العربية الفصحى', author:'أ. سارة الدوسري', isbn:'978-0-234567-89-0' },
    { titleAr:'الفيزياء للجميع', author:'د. خالد الزهراني', isbn:'978-0-345678-90-1' },
    { titleAr:'موسوعة العلوم', author:'أ. محمد العتيبي', isbn:'978-0-456789-01-2' },
    { titleAr:'قواعد اللغة الإنجليزية', author:'J. Smith', isbn:'978-0-567890-12-3' },
  ];
  for (const bk of books) {
    libraryItems.push({
      id: nextId('libraryItems'),
      schoolId: sid,
      itemCode: `LIB-${sid}-${String(rand(100,999))}`,
      titleAr: bk.titleAr,
      titleEn: bk.titleAr,
      authorName: bk.author,
      publisherName: pick(['مكتبة الملك فهد','دار النشر العربية','المكتبة الخضراء','منشورات الوزارة']),
      isbnNumber: bk.isbn,
      category: rand(1,10),
      itemStatus: pick(libStatuses),
      totalCopiesCount: rand(5,30),
      availableCopiesCount: rand(2,15),
      shelfLocationCode: `SH-${String.fromCharCode(64+rand(1,5))}-${rand(1,20)}`,
      unitPurchaseCost: rand(30,150),
      acquisitionDate: dateStr(2024,rand(1,12),rand(1,28))
    });
  }
}

// ===== schoolOperationalBudgetLogs =====
const budgetLogs = [];
const budgetCats = ['تشغيلية','صيانة','رواتب','أنشطة','تجهيزات','نقل'];
for (let i = 0; i < 10; i++) {
  const useDir = Math.random() > 0.5;
  const cat = pick(budgetCats);
  const allocated = rand(50000,500000);
  const consumed = rand(10000, allocated);
  budgetLogs.push({
    id: nextId('budgetLogs'),
    directorateId: useDir ? pick(directorates.map(d=>d.id)) : null,
    schoolId: !useDir ? pick(activeSchoolIds) : null,
    fiscalYear: '1446-1447',
    budgetCategoryCode: `BUD-${cat.slice(0,4).toUpperCase()}-${i}`,
    categoryNameAr: `${cat}`,
    categoryNameEn: cat,
    allocatedAmount: allocated,
    consumedAmount: consumed,
    remainingAmount: allocated - consumed,
    status: pick(['نشط','موقوف']),
    quarterNumber: rand(1,4),
    approvedByDirectorId: null,
    lastTransactionDate: dateStr(2025,rand(9,12),rand(1,28)),
    notesDescription: pick(['مصروفات تشغيلية','ميزانية الصيانة الدورية','رواتب الموظفين','تجهيزات الفصل الدراسي',null])
  });
}

// ===== schoolTransportationRoutes =====
const transportRoutes = [];
for (const sid of activeSchoolIds) {
  const routes = [
    { routeCode:`BUS-${sid}-01`, routeNameAr:`خط ${pick(['الخزامى','النزهة','الربوة','الورود','النخيل'])}`, morningStartHour:'06:00', eveningReturnHour:'13:30', monthlyFee:rand(150,350), totalSeats:44, busPlateNumber:`ABC ${rand(1000,9999)}` },
    { routeCode:`BUS-${sid}-02`, routeNameAr:`خط ${pick(['الفلاح','الصفا','الياسمين','الزهراء','الأمانة'])}`, morningStartHour:'06:15', eveningReturnHour:'13:45', monthlyFee:rand(150,350), totalSeats:44, busPlateNumber:`DEF ${rand(1000,9999)}` },
  ];
  for (const rt of routes) {
    transportRoutes.push({
      id: nextId('transportRoutes'),
      schoolId: sid,
      ...rt,
      driverEmployeeId: null,
      routeNameEn: null,
      busSupervisorEmployeeId: null,
      busModelAndYear: `Toyota Coaster ${rand(2020,2025)}`,
      totalSubscribedStudents: rand(10,35),
      gpsTrackingDeviceId: `GPS-${String(rand(100000,999999))}`,
      isActive: true
    });
  }
}

// ===== curriculumTextbookDistributions =====
const textbookDists = [];
for (const sid of activeSchoolIds.slice(0,3)) {
  const thoseSub = subjects.filter(s => s.schoolId === sid);
  for (let i = 0; i < 3; i++) {
    const sub = pick(thoseSub);
    const qty = rand(50,300);
    textbookDists.push({
      id: nextId('textbookDists'),
      schoolId: sid,
      subjectId: sub.id,
      textbookCode: `TEXT-${sid}-${i}`,
      textbookTitleAr: `${sub.subjectNameAr} - كتاب الطالب`,
      textbookTitleEn: `${sub.subjectNameEn} - Student Book`,
      editionYear: 2025,
      quantityAllocated: qty,
      quantityDistributed: rand(20, qty),
      distributionDate: dateStr(2025,rand(8,9),rand(1,15)),
      targetGradeLevel: rand(1,12),
      unitCost: rand(30,120),
      totalValueAmount: 0,
      warehouseLocationCode: `WH-${String.fromCharCode(64+rand(1,5))}-${rand(1,10)}`,
      isActive: true
    });
  }
}

// ===== gradingScaleBounds =====
const gradingScales = [
  { scaleName:'ممتاز', letterCode:'أ', minPercentage:90, maxPercentage:100, gradePointValue:4.0, descriptionAr:'ممتاز', scaleCode:'A', isPassingGrade:true, displayOrder:1 },
  { scaleName:'جيد جداً', letterCode:'ب', minPercentage:80, maxPercentage:89, gradePointValue:3.5, descriptionAr:'جيد جداً', scaleCode:'B+', isPassingGrade:true, displayOrder:2 },
  { scaleName:'جيد', letterCode:'ج', minPercentage:70, maxPercentage:79, gradePointValue:3.0, descriptionAr:'جيد', scaleCode:'B', isPassingGrade:true, displayOrder:3 },
  { scaleName:'مقبول', letterCode:'د', minPercentage:60, maxPercentage:69, gradePointValue:2.5, descriptionAr:'مقبول', scaleCode:'C+', isPassingGrade:true, displayOrder:4 },
  { scaleName:'ضعيف', letterCode:'ه', minPercentage:0, maxPercentage:59, gradePointValue:1.0, descriptionAr:'ضعيف - راسب', scaleCode:'F', isPassingGrade:false, displayOrder:5 },
];
const gradingScaleBounds = [];
for (const sid of activeSchoolIds) {
  for (const gs of gradingScales) {
    gradingScaleBounds.push({
      id: nextId('gradingScaleBounds'),
      schoolId: sid,
      ...gs,
      descriptionEn: gs.descriptionAr,
      isActive: true
    });
  }
}

// ===== referenceCodingLookups =====
const refLookups = [];
const codeTypes = ['STAGE_LEVEL','SUBJECT_CATEGORY','FACILITY_TYPE','DOCUMENT_TYPE'];
for (const sid of activeSchoolIds.slice(0,2)) {
  for (const ct of codeTypes) {
    refLookups.push({
      id: nextId('refLookups'),
      schoolId: sid,
      codeType: ct,
      codeKey: `${ct}_${sid}_${rand(1,5)}`,
      codeValueAr: pick(['أساسي','ثانوي','اختياري','إجباري','عام']),
      codeValueEn: pick(['Core','Secondary','Elective','Required','General']),
      descriptionAr: 'وصف رمز التصنيف',
      descriptionEn: 'Classification code description',
      sortOrder: rand(1,10),
      isSystemCode: Math.random() > 0.5,
      isActive: true,
      parentCodeId: null,
      notes: null
    });
  }
}

// ===== academicWarningPolicies =====
const warningPolicies = [];
for (const sid of activeSchoolIds.slice(0,3)) {
  const warnCats = ['أكاديمي','سلوكي','حضور','عام'];
  for (let i = 0; i < 3; i++) {
    warningPolicies.push({
      id: nextId('warningPolicies'),
      schoolId: sid,
      policyCode: `WARN-${sid}-${i}`,
      policyTitleAr: pick(['سياسة الإنذار الأكاديمي','سياسة الحضور والغياب','سياسة السلوك','سياسة الغياب المتكرر']),
      warningCategory: pick(warnCats),
      thresholdValue: rand(3,10),
      actionRequired: pick(['إشعار_وليّ_أمر','استدعاء_ولي_أمر','تحويل_إرشاد','إنذار_رسمي']),
      policyTitleEn: null,
      consecutiveOccurrenceLimit: rand(3,5),
      autoTriggerNotification: true,
      escalationPolicyId: null,
      isActive: true
    });
  }
}

// ===== officialCirculars =====
const circularTypesList = ['تعميم_وزاري','تعميم_إداري','قرار','تعليمات'];
const circulars = [];
for (let i = 0; i < 5; i++) {
  circulars.push({
    id: nextId('circulars'),
    circularNumber: `CIR-${String(rand(100,999))}-2026`,
    issueDate: dateStr(2026,rand(1,6),rand(1,28)),
    titleAr: pick(['تعميم بشأن بدء الفصل الدراسي الثاني','قرار تنظيم الاختبارات النهائية','تعليمات الأمن والسلامة','تعميم تطوير المناهج','قرار تشكيل لجان الاختبارات']),
    titleEn: pick(['Circular on Semester Start','Exam Organization Decision','Safety Instructions','Curriculum Development','Exam Committee Formation']),
    circularType: pick(circularTypesList),
    issuerName: 'وزارة التعليم - الإدارة العامة',
    targetAudience: pick(audiences),
    effectiveDate: dateStr(2026,1,1),
    isActive: true,
    contentBody: 'نص التعميم يشير إلى ضرورة الالتزام بالتعليمات الصادرة',
    issuerEmployeeId: null,
    attachmentFileUrl: null,
    requiresMandatoryAcknowledgment: Math.random() > 0.5,
    acknowledgmentDeadline: Math.random() > 0.5 ? dateStr(2026,rand(1,3),rand(1,28)) : null
  });
}

// ===== academicBranchConfigLogs =====
const branchConfigs = [];
for (const sid of activeSchoolIds.slice(0,3)) {
  const configs = [
    { configKey:'ATTENDANCE_POLICY', configValue:'DAILY', previousValue:'WEEKLY', changeReason:'تحديث سياسة الحضور', configCategory:'عامة', requiresSupervisoryApproval:false },
    { configKey:'GRADING_SYSTEM', configValue:'PERCENTAGE', previousValue:'LETTER', changeReason:'تغيير نظام التقييم', configCategory:'أكاديمية', requiresSupervisoryApproval:true },
  ];
  for (const cfg of configs) {
    branchConfigs.push({
      id: nextId('branchConfigs'),
      schoolId: sid,
      ...cfg,
      effectiveDate: dateStr(2025,9,1),
      modifiedByEmployeeId: null,
      approvalStatus: pick(['معتمد','قيد_المراجعة']),
      isActive: true
    });
  }
}

// ===== academicLockPeriods =====
const lockPeriods = [];
for (const sid of activeSchoolIds.slice(0,3)) {
  lockPeriods.push({
    id: nextId('lockPeriods'),
    officeId: pick(directorates.map(d => d.id)),
    schoolId: sid,
    periodName: pick(['فترة إغلاق أعمال الفصل الأول','فترة إغلاق أعمال الفصل الثاني','فترة إغلاق نهاية العام']),
    startDate: dateStr(2025,rand(11,12),rand(1,28)),
    endDate: dateStr(2026,rand(1,3),rand(1,28)),
    isActive: true,
    lockGradeRosters: true,
    lockEnrollmentSnapshots: true,
    lockPeriodStatisticalReports: true,
    lockAttendanceLogs: true,
    lockBehavioralRecords: true,
    lockFinancialFeeAssessments: true,
    unlockReasonDescription: null,
    initiatedByEmployeeId: null
  });
}

// ===== trainingCourseOfferings =====
const trainingCourses = [];
for (let i = 0; i < 6; i++) {
  const useDir = Math.random() > 0.5;
  trainingCourses.push({
    id: nextId('trainingCourses'),
    directorateId: useDir ? pick(directorates.map(d => d.id)) : null,
    schoolId: !useDir ? pick(activeSchoolIds) : null,
    courseCode: `TRN-${String(rand(1000,9999))}`,
    courseTitleAr: pick(['طرق التدريس الحديثة','إدارة الصفوف الدراسية','استخدام التقنية في التعليم','تنمية المهارات الإشرافية','القيادة التربوية','التقييم والاختبارات']),
    trainerName: pick(arabicTeachers),
    startDate: dateStr(2026,rand(1,4),rand(1,15)),
    endDate: dateStr(2026,rand(1,6),rand(1,28)),
    totalHours: rand(6,30),
    maxParticipants: rand(20,60),
    costPerParticipant: rand(0,500),
    courseTitleEn: null,
    trainingLocation: pick(['مركز التدريب الرئيسي','قاعة التدريب بالمدرسة','فندق الرياض']),
    targetSpecialization: pick(['علمي','أدبي','عام',null]),
    enrolledParticipantsCount: rand(5,30),
    certificateTemplateUrl: null,
    isActive: true
  });
}

// ===== educationalSupervisionVisits =====
const supVisits = [];
for (let i = 0; i < 6; i++) {
  const dir = pick(directorates);
  const sch = pick(schools);
  supVisits.push({
    id: nextId('supVisits'),
    directorateId: dir.id,
    schoolId: sch.id,
    supervisorName: pick(['د. عبدالله القحطاني','أ. نورة الدوسري','د. سعد الشهراني','أ. فهد المطيري','د. مريم الغامدي']),
    visitDate: dateStr(2025,rand(9,12),rand(1,28)),
    visitPurpose: pick(['متابعة أداء المعلمين','تقييم البرامج التعليمية','متابعة سير الاختبارات','تفقد المرافق المدرسية','زيارة إشرافية دورية']),
    evaluationScore: rand(60,100),
    recommendations: pick(['تحسين الأداء التدريسي','تطبيق استراتيجيات التعلم النشط','تطوير مهارات التقويم','لا توجد توصيات عاجلة']),
    status: pick(['مجدولة','منفذة','ملغاة','مؤجلة']),
    supervisorEmployeeId: null,
    targetDepartmentId: null,
    followUpRequiredDate: Math.random() > 0.5 ? dateStr(2026,rand(1,3),rand(1,28)) : null,
    actionItemsDetail: pick(['تنفيذ خطة تحسين','متابعة أسبوعية','تقرير متابعة',null])
  });
}

// ===== directorateExamCenterAssignments =====
const examCenters = [];
for (const dir of directorates) {
  for (let i = 0; i < 2; i++) {
    const sch = pick(schools);
    examCenters.push({
      id: nextId('examCenters'),
      directorateId: dir.id,
      hostedAtSchoolId: sch.id,
      examCenterCode: `EXC-${dir.id}-${i+1}`,
      examSessionTitleAr: `اختبارات نهاية الفصل الدراسي ${pick(['الأول','الثاني'])}`,
      academicYear: '1446-1447',
      targetEducationalStageId: pick(educationalStages.map(e=>e.id)),
      totalAllocatedCandidatesCount: rand(200,800),
      totalExaminationRoomsCount: rand(5,20),
      chiefSuperintendentEmployeeId: null,
      residentSecurityOfficerEmployeeId: null,
      sessionStartDate: dateStr(2026,rand(5,6),rand(1,15)),
      sessionEndDate: dateStr(2026,rand(5,6),rand(10,25)),
      centerStatus: pick(['نشط','موقوف'])
    });
  }
}

// ===== directorateLegalCaseLogs =====
const legalCases = [];
const caseCategories = ['إدارية','مالية','جنائية','عقود','أخرى'];
for (let i = 0; i < 5; i++) {
  const dir = pick(directorates);
  legalCases.push({
    id: nextId('legalCases'),
    directorateId: dir.id,
    caseCodeNumber: `LEG-${String(rand(100,999))}-${2026}`,
    caseCategory: pick(caseCategories),
    subjectTitle: pick(['قضية تعاقد صيانة','مخالفة إدارية','نزاع عقاري','قضية تشهير','مخالفة أنظمة السلامة']),
    involvedPartiesDescription: pick(['شركة المقاولات المتحدة','مقاول الصيانة','أحد الموردين','إحدى المدارس الأهلية']),
    registrationDate: dateStr(2025,rand(1,12),rand(1,28)),
    resolutionDate: Math.random() > 0.5 ? dateStr(2026,rand(1,6),rand(1,28)) : null,
    caseStatus: pick(['مفتوحة','قيد_النظر','محلولة','مغلقة']),
    resolutionDecisionText: Math.random() > 0.5 ? 'تم البت في القضية وفق الأنظمة' : null,
    assignedLegalCounselEmployeeId: null,
    caseDocumentAttachmentUrl: null
  });
}

// ===== directorateStatisticalReports =====
const statReports = [];
const periodTypes = ['أسبوعي','شهري','ربع_سنوي','نصف_سنوي','سنوي'];
const reportCats = ['أكاديمي','إداري','مالي','إحصائي'];
for (const dir of directorates) {
  for (let i = 0; i < 3; i++) {
    statReports.push({
      id: nextId('statReports'),
      directorateId: dir.id,
      reportCode: `RPT-${dir.id}-${String(i+1).padStart(2,'0')}`,
      reportTitleAr: pick(['تقرير الأداء الأكاديمي','تقرير إحصائي للطلاب','تقرير الميزانية','تقرير إنجازات المدارس']),
      reportTitleEn: null,
      targetCategory: pick(reportCats),
      periodType: pick(periodTypes),
      targetAcademicYear: '1446-1447',
      statisticalDataPayloadJson: JSON.stringify({ totalSchools: 45, totalStudents: 15000 }),
      analyticalSummary: pick(['يظهر تحسن في الأداء بنسبة 15%','مستوى الأداء مستقر','هناك حاجة لتحسين النتائج']),
      recommendationsText: pick(['تكثيف الزيارات الإشرافية','عقد دورات تدريبية','تطوير خطط التحسين',null]),
      generationDate: dateStr(2026,rand(1,6),rand(1,28)),
      compiledByEmployeeId: null,
      verificationStatus: pick(['غير_مدقق','قيد_التدقيق','مدقق','معتمد'])
    });
  }
}

// ===== visitorEntryLogs =====
const visitorLogs = [];
const visitStatuses = ['مجدولة','منفذة','ملغاة','مؤجلة'];
for (const sid of activeSchoolIds) {
  for (let i = 0; i < 3; i++) {
    visitorLogs.push({
      id: nextId('visitorLogs'),
      schoolId: sid,
      visitorFullName: pick(arabicFirstNames) + ' ' + pick(arabicLastNames),
      nationalIdOrPassport: String(rand(1000000000,9999999999)),
      visitPurpose: pick(['مقابلة مدير المدرسة','تسليم مستندات','صيانة','زيارة ولي أمر','تقديم طلب','تسليم كتب']),
      hostEmployeeId: null,
      checkInTime: dateStr(2025,rand(9,12),rand(1,28)) + 'T08:' + String(rand(0,59)).padStart(2,'0') + ':00',
      checkOutTime: Math.random() > 0.5 ? dateStr(2025,rand(9,12),rand(1,28)) + 'T' + String(rand(10,14)).padStart(2,'0') + ':00:00' : null,
      visitorBadgeNumber: `VG-${String(rand(1000,9999))}`,
      status: pick(visitStatuses),
      visitorPhoneNumber: `+9665${String(rand(10000000,99999999))}`,
      visitorOrganization: pick(['وزارة التعليم','شركة صيانة','أولياء الأمور','مكتب التربية','لا يوجد']),
      securityGateNumber: pick(['البوابة الرئيسية','البوابة الشرقية','البوابة الغربية']),
      securityOfficerEmployeeId: null
    });
  }
}

// ===== ASSEMBLE & WRITE =====
const output = {
  ...raw,
  directorates,
  schools,
  educationalStages,
  schoolAcademicYears,
  schoolSemesters,
  schoolLevels,
  schoolShifts,
  subjects,
  classrooms,
  facilities,
  schoolContactInfos,
  departments,
  gradeCapacities,
  schoolCurriculumPlans,
  classSchedules: classSchedules,
  examDistributionTimetables: examTimetables,
  classroomOperationalRules,
  classroomResourceAllocations,
  schoolAccreditationLogs: accreditations,
  schoolAnnouncementLogs: announcements,
  schoolAuditLogs: auditLogs,
  schoolCanteenItems: canteenItems,
  schoolEventCalendars: events,
  schoolFacilityMaintenanceLogs: maintLogs,
  schoolLibraryItems: libraryItems,
  schoolOperationalBudgetLogs: budgetLogs,
  schoolTransportationRoutes: transportRoutes,
  curriculumTextbookDistributions: textbookDists,
  gradingScaleBounds,
  referenceCodingLookups: refLookups,
  academicWarningPolicies: warningPolicies,
  officialCirculars: circulars,
  academicBranchConfigLogs: branchConfigs,
  academicLockPeriods: lockPeriods,
  trainingCourseOfferings: trainingCourses,
  educationalSupervisionVisits: supVisits,
  directorateExamCenterAssignments: examCenters,
  directorateLegalCaseLogs: legalCases,
  directorateStatisticalReports: statReports,
  visitorEntryLogs: visitorLogs
};

fs.writeFileSync(DB_PATH, JSON.stringify(output, null, 2), 'utf-8');
console.log('✅ db.json updated successfully.');
console.log(`   Top-level keys: ${Object.keys(output).length}`);
console.log(`   Preserved: auth, users (${raw.users.length} records)`);
