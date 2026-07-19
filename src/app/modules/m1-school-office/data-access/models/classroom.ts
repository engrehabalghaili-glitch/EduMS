export interface Classroom {
  id: number;
  schoolId: number;
  classroomCode: string;
  classroomNameAr: string;
  classroomNameEn: string;
  gradeLevel: number;
  capacity: number;
  roomNumber: string | null;
  floorLevel: number;
  buildingSection: string | null;
  homeroomTeacherEmployeeId: number | null;
  isSmartClassroom: boolean;
  isActive: boolean;
}

export type CreateClassroomDto = Omit<Classroom, 'id' | 'isActive'>;

export type UpdateClassroomDto = Omit<Classroom, 'schoolId' | 'isActive'>;
