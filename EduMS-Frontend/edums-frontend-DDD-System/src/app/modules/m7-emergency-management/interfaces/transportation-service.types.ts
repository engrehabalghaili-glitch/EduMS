import type { TransportationStop } from './shared.types'

export interface TransportationService {
  id: number
  schoolId: number
  routeCode: string
  routeName: string
  routeDescription?: string
  busAssetId?: number
  busPlateNumber?: string
  busCapacity?: number
  busModel?: string
  busYear?: string
  driverEmployeeId?: number
  driverLicenseNumber?: string
  driverPhone?: string
  supervisorEmployeeId?: number
  supervisorPhone?: string
  shiftId?: number
  tripType: 'ذهاب' | 'عودة' | 'ذهاب وعودة'
  startTime?: string
  endTime?: string
  estimatedDurationMinutes?: string
  stops?: TransportationStop[]
  isActive: boolean
  serviceStatus: 'نشط' | 'متوقف' | 'ملغي'
  operatorCompany?: string
  contractId?: number
  notes?: string
}

export type CreateTransportationService = Omit<TransportationService, 'id'>

export type UpdateTransportationService = Partial<TransportationService> & { id: number }

export type TransportationServiceResponse = TransportationService

export type TransportationServiceListResponse = TransportationService[]
