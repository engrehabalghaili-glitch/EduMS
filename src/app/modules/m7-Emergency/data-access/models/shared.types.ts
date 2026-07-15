export interface Attachment {
  fileName: string
  filePath: string
  fileType?: string
  fileSize?: number
}

export interface Participant {
  name: string
  type: string
  role?: string
}

export interface ExpenseItem {
  description: string
  amount: number
  date?: string
  category?: string
}

export interface ResourceItem {
  name: string
  quantity: number
  unit?: string
  description?: string
}

export interface ExternalAgency {
  name: string
  contactPerson?: string
  contactPhone?: string
  responseTime?: string
}

export interface ActionStep {
  stepNumber: number
  description: string
  assignedTo?: string
  dueDate?: string
  status: string
}

export interface TeamMember {
  employeeId: number
  name: string
  role: string
}

export interface CommitteeMember {
  name: string
  position: string
  role: string
  phone?: string
}

export interface TransportationStop {
  stopName: string
  order: number
  arrivalTime?: string
  studentCount?: number
}
