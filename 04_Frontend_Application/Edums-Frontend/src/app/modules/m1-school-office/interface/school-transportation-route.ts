export interface SchoolTransportationRoute {
  id: number;
  schoolId: number;
  routeCode: string;
  routeNameAr: string;
  driverEmployeeId: number | null;
  busPlateNumber: string | null;
  totalSeats: number;
  morningStartHour: string;
  eveningReturnHour: string;
  monthlyFee: number;
  routeNameEn: string | null;
  busSupervisorEmployeeId: number | null;
  busModelAndYear: string | null;
  totalSubscribedStudents: number;
  gpsTrackingDeviceId: string | null;
  isActive: boolean;
}

export type CreateSchoolTransportationRouteDto = Omit<SchoolTransportationRoute, 'id' | 'isActive'>;

export type UpdateSchoolTransportationRouteDto = Omit<SchoolTransportationRoute, 'schoolId' | 'isActive'>;
