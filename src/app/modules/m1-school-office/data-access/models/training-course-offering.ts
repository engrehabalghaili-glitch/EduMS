export interface TrainingCourseOffering {
  id: number;
  directorateId: number | null;
  schoolId: number | null;
  courseCode: string;
  courseTitleAr: string;
  trainerName: string | null;
  startDate: string;
  endDate: string;
  totalHours: number;
  maxParticipants: number;
  costPerParticipant: number;
  courseTitleEn: string | null;
  trainingLocation: string | null;
  targetSpecialization: string | null;
  enrolledParticipantsCount: number;
  certificateTemplateUrl: string | null;
  isActive: boolean;
}

export type CreateTrainingCourseOfferingDto = Omit<TrainingCourseOffering, 'id' | 'isActive'>;

export type UpdateTrainingCourseOfferingDto = Omit<TrainingCourseOffering, 'directorateId' | 'schoolId' | 'isActive'>;
